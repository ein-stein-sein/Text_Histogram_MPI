using Histogram_MPI;
using MPI;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Stopwatch stopWatch = Stopwatch.StartNew();
        using (new MPI.Environment(ref args))
        {

            Intracommunicator comm = Communicator.world;

            if (comm.Rank == 0)
            {
                MasterProgram.Run(stopWatch, args, comm);
            }
            else
            {
                WorkerProgram.Run(args, comm);
            }
        }
    }
}