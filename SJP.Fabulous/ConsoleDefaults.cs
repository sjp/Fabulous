﻿using System.Collections.Generic;
using System.Linq;
using EnumsNET;

namespace SJP.Fabulous
{
    public static class AnsiStyles
    {
        public static IEnumerable<ConsoleStyle> GetAnsiStyles(TextDecoration decorations)
        {
            var result = new List<ConsoleStyle>();

            var validDecorations = decorations.GetFlags().Where(d => d != TextDecoration.None);
            foreach (var decoration in validDecorations)
                result.Add(_decorations[decoration]);

            return result;
        }

        private readonly static IReadOnlyDictionary<TextDecoration, ConsoleStyle> _decorations = new Dictionary<TextDecoration, ConsoleStyle>
        {
            [TextDecoration.Blink] = new ConsoleStyle(5, 25),
            [TextDecoration.Bold] = new ConsoleStyle(1, 22),
            [TextDecoration.Dim] = new ConsoleStyle(2, 22),
            [TextDecoration.Hidden] = new ConsoleStyle(8, 28),
            [TextDecoration.Italic] = new ConsoleStyle(3, 23),
            [TextDecoration.Strikethrough] = new ConsoleStyle(9, 29),
            [TextDecoration.Underline] = new ConsoleStyle(4, 24)
        };
    }
}
