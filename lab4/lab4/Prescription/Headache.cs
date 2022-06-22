using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Prescription
{
    class Headache : PrescriptionBase
    {
        public Headache()
        {
            description = "Парацетамол, анальгін, ібупрофен";
        }

        public override DateTime GetValidity()
        {
            return DateTime.Now.AddDays(14);
        }
    }
}
