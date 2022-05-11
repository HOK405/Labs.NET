using MyLibrary;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Runtime;
using System.IO;

namespace lab2_LinqToXmL
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

                //new Car(null, "Купе", 18),
                //new Car(null, "Спальний", 21),
                //new Car(null, "Купе", 20),

            };
            List <Schedule> Schedule = new()
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

            XmlWriterSettings settings = new();
            settings.Indent = true;

            using (XmlWriter writer = XmlWriter.Create("trains.xml",settings))
            {
                writer.WriteStartElement("trains");

                foreach (Train train in Trains)
                {
                    writer.WriteStartElement("train");
                    writer.WriteElementString("Train_number", train.Train_number.ToString());
                    writer.WriteElementString("Name", train.Name);
                    writer.WriteElementString("Inventary_number", train.Inventary_number);
                    writer.WriteElementString("Car_quantity", train.Car_quantity.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("cars.xml", settings))
            {
                writer.WriteStartElement("cars");

                foreach (Car car in Cars)
                {
                    writer.WriteStartElement("car");
                    writer.WriteElementString("Train_number", car.Train_number.ToString());
                    writer.WriteElementString("Type", car.Type);
                    writer.WriteElementString("Seat_quantity", car.Seat_quantity.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("schedule.xml", new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartElement("schedules");

                foreach (Schedule schedule in Schedule)
                {
                    writer.WriteStartElement("schedule");
                    writer.WriteElementString("Train_number", schedule.Train_number.ToString());
                    writer.WriteElementString("Departure_city", schedule.Departure_city);
                    writer.WriteElementString("Arrival_city", schedule.Arrival_city);
                    writer.WriteElementString("Departure_time", schedule.Departure_time.ToString("s"));  //////   [EDITED]
                    writer.WriteElementString("Arrival_time", schedule.Arrival_time.ToString("s"));     //////    [EDITED]
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }

            XDocument trainsDoc = XDocument.Load("trains.xml");
            XDocument carsDoc = XDocument.Load("cars.xml");
            XDocument scheduleDoc = XDocument.Load("schedule.xml");

            ShowMenu();
            do
            {
                Console.Write("\nВведіть ваш вибір: ");
                int value = int.Parse(Console.ReadLine());
                switch (value)
                {
                    case 1:
                        Console.Clear();
                        ShowMenu();
                        q1();//   1)       Додавання даних до trains
                        break;

                    case 2:
                        Console.Clear(); 
                        ShowMenu();
                        q2();//   2)       Видалення даних із trains
                        break;

                    case 3:
                        Console.Clear(); 
                        ShowMenu();
                        q3();//   3)       Редагування xml - файлу trains
                        break;

                    case 4:
                        Console.Clear(); 
                        ShowMenu();
                        q4();//   4)       Запис та читання із серіалізацією
                        break;

                    case 5:
                        Console.Clear(); 
                        ShowMenu();
                        q5();//   5)       Вивід всих ПІБ головних по потягу
                        break;

                    case 6:
                        Console.Clear(); 
                        ShowMenu();
                        q6();//   6)       Вивід всіх дат та часу відправлення, відсортовані по давності від пізніших до раніших
                        break;

                    case 7:
                        Console.Clear(); 
                        ShowMenu();
                        q7();//   7)       Вивід рейсів за містом відправлення
                        break;

                    case 8:
                        Console.Clear(); 
                        ShowMenu();
                        q8();//   8)       Вивід інформації про рейс
                        break;

                    case 9:
                        Console.Clear(); 
                        ShowMenu();
                        q9();//   9)       Вивід назви потягів та кількість вагонів яких менша 4, відсортовані за спаданням
                        break;

                    case 10:
                        Console.Clear(); 
                        ShowMenu();
                        q10();//  10)      Вивід загальної кількості вагонів
                        break;

                    case 11:
                        Console.Clear(); 
                        ShowMenu();
                        q11();//  11  Вивід інформації про рейс та інвентарний номер потягу в рейсі (InnerJoin)
                        break;

                    case 12:
                        Console.Clear(); 
                        ShowMenu();
                        q12();// 12   Вивід рейсів відфільтрованих за часом відправлення
                        break;

                    case 13:
                        Console.Clear(); 
                        ShowMenu();
                        q13();// 13 Вивід вузла на 3-ому місці
                        break;

                    case 14:
                        Console.Clear(); 
                        ShowMenu();
                        q14();// 14 Пропускання перших двох вузлів та вивід наступних двох
                        break;

                    case 15:
                        Console.Clear(); 
                        ShowMenu();
                        q15();// 15 Назва потягу та кількість вагонів у ньому
                        break;
                }
            } while (true);

            void q1()
            {

                var root = trainsDoc.Element("trains");
                if (root != null)
                {
                    root.Add(new XElement("train",
                                new XElement("Train_number", 7),
                                new XElement("Name", "Юрієнко Юрій Юрійович"),
                                new XElement("Inventary_number", "ЮТ-1751"),
                                new XElement("Car_quantity", 0)));

                    trainsDoc.Save("trains.xml");
                }
            }
            void q2()
            {
                var root2 = trainsDoc.Element("trains");
                if (root2 != null)
                {
                    var rTrain = root2.Elements("train").FirstOrDefault(p => p.Element("Train_number")?.Value == "7");
                    if (rTrain != null)
                    {
                        rTrain.Remove();
                        trainsDoc.Save("trains.xml");
                    }
                }
            }
            void q3()
            {
                var xtrain = trainsDoc.Element("trains")?.Elements("train").FirstOrDefault(p => p.Element("Inventary_number")?.Value == "ФВ-4215");
                if (xtrain != null)
                {
                    var item = xtrain.Element("Inventary_number");
                    if (item != null) item.Value = "ФВ-4216";
                    trainsDoc.Save("trains.xml"); // xtrain.Save("edited.xml") збереження редагованої частини файлу
                }
            }
            void q4()
            {
                List<Car> Cars2 = new()
                {
                    new Car(1, "Купе", 20),
                    new Car(2, "Плацкарт", 18),
                    new Car(3, "Спальний", 16)
                };
                XmlSerializer serializer = new XmlSerializer(typeof(List<Car>));
                using (TextWriter writer = File.CreateText("serialized_cars.xml"))
                    serializer.Serialize(writer, Cars2);

                List<Car>? newcars = new() { };
                using (TextReader reader = File.OpenText("serialized_cars.xml"))
                    newcars = (List<Car>?)serializer.Deserialize(reader);
                foreach (Car item in newcars)
                    Console.WriteLine($"Тип: {item.Type} | Кількість місць: {item.Seat_quantity}");
            }
            void q5()
            {
                IEnumerable<XElement> names = trainsDoc.Descendants("Name");
                foreach (XElement item in names)
                    Console.WriteLine((string)item);
            }
            void q6()
            {
                var q5 = scheduleDoc.Descendants("schedule").Select(p => p.Element("Departure_time").Value).OrderByDescending(p => p.Trim());
                foreach (var item in q5)
                    Console.WriteLine(item);
            }
            void q7()
            {
                IEnumerable<XElement> q6 =
                    from x in scheduleDoc.Root.Elements("schedule")
                    where (string)x.Element("Departure_city") == "Київ"
                    select x;
                foreach (var item in q6)
                    Console.WriteLine($"Місто: {item.Element("Departure_city").Value}, " +
                        $"час відправлення/прибуття: {(DateTime)item.Element("Departure_time"):g}" +
                        $" - {(DateTime)item.Element("Arrival_time"):g}");
            }
            void q8()
            {
                foreach (XElement scheduleElement in scheduleDoc.Element("schedules").Elements("schedule"))
                {
                    XElement Departure_city = scheduleElement.Element("Departure_city");
                    XElement Arrival_city = scheduleElement.Element("Arrival_city");
                    XElement Train_number = scheduleElement.Element("Train_number");
                    XElement Departure_time = scheduleElement.Element("Departure_time");
                    XElement Arrival_time = scheduleElement.Element("Arrival_time");

                    if (Departure_city != null && Arrival_city != null && Train_number != null && Departure_time != null && Arrival_time != null)
                    {
                        Console.WriteLine($"Місто відправлення: {Departure_city.Value}");
                        Console.WriteLine($"Місто прибуття: {Arrival_city.Value}");
                        Console.WriteLine($"Потяг: {Train_number.Value}");
                        Console.WriteLine($"Час відправлення: {(DateTime)Departure_time}");
                        Console.WriteLine($"Час прибуття: {(DateTime)Arrival_time}");
                    }
                    Console.WriteLine();
                }
            }
            void q9()
            {
                var q9 = trainsDoc.Descendants("train").Select(el => new Train()
                {
                    Inventary_number = (string)el.Element("Inventary_number"),
                    Car_quantity = (int)el.Element("Car_quantity")
                })
                   .Where(p => p.Car_quantity < 4)
                   .OrderByDescending(x => x.Car_quantity);
                foreach (var item in q9)
                    Console.WriteLine($"{item.Inventary_number} - {item.Car_quantity}");
            }
            void q10()
            {
                var q10 = carsDoc.Descendants("car").Count();
                Console.WriteLine(q10);
            }
            void q11()
            {
                var q11 = trainsDoc.Descendants("train").Select(el => new Train()
                {
                    Inventary_number = (string)el.Element("Inventary_number"),
                    Car_quantity = (int)el.Element("Car_quantity"),
                    Name = (string)el.Element("Name"),
                    Train_number = (int)el.Element("Train_number")
                })
                .Join(scheduleDoc.Descendants("schedule").Select(el => new Schedule()
                {
                    Train_number = (int)el.Element("Train_number"),
                    Departure_city = (string)el.Element("Departure_city"),
                    Arrival_city = (string)el.Element("Arrival_city"),
                    Departure_time = (DateTime)el.Element("Departure_time"),
                    Arrival_time = (DateTime)el.Element("Arrival_time")
                }),
                t => t.Train_number,
                s => s.Train_number,
                (t, s) => new { s.Departure_city, s.Arrival_city, t.Inventary_number, s.Departure_time, s.Arrival_time, t.Name });

                foreach (var x in q11)
                    Console.WriteLine($"{x.Departure_city,-8}{"-",-5}{x.Arrival_city,-18}| №{x.Inventary_number} | {x.Departure_time,-16:g}----{x.Arrival_time,16:g}  {x.Name}");
            }
            void q12()
            {
                var q12 = from schedule in scheduleDoc.Root.Elements("schedule")
                          where (DateTime)schedule.Element("Departure_time") > new DateTime(2022, 04, 18)
                          orderby (DateTime)schedule.Element("Departure_time") descending
                          select schedule;
                foreach (var x in q12)
                    Console.WriteLine($"{(DateTime)x.Element("Departure_time"),27:F}----{(DateTime)x.Element("Arrival_time"),-29:F} | {x.Element("Departure_city").Value}");
            }
            void q13()
            {
                XElement XEDocTrains = XElement.Load("trains.xml");
                var q13 = XEDocTrains.Descendants("train").ElementAt(2);
                Console.WriteLine(q13);
            }
            void q14()
            {
                XElement XEDocSchedule = XElement.Load("schedule.xml");
                var q14 = XEDocSchedule.Descendants("schedule").Skip(1).Take(2);
                foreach (var x in q14)
                    Console.WriteLine(x);
            }
            void q15()
            {
                var joinQuery = from trains in trainsDoc.Descendants("train")
                                join cars in carsDoc.Descendants("car") on (int)trains.Element("Train_number") equals (int)cars.Element("Train_number")
                                group trains by new { trains.Element("Inventary_number").Value };
                foreach (var x in joinQuery)
                    Console.WriteLine($"Потяг - {x.Key.Value} | Кількість вагонів: {x.Count()}");
            }
            void ShowMenu()
            {
                Console.WriteLine(  "1  - Додавання даних\n" +
                                    "2  - Видалення даних\n" +
                                    "3  - Редагування xml - файлу\n" +
                                    "4  - Запис та читання із серіалізацієюх\n" +
                                    "5  - Вивід всих ПІБ головних по потягу\n" +
                                    "6  - Вивід всіх дат та часу відправлення, відсортовані по давності від пізніших до раніших\n" +
                                    "7  - Вивід рейсів за містом відправлення\n" +
                                    "8  - Вивід інформації про рейс\n" +
                                    "9  - Вивід назви потягів та кількість вагонів яких менша 4, відсортовані за спаданням\n" +
                                    "10 - Вивід загальної кількості вагонів\n" +
                                    "11 - Вивід інформації про рейс та інвентарний номер потягу в рейсі (InnerJoin)і\n" +
                                    "12 - Вивід рейсів відфільтрованих за часом відправлення\n" +
                                    "13 - Вивід вузла на 3-ому місці\n" +
                                    "14 - Пропускання перших двох вузлів та вивід наступних двох\n" +
                                    "15 - Назва потягу та кількість вагонів у ньому\n");
            }
        }
    }
}
