using System;

namespace SJP.Fabulous
{
    public class EnvironmentVariableProvider : IEnvironmentVariableProvider
    {
        public string GetEnvironmentVariable(string variableName) => Environment.GetEnvironmentVariable(variableName);

        public T GetEnvironmentVariable<T>(string variableName) where T : IConvertible
        {
            var result = Environment.GetEnvironmentVariable(variableName);
            if (result == null)
                return default(T);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public bool HasEnvironmentVariable(string variableName) => Environment.GetEnvironmentVariable(variableName) != null;

        public bool TryGetEnvironmentVariable(string variableName, out string value)
        {
            value = Environment.GetEnvironmentVariable(variableName);
            return value != null;
        }

        public bool TryGetEnvironmentVariable<T>(string variableName, out T value) where T : IConvertible
        {
            var result = Environment.GetEnvironmentVariable(variableName);
            if (result == null)
            {
                value = default(T);
                return false;
            }

            try
            {
                value = (T)Convert.ChangeType(result, typeof(T));
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }
    }
}
