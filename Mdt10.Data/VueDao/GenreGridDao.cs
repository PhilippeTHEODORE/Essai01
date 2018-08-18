using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class GenreGridDao : AbstractVueDao<GenreGrid>, IGenreGridDao
    {
        public GenreGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> parameters)
        {
            return "select g.Id as Id, g.Libelle as Libelle, g.CleCote as CleCote from Genre g order by g.Libelle ";
        }

        //public override List<GenreGrid> Sort(List<GenreGrid> list, List<SortingProperty<GenreGrid>> sortingProperties)
        //{
        //    return list;
        //}


    }

}
