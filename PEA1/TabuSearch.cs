using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEA1
{
    class TabuSearch : Algorithm, IAlgorithm
    {
        double givenTime;
        string neighbourType;
        bool diversification;
        int breakCase;
        int[,] tabuList;
        int cadence;

        public TabuSearch(FileHolder fileHolder, double givenTime, string neighbourType, bool diversification=false) : base(fileHolder)
        {
            this.givenTime = givenTime;
            this.neighbourType = neighbourType;
            this.diversification = diversification;
            tabuList = new int[cityAmmount, cityAmmount];
            cadence = Convert.ToInt32(Math.Sqrt(cityAmmount));
            breakCase = 20;
        }

        public void FindBestSolution()
        {
            bestPath = InitializeFirstPath();
            bestCost = PathCost(bestPath);
            int[] currentPath = (int[])bestPath.Clone();
            int currentCost = bestCost;
            int currentCase = 0;
            DateTime start = DateTime.Now;
            TimeSpan ts = DateTime.Now - start;
            int previousCost;

            while (ts.TotalMilliseconds < givenTime)
            {
                int bestI = 0;
                int bestJ = 0;

                previousCost = currentCost;
                var tempCost = PathCost(NextPath(currentPath, neighbourType));
                
                for (int i = 1; i < cityAmmount; i++)
                {
                    for(int j = i+1; j < cityAmmount; j++)
                    {
                        int[] nextPath = NextPath(currentPath, neighbourType, i, j);
                        int nextCost = PathCost(nextPath);

                        if(nextCost < bestCost || nextCost < tempCost && tabuList[i, j] == 0)
                        {
                            tempCost = nextCost;
                            bestI = i;
                            bestJ = j;
                        }
                    }
                }

                currentPath = NextPath(currentPath, neighbourType, bestI, bestJ);
                currentCost = PathCost(currentPath);

                tabuList[bestI, bestJ] = cadence;
                DecrementTabluList();

                if(currentCost < bestCost)
                {
                    bestCost = currentCost;
                    bestPath = (int[])currentPath.Clone();
                    currentCase = 0;
                }
                else if(diversification && currentCost >= previousCost)
                {
                    currentCase++;
                    if(currentCase >= breakCase)
                    {
                        tabuList = new int[cityAmmount, cityAmmount];
                        currentPath = InitializeFirstPath();
                        currentCost = PathCost(currentPath);
                    }
                }


                ts = DateTime.Now - start;
            }

        }

        void DecrementTabluList()
        {
            for(int i = 0; i < cityAmmount; i++)
            {
                for (int j = 0; j < cityAmmount; j++)
                {
                    if(tabuList[i, j] > 0)
                    {
                        tabuList[i, j]--;
                    }
                }
            }
        }


    }
}
