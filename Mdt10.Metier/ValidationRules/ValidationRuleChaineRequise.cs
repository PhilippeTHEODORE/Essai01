using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Mdt10.UI.AccessControl;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    /// <summary>
    /// Classe de règle de validation
    /// Règle ChaineRequise
    /// </summary>
    public sealed class ValidationRuleChaineRequise : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidation"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="ruleErrorLevel"></param>
        /// <param name="validationDataChaine"></param>
        public ValidationRuleChaineRequise(
            IValidationRule nextValidation, 
            string messageValidationRule, 
            ErrorLevel ruleErrorLevel, 
            ValidationDataChaine validationDataChaine)
            : base(
            validationDataChaine.Name + "ChaineRequise",
            nextValidation, 
            messageValidationRule, 
            ruleErrorLevel)
        {
            ValidationDataChaine = validationDataChaine;
            //Name = validationDataChaine.Name + "ChaineRequise";
            ValidationDataChaine.Rules.Add(Name);
        }

        public ValidationRuleChaineRequise(string name, IValidationRule nextValidation, string messageValidationRule, ErrorLevel ruleErrorLevel, ValidationDataChaine validationDataChaine)
            : base(name, nextValidation, messageValidationRule, ruleErrorLevel)
        {
            ValidationDataChaine = validationDataChaine;
            ValidationDataChaine.Rules.Add(name);
        }
        private ValidationDataChaine ValidationDataChaine { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataChaine.HasChanged && ValidationDataChaine.IsValid)
            {
                string valeur = ValidationDataChaine.SourceValue;
                if (!String.IsNullOrEmpty(valeur)) return;
                ValidationDataChaine.SetError(MessageValidationRule, RuleErrorLevel);
            }
            return;
        }
    }
}
