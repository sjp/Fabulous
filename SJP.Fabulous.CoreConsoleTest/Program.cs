﻿using System;
using SJP.Fabulous;

namespace SJP.Fabulous.CoreConsoleTest
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Fabulous.WriteLine("core test");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }
    }
}