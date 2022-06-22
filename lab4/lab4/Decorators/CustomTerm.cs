using lab4.Prescription;
using System;

namespace lab4.Decorators
{
    internal class CustomTerm : AddDaysBase
    {
        int n;
        private PrescriptionBase _prescription;
        public CustomTerm(PrescriptionBase prescription, int n=0)
        {
            this.n = n;
            _prescription = prescription;
            description = _prescription.GetDescription();
            validity = _prescription.GetValidity().AddDays(n);
        }

        public override DateTime GetValidity()
        {
            return validity;
        }
    }
}
