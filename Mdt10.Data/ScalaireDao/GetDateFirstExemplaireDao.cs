using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System.Collections;
using NHibernate;

namespace Mdt10.Data.ScalaireDao
{
    // Pour un Id Exemplaire (int), recherche de la dernière date d'entrée (DateTime?) 
    public class GetDateFirstExemplaireDao : AbstractScalaireDao<int, DateTime?>, IDaoScalaireGetDateFirstExemplaire 
    {
        public GetDateFirstExemplaireDao(IDaoSession daoSession) : base(daoSession) { }

        public override DateTime? GetScalaire(int idDocument)
        {
            string _query = "select min(exemplaire.DateEntree) as result " +
                "from Exemplaire exemplaire  inner join exemplaire.Document document where document.Id = :ParamIdDocument";

            IQuery query = NHibernateSession.CreateQuery(_query).SetString("ParamIdDocument", idDocument.ToString()).SetMaxResults(1);
            IList<DateTime?> _firstEntree = query.List<DateTime?>();

            if (_firstEntree[0] == null)
            {
                return (DateTime?)null;
            }
            else
            {
                return (DateTime?)_firstEntree[0];
            }
        }
    }
}
