@echo off

set project=ConferenceVision
set projectdir=%USERPROFILE%\Build2018
set desktop=%USERPROFILE%\Desktop

echo Copying project to desktop...

xcopy %projectdir% %desktop% /s /e  

echo Opening Visual Studio...

start "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" "%desktop%\%project%\%project%.sln"