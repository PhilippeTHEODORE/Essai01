using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using  Mdt10.Metier.ValidationsRulesLibrary.Entites;
using System.Collections.Generic;
using System;

namespace Mdt10.Data.Dao
{
    public class LivreDao : AbstractEntiteDao<Livre, int>, ILivreDaoEntite
    {
        public LivreDao(IDaoSession daoSession) : base(daoSession) { }

        new public Livre Save(Livre livre)
        {
            if (livre.Id == 0)
            {
                livre.NomEnfant = "Livre";
            }
            base.Save(livre);
            return livre;
        }

        public override Boolean CanDelete(int id)
        {
            string queryHql = "select doc.Id from Exemplaire ex inner join ex.Document doc where doc.Id = : IdDocument";
            return NHibernateSession.CreateQuery(queryHql).SetParameter("IdDocument", id).SetMaxResults(1).List<object>().Count == 0;
        }

        public override string GetCanDeleteMessage(int id)
        {
            return "Il existe des exemplaires pour ce livre\nLa suppression est impossible";
        }

        //public void FlushToObject(Livre livre, ValidationLivre validationLivre)
        //{
        //    livre.Titre = validationLivre.DataTitre.CastedValue;
        //    livre.Resume = validationLivre.DataResume.CastedValue;
        //    livre.DateEntree = validationLivre.DataDateEntree.CastedValue;
        //}
    }
}
