using System.Collections.Generic;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    public delegate bool ValidationReportHandler();

    public sealed class ValidationRuleRunning
    {

        public event ValidationReportHandler AfterValidation;

        private List<IValidationReport> validationDatas = new List<IValidationReport>();

        public List<IValidationReport> ValidationDatas
        {
            get
            { return validationDatas; }
            set
            { validationDatas = value; }
        }

        public AbstractValidationRule ValidationRule { get; set; }

        /// <summary>
        /// Exécute la validation de toutes les données
        /// </summary>
        public void Run()
        {
            ValidationDataInitChanged();
            ValidationRule.Valide();
            OnAfterValidation();
        }

        public bool ValidationEnabled { get; set; }

        /// <summary>
        /// Exécute la validation d'une donnée et de ses dépendances
        /// </summary>
        public void Run(string dataName)
        {
            ValidationDataInitChanged(dataName);
            ValidationRule.Valide();
            OnAfterValidation();
        }

        /// <summary>
        /// Initialisation de toutes les données de validation
        /// </summary>
        /// <param name="dataName"></param>
        private void ValidationDataInitChanged()
        {
            foreach (IValidationReport v in validationDatas)
            {
                v.InitError();
                v.HasChanged = true;
            }
        }

        /// <summary>
        /// Initialisation des données de validation ayant une règle commune avec dataName
        /// </summary>
        /// <param name="dataName"></param>
        private void ValidationDataInitChanged(string dataName)
        {
            foreach (IValidationReport v in validationDatas)
            {
                if (v.Name == dataName)
                {
                    v.InitError();
                    v.HasChanged = true;

                    // Pour chaque règle de validation de la données de validation
                    foreach (string ruleName1 in v.Rules)
                    {
                        // Pour toutes les données sauf la donnée dataName
                        foreach (IValidationReport d in validationDatas)
                        {
                            if (v.Name != d.Name)
                            {
                                // Pour chaque règle de validation de la données de validation
                                foreach (string ruleName2 in d.Rules)
                                {
                                    // v et d ont une règle commune, on initialise d
                                    if (ruleName1 == ruleName2)
                                    {
                                        d.InitError();
                                        d.HasChanged = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Evénement lancé après l'exécution de la validation
        /// </summary>
        private void OnAfterValidation()
        {
            if (AfterValidation != null)
                AfterValidation();
        }
    }
}
