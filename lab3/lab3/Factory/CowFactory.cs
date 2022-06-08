using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class CowFactory : IFactory
    {
        public IAnimal createAnimal(string name, int age, double foodAmount) => new Cow { Name = name, Age = age, FoodAmount = foodAmount };
        public IFarm createFarm() => new CowFarm();
    }
}
