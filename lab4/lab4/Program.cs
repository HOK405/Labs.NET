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

                             // Decorator
            PrescriptionBase moderateHeadache = new ModerateIllness(headache);
            Console.WriteLine("Рецепт: " + moderateHeadache.GetDescription());
            Console.WriteLine("Дійсний до: " + moderateHeadache.GetValidity().ToLongDateString() + "\n");

            PrescriptionBase bloodPressure = new HighBloodPressure();
            Console.WriteLine("Рецепт: " + bloodPressure.GetDescription());
            Console.WriteLine("Дійсний до: " + bloodPressure.GetValidity().ToLongDateString() + "\n");
                             // Decorator
            PrescriptionBase cstm = new CustomTerm(bloodPressure,2);
            Console.WriteLine("Рецепт: " + cstm.GetDescription());
            Console.WriteLine("Дійсний до: " + cstm.GetValidity().ToLongDateString() + "\n");

            Console.ReadLine();
        }
    }
}
