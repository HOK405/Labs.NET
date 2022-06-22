using System;
using lab4.Prescription;

namespace lab4.Decorators
{
    class ModerateIllness : AddDaysBase
    {
        private PrescriptionBase _prescription;
        public ModerateIllness(PrescriptionBase prescription)
        {
            _prescription = prescription;
            description = _prescription.GetDescription();
            validity = _prescription.GetValidity().AddDays(7);
        }

        public override DateTime GetValidity()
        {
                return validity;
        }
    }
}
