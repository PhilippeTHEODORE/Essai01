using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class TypeDocumentGridDao : AbstractVueDao<TypeDocumentGrid>, ITypeDocumentGridDao
 {
        public TypeDocumentGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            string select = "select td.Id as Id, td.Version as Version, td.Libelle as Libelle, md.Libelle as Media from TypeDocument td left join td.Media md ";

            string where="";

            if (filters != null)
            {
                foreach (KeyValuePair<string, string> filter in filters)
                {
                    if (filter.Key == TypeDocumentFilter.IdMedia.ToString()) where = "where md.Id = : IdMedia ";
                }
            }
            string order = "order by td.Libelle";
            return select + where + order;
        }
    }
}
