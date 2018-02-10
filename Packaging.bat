@ECHO off
SET PATH=%PATH%;"C:\Users\Doraku\.nuget\packages\xunit.runner.console\2.2.0\tools\";"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin"

DEL *.html
DEL *.nupkg

msbuild /t:Clean /p:Configuration=Release .\source\DefaultEcs.sln
msbuild /t:Build /p:Configuration=Release .\source\DefaultEcs.sln

xunit.console.exe .\source\DefaultEcs.Test\bin\Release\net45\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_net45.html
IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_net45.html
xunit.console.exe .\source\DefaultEcs.Test\bin\Release\net46\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_net46.html
IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_net46.html
xunit.console.exe .\source\DefaultEcs.Test\bin\Release\net47\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_net47.html
IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_net47.html

--xunit.console.exe .\source\DefaultEcs.Test\bin\Release\netcoreapp1.0\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_netcoreapp1.0.html
--IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_netcoreapp1.0.html
--xunit.console.exe .\source\DefaultEcs.Test\bin\Release\netcoreapp2.0\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_netcoreapp2.0.html
--IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_netcoreapp2.0.html

--xunit.console.exe .\source\DefaultEcs.Test\bin\Release\netstandard1.3\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_netstandard1.3.html
--IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_netstandard1.3.html
--xunit.console.exe .\source\DefaultEcs.Test\bin\Release\netstandard2.0\DefaultEcs.Test.dll -notrait "Category=Performance" -html DefaultEcs_netstandard2.0.html
--IF %ERRORLEVEL% EQU 0 DEL DefaultEcs_netstandard2.0.html

SET Count=0
FOR %%A IN (DefaultEcs_*.html) DO SET /A Count += 1

IF %Count% GTR 0 GOTO :end

msbuild /t:Pack /p:Configuration=Release .\source\DefaultEcs\DefaultEcs.csproj
IF %ERRORLEVEL% EQU 0 MOVE .\source\DefaultEcs\bin\Release\*.nupkg .\

:end