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
        }

        public override DateTime GetValidity()
        {
            return DateTime.Now.AddMonths(1);
        }
    }
}
