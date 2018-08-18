using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class RevueGridDao  : AbstractVueDao<RevueGrid>, IRevueGridDao 
    {
        public RevueGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            string select = "select r.Id as Id, r.Libelle as Libelle, p.Libelle as Periodicite from Revue r inner join r.Periodicite p ";
            string where="";
            string order = "order by r.Libelle";
            return select + where + order;
        }
    }
}
