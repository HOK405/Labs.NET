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
            validity = DateTime.Now.AddDays(7);
        }
        public override DateTime GetValidity()
        {
            return validity;
        }
    }
}
