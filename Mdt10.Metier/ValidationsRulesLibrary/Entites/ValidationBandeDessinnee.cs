using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationsRulesLibrary;
using Mdt10.Metier.ValidationRule;

namespace Mdt10.Metier.ValidationsRulesLibrary.Entites
{
    public class ValidationBandeDessinnee : ValidationDocument
    {
        // Données de validation
        ValidationDataChaine dataAuteur;
        ValidationDataChaine dataNomSerie;
        ValidationDataChaine dataNumeroSerie;

        public ValidationBandeDessinnee()
            : base()
        {
            dataAuteur = new ValidationDataChaine("Auteur", (string)null);
            dataAuteur.DataChanged += validationRuleRunning.Run;

            dataNomSerie = new ValidationDataChaine("NomSerie", (string)null);
            dataNomSerie.DataChanged += validationRuleRunning.Run;

            dataNumeroSerie = new ValidationDataChaine("NumeroSerie", (string)null);
            dataNumeroSerie.DataChanged += validationRuleRunning.Run;

            validationRuleRunning.ValidationDatas.Add(dataAuteur);
            validationRuleRunning.ValidationDatas.Add(dataNomSerie);
            validationRuleRunning.ValidationDatas.Add(dataNumeroSerie);

            validationRuleRunning.ValidationRule = GetValidationRules();

        }

        public ValidationDataChaine DataAuteur { get { return dataAuteur; } set { dataAuteur = value; } }
        public ValidationDataChaine DataNomSerie { get { return dataNomSerie; } set { dataNomSerie = value; } }
        public ValidationDataChaine DataNumeroSerie { get { return dataNumeroSerie; } set { dataNumeroSerie = value; } }

        protected override AbstractValidationRule GetValidationRules()
        {
            AbstractValidationRule root = base.GetValidationRules();

            ValidationRuleChaineRequise auteurRequis =
                new ValidationRuleChaineRequise(
                    root,
                    "L'auteur est obligatoire",
                    ErrorLevel.Critical,
                    dataAuteur);

            ValidationRuleChaineRequise nomSerieRequis =
                new ValidationRuleChaineRequise(
                    auteurRequis,
                    "Le nom de la série est obligatoire",
                    ErrorLevel.Critical,
                    dataNomSerie);

            ValidationRuleChaineRequise numeroSerieRequis =
                new ValidationRuleChaineRequise(
                    nomSerieRequis,
                    "Le numéro de la série est obligatoire",
                    ErrorLevel.Critical,
                    dataNumeroSerie);

            return numeroSerieRequis;
        }
    }
}
