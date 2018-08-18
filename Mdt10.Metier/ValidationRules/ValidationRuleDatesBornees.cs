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
    public sealed class ValidationRuleDatesBornees : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataDateDebut"></param>
        public ValidationRuleDatesBornees(
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDateDebut,
            ValidationDataDate validationDataDateFin
            )
            : base(validationDataDateFin.Name + "DatesBornees" + validationDataDateDebut.Name,nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateDebut = validationDataDateDebut;

            ValidationDataDateFin = validationDataDateFin;

            ValidationDataDateDebut.Rules.Add(Name);
            ValidationDataDateFin.Rules.Add(Name);

        }

        public ValidationRuleDatesBornees(
            string name,
            IValidationRule nextValidationRule,
            string messageValidationRule,
            ErrorLevel errorLevelValidationRule,
            ValidationDataDate validationDataDateDebut,
            ValidationDataDate validationDataDateFin
            )
            : base(name,nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDateDebut = validationDataDateDebut;

            ValidationDataDateFin = validationDataDateFin;

            ValidationDataDateDebut.Rules.Add(Name);
            ValidationDataDateFin.Rules.Add(Name);

        }

        private ValidationDataDate ValidationDataDateDebut { get; set; }
        private ValidationDataDate ValidationDataDateFin { get; set; }

        public override void Valide()
        {
            if (NextValidationRule != null) NextValidationRule.Valide();

            if (ValidationDataDateDebut.HasChanged || ValidationDataDateFin.HasChanged)
            {
                if (ValidationDataDateDebut.IsValid && ValidationDataDateFin.IsValid)
                {

                    if (ValidationDataDateFin.CastedValue >= ValidationDataDateDebut.CastedValue) return ;

                    ValidationDataDateDebut.SetError(MessageValidationRule, RuleErrorLevel);
                    ValidationDataDateFin.SetError(MessageValidationRule, RuleErrorLevel);
                }
                return ;
            }
            return ;
        }
    }
}
