using System;
using System.Linq;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    /// <summary>
    /// A console writer that only prints text and does not perform any styling.
    /// </summary>
    public class UnstyledConsoleWriter : IConsoleWriter
    {
        /// <summary>
        /// Creates a console writer that performs no styling.
        /// </summary>
        /// <param name="text">A piece of text to be printed.</param>
        public UnstyledConsoleWriter(FabulousText text)
            : this(new FabulousTextCollection(text))
        {
        }

        /// <summary>
        /// Creates a console writer that performs no styling.
        /// </summary>
        /// <param name="textCollection">A collection of text to be printed.</param>
        public UnstyledConsoleWriter(FabulousTextCollection textCollection)
        {
            TextCollection = textCollection ?? throw new ArgumentNullException(nameof(textCollection));
        }

        /// <summary>
        /// The pieces of text to be printed
        /// </summary>
        protected FabulousTextCollection TextCollection { get; }

        /// <summary>
        /// Writes unstyled text to the standard output stream.
        /// </summary>
        public void Write()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                Console.Write(text.Text);
            }
        }

        /// <summary>
        /// Writes unstyled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void Write(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                Console.Write(text.Text, args);
            }
        }

        /// <summary>
        /// Writes unstyled text followed by the current line terminator to the standard output stream.
        /// </summary>
        public void WriteLine()
        {
            Write();
            Console.WriteLine();
        }

        /// <summary>
        /// Writes unstyled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteLine(params object[] args)
        {
            Write(args);
            Console.WriteLine();
        }

        /// <summary>
        /// Writes unstyled text to the standard error stream.
        /// </summary>
        public void WriteError()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                Console.Error.Write(text.Text);
            }
        }

        /// <summary>
        /// Writes unstyled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteError(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                Console.Error.Write(text.Text, args);
            }
        }

        /// <summary>
        /// Writes unstyled text followed by the current line terminator to the standard error stream.
        /// </summary>
        public void WriteErrorLine()
        {
            WriteError();
            Console.Error.WriteLine();
        }

        /// <summary>
        /// Writes unstyled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteErrorLine(params object[] args)
        {
            WriteError(args);
            Console.Error.WriteLine();
        }

        /// <summary>
        /// Asynchronously writes unstyled text to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                await Console.Out.WriteAsync(text.Text);
            }
        }

        /// <summary>
        /// Asynchronously writes unstyled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                await Console.Out.WriteAsync(string.Format(text.Text, args));
            }
        }

        /// <summary>
        /// Asynchronously writes unstyled text followed by the current line terminator to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteLineAsync()
        {
            await WriteAsync();
            await Console.Out.WriteLineAsync();
        }

        /// <summary>
        /// Asynchronously writes unstyled text using the text representation of the specified array of objects to the standard output stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteLineAsync(params object[] args)
        {
            await WriteAsync(args);
            await Console.Out.WriteLineAsync();
        }

        /// <summary>
        /// Asynchronously writes unstyled text to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteErrorAsync()
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                await Console.Error.WriteAsync(text.Text);
            }
        }

        /// <summary>
        /// Asynchronously writes unstyled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteErrorAsync(params object[] args)
        {
            foreach (var text in TextCollection.Where(t => t.Text.Length > 0))
            {
                await Console.Error.WriteAsync(string.Format(text.Text, args));
            }
        }

        /// <summary>
        /// Asynchronously writes unstyled text followed by the current line terminator to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteErrorLineAsync()
        {
            await WriteErrorAsync();
            await Console.Error.WriteLineAsync();
        }

        /// <summary>
        /// Asynchronously writes unstyled text using the text representation of the specified array of objects to the standard error stream using the styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public async Task WriteErrorLineAsync(params object[] args)
        {
            await WriteErrorAsync(args);
            await Console.Error.WriteLineAsync();
        }
    }
}
