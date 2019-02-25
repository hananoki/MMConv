using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using CsLib;

namespace MMConv {
	public static class MainWindowHelper {

		public static MainWindow s_MainWindow;

		static byte[] s_sndJobStart;
		static byte[] s_sndJobFinish;

		public static string ChangeOutputDir( string outputDir, string fullpath ) {
			if( outputDir == null ) {
				return fullpath.GetDirectory();
			}
			return outputDir;
		}

		public static void Init() {

			Func<string, byte[]> ReadBinaryFile = ( filename ) => {
				byte[] buf = null;
				if( File.Exists( filename ) ) {
					using( FileStream fs = new FileStream( filename, FileMode.Open, FileAccess.Read ) )
					using( BinaryReader r = new BinaryReader( fs ) ) {
						buf = r.ReadBytes( (int) fs.Length );
					}
				}
				return buf;
			};

			s_sndJobStart = ReadBinaryFile( MainWindow.m_config.seStart );
			s_sndJobFinish = ReadBinaryFile( MainWindow.m_config.seFinish );
		}


		public static string ChangeOutputFileName( string outputDir, string fullpath, string ext ) {
			if( outputDir == null ) {
				//var dir = fullpath.getDirectory().changeShortPath();
				//var fname = fullpath.getFileName().changeExt( ext );
				//return dir+"\\"+fname;
				//var ss = 
				//ss = ss.changeShortPath();
				return fullpath.ChangeExtention( ext );
			}
			string s = @"{0}\{1}.{2}".format( outputDir, fullpath.GetBaseName(), ext );
			return s;
		}


		public static void SetNotifyText( string text = "", NotifyType type = NotifyType.Info, int interval = 10000 ) {
			s_MainWindow.SetNotifyText( text, type, interval );
		}

		public static void SetExceptionLog( Exception e ) {
			s_MainWindow.SetExceptionLog(e);
		}

		public static void SetProcessLog( string format, params object[] args ) {
			s_MainWindow.SetProcessLog( format, args );
		}

		public static void PlaySoundJobStart() {
			PlaySE( s_sndJobStart );
		}
		public static void PlaySoundJobFinish() {
			PlaySE( s_sndJobFinish );
		}

		public static void PlaySE( byte[] buf ) {
			Win32.PlaySound( buf, IntPtr.Zero, Win32.PlaySoundFlags.SND_MEMORY | Win32.PlaySoundFlags.SND_ASYNC );
		}
	}
}
