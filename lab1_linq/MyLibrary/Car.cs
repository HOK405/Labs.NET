using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Car
    {
        public int? Train_number { get; set; }
        public string Type { get; set; }
        public int Seat_quantity { get; set; }
        public Car(int? Train_number, string Type, int Seat_quantity)
        {
            this.Train_number = Train_number;
            this.Type = Type;
            this.Seat_quantity = Seat_quantity;
        }
        public override string ToString()
        {
            return string.Format($"Номер потягу - {Train_number}; Тип - {Type}; Кількість місць - {Seat_quantity}");
        }
    }
}
