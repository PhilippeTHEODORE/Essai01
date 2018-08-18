using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;

namespace Mdt10.Data.Dao
{
    public class PeriodiciteDao : AbstractEntiteDao<Periodicite, int>, IPeriodiciteDaoEntite
    {
        //public PeriodiciteDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public PeriodiciteDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }

        //public IList<PeriodiciteCombo> GetVueCombo()
        //{
        //    return (IList<PeriodiciteCombo>)GetListe<PeriodiciteCombo>("select p.Id as Id, p.Libelle as Libelle from Periodicite p order by p.Libelle");
        //}

        //public IList<PeriodiciteCombo> GetVueGrid()
        //{
        //    return (IList<PeriodiciteCombo>)GetListe<PeriodiciteCombo>("select p.Id as Id, p.Libelle as Libelle from Periodicite p order by p.Libelle");
        //}

        //public IList<PeriodiciteCombo> GetVueDao(Dictionary<string, string> x)
        //{
        //    return (IList<PeriodiciteCombo>)GetListe<PeriodiciteCombo>("select p.Id as Id, p.Libelle as Libelle from Periodicite p order by p.Libelle");
        //}

        //public Type GetTypeObjetMetier()
        //{ return typeof(Periodicite); }
        //public string GetIdColumnName() { return "Id"; }

    }
}
