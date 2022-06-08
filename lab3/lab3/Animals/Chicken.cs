using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Chicken : IAnimal
    {
        public string Name { get; set; }
        public double FoodAmount { get; set; }
        public int Age { get; set; }
    }
}
