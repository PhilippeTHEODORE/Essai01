using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class MotCleGridDao : AbstractVueDao<MotCleGrid>, IMotCleVueDao 
    {
        public MotCleGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> parameters)
        {
            return "select mc.Id as Id, mc.Mot as Mot from MotCle mc order by mc.Mot";
        }
    }
}
