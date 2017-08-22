using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    /// <summary>
    /// Represents a collection of styled text that can be printed together.
    /// </summary>
    public class FabulousTextCollection : IConsoleWriter, IEnumerable<FabulousText>, IEquatable<FabulousTextCollection>
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
        /// <exception cref="ArgumentNullException"><paramref name="fragments"/> is <c>null</c>.</exception>
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
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="fragment"/> is <c>null</c>.</exception>
        public static FabulousTextCollection operator +(FabulousTextCollection collection, FabulousText fragment)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var fragments = new List<FabulousText>(collection.Fragments) { fragment };
            return new FabulousTextCollection(fragments);
        }

        /// <summary>
        /// Combines a collection of text with a styled text fragment.
        /// </summary>
        /// <param name="fragment">A styled piece of text.</param>
        /// <param name="collection">A styled collection of text.</param>
        /// <returns>A new object representing the combined collection of styled text objects.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="fragment"/> is <c>null</c>.</exception>
        public static FabulousTextCollection operator +(FabulousText fragment, FabulousTextCollection collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (fragment == null)
                throw new ArgumentNullException(nameof(fragment));

            var fragments = new List<FabulousText> { fragment };
            fragments.AddRange(collection.Fragments);
            return new FabulousTextCollection(fragments);
        }

        /// <summary>
        /// Combines two collections of styled text.
        /// </summary>
        /// <param name="collectionA">A styled collection of text.</param>
        /// <param name="collectionB">A styled collection of text.</param>
        /// <returns>A new object representing the combined collection of objects.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collectionA"/> or <paramref name="collectionB"/> is <c>null</c>.</exception>
        public static FabulousTextCollection operator +(FabulousTextCollection collectionA, FabulousTextCollection collectionB)
        {
            if (collectionA == null)
                throw new ArgumentNullException(nameof(collectionA));
            if (collectionB == null)
                throw new ArgumentNullException(nameof(collectionB));

            var fragments = collectionA.Fragments.ToList();
            fragments.AddRange(collectionB);

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

        /// <summary>
        /// Equality operator for FabulousTextCollection objects
        /// </summary>
        /// <param name="a">A FabulousTextCollection object.</param>
        /// <param name="b">Another FabulousTextCollection object.</param>
        /// <returns><c>true</c> if all of the contained FabulousText are equal, otherwise <c>false</c>.</returns>
        public static bool operator ==(FabulousTextCollection a, FabulousTextCollection b)
        {
            var aIsNull = ReferenceEquals(a, null);
            var bIsNull = ReferenceEquals(b, null);

            if (aIsNull && bIsNull)
                return true;

            if (aIsNull ^ bIsNull)
                return false;

            if (ReferenceEquals(a, b))
                return true;

            return a.Equals(b);
        }

        /// <summary>
        /// Inequality operator for FabulousTextCollection objects
        /// </summary>
        /// <param name="a">A FabulousTextCollection object.</param>
        /// <param name="b">Another FabulousTextCollection object.</param>
        /// <returns><c>false</c> if all of the contained FabulousText objects are equal, otherwise <c>true</c>.</returns>
        public static bool operator !=(FabulousTextCollection a, FabulousTextCollection b) => !(a == b);

        /// <summary>
        /// Indicates whether the text collection is equal to another text collection.
        /// </summary>
        /// <returns><c>true</c> if the text collection is equal to the <paramref name="other" /> parameter; otherwise, <c>false</c>.</returns>
        /// <param name="other">A text collection to compare with this object.</param>
        public bool Equals(FabulousTextCollection other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Fragments.SequenceEqual(other.Fragments);
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current text collection.
        /// </summary>
        /// <returns><c>true</c> if the specified object is equal to the current text collection; otherwise, <c>false</c>.</returns>
        /// <param name="obj">The object to compare with the current text collection.</param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as FabulousTextCollection);
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the text collection.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var result = 17;

                foreach (var fragment in Fragments)
                    result = (result * 31) + fragment.GetHashCode();

                return result;
            }
        }

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
