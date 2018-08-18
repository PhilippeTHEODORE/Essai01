using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationRule;
using Mdt10.Metier.ValidationRulesBuilder;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationExemplaire : AbstractValidation
    {
        // Données de validation
        protected ValidationDataDate dataDateEntree;
        protected ValidationDataDate dataDateParutionDocument;

        public ValidationExemplaire()
        {
            dataDateEntree = new ValidationDataDate("DateEntree", (string)null);
            dataDateEntree.DataChanged += validationRuleRunning.Run;

            dataDateParutionDocument = new ValidationDataDate("DateParution", (string)null);
            dataDateParutionDocument.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataDateParutionDocument);
            validationRuleRunning.ValidationDatas.Add(dataDateEntree);
            
            validationRuleRunning.ValidationRule = GetValidationRules();
        }

        public ValidationDataDate DataDateEntree
        {
            get { return dataDateEntree; }
            set { dataDateEntree = value; }
        }
        public ValidationDataDate DataDateParutionDocument
        {
            get { return dataDateParutionDocument; }
            set { dataDateParutionDocument = value; }
        }

        protected virtual AbstractValidationRule GetValidationRules()
        {
            // Création des règles de validation
            ValidationRuleDateValideOuVide dateEntreeValide =
                new ValidationRuleDateValideOuVide(
                    null,
                    "Le format de la date d'entrée est incorrect",
                    ErrorLevel.Critical,
                    dataDateEntree);

            ValidationRuleDateRequise dateEntreeRequise =
                new ValidationRuleDateRequise(
                    dateEntreeValide,
                    "La date d'entrée est obligatoire",
                    ErrorLevel.Critical,
                    dataDateEntree);

            ValidationRuleDateSuperieureEgale dateEntreeSuperieureParution =
                new ValidationRuleDateSuperieureEgale(
                    dateEntreeRequise,
                    "La date d'entrée doit être supérieure ou égale au {0}, date de parution du document",
                    ErrorLevel.Critical,
                    dataDateEntree,
                    dataDateParutionDocument);

            return dateEntreeSuperieureParution;
        }
    }
}
