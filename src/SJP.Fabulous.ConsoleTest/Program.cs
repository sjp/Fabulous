using System;

namespace SJP.Fabulous.ConsoleTest
{
    internal static class Program
    {
        private static void Main()
        {
            FabulousConsole.ColorLevel = FabulousConsole.GetMaximumSupportedColorMode();
            var a1 = Fabulous
                .Red
                .BgHex("#00f")
                .Underline
                .Reset
                .Text("abc");
            var a2 = Fabulous.Yellow.Text("def");
            var a3 = Fabulous
                .Black
                .BgWhiteBright
                .Strikethrough
                .Text("ghi");
            Fabulous.WriteLine(a1 + a2 + a3);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
