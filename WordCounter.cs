namespace Histogram_Sequential
{
    public class WordCounter
    {
        private readonly Dictionary<string, int> wordCounts = new();

        private readonly HashSet<char> separators = new();

        private string currentWord = "";

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

        public Dictionary<string, int> GetWordCounts()
        {
            return wordCounts;
        }

        private void IncrementWordCount()
        {
            if (currentWord == "")
            {
                return;
            }

            if (wordCounts.ContainsKey(currentWord))
            {
                wordCounts[currentWord]++;
            }
            else
            {
                wordCounts[currentWord] = 1;
            }

        }
    }

}
