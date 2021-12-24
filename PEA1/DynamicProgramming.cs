using System;
using System.Collections.Generic;
using System.Text;

namespace PEA1
{
    class DynamicProgramming : Algorithm, IAlgorithm
    {
        int allVisited; //do przechowania maski bitowej ktora mowi ze wszystkie miasta zostaly odwiedzone
        int[,] costMemo;    //pomocnicza tablica do zapisu kosztow przejsc
        public DynamicProgramming(FileHolder fileHolder) : base(fileHolder)
        {
            allVisited = (1 << cityAmmount) - 1;   //maska bitowa o rozmiarze ilosci miast ktore sa do odwiedzenia i odjete 1 tak aby z 1000.... zamienilo sie na same 111... 
            costMemo = new int[1 << cityAmmount, cityAmmount];  //dla kazdego miasta mapa bitowa na ktorej sa zaznaczane koszty
        }

        public void FindBestSolution()
        {
            for(int i=0; i < 1 << cityAmmount; i++) //wstepne przygotowanie tablicy kosztow
            {
                for(int j=0; j<cityAmmount; j++)
                {
                    costMemo[i, j] = int.MaxValue;
                }
            }
            int startingCity = 0;   //zaczynamy z pierwszego, okreslonego miasta o indeksie 0
            int startingMask = 1 << 0;  //maska mowi ze pierwsze miasto jest odwiedzone (to z ktorego ruszamy)
            bestCost = FindBestCost(startingMask, startingCity);
            bestPath = FindBestPath(startingMask, startingCity);

        }
        int FindBestCost(int mask, int position)    // position = miasto, ktore chcemy przeanalizowac (jego mozliwe sciezki dalej)
        {
            int cost = int.MaxValue;

            if (mask == allVisited) // jesli przejdziemy wszystkie miasta w danej sciezce
            {
                costMemo[mask, position] = cityDistances[position, 0];
                return costMemo[mask, position];  //zwracana jest odleglosc od ostatniego miasta do poczatkowego (pozniej dodawana do sciezki)
            }

            if(costMemo[mask, position] != int.MaxValue)  //zaleta progamowania dynamicznego - jak juz jakas sciezke obliczylismy to wynik mamy zapisany
            {
                return costMemo[mask, position];
            }

            //sprawdzana jest sciezka od miasta startowego do kazdego kolejnego mozliwego + pozostaly koszt jaki sie wiaze z wyborem tego miasta
            for(int city=0; city < cityAmmount; city++) //dla kazdego miasta ze wszystkich dostepnych miast
            {
                if((mask & (1<<city)) == 0) //jesli miasto jest jeszcze nieodwiedzone (tyczy sie to danej sciezki)
                {
                    int newCost = cityDistances[position, city] + FindBestCost(mask | (1<<city), city); //obliczamy koszt sciezki (rekurencyjnie)
                    if (newCost < cost)
                    {
                        cost = newCost;
                    }
                        
                }
            }

            costMemo[mask, position] = cost;    //przypisanie aktualnie najlepszego kosztu do tablicy kosztow
            return costMemo[mask, position];
        }

        int[] FindBestPath(int currentMask, int startingCity)  //odnalezienie sciezki dla ktorej jest najmnniejszy koszt
        {
            int[] visitedPath = new int[cityAmmount];
            visitedPath[0] = startingCity;

            for(int c = 1; c < cityAmmount; c++)    //c ==> counter, licznik sprawdzajacy na ktorej pozycji w tablicy powinnismy zapisac miasto
            {
                int currentBestCost = int.MaxValue;

                for (int i=0; i<cityAmmount; i++)
                {
                    int set = (currentMask | 1 << i);       //sprawdzanie po kolei kazdego mozliwego miasta do ktorego mozemy pojsc
                    if (set != currentMask)                 //nie rozpatrujemy miast ktore juz odwiedzilismy
                    {
                        //sprawdzanie dlugosci sciezki dla kazdego miasta do ktorego mozna pojsc z obecnej sciezki (maski bitowej set)
                        int tempCost = costMemo[set, i] + cityDistances[visitedPath[c - 1],i] + ExistingPathCost(visitedPath, c);

                        if (tempCost < currentBestCost)     //znajdowanie najkrotszej sciezki
                        {
                            currentBestCost = tempCost;     
                            visitedPath[c] = i;             //zapisanie miasta do ktorego pojscie daje najlepsza sciezke
                        }
                    }

                }
                currentMask = (currentMask | (1 << visitedPath[c]));        //zmiana maski bitowej na taka z uwzglednionym miastem do ktorego pojscie bylo najlepsze

            }

            return visitedPath;
        }

        int ExistingPathCost(int[] visitedPath, int counter)
        {
            int cost = 0;

            for (int i = 0; i < counter - 1; i++)
            {
                cost += cityDistances[visitedPath[i], visitedPath[i+1]];
            }

            return cost;
        }

    }
}
