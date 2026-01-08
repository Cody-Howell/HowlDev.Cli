# HowlDev.Core

## HowlDev.Core.TextDTO

This is a command-line NuGet package that you can install with:

```bash
dotnet tool install --global HowlDev.Cli.TextDTO
```

You can use it by: 

```bash
textdto ./schemas cs ./api/dtos ts-z ./client/dtos
```

You can export a given file as a set of DTO's with any of the 3 following tags:

- cs
  - Exports a C# file with an optional namespace in the format of a class with public get and set properties
- ts
  - Creates a Type that has the provided properties
    - Ignores the Default property (impossible with type definitions)
    - Nullable means undefined, the default null state for things in JavaScript
- ts-z
  - Creates a Zod object with the provided properties (you must install Zod yourself)
  - Names are appended with Schema for Zod parsing and Type for the type inference. Both are exported.

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

The current list of types are C# primitives. They are all converted to a TS type when being added to a TS file.

- string
  - string for JS, TS, Zod, and C#
- int, uint, byte, long, double, etc.
  - ___ for C#, number for JS, TS, and Zod
- bool
  - bool for C#, boolean for JS, TS, and Zod
