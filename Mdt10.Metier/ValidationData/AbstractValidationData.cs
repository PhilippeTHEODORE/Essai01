using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.ValidationData
{
    /// <summary>
    /// Représente une donnée générique de validation
    /// </summary>
    /// <typeparam name="R">Type générique de la donnée</typeparam>
    public abstract class AbstractValidationData<R> : IValidationData<R>, IValidationReport
    {

        public delegate void ValidationDataDataChangedHandler(string ValidationDataName);
        public event ValidationDataDataChangedHandler DataChanged;

        protected string sourceValue;
        protected bool hasChanged;
        protected R castedValue;

        /// <summary>
        /// Contructeur à utiliser quand la donnée n'a pas de source texte, la donnée est transmise dans son type R
        /// </summary>
        /// <param name="name">Nom de la donnée</param>
        /// <param name="binding">Nom du binding, ex : le nom d'un contrôle TextBox</param>
        /// <param name="castee">Donnée dans son type réel R</param>
        public AbstractValidationData(string name, R castee)
        {
            Name = name;
            HasSource = false;
            CastedValue = castee;
            IsValid = true;
            Rules = new List<string>();
        }

        /// <summary>
        /// Contructeur à utiliser quand la donnée a une source texte, la donnée est transmise en type String puis castée dans son type <R> par le constructeur de la classe héritée
        /// </summary>
        /// <param name="name"></param>
        /// <param name="binding"></param>
        /// <param name="entree"></param>
        public AbstractValidationData(string name, string entree)
        {
            Name = name;
            HasSource = true;
            SourceValue = entree;
            IsValid = true;
            Rules = new List<string>();
        }

        public abstract void SetSourceValue(string sourceValeur);

        public void SetCastedValue(R sourceCasted)
        {
            InitError();
            CastedValue = sourceCasted;
            OnDataChanged();
        }

        /// <summary>
        /// Nom de la donnée de validation
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Liste des règles de validation utilisant cette donnée de validation
        /// </summary>
        public List<string> Rules { get;  set; }

        /// <summary>
        /// La donnée de validation à été modifiée
        /// </summary>
        public bool HasChanged
        {
            get
            {
                return hasChanged;
            }
            set
            {
                hasChanged = value;
            }
        }

        /// <summary>
        /// La donnée de validation à une source texte
        /// Si True, les propriétés SourceValue et CastingSuccessfull sont pertinentes
        /// Le setter est privé, la propriété est initialisée par le constructeur
        /// </summary>
        public bool HasSource { get; private set; }

          /// <summary>
        /// Valeur source de la donnée, le setter est protected et initialisé par les constructeurs
        /// Pertinente si HasSource est à True, sinon ne pas l'exploiter
        /// Le setter est privé, la propriété est initialisée par le constructeur
        /// </summary>
        public string SourceValue
        {
            get
            { return sourceValue; }
            protected set
            {
                sourceValue = value;
                hasChanged = true;
                //TODO Coder événement ValidationDataChangedHandler
                //OnDataChanged();
            }
        }

        /// <summary>
        /// Valeur source de la donnée, le setter est protected et initialisé par les constructeurs
        /// Pertinente si HasSource est à True, sinon ne pas l'exploiter
        /// Le setter est privé, la propriété est initialisée par le constructeur
        /// </summary>
        public string NewSourceValue { get;  set; }

        /// <summary>
        /// Réussite du casting de la donnée source
        /// Pertinente si HasSource est à True, sinon ne pas l'exploiter
        /// </summary>
        public bool CastingSuccessfull { get; protected set; }

        /// <summary>
        /// Valeur castée dans le type réel de la donnée, le setter est protected et initialisé par les constructeurs
        /// Le setter est protected, la propriété peut être initialisé par la classe hérité
        /// </summary>
        public R CastedValue
        {
            get
            { return castedValue; }

            protected set
            {
                castedValue = value;
                hasChanged = true;
                 //TODO Coder événement ValidationDataChangedHandler
                //OnDataChanged();
           }
        }

        /// <summary>
        /// Validité de la donnée défini par la validation
        /// Le setter est privé, la propriété est initialisée par la méthode SetError
        /// </summary>
        public bool IsValid { get; private set; }

        /// <summary>
        /// Message d'anomalie
        /// Défini par la méthode SetError
        /// Le setter est privé, la propriété est initialisée par la méthode SetError
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Niveau d'erreur
        /// Défini par la méthode SetError
        /// Le setter est privé, la propriété est initialisée par la méthode SetError
        /// </summary>
        public ErrorLevel ErrorLevel { get; private set; }

        /// <summary>
        /// Positionne le niveau de l'erreur et le message de validation
        /// Appelé par la règle de validation
        /// </summary>
        /// <param name="message">Message de l'anomalie</param>
        /// <param name="errorLevel">Niveau de l'erreur</param>
        public void SetError(string message, ErrorLevel errorLevel)
        {
            Message = message;
            ErrorLevel = errorLevel;
            IsValid = ErrorLevel != ErrorLevel.Critical;
        }

        public void InitError()
        {
            SetError("", ValidationData.ErrorLevel.None);
        }

        public void OnDataChanged()
        {
            if (DataChanged != null)
            {
                DataChanged(Name);
            }
        }

    }
}

