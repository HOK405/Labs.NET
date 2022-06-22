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
            validity = DateTime.Now.AddDays(14);
        }

        public override DateTime GetValidity()
        {
            return validity;
        }
    }
}
