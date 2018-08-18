using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class PeriodiciteComboDao : AbstractVueDao<PeriodiciteCombo>, IPeriodiciteComboDao 
    {
        public PeriodiciteComboDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> parameters)
        {
            return "select p.Id as Id, p.Libelle as Libelle from Periodicite p order by p.Libelle";
        }
    }
}
