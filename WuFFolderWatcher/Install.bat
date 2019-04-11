@ECHO OFF

echo Installing WuFFolderWatcher...
echo ---------------------------------------------------
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil .\WuFFolderWatcher.exe
echo ---------------------------------------------------
echo WuFFolderWatcher installation complete.

echo Starting WuFFolderWatcher...
echo ---------------------------------------------------
sc start WuFFolderWatcher
echo ---------------------------------------------------
echo WuFFolderWatcher successfully started.

echo Starting WuFFolderWatcher tray app...
echo ---------------------------------------------------
start .\WuFFolderWatcherTrayApp.exe
echo ---------------------------------------------------
echo WuFFolderWatcher tray app successfully started.



echo Add a link to the  WuFFolderWatcher system tray app to the StartUp folder...
echo ---------------------------------------------------
if exist .\StartFolderWactherSysTrayApp.bat del .\StartFolderWactherSysTrayApp.bat
echo pushd "%cd%" >> StartFolderWactherSysTrayApp.bat
echo start "" "%cd%\WuFFolderWatcherTrayApp.exe" >> StartFolderWactherSysTrayApp.bat
echo exit >>  StartFolderWactherSysTrayApp.bat
if exist "%programdata%\Microsoft\Windows\Start Menu\Programs\StartUp\StartFolderWactherSysTrayApp.bat"  del "%programdata%\Microsoft\Windows\Start Menu\Programs\StartUp\StartFolderWactherSysTrayApp.bat"
if exist .\StartFolderWactherSysTrayApp.bat xcopy .\StartFolderWactherSysTrayApp.bat "%programdata%\Microsoft\Windows\Start Menu\Programs\StartUp\"
echo ---------------------------------------------------
echo link to the  WuFFolderWatcher system tray app tray app successfully started.