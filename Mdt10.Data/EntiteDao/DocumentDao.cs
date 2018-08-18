using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
namespace Mdt10.Data.Dao
{
    public class DocumentDao : AbstractEntiteDao<Document, int>, IDocumentDaoEntite
    {
        public DocumentDao(IDaoSession daoSession) : base(daoSession) { }

        //public DocumentDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }

        public override Boolean CanDelete(int id)
        {
            //string queryHql = "select doc.Id from Exemplaire ex inner join ex.Document doc where doc.Id = : IdDocument";
            //return NHibernateSession.CreateQuery(queryHql).SetParameter("IdDocument", id).SetMaxResults(1).List<object>().Count == 0;
            return true;
        }
    }
}
