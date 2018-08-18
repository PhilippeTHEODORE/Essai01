using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Mdt10.UI.AccessControl;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationRule
{
    /// <summary>
    /// Classe abstraite d'exécution d'une règle de validation
    /// </summary>
    public abstract class AbstractValidationRule : IValidationRule
    {
        /// <summary>
        /// Classe abstraite d'une règle de validation
        /// </summary>
        /// <param name="nextValidation">Référence à un objet de validation du chainage implémentant IValidationRule</param>
        /// <param name="messageValidationRule">Message d'erreur de la règle de validation</param>
        /// <param name="ruleErrorLevel">Niveau d'erreur de la règle de validation</param>
        //public AbstractValidationRule(IValidationRule nextValidation, string messageValidationRule, ErrorLevel ruleErrorLevel)
        //{
        //    NextValidationRule = nextValidation;
        //    MessageValidationRule = messageValidationRule;
        //    RuleErrorLevel = ruleErrorLevel;
        //}

        /// <summary>
        /// Classe abstraite d'une règle de validation
        /// </summary>
        /// <param name="nextValidation">Référence à un objet de validation du chainage implémentant IValidationRule</param>
        /// <param name="messageValidationRule">Message d'erreur de la règle de validation</param>
        /// <param name="ruleErrorLevel">Niveau d'erreur de la règle de validation</param>
        public AbstractValidationRule(string name,IValidationRule nextValidation, string messageValidationRule, ErrorLevel ruleErrorLevel)
        {
            NextValidationRule = nextValidation;
            MessageValidationRule = messageValidationRule;
            RuleErrorLevel = ruleErrorLevel;
            Name = name;
        }

        /// <summary>
        /// Niveau d'erreur de la règle de validation
        /// </summary>
        protected ErrorLevel RuleErrorLevel { get; private set; }

        /// <summary>
        /// Message de la règle de validation
        /// </summary>
        protected string MessageValidationRule { get; private set; }

        protected string Name { get;  set; }
        
        protected IValidationRule NextValidationRule { get; private set; }

        public abstract void Valide();
    }
}
