@echo off

set project=Testing
set projectfile=project\%project%.zip
set desktop=%USERPROFILE%\Desktop
set zip=project\7za.exe

echo Extracting project to desktop...

%zip% x -o%desktop% %projectfile%  

echo Opening Visual Studio...

start "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.exe" "%desktop%\%project%\%project%.sln"