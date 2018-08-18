using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.ValidationData
{
    public sealed class ValidationDataEntier : AbstractValidationData<Int32?>
    {
        /// <summary>
        /// Constructeur pour donnée sans SourceValue, la date est passée en paramètre
        /// </summary>
        /// <param name="name">Nom de la donnée</param>
        /// <param name="binding">Nom du Binding</param>
        /// <param name="entier">Valeur de la date</param>
        public ValidationDataEntier(string name, Int32? entier)
            : base(name, entier)
        { }

        /// <summary>
        /// Constructeur pour donnée avec SourceValue, le paramètre entreeDate est castée en DateTime
        /// </summary>
        /// <param name="name">Nom de la donnée</param>
        /// <param name="binding">Nom du Binding</param>
        /// <param name="date">Valeur de la date en type String</param>
        public ValidationDataEntier(string name, string sourceEntier)
            : base(name, sourceEntier)
        {
            this.SetSourceValue(sourceEntier);
        }

        public override void SetSourceValue(string sourceEntier)
        {
            CastingSuccessfull = false;
            SetError("", ValidationData.ErrorLevel.None);

            if (string.IsNullOrEmpty(sourceEntier))
            {
                CastedValue = null;
                NewSourceValue = null;
            }
            else
            {
                Int32 entierValue;

                if (int.TryParse(sourceEntier, out entierValue))
                {
                    CastedValue = entierValue;
                    NewSourceValue = entierValue.ToString();
                    CastingSuccessfull = true;
                }
                else
                {
                    CastedValue = null;
                    NewSourceValue = null;
                }
            }
            OnDataChanged();

        }
    }
}
