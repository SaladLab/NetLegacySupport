@echo off

pushd %~dp0

tools\nuget\NuGet.exe update -self
tools\nuget\NuGet.exe install FAKE -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages -ExcludeVersion -Version 4.10.3
tools\nuget\NuGet.exe install nunit.runners -ConfigFile tools\nuget\Nuget.Config -OutputDirectory packages\FAKE -ExcludeVersion -Version 3.0.1

set encoding=utf-8
packages\FAKE\tools\FAKE.exe build.fsx %*

popd
