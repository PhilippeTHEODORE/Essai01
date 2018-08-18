using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Services
{
    /// <summary>
    /// Interface générique de Service
    /// </summary>
    /// <typeparam name="T">Type de l'objet paramètre du service</typeparam>
    public interface IService<T>
    {
        ServiceStatut ExecuteService(T Objet);
    }
    /// <summary>
    /// Interface du service d'entrée de documents
    /// </summary>
    public interface IServiceEntreeDocument : IService<Classes.EntreeDocument> { }

}
