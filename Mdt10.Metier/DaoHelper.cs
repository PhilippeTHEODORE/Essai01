using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using Mdt10.Metier.DataInterfaces;
using log4net;
using log4net.Config;

namespace Mdt10.Metier
{
    public static class DaoHelper
    {
        private static IDaoSession daoSession;

        static DaoHelper()
        {
            daoSession = Windsor.GetObjet<IDaoSession>();
        }

        public static void ClearCache()
        {
            daoSession.ClearCache();
        }

        public static void BeginTransaction()
        {
            daoSession.BeginTransactionDao();
        }

        public static void CommitTransaction()
        {
            daoSession.CommitTransactionDao();
        }

        public static void RollbackTransaction()
        {
            daoSession.RollbackTransactionDao();
        }
    }
}
