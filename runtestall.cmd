@echo off
setlocal ENABLEDELAYEDEXPANSION
pushd "%~dp0"

for /F %%I in ('dir /b *.Test.cs 2^>nul') do (
    set fileName=%%~nI
    echo Testing !fileName:~0,-5!
    call runtest.cmd %%I
    if !errorlevel! NEQ 0 exit /b
)