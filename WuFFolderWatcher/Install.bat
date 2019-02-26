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
