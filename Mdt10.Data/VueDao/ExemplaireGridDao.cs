using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class ExemplaireGridDao : AbstractVueDao<ExemplaireGrid>, IExemplaireGridDao 
    {
        private ComparePropertieGeneric<ExemplaireGrid> compareDateEntree = (n1, n2) => n1.DateEntree.CompareTo(n2.DateEntree);
        private ComparePropertieGeneric<ExemplaireGrid> compareCote = (n1, n2) => n1.Cote.CompareTo(n2.Cote);

        public ExemplaireGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override List<SortingProperty<ExemplaireGrid>> SortingPropertiesBuilder(List<SortingProperty<ExemplaireGrid>> sortingProperties)
        {
            foreach (SortingProperty<ExemplaireGrid> property in sortingProperties)
            {

                switch (property.DataPropertyName)
                {
                    case "DateEntree":
                        property.ComparePropertie = compareDateEntree;
                        break;
                    case "Cote":
                        property.ComparePropertie = compareCote;
                        break;
                }
            }
            return sortingProperties;
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            //string select = 
            //    "select exemplaire.Id as Id, exemplaire.Version as Version, exemplaire.DateEntree as DateEntree, exemplaire.Cote as Cote, document.Id as Id_Document from Exemplaire exemplaire " +
            //    "inner join exemplaire.Document document ";

            string select =
    "select exemplaire.Id as Id, exemplaire.Version as Version, exemplaire.DateEntree as DateEntree, exemplaire.Cote as Cote, exemplaire.Document.Id as Id_Document from Exemplaire exemplaire ";


            
            string where = "";

            if (filters != null)
            {
                foreach (KeyValuePair<string, string> filter in filters)
                {
                    if (filter.Key == "IdDocument") where = " where exemplaire.Document.Id = : IdDocument ";
                }
            }
            string order = " order by exemplaire.DateEntree, exemplaire.Cote";
            return select + where + order;
        }
    }
}
