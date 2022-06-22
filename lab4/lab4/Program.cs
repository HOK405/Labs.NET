using lab4.Decorators;
using lab4.Prescription;
using System;
using System.Text;

namespace lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            PrescriptionBase headache = new Headache();
            Console.WriteLine("Рецепт: " + headache.GetDescription());
            Console.WriteLine("Дійсний до: " + headache.GetValidity().ToLongDateString()+"\n");

            PrescriptionBase moderateHeadache = new ModerateIllness(headache);
            Console.WriteLine("Рецепт: " + moderateHeadache.GetDescription());
            Console.WriteLine("Дійсний до: " + moderateHeadache.GetValidity().ToLongDateString() + "\n");

            PrescriptionBase moderateHighBloodPressure = new ModerateIllness(new HighBloodPressure());
            Console.WriteLine("Рецепт: " + moderateHighBloodPressure.GetDescription());
            Console.WriteLine("Дійсний до: " + moderateHighBloodPressure.GetValidity().ToLongDateString() + "\n");

            PrescriptionBase customTermHighPressure = new CustomTerm(moderateHighBloodPressure, 2);
            Console.WriteLine("Рецепт: " + customTermHighPressure.GetDescription());
            Console.WriteLine("Дійсний до: " + customTermHighPressure.GetValidity().ToLongDateString() + "\n");

            Console.ReadLine();
        }
    }
}
