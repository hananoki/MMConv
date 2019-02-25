using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsLib;

namespace MMConv {
	//using StringList = List<string>;


	//using FileInfoList = List<MediaFileInfo>;
	//using MP3Infp = Tsukikage.DllPInvoke.MP3Tag.MP3Infp;

	public enum NotifyType {
		None,
		Info,
		Warning,
		Error,
	}

	/// <summary>
	/// 
	/// </summary>
	public partial class MainWindow : Form {

		public static Config m_settingInstance;
		public static Config m_config {
			get {
				if( m_settingInstance == null ) {
					m_settingInstance = new Config();
				}
				return m_settingInstance;
			}
			set {
				m_settingInstance = value;
			}
		}

		public Timer timer;
		//Setting m_setting = new Setting();

		string m_userSaveDir {
			get {
				return m_config.userSaveDir;
			}
			set {
				m_config.userSaveDir = value;
			}
		}

		// 0:入力と一緒
		int m_outputDirMode {
			get { return m_config.outputDirMode; }
			set { m_config.outputDirMode = value; }
		}


		const string m_videoType = "mp4|m4v|avi|mpg|mpeg|flv|webm|mkv";
		const string m_audioType = "m4a|mp3|mka|mp2|wav|tak|flac|ape|tta|wv|ogg|xwm|fuz";
		const string m_mediaType = m_videoType + "|" + m_audioType;

		public static ParallelOptions m_parallelOptions = new ParallelOptions();

		public Dictionary<CommandType, CommandInfo> m_actionMap;


		public Dictionary<ToolType, ToolAdapter> m_toolMap;
		ToolConfigWindow m_ToolConfigWindow;

		LogWindow m_logWindow;

		CommandType m_actionType {
			get { return (CommandType) m_config.actionType; }
			set { m_config.actionType = (int) value; }
		}

		public  void MakeToolMap() {
			m_toolMap = new Dictionary<ToolType, ToolAdapter>() {
				{
					ToolType.FFMPEG,
					new ToolAdapter(
						f => m_config.toolFFMPEG = f,
						() => m_config.toolFFMPEG,
						m_ToolConfigWindow.editDlgFFMpeg )
				},{
					ToolType.FLAC,
					new ToolAdapter(
						f => m_config.toolFLAC = f,
						() => m_config.toolFLAC,
						m_ToolConfigWindow.editDlgFlac )
				},{
					ToolType.MP3GAIN,
					new ToolAdapter(
						f=>m_config.toolMP3GAIN=f, ()=>{return m_config.toolMP3GAIN;},m_ToolConfigWindow.editDlgMP3Gain ) },
				{ ToolType.NEROAAC,   new ToolAdapter( f=>m_config.toolNEROAAC=f, ()=>{return m_config.toolNEROAAC;},m_ToolConfigWindow.editDlgNeroAAC ) },
				{ ToolType.TAK,       new ToolAdapter( f=>m_config.toolTAK =f,     ()=>{return m_config.toolTAK;},m_ToolConfigWindow.editDlgTak ) },
				{ ToolType.SHNTOOL,   new ToolAdapter( f=>m_config.toolSHNTOOL=f,     ()=>{return m_config.toolSHNTOOL;}, m_ToolConfigWindow.editDlgShn ) },
				{ ToolType.SOX,       new ToolAdapter( f=>m_config.toolSOX=f,     ()=>{return m_config.toolSOX;}, m_ToolConfigWindow.editDlgSoX ) },
				{
				ToolType.SEVENZ, new ToolAdapter(
					f => m_config.tool7Z=f,
					() => m_config.tool7Z,
					m_ToolConfigWindow.editDlg7Z )
				},{
				ToolType.WAVEGAIN, new ToolAdapter(
					f=>m_config.toolWAVEGAIN=f,
					()=>{return m_config.toolWAVEGAIN;},
					m_ToolConfigWindow.editDlgWavGain )
				},{
				ToolType.XWMA, new ToolAdapter(
					f=>m_config.toolXWMA=f,
					()=>{return m_config.toolXWMA;},
					m_ToolConfigWindow.editDlgXWMA )
				},{
				ToolType.FUZ, new ToolAdapter(
					f => m_config.toolFUZ = f,
					() => m_config.toolFUZ,
					m_ToolConfigWindow.editDlgFUZ )
				},
			};
		}


