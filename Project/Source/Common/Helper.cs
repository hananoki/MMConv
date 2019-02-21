using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


	public static class JsonUtils {
		public static string ToJson<T>( T obj ) {
			var builder = new StringBuilder();
			var writer = new LitJson.JsonWriter( builder ) {
				PrettyPrint = true
			};
			LitJson.JsonMapper.ToJson( obj, writer );
			return builder.ToString();
		}
	}

public static partial class Helper {
	public static string ChangeOutputDir( string outputDir, string fullpath ) {
		if( outputDir == null ) {
			return fullpath.GetDirectory();
		}
		return outputDir;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="value"></param>
	public static void SetCurrentDirectory( string value ) {
		Environment.CurrentDirectory = value;
		Debug.Log( "SetCurrentDirectory > {0}", value );
	}


	/// <summary>
	/// このプロセスのみ有効な環境変数を設定します
	/// </summary>
	/// <param name="path"></param>
	public static void SetEnvironmentPath( string path ) {
		//rt.setEnv( "PATH", path, EnvironmentVariableTarget.Process );
		Environment.SetEnvironmentVariable( "PATH", path, EnvironmentVariableTarget.Process );
		Debug.Log( "SetEnvironmentPath: {0}".format( path ) );
	}
}


public static class Debug {
	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void AllocConsole() {
		Win32.AllocConsole();
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void Log( int m ) {
		Console.WriteLine( m );
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void Error( Exception e ) {
		Console.WriteLine( e.ToString() );
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void Log( string m, params object[] args ) {
#if TRACE
		if( string.IsNullOrEmpty( m ) ) return;
		Console.WriteLine( string.Format( m, args ) );
#endif
	}
}



