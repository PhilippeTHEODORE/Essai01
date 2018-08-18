using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier;
using Mdt10.Metier.Entites;
using Mdt10.Metier.DataInterfaces;

namespace Mdt10.Services
{
    /// <summary>
    /// Classe d'exécution d'une entrée de document
    /// <para>texte</para>
    /// Génére des objets métier EntreeDocument
    /// </summary>
    public class ServiceEntreeDocument : AbstractService<Classes.EntreeDocument>, IServiceEntreeDocument 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entreeDocument">Objet paramètre</param>
        /// <returns>Objet ServiceStatut contient l'identifiant du 1er objet EntreeDocument généré</returns>
        public override ServiceStatut ExecuteService(Classes.EntreeDocument entreeDocument)
        {
            IExemplaireDaoEntite _objetMetierDao = Windsor.GetObjet<IExemplaireDaoEntite>();

            ServiceStatut _serviceStatut = new ServiceStatut();
            Exemplaire _exemplaire;

            for (int i = 1; i <= entreeDocument.Nombre; i++)
            {
                _exemplaire = new Exemplaire();
                _exemplaire.Document = entreeDocument.Document;
                _exemplaire.DateEntree = entreeDocument.DateEntree;
                _objetMetierDao.Save(_exemplaire);

                if (_serviceStatut.IdObjet == 0)
                    _serviceStatut.IdObjet = _exemplaire.Id;
            }

            _serviceStatut.TypeObjet = typeof(Exemplaire);
            _serviceStatut.Statut = Statut.Success;
            return _serviceStatut;
        }
    }
}
