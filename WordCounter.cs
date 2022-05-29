namespace Histogram_MPI
{
    /// <summary>
    /// Class for counting the words in a text.
    /// </summary>
    public class WordCounter
    {
        /// <summary>
        /// The counts for each word.
        /// </summary>
        public Dictionary<string, int> WordCounts { get; } = new();

        private readonly HashSet<char> separators = new();

        private string currentWord = "";

        /// <summary>
        /// Constructs a new <see cref="WordCounter"/>
        /// </summary>
        public WordCounter()
        {
            // Exclude all characters before 'A'
            for (char c = (char)0; c < 'A'; c++)
            {
                separators.Add(c);
            }
            // Exclude all characters between 'Z' and 'a'
            for (char c = (char)('Z' + 1); c < 'a'; c++)
            {
                separators.Add(c);
            }
            // Exclude the ASCII characters after 'z'
            for (char c = (char)('z' + 1); c < 128; c++)
            {
                separators.Add(c);
            }
        }

        /// <summary>
        /// Processes a single character in order to count the words.
        /// </summary>
        /// <param name="c">The current character to process</param>
        public void Process(char c)
        {
            if (separators.Contains(c))
            {
                IncrementWordCount();
                currentWord = "";
            }
            else
            {
                currentWord += c;
            }
        }

        private void IncrementWordCount()
        {
            if (currentWord == "")
            {
                return;
            }

            if (WordCounts.ContainsKey(currentWord))
            {
                WordCounts[currentWord]++;
            }
            else
            {
                WordCounts[currentWord] = 1;
            }

        }
    }

}
