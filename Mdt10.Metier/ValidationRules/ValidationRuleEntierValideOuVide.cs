using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    /// <summary>
    /// Classe de règle de validation
    /// Règle EntierValideOuVide
    /// </summary>
    public sealed class ValidationRuleEntierValideOuVide : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataEntier"></param>
        public ValidationRuleEntierValideOuVide(IValidationRule nextValidationRule, string messageValidationRule, ErrorLevel errorLevelValidationRule, ValidationDataEntier validationDataEntier)
            : base(validationDataEntier.Name + "EntierValideOuVide",nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataEntier = validationDataEntier;
            ValidationDataEntier.Rules.Add(Name);
        }

        public ValidationRuleEntierValideOuVide(string name,IValidationRule nextValidationRule, string messageValidationRule, ErrorLevel errorLevelValidationRule, ValidationDataEntier validationDataEntier)
            : base(name,nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataEntier = validationDataEntier;
            ValidationDataEntier.Rules.Add(Name);
        }

        private ValidationDataEntier ValidationDataEntier { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataEntier.HasChanged)
            {
                if (ValidationDataEntier.IsValid)
                {
                    if (!ValidationDataEntier.HasSource) return;

                    if (ValidationDataEntier.HasSource && !string.IsNullOrEmpty(ValidationDataEntier.SourceValue) && !ValidationDataEntier.CastingSuccessfull)
                    {
                        ValidationDataEntier.SetError(MessageValidationRule, RuleErrorLevel);
                        return;
                    }
                }
            }
            return;
        }
    }
}
