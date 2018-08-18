using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Mdt10.Metier.Entites;

namespace Mdt10.Services.Classes
{
    /// <summary>
    /// Classe paramètre pour le service EntreeDocument
    /// </summary>
    public class EntreeDocument
    {
        /// <summary>
        /// Document de l'entrée
        /// </summary>
        public Document Document { get; set; }
        /// <summary>
        /// Date d'entrée du document
        /// </summary>
        public DateTime DateEntree { get; set; }
        /// <summary>
        /// Côte du document
        /// </summary>
        public virtual string CleCote { get; set; }
        /// <summary>
        /// Nombre d'entrée de document
        /// </summary>
        public int Nombre { get; set; }
    }
}
