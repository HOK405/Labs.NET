using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Prescription
{
    internal class HighBloodPressure : PrescriptionBase
    {
        public HighBloodPressure()
        {
            description = "Каптопрес, фуросемід, конкор, трипліксам";
            validity = DateTime.Now.AddMonths(1);
        }

        public override DateTime GetValidity()
        {
            return validity;
        }
    }
}
