using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Services
{
    /// <summary>
    /// Classe abstraite de base de définition d'un service
    ///<para> Cette classe contient uniquement la méthode <c>ExecuteService</c> qui recoit un seul paramètre de type générique</para>
    /// </summary>
    /// <typeparam name="T">Type de l'objet paramètre du service</typeparam>
    public abstract class AbstractService<T> : IService<T>
    {
        /// <summary>
        /// Exécute le service
        /// </summary>
        /// <param name="Objet">Objet contenant les paramètres du service</param>
        /// <returns>Objet définissant le résultat d'exécution du service</returns>
        public abstract ServiceStatut ExecuteService(T Objet);
    }
}
