namespace Histogram_MPI
{
    /// <summary>
    /// Class for displaying a histogram of character and word counts in the console
    /// </summary>
    internal static class HistogramDisplay
    {
        /// <summary>
        /// Displays the given result in the console
        /// </summary>
        /// <param name="result">The result to display</param>
        public static void Display(Result result)
        {
            Console.WriteLine("-------");
            Console.WriteLine("CHARACTER COUNT");
            DisplayCharacterCount(result);

            Console.WriteLine("-------");
            Console.WriteLine("WORD COUNT");
            DisplayWordCount(result);

        }

        private static void DisplayCharacterCount(Result result)
        {
            foreach (var entry in result.CharacterCounts.OrderBy(entry => entry.Key))
            {
                Console.WriteLine($"'{entry.Key}' : '{result.CharacterCounts[entry.Key]}' ");
            }
        }

        private static void DisplayWordCount(Result result)
        {
            foreach (var entry in result.WordCounts.OrderBy(entry => entry.Key))
            {
                Console.WriteLine($"'{entry.Key}' : '{result.WordCounts[entry.Key]}' ");
            }
        }
    }
}
