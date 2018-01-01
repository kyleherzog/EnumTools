# Enum Tools
[![Build status](https://ci.appveyor.com/api/projects/status/dcquffxl5ua3065i?svg=true)](https://ci.appveyor.com/project/kyleherzog/enumtools)

This library is available from [NuGet.org](https://www.nuget.org/packages/EnumTools/)
or download from the [CI build feed](https://ci.appveyor.com/nuget/enumtools).

--------------------------

A .NET Standard class library that provides tools and extensions to add functionality to enums.

See the [changelog](CHANGELOG.md) for changes and roadmap.

## Features

- Access to DisplayAttribute properties
- Find minimum/maximum values
- Querying Enums for DisplayAttribute GroupName details
- Parsing strings to enum value by ShortName

### DisplayAttribute Properties Access
A number of extension methods are provided that allow access to the DisplayAttribute properties for enum values including the following:
- ToName
- ToShortName
- ToDescription
- GroupName
- Prompt

Those extension methods prefixed with "To" will default to the ToString value if the DisplayAttribute properties are not set.

### Minimum/Maximum Values
Access to the minimum and maximum values of a given enum can be found using the `Enum<T>` class.

### Group Name Methods
`Enum<T>` also provides the InfoByGroup and GroupNames methods to get aggregate details about DisplayAttribute Group properties.

### Parsing Short Names
String values that match an enum value's DisplayAttribute ShortName property can be parsed into their matching enum value using the TryParseShortName and ParseShortName methods of `Enum<T>`.


## License
[Apache 2.0](LICENSE)