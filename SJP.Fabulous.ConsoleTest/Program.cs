using System;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.ConsoleTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var a1 = Fabulous
                .Rgb(255, 0, 0)
                .BgHex("#00f")
                .Underline
                .Reset
                .Text("abc");
            var a2 = "def";
            var a3 = Fabulous
                .Foreground(new Rgb(0, 0, 0))
                .Background(new Rgb(0, 255, 0))
                .Text("ghi");
            Fabulous.WriteLine(a1 + a2 + a3);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
