using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace PEA1
{
    class FileReader
    {
        public FileHolder Read(Stream fileStream, List<string> writeList)   //lista przekazywana na potrzeby kontroli poprawnosci
        {
            var fileContent = string.Empty;
            int cityAmmount;
            FileHolder fileHolder = new FileHolder();

            using (StreamReader reader = new StreamReader(fileStream))  //czytanie ze strumienia
            {
                //fileContent = reader.ReadToEnd();
                fileContent = reader.ReadLine();    // odczytanie pierwszej linii ze strumienia
                cityAmmount = Convert.ToInt32(fileContent); //przypisanie pierwszej wartosci jako ilosc miast (rozmiar problemu)

                for(int i = 0; i < cityAmmount; i++)
                {
                    fileContent = reader.ReadLine();    //odczyt kolejnych linii
                    writeList.Add(fileContent);         //i zapisywanie ich w liscie
                }
            }

            fileHolder.SetCityAmount(cityAmmount);  //ustawienie obiektowi fileHolder ilosci miast

            if (cityAmmount > 0)    //domyslnie cityAmmount jest 0 wiec to taka kontrola czy sie dobrze odczytalo i czy ma to sens
            {
                int[,] cityDistances = new int[cityAmmount, cityAmmount];   //nasz graf - faza tworzenia

                for(int i = 0; i < cityAmmount; i++)
                {
                    string line = writeList[i];         //pobor linii z listy i przetworzenie jej na osobne dane w tablicy
                    string[] distances = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);    //z pominieciem spacji

                    for(int j = 0; j < cityAmmount; j++)
                    {
                        cityDistances[i, j] = Convert.ToInt32(distances[j]);    //wpisanie kazdego z pobranych elementow na odpowiednie miejsce
                    }                                                           //tablicy przechowujacej graf
                }
                fileHolder.SetCityDistances(cityDistances);     //ustawienie grafu w fileHolderze
            }

            writeList.Clear();
            foreach(var dist in fileHolder.GetCityDistances())  //fragment dla mnie do sprawdzania poprawnosci
            {
                writeList.Add(dist.ToString());
            }


            return fileHolder;

        }

        public FileHolder ReadRaw(Stream fileStream, List<string> writeList)    //czytanie nieprzygotowanych plikow - moze spowodowac problemy
        {
            var fileContent = string.Empty;
            int cityAmmount;
            FileHolder fileHolder = new FileHolder();

            using (StreamReader reader = new StreamReader(fileStream))
            {

                while((fileContent = reader.ReadLine()) != null)
                {
                    writeList.Add(fileContent);
                }
            }

            var tempList = new List<string>();

            if (writeList.Count() > 0)
            {
                foreach(string line in writeList)
                {
                    if (line.Contains("NAME") || line.Contains("COMMENT") || line.Contains("EDGE_WEIGHT_TYPE") || line.Contains("EDGE_WEIGHT_FORMAT") || line.Contains("EDGE_WEIGHT_SECTION") || line.Contains("EOF"))
                    {
                        tempList.Add(line);
                    }
                    else if (line.Contains("DIMENSION:"))
                    {
                        var elements = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        fileHolder.SetCityAmount(Convert.ToInt32(elements[1]));
                        tempList.Add(line);
                    }
                }

                foreach(string t in tempList)
                {
                    writeList.Remove(t);
                }

                if(fileHolder.GetCityAmount() == 0)
                {
                    var size = writeList[0];
                    fileHolder.SetCityAmount(Convert.ToInt32(size.Trim()));
                    writeList.Remove(size);
                }

                cityAmmount = fileHolder.GetCityAmount();
                int[,] cityDistances = new int[cityAmmount, cityAmmount];

                List<int> allDistances = new List<int>();
                foreach(string line in writeList)
                {
                    string[] distances = line.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach(string distance in distances)
                    {
                        int convertedDistance = Convert.ToInt32(distance);
                        allDistances.Add(convertedDistance);

                    }
                }

                for (int i = 0; i < cityAmmount; i++)
                {
                    var intList = new List<int>();
                    for (int j = i * cityAmmount; j < i * cityAmmount + cityAmmount; j++)
                    {
                        intList.Add(allDistances[j]);

                    }
                    for (int j = 0; j < cityAmmount; j++)
                    {
                        cityDistances[i, j] = intList[j];
                    }
                    intList.Clear();

                }

                fileHolder.SetCityDistances(cityDistances);
            }

            writeList.Clear();
            foreach (var dist in fileHolder.GetCityDistances())  //fragment dla mnie do sprawdzania poprawnosci
            {
                writeList.Add(dist.ToString());
            }


            return fileHolder;
        }

    }
}