		void MakeCommandMap() {
			m_actionMap = new Dictionary<CommandType, CommandInfo>() {
				{ CommandType.CnvWAV,  new CommandInfo( CommandJob.JobCnvWAV, m_rbtnCnvWav ) },
				{ CommandType.CnvM4A,  new CommandInfo( CommandJob.JobCnvM4A, m_rbtnCnvM4A ) },
				{ CommandType.CnvFLAC, new CommandInfo( CommandJob.JobCnvFLAC, m_rbtnCnvFLAC ) },
				{ CommandType.CnvXWM,  new CommandInfo( CommandJob.JobCnvXWM, m_rbtnCnvXWM ) },
				//{ CommandType.CnvXWM,  new CommandInfo( CommandJob.JobCnvXWM, m_rbtnCnvFLAC ) },

				{ CommandType.CopyM4V, new CommandInfo( CommandJob.JobCopyM4V, m_rbtnCopyM4V ) },
				{ CommandType.CopyMKV, new CommandInfo( CommandJob.JobCopyMKV, m_rbtnCopyMKV ) },

				{ CommandType.CDFlac,      new CommandInfo( CommandJob.JobCDFlac, m_rbtnCDBatch ) },
				{ CommandType.CDSplitM4A,  new CommandInfo( CommandJob.JobCDSplitM4A, m_rbtnCDBatch2 ) },
				{ CommandType.SoundParge,  new CommandInfo( CommandJob.JobSoundParge, m_rbtnSoundSplit ) },
				{ CommandType.ReplayGain,  new CommandInfo( CommandJob.JobReplayGain, m_rbtnReplayGain ) },
				{ CommandType.WavJoin,     new CommandInfo( CommandJob.JobWavJoin, m_rbtnWavJoin ) },

				{ CommandType.TagRename,  new CommandInfo( CommandJob.JobTagRename, m_rbtnTagRename ) },

				{ CommandType.DiscPack,  new CommandInfo( CommandJob.JobDickPack, m_rbtnWavGain) },
				{ CommandType.WavSplit,  new CommandInfo( CommandJob.JobWavSplit, m_rbtnWavSplit) },
				{ CommandType.WavSplitGain,  new CommandInfo( CommandJob.JobWavSplitGain, m_rbtnWavSplitGain) },
			};
		}


		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindow() {
			InitializeComponent();
			MainWindowHelper.s_MainWindow = this;

			m_listView.SetDoubleBuffered( true );
		}


		ListViewItem[] _item;

		//
		// 引数が示すindexのアイテムを返すと描画される
		//
		void listView1_RetrieveVirtualItem( object sender, RetrieveVirtualItemEventArgs e ) {
			if( _item == null ) return;
			e.Item = _item[ e.ItemIndex ];
		}


		/// <summary>
		/// パス名からディレクトリかファイルを判定します
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		DropFileType checkDropFileType( string path ) {
			if( System.IO.File.Exists( path ) == true ) {
				return DropFileType.File;
			}
			else if( System.IO.Directory.Exists( path ) == true ) {
				return DropFileType.Directory;
			}
			return DropFileType.None;
		}


		private void Window_PreviewDragOver( object sender, DragEventArgs e ) {
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				if( ( e.KeyState & 8 ) == 8 ) {
					e.Effect = DragDropEffects.Copy;
				}
				else {
					e.Effect = DragDropEffects.Move;
				}
			}
			else {
				e.Effect = DragDropEffects.None;
			}

			//e.Handled = true;
		}


		public void setNotifyTextDefault( string text ) {
			SetNotifyText( text );
		}

		public void SetNotifyText( string text = "", NotifyType type = NotifyType.Info, int interval = 10000 ) {
			Invoke( new Action( () => {
				m_txtNotify.Text = text;
				switch( type ) {
					case NotifyType.None:
						m_picNotify.Image = null;
						break;
					case NotifyType.Info:
						m_picNotify.Image = m_bmpInfo;
						break;
					case NotifyType.Warning:
						m_picNotify.Image = m_bmpWarning;
						break;
					case NotifyType.Error:
						m_picNotify.Image = m_m_bmpError;
						break;
				}
				timer.Stop();
				if( 1 <= interval ) {
					timer.Interval = interval;
					timer.Start(); // timer.Start()と同じ
				}
			} ) );
			//Debug.Log( text );
		}


		public void SetExceptionLog( Exception e ) {
			var ss = e.ToString().Replace( "\r", "" ).Split( '\n' );
			foreach( var s in ss ) {
				//listBox1.Items.Add( s );
			}
			SetNotifyText( "例外エラーが発生しました", NotifyType.Error );
			Debug.Log( e.ToString() );
		}


