using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System;
namespace Mdt10.Data.Dao
{
    public class RevueDao : AbstractEntiteDao<Revue, int>, IRevueDaoEntite
    {
        //public RevueDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public RevueDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
