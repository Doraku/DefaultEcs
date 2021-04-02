@ECHO off

DEL /q build
dotnet clean source\DefaultEcs\DefaultEcs.csproj -c Release
dotnet clean source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release

dotnet test source\DefaultEcs.Test\DefaultEcs.Test.csproj -c Release -r build -l trx

IF %ERRORLEVEL% GTR 0 GOTO :end

dotnet pack source\DefaultEcs\DefaultEcs.csproj -c Release -o build /p:LOCAL_VERSION=true

:end