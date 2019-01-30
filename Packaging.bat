@ECHO off

DEL /q package
dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release

cd source\DefaultEcs.Test

dotnet xunit -configuration Release -xml ..\..\package\test.xml -fxversion 2.1.0

cd ..\..

IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet pack source\DefaultEcs\DefaultEcs.csproj -c Release -o ..\..\package\

:end