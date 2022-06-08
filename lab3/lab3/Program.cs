using System;
using System.Text;

namespace lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            IFactory Factory = new SheepFactory();
            IFarm Farm = Factory.createFarm();
            IAnimal Tom = Factory.createAnimal("Tommy", 1, 3.1);
            var (FarmName, animalName,animalAge,foodAmount) = Farm.RaiseAnimal(Tom);
            Console.WriteLine($"Назва ферми: {FarmName}\n{"",13}Кличка: {animalName}\n{"",13}Вік: {animalAge}\n{"",13}Харчування: {foodAmount} кг/день\n");

            Factory = new CowFactory();
            Farm = Factory.createFarm();
            IAnimal Jack = Factory.createAnimal("Jacky", 2, 4.3);
            (FarmName, animalName, animalAge, foodAmount) = Farm.RaiseAnimal(Jack);
            Console.WriteLine($"Назва ферми: {FarmName}\n{"",13}Кличка: {animalName}\n{"",13}Вік: {animalAge}\n{"",13}Харчування: {foodAmount} кг/день\n");

            Factory = new ChickenFactory();
            Farm = Factory.createFarm();
            IAnimal Pit = Factory.createAnimal("Pitty", 1, 1.1);
            (FarmName, animalName, animalAge, foodAmount) = Farm.RaiseAnimal(Pit);
            Console.WriteLine($"Назва ферми: {FarmName}\n{"",13}Кличка: {animalName}\n{"",13}Вік: {animalAge}\n{"",13}Харчування: {foodAmount} кг/день\n");


            Console.ReadKey();
        }
    }
}
