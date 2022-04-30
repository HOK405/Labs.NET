using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Schedule
    {
        public string Departure_city { get; set; }
        public string Arrival_city { get; set; }
        public int Train_number { get; set; }
        public DateTime Departure_time { get; set; }
        public DateTime Arrival_time { get; set; }
        public Schedule(string Departure_city, string Arrival_city, int Train_number, DateTime Departure_time, DateTime Arrival_time)
        {
            this.Departure_city = Departure_city;
            this.Arrival_city = Arrival_city;
            this.Train_number = Train_number;
            this.Departure_time = Departure_time;
            this.Arrival_time = Arrival_time;
        }
        public override string ToString()
        {
            return string.Format($"{Departure_city,-8}{"-",-5}{Arrival_city,-20}№{Train_number}    {Departure_time}----{Arrival_time}");
        }
    }
}
