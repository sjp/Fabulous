using System;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.ConsoleTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            WindowsConsole.EnableVirtualTerminalProcessing();
            //Console.WriteLine("\x1b[38;2;40;177;249mTRUECOLOR\x1b[0m\n");
            //var x = Rgb.FromHex("afc");
            //var y = Rgb.FromHex("#aa0001");

            //Console.WriteLine("\u001b[16m\u001b[236mabc\u001b[39m\u001b[49m");

            //Fabulous.WriteLine("test message");
            //Fabulous.WriteLine(new FabulousText(new Rgb(0,0,0), new Rgb(0,1,1), TextDecoration.None, "hello"));
            //Fabulous.WriteLine(new FabulousText(new Rgb(0, 0, 0), new Rgb(0, 1, 1), TextDecoration.None, "hello") + "combine test");

            var a1 = Fabulous
                .Rgb(255, 0, 0)
                .BgHex("#00f")
                .Underline
                .Text("abc");
            var a2 = "def";
            var a3 = Fabulous
                .Foreground(new Rgb(0, 0, 0))
                .Background(new Rgb(0, 255, 0))
                .Text("ghi");
            Fabulous.WriteLine(a1 + a2 + a3);

            var standard = new StandardConsoleWriter(a1 + a2 + a3);
            standard.WriteLine();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}
