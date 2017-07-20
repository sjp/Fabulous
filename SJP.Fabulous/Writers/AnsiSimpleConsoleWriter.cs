using System;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    // assumes that the text passed in is valid ansi formatted text
    // and does not do any further processing
    public class AnsiConsoleWriter : IConsoleWriter
    {
        public AnsiConsoleWriter(string text)
        {
            Text = text ?? string.Empty;
        }

        protected string Text { get; }

        public void Write()
        {
            Console.Write(Text);
        }

        public void Write(params object[] args)
        {
            Console.Write(Text, args);
        }

        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }

        public void WriteLine(params object[] args)
        {
            Write(args);
            Console.WriteLine();
        }

        public void WriteError()
        {
            Console.Error.Write(Text);
        }

        public void WriteError(params object[] args)
        {
            Console.Error.Write(Text, args);
        }

        public void WriteErrorLine()
        {
            WriteError();
            Console.Error.WriteLine();
        }

        public void WriteErrorLine(params object[] args)
        {
            WriteError(args);
            Console.Error.WriteLine();
        }

        public async Task WriteAsync()
        {
            await Console.Out.WriteAsync(Text);
        }

        public async Task WriteAsync(params object[] args)
        {
            await Console.Out.WriteAsync(string.Format(Text, args));
        }

        public async Task WriteLineAsync()
        {
            await WriteAsync();
            await Console.Out.WriteLineAsync();
        }

        public async Task WriteLineAsync(params object[] args)
        {
            await WriteAsync(args);
            await Console.Out.WriteLineAsync();
        }

        public async Task WriteErrorAsync()
        {
            await Console.Error.WriteAsync(Text);
        }

        public async Task WriteErrorAsync(params object[] args)
        {
            await Console.Error.WriteAsync(string.Format(Text, args));
        }

        public async Task WriteErrorLineAsync()
        {
            await WriteErrorAsync();
            await Console.Error.WriteLineAsync();
        }

        public async Task WriteErrorLineAsync(params object[] args)
        {
            await WriteErrorAsync(args);
            await Console.Error.WriteLineAsync();
        }
    }
}
