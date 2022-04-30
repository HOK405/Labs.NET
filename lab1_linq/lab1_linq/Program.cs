using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyLibrary;

namespace lab1_linq
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<Train> Trains = new()
            {
                new Train(1, "Андрієнко Андрій Андрійович", "ФВ-4215", 3),
                new Train(2, "Васильченко Василь Васильович", "УМ-1415", 4),
                new Train(3, "Ігоренко Ігор Ігорович", "КА-9517", 2),
                new Train(6, "Валерієнко Валерій Валерійович", "СВ-0001", 0),
                new Train(4, "Сергієнко Сергій Сергійович", "СП-9091", 3),
                new Train(5, "Максименко Максим Максимович", "ЮА-7500", 5),
            };

            List<Car> Cars = new()
            {
                new Car(1, "Купе", 20),
                new Car(1, "Плацкарт", 20),
                new Car(1, "Спальний", 20),

                new Car(2, "Купе", 15),
                new Car(2, "Купе", 16),
                new Car(2, "Спальний", 15),
                new Car(2, "Спальний", 16),

                new Car(3, "Плацкарт", 17),
                new Car(3, "Спальний", 15),

                new Car(4, "Купе", 30),
                new Car(4, "Купе", 25),
                new Car(4, "Купе", 30),

                new Car(5, "Купе", 18),
                new Car(5, "Спальний", 21),
                new Car(5, "Купе", 20),
                new Car(5, "Спальний", 50),
                new Car(5, "Купе", 17),

                new Car(null, "Купе", 18),
                new Car(null, "Спальний", 21),
                new Car(null, "Купе", 20),

            };

            List<Schedule> Schedule = new()
            {
                new Schedule("Київ", "Чоп", 1, new DateTime(2022, 04, 16, 10, 30, 00), new DateTime(2022, 04, 17, 05, 00, 00)),
                new Schedule("Київ", "Вінниця", 2, new DateTime(2022, 04, 16, 12, 30, 00), new DateTime(2022, 04, 16, 17, 25, 00)),
                new Schedule("Ужгород", "Львів", 3, new DateTime(2022, 04, 17, 13, 25, 00), new DateTime(2022, 04, 17, 16, 10, 00)),
                new Schedule("Чоп", "Київ", 1, new DateTime(2022, 04, 17, 14, 00, 00), new DateTime(2022, 04, 18, 09, 20, 00)),
                new Schedule("Київ", "Суми", 4, new DateTime(2022, 04, 18, 10, 30, 00), new DateTime(2022, 04, 18, 14, 00, 00)),
                new Schedule("Київ", "Харків", 5, new DateTime(2022, 04, 18, 11, 20, 00), new DateTime(2022, 04, 18, 23, 00, 00)),
                new Schedule("Львів", "Ужгород", 3, new DateTime(2022, 04, 18, 13, 25, 00), new DateTime(2022, 04, 18, 16, 10, 00)),
                new Schedule("Київ", "Суми", 1, new DateTime(2022, 04, 19, 04, 00, 00), new DateTime(2022, 04, 19, 10, 10, 00)),
                new Schedule("Ужгород", "Івано-Франківськ", 3, new DateTime(2022, 04, 19, 09, 00, 00), new DateTime(2022, 04, 19, 14, 10, 00))
            };

            ShowMenu();
            while (true)
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice == 1) { Console.Clear(); ShowMenu(); q1(Schedule);}
                else if (choice == 2) { Console.Clear(); ShowMenu(); q2(Trains); }
                else if (choice == 3) { Console.Clear(); ShowMenu(); q3(Trains); }
                else if (choice == 4) { Console.Clear(); ShowMenu(); q4(Cars); }
                else if (choice == 5) { Console.Clear(); ShowMenu(); q5(Cars); }
                else if (choice == 6) { Console.Clear(); ShowMenu(); q6(Schedule); }
                else if (choice == 7) { Console.Clear(); ShowMenu(); q7(Schedule, Trains); }
                else if (choice == 8) { Console.Clear(); ShowMenu(); q8(Trains, Cars); }
                else if (choice == 9) { Console.Clear(); ShowMenu(); q9(Trains,Cars); }
                else if (choice == 10){ Console.Clear(); ShowMenu(); q10(Trains,Cars); }
                else if (choice == 11){ Console.Clear(); ShowMenu(); q11(Trains, Schedule); }
                else if (choice == 12){ Console.Clear(); ShowMenu(); q12(Cars); }
                else if (choice == 13){ Console.Clear(); ShowMenu(); q13(Trains, Cars); }
                else if (choice == 14){ Console.Clear(); ShowMenu(); q14(Trains, Cars, Schedule); }
                else if (choice == 15){ Console.Clear(); ShowMenu(); q15(Cars, Trains); }
            }
        }

        static void q1(List<Schedule> Schedule)
        {
            Console.WriteLine("Вивести весь розклад");
            var q1 = from x in Schedule
                     select x;
            foreach (var x in q1)
                Console.WriteLine(x);
        }
        static void q2(List<Train> Trains)
        {
            Console.WriteLine("Вивести всі потяги:");
            var q2 = Trains.Select(x => x);
            foreach (var x in q2)
            {
                Console.WriteLine(x);
            }
        }
        static void q3(List<Train> Trains)
        {
            Console.WriteLine("\nВивести всі потяги, відсортовані по кількості вагонів");
            var q3 = from x in Trains
                     orderby x.Car_quantity descending
                     select x;
            foreach (var x in q3)
                Console.WriteLine(x);
        }
        static void q4(List<Car> Cars)
        {
            Console.WriteLine("\nЗагальна кількість всіх місць у всіх вагонах");
            var q4 = Cars.Sum(p => p.Seat_quantity);
            Console.WriteLine(q4);
        }
        static void q5(List<Car> Cars)
        {
            var q5 = Cars.
                Where(t => (t.Type == t.Type)).Select(t => t.Seat_quantity);
            Console.WriteLine("Середня кількість вагонів = {0}\nНайбільша кількість вагонів = {1}\nНайменша кількість вагонів = {2}", ((int)q5.Average()), q5.Max(), q5.Min());
        }
        static void q6(List<Schedule> Schedule)
        {
            Console.WriteLine("\nВивести рейси в розкладі, у яких місто відправлення або прибуття розпочинається на \"У\"");
            var q6 = from x in Schedule
                     where x.Departure_city.StartsWith("У") || x.Arrival_city.StartsWith("У")
                     select x;
            foreach (var x in q6)
                Console.WriteLine(x);
        }
        static void q7(List<Schedule> Schedule, List<Train> Trains)
        {
            Console.WriteLine("Вивід рейсів після 2022.04.18  5:00");
            var q7 =
                    from schedule in Schedule
                    join trains in Trains on schedule.Train_number equals trains.Train_number
                    where schedule.Departure_time > new DateTime(2022, 04, 18, 5, 0, 0)
                    select new
                    {
                        Departure_city = schedule.Departure_city,
                        Arrival_city = schedule.Arrival_city,
                        Inventary_number = trains.Inventary_number,
                        Departure_time = schedule.Departure_time,
                        Arrival_time = schedule.Arrival_time,
                    };
            foreach (var x in q7)
            {
                Console.WriteLine($"{x.Departure_city,-8}{"-",-5}{x.Arrival_city,-20}№ {x.Inventary_number}    {x.Departure_time}----{x.Arrival_time}");
            }

        }
        static void q8(List<Train> Trains, List<Car> Cars)
        {
            Console.WriteLine("\nLeft Join, вивід типу вагона та назву потяга у якому він знаходиться");
            var q8 =
                from cars in Cars
                join trains in Trains on cars.Train_number equals trains.Train_number into carTrainsGroup
                from subTrains in carTrainsGroup.DefaultIfEmpty()
                select new { carType = cars.Type, trainName = subTrains?.Inventary_number };
            foreach (var x in q8)
            {
                if (x.trainName == null)
                    Console.WriteLine($"{x.carType} - потяг відсутній");
                else
                    Console.WriteLine($"{x.carType} - {x.trainName}");
            }
        }
        static void q9(List<Train> Trains, List<Car> Cars)
        {
            Console.WriteLine("\nRight Join, вивід типу вагона та назву потяга у якому він знаходиться");
            var q9 =
                from trains in Trains
                join cars in Cars on trains.Train_number equals cars.Train_number into trainCarsGroup
                from subCars in trainCarsGroup.DefaultIfEmpty()
                select new { trainName = trains.Inventary_number, carType = subCars?.Type };
            foreach (var x in q9)
            {
                if (x.carType == null)
                    Console.WriteLine($"{x.trainName} - вагони відсутні");
                else
                    Console.WriteLine($"{x.trainName} - {x.carType}");
            }
        }
        static void q10(List<Train> Trains, List<Car> Cars)
        {
            Console.WriteLine("\nВивід інвентарного номеру потяга та фактичної кількості вагонів у ньому\n");
            var q10 =
                from trains in Trains
                join cars in Cars on trains.Train_number equals cars.Train_number
                group trains by new { trains.Name, trains.Inventary_number };
            foreach (var x in q10)
            {
                Console.WriteLine($"ПІБ - {x.Key.Name,-30}| потяг {x.Key.Inventary_number} | к-сть вагонів: {x.Count()}");
            }
        }
        static void q11(List<Train> Trains, List<Schedule> Schedule)
        {
            Console.WriteLine("\nВивід інвентарного номеру потяга, кількості запланованих рейсів та часу, коли вони будуть здійcнені\n");
            var q11 =
                from schedule in Schedule
                join trains in Trains on schedule.Train_number equals trains.Train_number
                group schedule by new { trains.Inventary_number };
            foreach (var x in q11)
            {
                Console.WriteLine($"Потяг: {x.Key.Inventary_number} | Кількість запланованих рейсів: {x.Count()}|");
                foreach (var item in x)
                {
                    Console.WriteLine($"{"",49}|{item.Departure_time}");
                }
                Console.WriteLine();
            }
        }
        static void q12(List<Car> Cars)
        {
            Console.WriteLine("Вивід кількості вагонів певного типу, перечислення кількості місць у кожному вагоні та сума всіх місць вагона\n");
            var q12 = from cars in Cars
                      group cars by cars.Type into carsGroup
                      select new
                      {
                          Key = carsGroup.Key,
                          Cars = carsGroup.OrderByDescending(x => x.Seat_quantity),
                          Sum = carsGroup.Sum(x => x.Seat_quantity)
                      };
            foreach (var x in q12)
            {
                int counter = 1;
                Console.WriteLine("Вагонів типу \"" + x.Key + "\": " + x.Cars.Count());
                foreach (var n in x.Cars)
                {
                    Console.WriteLine(counter + ") Кількість місць - " + n.Seat_quantity);
                    counter++;
                }
                Console.WriteLine("Всього кількість місць у вагонах даного типу - " + x.Sum + "\n");
            }
        }
        static void q13(List<Train> Trains, List<Car> Cars)
        {
            Console.WriteLine("Вивід назви потягу та кількості місць у ньому, відсортовані по кількості місць");
            var q13 = from cars in Cars
                      join trains in Trains on cars.Train_number equals trains.Train_number
                      group new { cars.Seat_quantity }
                      by new { cars.Train_number, trains.Inventary_number } into newGroup
                      orderby newGroup.Sum(car => car.Seat_quantity) descending
                      select new
                      {
                          Sum = newGroup.Sum(x => x.Seat_quantity),
                          Name = newGroup.Key.Inventary_number
                      };
            foreach (var x in q13)
                Console.WriteLine($" {x.Name} - {x.Sum}");
        }
        static void q14(List<Train> Trains, List<Car> Cars, List<Schedule> Schedule)
        {
            Console.WriteLine("Вивід найдетальнішої інформації про кожен рейс");
            var q14 = from cars in Cars
                      join trains in Trains on cars.Train_number equals trains.Train_number
                      join schedule in Schedule on trains.Train_number equals schedule.Train_number
                      group new { cars.Seat_quantity }
                     by new { schedule.Departure_city, schedule.Arrival_city, schedule.Departure_time, schedule.Arrival_time, trains.Inventary_number, trains.Name } into newGroup
                      orderby newGroup.Key.Departure_time
                      select new
                      {
                          departureCity = newGroup.Key.Departure_city,
                          departureTime = newGroup.Key.Departure_time,
                          arrivalCity = newGroup.Key.Arrival_city,
                          arrivalTime = newGroup.Key.Arrival_time,
                          Sum = newGroup.Sum(x => x.Seat_quantity),
                          InventaryName = newGroup.Key.Inventary_number,
                          Name = newGroup.Key.Name
                      };
            foreach (var x in q14)
            {
                Console.WriteLine($"{x.departureCity,-8}{"-",-5}{x.arrivalCity,-18}| №{x.InventaryName} | {x.departureTime,-16:g}----{x.arrivalTime,16:g} |{x.Sum,4}| {x.Name}");
            }
            Console.WriteLine("\n");
        }
        static void q15(List<Car> Cars, List<Train> Trains)
        {
            var q15 =
               from cars in Cars
               join trains in Trains on cars.Train_number equals trains.Train_number
               group new { cars, trains } by new { cars.Type } into newGroup
               select new
               {
                   sumType = newGroup.Count(),
                   type = newGroup.Key.Type,
                   someGroup = newGroup
               };
            foreach (var x in q15)
            {
                Console.WriteLine($"Всього типу  \"{x.type}\" - {x.sumType}");
                foreach (var item in x.someGroup)
                {
                    Console.WriteLine($"{item.trains.Inventary_number}");
                }
                Console.WriteLine();
            }
        }
        static void ShowMenu()
        {
            Console.WriteLine("1  - Вивести весь розклад\n" +
                                "2  - Вивести всі потяги\n" +
                                "3  - Вивести всі потяги, відсортовані по кількості вагонів\n" +
                                "4  - Загальна кількість всіх місць у всіх вагонах\n" +
                                "5  - Середня, найменша та найбільша кількість вагонів\n" +
                                "6  - Вивести рейси в розкладі, у яких місто відправлення або прибуття розпочинається на \"У\"\n" +
                                "7  - Вивід рейсів після 2022.04.18  18:00\n" +
                                "8  - Left Join, вивід типу вагона та назву потяга у якому він знаходиться\n" +
                                "9  - Right Join, вивід типу вагона та назву потяга у якому він знаходиться\n" +
                                "10 - Вивід інвентарного номеру потяга та фактичної кількості вагонів у ньому\n" +
                                "11 - Вивід інвентарного номеру потяга, кількості запланованих рейсів та часу, коли вони будуть здійcнені\n" +
                                "12 - Вивід кількості вагонів певного типу, перечислення кількості місць у кожному вагоні та сума всіх місць вагона\n" +
                                "13 - Вивід назви потягу та кількості місць у ньому, відсортовані по кількості місць\n" +
                                "14 - Вивід детальної інформації про кожен рейс\n" +
                                "15 - Тип вагону, загальна кількість та перелік потягів у яких вони знаходяться\n");
        }
      
    } 
}
