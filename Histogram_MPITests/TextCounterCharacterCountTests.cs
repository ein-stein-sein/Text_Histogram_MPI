using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Histogram_MPI.Tests
{
    [TestClass()]
    public class TextCounterCharacterCountTests
    {
        [TestMethod("Count character a")]
        public void CharacterCountTest1()
        {
            TextCounter counter = new TextCounter();

            Result result = counter.Count("I have a dream!");

            Assert.AreEqual(3, result.CharacterCounts['a']);
        }

        [TestMethod("Count character space")]
        public void CharacterCountTest2()
        {
            TextCounter counter = new TextCounter();

            Result result = counter.Count("I have a dream!");

            Assert.AreEqual(3, result.CharacterCounts[' ']);
        }

        [TestMethod("Count character i case sensitive")]
        public void CharacterCountCaseSensitiveTest()
        {
            TextCounter counter = new TextCounter();

            Result result = counter.Count("I have an intelligent alogorithm!");

            Assert.AreEqual(1, result.CharacterCounts['I']);
            Assert.AreEqual(3, result.CharacterCounts['i']);
        }

    }
}