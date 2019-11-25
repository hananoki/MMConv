using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CsLib;

namespace MMConv {
	public class Config {
		int width;
		int height;
		public int x;
		public int y;

		public int Width {
			get {
				if( width == 0 ) return 800;
				return width;
			}
			set { width = value; }
		}
		
		public int Height {
			get {
				if( height == 0 ) return 600;
				return height;
			}
			set {
				height = value;
			}
		}
		public int outputDirMode;

		public string userSaveDir;
		public int actionType;

		public string seStart;
		public string seFinish;

		public string toolFFMPEG;
		public string toolNEROAAC;
		public string toolMP3GAIN;
		public string toolFLAC;
		public string toolTAK;
		public string toolSHNTOOL;
		public string toolSOX;
		public string tool7Z;
		public string toolWAVEGAIN;
		public string toolXWMA;
		public string toolFUZ;
		public string toolBMS;

		public void RollbackWindow( Control window ) {
			window.Location = new Point( x, y );
			window.Width = Width;
			window.Height = Height;
		}

		public void BackupWindow( Control window ) {
			x = window.Location.X;
			y = window.Location.Y;
			width = window.Width;
			height = window.Height;
		}

		public void WriteSettingJson( string filepath ) {
			using( var st = new StreamWriter( filepath ) ) {
				string json = JsonUtils.ToJson( MainWindow.m_config );// LitJson.JsonMapper.ToJson( m_setting );
				st.Write( json );
			}
		}

		public void ReadSettingJson( string filepath, Action complete = null ) {
			try {
				using( var st = new StreamReader( filepath ) ) {
					MainWindow.m_config = LitJson.JsonMapper.ToObject<Config>( st.ReadToEnd() );
				}
				complete?.Invoke();
			}
			catch( FileNotFoundException ) {
				Debug.Log( $"FileNotFoundException: {filepath} が見つかりません、デフォルト動作になります" );
			}
			catch( Exception e ) {
				MainWindowHelper.SetExceptionLog( e );
			}
		}

		public string[] MakeToolPathList() {
			string[] lst = {
				toolFFMPEG,
				toolFLAC,
				toolMP3GAIN,
				toolNEROAAC,
				toolTAK,
				toolSHNTOOL,
				toolSOX,
				tool7Z,
				toolWAVEGAIN,
				toolXWMA,
				toolBMS,
			};
			return lst;
		}

		public string[] GetToolPathList() {
			return MakeToolPathList();
		}
	} // Setting
}
