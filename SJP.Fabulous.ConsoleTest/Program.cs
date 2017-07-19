using System;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.ConsoleTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            WindowsConsole.EnableVirtualTerminalProcessing();

            var x = Rgb.FromHex("afc");
            var y = Rgb.FromHex("#aa0001");

            Console.WriteLine("\u001b[16m\u001b[236mabc\u001b[39m\u001b[49m");

            //Fabulous.WriteLine("test message");
            //Fabulous.WriteLine(new FabulousText(new Rgb(0,0,0), new Rgb(0,1,1), TextDecoration.None, "hello"));
            //Fabulous.WriteLine(new FabulousText(new Rgb(0, 0, 0), new Rgb(0, 1, 1), TextDecoration.None, "hello") + "combine test");

            var a1 = Fabulous
                .Rgb(255, 0, 0)
                .BgHex("#00f")
                .Text("abc");
            var a2 = "def";
            var a3 = Fabulous
                .Foreground(new Rgb(0, 0, 0))
                .Background(new Rgb(0, 255, 0))
                .Text("ghi");
            //Fabulous.WriteLine(a1 + a2 + a3);

            var enhanced = new AnsiEnhancedConsoleWriter(a1);
            enhanced.Write();

            enhanced = new AnsiEnhancedConsoleWriter(a1 + a2 + a3);
            enhanced.Write();
            Console.WriteLine("\u001B[31m\u001B[42mfoo\u001B[49m\u001B[39m\u001B");

            var colorMode = ConsoleSupport.SupportedColorMode;

            WindowsConsole.EnableVirtualTerminalProcessing();
            // Console.WriteLine("\u001B[4m\u001B[31m\u001B[42mfoo\u001B[49m\u001B[39m\u001B[24m");
            Console.WriteLine("\u001B[0m\u001B[1m\u001B[38;2;144;10;178m\u001B[7mHello, " +
            "\u001B[27m\u001B[39m\u001B[22m\u001B[0m\u001B[0m\u001B[1m" +
            "\u001B[38;2;144;10;178mthere!\u001B[39m\u001B[22m\u001B[0m");

            const string UNDERLINE = "\x1B[4m";
            const string RESET = "\x1B[0m";
            Console.WriteLine("Some " + UNDERLINE + "underlined" + RESET + " text");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
