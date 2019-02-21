using System;
using System.Windows.Forms;

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MMConv {
	public partial class LogWindow : Form {
		public static LogWindow instance;

		public LogWindow() {
			if( instance != null ) throw new Exception( "LogWindow singleton" );

			InitializeComponent();
			instance = this;
		}

		public void AddLog( string txt ) {
			Invoke( new Action( () => {
				lock( richTextBox1 ) {
					richTextBox1.AppendText( txt );
					richTextBox1.AppendText( "\n" );
				}
			} ) );
		}

		private void LogWindow_FormClosing( object sender, FormClosingEventArgs e ) {
			if( e.CloseReason == CloseReason.UserClosing ) {
				e.Cancel = true;
				Visible = false;
			}
		}

		private void toolStripMenuItem1_Click( object sender, EventArgs e ) {
			richTextBox1.Clear();
		}
	}

	
}
