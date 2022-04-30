using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Train
    {
        public int Train_number { get; set; }
        public string Name { get; set; }
        public string Inventary_number { get; set; }
        public int Car_quantity { get; set; }
        public Train(int Train_number, string Name, string Inventary_number, int Car_quantity)
        {
            this.Train_number = Train_number;
            this.Name = Name;
            this.Inventary_number = Inventary_number;
            this.Car_quantity = Car_quantity;
        }
        public override string ToString()
        {
            return string.Format($"Інвентарний номер - {Inventary_number, -3}; ПІБ - {Name,-30}; Номер - {Train_number, 2} ; Кількість вагонів -{Car_quantity, 3}");
        }
    }
}
