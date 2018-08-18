using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.ValidationData
{
    public sealed class ValidationDataDate : AbstractValidationData<DateTime?>
    {
        /// <summary>
        /// Constructeur pour donnée sans SourceValue, la date est passée en paramètre
        /// </summary>
        /// <param name="name">Nom de la donnée</param>
        /// <param name="binding">Nom du Binding</param>
        /// <param name="date">Valeur de la date</param>
        public ValidationDataDate(string name, DateTime? date)
            : base(name, date)
        { }

        /// <summary>
        /// Constructeur pour donnée avec SourceValue, le paramètre entreeDate est castée en DateTime
        /// </summary>
        /// <param name="name">Nom de la donnée</param>
        /// <param name="binding">Nom du Binding</param>
        /// <param name="date">Valeur de la date en type String</param>
        public ValidationDataDate(string name, string sourceDate)
            : base(name, sourceDate)
        {
            this.SetSourceValue(sourceDate);
        }

        public override void SetSourceValue(string sourceDate)
        {
            CastingSuccessfull = false;
            SourceValue = sourceDate;
            SetError("", ValidationData.ErrorLevel.None);

            if (string.IsNullOrEmpty(sourceDate))
            {
                CastedValue = null;
                NewSourceValue = null;
            }
            else
            {
                DateTime dateValue;

                if (DateTime.TryParse(sourceDate, out dateValue))
                {
                    CastedValue = dateValue;
                    CastingSuccessfull = true;
                    NewSourceValue = dateValue.ToShortDateString();
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
