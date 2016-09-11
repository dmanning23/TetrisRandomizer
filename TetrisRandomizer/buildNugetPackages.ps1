rm *.nupkg
nuget pack .\TetrisRandomizer.nuspec -IncludeReferencedProjects -Prop Configuration=Release
nuget push *.nupkg