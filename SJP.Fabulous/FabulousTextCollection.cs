using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    public class FabulousTextCollection : IConsoleWriter, IEnumerable<FabulousText>
    {
        public FabulousTextCollection(params FabulousText[] fragments)
            : this(fragments as IEnumerable<FabulousText>)
        {
        }

        public FabulousTextCollection(IEnumerable<FabulousText> fragments)
        {
            Fragments = fragments ?? throw new ArgumentNullException(nameof(fragments));
        }

        public IEnumerable<FabulousText> Fragments { get; }

        public static implicit operator FabulousTextCollection(string text)
        {
            FabulousText fragment = text;
            return new FabulousTextCollection(fragment);
        }

        public static implicit operator FabulousTextCollection(FabulousText fragment)
        {
            return new FabulousTextCollection(fragment);
        }

        public static FabulousTextCollection operator +(FabulousTextCollection collection, FabulousText fragment)
        {
            var fragments = new List<FabulousText>(collection.Fragments) { fragment };
            return new FabulousTextCollection(fragments);
        }

        public IEnumerator<FabulousText> GetEnumerator() => Fragments.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Fragments.GetEnumerator();

        #region IConsoleWriter

        public void Write() => Fabulous.Write(this);

        public void Write(params object[] args) => Fabulous.Write(this, args);

        public void WriteLine() => Fabulous.WriteLine(this);

        public void WriteLine(params object[] args) => Fabulous.WriteLine(this, args);

        public void WriteError() => Fabulous.WriteError(this);

        public void WriteError(params object[] args) => Fabulous.WriteError(this, args);

        public void WriteErrorLine() => Fabulous.WriteErrorLine(this);

        public void WriteErrorLine(params object[] args) => Fabulous.WriteErrorLine(this, args);

        public Task WriteAsync() => Fabulous.WriteAsync(this);

        public Task WriteAsync(params object[] args) => Fabulous.WriteAsync(this, args);

        public Task WriteLineAsync() => Fabulous.WriteLineAsync(this);

        public Task WriteLineAsync(params object[] args) => Fabulous.WriteLineAsync(this, args);

        public Task WriteErrorAsync() => Fabulous.WriteErrorAsync(this);

        public Task WriteErrorAsync(params object[] args) => Fabulous.WriteErrorAsync(this, args);

        public Task WriteErrorLineAsync() => Fabulous.WriteErrorLineAsync(this);

        public Task WriteErrorLineAsync(params object[] args) => Fabulous.WriteErrorLineAsync(this, args);

        #endregion IConsoleWriter
    }
}
