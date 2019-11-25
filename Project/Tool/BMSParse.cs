using System;
using System.IO;
using System.Linq;
using System.Text;
//using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MMConv
{
	class BMSParse
	{
		public string m_TITLE = "";
		public string m_ARTIST = "";

		public void Read( string filename ) {
			if( !File.Exists( filename ) ) {
				throw new FileNotFoundException( filename );
			}
			using( var st = new StreamReader( filename, Encoding.GetEncoding( "shift_jis" ) ) ) {

				bool c1 = false;
				bool c2 = false;
				while( st.Peek() >= 0 ) {
					if( c1 && c2 ) break;

					var s = st.ReadLine();

					bool matches( string s1, string s2, Action<GroupCollection> func ) {
						var mm = Regex.Matches( s1, s2 );
						if( 0 < mm.Count ) {
							func( mm[ 0 ].Groups );
							return true;
						}
						return false;
					}

					if( matches( s, "^#[tT][iI][tT][lL][eE] +(.*)", ( m ) => {
						m_TITLE = m[ 1 ].Value;
						c1 = true;
					} ) ) continue;
					if( matches( s, "^#[aA][rR][tT][iI][sS][tT] +(.*)", ( m ) => {
						m_ARTIST = m[ 1 ].Value;
						c2 = true;
					} ) ) continue;
				}
			}

		}
	}
}
