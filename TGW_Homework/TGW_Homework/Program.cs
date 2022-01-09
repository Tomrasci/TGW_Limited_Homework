using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Homework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of destinations");
            int destinations = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter 1 for Round Robin algorithm and 2 for Random algorithm");
            int algorithmSelection = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the number of consecutive loads");
            int conLoads = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the percentage of failure");
            int failurePercent = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the total number of loads");
            int loads = Convert.ToInt32(Console.ReadLine());

            LaneSelection selection = new LaneSelection();
            if (algorithmSelection == 1)
            {
                selection.RoundRobinAlgorithm(destinations, conLoads, failurePercent, loads);
            }
            else if (algorithmSelection == 2)
            {
                selection.RandomAlgorithm(destinations, conLoads, failurePercent, loads);
            }



        }
    }
}
