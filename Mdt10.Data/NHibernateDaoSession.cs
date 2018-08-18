using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.Runtime.Remoting.Messaging;
using System;
using Mdt10.Metier.Exception;

namespace Mdt10.Data
{
    /// <summary>
    /// Fournie les services de gestion des sessions et des transactions
    /// </summary>
    public class NHibernateDaoSession : IDaoSession, INHibernateDaoSession
    {
        private const string CurrentSessionKey = "nhibernate.current_session";
        private const string CurrentTransactionKey = "nhibernate.current_transaction";
        private static ISessionFactory sessionFactory;

        private static Object thisLock = new Object();

        public string Utilisateur { get; set; }

        public NHibernateDaoSession(string sessionFactoryConfigPath)
        {
            SessionFactoryConfigPath = sessionFactoryConfigPath;
            //GetCurrentSession(sessionFactoryConfigPath);
        }

        /// <summary>
        /// Obtient ou définie de chemin d'accès au fichier de configuration nHibernate
        /// </summary>
        protected string SessionFactoryConfigPath
        {
            get { return sessionFactoryConfigPath; }
            set { sessionFactoryConfigPath = value; }
        }

        /// <summary>
        /// Renvoi la session nHibernate ISession
        /// </summary>
        /// <returns></returns>
        public ISession GetCurrentSession()
        {
            //lock (thisLock)
            //{
                if (sessionFactory == null)
                {
                    Configuration cfg = new Configuration();
                    cfg.Configure(SessionFactoryConfigPath);

                    sessionFactory = cfg.BuildSessionFactory();
                }

                ISession currentSession = CallContext.GetData(CurrentSessionKey) as ISession;
                if (currentSession == null)
                {
                    currentSession = sessionFactory.OpenSession();
                    CallContext.SetData(CurrentSessionKey, currentSession);
                }
                return currentSession;
            //}
        }

        /// <summary>
        /// Ouverture d'une transaction nHibernate
        /// </summary>
        public void BeginTransactionDao()
        {
            if (sessionFactory != null)
            {
                ITransaction transaction = CallContext.GetData(CurrentTransactionKey) as ITransaction;
                if (transaction == null)
                {
                    transaction = GetCurrentSession().BeginTransaction();
                    CallContext.SetData(CurrentTransactionKey, transaction);
                }
            }
        }

        /// <summary>
        /// Commit de la transcation
        /// </summary>
        public void CommitTransactionDao()
        {
            if (sessionFactory != null)
            {
                ISession session = GetCurrentSession();
                ITransaction transaction = CallContext.GetData(CurrentTransactionKey) as ITransaction;
                if (transaction == null)
                {
                    session.Flush();
                }
                else
                {
                    try
                    {
                        transaction.Commit();
                    }
                    catch (StaleObjectStateException)
                    {
                        transaction.Dispose();
                        CallContext.FreeNamedDataSlot(CurrentTransactionKey);

                        // Provoque l'ouverture d'une nouvelle session
                        CloseSession();
                        session = GetCurrentSession();

                        throw (new UpdatedOrDeletedObject());

                    }
                    catch (Exception e) //e
                    // TODO gerer l'exception
                    {
                        throw;
                    }
                    session.Clear();
                    CallContext.FreeNamedDataSlot(CurrentTransactionKey);
                }
            }
        }

        public void CloseSession()
        {
            ISession currentSession = CallContext.GetData(CurrentSessionKey) as ISession;

            if (currentSession != null)
            {
                currentSession.Close();
                CallContext.FreeNamedDataSlot(CurrentSessionKey);
            }
        }

        public void CloseSessionFactory()
        {
            if (sessionFactory != null)
            {
                sessionFactory.Close();
            }
        }


        /// <summary>
        /// Rollback de la transaction
        /// </summary>
        public void RollbackTransactionDao()
        {
            if (sessionFactory != null)
            {
                ITransaction transaction = CallContext.GetData(CurrentTransactionKey) as ITransaction;
                if (transaction != null)
                {
                    transaction.Rollback();
                    GetCurrentSession().Clear();
                    CallContext.FreeNamedDataSlot(CurrentTransactionKey);
                }
            }
        }

        public void ClearCache()
        {
            GetCurrentSession().Clear();
        }

        /// <summary>
        /// Initialisation de la base de données, la base de données doit exister
        /// </summary>
        public void InitShchema()
        {

            Configuration cfg = new Configuration();
            cfg.Configure(sessionFactoryConfigPath);

            ISessionFactory sessionFactory = cfg.BuildSessionFactory();
            new SchemaExport(cfg).Execute(true /*script*/, true /*export to db*/, false /*just drop*/); //.SetOutputFile("c:\\MyDDL.sql").Execute(true /*script*/, true /*export to db*/, false /*just drop*/);
        }

        private string sessionFactoryConfigPath;

    }
}
