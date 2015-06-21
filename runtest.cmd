@echo off
setlocal ENABLEDELAYEDEXPANSION

pushd "%~dp0"
path %~dp0tools;%path%

set problem=%~n1
if [%problem:~-5%] == [.Test] set problem=%problem:~0,-5%

set bin=bin\%problem%
if exist  %bin% rmdir  %bin% /s /q
mkdir  %bin%

for /F %%I in ('dir /b %problem%*.cs 2^>nul') do (
    set csFiles=!csFiles! %%I
    set fileName=%%~nI
    if "!fileName:~-5!"==".Test" set hasTest=true
)
if "%csFiles%" == "" (
    echo No source files detected for problem '%problem%'^^!
    exit /b 1
)

call :CS %csFiles%
if !errorlevel! NEQ 0 exit /b

echo End.
goto :EOF

:CS
set _csc="C:\WINDOWS\Microsoft.NET\Framework\v4.0.30319\csc.exe"
echo Restoring NuGet packages ...
nuget restore -PackagesDirectory packages -Verbosity quiet
echo Compiling %* ...
%_csc% /target:library /out:%bin%\%problem%.dll /r:packages\NUnit.2.6.4\lib\nunit.framework.dll %* /nologo /fullpaths
if !errorlevel! NEQ 0 exit /b
xcopy packages\NUnit.2.6.4\lib\nunit.framework.dll %bin% 1>nul
if "%hasTest%"=="true" (
    echo Testing ...
    packages\NUnit.Runners.2.6.4\tools\nunit-console.exe %bin%\%problem%.dll /noresult /nologo /framework:4.5
) else (
    echo Warning: No tests^^!
)
exit /b
