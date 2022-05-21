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
        public void combineResults(Result result)
        {
            this.WordCounts = this.WordCounts.Concat(result.WordCounts)
                                      .GroupBy(o => o.Key)
                                      .ToDictionary(o => o.Key, o => o.Sum(v => v.Value));
            this.CharacterCounts = this.CharacterCounts.Concat(result.CharacterCounts)
                                      .GroupBy(o => o.Key)
                                      .ToDictionary(o => o.Key, o => o.Sum(v => v.Value));
        }

    }
}
