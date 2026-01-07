# HowlDev.Core

## HowlDev.Core.TextDTO

This is a command-line NuGet package that you can install with:

```bash
dotnet tool install --global --add-source ./nupkgs YourUniquePackageId
```

You can export a given file as a set of DTO's with any of the 4 following tags:

- cs
  - Exports a C# file with an optional namespace in the format of a class with public get and set properties
- js
  - Creates an interface with the provided properties
- ts
  - Creates a Type that has the provided properties
- ts-z
  - Creates a Zod object with the provided properties (you must install Zod yourself)

Here's the structure:

```json
{
  "name": "IdAndTitleDTO", // Required
  "namespace": "ProjectTracker.Classes", // This is an optional thing for C# classes only (only file-scoped is available)
  "ignoreWarnings": true, // Also optional; uses the language-specific disable of warnings
  "properties": [
    {
      "name": "Id", // These two properties are required
      "type": "int"
    },
    {
      "name": "Sample",
      "type": "string",
      "default": "Unknown" // You can assign a default value here (optional param)
    },
    {
      "name": "ProjectTitle",
      "type": "string",
      "nullable": true // You can make a property optional (optional param)
    }
  ]
}
```

The current list of types:

- string
  - String for JS, TS, Zod, and C#
- int
  - int for C#, number for JS, TS, and Zod
- double
  - double for C#, number for JS, TS, and Zod
- bool
  - bool for C#, boolean for JS, TS, and Zod
