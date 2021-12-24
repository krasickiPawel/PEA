using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEA1
{
    class SimulatedAnnealing : Algorithm, IAlgorithm
    {
        double givenTime;
        string neighbourType;
        public SimulatedAnnealing(FileHolder fileHolder, double givenTime, string neighbourType) : base(fileHolder)
        {
            this.givenTime = givenTime;
            this.neighbourType = neighbourType;
        }

        public void FindBestSolution()
        {
            int[] currentPath = InitializeFirstPath();
            int currentCost = PathCost(currentPath);
            bestPath = (int[])currentPath.Clone();
            bestCost = currentCost;
            DateTime start = DateTime.Now;
            TimeSpan ts = DateTime.Now - start;

            double temperature = InitializeTemperature();
            double coolingFactor = 0.99;
            int epoch = cityAmmount * 10;

            while (ts.TotalMilliseconds < givenTime)
            {

                for(int i = 0; i < epoch; i++)
                {
                    int[] nextPath = NextPath(currentPath, neighbourType);
                    int nextCost = PathCost(nextPath);

                    if(nextCost < bestCost)
                    {
                        bestPath = (int[])nextPath.Clone();
                        currentPath = (int[])nextPath.Clone();
                        bestCost = currentCost = nextCost;
                    }

                    else if (nextCost < currentCost || Math.Exp(-(nextCost - bestCost) / temperature) > random.NextDouble())
                    {
                        currentPath = (int[])nextPath.Clone();
                        currentCost = nextCost;
                    }
                }

                temperature *= coolingFactor;
                ts = DateTime.Now - start;

            }
        }

        double InitializeTemperature()
        {
            double temperature = 0;

            for(int i = 0; i < 10; i++)
            {
                temperature += Math.Abs(PathCost(InitializeFirstPath()) - PathCost(InitializeFirstPath()));
            }

            temperature /= 10;

            return temperature * 3;
        }
    }
}
