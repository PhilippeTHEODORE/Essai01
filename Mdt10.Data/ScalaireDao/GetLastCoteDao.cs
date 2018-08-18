using System;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System.Collections;
using NHibernate;

namespace Mdt10.Data.ScalaireDao
{
    // Pour une clé de côte (string), recherche de la dernière numérotation (int) 
    public class GetLastCoteScalaireDao : AbstractScalaireDao<string, int>, IDaoScalaireGetLastCote 
    {
        public GetLastCoteScalaireDao(IDaoSession daoSession) : base(daoSession) { }

        public override int GetScalaire(string cleCote)
        {
            string _query = "select max(Cote) as result from Exemplaire where Cote like :ParamCote";

            IQuery query = NHibernateSession.CreateQuery(_query).SetString("ParamCote", cleCote + "%").SetMaxResults(1);
            IList<string> _lastCote = query.List<string>();

            int _lastSeparator=1;

            if (_lastCote[0] == null)
            {
                return 0;
            }
            else
            {
                string x = (string)_lastCote[0];
                _lastSeparator = x.LastIndexOf("-")+1;
                return int.Parse(x.Substring(_lastSeparator));
            }
        }
    }
}
