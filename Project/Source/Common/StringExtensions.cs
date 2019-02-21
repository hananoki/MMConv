
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Collections.Generic;


public static class StringExtensions {
	public static string GetValue( this Dictionary<string, string> dic, string key ) {
		return dic.ContainsKey( key ) ? dic[ key ] : "";
	}

	public static string format( this string fm, params object[] values ) {
		return string.Format( fm, values );
	}
	public static string quote( this string s ) {
		return '"' + s + '"';
	}
	public static int toInt32( this string s ) {
		return Convert.ToInt32( s );
	}
	public static string getExt( this string s ) {
		return Path.GetExtension( s );
	}
	public static string GetDirectory( this string s ) {
		if( s == "" ) return "";
		return Path.GetDirectoryName( s );
	}

	public static string getFileName( this string s ) {
		return Path.GetFileName( s );
	}

	public static string ChangeExtention( this string s, string ext ) {
		return Path.ChangeExtension( s, ext );
	}

	public static string GetBaseName( this string s ) {
		return Path.GetFileNameWithoutExtension( s );
	}

	public static bool isPathRooted( this string s ) {
		return Path.IsPathRooted( s );
	}

	public static string replace( this string s1, string s2, string s3 ) {
		return Regex.Replace( s1, s2, s3, RegexOptions.Singleline );
	}

	public static bool match( this string s1, string s2, Action<GroupCollection> func ) {
		var mm = Regex.Matches( s1, s2 );
		if( 0 < mm.Count ) {
			func( mm[ 0 ].Groups );
			return true;
		}
		return false;
	}

	public static string match2( this string s1, string s2, Func<GroupCollection, string> func1 ) {
		var mm = Regex.Matches( s1, s2 );
		if( 0 < mm.Count ) {
			return func1( mm[ 0 ].Groups );
		}
		return null;
	}
	public static string match2( this string s1, string s2, Func<GroupCollection, string> func1, Func<string> func2 ) {
		var mm = Regex.Matches( s1, s2 );
		if( 0 < mm.Count ) {
			return func1( mm[ 0 ].Groups );
		}
		return func2();
	}

	private const uint FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

	public static string changeShortPath( this string s ) {
		var sb = new StringBuilder( 1024 );
		uint ret = Win32.GetShortPathName( s, sb, (uint) sb.Capacity );
		if( ret == 0 ) {
			int errCode = Marshal.GetLastWin32Error();
			if( errCode != 0 ) {
				Console.WriteLine( "Win32エラー・コード：" +
					String.Format( "{0:X8}", errCode ) );

				StringBuilder message = new StringBuilder( 255 );

				Win32.FormatMessage(
					FORMAT_MESSAGE_FROM_SYSTEM,
					IntPtr.Zero,
					(uint) errCode,
					0,
					message,
					message.Capacity,
					IntPtr.Zero );

				Console.WriteLine( "Win32エラー・メッセージ：" +
					message.ToString() );

				throw new Exception( "短いファイル名の取得に失敗しました。" );
			}
		}
		return sb.ToString();
	}
}

