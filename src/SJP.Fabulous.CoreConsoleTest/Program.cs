using System;

namespace SJP.Fabulous.CoreConsoleTest
{
    internal static class Program
    {
        private static void Main()
        {
            Fabulous.WriteLine("core test");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}