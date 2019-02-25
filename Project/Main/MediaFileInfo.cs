using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Reflection;

using MediaInfoDotNet;
using MediaInfoLib;
using CsLib;

namespace MMConv {
	public class MediaFileInfo {
		public ListViewItem item;
		public string[] regData;
		public string filepath;
		//public string        filetype;
		//public string        year;
		//public string        duration;
		//public MediaFile mediaFile;

		string m_format;
		string m_artist;
		string m_album;
		string m_trackName;
		string m_trackIndex;
		string m_trackTotal;
		string m_discIndex;
		string m_discTotal;
		string m_recordedDate;
		string m_genre;
		string m_comment;
		int m_duration;
		public int m_sampleRate;
		int m_audioCount;
		//string m_audioFormat;
		//int m_audioChannels;
		//int m_audioBitDepth;
		//int m_audioBitRate;
		//string m_audioBitRateMode;

		//string m_internetMediaType;

		//public string internetMediaType {
		//	get {
		//		if( mediaFile.internetMediaType == "" ) {
		//			switch( mediaFile.format ) {
		//				case MainFrame.FORMAT_FLAC:
		//					return "audio/x-flac";
		//				default:
		//					return "unknown";
		//			}
		//		}
		//		return mediaFile.internetMediaType;
		//	}
		//}


		/// <summary>
		/// Wave, FLAC, MPEG-4, MPEG Audio
		/// </summary>
		public string format { get { return m_format; } }
		public string artist { get { return m_artist; } }
		public string album { get { return m_album; } }
		public string trackName { get { return m_trackName; } }
		public string trackIndex { get { return m_trackIndex; } }
		public string trackTotal { get { return m_trackTotal; } }
		public string discIndex { get { return m_discIndex; } }
		public string discTotal { get { return m_discTotal; } }
		public string recordedDate { get { return m_recordedDate; } }
		public string genre { get { return m_genre; } }
		public string comment { get { return m_comment; } }
		public int duration { get { return m_duration; } }

		public int sampleRate { get { return m_sampleRate; } }
		//public string internetMediaType { get { return m_internetMediaType; } }

		//public int audioCount { get { return m_audioCount; } }
		//public string audioFortmat { get { return m_audioFormat; } }
		//public int audioChannels { get { return m_audioChannels; } }
		//public int audioBitDepth { get { return m_audioBitDepth; } }
		//public int audioBitRate { get { return m_audioBitRate; } }
		//public string audioBitRateMode { get { return m_audioBitRateMode; } }

		public string m_playTime;
		public string detail;
		public string bitRate;

		public bool noMediaInfo;

		public bool Init( string filepath ) {
			var mediaFile = new MediaInfoDotNet.MediaFile( filepath );
			//if( !mediaFile.HasStreams ) {
			//	// 大文字と小文字を区別しない一致
			//	if( System.Text.RegularExpressions.Regex.IsMatch(
			//		filepath,
			//		"\\.(?:xwm)$",
			//		System.Text.RegularExpressions.RegexOptions.IgnoreCase ) ) {
			//		m_format = "XWM";
			//		noMediaInfo = true;
			//		return true;
			//	}
			//	if( System.Text.RegularExpressions.Regex.IsMatch(
			//		filepath,
			//		"\\.(?:fuz)$",
			//		System.Text.RegularExpressions.RegexOptions.IgnoreCase ) ) {
			//		m_format = "FUZ";
			//		noMediaInfo = true;
			//		return true;
			//	}
				
			//	MainWindowHelper.SetNotifyText( "ストリームを検出できませんでした" );
			//	return false;
			//}

			Dictionary<String, String> dic = new Dictionary<string, string>();

			using( var lol = new MediaInfo() ) {
				var prop = lol.GetType().GetField( "MustUseAnsi", BindingFlags.Instance | BindingFlags.NonPublic );
				prop.SetValue( lol, false );

				if( lol.Open( Uri.UnescapeDataString( filepath ) ) == 1 ) {
					foreach( string entry in lol.Inform().Split( '\n' ) ) {
						var tokens = entry.Split( ':' );
						if( tokens.Length == 2 )
							dic[ tokens[ 0 ].Trim() ] = tokens[ 1 ].Trim();
					}
					lol.Close();
				}
			}

			m_format = dic.GetValue( "Format" );
			m_artist = dic.GetValue( "Performer" );
			m_album = dic.GetValue( "Album" );
			m_trackName = dic.GetValue( "Track name" );
			m_trackIndex = dic.GetValue( "Track name/Position" );
			m_trackTotal = dic.GetValue( "Track name/Total" );
			m_discIndex = dic.GetValue( "Part name/Position" );
			m_discTotal = dic.GetValue( "Part name/Total" );
			
			m_genre = dic.GetValue( "Genre" );
			m_comment = dic.GetValue( "Comment" );
			m_recordedDate = dic.GetValue( "Recorded date" );

			switch( dic.GetValue( "Sampling rate" ) ) {
				case "32.0 KHz":
					m_sampleRate = 32000;
					break;
				case "44.1 KHz":
					m_sampleRate = 44100;
					break;
				case "48.0 KHz":
					m_sampleRate = 48000;
					break;
				case "96.0 KHz":
					m_sampleRate = 96000;
					break;
				default:
					MessageBox.Show( "未対応のサンプリングレート: {0}", dic.GetValue( "Sampling rate" ) );
					break;
			}

			m_duration = mediaFile.General.duration;
			var tm = m_duration / 1000;
			var m = ( tm / 60 ) % 60;
			var h = ( tm / 60 ) / 60; ;
			var s = ( tm % 60 );
			//m_playTime = "{0:00}:{1:00}:{2:00}".format( h, m, s );
			m_playTime = $"{h:00}:{m:00}:{s:00}";
			bitRate = dic.GetValue( "Bit rate" );

			switch( m_format ) {
				case "Wave":
				case "PCM":
					detail = $"{dic.GetValue( "Format" )}, {dic.GetValue( "Channel(s)" )}, {dic.GetValue( "Bit depth" )}";
					break;
				case "MPEG Audio":
					detail = $"{dic.GetValue( "Format" )}, {dic.GetValue( "Format version" )}, {dic.GetValue( "Format profile" )}, {dic.GetValue( "Mode" )}";
					break;
				case "MPEG-4":
					detail = $"{dic.GetValue( "Format" )}, {dic.GetValue( "Format profile" )}";
					break;
				case "FLAC":
					detail = $"{dic.GetValue( "Format" )}";
					break;
			}

			//m_audioCount = mediaFile.Audio.Count;
			return true;
		}

		public MediaFileInfo( ListViewItem item, string filepath ) {
			this.item = item;
			this.filepath = filepath;
		}

		public bool hasWav() {
			if( string.IsNullOrEmpty( m_format ) ) return false;
			if( m_format == "Wave" ) return true;
			if( m_format == "PCM" ) return true; 
			return false;
		}
	}

}
