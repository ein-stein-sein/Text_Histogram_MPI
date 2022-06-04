using Histogram_Sequential;
using MPI;
using System.Diagnostics;

namespace Histogram_MPI
{
    /// <summary>
    /// Program of the master.
    /// </summary>
    internal class MasterProgram
    {
        /// <summary>
        /// Runs the program of the master.
        /// </summary>
        /// <param name="args">the command line arguments</param>
        /// <param name="comm">the MPI intracommunicator</param>
        public static void Run(Stopwatch stopWatch, string[] args, Intracommunicator comm)
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

            int workerCount = comm.Size - 1;
            string[] parts = HelperFunctions.SplitIntoChunks(text, workerCount);

            for (int workerProcess = 1; workerProcess <= workerCount; workerProcess++)
            {
                comm.Send(parts[workerProcess - 1], workerProcess, 1);
                Console.WriteLine($"Sent text part with size {parts[workerProcess - 1].Length} to process {workerProcess}.");
                //Console.WriteLine($"Sample: {parts[i].Substring(0, 30)}...");
            }

            Result result = new(new Dictionary<char, int>(), new Dictionary<string, int>());
            for (int workerProcess = 1; workerProcess <= workerCount; workerProcess++)
            {
                Result newResult = comm.Receive<Result>(workerProcess, 0);
                result.CombineResults(newResult);
            }
            stopWatch.Stop();
            Console.WriteLine($"Took {stopWatch.Elapsed.TotalSeconds} seconds");
            HistogramDisplayCsv.Display(result, "characterCount.txt", "wordCount.txt");

        }
    }
}
