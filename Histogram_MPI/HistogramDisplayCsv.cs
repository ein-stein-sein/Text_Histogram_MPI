using Histogram_MPI;

namespace Histogram_Sequential
{
    /// <summary>
    /// Class for displaying a histogram of character and word counts in the console
    /// </summary>
    internal static class HistogramDisplayCsv
    {
        /// <summary>
        /// Displays the given result in the console
        /// </summary>
        /// <param name="result">The result to display</param>
        public static void Display(Result result, string characterCountFilename, string wordCountFilename)
        {
            DisplayCharacterCount(result, characterCountFilename);


            DisplayWordCount(result, wordCountFilename);
        }

        private static void DisplayCharacterCount(Result result, String filename)
        {
            using StreamWriter fs = new StreamWriter(filename);
            foreach (var entry in result.CharacterCounts.OrderBy(entry => entry.Key))
            {
                fs.WriteLine($"{entry.Key},{result.CharacterCounts[entry.Key]}");
            }

        }

        private static void DisplayWordCount(Result result, String filename)
        {
            using StreamWriter fs = new StreamWriter(filename);
            foreach (var entry in result.WordCounts.OrderBy(entry => entry.Key))
            {
                fs.WriteLine($"{entry.Key},{result.WordCounts[entry.Key]}");
            }
        }
    }
}
