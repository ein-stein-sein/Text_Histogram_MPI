using Histogram_Sequential;
using MPI;


class Program
{
    static void Main(string[] args)
    {
        using (new MPI.Environment(ref args))
        {

            Intracommunicator comm = Communicator.world;

            // read the file
            // split file into list of n lists, where n is the comm.size - 1

            if (comm.Rank == 0)
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Please specify file to analyze!");
                    return;
                }
                string filename = args[0];
                Console.WriteLine($"Analyzing: {filename}");

                string text = File.ReadAllText(filename);

                string[] parts = HelperFunctions.SplitIntoChunks(text, comm.Size);

                for (int i = 1; i < comm.Size; i++)
                {
                    comm.Send(parts[i], i, 1);
                    Console.WriteLine($"Sent text part to process {i}.");
                    //Console.WriteLine($"Sample: {parts[i].Substring(0, 30)}...");
                }

                HistogramDisplay histogramDisplay = new HistogramDisplay();

                Result result = new(new Dictionary<char, int>(), new Dictionary<string, int>());
                for (int i = 1; i < comm.Size; i++)
                {
                    Result newResult = comm.Receive<Result>(i, 0);
                    result.combineResults(newResult);
                    Console.WriteLine($"Sent text part to process {i}.");
                }

                histogramDisplay.Display(result);

            }

            else
            {
                if (args.Length == 0)
                {
                    return;
                }
                Console.WriteLine($"Process {comm.Rank} started.");
                string text = "";
                comm.Receive(0, 1, out text);
                Console.WriteLine($"Process {comm.Rank} received it´s text part.");

                ITextCounter counter = new TextCounter();
                Result result = counter.Count(text);
                Console.WriteLine($"Process {comm.Rank} has {result.CharacterCounts.Count()} character counts");
                Console.WriteLine($"Process {comm.Rank} has {result.WordCounts.Count()} word counts");

                comm.Send(result, 0, 0);
            }
        }
    }
}