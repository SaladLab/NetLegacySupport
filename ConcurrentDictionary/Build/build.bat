@echo Off

REM Build

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\ConcurrentDictionary.Net20.sln /p:Configuration="Release" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\ConcurrentDictionary.Net35.sln /p:Configuration="Release" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ..\ConcurrentDictionary.Net40.sln /p:Configuration="Release" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false

REM Package

rd /s/q bin
mkdir bin
mkdir bin\lib
mkdir bin\lib\net20
mkdir bin\lib\net35
mkdir bin\lib\net40

copy ..\output\NetLegacySupport.ConcurrentDictionary\bin\Net20\Release\NetLegacySupport.ConcurrentDictionary.* bin\lib\net20
copy ..\output\NetLegacySupport.ConcurrentDictionary\bin\Net35\Release\NetLegacySupport.ConcurrentDictionary.* bin\lib\net35
copy ..\output\NetLegacySupport.ConcurrentDictionary\bin\Net40\Release\NetLegacySupport.ConcurrentDictionary.* bin\lib\net40

call nuget.exe pack NetLegacySupport.ConcurrentDictionary.nuspec -BasePath bin
