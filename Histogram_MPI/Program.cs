using Histogram_MPI;
using MPI;

class Program
{
    static void Main(string[] args)
    {
        using (new MPI.Environment(ref args))
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify file to analyze as command line argument!");
                return;
            }

            Intracommunicator comm = Communicator.world;

            string textPart;
            if (comm.Rank == 0)
            {
                // Master
                string filename = args[0];
                Console.WriteLine($"Analyzing: {filename}");

                string text = File.ReadAllText(filename);
                string[] parts = TextSplitter.SplitIntoChunks(text, comm.Size);
                textPart = comm.Scatter(parts);
            }
            else
            {
                // Worker
                textPart = comm.Scatter<string>(0);
            }

            Result result = AnalyzeTextPart(textPart);
            Result[] results = comm.Gather(result, 0);

            if (comm.Rank == 0)
            {
                // Master
                Result finalResult = CombineResults(results);
                HistogramDisplay.Display(finalResult);
            }
        }

    }
    private static Result AnalyzeTextPart(string textPart)
    {
        TextCounter counter = new TextCounter();
        return counter.Count(textPart);
    }

    private static Result CombineResults(Result[] results)
    {
        Dictionary<char, int> characterCounts = new();
        Dictionary<string, int> wordCounts = new();

        characterCounts = results.SelectMany(r => r.CharacterCounts)
                                      .GroupBy(o => o.Key)
                                      .ToDictionary(o => o.Key, o => o.Sum(v => v.Value));
        wordCounts = results.SelectMany(r => r.WordCounts)
                                      .GroupBy(o => o.Key)
                                      .ToDictionary(o => o.Key, o => o.Sum(v => v.Value));

        return new Result(characterCounts, wordCounts);
    }
}