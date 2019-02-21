
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using System.Text.RegularExpressions;

using Microsoft.Win32;


public class CueSheet {
	public class Track {
		public string title;
		public string performer;
		public int min = 0;
		public int sec = 0;
		public int frm = 0;
	}

	public Track[] m_track;
	public string m_title = "";
	public string m_performer = "";
	public string m_file = "";
	public string m_genre = "";
	public string m_date = "";
	public string m_discid = "";

	public Track this[ int i ] {
		get { return this.m_track[ i ]; }
	}
	public CueSheet() {
	}
	public CueSheet( int num ) {
		m_track = new Track[ num ];
	}

	public int Count {
		get { return m_track.Length; }
	}

	public void setAudioInfo( int n, string min, string sec, string frm ) {
		if( m_track[ n ] == null ) {
			m_track[ n ] = new Track();
		}
		var t = m_track[ n ];
		t.min = Convert.ToInt32( min );
		t.sec = Convert.ToInt32( sec );
		t.frm = Convert.ToInt32( frm );
	}
	public void makeFormat() {
		for( int i = 1; i < m_track.Length; ++i ) {
			var ms1 = m_track[ i ].frm;
			var ms2 = m_track[ i - 1 ].frm;
			var ss1 = m_track[ i ].sec;
			var ss2 = m_track[ i - 1 ].sec;
			var mm1 = m_track[ i ].min;
			var mm2 = m_track[ i - 1 ].min;
			var ms3 = ms1 + ms2;
			if( 100 <= ms3 ) {
				ms3 -= 100;
				ss2 += 1;
			}
			var ss3 = ss1 + ss2;
			if( 60 <= ss3 ) {
				ss3 -= 60;
				mm2 += 1;
			}
			var mm3 = mm1 + mm2;
			//console.log( "+  {0}:{1}:{2} ", m1, m2, m3 );
			m_track[ i ].min = mm3;
			m_track[ i ].sec = ss3;
			m_track[ i ].frm = ms3;
		}
		for( int i = m_track.Length - 1; 1 <= i; --i ) {
			m_track[ i ] = m_track[ i - 1 ];
		}
		m_track[ 0 ] = new Track();
	}

	public void read( string filename ) {
		if( !File.Exists( filename ) ) {
			throw new FileNotFoundException( "ファイルねい", filename );
		}
		using( var st = new System.IO.StreamReader( filename, Encoding.GetEncoding( "shift_jis" ) ) ) {
			var lst = new List<Track>();

			while( st.Peek() >= 0 ) {
				var s = st.ReadLine();

				Func<string, string, Action<GroupCollection>, bool> matches = ( s1, s2, func ) => {
					var mm = Regex.Matches( s1, s2 );
					if( 0 < mm.Count ) {
						func( mm[ 0 ].Groups );
						return true;
					}
					return false;
				};
				if( matches( s, "^REM GENRE +(.*)", ( m ) => {
					m_genre = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^REM DATE +(.*)", ( m ) => {
					m_date = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^REM DISCID +(.*)", ( m ) => {
					m_discid = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^  TRACK", ( m ) => {
					lst.Add( new Track() );
					lst[ lst.Count - 1 ].performer = m_performer;
				} ) ) continue;
				if( matches( s, "^    TITLE +\"(.*)\"", ( m ) => {
					lst[ lst.Count - 1 ].title = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^    PERFORMER +\"(.*)\"", ( m ) => {
					lst[ lst.Count - 1 ].performer = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^TITLE \"(.*)\"", ( m ) => {
					m_title = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^FILE \"(.*)\"", ( m ) => {
					m_file = m[ 1 ].Value;
				} ) ) continue;
				if( matches( s, "^PERFORMER +\"(.*)\"", ( m ) => {
					m_performer = m[ 1 ].Value;
				} ) ) continue;
			}

			m_track = lst.ToArray();
		}
	}
	public void write( string filename ) {
		using( var w = new StreamWriter( filename, false, Encoding.GetEncoding( "shift_jis" ) ) ) {
			if( m_genre != "" ) {
				w.WriteLine( "REM GENRE {0}", m_genre );
			}
			if( m_genre != "" ) {
				w.WriteLine( "REM DATE {0}", m_date );
			}
			w.WriteLine( "PERFORMER \"{0}\"", m_performer );
			w.WriteLine( "TITLE \"{0}\"", m_title );
			w.WriteLine( "FILE \"{0}\" WAVE", filename.getFileName().ChangeExtention( "wav" ) );
			foreach( var t in m_track.Select( ( v, i ) => new { v, i } ) ) {
				int min = 0;
				int sec = 0;
				int frm = 0;
				min = t.v.min;
				sec = t.v.sec;
				frm = (int) ( (float) t.v.frm * 0.75f );
				if( 75 <= frm ) {
					frm = 0;
					sec += 1;
				}
				if( 60 <= sec ) {
					sec = 0;
					min += 1;
				}
				w.WriteLine( "  TRACK {0:D2} AUDIO", t.i + 1 );
				if( t.v.title.Contains( "\"" ) ) {
					w.WriteLine( "    TITLE {0}".format( t.v.title ) );
				}
				else {
					w.WriteLine( "    TITLE \"{0}\"".format( t.v.title ) );
				}
				w.WriteLine( "    PERFORMER \"{0}\"".format( t.v.performer ) );
				w.WriteLine( "    INDEX 01 {0:D2}:{1:D2}:{2:D2}", min, sec, frm );
			}
		}
	}
}
