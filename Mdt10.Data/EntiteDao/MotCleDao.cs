using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;

namespace Mdt10.Data.Dao
{
    public class DocumentMotCleDao : AbstractEntiteDao<DocumentMotCle, int>, IDocumentMotCleDaoEntite
    {
        //public DocumentMotCleDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public DocumentMotCleDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
