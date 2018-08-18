using System;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationRule;
using Mdt10.Metier.ValidationRulesBuilder;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public abstract class ValidationDocument : AbstractValidation
    {
        // Données de validation
        protected ValidationDataChaine dataTitre;
        protected ValidationDataChaine dataResume;
        protected ValidationDataDate dataDateExemplaire;
        protected ValidationDataDate dataDateParution;
        protected ValidationDataDate dataDateEntree;
        protected ValidationDataEntier dataTypeDocument;
        protected ValidationDataEntier dataGenre;
        protected ValidationDataEntier dataIdentifiant;

        protected ValidationDocument()
        {
            dataTitre = new ValidationDataChaine("Titre", (string)null);
            dataTitre.DataChanged += validationRuleRunning.Run;

            dataResume = new ValidationDataChaine("Resume", (string)null);
            dataResume.DataChanged += validationRuleRunning.Run;

            dataDateExemplaire = new ValidationDataDate("DateExemplaire", (DateTime?)null);
            dataDateExemplaire.DataChanged += validationRuleRunning.Run;

            dataDateParution = new ValidationDataDate("DateParution", (string)null);
            dataDateParution.DataChanged += validationRuleRunning.Run;

            dataDateEntree = new ValidationDataDate("DateEntree", (string)null);
            dataDateEntree.DataChanged += validationRuleRunning.Run;

            dataTypeDocument = new ValidationDataEntier("TypeDocument", (int?)null);
            dataTypeDocument.DataChanged += validationRuleRunning.Run;

            dataGenre = new ValidationDataEntier("Genre", (int?)null);
            dataGenre.DataChanged += validationRuleRunning.Run;

            dataIdentifiant = new ValidationDataEntier("Identifiant", 1);
            dataIdentifiant.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataTitre);
            validationRuleRunning.ValidationDatas.Add(dataResume);
            validationRuleRunning.ValidationDatas.Add(dataDateParution);
            validationRuleRunning.ValidationDatas.Add(dataDateEntree);
            validationRuleRunning.ValidationDatas.Add(dataTypeDocument);
            validationRuleRunning.ValidationDatas.Add(dataGenre);
        }

        public ValidationDataChaine DataTitre { get { return dataTitre; } set { dataTitre = value; } }
        public ValidationDataChaine DataResume { get { return dataResume; } set { dataResume = value; } }
        public ValidationDataDate DataDateExemplaire { get { return dataDateExemplaire; } set { dataDateExemplaire = value; } }
        public ValidationDataDate DataDateParution { get { return dataDateParution; } set { dataDateParution = value; } }
        public ValidationDataDate DataDateEntree { get { return dataDateEntree; } set { dataDateEntree = value; } }
        public ValidationDataEntier DataTypeDocument { get { return dataTypeDocument; } set { dataTypeDocument = value; } }
        public ValidationDataEntier DataGenre { get { return dataGenre; } set { dataGenre = value; } }

        protected virtual AbstractValidationRule GetValidationRules()
        {
            ValidationRuleChaineRequise titreRequis =
                new ValidationRuleChaineRequise(
                    "TitreObligatoire",
                    null,
                    "Le titre est obligatoire",
                    ErrorLevel.Critical,
                    dataTitre);

            ValidationRuleChaineRequise resumeConseille =
                new ValidationRuleChaineRequise(
                    titreRequis,
                    "La saisie du résumé est recommandée",
                    ErrorLevel.Information,
                    dataResume);

            AbstractValidationRule borneDateParutionEntree =
                BuilderBuilderDatesBornees.GetValidationRuleDatesBornees(
                "DateParutionEntreeBornees",
                resumeConseille,
                dataDateParution,
                "Le format de la date de parution est incorrect",
                "La date de parution est obligatoire",
                ErrorLevel.Critical,
                "La date d'entrée doit être supérieure ou égale à la date de parution",
                dataDateEntree,
                "Le format de la date d'entrée est incorrect",
                "La date d'entrée est obligatoire");


            ValidationRuleDateInferieureEgale ExemlaireSuperieureEgaleParution =
                new ValidationRuleDateInferieureEgale(
                    "ExemlaireSuperieureEgaleParution",
                    borneDateParutionEntree,
                    "La date de parution doit être inférieure ou égale à la date d'entrée du premier exemplaire le {0}" ,
                    ErrorLevel.Critical,
                    dataDateParution,
                    dataDateExemplaire);

            ValidationRuleEntierSuperieur idGenreValide =
                new ValidationRuleEntierSuperieur(
                    ExemlaireSuperieureEgaleParution,
                    "La sélection du genre est obligatoire",
                    ErrorLevel.Critical,
                    dataGenre,
                    dataIdentifiant);

            ValidationRuleEntierRequis idTypeDocumentRequis =
                new ValidationRuleEntierRequis(
                    idGenreValide,
                    "La sélection du type de document est obligatoire",
                    ErrorLevel.Critical,
                    dataTypeDocument);

            ValidationRuleEntierSuperieur idTypeDocumentValide =
                new ValidationRuleEntierSuperieur(
                    idTypeDocumentRequis,
                    "La sélection du type de document est obligatoire",
                    ErrorLevel.Critical,
                    dataTypeDocument,
                    dataIdentifiant);

            return idTypeDocumentValide;
        }
    }
}
