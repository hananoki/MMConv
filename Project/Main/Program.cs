using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsLib;

namespace MMConv {
	///using FileInfoList = List<MediaFileInfo>;

	static class Program {
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main() {
			using( var mutex = new System.Threading.Mutex( false, typeof( MainWindow ).ToString() ) ) {
				if( mutex.WaitOne( 0, false ) == false ) {
					//すでに起動していると判断して終了
					MessageBox.Show( "多重起動はできません。", typeof( MainWindow ).ToString() );
					return;
				}

				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault( false );

				Helper._init();
				Application.Run( new MainWindow() );
			}
		}
	}

	

	


	
	partial class MainWindow {
		

		#region プロパティ

		

		//public string getSettingFilePath() {
		//	//return Path.GetDirectoryName(Application.ExecutablePath) + @"\setting.json";
		//	return @"C:\usr\local\config\MediaFX.json";
		//}
		

		#endregion

		
		/// <summary>
		/// ドロップされた時の処理タイプ
		/// </summary>
		public enum DropFileType {
			None,
			File,
			Directory,
		}

		
		

		public List<MediaFileInfo> m_fileList = new List<MediaFileInfo>();

		
		
		List<CommandJobData> m_jobs = new List<CommandJobData>();
		Task m_runningTask = null;
		

		

		Bitmap m_bmpErrorCache;
		public Bitmap m_m_bmpError {
			get {
				if( m_bmpErrorCache == null ) {
					m_bmpErrorCache = SystemIcons.Error.ToBitmap();
				}
				return m_bmpErrorCache;
			}
		}
		Bitmap m_bmpWarningCache;
		public Bitmap m_bmpWarning {
			get {
				if( m_bmpWarningCache == null ) {
					m_bmpWarningCache = SystemIcons.Warning.ToBitmap();
				}
				return m_bmpWarningCache;
			}
		}
		Bitmap m_bmpInfoCache;
		public Bitmap m_bmpInfo {
			get {
				if( m_bmpInfoCache == null ) {
					m_bmpInfoCache = SystemIcons.Information.ToBitmap();
				}
				return m_bmpInfoCache;
			}
		}

		

		
	}



	
}
