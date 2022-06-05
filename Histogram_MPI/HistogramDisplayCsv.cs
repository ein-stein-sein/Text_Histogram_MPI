using Histogram_MPI;

namespace Histogram_Sequential
{
    /// <summary>
    /// Class for writing histograms of character and word counts into CSV files
    /// </summary>
    internal static class HistogramDisplayCsv
    {
        /// <summary>
        /// Write the given result in CSV files
        /// </summary>
        /// <param name="result">The result to display</param>
        /// <param name="characterCountFilename">the filename for the character count</param>
        /// <param name="wordCountFilename">the filename for the word count</param>
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
