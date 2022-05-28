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
            double wtime = Unsafe.MPI_Wtime();
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
                Console.WriteLine($"Sent text part {workerProcess - 1} to process {workerProcess}.");
                //Console.WriteLine($"Sample: {parts[i].Substring(0, 30)}...");
            }

            HistogramDisplay histogramDisplay = new HistogramDisplay();

            Result result = new(new Dictionary<char, int>(), new Dictionary<string, int>());
            for (int workerProcess = 1; workerProcess <= workerCount; workerProcess++)
            {
                Result newResult = comm.Receive<Result>(workerProcess, 0);
                result.combineResults(newResult);
            }
            double wtime2 = Unsafe.MPI_Wtime();
            Console.WriteLine($"Took {wtime2 - wtime} seconds");
            histogramDisplay.Display(result);

        }
    }
}
