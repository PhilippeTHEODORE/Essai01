using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    /// <summary>
    /// Classe de règle de validation
    /// Règle ChaineRequise
    /// </summary>
    public sealed class ValidationRuleDateValideOuVide : AbstractValidationRule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nextValidationRule"></param>
        /// <param name="messageValidationRule"></param>
        /// <param name="errorLevelValidationRule"></param>
        /// <param name="validationDataDate"></param>
        public ValidationRuleDateValideOuVide(
            IValidationRule nextValidationRule, 
            string messageValidationRule, 
            ErrorLevel errorLevelValidationRule, 
            ValidationDataDate validationDataDate)
            : base(validationDataDate.Name + "DateValideOuVide", nextValidationRule, messageValidationRule, errorLevelValidationRule)
        {
            ValidationDataDate = validationDataDate;
            ValidationDataDate.Rules.Add(Name);

        }

        public ValidationRuleDateValideOuVide(string name,IValidationRule nextValidationRule, string messageValidationRule, ErrorLevel errorLevelValidationRule, ValidationDataDate validationDataDate)
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
                    if (!ValidationDataDate.HasSource) return;

                    if (ValidationDataDate.HasSource && !string.IsNullOrEmpty(ValidationDataDate.SourceValue) && !ValidationDataDate.CastingSuccessfull)
                    {
                        ValidationDataDate.SetError(MessageValidationRule, RuleErrorLevel);
                        return;
                    }
                }
            }
            return ;
        }
    }
}
