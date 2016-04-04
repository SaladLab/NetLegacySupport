#I @"packages/FAKE/tools"
#I @"packages/FAKE.BuildLib/lib/net451"
#r "FakeLib.dll"
#r "BuildLib.dll"

open Fake
open BuildLib

let solution = 
    initSolution
        "./NetLegacySupport.sln" "Release" 
        [ { emptyProject with Name="NetLegacySupport.Action";
                              Folder="./core/Action";
                              Dependencies=[] };
          { emptyProject with Name="NetLegacySupport.ConcurrentDictionary";
                              Folder="./core/ConcurrentDictionary";
                              Dependencies=[("NetLegacySupport.Action", "")] };
          { emptyProject with Name="NetLegacySupport.Tuple";
                              Folder="./core/Tuple";
                              Dependencies=[] } ]

Target "Clean" <| fun _ -> cleanBin

Target "AssemblyInfo" <| fun _ -> generateAssemblyInfo solution

Target "Restore" <| fun _ -> restoreNugetPackages solution

Target "Build" <| fun _ -> buildSolution solution

Target "Test" <| fun _ -> testSolution solution

Target "Cover" <| fun _ -> coverSolution solution

Target "Nuget" <| fun _ ->
    createNugetPackages solution
    publishNugetPackages solution

Target "CreateNuget" <| fun _ ->
    createNugetPackages solution

Target "PublishNuget" <| fun _ ->
    publishNugetPackages solution

Target "CI" <| fun _ -> ()

Target "Help" <| fun _ -> 
    showUsage solution (fun _ -> None)

"Clean"
  ==> "AssemblyInfo"
  ==> "Restore"
  ==> "Build"
  ==> "Test"

"Build" ==> "Nuget"
"Build" ==> "CreateNuget"
"Build" ==> "Cover"

"Test" ==> "CI"
"Cover" ==> "CI"
"Nuget" ==> "CI"

RunTargetOrDefault "Help"
