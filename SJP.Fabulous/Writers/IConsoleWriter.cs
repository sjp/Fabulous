using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJP.Fabulous
{
    public interface IConsoleWriter : IConsoleWriterSync, IConsoleWriterAsync { }

    public interface IConsoleWriterSync
    {
        void Write();

        void Write(params object[] args);

        void WriteLine();

        void WriteLine(params object[] args);

        void WriteError();

        void WriteError(params object[] args);

        void WriteErrorLine();

        void WriteErrorLine(params object[] args);
    }

    public interface IConsoleWriterAsync
    {
        Task WriteAsync();

        Task WriteAsync(params object[] args);

        Task WriteLineAsync();

        Task WriteLineAsync(params object[] args);

        Task WriteErrorAsync();

        Task WriteErrorAsync(params object[] args);

        Task WriteErrorLineAsync();

        Task WriteErrorLineAsync(params object[] args);
    }
}
