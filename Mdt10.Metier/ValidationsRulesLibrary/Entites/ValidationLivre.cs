using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationsRulesLibrary;
using Mdt10.Metier.ValidationRule;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationLivre : ValidationDocument
    {
        // Données de validation
        private ValidationDataChaine dataAuteur;
        private ValidationDataChaine dataEditeur;
        private ValidationDataChaine dataIsbn;

        public ValidationLivre()
            : base()
        {
            dataAuteur = new ValidationDataChaine("Auteur", (string)null);
            dataAuteur.DataChanged += validationRuleRunning.Run;

            dataEditeur = new ValidationDataChaine("Editeur", (string)null);
            dataEditeur.DataChanged += validationRuleRunning.Run;

            dataIsbn = new ValidationDataChaine("Isbn", (string)null);
            dataIsbn.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataAuteur);
            validationRuleRunning.ValidationDatas.Add(dataEditeur);
            validationRuleRunning.ValidationDatas.Add(dataIsbn);

            validationRuleRunning.ValidationRule = GetValidationRules();

        }

        public ValidationDataChaine DataAuteur { get { return dataAuteur; } set { dataAuteur = value; } }
        public ValidationDataChaine DataEditeur { get { return dataEditeur; } set { dataEditeur = value; } }
        public ValidationDataChaine DataIsbn { get { return dataIsbn; } set { dataIsbn = value; } }

        protected override AbstractValidationRule GetValidationRules()
        {
            AbstractValidationRule root = base.GetValidationRules();

            ValidationRuleChaineRequise auteurRequis =
                new ValidationRuleChaineRequise(
                    root,
                    "L'auteur est obligatoire",
                    ErrorLevel.Critical,
                    dataAuteur);

            ValidationRuleChaineRequise editeurRequis =
                new ValidationRuleChaineRequise(
                    auteurRequis,
                    "L'éditeur est obligatoire",
                    ErrorLevel.Critical,
                    dataEditeur);

            ValidationRuleChaineRequise isbnRequis =
                new ValidationRuleChaineRequise(
                //editeurRequis,
                    auteurRequis,
                    "Le code Isbn est obligatoire",
                    ErrorLevel.Critical,
                    dataIsbn);

            ////////////ValidationRuleChaineRequise xisbnRequis =
            ////////////    new ValidationRuleISBN(
            ////////////       //editeurRequis,
            ////////////        auteurRequis,
            ////////////        "Le code Isbn est obligatoire",
            ////////////        ErrorLevel.Critical,
            ////////////        dataIsbn);

            return isbnRequis;
        }
    }
}
