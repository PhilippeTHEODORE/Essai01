using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    /// <summary>
    /// Classe de règle de validation
    /// Règle ChaineRequise
    /// </summary>
    public sealed class ValidationRuleEntierSuperieur : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataEntier"></param>
        public ValidationRuleEntierSuperieur(
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataEntier validationDataEntierControle,
            ValidationDataEntier validationDataEntierReference
            )
            : base(validationDataEntierControle.Name + "EntierSuperieur",nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataEntierControle = validationDataEntierControle;
            ValidationDataEntierControle.Rules.Add(Name);
            ValidationDataEntierReference = validationDataEntierReference;
        }

        public ValidationRuleEntierSuperieur(
            string name,
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataEntier validationDataEntier,
            ValidationDataEntier validationDataEntierReference
    )
            : base(name, nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataEntierControle = validationDataEntier;
            ValidationDataEntierControle.Rules.Add(Name);
            ValidationDataEntierReference = validationDataEntierReference;
        }



        private ValidationDataEntier ValidationDataEntierControle { get; set; }
        private ValidationDataEntier ValidationDataEntierReference { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataEntierControle.HasChanged)
            {
                if (ValidationDataEntierControle.IsValid)
                {

                    //if (ValidationDataEntierControle.CastedValue == null) return true;

                    //if (ValidationDataEntierReference.CastedValue == null) return true;
                    if (ValidationDataEntierControle.CastedValue != null)
                    {
                        if (ValidationDataEntierControle.CastedValue >= ValidationDataEntierReference.CastedValue) return;
                    }
                    ValidationDataEntierControle.SetError(string.Format(MessageValidationRule, ValidationDataEntierReference.CastedValue), RuleErrorLevel);
                }
            }
            return ;
        }
    }
}
