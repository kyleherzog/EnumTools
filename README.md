# Enum Tools

--------------------------

Portable class library that provides tools and extensions to add functionality to enums.

See the [changelog](CHANGELOG.md) for changes and roadmap.

## Features

- Access to DisplayAttribute properties
- Find minimum/maximum values

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

`Enum<T>` also provides the InfoByGroup and GroupNames methods to get aggregate details about DisplayAttribute Group properties.

## License
[Apache 2.0](LICENSE)