using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class ChickenFarm : IFarm
    {
        public (string, string, int, double) RaiseAnimal(IAnimal animal) => ("Ферма курей", animal.Name, animal.Age, animal.FoodAmount);
    }
}
