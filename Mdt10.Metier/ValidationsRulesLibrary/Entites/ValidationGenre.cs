using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationsRulesLibrary;
using Mdt10.Metier.ValidationRule;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationGenre : AbstractValidation
    {
        // Données de validation
        ValidationDataChaine dataLibelle;
        ValidationDataChaine dataCleCote;

        public ValidationGenre()
        {
            dataLibelle = new ValidationDataChaine("Libelle", (string)null);
            dataLibelle.DataChanged += validationRuleRunning.Run;

            dataCleCote = new ValidationDataChaine("CleCote", (string)null);
            dataCleCote.DataChanged += validationRuleRunning.Run;


            validationRuleRunning.ValidationDatas.Add(dataLibelle);
            validationRuleRunning.ValidationDatas.Add(dataCleCote);

            validationRuleRunning.ValidationRule = GetValidationRules();

        }

        public ValidationDataChaine DataLibelle { get { return dataLibelle; } set { dataLibelle = value; } }
        public ValidationDataChaine DataCleCote { get { return dataCleCote; } set { dataCleCote = value; } }

        protected AbstractValidationRule GetValidationRules()
        {

            ValidationRuleChaineRequise libelleRequis =
                new ValidationRuleChaineRequise(
                    null,
                    "Le libellé est obligatoire",
                    ErrorLevel.Critical,
                    dataLibelle);

            ValidationRuleChaineRequise cleCoteRequise =
                new ValidationRuleChaineRequise(
                    libelleRequis,
                    "La clé de la côte est obligatoire",
                    ErrorLevel.Critical,
                    dataCleCote);

            return cleCoteRequise;
        }
    }
}
