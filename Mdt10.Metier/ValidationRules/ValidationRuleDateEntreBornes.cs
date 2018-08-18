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
    public sealed class ValidationRuleDateEntreBornes : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataDateControle"></param>
        public ValidationRuleDateEntreBornes(
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDateControle,
            ValidationDataDate validationDataDateDebut,
            ValidationDataDate validationDataDateFin
            )
            : base(validationDataDateControle.Name + "DateEntreBornes", nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateControlee = validationDataDateControle;
            ValidationDataDateDebut = validationDataDateDebut;
            ValidationDataDateFin = validationDataDateFin;

            ValidationDataDateControlee.Rules.Add(Name );
        }

        public ValidationRuleDateEntreBornes(
            string name,
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDateControle,
            ValidationDataDate validationDataDateDebut,
            ValidationDataDate validationDataDateFin
            )
            : base(name, nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateControlee = validationDataDateControle;
            ValidationDataDateDebut = validationDataDateDebut;
            ValidationDataDateFin = validationDataDateFin;

            ValidationDataDateControlee.Rules.Add(Name);
        }

        private ValidationDataDate ValidationDataDateControlee { get; set; }
        private ValidationDataDate ValidationDataDateDebut { get; set; }
        private ValidationDataDate ValidationDataDateFin { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataDateControlee.HasSource)
            {
                if (ValidationDataDateControlee.IsValid)
                {
                    if (ValidationDataDateDebut.CastedValue == null) return;

                    if (ValidationDataDateControlee.CastedValue >= ValidationDataDateDebut.CastedValue
                        &&
                        ValidationDataDateControlee.CastedValue <= ValidationDataDateFin.CastedValue) return;

                    ValidationDataDateControlee.SetError(MessageValidationRule, RuleErrorLevel);
                }
            }
            return;
        }
    }
}
