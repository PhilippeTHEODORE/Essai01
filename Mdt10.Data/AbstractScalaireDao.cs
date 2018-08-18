using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using Mdt10.Metier.DataInterfaces;

namespace Mdt10.Data
{
    // T est le type de la liste générique renvoyée par la méthode GetVueDao  ex : TypeDocumentGrid
    public abstract class AbstractScalaireDao<T, U> : IDaoScalaire<T, U>
    {
        //private readonly string SessionFactoryConfigPath;
        protected Type _objetMetierType;
        protected string _idColumnName;
        private IDaoSession _daoSession;
        private INHibernateDaoSession _getDaoSession;

        public AbstractScalaireDao(IDaoSession daoSession)
        {
            _daoSession = daoSession;
            _getDaoSession = (INHibernateDaoSession)_daoSession;
        }

        //public AbstractScalaireDao(string sessionFactoryConfigPath)
        //{
        //    SessionFactoryConfigPath = sessionFactoryConfigPath;
        //}

        abstract public U GetScalaire(T parametre);

        protected ISession NHibernateSession
        {
            get { return _getDaoSession.GetCurrentSession(); }
        }
    }
}
