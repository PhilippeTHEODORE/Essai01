using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;

namespace Mdt10.Data.Dao
{
    public class MotCleDao : AbstractEntiteDao<MotCle, int>, IMotCleDaoEntite
    {
        //public MotCleDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public MotCleDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
