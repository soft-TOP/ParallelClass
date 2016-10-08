using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelClass
{
    class Program
    {
        static void Main(string[] args)
        {
            String ausgabe = "\"IsCompleted\": {0} | \"LowestBreakIteration\": {1}";

            Console.WriteLine("loopstate.Stop()");
            ParallelLoopResult result;
            result = Parallel.
            For(0, 10000, (Int32 i, ParallelLoopState loopstate) =>
            {
                if (i == 5000)
                {
                    Console.WriteLine("Breaking loop");
                    loopstate.Stop();
                }
                return;
            });
            Console.WriteLine(ausgabe, result.IsCompleted.ToString(), result.LowestBreakIteration.ToString());


            Console.WriteLine(String.Empty.PadRight(40, '-'));
            Console.WriteLine("loopstate.Break()");
            result = Parallel.
                For(0, 10000, (Int32 i, ParallelLoopState loopstate) =>
                {
                    if (i == 5000)
                    {
                        Console.WriteLine("Breaking loop");
                        loopstate.Break();
                    }
                    return;
                });
            Console.WriteLine(ausgabe, result.IsCompleted.ToString(), result.LowestBreakIteration.ToString());


            Console.WriteLine(String.Empty.PadRight(40, '-'));
            Console.WriteLine("keine Unterbrechung");
            result = Parallel.
               For(0, 1000, (Int32 i, ParallelLoopState loopstate) =>
               {
                   if (i == 5000)
                   {
                       Console.WriteLine("Breaking loop");
                       loopstate.Break();
                   }
                   return;
               });
            Console.WriteLine(ausgabe, result.IsCompleted.ToString(), result.LowestBreakIteration.ToString());

            Console.ReadLine();
        }
    }
}
