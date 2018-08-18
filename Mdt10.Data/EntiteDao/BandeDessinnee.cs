using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System;
namespace Mdt10.Data.Dao
{
    public class BandeDessinneeDao : AbstractEntiteDao<BandeDessinnee, int>, IBandeDessinneeDaoEntite
    {
        public BandeDessinneeDao(IDaoSession daoSession) : base(daoSession) { }

        //public BandeDessinneeDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
