using System;
using System.Collections.Generic;
using System.Text;

namespace PEA1
{
    class BranchAndBound : Algorithm
    {
        public BranchAndBound(FileHolder fileHolder) : base(fileHolder)
        {
        }

        public void FindBestSolution()
        {


            bestCost = 1 << cityAmmount;

            for (int i=0; i < cityAmmount; i++)
            {
                bestPath[i] = i;
            }

        }

        
    }
}
