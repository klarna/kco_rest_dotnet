#tool "nuget:?package=NUnit.ConsoleRunner"
#tool "nuget:?package=OpenCover"
#tool "nuget:?package=NUnit.Extension.NUnitV2ResultWriter"

var target = Argument("target", "Default");

var solutionPath = "./Klarna.Rest.Core.sln";

var testResultsFileName = "nunit-testresults.xml";
var openCoverFileName = "opencover-results.xml";

var configuration = Argument("Configuration", "Release");

var runAllTests = Argument("RunAllTests", false);

Task("Clean")
    .Does(() => {
        if(FileExists(testResultsFileName))
        {
            DeleteFile(testResultsFileName);
        }

        if(FileExists(openCoverFileName))
        {
            DeleteFile(openCoverFileName);
        }

        DeleteFiles("./*.nupkg");
    });

Task("Restore")
    .Does(() => {
        Information("Restoring NuGet Packages for dotnet core...");
        DotNetCoreRestore(solutionPath);

        Information("Restoring NuGet Packages for dotnet framework...");
        NuGetRestore("./Klarna.Rest.Core.Tests/Klarna.Rest.Core.Tests.csproj", new NuGetRestoreSettings {
            PackagesDirectory = "./packages"
            });
    });

DotNetCoreMSBuildSettings msBuildSettings = null;
Task("Version")
    .Does(() => {
        msBuildSettings = new DotNetCoreMSBuildSettings()
                            .WithProperty("Version", $"1.0.0.{Bamboo.Environment.Build.Number}")
                            .WithProperty("FileVersion", $"1.0.0.{Bamboo.Environment.Build.Number}")
                            .WithProperty("AssemblyVersion", $"1.0.0.{Bamboo.Environment.Build.Number}");
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .IsDependentOn("Version")
    .Does(() => {
        var settings = new DotNetCoreBuildSettings {
            Configuration = configuration,
            MSBuildSettings = msBuildSettings
        };

        DotNetCoreBuild("./Klarna.Rest.Core/Klarna.Rest.Core.csproj", settings);
        DotNetCoreBuild("./Klarna.Rest.Core.Tests/Klarna.Rest.Core.Tests.csproj", settings);
       
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {

		var projects = GetFiles("./Klarna.Rest.Core.Tests/Klarna.Rest.Core.Tests.csproj");
		foreach(var project in projects)
		{
			DotNetCoreTool(
				projectPath: project.FullPath,
				command: "xunit",
				arguments: $"-configuration {configuration} -diagnostics -stoponfail"
			);
		}

    })
    .OnError(exception => {
        // When tests fail task will return 1 and this will stop the whole build in bamboo.
        if(!Bamboo.IsRunningOnBamboo)
        {
            throw exception;
        }
    });

Task("Package")
    .IsDependentOn("Test")
    .Does(() => {
        var dotNetCorePackSettings = new DotNetCorePackSettings {
                IncludeSymbols = true,
                NoBuild = true,
                Configuration = configuration,
                MSBuildSettings = msBuildSettings,
                OutputDirectory = "./"
            };
        
        DotNetCorePack("./Klarna.Rest.Core/Klarna.Rest.Core.csproj", dotNetCorePackSettings);
    });

Task("Default")
    .IsDependentOn("Package");

RunTarget(target);