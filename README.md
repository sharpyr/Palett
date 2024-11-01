<p align="center">
  <a href="https://github.com/sharpyr/Palett">
    <img src="../media/palett-banner.svg" />
  </a>
  <p align="center"> Color space system </p>
</p>

[![Version](https://img.shields.io/nuget/vpre/Palett.svg)](https://www.nuget.org/packages/Palett)
[![Downloads](https://img.shields.io/nuget/dt/Palett.svg)](https://www.nuget.org/packages/Palett)
[![License](https://img.shields.io/github/license/sharpyr/Palett.svg)](https://github.com/sharpyr/Palett/LICENSE)
[![Language](https://img.shields.io/badge/language-C%23-blueviolet.svg)](https://dotnet.microsoft.com/learn/csharp)
[![Compatibility](https://img.shields.io/badge/compatibility-.NET%20Framework%204.7.2%2B%20%7C%20.NET%20Standard%202.0-blue.svg)]()
[![Dependent Libraries](https://img.shields.io/librariesio/dependents/nuget/Palett.svg?label=dependent%20libraries)](https://libraries.io/nuget/Palett)

## Features

- Transform between RGB and HSL color spaces.
- Convert among hex, int, (byte r, byte g, byte b), (float h, float s, float l) and System.Drawing.Color.
- Applicable to styles: Bold, Italic, Underline, and Inverse.
- Render an array or 2d-array of number into colored based on the relative value of each number.

## Packages

| Package            | What it's for                                         |
|--------------------|-------------------------------------------------------|
| `Palett`           | The core library, including all Palett sub projects   |
| `Palett.Cards`     | Preset color cards with 14 degrees of color gradients |
| `Palett.Convert`   | Convert colors among hex / int / rgb / hsl / Color    |
| `Palett.Deco`      | Render terminal string color                          |
| `Palett.Dye`       | Colorant (factory) for terminal string                |
| `Palett.Fluos`     | Colorize array and 2d-array in terminal               |
| `Palett.Presets`   | Preset color range                                    |
| `Palett.Projector` | Project a number to colored based on a range          |
| `Palett.Types`     | Base types in Palett series                           |
| `Palett.Utils`     | Base static params of ANSI values                     |

## Install

Palett is designed to work with .NET Standard 2.0.

Install [Palett package](https://www.nuget.org/packages/Palett) and its dependencies.

NuGet Package Manager:

```powershell
Install-Package Palett
```

.NET CLI:

```shell
dotnet add package Palett
```

All versions can be found [on nuget](https://www.nuget.org/packages/Palett#versions-body-tab).

## Usage

```cs

using Palett.Convert;
// using RGB = System.ValueTuple<byte, byte, byte>;
// using HSL = System.ValueTuple<float, float, float>;

(byte, byte, byte) rgb = (242, 114, 69);
var hsl = rgb.RgbToHsl();
var hex = hsl.HslToHex();
var rgb2 = Conv.HexToRgb(hex);
var int = rgb2.RgbToInt();

```

## License

Palett is licensed under the [MIT](https://github.com/sharpyr/Palett/LICENSE) license