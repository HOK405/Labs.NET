using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Prescription
{
    class Stomachache : PrescriptionBase
    {
        public Stomachache()
        {
            description = "Моторикс, метоклопрамід, домрид";
        }
        public override DateTime GetValidity()
        {
            return DateTime.Now.AddDays(7);
        }
    }
}
