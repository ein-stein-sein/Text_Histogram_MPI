namespace Histogram_MPI
{
    /// <summary>
    /// Class for counting all characters in a given text.
    /// The counting is case-sensitive.
    /// </summary>
    internal class CharacterCounter
    {
        /// <summary>
        /// The counts for each character.
        /// </summary>
        public Dictionary<char, int> CharacterCounts { get; } = new();

        /// <summary>
        /// Processes a single character in order to count the characters.
        /// </summary>
        /// <param name="c">The character to process</param>
        public void Process(char c)
        {
            if (CharacterCounts.ContainsKey(c))
            {
                CharacterCounts[c] += 1;
            }
            else
            {
                CharacterCounts[c] = 1;
            }
        }

    }
}
