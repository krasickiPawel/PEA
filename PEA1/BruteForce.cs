using System;
using System.Collections.Generic;
using System.Text;

namespace PEA1
{
    class BruteForce : Algorithm, IAlgorithm
    {
        //bool[] visited;

        public BruteForce(FileHolder fileHolder) : base(fileHolder)
        {
        }
        public void FindBestSolution()
        {
            int[] currentPath = new int[cityAmmount-1];     //tablica do przechowywania aktualnie przemierzanej sciezki (z pominieciem miasta startowego)

            for (int i = 1; i < cityAmmount; i++)    //wpisanie pierwszej trasy i ustawienie jej jako najlepszej
            {
                currentPath[i-1] = i;
                bestPath[i-1] = i; //usunac to i przypisac za forem
            }
            bestCost = PathCost(bestPath);  //koszt pierwszej sciezki jako najlepszy

            //sprawdzanie kolejnych tras czy nie sa lepsze             
            while (IsNextPermutation(currentPath))                  //styl z C++ 
            {             
                int currentCost = PathCost(currentPath);   //currentPath jest zmieniane w IsNextPermutation          
                if(currentCost < bestCost)             
                {               
                    bestCost = currentCost;           
                    for(int i=0; i<cityAmmount-1; i++)          
                    {
                        bestPath[i] = currentPath[i];    //zapisanie nowej najlepszej sciezki            
                    }                  
                }              
            }
          
        }

                    
        bool IsNextPermutation<T>(IList<T> currentPath) where T : IComparable   //przerobiona funkcja next_permutation() z C++ (bo nie ma jej domyslnie w C#)
        {
            if (currentPath.Count < 2) return false;   //dla 1 elementu nie ma permutacji
            var k = currentPath.Count - 2;
            
            while (k >= 0 && currentPath[k].CompareTo(currentPath[k + 1]) >= 0) k--;
            if (k < 0) return false;

            var l = currentPath.Count - 1;

            while (l > k && currentPath[l].CompareTo(currentPath[k]) <= 0) l--;

            var tmp = currentPath[k];
            currentPath[k] = currentPath[l];    //zamiana elementow miejscami (inna permutacja)
            currentPath[l] = tmp;

            var i = k + 1;
            var j = currentPath.Count - 1;

            while (i < j)
            {
                tmp = currentPath[i];
                currentPath[i] = currentPath[j];
                currentPath[j] = tmp;
                i++;
                j--;
            }
            
            return true; 
        }

        new int PathCost(int[] path)  //liczenie kosztu sciezki
        {
            int cost = 0;
            cost += cityDistances[0, path[0]];  //koszt od miasta startowego do pierwszego w sciezce (nie analizuje miasta startowego w BF i dzieki temu zlozonosc spada do O((n-1)!)
            for (int i = 0; i < cityAmmount - 2; i++)
            {
                cost += cityDistances[path[i], path[i + 1]];    //dodawanie kosztow miedzy kolejnymi miastami
            }
            cost += cityDistances[path[cityAmmount - 2], 0];    //dodanie kosztu powrotu do miasta startowego (brzydko wygladajace -2 spowodowane stalym punktem startu)
            return cost;
        }

        public new int[] GetBestPath()  //zwrocenie najlepszej sciezki - nadpisana metoda z Algorithm bo tutaj trzeba dopisac miasto startowe do sciezki
        {
            var finalPath = new int[cityAmmount];
            finalPath[0] = 0;
            for (int i = 1; i < cityAmmount; i++)
            {
                finalPath[i] = bestPath[i - 1];
            }
            return finalPath;
        }

    }
}
