<h1 align="center">
	<br>
	<img width="204" height="50" src="fabulous.png" alt="Fabulous">
	<br>
	<br>
</h1>

> Easy terminal styling for .NET.

[![License (MIT)](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT) [![Build status](https://ci.appveyor.com/api/projects/status/h3dncugcr67opiy0?svg=true)](https://ci.appveyor.com/project/sjp/fabulous)

This project is largely inspired by [Chalk](https://github.com/chalk/chalk) and the API is very similar. Currently the only features missing are support for colorspaces beyond RGB, this may change in future.

## Highlights

* Chainable and fluent API.
* Support for regular styling by `System.Console`, in addition to ANSI 16 colors, ANSI 256 colors and ANSI true colors.
* Auto-detection of color support.
* Minimal and focused.

## Installation

*TODO*. Something like the following though (when the package is available on Nuget).

```powershell
Install-Package SJP.Fabulous
```

or

```console
dotnet add package SJP.Fabulous
```

## Usage

```csharp
Fabulous
    .Green
    .Text("Hello, world!")
    .WriteLine();
```

Fabulous has two easy ways to create styled text. The previous method shows one way, the other is to initialize from a `string` object.

```csharp
FabulousText message = "Hello, world!";
message.WriteLine();
```

You can also combine text with different styling together (including regular `string` objects) and write in one go.

```csharp
var hello = Fabulous.Green.Text("Hello");
var comma = ", ";
var world = Fabulous.Yellow.Text("world!");

var message = hello + comma + world;
message.WriteLine();
```

You can also use `Fabulous.WriteLine()` for writing instead of the fluent approach.

```csharp
var message = Fabulous.Yellow.Text("Hello, world!");
Fabulous.WriteLine(message);
```

You can also write with format strings for compatibility with the `Console.Write()` and `Console.WriteLine()` methods.

```csharp
var helloMessage = Fabulous.BgWhite.Black.Text("Hello, {0}!");
var name = "Simon";
helloMessage.WriteLine(name); // writes "Hello, Simon!"
```

## Styles

### Modifiers

* `Reset`
* `Bold`
* `Dim`
* `Italic`
* `Underline`
* `Hidden`
* `Strikethrough`

### Colors

* `Black`
* `Red`
* `Green`
* `Yellow`
* `Blue`
* `Magenta`
* `Cyan`
* `White`
* `Grey` or `Gray`
* `RedBright`
* `GreenBright`
* `YellowBright`
* `BlueBright`
* `MagentaBright`
* `CyanBright`
* `WhiteBright`

### Background Colors

* `BgBlack`
* `BgRed`
* `BgGreen`
* `BgYellow`
* `BgBlue`
* `BgMagenta`
* `BgCyan`
* `BgWhite`
* `BgGrey` or `BgGray`
* `BgRedBright`
* `BgGreenBright`
* `BgYellowBright`
* `BgBlueBright`
* `BgMagentaBright`
* `BgCyanBright`
* `BgWhiteBright`

## API

### `FabulousConsole.ColorLevel`

Example: `FabulousConsole.ColorLevel = ConsoleColorMode.Basic;`

Setting the `ColorLevel` property determines the level of coloring and styling that the console will use. By default this is set to `ConsoleColorMode.Standard`, which means that the styling is limited to the feature set that `System.Console` provides.

To use the maximum supported color level, you can use the following code:

```csharp
FabulousConsole.ColorLevel = FabulousConsole.GetMaximumSupportedColorMode();
```

### `WindowsConsole.IsWindowsPlatform`

If you are unsure of which platform your code is currently running in, you can check this property. This is important because `cmd.exe` is fairly limited in the amount of styling it can provide, at least on systems pre-dating some versions of Windows 10. 

### `WindowsConsole.MaximumSupportedColorLevel`

Determines the greatest level of support that the current Windows console can provide. This may turn on ANSI processing for your console instance if it is not already available. This property is available for use, but it is usually not necessary. For most situations it is sufficient to use `FabulousConsole.GetMaximumSupportedColorMode()` instead.

## 256 and Truecolor Color Support

Fabulous supports 256 colors and Truecolor (16 million colors) on terminal emulators which support it.

For terminals which do not have support for the chosen color styling, the colors are downsampled to the closest matching color. For 256 color terminals this will likely not matter much, but for 16 colors the effect will be noticeable.

There are a few ways to declare foreground colors in addition to the styling properties listed above (e.g. `White`, `Green`, `Cyan`, etc).

Examples:

* `Hex("#DEADED")`
* `Rgb(15, 100, 204)`
* `Keyword("orangered")`
* `Keyword(ColorKeyword.OrangeRed)`

For background colors, the same methods can be used, but must be prefixed with `Bg` instead.

* `BgHex("#DEADED")`
* `BgRgb(15, 100, 204)`
* `BgKeyword("orangered")`
* `BgKeyword(ColorKeyword.OrangeRed)`

## Examples

Using this API you can easily create helper methods for common scenarios.

```csharp
public static void WriteSuccessLine(string message)
{
    var successMessage = Fabulous.Green.Text("[SUCCESS]") + " " + message;
    successMessage.WriteLine();
}

public static void WriteWarningLine(string message)
{
    var warningMessage = Fabulous.Yellow.Text("[WARNING]") + " " + message;
    warningMessage.WriteLine();
}

public static void WriteErrorLine(string message)
{
    var errorMessage = Fabulous.Red.Text("[ERROR]") + " " + message;
    errorMessage.WriteLine();
}
```

## Windows

When using Windows, using a more sophisticated terminal emulator than `cmd.exe` will give you greater access to styling than basic coloring. Try [cmder](http://cmder.net/) or [ConEmu](https://conemu.github.io/).