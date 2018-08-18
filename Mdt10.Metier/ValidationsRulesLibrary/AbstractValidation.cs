using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationRule;
using Mdt10.Metier.ValidationRulesBuilder;

namespace Mdt10.Metier.ValidationsRulesLibrary
{
    public abstract class AbstractValidation
    {
        /// <summary>
        /// Active ou désactive la validation automatique
        /// </summary>
        public bool ValidationEnabled { get; set; }

        protected ValidationRuleRunning validationRuleRunning = new ValidationRuleRunning();

        ///<summary> 
        ///Exécute la validation de l'ensemble des données de validation 
        /// </summary>
        public void Run()
        {
            validationRuleRunning.Run();
        }

        /// <summary>
        /// Exécute la validation d'une donnée de validation du nom fourni en paramètre et de ses dépendances
        /// </summary>
        /// <param name="dataName">Nom de la donnée de validation qui a déclenchée la validation</param>
        public void Run(string dataName)
        {
            validationRuleRunning.Run(dataName);
        }

        /// <summary>
        /// Définie la méthode appelée après l'exécution de la validation
        /// </summary>
        /// <param name="validationReport">Méthode de validation</param>
        public void SetValidationReportMethod(ValidationReportHandler validationReport)
        {
            validationRuleRunning.AfterValidation += validationReport;
        }
    }
}
