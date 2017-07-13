using System;

namespace SJP.Fabulous.ConsoleTest
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Fabulous.WriteLine("test message");

            Fabulous.WriteLine(new FabulousText(new RgbColor(0,0,0), new RgbColor(0,1,1), TextDecoration.None, "hello"));

            Fabulous.WriteLine(new FabulousText(new RgbColor(0, 0, 0), new RgbColor(0, 1, 1), TextDecoration.None, "hello") + "combine test");

            var a1 = Fabulous
                .Foreground(new RgbColor(12, 12, 13))
                .Background(new RgbColor(12, 12, 14))
                .Text("abc");
            var a2 = "def";
            var a3 = Fabulous
                .Foreground(new RgbColor(12, 12, 13))
                .Background(new RgbColor(12, 12, 14))
                .Text("ghi");
            Fabulous.WriteLine(a1 + a2 + a3);

            var colorMode = ConsoleSupport.SupportedColorMode;

            WindowsConsole.EnableVirtualTerminalProcessing();
            const string UNDERLINE = "\x1B[4m";
            const string RESET = "\x1B[0m";
            Console.WriteLine("Some " + UNDERLINE + "underlined" + RESET + " text");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);

        }
    }
}
