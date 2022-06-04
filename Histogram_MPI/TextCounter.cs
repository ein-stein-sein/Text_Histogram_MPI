namespace Histogram_MPI
{
    /// <summary>
    /// Class for counting characters and words in a text.
    /// </summary>
    public class TextCounter
    {
        /// <summary>
        /// Counts characters and words in the given text.
        /// </summary>
        /// <param name="text">The text to count.</param>
        /// <returns>Character and word counts in the given text.</returns>
        public Result Count(string text)
        {
            CharacterCounter characterCounter = new();
            WordCounter wordCounter = new();

            foreach (char a in text)
            {
                characterCounter.Process(a);
                wordCounter.Process(a);
            }
            wordCounter.Finish();

            return new Result(characterCounter.CharacterCounts, wordCounter.WordCounts);
        }
    }
}
