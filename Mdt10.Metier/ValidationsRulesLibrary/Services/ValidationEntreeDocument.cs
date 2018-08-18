using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationRule;
using Mdt10.Metier.ValidationRulesBuilder;

namespace Mdt10.Metier.ValidationsRulesLibrary.Services
{
    public class ValidationEntreeDocument : AbstractValidation
    {
        // Données de validation
        protected ValidationDataDate dataDateEntree;
        protected ValidationDataDate dataDateParutionDocument;
        protected ValidationDataEntier dataNombreExemplaire;
        protected ValidationDataEntier dataNombreExemplaireMini;

        public ValidationEntreeDocument()
        {
            dataDateEntree = new ValidationDataDate("DateEntree", (string)null);
            dataDateEntree.DataChanged += validationRuleRunning.Run;

            dataDateParutionDocument = new ValidationDataDate("DateParution", (string)null);
            dataDateParutionDocument.DataChanged += validationRuleRunning.Run;

            dataNombreExemplaire = new ValidationDataEntier("TypeDocument", (int?)null);
            dataNombreExemplaire.DataChanged += validationRuleRunning.Run;

            dataNombreExemplaireMini = new ValidationDataEntier("Genre", (int?)null);
            dataNombreExemplaireMini.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataDateParutionDocument);
            validationRuleRunning.ValidationDatas.Add(dataDateEntree);
            validationRuleRunning.ValidationDatas.Add(dataNombreExemplaire);
            validationRuleRunning.ValidationDatas.Add(dataNombreExemplaireMini);
            
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
        public ValidationDataEntier DataNombreExemplaire
        {
            get { return dataNombreExemplaire; }
            set { dataNombreExemplaire = value; }
        }
        public ValidationDataEntier DataNombreExemplaireMini
        {
            get { return dataNombreExemplaireMini; }
            set { dataNombreExemplaireMini = value; }
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

            ValidationRuleEntierValideOuVide nombreExemplaireValide =
                new ValidationRuleEntierValideOuVide(
                    dateEntreeSuperieureParution,
                    "Le format du nombre d'entrées est invalide",
                    ErrorLevel.Critical,
                    dataNombreExemplaire);

            ValidationRuleEntierRequis nombreExemplaireRequis =
                new ValidationRuleEntierRequis(
                    nombreExemplaireValide,
                    "Le nombre d'entrées est obligatoire",
                    ErrorLevel.Critical,
                    dataNombreExemplaire);

            ValidationRuleEntierSuperieur nombreExemplaireSuperieur =
                new ValidationRuleEntierSuperieur(
                    nombreExemplaireRequis,
                    "Le nombre d'entrées doit être supérieur ou égal à {0}",
                    ErrorLevel.Critical,
                    dataNombreExemplaire,
                    dataNombreExemplaireMini);

            return nombreExemplaireSuperieur;
        }
    }
}
