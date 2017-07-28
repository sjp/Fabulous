using System;
using NUnit.Framework;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class AnsiFullStringBuilderTests
    {
        [Test]
        public void Ctor_GivenNullInput_ThrowsArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AnsiFullStringBuilder((FabulousTextCollection)null));
        }

        [Test]
        public void ToAnsiString_GivenOnlyFgAndBgColors_ReturnsCorrectValue()
        {
            var message = "this is a test";
            var expected = $"\x1B[38;2;192;192;192m\x1B[48;2;0;0;0m{ message }\x1B[39m\x1B[49m";

            var text = Fabulous.White.BgBlack.Text(message);
            var builder = new AnsiFullStringBuilder(text);
            var result = builder.ToAnsiString();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToAnsiString_GivenTextWithStyling_ReturnsCorrectValue()
        {
            var message = "this is an important test";
            var expected = $"\x1B[38;2;192;192;192m\x1B[48;2;0;0;0m\x1B[1m\x1B[4m{ message }\x1B[39m\x1B[49m\x1B[22m\x1B[24m";

            var text = Fabulous.White.BgBlack.Bold.Underline.Text(message);
            var builder = new AnsiFullStringBuilder(text);
            var result = builder.ToAnsiString();

            Assert.AreEqual(expected, result);
        }
    }
}
