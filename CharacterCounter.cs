namespace Histogram_Sequential
{
    internal class CharacterCounter
    {
        readonly Dictionary<char, int> characterCounts = new Dictionary<char, int>();

        public void Process(char c)
        {
            if (characterCounts.ContainsKey(c))
            {
                characterCounts[c] += 1;
            }
            else
            {
                characterCounts[c] = 1;
            }
        }

        public Dictionary<char, int> GetCharacterCounts()
        {
            return characterCounts;
        }

    }
}
