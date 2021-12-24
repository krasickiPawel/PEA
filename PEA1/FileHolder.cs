using System;
using System.Collections.Generic;
using System.Text;

namespace PEA1
{
    class FileHolder
    {
        int cityAmmount;
        int[,] cityDistances;


        public int GetCityAmount()     //styl z javy bo taki dobrze umiem
        {
            return cityAmmount;
        }

        public void SetCityAmount(int cityAmmount)   //styl z javy
        {
            this.cityAmmount = cityAmmount;
        }

        public int[,] GetCityDistances()
        {
            return cityDistances;
        }

        public void SetCityDistances(int[,] cityDistances)
        {
            this.cityDistances = cityDistances;
        }


    }
}
