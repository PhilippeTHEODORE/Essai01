﻿using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using NHibernate;

namespace Mdt10.Data.Dao
{
    public class TypeDocumentDao : AbstractEntiteDao<TypeDocument, int>, ITypeDocumentDaoEntite
    {
        //public TypeDocumentDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public TypeDocumentDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            string queryHql = "select doc.Id from Document doc inner join doc.TypeDocument td where td.Id = : IdTypeDocument";
            return NHibernateSession.CreateQuery(queryHql).SetParameter("IdTypeDocument", id).SetMaxResults(1).List<object>().Count == 0;
        }
    }
}
