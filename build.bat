"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" /p:Configuration=Release Project/MMConv.csproj

copy Project\bin\Release\MMConv.exe .\Build
copy Project\bin\Release\*.dll .\Build
copy Project\bin\Release\x64 .\Build
copy Project\bin\Release\x86 .\Build

pause