		public void SetProcessLog( string format, params object[] args ) {
			try {
				SetNotifyText( string.Format( format, args ), NotifyType.Info );
			}
			catch( Exception e ) {
				SetExceptionLog( e );
			}
		}


		/// <summary>
		/// 
		/// </summary>
		public void ClearList() {
			//for( int i = m_listView.Items.Count - 1; 0 <= i; i-- ) {
			//	m_listView.Items.RemoveAt( i );
			//}

			//foreach( ListViewItem item in m_listView.Items ) {
			//	m_listView.Items.Remove( item );
			//}
			m_listView.VirtualListSize = 0;
			m_fileList.Clear();
		}


		static bool geFilterFilename( string file ) {
			return System.Text.RegularExpressions.Regex.IsMatch(
					file,
					"\\.(?:" + m_mediaType + ")$",
					System.Text.RegularExpressions.RegexOptions.IgnoreCase );
		}


		/// <summary>
		/// 
		/// </summary>
		async void startTask() {
			m_pictureBox1.Visible = true;

			if( m_runningTask != null ) {
				lock( m_runningTask ) {
					if( m_runningTask != null ) {
						Debug.Log( "m_runningTaskが存在.. job入れて返す" );
						return;
					}
				}
			}

			SetNotifyText( "処理を開始します" );
			MainWindowHelper.PlaySoundJobStart();

			m_runningTask = Task.Factory.StartNew( () => {
				for( ; ; ) {
					try {
						CommandJobData job;
						lock( m_jobs ) {
							if( m_jobs.Count == 0 ) break;
							Debug.Log( "jobから取得" );
							job = m_jobs[ 0 ];
							m_jobs.Remove( m_jobs[ 0 ] );
						}
						if( job.outputDir != null && !Directory.Exists( job.outputDir ) ) {
							Directory.CreateDirectory( job.outputDir );
						}
						m_actionMap[ job.type ].func( job );
					}
					catch( Exception e ) {
						SetExceptionLog( e );
					}
				}
			} );
			await m_runningTask;

			lock( m_runningTask ) {
				Debug.Log( "m_runningTask 終了" );
				//m_tasks.Clear();
				//win32api.PlaySound( "se-075.wav", IntPtr.Zero, win32api.PlaySoundFlags.SND_FILENAME | win32api.PlaySoundFlags.SND_ASYNC );
				MainWindowHelper.PlaySoundJobFinish();
				//	m_uiStart.Enabled = true;
				m_pictureBox1.Visible = false;

				MainWindowHelper.PlaySoundJobFinish();

				m_runningTask = null;
			}
		}


		/// <summary>
		/// ドロップ時の処理
		/// </summary>
		/// <param name="e"></param>
		async void OnDropProcess( object sender, DragEventArgs e ) {

			m_pictureBox1.Visible = true;

			if( ( e.KeyState & 8 ) != 8 ) {
				// ctrl押してない時はリスト消す
				ClearList();
			}

			Action<string> addData = ( filepath ) => m_fileList.Add( new MediaFileInfo( null, filepath ) );

			foreach( var s in (string[]) e.Data.GetData( DataFormats.FileDrop, false ) ) {
				var type = checkDropFileType( s );
				if( type == DropFileType.None ) continue;

				if( type == DropFileType.Directory ) {
					string[] files = Array.FindAll( Directory.GetFiles( s, "*", SearchOption.AllDirectories ), geFilterFilename );

					foreach( var wav in files ) {
						addData( wav );
					}
				}
				//ファイル
				else if( type == DropFileType.File ) {
					if( geFilterFilename( s ) ) {
						addData( s );
					}
				}
			}

			await Task.Factory.StartNew( () => {
				int num = 0;
				Parallel.For( 0, m_fileList.Count, m_parallelOptions, i => {
					num++;
					SetNotifyText( $"解析中({num}/{m_fileList.Count})", interval: 0 );
					var f = m_fileList[ i ];
					if( f.item != null ) return;

					if( !m_fileList[ i ].Init( f.filepath ) ) {
						Log.Error( $"{f.filepath} 解析に失敗しました" );
						return;
					}
					f.regData = new string[]{
							f.filepath,
							f.format,
							f.m_playTime,
							f.bitRate,
							f.detail,
						};
				} );
			} );

			SetNotifyText( "解析が終了しました" );
			//m_fileList.Where();

			m_listView.VirtualListSize = m_fileList.Count;
			_item = new ListViewItem[ m_fileList.Count ];
			for( int i = 0; i < m_fileList.Count; i++ ) {
				var f = m_fileList[ i ];
				if( f.regData == null ) {
					f.item = new ListViewItem(new string[] { "","","","",""} );
				}
				else {
					f.item = new ListViewItem( f.regData );
				}
				f.item.Checked = true;
				_item[ i ] = f.item;
			}
			//foreach( var f in m_fileList ) {
			//	if( f.item != null ) continue;
			//	f.item = m_listView.Items.Add( new ListViewItem( f.regData ) );
			//	f.item.Checked = true;
			//}

			try {
				m_listView.Columns[ 0 ].Width = -1;
				m_listView.Columns[ 1 ].Width = -1;
				m_listView.Columns[ 2 ].Width = -1;
				m_listView.Columns[ 3 ].Width = -1;
				m_listView.Columns[ 4 ].Width = -1;
			}
			catch( InvalidOperationException ee3 ) {
				Log.Exception( ee3 );
			}
			catch( Exception ee ) {
				Log.Exception( ee );
			}


			UpdateOutputDirectory();

			m_pictureBox1.Visible = false;
		}


