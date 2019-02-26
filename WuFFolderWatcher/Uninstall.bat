@ECHO OFF

echo Stopping WuFFolderWatcher tray app...
echo ---------------------------------------------------
taskkill /F /IM WuFFolderWatcherTrayApp.exe
echo ---------------------------------------------------
echo WuFFolderWatcher tray app successfully stopped.

echo Uninstalling WuFFolderWatcher...
echo ---------------------------------------------------
C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\InstallUtil /u .\WuFFolderWatcher.exe
echo ---------------------------------------------------
echo WuFFolderWatcher uninstall complete.

