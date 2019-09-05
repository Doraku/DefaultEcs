@ECHO off

DEL /q package
dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release
dotnet clean source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release

dotnet test source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release -r ..\..\package\ -l trx

IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release
dotnet clean source\DefaultEcs\DefaultEcs.Package.csproj -c Release

dotnet pack source\DefaultEcs\DefaultEcs.Package.csproj -c Release -o ..\..\package\

DEL /q docs\coverage

rem dotnet tool install -g coverlet.console
coverlet source\DefaultEcs.Test\bin\Release\netcoreapp2.2\DefaultEcs.Test.dll -t "dotnet" -a "vstest source\DefaultEcs.Test\bin\Release\netcoreapp2.2\DefaultEcs.Test.dll" -o package\coverage.xml -f opencover

:end