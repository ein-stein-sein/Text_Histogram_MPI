namespace Histogram_Sequential
{
    public class TextCounter : ITextCounter
    {
        public Result Count(string text)
        {
            CharacterCounter characterCounter = new();
            WordCounter wordCounter = new();

            foreach (char a in text)
            {
                characterCounter.Process(a);
                wordCounter.Process(a);
            }

            return new Result(characterCounter.GetCharacterCounts(), wordCounter.GetWordCounts());
        }
    }
}
