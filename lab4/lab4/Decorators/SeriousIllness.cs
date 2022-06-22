using System;
using lab4.Prescription;

namespace lab4.Decorators
{
    class SeriousIllness : AddDaysBase
    {
        private PrescriptionBase _prescription;
        public SeriousIllness(PrescriptionBase prescription)
        {
            _prescription = prescription;
            description = _prescription.GetDescription();
            validity = _prescription.GetValidity().AddDays(14);
        }
        public override DateTime GetValidity()
        {
            return validity;
        }
    }
}
