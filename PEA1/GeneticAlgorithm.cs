using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PEA1
{
    class GeneticAlgorithm : Algorithm, IAlgorithm
    {
        private double givenTime;
        private string mutationMethod;
        private string crossMethod;
        private int populationSize;
        private double mutationProbability;
        private double crossProbability;
        private int[][] population;
        private int[] populationCosts;
        private int currentBestCost;
        private int[] currentBestPath;

        public GeneticAlgorithm(FileHolder fileHolder, double givenTime, string mutationMethod, 
            string crossMethod, int populationSize, double mutationProbability,
            double crossProbability) : base(fileHolder)
        {
            this.givenTime = givenTime;
            this.mutationMethod = mutationMethod;
            this.crossMethod = crossMethod;
            this.populationSize = populationSize;
            this.mutationProbability = mutationProbability;
            this.crossProbability = crossProbability;
            bestCost = int.MaxValue;
            currentBestCost = int.MaxValue;
        }


        public void FindBestSolution()
        {
            population = FirstPopulation();
            populationCosts = new int[populationSize];
            CalculatePopulationCosts();
            SaveBestSolution();

            DateTime start = DateTime.Now;
            TimeSpan ts = DateTime.Now - start;

            while (ts.TotalMilliseconds < givenTime)        //dopoki czas sie nie skonczyl
            {
                var selectedParents = ParentSelection();    //wybierac 2 i brac ktory lepszy, zwraca indeksy wybranych
                var children = Crossower(selectedParents);  //zwraca nowa populacje
                var mutatedChilds = Mutation(children);     //mutuje dla kazdego z osobna

                UpdatePopulation(mutatedChilds);            //zamienia obecna populacje na nowa powstala

                CalculatePopulationCosts();                 //liczy dlugosci aktualnych tras w populacji
                SaveBestSolution();                         //sprawdza czy nie ma lepszej sciezki niz najlepsza dotychczas

                ts = DateTime.Now - start;                  //kontrola uplywajacego czasu
            }

        }


        private int[][] FirstPopulation()
        {
            int[][] firstPopulationTab = new int[populationSize][];

            for (int i = 0; i < populationSize; i++)
                firstPopulationTab[i] = InitializeFirstPath();

            return firstPopulationTab;
        }

        private void CalculatePopulationCosts()
        {
            for (int i = 0; i < populationSize; i++)
                populationCosts[i] = PathCost(population[i]); 
        }

        private void SaveBestSolution()
        {
            for (int i = 0; i < populationSize; i++)
                if (populationCosts[i] < currentBestCost)
                {
                    currentBestCost = populationCosts[i];
                    currentBestPath = population[i];
                }
            if(currentBestCost < bestCost)
            {
                bestCost = currentBestCost;
                bestPath = currentBestPath;
            }
        }

        private int[] ParentSelection()
        {
            return TournamentSelection();
        }

        private int[] TournamentSelection()
        {
            var parents = new int[populationSize];

            for (int i = 0; i < populationSize; i++)
            {
                int[] randomIndexes = TwoRandomIndexes(0, populationSize);
                int firstRandomIndex = randomIndexes[0];
                int secondRandomIndex = randomIndexes[1];

                if (populationCosts[firstRandomIndex] < populationCosts[secondRandomIndex])
                    parents[i] = firstRandomIndex;
                else 
                    parents[i] = secondRandomIndex;

            }

            return parents;
        }

        private int[][] Crossower(int[] parents)    //takes parentsIndexTab
        {
            int[][] children = new int[populationSize][];

            for (int i = 0; i < populationSize - 1; i++)
            {
                int[] child;
                if (crossProbability > random.NextDouble())
                    if (crossMethod == "OX")
                        child = OX(population[parents[i]], population[parents[i + 1]]);
                    else
                        child = PMX(population[parents[i]], population[parents[i + 1]]);
                else
                    child = population[parents[i]];

                children[i] = child;
            }
            
            int[] lastChild;
            if (crossProbability > random.NextDouble())
                if (crossMethod == "OX")
                    lastChild = OX(population[parents[populationSize - 1]], population[parents[0]]);
                else
                    lastChild = PMX(population[parents[populationSize - 1]], population[parents[0]]);
            else
                lastChild = population[parents[populationSize - 1]];

            children[populationSize - 1] = lastChild;

            return children;
        }

        private int[] PMX(int[] par1, int[] par2)
        {
            var parent1 = par1.ToList();
            parent1.RemoveAt(0);
            var parent2 = par2.ToList();
            parent2.RemoveAt(0);

            var child = new int[cityAmmount - 1];
            int[] randomIndexes = TwoRandomIndexes(1, cityAmmount - 1); //dla 20 miast najwiekszy secondIndex to 18
            int firstRandomIndex = randomIndexes[0];
            int secondRandomIndex = randomIndexes[1];

            void Recursion(int index, int constantI)
            {
                var id = parent2.IndexOf(parent1[index]);
                if (id < firstRandomIndex || id >= secondRandomIndex)
                    child[id] = parent2[constantI];
                else
                    Recursion(id, constantI);
            }

            for (int i = firstRandomIndex; i < secondRandomIndex; i++)
                child[i] = parent1[i];

            for (int i = firstRandomIndex; i < secondRandomIndex; i++)
            {
                if (child.Contains(parent2[i])) continue;
                Recursion(i, i);
            }

            for (int i = 0; i < cityAmmount - 1; i++)
            {
                if (child[i] > 0) continue;
                else child[i] = parent2[i];
            }
            
            var fullChild = new int[cityAmmount];
            fullChild[0] = 0;

            for (int i = 1; i < cityAmmount; i++)
                fullChild[i] = child[i - 1];

            return fullChild;
        }

        private int[] OX(int[] par1, int[] par2)
        {
            var parent1 = new int[cityAmmount - 1];
            var parent2 = new int[cityAmmount - 1];
            for (int i = 0; i< cityAmmount - 1; i++)
            {
                parent1[i] = par1[i + 1];
                parent2[i] = par2[i + 1];
            }

            var child = new int[cityAmmount - 1];
            int[] randomIndexes = TwoRandomIndexes(1, cityAmmount - 1);
            int firstRandomIndex = randomIndexes[0];
            int secondRandomIndex = randomIndexes[1];
            List<int> copiedValues = new List<int>();
            int index = secondRandomIndex;
            int j = secondRandomIndex;

            for (int i = firstRandomIndex; i < secondRandomIndex; i++)
            {
                child[i] = parent1[i];
                copiedValues.Add(parent1[i]);
            }
            
            while (index != firstRandomIndex)
            {
                if (index >= cityAmmount - 1) index = 0;
                if (j >= cityAmmount - 1) j = 0;

                if (!copiedValues.Contains(parent2[j]))
                {
                    child[index] = parent2[j];
                    index++;
                }

                j++;
            }
            
            var fullChild = new int[cityAmmount];
            fullChild[0] = 0;

            for (int i = 1; i < cityAmmount; i++)
                fullChild[i] = child[i - 1];

            return fullChild;
        }

        private int[][] Mutation(int[][] children)
        {
            for (int i = 0; i < populationSize; i++)
                if (mutationProbability > random.NextDouble())
                    children[i] = Mutate(children[i]);

            return children;
        }

        private int[] Mutate(int[] child)
        {
            return NextPath(child, mutationMethod);
        }

        private void UpdatePopulation(int[][] mutatedChilds)
        {
            population = mutatedChilds;
        }
    }
}
