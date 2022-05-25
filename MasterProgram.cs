using Histogram_Sequential;
using MPI;

namespace Histogram_MPI
{
    internal class MasterProgram
    {
        public static void Run(string[] args, Intracommunicator comm)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please specify file to analyze!");
                return;
            }

            // read the file
            // split file into list of n lists, where n is the comm.size - 1
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
    }
}
