using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public partial class BoxOfCandy
    {
        public void DisplayCandies()
        {
            foreach (CandyProduct candy in Candies)
            {
                candy.DisplayInfo();
            }
        }
    }
}
