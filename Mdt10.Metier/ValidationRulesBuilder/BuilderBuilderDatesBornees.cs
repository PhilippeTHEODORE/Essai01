using Mdt10.Metier.ValidationData;
using Mdt10.Metier.ValidationRule;



namespace Mdt10.Metier.ValidationRulesBuilder
{
    public static class BuilderBuilderDatesBornees
    {
        /// <summary>
        /// Renvoi un objet ValidationRule de bornes de dates
        /// Les dates de début et de fin sont obligatoires
        /// </summary>
        /// <param name="ValidationRuleRoot">ValidationRule racine de chainage</param>
        /// <param name="dateDebut">Objet Validation de la date de début</param>
        /// <param name="messageDebutValidOuVide">Messsage de contrôle du format de la date de début</param>
        /// <param name="messageDebutRequise">Messsage de contrôle de date de début requise</param>
        /// <param name="errorLevel">Niveau d'erreur de la validation</param>
        /// <param name="messageBorneDate">Message de contrôle de vlidation de la borne des dates</param>
        /// <param name="dateFin">Objet Validation de la date de fin</param>
        /// <param name="messageFintValidOuVide">Messsage de contrôle du format de la date de fin</param>
        /// <param name="messageFinRequise">Messsage de contrôle de date de fin requise</param>
        /// <returns></returns>
        public static AbstractValidationRule GetValidationRuleDatesBornees(
             string name,
             AbstractValidationRule ValidationRuleRoot,
             ValidationDataDate dateDebut,
             string messageDebutValidOuVide,
             string messageDebutRequise,
             ErrorLevel errorLevel,
             string messageBorneDate,
             ValidationDataDate dateFin,
             string messageFintValidOuVide,
             string messageFinRequise

             )
        {
            ValidationRuleDateValideOuVide dateDebutValide =
                new ValidationRuleDateValideOuVide(
                    ValidationRuleRoot,
                    messageDebutValidOuVide,
                    ErrorLevel.Critical,
                    dateDebut);

            ValidationRuleDateRequise dateDebutRequise =
                new ValidationRuleDateRequise(
                    dateDebutValide,
                    messageDebutRequise,
                    ErrorLevel.Critical,
                    dateDebut);

            //string s = dateDebutRequise

            ValidationRuleDateValideOuVide dateFinValide =
                new ValidationRuleDateValideOuVide(
                    dateDebutRequise,
                    messageFintValidOuVide,
                    ErrorLevel.Critical,
                    dateFin);

            ValidationRuleDateRequise dateFinRequise =
                new ValidationRuleDateRequise(
                    dateFinValide,
                    messageFinRequise,
                    ErrorLevel.Critical,
                    dateFin);

            ValidationRuleDatesBornees FinSuperieureEgaleDebut =
                new ValidationRuleDatesBornees(
                    name,
                    dateFinRequise,
                    messageBorneDate,
                    errorLevel,
                    dateDebut,
                    dateFin);

            return FinSuperieureEgaleDebut;
        }
    }
}
