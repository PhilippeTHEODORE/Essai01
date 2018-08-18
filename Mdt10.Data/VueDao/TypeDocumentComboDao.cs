using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class TypeDocumentComboDao : AbstractVueDao<TypeDocumentCombo>, ITypeDocumentComboDao
    {
        public TypeDocumentComboDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            string select = "select td.Id as Id, td.Libelle as Libelle from TypeDocument td ";
            string where = "";
            string order = "order by td.Libelle";
            return select + where + order;
        }
    }
}
