using System;
using System.Text;
using System.Runtime.InteropServices;

public static class Win32 {

	#region dwmapi.dll

	[StructLayout( LayoutKind.Sequential )]
	public struct MARGINS {
		public int leftWidth;
		public int rightWidth;
		public int topHeight;
		public int bottomHeight;
	}

	[DllImport( "dwmapi.dll", PreserveSig = true )]
	public static extern int DwmExtendFrameIntoClientArea( IntPtr hwnd, ref MARGINS margins );

	[DllImport( "dwmapi.dll", PreserveSig = false )]
	public static extern bool DwmIsCompositionEnabled();

	[DllImport( "dwmapi.dll" )]
	public static extern int DwmIsCompositionEnabled( out bool enabled );

	#endregion



	#region winmm.dll

	//サウンドを再生するWin32 APIの宣言
	[Flags]
	public enum PlaySoundFlags : int {
		SND_SYNC = 0x0000,
		SND_ASYNC = 0x0001,
		SND_NODEFAULT = 0x0002,
		SND_MEMORY = 0x0004,
		SND_LOOP = 0x0008,
		SND_NOSTOP = 0x0010,
		SND_NOWAIT = 0x00002000,
		SND_ALIAS = 0x00010000,
		SND_ALIAS_ID = 0x00110000,
		SND_FILENAME = 0x00020000,
		SND_RESOURCE = 0x00040004,
		SND_PURGE = 0x0040,
		SND_APPLICATION = 0x0080
	}

	[DllImport( "winmm.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto )]
	public static extern bool PlaySound( string pszSound, IntPtr hmod, PlaySoundFlags fdwSound );

	[DllImport( "winmm.dll" )]
	public static extern bool PlaySound( byte[] pszSound, IntPtr hmod, PlaySoundFlags fdwSound );

	#endregion

	[StructLayout( LayoutKind.Sequential )]
	public struct SystemInfo {
		public uint dwOemId;
		public uint dwPageSize;
		public IntPtr lpMinimumApplicationAddress;
		public IntPtr lpMaximumApplicationAddress;
		public uint dwActiveProcessorMask;
		public uint dwNumberOfProcessors;
		public uint dwProcessorType;
		public uint dwAllocationGranularity;
		public uint dwProcessorLevel;
		public uint dwProcessorRevision;
	}

	[DllImport( "kernel32" )]
	public static extern bool AllocConsole();

	[DllImport( "kernel32.dll" )]
	public static extern uint FormatMessage(
		uint dwFlags, IntPtr lpSource,
		uint dwMessageId, uint dwLanguageId,
		StringBuilder lpBuffer, int nSize,
		IntPtr Arguments );

	[DllImport( "kernel32.dll", ExactSpelling = true )]
	public static extern void GetSystemInfo( out SystemInfo ptmpsi );



	[DllImport( "kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto )]
	public static extern uint GetShortPathName( [MarshalAs( UnmanagedType.LPTStr )] string lpszLongPath, [MarshalAs( UnmanagedType.LPTStr )] StringBuilder lpszShortPath, uint cchBuffer );


	[DllImport( "User32.dll" )]
	public static extern bool DestroyIcon( IntPtr hIcon );

	// ExtractIconEx 複数の引数指定方法により、オーバーロード定義する。
	[DllImport( "Shell32.dll", CharSet = CharSet.Unicode )]
	public static extern uint ExtractIconEx( string lpszFile, int nIconIndex, IntPtr[] phiconLarge, IntPtr[] phiconSmall, uint nIcons );
	[DllImport( "Shell32.dll", CharSet = CharSet.Unicode )]
	public static extern uint ExtractIconEx( string lpszFile, int nIconIndex, IntPtr[] phiconLarge, IntPtr phiconSmall, uint nIcons );
	[DllImport( "Shell32.dll", CharSet = CharSet.Unicode )]
	public static extern uint ExtractIconEx( string lpszFile, int nIconIndex, IntPtr phiconLarge, IntPtr[] phiconSmall, uint nIcons );
	[DllImport( "Shell32.dll", CharSet = CharSet.Unicode )]
	public static extern uint ExtractIconEx( string lpszFile, int nIconIndex, out IntPtr phiconLarge, out IntPtr phiconSmall, uint nIcons );
	// SHGetFileInfo関数
	[DllImport( "shell32.dll" )]
	public static extern IntPtr SHGetFileInfo( string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags );
	// SHGetFileInfo関数で使用するフラグ
	public const uint SHGFI_ICON = 0x100; // アイコン・リソースの取得
	public const uint SHGFI_LARGEICON = 0x0; // 大きいアイコン
	public const uint SHGFI_SMALLICON = 0x1; // 小さいアイコン
																					 // SHGetFileInfo関数で使用する構造体
	public struct SHFILEINFO {
		public IntPtr hIcon;
		public IntPtr iIcon;
		public uint dwAttributes;
		[MarshalAs( UnmanagedType.ByValTStr, SizeConst = 260 )]
		public string szDisplayName;
		[MarshalAs( UnmanagedType.ByValTStr, SizeConst = 80 )]
		public string szTypeName;
	};
}


