using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class GenreComboDao : AbstractVueDao<GenreCombo>, IGenreComboDao
    {
        public GenreComboDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> parameters)
        {
            return "select g.Id as Id, g.Libelle as Libelle from Genre g order by g.Libelle ";
        }


    }
}
