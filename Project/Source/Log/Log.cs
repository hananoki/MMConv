using System;

namespace MMConv {
	public static class Log {
		public static void Info( string txt ) {
			LogWindow.instance.AddLog( "[Info] " + txt );
		}
		public static void Warning( string txt ) {
			LogWindow.instance.AddLog( "[Warning] " + txt );
		}
		public static void Error( string txt ) {
			LogWindow.instance.AddLog( "[Error] " + txt );
		}
		public static void Exception( Exception e ) {
			LogWindow.instance.AddLog( "[Exception] " + e.ToString() );
		}
	}
}
