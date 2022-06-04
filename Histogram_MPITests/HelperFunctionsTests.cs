using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Histogram_MPI.Tests
{
    [TestClass()]
    public class HelperFunctionsTests
    {
        [TestMethod("Text empty")]
        public void TextEmptySplitIntoChunksTest()
        {
            string exampleText = "";
            string[] parts = HelperFunctions.SplitIntoChunks(exampleText, 3);
            int sumPartsLength = parts.Select(p => p.Length).Sum();

            Assert.AreEqual(parts[0], "");
            AssertEqualLength(exampleText, parts);
            AssertCharacterCount(exampleText, parts);
        }

        [TestMethod("Text length less than chunk size")]
        public void SplitIntoChunksTest1()
        {
            string exampleText = "Th";
            string[] parts = HelperFunctions.SplitIntoChunks(exampleText, 3);
            int sumPartsLength = parts.Select(p => p.Length).Sum();

            Assert.AreEqual(parts[0], "Th");
            AssertEqualLength(exampleText, parts);
            AssertCharacterCount(exampleText, parts);
        }

        [TestMethod()]
        public void SplitIntoChunksTest2()
        {
            string exampleText = "This ifwefs my text123";
            string[] parts = HelperFunctions.SplitIntoChunks(exampleText, 3);
            int sumPartsLength = parts.Select(p => p.Length).Sum();

            AssertEqualLength(exampleText, parts);
            AssertCharacterCount(exampleText, parts);
        }

        [TestMethod()]
        public void SplitIntoChunksTest3()
        {
            string exampleText = @"The Project Gutenberg EBook of Les Miserables, by Victor Hugo

This eBook is for the use of anyone anywhere at no cost and with
almost no restrictions whatsoever.  You may copy it, give it away or
re-use it under the terms of the Project Gutenberg License included
with this eBook or online at www.gutenberg.org


Title: Les Miserables
       Complete in Five Volumes";
            string[] parts = HelperFunctions.SplitIntoChunks(exampleText, 3);
            int sumPartsLength = parts.Select(p => p.Length).Sum();

            AssertEqualLength(exampleText, parts);
            AssertCharacterCount(exampleText, parts);
        }


        private static void AssertEqualLength(string exampleText, string[] parts)
        {
            int sumPartsLength = parts.Select(p => p.Length).Sum();
            Assert.AreEqual(exampleText.Length, sumPartsLength);
        }

        private static void AssertCharacterCount(string exampleText, string[] parts)
        {
            Dictionary<char, int> expected = exampleText.ToCharArray().GroupBy(c => c)
                .ToDictionary(c => c.Key, c => c.Count());

            Dictionary<char, int> actual = parts.SelectMany(p => p.ToCharArray()).GroupBy(c => c)
                .ToDictionary(c => c.Key, c => c.Count());

            CollectionAssert.AreEqual(expected.OrderBy(kv => kv.Key).ToList(), actual.OrderBy(kv => kv.Key).ToList());
        }

    }
}