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
    public sealed class ValidationRuleDateRequise : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataDate"></param>
        public ValidationRuleDateRequise(IValidationRule nextValidationRule, string messageValidationRule, ErrorLevel errorLevelValidationRule, ValidationDataDate validationDataDate)
            : base(validationDataDate.Name + "DateRequise", nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDate = validationDataDate;
            ValidationDataDate.Rules.Add(Name);
        }

        public ValidationRuleDateRequise(string name,IValidationRule nextValidationRule, string messageValidationRule, ErrorLevel errorLevelValidationRule, ValidationDataDate validationDataDate)
            : base(name,nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDate = validationDataDate;
            ValidationDataDate.Rules.Add(Name);
        }


        private ValidationDataDate ValidationDataDate { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataDate.HasChanged)
            {

                if (ValidationDataDate.IsValid)
                {

                    if (ValidationDataDate.CastedValue != null) return;

                    ValidationDataDate.SetError(MessageValidationRule, RuleErrorLevel);
                }
            }
            return ;
        }
    }
}
