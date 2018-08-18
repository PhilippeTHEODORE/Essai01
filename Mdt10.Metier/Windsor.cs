using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.Windsor.Configuration.Interpreters;
using Mdt10.Metier.DataInterfaces;
using log4net;
using log4net.Config;

namespace Mdt10.Metier
{
    /// <summary>
    /// Classe statique de stockage du conteneur Windsor et de résolution des objets
    /// Il est préférable d'appeler la méthode Init() au démarrage de l'interface
    /// </summary>
    public static class Windsor
    {
        private static IWindsorContainer windsorContainer;

        static Windsor()
        {
            if (windsorContainer == null) Init();
        }


        public static void SetUser(string user)
        {

            Mdt10.Metier.DataInterfaces.IDaoSession daoSession;

            daoSession = windsorContainer.Resolve<Mdt10.Metier.DataInterfaces.IDaoSession>();

            daoSession.Utilisateur = user;
        }


        public static void Init()
        {
            if (windsorContainer == null)
            {
                //ILog log = LogManager.GetLogger("Essai du logger Log4Net"); ;
                XmlConfigurator.Configure();
                //log.Fatal("test de log");

                windsorContainer = new WindsorContainer(new XmlInterpreter());

                Mdt10.Metier.DataInterfaces.IDaoSession daoSession;
                daoSession = windsorContainer.Resolve<Mdt10.Metier.DataInterfaces.IDaoSession>();
                daoSession.Utilisateur = "ptheodore";

            }
        }

        public static T GetObjet<T>()
        {
            return windsorContainer.Resolve<T>();
        }
    }
}
