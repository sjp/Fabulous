# Fabulous

[![License (MIT)](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

This is a work in progress.

The aim of this project is to easily write styled text to the console in .NET. It is largely inspired by [Chalk](https://github.com/chalk/chalk) so Fabulous' API should be similar.

Goals:

* Simple and chainable text styling.
* Colour matching to the console's supported colour schemes. For example, if only 16 colours are supported and we want to use a colour that cannot be printed, then we use a nearest neighbour approach to match colours. This could be via the RGB colourspace, or perhaps something like HCL instead.