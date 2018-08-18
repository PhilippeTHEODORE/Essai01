using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class VueMediaDao : AbstractVueDao<MediaGrid>, IMediaVueDao 
    {
        public VueMediaDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> parameters)
        {
            return "select m.Id as Id, m.Version as Version, m.Libelle as Libelle from Media m order by m.Libelle";
        }
    }
}
