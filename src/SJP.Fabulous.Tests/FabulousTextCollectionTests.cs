using System;
using NUnit.Framework;
using System.Linq;

namespace SJP.Fabulous.Tests
{
    [TestFixture]
    public class FabulousTextCollectionTests
    {
        [Test]
        public void Ctor_GivenNullFragments_ThrowsArgNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new FabulousTextCollection(null));
        }

        [Test]
        public void Fragments_PropertyGet_ReturnsFragments()
        {
            FabulousText abc = "abc";
            FabulousText def = "def";
            var fragments = new[] { abc, def };

            var collection = new FabulousTextCollection(fragments);

            Assert.AreSame(fragments, collection.Fragments);
        }

        [Test]
        public void ImplicitOp_GivenString_CreatesViaCtor()
        {
            const string abc = "abc";
            FabulousText text = abc;

            FabulousTextCollection collection = abc;

            var collectionText = collection.Fragments.Single();

            Assert.AreEqual(text.Text, collectionText.Text);
        }

        [Test]
        public void ImplicitOp_GivenFabulousText_CreatesViaCtor()
        {
            FabulousText text = "abc";
            FabulousTextCollection collection = text;

            var collectionText = collection.Fragments.Single();

            Assert.AreEqual(text.Text, collectionText.Text);
        }

        [Test]
        public void AdditionOp_GivenCollectionThenText_AddsInCorrectOrder()
        {
            FabulousText abc = "abc";

            FabulousText def = "def";
            FabulousText ghi = "ghi";
            var collection = new FabulousTextCollection(def, ghi);

            var combined = abc + collection;
            var combinedText = string.Concat(combined.Fragments.Select(t => t.Text));
            var expected = abc.Text + def.Text + ghi.Text;

            Assert.IsTrue(expected == combinedText);
        }

        [Test]
        public void AdditionOp_GivenTextThenCollection_AddsInCorrectOrder()
        {
            FabulousText abc = "abc";
            FabulousText def = "def";
            var collection = new FabulousTextCollection(abc, def);

            FabulousText ghi = "ghi";
            var combined = collection + ghi;
            var combinedText = string.Concat(combined.Fragments.Select(t => t.Text));
            var expected = abc.Text + def.Text + ghi.Text;

            Assert.IsTrue(expected == combinedText);
        }

        [Test]
        public void AdditionOp_GivenTwoCollections_AddsInCorrectOrder()
        {
            FabulousTextCollection abc = "abc";
            FabulousTextCollection def = "def";

            var combined = abc + def;
            var combinedText = string.Concat(combined.Fragments.Select(t => t.Text));
            var expected = abc.Fragments.Single().Text + def.Fragments.Single().Text;

            Assert.IsTrue(expected == combinedText);
        }

        [Test]
        public void AdditionOp_GivenCollectionThenTextWithNullCollection_ThrowsArgNullException()
        {
            FabulousTextCollection collection = null;
            FabulousText text = "abc";

            Assert.Throws<ArgumentNullException>(() => { var x = collection + text; });
        }

        [Test]
        public void AdditionOp_GivenCollectionThenTextWithNullText_ThrowsArgNullException()
        {
            FabulousTextCollection collection = "abc";
            FabulousText text = null;

            Assert.Throws<ArgumentNullException>(() => { var x = collection + text; });
        }

        [Test]
        public void AdditionOp_GivenTextThenCollectionWithNullCollection_ThrowsArgNullException()
        {
            FabulousTextCollection collection = null;
            FabulousText text = "abc";

            Assert.Throws<ArgumentNullException>(() => { var x = text + collection; });
        }

        [Test]
        public void AdditionOp_GivenTextThenCollectionWithNullText_ThrowsArgNullException()
        {
            FabulousTextCollection collection = "abc";
            FabulousText text = null;

            Assert.Throws<ArgumentNullException>(() => { var x = text + collection; });
        }

        [Test]
        public void AdditionOp_GivenTwoCollectionsWithFirstCollectionNull_ThrowsArgNullException()
        {
            FabulousTextCollection collectionA = null;
            FabulousTextCollection collectionB = "abc";

            Assert.Throws<ArgumentNullException>(() => { var x = collectionA + collectionB; });
        }

        [Test]
        public void AdditionOp_GivenTwoCollectionsWithSecondCollectionNull_ThrowsArgNullException()
        {
            FabulousTextCollection collectionA = "abc";
            FabulousTextCollection collectionB = null;

            Assert.Throws<ArgumentNullException>(() => { var x = collectionA + collectionB; });
        }

        [Test]
        public void Equals_GivenDifferentValuedObjects_ReturnsFalse()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Red.Text(message);
            var b = bText + bText;

            var result = a.Equals(b);

            Assert.IsFalse(result);
        }

        [Test]
        public void Equals_GivenSameValuedObjects_ReturnsTrue()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Green.Text(message);
            var b = bText + bText;

            var result = a.Equals(b);

            Assert.IsTrue(result);
        }

        [Test]
        public void Equals_GivenSameObjects_ReturnsTrue()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var result = a.Equals(a);

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsOp_GivenSameValuedObjects_ReturnsTrue()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Green.Text(message);
            var b = bText + bText;

            var result = a == b;

            Assert.IsTrue(result);
        }

        [Test]
        public void EqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Red.Text(message);
            var b = bText + bText;

            var result = a == b;

            Assert.IsFalse(result);
        }

        [Test]
        public void NotEqualsOp_GivenDifferentValuedObjects_ReturnsFalse()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Red.Text(message);
            var b = bText + bText;

            var result = a != b;

            Assert.IsTrue(result);
        }

        [Test]
        public void NotEqualsOp_GivenSameValuedObjects_ReturnsFalse()
        {
            const string message = "asd";
            var aText = Fabulous.Green.Text(message);
            var a = aText + aText;

            var bText = Fabulous.Green.Text(message);
            var b = bText + bText;

            var result = a != b;

            Assert.IsFalse(result);
        }
    }
}