		/// <summary>
		/// 出力設定によるUIの更新
		/// </summary>
		public void UpdateOutputDirectory() {
			m_outputDirMode = comboBox1.SelectedIndex;

			if( m_outputDirMode == 0 ) {
				m_editOutDir.Enabled = false;
				m_btnOpenFileDlg.Enabled = false;
			}
			else {
				m_editOutDir.Enabled = true;
				m_btnOpenFileDlg.Enabled = true;
			}

			if( m_outputDirMode == 0 ) {
				if( m_listView.Items.Count == 0 ) {
					m_editOutDir.Text = "入力ファイルがありません";
				}
				else {
					m_editOutDir.Text = Path.GetDirectoryName( m_listView.Items[ 0 ].Text );
				}
			}
			else {
				m_editOutDir.Text = m_userSaveDir;
			}
		}


		


		/// <summary>
		/// フォームの初期化
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="ev"></param>
		private void Form1_Load( object sender, EventArgs ev ) {
			timer = new Timer();
			timer.Tick += new EventHandler( ( s, ee ) => {
				m_txtNotify.Text = "";
				m_picNotify.Image = null;
				//Debug.Log( "timer" );
				timer.Stop();
			} );

			Helper.ReadJson( ref m_settingInstance, Helper.m_configPath );

			Debug.Log( "環境変数を設定します" );

			var toolPaths = m_config.GetToolPathList().
				Where( x => !string.IsNullOrEmpty( x ) ).
				Select( x => Path.GetDirectoryName( x ) ).ToArray();

			Helper.SetEnvironmentPath( string.Join( ";", toolPaths ) );

			try {
				Font = SystemFonts.IconTitleFont;

				SetNotifyText( type: NotifyType.None );

				m_ToolConfigWindow = new ToolConfigWindow( this );
				
				MakeCommandMap();
				MakeToolMap();
				comboBox1.SelectedIndex = m_config.outputDirMode;
				UpdateOutputDirectory();

				if( m_actionMap != null ) {
					foreach( var c in m_actionMap ) {
						c.Value.ctrl.BackColor = Color.Transparent;
					}
					m_actionMap[ m_actionType ].ctrl.Checked = true;
					m_actionMap[ m_actionType ].ctrl.BackColor = Color.LightSkyBlue;
				}

				MainWindowHelper.Init();

				var info = new Win32.SystemInfo();
				Win32.GetSystemInfo( out info );

				if( 1 < info.dwNumberOfProcessors ) {
					m_parallelOptions.MaxDegreeOfParallelism = (int) info.dwNumberOfProcessors - 1;
				}


				if( comboBox1.SelectedIndex < 0 ) {
					comboBox1.SelectedIndex = 0;
				}
				m_pictureBox1.Visible = false;

				ClearList();
				// 必須：描画に必要なListViewItemを返すイベント追加
				m_listView.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler( listView1_RetrieveVirtualItem );

				m_config.RollbackWindow( this );

				UpdateOutputDirectory();

				m_btnOpenFileDlg.Height = m_editOutDir.Height;

				Debug.Log( "Form1_Load called" );
			}
			catch( Exception e ){
				SetExceptionLog( e );
			}

			
			LogWindow.Visible = false;
			//m_logWindow.AddLog("start log");
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosing( object sender, FormClosingEventArgs e ) {
			m_config.outputDirMode = comboBox1.SelectedIndex;
			m_config.BackupWindow( this );
			Helper.WriteJson( m_config, Helper.m_configPath );
		}


		private void m_btnOpenFileDlg_Click( object sender, EventArgs e ) {
			//FolderBrowserDialogクラスのインスタンスを作成
			FolderBrowserDialog fbd = new FolderBrowserDialog();

			//上部に表示する説明テキストを指定する
			fbd.Description = "フォルダを指定してください。";
			//ルートフォルダを指定する
			//デフォルトでDesktop
			fbd.RootFolder = Environment.SpecialFolder.Desktop;
			//最初に選択するフォルダを指定する
			//RootFolder以下にあるフォルダである必要がある
			fbd.SelectedPath = m_userSaveDir;//@"C:\Windows";
			//ユーザーが新しいフォルダを作成できるようにする
			//デフォルトでTrue
			fbd.ShowNewFolderButton = true;

			//ダイアログを表示する
			if( fbd.ShowDialog( this ) == DialogResult.OK ) {
				//選択されたフォルダを表示する
				//Console.WriteLine( fbd.SelectedPath );
				m_userSaveDir = fbd.SelectedPath;

				UpdateOutputDirectory();
			}
		}

		//private void listView1_DragDrop( object sender, DragEventArgs e ) {
		//	OnDropProcess( e );
		//}

		private void m_listView_DragEnter( object sender, DragEventArgs e ) {
			
			if( e.Data.GetDataPresent( DataFormats.FileDrop ) ) {
				if( ( e.KeyState & 8 ) == 8 ) {
					e.Effect = DragDropEffects.Copy;
				}
				else {
					e.Effect = DragDropEffects.Move;
				}
			}
			else {
				e.Effect = DragDropEffects.None;
			}
		}


		private void OnClick_ListClear( object sender, EventArgs e ) {
			ClearList();
			UpdateOutputDirectory();

			SetNotifyText( "リストをクリアしました" );
		}

		
		private void comboBox1_SelectedIndexChanged( object sender, EventArgs e ) {
			UpdateOutputDirectory();
		}
		

		/// <summary>
		/// ラジオボタンをクリックした時のイベント処理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="ev"></param>
		private void OnRadioBtn_CheckedChanged( object sender, EventArgs ev ) {
			try {
				var rbtn = (RadioButton) sender;
				if( rbtn.Checked ) {
					if( m_actionMap.ContainsKey( m_actionType ) ) {
						m_actionMap[ m_actionType ].ctrl.BackColor = Color.Transparent;
					}
					
					m_actionType = (CommandType) rbtn.Tag;
					if( m_actionMap.ContainsKey( m_actionType ) ) {
						m_actionMap[ m_actionType ].ctrl.BackColor = Color.LightSkyBlue;
					}
					Debug.Log( m_actionType.ToString() );
				}
			}
			catch( Exception e ){
				SetExceptionLog( e );
			}
		}

		


		/// <summary>
		/// 実行ボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_uiStart_Click( object sender, EventArgs e ) {
			if( m_listView.Items.Count == 0 ) {
				SetProcessLog( "リストが空なので無視します" );
				return;
			}

			var lst = new List<MediaFileInfo>();
			foreach( var f in m_fileList ) {
				if( f.item.Checked ) {
					lst.Add( f );
				}
			}
			lock( m_jobs ) {
				string s = null;
				if( m_outputDirMode == 1 ) {
					s = m_userSaveDir;
				}
				m_jobs.Add( new CommandJobData( m_actionType, lst, s ) );
			}
			startTask();
		}


		private void m_listView_DoubleClick( object sender, EventArgs ev ) {
			try {
				ListView lw = (ListView) sender;
				if( lw.SelectedItems.Count == 0 ) return;
				using( var p = System.Diagnostics.Process.Start( lw.SelectedItems[ 0 ].SubItems[ 0 ].Text ) ) {
				}
			}
			catch( Exception  ){
			}
		}

		private void OnClick_ToolPanel( object sender, EventArgs e ) {
			m_ToolConfigWindow.ShowDialog();
		}

		private void button2_Click( object sender, EventArgs e ) {
			//if( !m_logWindow.Visible ) {
			LogWindow.Visible = true;
			//}
		}

		private void m_editOutDir_TextChanged( object sender, EventArgs e ) {
			if( m_outputDirMode == 1 ) {
				m_userSaveDir = m_editOutDir.Text;
				Debug.Log( m_userSaveDir );
			}
		}
	} // class
} // namespace
