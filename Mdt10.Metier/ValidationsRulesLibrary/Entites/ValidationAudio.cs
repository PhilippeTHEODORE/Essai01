using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationsRulesLibrary;
using Mdt10.Metier.ValidationRule;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationAlbum : ValidationDocument
    {
        // Données de validation
        ValidationDataChaine dataAlbum;

        public ValidationAlbum()
            : base()
        {
            dataAlbum = new ValidationDataChaine("Album", (string)null);
            dataAlbum.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataAlbum);
            validationRuleRunning.ValidationRule = GetValidationRules();
        }

        public ValidationDataChaine DataAuteur { get { return dataAlbum; } set { dataAlbum = value; } }

        protected override AbstractValidationRule GetValidationRules()
        {
            AbstractValidationRule root = base.GetValidationRules();

            ValidationRuleChaineRequise albumRequis =
                new ValidationRuleChaineRequise(
                    root,
                    "L'album est obligatoire",
                    ErrorLevel.Critical,
                    dataAlbum);

            return albumRequis;
        }
    }
}
