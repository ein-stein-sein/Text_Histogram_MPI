namespace Histogram_Sequential
{
    [Serializable]
    public struct Result
    {

        public Dictionary<char, int> CharacterCounts { get; set; }

        public Dictionary<string, int> WordCounts { get; set; }

        public Result(Dictionary<char, int> characterCounts, Dictionary<string, int> wordCounts)
        {
            this.WordCounts = wordCounts;
            this.CharacterCounts = characterCounts;
        }

    }
}
