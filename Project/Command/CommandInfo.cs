using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MMConv {
	public struct CommandInfo {
		public Action<CommandJobData> func;
		public RadioButton ctrl;
		public CommandInfo( Action<CommandJobData> func, RadioButton ctrl ) {
			this.func = func;
			this.ctrl = ctrl;
		}
	};

	
}
