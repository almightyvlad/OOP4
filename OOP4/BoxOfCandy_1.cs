using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP4
{
    public partial class BoxOfCandy
    {
        List<CandyProduct> Candies { get; set; } = new List<CandyProduct>();

        public void AddCandy(CandyProduct candy)
        {
            Candies.Add(candy);
        }
    }
}
