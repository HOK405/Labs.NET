using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4.Prescription
{
    public abstract class PrescriptionBase
    {
        protected string description;
        public string GetDescription()
        {
            return description;
        }
        public abstract DateTime GetValidity();
    }
}
