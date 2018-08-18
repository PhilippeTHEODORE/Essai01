using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.ValidationData
{
    public class ValidationDataBoolean : AbstractValidationData<bool>
    {

        public ValidationDataBoolean(string name, string chaine)
            : base(name, chaine)
        { }

        //public ValidationDataBoolean(string name, string binding, string chaine)
        //    : base(name, binding, chaine)
        //{
        //    CastingSuccessfull = true;

        //}

        public override void SetSourceValue(string chaine)
        {
            ////////CastedValue = chaine;
            ////////CastingSuccessfull = true;
        }


    }
}
