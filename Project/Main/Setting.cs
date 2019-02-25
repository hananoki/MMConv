using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MMConv {
	public class Setting {
		int witdh;
		public int Width {
			get {
				if( witdh == 0 ) return 800;
				return witdh;
			}
			set { witdh = value; }
		}
		int height;
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


		public void WriteSettingJson( string filepath ) {
			using( var st = new StreamWriter( filepath ) ) {
				string json = JsonUtils.ToJson( MainWindow.m_setting );// LitJson.JsonMapper.ToJson( m_setting );
				st.Write( json );
			}
		}

		public void ReadSettingJson( string filepath, Action complete = null ) {
			try {
				using( var st = new StreamReader( filepath ) ) {
					MainWindow.m_setting = LitJson.JsonMapper.ToObject<Setting>( st.ReadToEnd() );
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
			};
			return lst;
		}

		public string[] GetToolPathList() {
			return MakeToolPathList();
		}
	} // Setting
}
