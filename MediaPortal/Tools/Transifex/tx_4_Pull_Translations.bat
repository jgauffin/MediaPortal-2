
"%WINDIR%\Microsoft.NET\Framework\v4.0.30319\MSBUILD.exe" tx.targets
tx pull -a -f > pull.log
