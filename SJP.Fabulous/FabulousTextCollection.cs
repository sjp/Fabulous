using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    /// <summary>
    /// Represents a collection of styled text that can be printed together.
    /// </summary>
    public class FabulousTextCollection : IConsoleWriter, IEnumerable<FabulousText>
    {
        /// <summary>
        /// Creates a collection of styled text fragments.
        /// </summary>
        /// <param name="fragments">A collection of styled text fragments.</param>
        public FabulousTextCollection(params FabulousText[] fragments)
            : this(fragments as IEnumerable<FabulousText>)
        {
        }

        /// <summary>
        /// Creates a collection of styled text fragments.
        /// </summary>
        /// <param name="fragments">A collection of styled text fragments.</param>
        public FabulousTextCollection(IEnumerable<FabulousText> fragments)
        {
            Fragments = fragments ?? throw new ArgumentNullException(nameof(fragments));
        }

        /// <summary>
        /// A collection of styled text fragments
        /// </summary>
        public IEnumerable<FabulousText> Fragments { get; }

        /// <summary>
        /// Initializes a collection of styled text from a <see cref="string"/> object.
        /// </summary>
        /// <param name="text">Text in the form of a <see cref="string"/> object.</param>
        public static implicit operator FabulousTextCollection(string text)
        {
            FabulousText fragment = text;
            return new FabulousTextCollection(fragment);
        }

        /// <summary>
        /// Initializes a collection of styled text from a <see cref="FabulousText"/> object.
        /// </summary>
        /// <param name="fragment">A styled piece of text.</param>
        public static implicit operator FabulousTextCollection(FabulousText fragment) => new FabulousTextCollection(fragment);

        /// <summary>
        /// Combines a collection of text with a styled text fragment.
        /// </summary>
        /// <param name="collection">A styled collection of text.</param>
        /// <param name="fragment">A styled piece of text.</param>
        /// <returns>A new object representing the combined collection of styled text objects.</returns>
        public static FabulousTextCollection operator +(FabulousTextCollection collection, FabulousText fragment)
        {
            var fragments = new List<FabulousText>(collection.Fragments) { fragment };
            return new FabulousTextCollection(fragments);
        }

        /// <summary>
        /// Combines a collection of text with a styled text fragment.
        /// </summary>
        /// <param name="fragment">A styled piece of text.</param>
        /// <param name="collection">A styled collection of text.</param>
        /// <returns>A new object representing the combined collection of styled text objects.</returns>
        public static FabulousTextCollection operator +(FabulousText fragment, FabulousTextCollection collection)
        {
            var fragments = new List<FabulousText> { fragment };
            fragments.AddRange(collection.Fragments);
            return new FabulousTextCollection(fragments);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FabulousTextCollection"/>.
        /// </summary>
        /// <returns>An enumerator for <see cref="FabulousTextCollection"/>.</returns>
        public IEnumerator<FabulousText> GetEnumerator() => Fragments.GetEnumerator();

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="FabulousTextCollection"/>.
        /// </summary>
        /// <returns>An enumerator for <see cref="FabulousTextCollection"/>.</returns>
        IEnumerator IEnumerable.GetEnumerator() => Fragments.GetEnumerator();

        #region IConsoleWriter

        /// <summary>
        /// Writes the collection of styled text to the standard output stream.
        /// </summary>
        public void Write() => Fabulous.Write(this);

        /// <summary>
        /// Writes using the text representation of the specified array of objects to the standard output stream using the collection of styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void Write(params object[] args) => Fabulous.Write(this, args);

        /// <summary>
        /// Writes the collection of styled text followed by the current line terminator to the standard output stream.
        /// </summary>
        public void WriteLine() => Fabulous.WriteLine(this);

        /// <summary>
        /// Writes the collection of styled text using the text representation of the specified array of objects to the standard output stream using the collection of styled text as the specified format information. The current line terminator will also be printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        /// <summary>
        /// Writes the collection of styled text to the standard error stream.
        /// </summary>
        public void WriteError() => Fabulous.WriteError(this);

        /// <summary>
        /// Writes the collection of styled text using the text representation of the specified array of objects to the standard error stream using the collection of styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteError(params object[] args) => Fabulous.WriteError(this, args);

        /// <summary>
        /// Writes the collection of styled text followed by the current line terminator to the standard error stream.
        /// </summary>
        public void WriteErrorLine() => Fabulous.WriteErrorLine(this);

        /// <summary>
        /// Writes the collection of styled text using the text representation of the specified array of objects to the standard error stream using the collection of styled text as the specified format information. The current line terminator will also be printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        public void WriteErrorLine(params object[] args) => Fabulous.WriteErrorLine(this, args);

        /// <summary>
        /// Asynchronously writes the collection of styled text to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteAsync() => Fabulous.WriteAsync(this);

        /// <summary>
        /// Asynchronously writes using the text representation of the specified array of objects to the standard output stream using the collection of styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteAsync(params object[] args) => Fabulous.WriteAsync(this, args);

        /// <summary>
        /// Asynchronously writes the collection of styled text followed by the current line terminator to the standard output stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteLineAsync() => Fabulous.WriteLineAsync(this);

        /// <summary>
        /// Asynchronously writes the collection of styled text using the text representation of the specified array of objects to the standard output stream using the collection of styled text as the specified format information. The current line terminator will also be asynchronously printed to standard output stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteLineAsync(params object[] args) => Fabulous.WriteLineAsync(this, args);

        /// <summary>
        /// Asynchronously writes the collection of styled text to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorAsync() => Fabulous.WriteErrorAsync(this);

        /// <summary>
        /// Asynchronously writes the collection of styled text using the text representation of the specified array of objects to the standard error stream using the collection of styled text as the specified format information.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorAsync(params object[] args) => Fabulous.WriteErrorAsync(this, args);

        /// <summary>
        /// Asynchronously writes the collection of styled text followed by the current line terminator to the standard error stream.
        /// </summary>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorLineAsync() => Fabulous.WriteErrorLineAsync(this);

        /// <summary>
        /// Asynchronously writes the collection of styled text using the text representation of the specified array of objects to the standard error stream using the collection of styled text as the specified format information. The current line terminator will also be asynchronously printed to the standard error stream afterwards.
        /// </summary>
        /// <param name="args">An array of objects to write using the styled text format.</param>
        /// <returns>A task that represents the asynchronous write operation.</returns>
        public Task WriteErrorLineAsync(params object[] args) => Fabulous.WriteErrorLineAsync(this, args);

        #endregion IConsoleWriter
    }
}
