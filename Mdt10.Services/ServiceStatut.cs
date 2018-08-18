using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Services
{
    /// <summary>
    /// Enumération définissant l'état du résultat d'exécution d'un objet de service : Success, Error ou None
    /// </summary>
    public enum Statut
    {
       /// <summary>
       /// Le service s'est exécuté avec succès
       /// </summary>
        Success, 
        /// <summary>
        /// Le service ne s'est pas exécuté correctement
        /// </summary>
        Error, 
        /// <summary>
        /// Etat par défaut du statut utilisé uniquement à l'initialisation d'un l'objet <c>ServiceStatut</c>  
        /// </summary>
        None
    }

    /// <summary>
    /// Décrit le résultat d'un service
    /// </summary>
    public class ServiceStatut
    {
        /// <summary>
        /// Objet de résultat d'exécution d'un objet de service
        /// </summary>
        public ServiceStatut()
        {
            Statut = Statut.None;
        }

        /// <summary>
        /// Statut de l'exécution du service
        /// </summary>
        public Statut Statut
        { get; set; }

        /// <summary>
        /// Identifiant d'un objet, généralement un objet métier
        /// </summary>
        public int IdObjet
        { get; set; }

        /// <summary>
        /// Type d'un objet, généralement un objet métier
        /// </summary>
        public Type TypeObjet
        { get; set; }
    }
}
