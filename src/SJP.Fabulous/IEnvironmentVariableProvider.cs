using System;

namespace SJP.Fabulous
{
    /// <summary>
    /// Defines methods used to provide environment variables.
    /// </summary>
    public interface IEnvironmentVariableProvider
    {
        /// <summary>
        /// Retrieves the value of an environment variable from the current process.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns>The value of the environment variable. This will be <c>null</c> if missing.</returns>
        string GetEnvironmentVariable(string variable);

        /// <summary>
        /// Retrieves the value of an environment variable from the current process. The return value indicates whether retrieval was successful.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="value">The value of the environment variable. This will be <c>null</c> if missing.</param>
        /// <returns><c>true</c> if the environment variable is present. <c>false</c> otherwise.</returns>
        bool TryGetEnvironmentVariable(string variable, out string value);

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns>The value of the environment variable as an object of type <typeparamref name="T"/>.</returns>
        T GetEnvironmentVariable<T>(string variable) where T : struct, IConvertible;

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type. The return value indicates whether retrieval and conversion was successful.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="value"></param>
        /// <returns><c>true</c> if the environment variable is present. <c>false</c> otherwise.</returns>
        bool TryGetEnvironmentVariable<T>(string variable, out T value) where T : struct, IConvertible;

        /// <summary>
        /// Retrieves the value of an environment variable from the current process to the target type. The return value indicates whether retrieval and conversion was successful.
        /// </summary>
        /// <typeparam name="T">The type of object to return.</typeparam>
        /// <param name="variable">The name of the environment variable.</param>
        /// <param name="formatter">An object that supplies culture-specific formatting information.</param>
        /// <param name="value"></param>
        /// <returns><c>true</c> if the environment variable is present. <c>false</c> otherwise.</returns>
        bool TryGetEnvironmentVariable<T>(string variable, IFormatProvider formatter, out T value) where T : struct, IConvertible;

        /// <summary>
        /// Determines whether an environment variable is present.
        /// </summary>
        /// <param name="variable">The name of the environment variable.</param>
        /// <returns><c>true</c> if the environment variable is present. <c>false</c> otherwise.</returns>
        bool HasEnvironmentVariable(string variable);
    }
}
