using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    interface IFactory
    {
        IFarm createFarm();
        IAnimal createAnimal(string Name, int Age, double FoodAmount);
    }
}
