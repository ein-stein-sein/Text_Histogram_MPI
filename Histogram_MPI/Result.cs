namespace Histogram_MPI
{

    /// <summary>
    /// Holds the result of counting the characters and words.
    /// </summary>
    [Serializable]
    public record Result
    {
        /// <summary>
        /// The count of each character.
        /// </summary>
        public Dictionary<char, int> CharacterCounts { get; set; }

        /// <summary>
        /// The count of each word.
        /// </summary>
        public Dictionary<string, int> WordCounts { get; set; }

        /// <summary>
        /// Constructs a new <see cref="Result"/> of counting the characters and words.
        /// </summary>
        /// <param name="characterCounts">The character counts</param>
        /// <param name="wordCounts">The word counts</param>
        public Result(Dictionary<char, int> characterCounts, Dictionary<string, int> wordCounts)
        {
            this.WordCounts = wordCounts;
            this.CharacterCounts = characterCounts;
        }

    }

}
