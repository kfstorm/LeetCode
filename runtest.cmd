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

for /F %%I in ('dir /b /s shared\*.cs 2^>nul') do (
    set csFiles=!csFiles! %%I
)

call :CS %csFiles%
if !errorlevel! NEQ 0 exit /b

echo End.
goto :EOF

:CS
echo Restoring NuGet packages ...
nuget restore -PackagesDirectory packages -Verbosity quiet
echo Compiling %* ...
set _csc="packages\Microsoft.Net.Compilers.1.1.1\tools\csc.exe"
set _nunit=packages\NUnit.2.6.4\lib\nunit.framework.dll
set _json=packages\Newtonsoft.Json.7.0.1\lib\net45\Newtonsoft.Json.dll
set _numerics=System.Numerics.dll
%_csc% /target:library /out:%bin%\%problem%.dll /r:%_nunit% /r:%_json% /r:%_numerics% %* /nologo /fullpaths
if !errorlevel! NEQ 0 exit /b
xcopy %_nunit% %bin% 1>nul
xcopy %_json% %bin% 1>nul
if "%hasTest%"=="true" (
    echo Testing ...
    packages\NUnit.Runners.2.6.4\tools\nunit-console.exe %bin%\%problem%.dll /noresult /nologo /framework:4.5
) else (
    echo Warning: No tests^^!
)
exit /b
