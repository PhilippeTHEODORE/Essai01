//using Mdt10.Services;
using Mdt10.Metier;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using Mdt10.Data.ScalaireDao;
using System.Collections.Generic;
using System;
using NHibernate;

namespace Mdt10.Data.Dao
{
    public class ExemplaireDao : AbstractEntiteDao<Exemplaire, int>, IExemplaireDaoEntite
    {
        //public ExemplaireDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public ExemplaireDao(IDaoSession daoSession) : base(daoSession) { }

        new public Exemplaire Save(Exemplaire exemplaire)
        {
            if (exemplaire.Id == 0)
            {
                exemplaire.Cote = GetNewCote(exemplaire.Document.Genre.CleCote);
            }
            base.Save(exemplaire);
            return exemplaire;
        }


        public override Boolean CanDelete(int id)
        {
            return true;
        }

        private string GetNewCote(string cleCote)
        {
            string _query = "select max(Cote) as result from Exemplaire where Cote like :ParamCote";
            IQuery query = NHibernateSession.CreateQuery(_query).SetString("ParamCote", cleCote + "%").SetMaxResults(1);
            IList<string> _lastCote = query.List<string>();
            int _LastCote = _lastCote[0] == null ? 0 : int.Parse(_lastCote[0].Substring(_lastCote[0].LastIndexOf("-") + 1));
            return cleCote + "-" + string.Format("{0:00000}", _LastCote + 1);
        }
    }
}
