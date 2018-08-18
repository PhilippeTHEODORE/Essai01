using System;
namespace Mdt10.Metier.ValidationData
{
    /// <summary>
    /// Expose les membres d'une donnée de validation ValidationData 
    /// </summary>
    /// <typeparam name="R"></typeparam>
    public interface IValidationData<R>
    {
        R CastedValue { get; }
        bool CastingSuccessfull { get; }
        bool HasSource { get; }
        bool IsValid { get;  }
        string Name { get; }
        void SetError(string message, ErrorLevel erreurLevel);
    }
}
