using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class CowFarm : IFarm
    {
        public (string, string, int, double) RaiseAnimal(IAnimal animal) => ("Ферма корів", animal.Name, animal.Age, animal.FoodAmount);
    }
}
