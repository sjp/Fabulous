﻿namespace SJP.Fabulous
{
    internal struct ConsoleStyle
    {
        public ConsoleStyle(int start, int close)
        {
            Start = start;
            Close = close;
        }

        public int Start { get; }

        public int Close { get; }
    }
}
