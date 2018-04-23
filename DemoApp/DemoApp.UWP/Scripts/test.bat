@echo off

set projectdir=%USERPROFILE%\Build_Project
set desktopdir=%USERPROFILE%\Desktop

echo Script running!
echo Creating directory on desktop...

xcopy %projectdir% %desktopdir% /s /e /q

echo Opening Visual Studio...

start "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" "%desktopdir%\App55\App55.sln"