using System;

namespace SJP.Fabulous
{
    /// <summary>
    /// A provider of environment variables, including testing for presence and strongly typed value retrieval.
    /// </summary>
    public class EnvironmentVariableProvider : IEnvironmentVariableProvider
    {
        /// <summary>
        /// Retrieves the value of an environment variable from the current process.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns>The value of the environment variable. This will be <b>null</b> if missing.</returns>
        public string GetEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable);

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns>The value of the environment variable as an object of type <typeparamref name="T"/>.</returns>
        /// <remarks>This method can throw an exception if the variable does not exist or cannot be converted to <typeparamref name="T"/>. <see cref="TryGetEnvironmentVariable(string, out string)"/> and related overloads for safe access.</remarks>
        public T GetEnvironmentVariable<T>(string variable) where T : IConvertible
        {
            var result = Environment.GetEnvironmentVariable(variable);
            if (result == null)
                return default(T);

            return (T)Convert.ChangeType(result, typeof(T));
        }

        /// <summary>
        /// Determines whether an environment variable is present.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns><b>True</b> if the environment variable is present. <b>False</b> otherwise.</returns>
        public bool HasEnvironmentVariable(string variable) => Environment.GetEnvironmentVariable(variable) != null;

        /// <summary>
        /// Retrieves the value of an environment variable from the current process. The return value indicates whether retrieval was successful.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="value">The value of the environment variable. This will be <b>null</b> if missing.</param>
        /// <returns><b>True</b> if the environment variable is present. <b>False</b> otherwise.</returns>
        public bool TryGetEnvironmentVariable(string variable, out string value)
        {
            value = Environment.GetEnvironmentVariable(variable);
            return value != null;
        }

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type. The return value indicates whether retrieval and conversion was successful.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="value"></param>
        /// <returns><b>True</b> if the environment variable is present. <b>False</b> otherwise.</returns>
        public bool TryGetEnvironmentVariable<T>(string variable, out T value) where T : IConvertible
        {
            var result = Environment.GetEnvironmentVariable(variable);
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

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type. The return value indicates whether retrieval and conversion was successful.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="formatter">An object that supplies culture-specific formatting information.</param>
        /// <param name="value"></param>
        /// <returns><b>True</b> if the environment variable is present. <b>False</b> otherwise.</returns>
        public bool TryGetEnvironmentVariable<T>(string variable, IFormatProvider formatter, out T value) where T : IConvertible
        {
            var result = Environment.GetEnvironmentVariable(variable);
            if (result == null)
            {
                value = default(T);
                return false;
            }

            try
            {
                value = (T)Convert.ChangeType(result, typeof(T), formatter);
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
