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
        /// <summary>
        /// Method to make destination array values 0 at first
        /// </summary>
        /// <param name="arr">destination values array</param>
        /// <param name="n">array length</param>
        /// <returns>destination values array with 0 as initial values</returns>
        public int[] FillEmptyArray(int[] arr, int n)
        {
            for (int i = 0; i < n; i++)
            {
                arr[i] = 0;
            }
            return arr;
        }
        /// <summary>
        /// Round robin algorithm which takes destionations, conLoads, failurePercent and loads and uses the classic RoundRobin
        /// method to keep dividing loads for each destination one after another
        /// </summary>
        /// <param name="destinations">destination number</param>
        /// <param name="conLoads">consecutive load number</param>
        /// <param name="failurePercent">percentage of failure for divert loads</param>
        /// <param name="loads">total loads</param>
        public void RoundRobinAlgorithm(int destinations, int conLoads, int failurePercent, int loads)
        {
            //Destination values Array to keep track of the values, also calculations of neededIterations and
            // failureLoads count, aswell as whether there is a lastLoad which is less than given conLoad number
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
            //Firstly check according to the destinations whether they must start from 1 again or go till last destination
            for (int i = 0; i < neededIterations; i++)
            {
                if (destinationNumber < destinations) {
                    destinationNumber++;
                }
                else
                {
                    destinationNumber = 1;
                }

                //Then check and update values of destinations according to conLoads and failurePercent
                //And also check whether lastLoad exist which is the last iteration of a not full consecutive load

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
            PrintPercentages(destinationArray, loads);

        }
        /// <summary>
        /// Random algorithm which takes destionations, conLoads, failurePercent and loads and divides loads using a random
        /// number generator with same percent for each destination
        /// </summary>
        /// <param name="destinations">destination number</param>
        /// <param name="conLoads">consecutive load number</param>
        /// <param name="failurePercent">percentage of failure for divert loads</param>
        /// <param name="loads">total loads</param>
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

            PrintPercentages(destinationArray, loads);

        }
        /// <summary>
        /// Print method to print destinations and their percentages
        /// </summary>
        /// <param name="destinationArray">Destination values array</param>
        /// <param name="loads">Total loads</param>
        public void PrintPercentages(int[] destinationArray, int loads)
        {
            for (int i = 0; i < destinationArray.Length; i++)
            {
                Console.WriteLine("Destination " + i);
                double percentage = Convert.ToDouble(destinationArray[i]) / loads * 100;
                Console.WriteLine(percentage +"%");
            }

        }

    }
}
