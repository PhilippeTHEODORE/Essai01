using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;

namespace Mdt10.Data.Dao
{
    public class PeriodiqueDao : AbstractEntiteDao<Periodique, int>, IPeriodiqueDaoEntite
    {
        //public PeriodiqueDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public PeriodiqueDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
