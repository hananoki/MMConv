"C:\Program Files (x86)\MSBuild\12.0\bin\MSBuild.exe" /p:Configuration=Release Project/MMConv.csproj

copy Project\bin\Release\MMConv.exe .\Build
copy Project\bin\Release\*.dll .\Build
copy Project\bin\Release\x64 .\Build
copy Project\bin\Release\x86 .\Build

pause
