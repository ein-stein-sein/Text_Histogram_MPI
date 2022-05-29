using MPI;

namespace Histogram_MPI
{
    /// <summary>
    /// Program of the worker.
    /// </summary>
    internal class WorkerProgram
    {
        /// <summary>
        /// Runs the program of the worker.
        /// </summary>
        /// <param name="args">the command line arguments</param>
        /// <param name="comm">the MPI intracommunicator</param>
        public static void Run(string[] args, Intracommunicator comm)
        {
            if (args.Length == 0)
            {
                return;
            }
            Console.WriteLine($"Process {comm.Rank} started.");
            comm.Receive(0, 1, out string text);
            Console.WriteLine($"Process {comm.Rank} received it´s text part.");

            TextCounter counter = new TextCounter();
            Result result = counter.Count(text);
            Console.WriteLine($"Process {comm.Rank} has {result.CharacterCounts.Count} character counts");
            Console.WriteLine($"Process {comm.Rank} has {result.WordCounts.Count} word counts");

            comm.Send(result, 0, 0);
        }
    }
}
