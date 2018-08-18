using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationsRulesLibrary;
using Mdt10.Metier.ValidationRule;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationMedia : AbstractValidation
    {
        // Données de validation
        ValidationDataChaine dataLibelle;

        public ValidationMedia()
        {
            dataLibelle = new ValidationDataChaine("Libelle", (string)null);
            dataLibelle.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataLibelle);
            validationRuleRunning.ValidationRule = GetValidationRules();
        }

        public ValidationDataChaine DataLibelle { get { return dataLibelle; } private set { dataLibelle = value; } }

        protected AbstractValidationRule GetValidationRules()
        {
            ValidationRuleChaineRequise libelleRequis =
                new ValidationRuleChaineRequise(
                    null,
                    "Le libellé est obligatoire",
                    ErrorLevel.Critical,
                    dataLibelle);
            return libelleRequis;
        }
    }
}
