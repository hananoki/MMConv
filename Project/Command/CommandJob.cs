using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tsukikage.DllPInvoke.MP3Tag;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace MMConv {
	public class CommandJobData {
		public CommandType type;
		public List<MediaFileInfo> fileInfoList = new List<MediaFileInfo>();
		public string outputDir;

		public CommandJobData( CommandType type, List<MediaFileInfo> fileList, string outputDir ) {
			this.type = type;
			this.fileInfoList = fileList;
			this.outputDir = outputDir;
		}
	}


	public class CommandOutput {
		public string Error { get; set; }
		public string Output { get; set; }

		public CommandOutput() {
			Error = "";
			Output = "";
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public static class CommandJob {
		public const string FORMAT_FLAC = "FLAC";


		internal static void MessageProcessStatus( string msg ) {
			MainWindowHelper.SetProcessLog( msg, NotifyType.Info, 0 );
		}

		internal static void MessageProcessComplete( string msg ) {
			MainWindowHelper.SetProcessLog( msg, NotifyType.Info, 5000 );
		}

		static void RunParallel( CommandJobData j, Action<int, MediaFileInfo, string> func ) {
			Parallel.For( 0, j.fileInfoList.Count, MainWindow.m_parallelOptions, i => {
				try {
					func( i, j.fileInfoList[ i ], j.outputDir );
				}
				catch( Exception e ) {
					MainWindowHelper.SetExceptionLog( e );
				}
			} );
		}

		#region Outputs Property

		private static object _outputsLockObject;
		private static object OutputsLockObject {
			get {
				if( _outputsLockObject == null )
					Interlocked.CompareExchange( ref _outputsLockObject, new object(), null );
				return _outputsLockObject;
			}
		}

		private static Dictionary<object, CommandOutput> _outputs;
		private static Dictionary<object, CommandOutput> Outputs {
			get {
				if( _outputs != null )
					return _outputs;

				lock( OutputsLockObject ) {
					_outputs = new Dictionary<object, CommandOutput>();
				}
				return _outputs;
			}
		}

		#endregion

		static int StartProcess( string filename, string arguments ) {
			Log.Info( $"{filename} {arguments}" );

			//*
			//using(  ) {
			var p = new System.Diagnostics.Process();
			p.StartInfo.FileName = filename;
			p.StartInfo.Arguments = arguments;
			p.StartInfo.UseShellExecute = false;
			p.StartInfo.CreateNoWindow = true;
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

			p.StartInfo.RedirectStandardOutput = true;
			p.StartInfo.RedirectStandardError = true;
			p.StartInfo.RedirectStandardInput = false;
			//p.StartInfo.StandardOutputEncoding = Encoding.GetEncoding( "Shift_JIS" );
			//p.StartInfo.StandardErrorEncoding = Encoding.GetEncoding( "Shift_JIS" );
			p.EnableRaisingEvents = true;

			ConcurrentQueue<string> messages = new ConcurrentQueue<string>();

			p.ErrorDataReceived += ErrorDataHandler;
			p.OutputDataReceived += OutputDataHandler;

			var output = new CommandOutput();
			Outputs.Add( p, output );

			p.Start();
			//
			p.BeginErrorReadLine();
			p.BeginOutputReadLine();

			p.WaitForExit();

			Outputs.Remove( p );

			//if( ( !String.IsNullOrWhiteSpace( output.Error ) ) ) {
			//	//return output.Error.TrimEnd( '\n' );
			//	Log.Error( output.Error.TrimEnd( '\n' ) );
			//}
			//Debug.Log(  );

			if( p.ExitCode != 0 ) {
				Log.Error( $"[StandardOutput] {output.Output.TrimEnd( '\n' )}" );
				Log.Error( $"[StandardError] {output.Error.TrimEnd( '\n' )}" );
			}

			return p.ExitCode;
			//}
			/*/
			return 0;
			/**/
		}
		private static void ErrorDataHandler( object sendingProcess, DataReceivedEventArgs errLine ) {
			if( errLine.Data == null )
				return;

			if( !Outputs.ContainsKey( sendingProcess ) )
				return;

			var commandOutput = Outputs[ sendingProcess ];

			commandOutput.Error = commandOutput.Error + errLine.Data + "\n";
		}

		private static void OutputDataHandler( object sendingProcess, DataReceivedEventArgs outputLine ) {
			if( outputLine.Data == null )
				return;

			if( !Outputs.ContainsKey( sendingProcess ) )
				return;

			var commandOutput = Outputs[ sendingProcess ];

			commandOutput.Output = commandOutput.Output + outputLine.Data + "\n";
		}


		static string fixedFileName( string s ) {
			s = s.Replace( "/", "／" );
			s = s.Replace( "?", "？" );
			s = s.Replace( "\\", "￥" );
			s = s.Replace( "*", "＊" );
			s = s.Replace( ":", "：" );
			s = s.Replace( "\"", "”" );
			s = s.Replace( "<", "＜" );
			s = s.Replace( ">", "＞" );
			s = s.Replace( "|", "｜" );
			return s;
		}


		static string selectOutputDir( string outputDir, string fullpath ) {
			if( outputDir == null ) {
				return fullpath.GetDirectory();
			}
			return outputDir;
		}


		/// <summary>
		/// 分割WavをCueSheetを元にリネーム
		/// </summary>
		/// <param name="filepath"></param>
		static void ApplyWavDirCueSheet( string outputDir, string filepath ) {
			var fdir = outputDir;

			var cue = new CueSheet();
			cue.read( filepath.ChangeExtention( "cue" ) );

			string[] wavs = Directory.GetFiles( fdir, "*.wav", System.IO.SearchOption.TopDirectoryOnly );

			wavs = wavs.Where( a => !a.Contains( "split-track00") ).ToArray();
			//Array.Find( wavs, a => a == "split-track00" );
			
			bool allow = false;
			if( 0 == wavs.Length || 0 == cue.Count ) {
				allow = true;

				MessageProcessStatus( "分割" );
				return;
			}
			if( allow == false && wavs.Length != cue.Count ) {
				MessageProcessComplete( "error" );
				return;
			}

			// リネーム用のリストがない場合は終了
			if( cue.Count == 0 ) return;

			foreach( var f in wavs ) {

				foreach( Match match in Regex.Matches( f, "(split-track)([0-9]+)" ) ) {
					try {
						int i = int.Parse( match.Groups[ 2 ].Value );
						CueSheet.Track track = cue[ i - 1 ];
						string title = track.title;
						title = title.Replace( "/", "／" );
						title = title.Replace( "?", "？" );
						title = title.Replace( "\\", "￥" );
						title = title.Replace( "*", "＊" );
						title = title.Replace( ":", "：" );
						title = title.Replace( "\"", "”" );
						title = title.Replace( "<", "＜" );
						title = title.Replace( ">", "＞" );
						title = title.Replace( "|", "｜" );

						try {
							TagInfo tag1 = Tsukikage.DllPInvoke.MP3Tag.MP3Infp.LoadTag( f );
							tag1.Album = cue.m_title;
							tag1.Artist = track.performer;
							tag1.Title = track.title;
							tag1.Genre = cue.m_genre;
							tag1.CreationDate = cue.m_date;
							tag1.TrackNumber = i.ToString();
							Tsukikage.DllPInvoke.MP3Tag.MP3Infp.SaveTagInfoUnicode( tag1 );
						}
						catch( Exception e ) {
							MainWindowHelper.SetExceptionLog( e );
						}
						var ss = Regex.Replace( f, "(split-track[0-9]+)", match.Groups[ 2 ].Value + " " + title );
						//	println( titleList[i-1] );
						//	var invalidChars = Path.GetInvalidFileNameChars();
						//	var removed = string.Concat(original.Where(c => !invalidChars.Contains(c)));
						File.Move( f, ss );
					}
					catch( Exception e ) {
						MainWindowHelper.SetExceptionLog( e );
					}
				}
			}
		}


		/// <summary>
		/// 結合wavをcueで分割する
		/// </summary>
		static void SplitWav( string outputDir, string filepath ) {

			var fdir = outputDir;

			if( !Directory.Exists( fdir ) ) {
				Directory.CreateDirectory( fdir );
			}

			var fname = filepath.getFileName();

			string[] files = Directory.GetFiles( fdir, "*.wav", System.IO.SearchOption.TopDirectoryOnly );

			// フォルダ内にwavが存在していた場合は事前分割とみなす
			if( 1 <= files.Length ) return;

			var command3 = "split -O never -d {0} -f {1} -o wav {2}".format(
				fdir.quote(),
				fname.ChangeExtention( "cue" ).quote(),
				fname.quote() );

			StartProcess( "shntool", command3 );
		}


		/// <summary>
		/// WAVファイルに変換するジョブ
		/// </summary>
		/// <param name="j"></param>
		public static void JobCnvWAV( CommandJobData j ) {

			Helper.SetCurrentDirectory( j.fileInfoList[ 0 ].filepath.GetDirectory() );

			int num = 0;
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				num++;
				MainWindowHelper.SetNotifyText( $"処理中({num}/{j.fileInfoList.Count})", interval: 0 );

				if( fileinfo.hasWav() ) {
					Log.Warning( $"[{fileinfo.filepath}] WAVEフォーマットなので無視します" );
					return;
				}
				var filepath = fileinfo.filepath.GetDirectory().changeShortPath() + "\\" + fileinfo.filepath.getFileName();
				var filepath2 = fileinfo.filepath.GetDirectory() + "\\" + fileinfo.filepath.getFileName();

				string newfilepath = MainWindowHelper.ChangeOutputFileName( outputDir, filepath, "wav" );

				switch( fileinfo.format ) {
					case "XWM":
						StartProcess(
							"xwmaencode",
							$"{filepath.quote()} {newfilepath.quote()}" );
						break;

					case "FUZ":
						StartProcess(
							"Fuz_extractor",
							$"-e {filepath.quote()}" );
						StartProcess(
							"xwmaencode",
							$"{MainWindowHelper.ChangeOutputFileName( outputDir, filepath2, "xwm" ).quote()} {newfilepath.quote()}" );

						var sss = MainWindowHelper.ChangeOutputFileName( outputDir, filepath2, "xwm" );
						if( File.Exists( sss ) ) {
							File.Delete( sss );
						}

						break;

					case FORMAT_FLAC:
						StartProcess(
							"flac",
							"-d {0} -o {1}".format( filepath.quote(), newfilepath.quote() ) );
						break;
					default:
						StartProcess(
							"ffmpeg",
							"-i {0} -y {1}".format( filepath.quote(), newfilepath.quote() ) );
						break;
				}

				if( !fileinfo.noMediaInfo ) {
					TagInfo tag1 = Tsukikage.DllPInvoke.MP3Tag.MP3Infp.LoadTag( newfilepath );
					tag1.Album = fileinfo.album;
					tag1.Artist = fileinfo.artist;
					tag1.Title = fileinfo.trackName;
					tag1.CreationDate = fileinfo.recordedDate;
					tag1.Genre = fileinfo.genre;
					tag1.Comment = fileinfo.comment;
					//tag1.Duration = fileinfo.duration;
					//tag1.TrackNumber = fileinfo.trackIndex + "/" + fileinfo.trackTotal;
					tag1.TrackNumber = fileinfo.trackIndex;
					Debug.Log( "{0}/{1}  {2}/{3}".format( fileinfo.trackIndex, fileinfo.trackTotal, fileinfo.discIndex, fileinfo.discTotal ) );
					Tsukikage.DllPInvoke.MP3Tag.MP3Infp.SaveTagInfoUnicode( tag1 );
				}
			} );

			MainWindowHelper.SetNotifyText( @"「WAVに変換」が完了しました" );
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="j"></param>
		public static void JobCnvM4A( CommandJobData j ) {
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				string input = filepath;
				string output = Path.ChangeExtension( input, ".m4a" );
				//var audio = fileinfo.mediaFile.Audio[ 0 ];
				//input.wav -r 44100 output.wav
				if( 48000 < fileinfo.sampleRate ) {
					string tmp = Path.GetTempPath() + "\\" + input.getFileName();
					StartProcess(
					"sox",
					"{0} -r 48000 {1}".format( input.quote(), tmp.quote() ) );
					input = tmp;
				}


				StartProcess(
					"neroAacEnc",
					"-lc -q 1.00 -if {0} -of {1}".format( input.quote(), output.quote() ) );

				StartProcess( "mp3gain", "/r /c /p {0}".format( output.quote() ) );
			} );
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="j"></param>
		public static void JobCnvFLAC( CommandJobData j ) {
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				string newfilepath = System.IO.Path.ChangeExtension( filepath, ".flac" );
				var args = String.Format( "-8 {0} -o {1}", filepath.quote(), newfilepath.quote() );

				StartProcess( "flac", args );
			} );
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="j"></param>
		public static void JobCnvXWM( CommandJobData j ) {
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				
				string newfilepath = filepath.ChangeExtention( ".xwm" );
				//var args = String.Format( "-8 {0} -o {1}", filepath.quote(), newfilepath.quote() );

				StartProcess( "xwmaencode", $"{filepath.quote()} {newfilepath.quote()}" );
				Debug.Log( newfilepath );
			} );
		}


		public static void JobCopyM4V( CommandJobData j ) {
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				string newfilepath = System.IO.Path.ChangeExtension( filepath, ".m4v" );
				var args = String.Format( "-i {0} -vcodec copy -acodec copy {1}", filepath.quote(), newfilepath.quote() );
				//console.log( lst[ i ] );
				StartProcess( "ffmpeg", args );
			} );
		}


		public static void JobCopyMKV( CommandJobData j ) {
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				string newfilepath = System.IO.Path.ChangeExtension( filepath, ".mkv" );
				var args = String.Format( "-i {0} -vcodec copy -acodec copy {1}", filepath.quote(), newfilepath.quote() );
				StartProcess( "ffmpeg", args );
			} );
		}


		/// <summary>
		/// CDバッチ処理
		/// </summary>
		/// <param name="j"></param>
		public static void JobCDFlac( CommandJobData j ) {

			RunParallel( j, ( i, f, outputDir ) => {
				if( !f.hasWav() ) {
					MainWindowHelper.SetNotifyText( "jobCDBatch: {0}は対応していません".format( f.format ), NotifyType.Warning );
					return;
					//continue;
				}

				var filepath = f.filepath;
				Helper.SetCurrentDirectory( filepath.GetDirectory() );

				var fname = filepath.GetBaseName();
				var cueFile = filepath.ChangeExtention( "cue" );
				if( !File.Exists( cueFile ) ) {
					MainWindowHelper.SetNotifyText( "makeTaskFlacPack: {0}が見つかりませんでした".format( cueFile.getFileName() ), NotifyType.Warning );
					return;
					//continue;
				}

				string newfilepath = MainWindowHelper.ChangeOutputFileName( j.outputDir, filepath, "flac" );

				//if( File.Exists( newfilepath ) ) {
				//	File.Delete( newfilepath );
				//}
				{
					var zfile = newfilepath.ChangeExtention( "zip" );
					if( File.Exists( zfile ) ) {
						File.Delete( zfile );
					}
				}


				var logFile = fname + ".log";
				var jpgFile = fname + ".jpg";
				var jpgOpt = "--picture=\"{0}\"".format( jpgFile );
				if( !File.Exists( filepath.ChangeExtention( "jpg" ) ) ) {
					DialogResult result = MessageBox.Show(
						String.Format( "[{0}.jpg] が見つかりませんでした。\n画像の埋め込み「なし」で継続しますがよろしいですか？", fname ),
						"what is this",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
					if( result == DialogResult.No ) {
						return;
					}
					jpgOpt = "";
					jpgFile = "";
				}
				var cueOpt = "--tag-from-file=\"CUESHEET={0}.cue\"".format( fname );
				var opt = "-8 --replay-gain {0} {1} \"{2}.wav\" -o {3}".format( jpgOpt, cueOpt, fname, newfilepath.quote() );
				MainWindowHelper.SetNotifyText( "flacでエンコード中... [{0}]".format( filepath.getFileName() ), interval: 0 );
				StartProcess( "flac", opt );

				StringBuilder s = new StringBuilder();
				s.Append( "a -y -mx=0 {0} {1}".format( newfilepath.ChangeExtention( "zip" ).quote(), newfilepath.quote() ) );

				//string[] addFile = { logFile, jpgFile, cueFile.getFileName() };

				var addFile = ( new string[] { logFile, jpgFile, cueFile.getFileName() } )
					.Where( a => !string.IsNullOrEmpty( a ) )
					.Where( a => File.Exists( a ) )
					.Select( a => a.quote() )
					.ToArray()
					;

				//foreach( var a in addFile ) {
				//	if( a == null || a == "" ) continue;
				//	if( File.Exists( a ) ) {
				//		s.Append( " " );
				//		s.Append( a.quote() );
				//	}
				//	else {
				//		setProcessLog( "{0}: not found".format( a ) );
				//	}
				//}
				s.Append( " " );
				s.Append( string.Join( " ", addFile ) );

				string[] addFolder = { "DVD", "特典DVD", "ブックレット" };
				foreach( var a in addFolder ) {
					if( Directory.Exists( a ) ) {
						s.Append( " " );
						s.Append( a.quote() );
					}
				}
				MainWindowHelper.SetNotifyText( "zip圧縮中... [{0}]".format( filepath.getFileName().ChangeExtention( "zip" ) ) );
				StartProcess( "7z", s.ToString() );
			} );
			MainWindowHelper.SetNotifyText( @"「CD -> FLAC」が完了しました" );
		}


		public static void JobSoundParge( CommandJobData j ) {
			foreach( var aa in j.fileInfoList ) {
				//				console.log( a.getExt() );
				var a = aa.filepath;
				using( var p = new System.Diagnostics.Process() ) {
					p.StartInfo.FileName = @"ffprobe";
					p.StartInfo.Arguments = "{0}".format( a.quote() );
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.CreateNoWindow = true;
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.RedirectStandardError = true;
					p.Start();
					//string hoge = p.StandardOutput.ReadToEnd();
					//string hoge2 = p.StandardError.ReadToEnd();

					Debug.Log( "{0} {1}".format( p.StartInfo.FileName, p.StartInfo.Arguments ) );
					string[] s = p.StandardError.ReadToEnd().Replace( "\r", "" ).Split( '\n' );
					foreach( var line in s ) {
						var match = Regex.Matches( line, @"^Input" );
						if( match.Count != 0 ) {
							Debug.Log( line );
						}
						if( Regex.Matches( line, @"Stream" ).Count != 0 ) {
							Debug.Log( line );
						}
						var match2 = Regex.Matches( line, @"Stream #([0-9]):([0-9]).*: Audio: ([a-zA-Z0-9_]+)" );
						if( match2.Count != 0 ) {
							var m = match2[ 0 ];
							Debug.Log( "#{0}:{1} {2}".format( m.Groups[ 1 ].Value, m.Groups[ 2 ].Value, m.Groups[ 3 ].Value ) );

							var ext = m.Groups[ 3 ].Value;
							switch( ext ) {
								case "aac":
									StartProcess( "ffmpeg", "-i {0} -vn -acodec copy {1}".format( a.quote(), MainWindowHelper.ChangeOutputFileName( j.outputDir, a, "m4a" ).quote() ) );
									break;
								case "vorbis":
									StartProcess( "ffmpeg", "-i {0} -vn -acodec copy {1}".format( a.quote(), MainWindowHelper.ChangeOutputFileName( j.outputDir, a, "ogg" ).quote() ) );
									break;
								case "mp3":
									StartProcess( "ffmpeg", "-i {0} -vn -acodec copy {1}".format( a.quote(), MainWindowHelper.ChangeOutputFileName( j.outputDir, a, "mp3" ).quote() ) );
									break;
							}
						}
					}
					p.WaitForExit();
				}
			}
		}


		/// <summary>
		/// flac > wav > split > gain
		/// </summary>
		/// <param name="flist"></param>
		public static void JobWavSplitGain( CommandJobData j ) {
			foreach( var f in j.fileInfoList ) {
				var filepath = f.filepath;

				if( filepath.Contains( ".flac" ) ) {
					var f1 = filepath.GetDirectory().changeShortPath() + "\\" + filepath.getFileName();
					var f2 = MainWindowHelper.ChangeOutputFileName( j.outputDir, filepath, "wav" );
					StartProcess(
							"flac",
							"-d {0} -o {1}".format( f1.quote(), f2.quote() ) );

					filepath = filepath.replace( ".flac", ".wav" );
				}

				Helper.SetCurrentDirectory( filepath.GetDirectory() );

				var outputDir = selectOutputDir( j.outputDir, filepath ).changeShortPath();
				var wavdir = outputDir + "\\" + filepath.GetBaseName() + "_WAV";

				MessageProcessStatus( "splitWav ..." );
				SplitWav( wavdir, filepath );

				//分割WavをCueSheetを元にリネーム
				MessageProcessStatus( "applyWavDirCueSheet ..." );
				ApplyWavDirCueSheet( wavdir, filepath );

				var files = Directory.GetFiles( wavdir, "*", System.IO.SearchOption.AllDirectories )
					.Where( a => a.getExt()==".wav" )
					.ToArray();
			
				foreach( var ff in  files ){
					Debug.Log( ff);
				}

				//parallelCommand( flist, ( i, fileinfo, outputDir ) => {
				//}
				int num = 0;
				
				Parallel.For( 0, files.Length, MainWindow.m_parallelOptions, i => {
					try {
						num++;
						MessageProcessStatus( $"処理中... ({num}/{files.Length})" );
						StartProcess( "WaveGain", "-r -y {0}".format( files[ i ].quote() ) );
					}
					catch( Exception e ) {
						MainWindowHelper.SetExceptionLog( e );
					}
				} );
			}

			MessageProcessComplete( @"「WavSplitGain」が完了しました" );
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="flist"></param>
		public static void JobWavSplit( CommandJobData j ){
			foreach( var f in j.fileInfoList ) {
				var filepath = f.filepath;
				Helper.SetCurrentDirectory( filepath.GetDirectory() );

				var outputDir = selectOutputDir( j.outputDir, filepath ).changeShortPath();
				var wavdir = outputDir + "\\" + filepath.GetBaseName() + "_WAV";

				MessageProcessStatus( "WAVに分割しています" );
				SplitWav( wavdir, filepath );

				//分割WavをCueSheetを元にリネーム
				ApplyWavDirCueSheet( wavdir, filepath );
			}
		}

		
		/// <summary>
		/// リプレイゲイン
		/// </summary>
		/// <param name="flist"></param>
		public static void JobReplayGain( CommandJobData flist ) {
			int num = 0;
			RunParallel( flist, ( i, fileinfo, outputDir ) => {
				num++;
				MessageProcessStatus( "処理中... ({0}/{1})".format( num, flist.fileInfoList.Count )/*, interval: 0*/ );

				var fname = fileinfo.filepath.quote();
				switch( fileinfo.format ) {
					case "Wave":
						StartProcess( "WaveGain", "-r -y {0}".format( fname ) );
						break;
					case "MPEG-4":
					case "MPEG Audio":
						StartProcess( "mp3gain", "/r /c /k /p {0}".format( fname ) );
						break;
				}
			} );
			MessageProcessComplete( @"「WaveGain」が完了しました" );
		}


		/// <summary>
		/// 
		/// </summary>
		public static void JobDickPack( CommandJobData j ) {

			var f = j.fileInfoList[ 0 ];

			Helper.SetCurrentDirectory( f.filepath.GetDirectory() );

//			console.log( f.filepath.getBaseName());
			var baseName = f.filepath.GetBaseName();

			baseName = baseName.replace( @"(\s?\[?Disc.*)", "" );
			Debug.Log( "baseName: " + baseName );
			var files = Directory.GetFiles( f.filepath.GetDirectory(), "*", System.IO.SearchOption.AllDirectories )
					.Where( a => a.Contains( baseName ) )
					.Where( a => !a.Contains( ".wav" ) )
					.ToArray();

			//string[] addFolder = { "DVD", "特典DVD", "ブックレット" };
			foreach( var a in (new string[]{ "DVD", "特典DVD", "ブックレット" }) ) {
				if( Directory.Exists( a ) ) {
					ArrayUtility.Add( ref files , a );
				}
			}

			var str = string.Join( "\n", files.Select( a =>  "> "+a.getFileName() ).ToArray() );

			DialogResult result = MessageBox.Show(
						string.Format( "アーカイブ対象 (*.flac)\n\n" + str + "\nよろしいですか？" ),
						"確認",
						MessageBoxButtons.YesNo,
						MessageBoxIcon.Question );
			if( result == DialogResult.No ) {
				return;
			}

			var zipfile = baseName + ".zip";
			MessageProcessStatus( "zip圧縮中... " + zipfile );

			
			StringBuilder s = new StringBuilder();
			s.Append( "a -y -mx=0 {0} {1}".format( zipfile.quote(), string.Join( " ", files.Select( a => a.quote() ).ToArray() ) ) );

			StartProcess( "7z", s.ToString() );

			MessageProcessComplete( @"「複数DiscPack」が完了しました" );
		}

		
		/// <summary>
		/// CueSheetを元に分割してエンコードする
		/// </summary>
		/// <param name="j"></param>
		public static void JobCDSplitM4A( CommandJobData j ) {
			foreach( var f in j.fileInfoList ) {
				var filepath = f.filepath;
				Helper.SetCurrentDirectory( filepath.GetDirectory() );

				var outputDir = Helper.ChangeOutputDir( j.outputDir, filepath ).changeShortPath();
				var wavdir = outputDir + "\\" + filepath.GetBaseName() + "_WAV";

				//結合wavをcueで分割する
				MainWindowHelper.SetNotifyText( "WAVに分割しています", interval: 0 );
				SplitWav( wavdir, filepath );

				//分割WavをCueSheetを元にリネーム
				ApplyWavDirCueSheet( wavdir, filepath );

				var fdirM4A = outputDir + "\\" + filepath.GetBaseName();
				if( !Directory.Exists( fdirM4A ) ) {
					Directory.CreateDirectory( fdirM4A );
				}
				if( File.Exists( filepath.ChangeExtention( "jpg" ) ) ) {
					File.Copy( filepath.ChangeExtention( "jpg" ), fdirM4A + "\\cover.jpg", true );
					File.Copy( filepath.ChangeExtention( "jpg" ), wavdir + "\\cover.jpg", true );
				}

				string[] m4a = Directory.GetFiles( fdirM4A, "*.m4a", SearchOption.TopDirectoryOnly );
				if( m4a.Length == 0 ) {
					string[] files2 = Directory.GetFiles( wavdir, "*.wav", SearchOption.TopDirectoryOnly );
					int num = 0;
					Parallel.For( 0, files2.Length, MainWindow.m_parallelOptions, i => {
						num++;
						MainWindowHelper.SetNotifyText( "エンコード処理中... ({0}/{1})".format( num, files2.Length ), interval: 0 );
						string output = fdirM4A + "\\" + files2[ i ].getFileName().ChangeExtention( "m4a" );
						StartProcess(
							"neroAacEnc",
							"-lc -q 1.00 -if {0} -of {1}".format( files2[ i ].quote(), output.quote() ) );
						StartProcess( "mp3gain", "/r /c /p {0}".format( output.quote() ) );
					} );
				}
			}
			MainWindowHelper.SetNotifyText( @"「CD -> SplitM4A」が完了しました" );
		}

		
		/// <summary>
		/// WAV結合
		/// </summary>
		/// <param name="j"></param>
		public static void JobWavJoin( CommandJobData j ) {
			//	string args = "";
			var cueSheet = new CueSheet( j.fileInfoList.Count );

			Helper.SetCurrentDirectory( j.fileInfoList[ 0 ].filepath.GetDirectory() );

			//updateFileList( j.fileInfoList );

			int num = 0;
			RunParallel( j, ( i, fileinfo, outputDir ) => {
				var filepath = fileinfo.filepath;
				num++;
				MainWindowHelper.SetNotifyText( "解析中... ({0}/{1})".format( num, j.fileInfoList.Count ), interval: 0 );

				using( var p = new System.Diagnostics.Process() ) {
					p.StartInfo.FileName = @"sox";
					p.StartInfo.Arguments = "--i {0}".format( filepath.quote() );
					p.StartInfo.UseShellExecute = false;
					p.StartInfo.CreateNoWindow = true;
					p.StartInfo.RedirectStandardOutput = true;
					p.StartInfo.RedirectStandardError = true;
					p.Start();
					string[] stdout = p.StandardOutput.ReadToEnd().Replace( "\r", "" ).Split( '\n' );
					foreach( var line in stdout ) {
						if( Regex.Matches( line, @"Duration" ).Count == 0 ) continue;
						var mm = Regex.Matches( line, @"Duration.*([0-9][0-9]):([0-9][0-9])\.([0-9][0-9])" );
						var m = mm[ 0 ];

						cueSheet.setAudioInfo( i, m.Groups[ 1 ].Value, m.Groups[ 2 ].Value, m.Groups[ 3 ].Value );
					}
				}
			} );

			cueSheet.makeFormat();

			var performerList = new List<string>();
			for( int i = 0; i < cueSheet.m_track.Length; ++i ) {
				cueSheet[ i ].title = j.fileInfoList[ i ].trackName;
				cueSheet[ i ].performer = j.fileInfoList[ i ].artist;
				if( performerList.Contains( j.fileInfoList[ i ].artist ) == false ) {
					performerList.Add( j.fileInfoList[ i ].artist );
				}
			}

			cueSheet.m_performer = "Various Artists";
			if( performerList.Count < 3 && performerList[ 0 ] != "" ) {
				cueSheet.m_performer = performerList[ 0 ];
			}
			cueSheet.m_title = "no title";
			if( j.fileInfoList[ 0 ].album != "" ) {
				cueSheet.m_title = j.fileInfoList[ 0 ].album;
			}
			cueSheet.m_genre = j.fileInfoList[ 0 ].genre;
			cueSheet.m_date = j.fileInfoList[ 0 ].recordedDate;

			StringBuilder str = new StringBuilder();
			foreach( var f in j.fileInfoList.Select( ( v, i ) => { return new { v, i }; } ) ) {
				if( 0 < f.i ) {
					str.Append( " " );
				}
				str.Append( f.v.filepath.getFileName().quote() );
			}

			var newOutput = Helper.ChangeOutputDir( j.outputDir, j.fileInfoList[ 0 ].filepath );
			string outputName = @"{0}\{1} - {2}.wav".format( newOutput, cueSheet.m_performer, cueSheet.m_title );

			//ファイル名に使用できない文字を取得
			char[] invalidChars = System.IO.Path.GetInvalidFileNameChars();

			var dname = outputName.GetDirectory();
			var fname = outputName.getFileName();

			//fname = fname.Replace( "~", "～" );
			fname = fname.Replace( "?", "？" );
			//fname = fname.Replace( " ", "_" );

			if( fname.IndexOfAny( invalidChars ) < 0 ) {
				Console.WriteLine( "ファイル名に使用できない文字は使われていません。" );
			}
			else {
				Console.WriteLine( "ファイル名に使用できない文字が使われています。" );
				MessageBox.Show( "不正なファイル名です。\n" + fname );
				return;
			}

			//System.Text.RegularExpressions.Regex r =
			//	new System.Text.RegularExpressions.Regex(
			//		"[\\x00-\\x1f<>:\"/\\\\|?*]" +
			//		"|^(CON|PRN|AUX|NUL|COM[0-9]|LPT[0-9]|CLOCK\\$)(\\.|$)" + 
			//		"|[\\. ]",
			//		System.Text.RegularExpressions.RegexOptions.IgnoreCase);

			////マッチしたら、不正なファイル名
			//if( r.IsMatch( fname ) ) {
			//	Console.WriteLine( "不正なファイル名です。" + fname );
			//	MessageBox.Show( "不正なファイル名です。\n" + fname );
			//	return;
			//}

			outputName = dname + "\\" + fname;

			str.Append( " " );
			str.Append( outputName.quote() );

			cueSheet.write( outputName.ChangeExtention( "cue" ) );
			MainWindowHelper.SetNotifyText( @"wavファイルを結合しています... [{0}]".format( outputName ) );
			StartProcess( "sox", str.ToString() );

			MainWindowHelper.SetNotifyText( @"「WAV結合」が完了しました [{0}]".format( outputName ) );
		}


		/// <summary>
		/// タグ情報を元にリネーム
		/// </summary>
		/// <param name="j"></param>
		public static void JobTagRename( CommandJobData j ) {
			//parallelCommand( flist, ( filepath, outputDir ) => {
			//	runningProcess( "sox", "/r /c /k /p {0}".format( filepath.quote() ) );
			//} );
			foreach( var f in j.fileInfoList ) {
				var fileMap = new Dictionary<string, string>() {
					{ "Wave",  ".wav" },
					{ "FLAC",  ".flac" },
					{ "MPEG-4",  ".m4a" },
					{ "MPEG Audio",  ".mp3" },
				};
				StringBuilder newName = new StringBuilder();
				newName.Append( f.filepath.GetDirectory() );
				newName.Append( "\\" );
				if( f.discIndex != "" ) {
					newName.Append( "{0}-".format( f.discIndex ) );
				}
				if( f.trackIndex != "" ) {
					newName.Append( "{0:D2} {1}".format( f.trackIndex.toInt32(), fixedFileName( f.trackName ) ) );
				}
				else {
					newName.Append( "{0}".format( ( f.trackName ) ) );
				}

				if( fileMap.ContainsKey( f.format ) ) {
					newName.Append( fileMap[ f.format ] );
				}
				File.Move( f.filepath, newName.ToString() );
				Debug.Log( f.filepath + " : " + newName.ToString() );
			}
		}
	}
}
