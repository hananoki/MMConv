using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MMConv {
	public partial class ToolConfigWindow : Form {

		MainWindow m_parent;

		public TextBox editDlgFFMpeg { get { return m_editDlgFFMpeg; } }
		public TextBox editDlgFlac { get { return m_editDlgFlac; } }
		public TextBox editDlgNeroAAC { get { return m_editDlgNeroAAC; } }
		public TextBox editDlgMP3Gain { get { return m_editDlgMP3Gain; } }
		public TextBox editDlgTak { get { return m_editDlgTak; } }
		public TextBox editDlgShn { get { return m_editDlgShn; } }
		public TextBox editDlgSoX { get { return m_editDlgSoX; } }
		public TextBox editDlg7Z { get { return m_editDlg7Z; } }
		public TextBox editDlgWavGain { get { return m_editDlgWavGain; } }
		public TextBox editDlgXWMA { get { return m_editDlgXWMA; } }
		public TextBox editDlgFUZ { get { return m_editDlgFUZ; } }

		public Button[] btnList;

		/// <summary>
		/// 
		/// </summary>
		public ToolConfigWindow( MainWindow parent ) {
			m_parent = parent;
			InitializeComponent();

			btnList = new Button[] {
				button3,
				button2,
				button1,
				m_btnDlg7Z,
				m_btnDlgSoX,
				m_btnDlgShn,
				m_btnDlgTak,
				m_btnDlgMP3Gain,
				m_btnDlgNeroAAC,
				m_btnDlgFlac,m_btnDlgFFMpeg,
			};

			foreach(var b in btnList ) {
				b.Click += OnFileDialogButton;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="toolInfo"></param>
		void ShowToolDialog( ToolAdapter toolInfo ) {
			var ofd = new OpenFileDialog();
			ofd.InitialDirectory = toolInfo.GetSettingToolPath().GetDirectory();
			ofd.FilterIndex = 1;
			ofd.Title = "開くファイルを選択してください";
			ofd.RestoreDirectory = false;
			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;
			if( ofd.ShowDialog() == DialogResult.OK ) {
				toolInfo.SetToolPath( ofd.FileName );
			}
		}

		/// <summary>
		/// ツールのファイル選択ダイアログボタン
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnFileDialogButton( object sender, EventArgs e ) {
			try {
				Button btn = sender as Button;
				Debug.Log( ((ToolType) btn.Tag).ToString() );
				ShowToolDialog( m_parent.m_toolMap[ (ToolType) btn.Tag ] );
			}
			catch( Exception ee ) {
				Log.Exception( ee );
			}
		}



		private void button1_Click( object sender, EventArgs e ) {
			Close();
		}

		private void button2_Click( object sender, EventArgs e ) {
			Close();
		}

		private void Form1_Load( object sender, EventArgs e ) {
			Font = SystemFonts.IconTitleFont;
		}
	}
}
