using System;
using System.Collections.Generic;
using System.Text;

namespace PEA1
{
    class Algorithm
    {
        protected int[] bestPath;
        protected int bestCost;
        protected int cityAmmount;
        protected int[,] cityDistances;
        protected Random random = new Random();

        protected Algorithm(FileHolder fileHolder) //kazdy algorytm uzywa najkrotsza sciezke i najmniejszy koszt, dlatego jest rodzic
        {
            this.cityAmmount = fileHolder.GetCityAmount();
            this.cityDistances = fileHolder.GetCityDistances();
            this.bestPath = new int[fileHolder.GetCityAmount()];
        }

        public int GetBestCost()
        {
            return bestCost;
        }


        public int[] GetBestPath()
        {
            return bestPath;
        }

        protected int PathCost(int[] path)                      //liczenie kosztu sciezki
        {
            int cost = 0;
            for (int i = 0; i < cityAmmount - 1; i++)
            {
                cost += cityDistances[path[i], path[i + 1]];    //dodawanie kosztow miedzy kolejnymi miastami
            }
            cost += cityDistances[path[cityAmmount - 1], 0];    //dodanie kosztu powrotu do miasta startowego 
            return cost;
        }


        protected int[] NextPath(int[] currentPath, string neighbourType, int firstRandomIndex, int secondRandomIndex)
        {
            int[] nextPath = new int[cityAmmount];
            for (int i = 0; i < cityAmmount; i++)
            {
                nextPath[i] = currentPath[i];
            }

            if (neighbourType == "Invert")
            {
                return Invert(nextPath, firstRandomIndex, secondRandomIndex);
            }
            else
            {
                return Swap(nextPath, firstRandomIndex, secondRandomIndex);
            }
        }

        int[] Swap(int[] nextPath, int firstRandomIndex, int secondRandomIndex)
        {
            int temp = nextPath[firstRandomIndex];
            nextPath[firstRandomIndex] = nextPath[secondRandomIndex];
            nextPath[secondRandomIndex] = temp;

            return nextPath;
        }

        int[] Invert(int[] nextPath, int firstRandomIndex, int secondRandomIndex)
        {
            if (firstRandomIndex < secondRandomIndex)
            {
                while (firstRandomIndex < secondRandomIndex)
                {
                    nextPath = Swap(nextPath, firstRandomIndex, secondRandomIndex);
                    firstRandomIndex++;
                    secondRandomIndex--;
                }
            }
            else
            {
                while (firstRandomIndex > secondRandomIndex)
                {
                    nextPath = Swap(nextPath, firstRandomIndex, secondRandomIndex);
                    firstRandomIndex--;
                    secondRandomIndex++;
                }
            }

            return nextPath;
        }

        protected int[] Shuffle(int[] currentPath)
        {
            int[] randomPath = new int[cityAmmount - 1];
            for (int i = 0; i < cityAmmount - 1; i++)
            {
                randomPath[i] = currentPath[i];
            }
            int n = cityAmmount - 1;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                var value = randomPath[k];
                randomPath[k] = randomPath[n];
                randomPath[n] = value;
            }

            return randomPath;
        }

        protected int[] InitializeFirstPath()
        {
            int[] firstPath = new int[cityAmmount - 1];

            for (int i = 1; i < cityAmmount; i++)
            {
                firstPath[i - 1] = i;     //pierwsza permutacja sciezki
            }

            int[] randomPath = Shuffle(firstPath);

            int[] returnPath = new int[cityAmmount];

            returnPath[0] = 0;

            for (int i = 1; i < cityAmmount; i++)
            {
                returnPath[i] = randomPath[i - 1];
            }

            return returnPath;
        }


        protected int[] NextPath(int[] currentPath, string neighbourType)
        {
            int[] randIndexes = TwoRandomIndexes(1, cityAmmount);
            int firstRandomIndex = randIndexes[0];
            int secondRandomIndex = randIndexes[1];

            return NextPath(currentPath, neighbourType, firstRandomIndex, secondRandomIndex);
        }

        protected int[] TwoRandomIndexes(int startPoint, int endPoint)
        {
            int firstRandomIndex = random.Next(startPoint, endPoint);
            int secondRandomIndex = random.Next(startPoint, endPoint);
            while (firstRandomIndex == secondRandomIndex)
                secondRandomIndex = random.Next(startPoint, endPoint);

            if (firstRandomIndex < secondRandomIndex)
                return new int[] { firstRandomIndex, secondRandomIndex };
            else
                return new int[] { secondRandomIndex, firstRandomIndex };
        }
    }
}
