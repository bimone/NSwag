## NSwag: The Swagger API toolchain for .NET and TypeScript

[![Gitter](https://img.shields.io/badge/gitter-join%20chat-1dce73.svg)](https://gitter.im/NSwag/NSwag)
[![NuGet Version](https://badge.fury.io/nu/nswag.core.svg)](https://www.nuget.org/packages?q=NSwag)
[![Build status](https://ci.appveyor.com/api/projects/status/aajfgxqf5dic7tkk?svg=true)](https://ci.appveyor.com/project/rsuter/nswag)
CI: [![Build status](https://ci.appveyor.com/api/projects/status/sfoha01b3i841iky?svg=true)](https://ci.appveyor.com/project/rsuter/nswag-25x6o)

NSwag is a Swagger 2.0 API toolchain for .NET, TypeScript and other platforms, written in C#. The [Swagger specification](http://swagger.io) uses JSON and JSON Schema to describe a RESTful web API. The project provides tools to generate Swagger specifications from existing Web API controllers and client code from these Swagger specifications and integrate this generation into existing processes. 

The NSwag project heavily uses [NJsonSchema for .NET](http://njsonschema.org) for JSON Schema handling and C#/TypeScript class/interface generation. 

**Ways to use the toolchain:** 

- Simple to use Windows GUI, [NSwagStudio](https://github.com/NSwag/NSwag/wiki/NSwagStudio)
- In your C# code, via [NuGet](https://www.nuget.org/packages?q=NSwag)
- Via [command line](https://github.com/NSwag/NSwag/wiki/CommandLine) (Windows, Mac and Linux support through [Mono](http://www.mono-project.com/))
- Generate code with [T4 templates](https://github.com/NSwag/NSwag/wiki/T4) in Visual Studio
- In your [MSBuild targets](https://github.com/NSwag/NSwag/wiki/MSBuild)

**Swagger Generators:**

- ASP.NET Web API assembly to Swagger (supports .NET Core)
    - [WebApiToSwaggerGenerator](https://github.com/NSwag/NSwag/wiki/WebApiToSwaggerGenerator)
    - [WebApiAssemblyToSwaggerGenerator](https://github.com/NSwag/NSwag/wiki/WebApiAssemblyToSwaggerGenerator)
- Types from .NET assemblies
    - [AssemblyTypeToSwaggerGenerator](https://github.com/NSwag/NSwag/wiki/AssemblyTypeToSwaggerGenerator)

**Code Generators:** 

- **TypeScript Client**
	- [SwaggerToTypeScriptClientGenerator](https://github.com/NSwag/NSwag/wiki/SwaggerToTypeScriptClientGenerator)
	- Available templates/supported libraries: 
		- JQuery with Callbacks, `JQueryCallbacks`
		- JQuery with promises `JQueryPromises`
		- AngularJS using $http, `AngularJS`
		- Angular 2 using the http service, `Angular2`
- **CSharp Client**
	- [SwaggerToCSharpClientGenerator](https://github.com/NSwag/NSwag/wiki/SwaggerToCSharpClientGenerator)
	- With [INotifyPropertyChanged](https://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged(v=vs.110).aspx) supporting DTOs
- **CSharp WebAPI Controllers** (contract first/schema first development)
	- [SwaggerToCSharpControllerGenerator](https://github.com/NSwag/NSwag/wiki/SwaggerToCSharpControllerGenerator)
	    - Generates Web API Controllers based on a Swagger specification

**Downloads**

- [Download latest **NSwagStudio MSI installer**](http://rsuter.com/Projects/NSwagStudio/installer.php) (Windows Desktop application)
- [Download latest **NSwag command line tools** and NSwagStudio as ZIP archive](http://rsuter.com/Projects/NSwagStudio/archive.php)
- [Download latest **Build Artifacts** from AppVeyor](https://ci.appveyor.com/project/rsuter/nswag/build/artifacts) (command line tools and NSwagStudio binaries)

**NuGet Packages**

- [NSwag.Core](https://www.nuget.org/packages/NSwag.Core/) (PCL 259): The Swagger reader and writer classes ([Source Code](https://github.com/NSwag/NSwag/tree/master/src/NSwag.Core))
- [NSwag.Annotations](https://www.nuget.org/packages/NSwag.Annotations/) (PCL 259): Attributes to decorate Web API controllers to control the Swagger generation ([Source Code](https://github.com/NSwag/NSwag/tree/master/src/NSwag.Annotations))
- [NSwag.CodeGeneration](https://www.nuget.org/packages/NSwag.CodeGeneration/) (PCL 259): Classes to generate C# and TypeScript clients ([Source Code](https://github.com/NSwag/NSwag/tree/master/src/NSwag.CodeGeneration))
- [NSwag.AssemblyLoader](https://www.nuget.org/packages/NSwag.AssemblyLoader/) (.NET 4.5+): Classes to load assemblies in an isolated AppDomain and generate Swagger specs from Web API controllers
- [NSwag.MSBuild](https://www.nuget.org/packages/NSwag.MSBuild/) (MSBuild .targets): Adds a .targets file to your Visual Studio project, so that you can run the NSwag command line tool in an MSBuild target

### Usage in C&#35;

The following code shows how to read a Swagger specification and generate C# client classes to call the described web services: 
	
```cs
var swaggerSettings = new WebApiToSwaggerGeneratorSettings();
var swaggerGenerator = new WebApiToSwaggerGenerator(swaggerSettings);

var service = swaggerGenerator.GenerateForController<PersonsController>();

var clientSettings = new SwaggerToCSharpClientGeneratorSettings 
{
    ClassName = "MyClass",
    Namespace = "MyNamespace"
};
var clientGenerator = new SwaggerToCSharpClientGenerator(service, clientSettings);

var code = clientGenerator.GenerateFile();
```

Check out the [project Wiki](https://github.com/NSwag/NSwag/wiki) for more information.

### NSwagStudio

The generators can be used in a comfortable and simple Windows GUI called NSwagStudio: 

[![](https://raw.githubusercontent.com/NSwag/NSwag/master/assets/screenshots/03_WebAPI_CSharp.png)](https://raw.githubusercontent.com/NSwag/NSwag/master/assets/screenshots/03_WebAPI_CSharp.png)
