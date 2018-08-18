using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.ValidationData;

namespace Mdt10.Metier.ValidationData
{
    /// <summary>
    /// Expose les membres nécessaires au traitement du résultat de la validation d'une données
    /// </summary>
    public interface IValidationReport
    {
        /// <summary>
        /// Libellé de l'erreur
        /// </summary>
        string Message { get;}
        /// <summary>
        /// Niveau de l'erreur
        /// </summary>
        ErrorLevel ErrorLevel { get; }
        string SourceValue { get; }

        string NewSourceValue { get; set; }

        bool HasChanged { get; set; }

        string Name { get; }

        List<string> Rules { get; set; }

        void InitError();
    }
}
