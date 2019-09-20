@ECHO off

DEL /q package
dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release
dotnet clean source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release

dotnet test source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release -r ..\..\package\ -l trx

IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release
dotnet clean source\DefaultEcs\DefaultEcs.Package.csproj -c Release

dotnet pack source\DefaultEcs\DefaultEcs.Package.csproj -c Release -o ..\..\package\

:end