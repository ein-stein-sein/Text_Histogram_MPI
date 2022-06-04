using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Histogram_MPI.Tests
{
    [TestClass()]
    public class TextCounterWordCountTests
    {


        [TestMethod("Simple sentence word count test")]
        public void SimpleSentenceWordCountTest()
        {
            TextCounter counter = new();

            Result result = counter.Count("I have a dream.");

            Assert.AreEqual(4, result.WordCounts.Count);
            Assert.AreEqual(1, result.WordCounts["I"]);
            Assert.AreEqual(1, result.WordCounts["have"]);
            Assert.AreEqual(1, result.WordCounts["a"]);
            Assert.AreEqual(1, result.WordCounts["dream"]);
        }

        [TestMethod("Simple sentence word count 2 test")]
        public void SimpleSentenceWordCount2Test()
        {
            TextCounter counter = new();

            Result result = counter.Count("most honorable pomp that could");

            Assert.AreEqual(5, result.WordCounts.Count);
            Assert.AreEqual(1, result.WordCounts["most"]);
            Assert.AreEqual(1, result.WordCounts["honorable"]);
            Assert.AreEqual(1, result.WordCounts["pomp"]);
            Assert.AreEqual(1, result.WordCounts["that"]);
            Assert.AreEqual(1, result.WordCounts["could"]);
        }

        [TestMethod("Simple sentence with exclamation mark word count test")]
        public void SimpleSentenceWithExclamationMarkWordCountTest()
        {
            TextCounter counter = new();

            Result result = counter.Count("I have a dream!");

            Assert.AreEqual(4, result.WordCounts.Count);
            Assert.AreEqual(1, result.WordCounts["I"]);
            Assert.AreEqual(1, result.WordCounts["have"]);
            Assert.AreEqual(1, result.WordCounts["a"]);
            Assert.AreEqual(1, result.WordCounts["dream"]);
        }

        [TestMethod("Simple sentence with repeated words word count test")]
        public void SimpleWordWithRepeatedWrodsCountTest()
        {
            TextCounter counter = new();

            Result result = counter.Count("I have a dream and I believe that we must make this dream come true!");

            Assert.AreEqual(13, result.WordCounts.Count);
            Assert.AreEqual(2, result.WordCounts["I"]);
            Assert.AreEqual(1, result.WordCounts["have"]);
            Assert.AreEqual(1, result.WordCounts["a"]);
            Assert.AreEqual(2, result.WordCounts["dream"]);
            Assert.AreEqual(1, result.WordCounts["and"]);
            Assert.AreEqual(1, result.WordCounts["believe"]);
            Assert.AreEqual(1, result.WordCounts["that"]);
            Assert.AreEqual(1, result.WordCounts["we"]);
            Assert.AreEqual(1, result.WordCounts["must"]);
            Assert.AreEqual(1, result.WordCounts["make"]);
            Assert.AreEqual(1, result.WordCounts["this"]);
            Assert.AreEqual(1, result.WordCounts["come"]);
            Assert.AreEqual(1, result.WordCounts["true"]);
        }

        [TestMethod("Simple sentence with line break word count test")]
        public void SimpleWordCountWithLineBreakTest()
        {
            TextCounter counter = new TextCounter();

            Result result = counter.Count(@"
                I dont believe 
                you
                ");

            Assert.AreEqual(4, result.WordCounts.Count);
            Assert.AreEqual(1, result.WordCounts["I"]);
            Assert.AreEqual(1, result.WordCounts["dont"]);
            Assert.AreEqual(1, result.WordCounts["believe"]);
            Assert.AreEqual(1, result.WordCounts["you"]);
        }

        [TestMethod("Sample King Arthur word count test")]
        public void SampleKingArthurWordCountTest()
        {
            TextCounter counter = new TextCounter();

            Result result = counter.Count(@"""Was it not, "" cried Gawain, ""in the house of this Thiébault that
                                           Meliance of Lis was nurtured ? """);

            Assert.AreEqual(16, result.WordCounts.Count);
            Assert.AreEqual(1, result.WordCounts["Was"]);
            Assert.AreEqual(1, result.WordCounts["it"]);
            Assert.AreEqual(1, result.WordCounts["not"]);
            Assert.AreEqual(1, result.WordCounts["cried"]);
            Assert.AreEqual(1, result.WordCounts["Gawain"]);
            Assert.AreEqual(1, result.WordCounts["in"]);
            Assert.AreEqual(1, result.WordCounts["the"]);
            Assert.AreEqual(1, result.WordCounts["not"]);
            Assert.AreEqual(1, result.WordCounts["house"]);
            Assert.AreEqual(2, result.WordCounts["of"]);
            Assert.AreEqual(1, result.WordCounts["this"]);
            Assert.AreEqual(1, result.WordCounts["Thiébault"]);
            Assert.AreEqual(1, result.WordCounts["that"]);
            Assert.AreEqual(1, result.WordCounts["Meliance"]);
            Assert.AreEqual(1, result.WordCounts["Lis"]);
            Assert.AreEqual(1, result.WordCounts["was"]);
            Assert.AreEqual(1, result.WordCounts["nurtured"]);
        }


    }
}