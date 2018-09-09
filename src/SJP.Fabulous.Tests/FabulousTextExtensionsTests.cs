using System;
using NUnit.Framework;
using Moq;
using SJP.Fabulous.Colorspaces;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    internal static class FabulousTextExtensionsTests
    {
        [Test]
        public static void Foreground_NullText_ThrowsArgNullException()
        {
            var color = Mock.Of<IColor>();
            Assert.Throws<ArgumentNullException>(() => FabulousTextExtensions.Foreground(null, color));
        }

        [Test]
        public static void Foreground_NullColor_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;
            Assert.Throws<ArgumentNullException>(() => text.Foreground(null));
        }

        [Test]
        public static void Foreground_GivenValidArgs_CreatesNewObject()
        {
            FabulousText text = "xyz";

            var newForeground = Mock.Of<IColor>();
            var result = text.Foreground(newForeground);

            Assert.AreNotSame(result, text);
        }

        [Test]
        public static void Background_NullText_ThrowsArgNullException()
        {
            var color = Mock.Of<IColor>();
            Assert.Throws<ArgumentNullException>(() => FabulousTextExtensions.Background(null, color));
        }

        [Test]
        public static void Background_NullColor_ThrowsArgNullException()
        {
            FabulousText text = string.Empty;
            Assert.Throws<ArgumentNullException>(() => text.Background(null));
        }

        [Test]
        public static void Background_GivenValidArgs_CreatesNewObject()
        {
            FabulousText text = "xyz";

            var newBackground = Mock.Of<IColor>();
            var result = text.Background(newBackground);

            Assert.AreNotSame(result, text);
        }

        [Test]
        public static void Text_GivenNullText_ThrowsArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() => FabulousTextExtensions.Text(null, string.Empty));
        }

        [Test]
        public static void Text_GivenValidText_SetsTextOnNewObject()
        {
            FabulousText text = "xyz";

            const string replacement = "abc";
            var result = text.Text(replacement);

            Assert.AreEqual(replacement, result.Text);
        }
    }
}
