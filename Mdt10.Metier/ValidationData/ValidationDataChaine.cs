using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.ValidationData
{
    public sealed class ValidationDataChaine : AbstractValidationData<string>
    {

        //public ValidationDataChaine(string name, string binding, string chaine)
        //    : base(name, binding, chaine)
        //{ }

        public ValidationDataChaine(string name, string chaine)
            : base(name, chaine)
        {
            this.SetSourceValue(chaine);
        }

        public override void SetSourceValue(string chaine)
        {
            SourceValue = chaine;
            CastedValue = chaine;
            CastingSuccessfull = true;
            SetError("", ValidationData.ErrorLevel.None);
            OnDataChanged();
        }
    }
}
