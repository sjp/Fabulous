# Fabulous

[![License (MIT)](https://img.shields.io/badge/license-MIT-blue.svg)](https://opensource.org/licenses/MIT)

This is a work in progress.

The aim of this project is to easily write styled text to the console in .NET. It is largely inspired by [Chalk](https://github.com/chalk/chalk) so Fabulous' API should be similar. One key difference with Chalk is that Fabulous does not support nesting of styles, instead each piece of text is independently styled. This approach feels more natural in C\#. Consequently, because all of the styling is slightly more explicit, some of the options no longer make sense, e.g. Chalk's `inverse` option will not be used because we will instead set the foreground and background colors explicitly.

Goals:

* Simple and chainable text styling.
* Colour matching to the console's supported colour schemes. For example, if only 16 colours are supported and we want to use a colour that cannot be printed, then we use a nearest neighbour approach to match colours.