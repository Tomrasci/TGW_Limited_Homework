using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TGW_Homework
{
    internal class LaneSelection
    {
        public LaneSelection()
        {

        }

        public int[] FillEmptyArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }

        public void RoundRobinAlgorithm(int destinations, int conLoads, int failurePercent, int loads)
        {
            int[] destinationArray = new int[destinations + 1];
            FillEmptyArray(destinationArray, destinations);
            int neededIterations = loads / conLoads;
            int destinationNumber = 0;
            int lastLoad = 0;
            int failureLoads = conLoads * failurePercent / 100;
            if (loads % conLoads != 0)
            {
                neededIterations++;
                lastLoad = loads % conLoads;
            }
            for (int i = 0; i < neededIterations; i++)
            {
                if (destinationNumber < destinations) {
                    destinationNumber++;
                }
                else
                {
                    destinationNumber = 1;
                }

                if (lastLoad == 0 || (lastLoad > 0 && i != neededIterations - 1))
                {
                    destinationArray[0] = destinationArray[0] + failureLoads;
                    destinationArray[destinationNumber] = destinationArray[destinationNumber] + conLoads - failureLoads;

                }

                else if (lastLoad > 0 && i == neededIterations - 1)
                {
                    int failure = lastLoad * failurePercent / 100;
                    destinationArray[0] = destinationArray[0] + failure;
                    destinationArray[destinationNumber] = destinationArray[destinationNumber] + lastLoad - failure;
                }
             
            }

            for (int i = 0;i < destinationArray.Length; i++)
            {
                Console.WriteLine("Destination " + i);
                Console.WriteLine(destinationArray[i]);
            }

        }

        public void RandomAlgorithm(int destinations, int conLoads, int failurePercent, int loads)
        {
            int[] destinationArray = new int[destinations + 1];
            FillEmptyArray(destinationArray, destinations);
            int neededIterations = loads / conLoads;
            int destinationNumber;
            int lastLoad = 0;
            int failureLoads = conLoads * failurePercent / 100;
            Random rnd = new Random();
            if (loads % conLoads != 0)
            {
                neededIterations++;
                lastLoad = loads % conLoads;
            }
            for (int i = 0; i < neededIterations; i++)
            {
                int number = rnd.Next(1, destinations + 1);
                destinationNumber = number;

                if (lastLoad == 0 || (lastLoad > 0 && i != neededIterations - 1))
                {
                    destinationArray[0] = destinationArray[0] + failureLoads;
                    destinationArray[destinationNumber] = destinationArray[destinationNumber] + conLoads - failureLoads;

                }

                else if (lastLoad > 0 && i == neededIterations - 1)
                {
                    int failure = lastLoad * failurePercent / 100;
                    destinationArray[0] = destinationArray[0] + failure;
                    destinationArray[destinationNumber] = destinationArray[destinationNumber] + lastLoad - failure;
                }

            }

            for (int i = 0; i < destinationArray.Length; i++)
            {
                Console.WriteLine("Destination " + i);
                Console.WriteLine(destinationArray[i]);
            }

        }

    }
}
