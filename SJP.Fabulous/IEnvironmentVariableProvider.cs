using System;

namespace SJP.Fabulous
{
    public interface IEnvironmentVariableProvider
    {
        string GetEnvironmentVariable(string variableName);

        bool TryGetEnvironmentVariable(string variableName, out string value);

        T GetEnvironmentVariable<T>(string variableName) where T : IConvertible;

        bool TryGetEnvironmentVariable<T>(string variableName, out T value) where T : IConvertible;

        bool HasEnvironmentVariable(string variableName);
    }
}
