# Implementing the Options Pattern
This is a guide to show the power of using the Options Pattern on .NET Core Applications. This guide will walk you through the files used and changes made.

### Template files not touched
1. MainLayout.cs
2. Error.razor
3. _Imports.razor
4. Routes.razor

### App.Razor
The only thing added to this file was Bootstrap for a little UI.

## appsettings.json and transform files
This is essentially the json models of the data you are going to want to ingest. 
* appsettings.json is used by default
* appsettings.`{environmentname}`.json contains the environment specific data
* don't put the same data in appsettings.prod.json as appsettings.qa.json, if the information is the same across environments, put it in the appsettings.json file
* there are edge cases

### Settings classes in Settings folder
These are the C# models of the json objects.

Not much more to be said. 

### EnvironmentSettings.cs in the Middleware folder
This is completely unnecessary. This can be done within the Program.cs file, but this gives an example of separating the work for more scalable code.

_If this appsettings.json file ends up having more than a couple objects, this could add a lot of bloat to the Program.cs file._

Note: whether you do this here or in the Program.cs file, you need to call `builder.Services.AddOptions();` after wiring them up.

## Program.cs
This file requires that you load the appsettings file into the builder.Configuration.

Then you can either run your middleware, or you configure the settings inline.

Whether it's inline or in middleware again, you need to make your services injectable. Controllers get this by simply wiring them up.

## Services
There is a method or two in the services, but really the important part is where you inject the `IOptions<T>` into your service.
