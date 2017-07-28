using System;
using NUnit.Framework;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class AnsiSimpleStringBuilderTests
    {
        [Test]
        public void Ctor_GivenNullInput_ThrowsArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new AnsiSimpleStringBuilder((FabulousTextCollection)null));
        }

        [Test]
        public void ToAnsiString_GivenOnlyFgAndBgColors_ReturnsCorrectValue()
        {
            var message = "this is a test";
            var expected = $"\x1B[97m\x1B[40m{ message }\x1B[39m\x1B[49m";

            var text = Fabulous.White.BgBlack.Text(message);
            var builder = new AnsiSimpleStringBuilder(text);
            var result = builder.ToAnsiString();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToAnsiString_GivenTextWithStyling_ReturnsCorrectValue()
        {
            var message = "this is an important test";
            var expected = $"\x1B[97m\x1B[40m\x1B[1m\x1B[4m{ message }\x1B[39m\x1B[49m\x1B[22m\x1B[24m";

            var text = Fabulous.White.BgBlack.Bold.Underline.Text(message);
            var builder = new AnsiSimpleStringBuilder(text);
            var result = builder.ToAnsiString();

            Assert.AreEqual(expected, result);
        }
    }
}
