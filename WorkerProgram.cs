using Histogram_Sequential;
using MPI;

namespace Histogram_MPI
{
    internal class WorkerProgram
    {
        public static void Run(string[] args, Intracommunicator comm)
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
