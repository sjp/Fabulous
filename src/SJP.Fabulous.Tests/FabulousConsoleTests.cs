using System;
using NUnit.Framework;
using Moq;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class FabulousConsoleTests
    {
        [SetUp, TearDown]
        public void Reset()
        {
            FabulousConsole.Environment = new EnvironmentVariableProvider();
            FabulousConsole.ColorLevel = ConsoleColorMode.Standard;
        }

        [Test]
        public void ColorLevel_OnDefaultPropertyGet_ReturnsStandardColorMode()
        {
            var colorLevel = FabulousConsole.ColorLevel;
            Assert.AreEqual(ConsoleColorMode.Standard, colorLevel);
        }

        [Test]
        public void ColorLevel_OnPropertySetWithInvalidEnum_ThrowsArgumentException()
        {
            var invalidLevel = (ConsoleColorMode)23904;
            Assert.Throws<ArgumentException>(() => FabulousConsole.ColorLevel = invalidLevel);
        }

        [Test]
        public void ColorLevel_OnPropertySetWithValidEnum_SetsCorrectly()
        {
            FabulousConsole.ColorLevel = ConsoleColorMode.Enhanced;
            Assert.AreEqual(ConsoleColorMode.Enhanced, FabulousConsole.ColorLevel);
        }

        [Test]
        public void Environment_OnPropertySetWithNullValue_ThrowsArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FabulousConsole.Environment = null);
        }

        [Test]
        public void Environment_OnPropertySetWithValidValue_SetsCorrectly()
        {
            var newEnv = Mock.Of<IEnvironmentVariableProvider>();

            FabulousConsole.Environment = newEnv;

            Assert.AreSame(newEnv, FabulousConsole.Environment);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenCIVariableIsTravis_ReturnsBasic()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var ciVar = "Travis";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("CI", out ciVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Basic, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenTravisVariablePresent_ReturnsBasic()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var ciVar = string.Empty;
            newEnv.Setup(env => env.TryGetEnvironmentVariable("CI", out ciVar)).Returns(true);
            newEnv.Setup(env => env.HasEnvironmentVariable("TRAVIS")).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Basic, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenCircleCiVariablePresent_ReturnsBasic()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var ciVar = string.Empty;
            newEnv.Setup(env => env.TryGetEnvironmentVariable("CI", out ciVar)).Returns(true);
            newEnv.Setup(env => env.HasEnvironmentVariable("CIRCLECI")).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Basic, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenCIVariablePresentWithUnknownCI_ReturnsNone()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var ciVar = string.Empty;
            newEnv.Setup(env => env.TryGetEnvironmentVariable("CI", out ciVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.None, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenTeamCityVariablePresentAndAtLeastVersion9dot1_ReturnsBasic()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var tcVersionVar = "9.3";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("TEAMCITY_VERSION", out tcVersionVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Basic, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenTeamCityVariablePresentLessThanVersion9dot1_ReturnsNone()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var tcVersionVar = "9.0";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("TEAMCITY_VERSION", out tcVersionVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.None, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenTeamCityVariablePresentWithBadData_ReturnsNone()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var tcVersionVar = "xyz";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("TEAMCITY_VERSION", out tcVersionVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.None, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenConEmuANSIPresentAndON_ReturnsEnhanced()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var conemuVar = "ON";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("ConEmuANSI", out conemuVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Enhanced, result);
        }

        [Test]
        public void GetMaximumSupportedColorMode_WhenConEmuANSIPresentAndNotON_ReturnsBasic()
        {
            var newEnv = new Mock<IEnvironmentVariableProvider>();

            var conemuVar = "xyz";
            newEnv.Setup(env => env.TryGetEnvironmentVariable("ConEmuANSI", out conemuVar)).Returns(true);

            FabulousConsole.Environment = newEnv.Object;
            var result = FabulousConsole.GetMaximumSupportedColorMode();

            Assert.AreEqual(ConsoleColorMode.Basic, result);
        }

        [TestFixture]
        public class NonWindowsTests
        {
            [SetUp]
            public void Reset()
            {
                FabulousConsole.Environment = new EnvironmentVariableProvider();
                FabulousConsole.ColorLevel = ConsoleColorMode.Standard;
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermProgramPresentWithHyper_ReturnsFull()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var termProgram = "Hyper";
                newEnv.Setup(env => WindowsConsole.IsWindowsPlatform).Returns(false);
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM", out termProgram)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Full, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermProgramPresentWithAppleTerminal_ReturnsFull()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var termProgram = "Apple_Terminal";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM", out termProgram)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Enhanced, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermProgramPresentWithiTermAndMajorVersionGte3_ReturnsFull()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var termProgram = "iTerm.app";
                var termProgramVersion = "3.1";

                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM", out termProgram)).Returns(true);
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out termProgramVersion)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Full, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermProgramPresentWithiTermAndMajorVersionLt3_ReturnsEnhanced()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var termProgram = "iTerm.app";
                var termProgramVersion = "2.4.5";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM", out termProgram)).Returns(true);
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out termProgramVersion)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Enhanced, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermProgramPresentWithiTermAndJunkVersion_ReturnsEnhanced()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var termProgram = "iTerm.app";
                var termProgramVersion = "xyz";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM", out termProgram)).Returns(true);
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM_PROGRAM_VERSION", out termProgramVersion)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Enhanced, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithScreen256ColorValue_ReturnsEnhanced()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "screen-256color";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Enhanced, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithXTerm256ColorValue_ReturnsEnhanced()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "xterm-256color";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Enhanced, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithScreenValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "screen";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithXTermValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "xterm";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithVT100Value_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "vt100";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithAnsiValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "ansi";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithColorValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "color";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithCygwinValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "vt100";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithLinuxValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "linux";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenTermPresentWithDumbValue_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                var term = "dumb";
                newEnv.Setup(env => env.TryGetEnvironmentVariable("TERM", out term)).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.None, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenColortermPresent_ReturnsBasic()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                newEnv.Setup(env => env.HasEnvironmentVariable("COLORTERM")).Returns(true);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.Basic, result);
            }

            [Test]
            public void GetMaximumSupportedColorMode_WhenNoVariablesPresent_ReturnsNone()
            {
                if (WindowsConsole.IsWindowsPlatform)
                    return;

                var newEnv = new Mock<IEnvironmentVariableProvider>();

                string tmp;
                newEnv.Setup(env => env.HasEnvironmentVariable(It.IsAny<string>())).Returns(false);
                newEnv.Setup(env => env.TryGetEnvironmentVariable(It.IsAny<string>(), out tmp)).Returns(false);

                FabulousConsole.Environment = newEnv.Object;
                var result = FabulousConsole.GetMaximumSupportedColorMode();

                Assert.AreEqual(ConsoleColorMode.None, result);
            }
        }
    }
}
