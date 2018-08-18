using System;
using System.Collections;
using System.Collections.Generic;
using NHibernate;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Enums;
using Mdt10.Metier.Sorting;
using System.Linq;
using System.Diagnostics.Contracts;
////////using NHibernate.Linq;


namespace Mdt10.Data
{
    // T est le type de la liste générique renvoyée par la méthode GetVueDao  ex : TypeDocumentGrid
    public abstract class AbstractVueDao<ObjetListeType> : IDaoVue<ObjetListeType>
    {
        //private readonly string SessionFactoryConfigPath;
        protected string _idColumnName;
        private INHibernateDaoSession _getDaoSession;

        private IDaoSession _daoSession;

        public AbstractVueDao(IDaoSession daoSession)
        {
            _daoSession = daoSession;
            _getDaoSession = (INHibernateDaoSession)_daoSession;
        }

        //public AbstractVueDao(string sessionFactoryConfigPath)
        //{
        //    SessionFactoryConfigPath = sessionFactoryConfigPath;
        //}

        public virtual List<ObjetListeType> GetVue(Dictionary<string, string> filters)
        {

            ////////ISession isession = NHibernateSession;
            ////////var query0 = from m in isession.Query<Livre>()
            ////////             select m;
            ////////IEnumerable<Livre> xy = query0.ToList();
            //Contract.Requires(filters != null);

            //TestCodeContract(null);

            //GetTuple();

            //GetSortedSet();


            IQuery query = NHibernateSession.CreateQuery(QueryBuilder(filters));

            if (filters != null)
            {
                foreach (KeyValuePair<string, string> filter in filters)
                {
                    query.SetParameter(filter.Key, filter.Value);
                }
            }

            return (List<ObjetListeType>)query.SetResultTransformer(NHibernate.Transform.Transformers.AliasToBean<ObjetListeType>()).List<ObjetListeType>();
        }


        //public void TestCodeContract(string s)
        //{
        //    Contract.Requires<ArgumentException>(s != null, "Le paramètre 's' ne peut pas être nulle !!!");

        //}

        ////////[ContractInvariantMethod()]
        ////////protected void TestCodeContractInvariant()
        ////////{
        ////////    Contract.Invariant(s != null, "Le dénominateur doit toujours être différent de 0.");
        ////////}


        ////////public void GetSortedSet()
        ////////{
        ////////    SortedSet<Media> x = new SortedSet<Media>();

        ////////    x.Add(new Media() { Libelle = "Média 4" });
        ////////    x.Add(new Media() { Libelle = "Média 1" });
        ////////    x.Add(new Media() { Libelle = "Média 3" });
        ////////    x.Add(new Media() { Libelle = "Média 2" });
        ////////}

        //public void GetTuple()
        //{
        //    Tuple<int, string> x = returnTuple();
        //    string s = string.Format("{0}, {1}", x.Item1,x.Item2);
        //}

        //public Tuple<int, string> returnTuple()
        //{

        //    Tuple<int, string> x = new Tuple<int, string>(1, "Coucou");
        //    return x;
        //}

        public virtual List<ObjetListeType> Sort(List<ObjetListeType> list, List<SortingProperty<ObjetListeType>> sortingProperties)
        {
            int i = 0;
            sortingProperties = SortingPropertiesBuilder(sortingProperties);

            list.Sort(delegate(ObjetListeType n1, ObjetListeType n2)
            {
                foreach (SortingProperty<ObjetListeType> sp in sortingProperties)
                {

                    if (Object.ReferenceEquals(n1, n2))
                    {
                        return 0;
                    }

                    i = sp.ComparePropertie(n1, n2);
                    if (i != 0)
                    {
                        if (sp.SortingDirection == SortingDirections.Descending) { return -i; }
                        return i;
                    }
                }
                return i;
            });
            return list;
        }

        abstract protected string QueryBuilder(Dictionary<string, string> parameters);

        // TODO faire methode abstraite
        virtual protected List<SortingProperty<ObjetListeType>> SortingPropertiesBuilder(List<SortingProperty<ObjetListeType>> sortingProperties) { return sortingProperties; }

        public string GetIdColumnName() { return _idColumnName; }

        //protected ISession NHibernateSession
        //{
        //    get { return NHibernateHelper.GetCurrentSession(SessionFactoryConfigPath); }
        //}
        protected ISession NHibernateSession
        {
            //get { return NHibernateHelper.GetCurrentSession(SessionFactoryConfigPath); }
            get { return _getDaoSession.GetCurrentSession(); }
        }

    }
}
