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
    public sealed class ValidationRuleDateInferieureEgale : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataDate"></param>
        public ValidationRuleDateInferieureEgale(
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDate,
            ValidationDataDate validationDataDateReference
            )
            : base(validationDataDate.Name + "DateInferieureEgale", nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateControle = validationDataDate;
            ValidationDataDateReference = validationDataDateReference;
            ValidationDataDateControle.Rules.Add(Name);

        }

        public ValidationRuleDateInferieureEgale(
            string name,
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDate,
            ValidationDataDate validationDataDateReference
            )
            : base(name, nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateControle = validationDataDate;
            ValidationDataDateReference = validationDataDateReference;
            ValidationDataDateControle.Rules.Add(Name);
        }

        private ValidationDataDate ValidationDataDateControle { get; set; }
        private ValidationDataDate ValidationDataDateReference { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();


            if (ValidationDataDateControle.HasChanged)
            {

                if (ValidationDataDateControle.IsValid)
                {
                    if (ValidationDataDateControle.CastedValue == null) return;

                    if (ValidationDataDateReference.CastedValue == null) return;

                    if (ValidationDataDateControle.CastedValue <= ValidationDataDateReference.CastedValue) return;

                    ValidationDataDateControle.SetError(string.Format(MessageValidationRule, ((DateTime)(ValidationDataDateReference.CastedValue)).ToShortDateString()), RuleErrorLevel);
                }
            }
            return;
        }
    }
}
