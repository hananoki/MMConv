using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace MMConv {
	/// <summary>
	/// ツール情報に絡んだ情報のパイプ役
	/// </summary>
	public struct ToolAdapter {
		Action<string> SetSettingToolPath;
		public Func<string> GetSettingToolPath;
		public TextBox ctrl;

		public ToolAdapter( Action<string> func, Func<string> func2, TextBox ctrl ) {
			this.SetSettingToolPath = func;
			this.GetSettingToolPath = func2;
			this.ctrl = ctrl;
			SetToolPath( GetSettingToolPath() );
		}

		public void SetToolPath( string filepath ) {
			SetSettingToolPath( filepath );
			ctrl.Text = filepath;
			UpdateCtrlState();
		}

		void UpdateCtrlState() {
			if( !File.Exists( GetSettingToolPath() ) ) {
				ctrl.BackColor = Color.Pink;
			}
			else {
				ctrl.BackColor = Color.White;
			}
		}
	}
}
