using Histogram_MPI;
using MPI;


class Program
{
    static void Main(string[] args)
    {
        using (new MPI.Environment(ref args))
        {

            Intracommunicator comm = Communicator.world;

            if (comm.Rank == 0)
            {
                MasterProgram.Run(args, comm);
            }
            else
            {
                WorkerProgram.Run(args, comm);
            }
        }
    }
}