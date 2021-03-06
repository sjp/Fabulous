using System;
using NUnit.Framework;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    internal static class EnvironmentVariableProviderTests
    {
        [Test]
        public static void HasEnvironmentVariable_GivenExistingVariable_ReturnsTrue()
        {
            var env = new EnvironmentVariableProvider();

            var pathVarPresent = env.HasEnvironmentVariable("PATH");

            Assert.IsTrue(pathVarPresent);
        }

        [Test]
        public static void HasEnvironmentVariable_GivenMissingVariable_ReturnsFalse()
        {
            var env = new EnvironmentVariableProvider();

            var notFoundVarPresent = env.HasEnvironmentVariable("THIS_WILL_NOT_BE_FOUND");

            Assert.IsFalse(notFoundVarPresent);
        }

        [Test]
        public static void GetEnvironmentVariable_GivenExistingVariable_ReturnsCorrectValue()
        {
            var env = new EnvironmentVariableProvider();

            var providerPath = env.GetEnvironmentVariable("PATH");
            var sysPath = Environment.GetEnvironmentVariable("PATH");

            Assert.AreEqual(sysPath, providerPath);
        }

        [Test]
        public static void GetEnvironmentVariable_GivenMissingVariable_ReturnsNull()
        {
            var env = new EnvironmentVariableProvider();
            var missingVar = env.GetEnvironmentVariable("THIS_WILL_NOT_BE_FOUND");

            Assert.IsNull(missingVar);
        }

        [Test, TestPlatform.Windows]
        public static void GetEnvironmentVariableT_GivenExistingVariableAndCorrectType_ReturnsCorrectValue()
        {
            var env = new EnvironmentVariableProvider();

            var numberOfProcessors = env.GetEnvironmentVariable<int>("NUMBER_OF_PROCESSORS");

            Assert.IsTrue(numberOfProcessors > 0);
        }

        [Test]
        public static void GetEnvironmentVariableT_GivenMissingVariable_ReturnsDefaultValue()
        {
            var env = new EnvironmentVariableProvider();
            var missingVar = env.GetEnvironmentVariable<int>("THIS_WILL_NOT_BE_FOUND");

            Assert.AreEqual(missingVar, default(int));
        }

        [Test]
        public static void TryGetEnvironmentVariable_GivenExistingVariable_ReturnsTrueAndCorrectValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable("PATH", out var providerPath);
            var sysPath = Environment.GetEnvironmentVariable("PATH");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isFound);
                Assert.AreEqual(sysPath, providerPath);
            });
        }

        [Test]
        public static void TryGetEnvironmentVariable_GivenMissingVariable_ReturnsFalseAndNullValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable("THIS_WILL_NOT_BE_FOUND", out var notFoundVar);
            _ = Environment.GetEnvironmentVariable("THIS_WILL_NOT_BE_FOUND");

            Assert.Multiple(() =>
            {
                Assert.IsFalse(isFound);
                Assert.IsNull(notFoundVar);
            });
        }

        [Test, TestPlatform.Windows]
        public static void TryGetEnvironmentVariableT_GivenExistingVariableAndCorrectType_ReturnsTrueAndCorrectValue()
        {
            var env = new EnvironmentVariableProvider();

            // note that this will probably only work on Windows
            var isFound = env.TryGetEnvironmentVariable<int>("NUMBER_OF_PROCESSORS", out var numberOfProcessors);
            var sysNumberOfProcs = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isFound);
                Assert.IsTrue(numberOfProcessors > 0);
                Assert.AreEqual(sysNumberOfProcs, numberOfProcessors.ToString());
            });
        }

        [Test]
        public static void TryGetEnvironmentVariableT_GivenExistingVariableAndIncorrectType_ReturnsFalseAndDefaultValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable<int>("PATH", out var pathInt);

            Assert.IsFalse(isFound);
            Assert.AreEqual(default(int), pathInt);
        }

        [Test]
        public static void TryGetEnvironmentVariableT_GivenMissingVariable_ReturnsFalseAndDefaultValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable<int>("THIS_WILL_NOT_BE_FOUND", out var notFoundVar);

            Assert.Multiple(() =>
            {
                Assert.IsFalse(isFound);
                Assert.AreEqual(default(int), notFoundVar);
            });
        }

        [Test, TestPlatform.Windows]
        public static void TryGetEnvironmentVariableTWithFormatter_GivenExistingVariableAndCorrectType_ReturnsTrueAndCorrectValue()
        {
            var env = new EnvironmentVariableProvider();

            // note that this will probably only work on Windows
            var isFound = env.TryGetEnvironmentVariable<int>("NUMBER_OF_PROCESSORS", null, out var numberOfProcessors);
            var sysNumberOfProcs = Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS");

            Assert.Multiple(() =>
            {
                Assert.IsTrue(isFound);
                Assert.IsTrue(numberOfProcessors > 0);
                Assert.AreEqual(sysNumberOfProcs, numberOfProcessors.ToString());
            });
        }

        [Test]
        public static void TryGetEnvironmentVariableTWithFormatter_GivenExistingVariableAndIncorrectType_ReturnsFalseAndDefaultValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable<int>("PATH", null, out var pathInt);

            Assert.Multiple(() =>
            {
                Assert.IsFalse(isFound);
                Assert.AreEqual(default(int), pathInt);
            });
        }

        [Test]
        public static void TryGetEnvironmentVariableTWithFormatter_GivenMissingVariable_ReturnsFalseAndDefaultValue()
        {
            var env = new EnvironmentVariableProvider();

            var isFound = env.TryGetEnvironmentVariable<int>("THIS_WILL_NOT_BE_FOUND", null, out var notFoundVar);

            Assert.Multiple(() =>
            {
                Assert.IsFalse(isFound);
                Assert.AreEqual(default(int), notFoundVar);
            });
        }
    }
}
