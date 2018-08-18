using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Enums;
using System.Security;
using System.Security.Permissions;
using Mdt10.Metier.Exception;

namespace Mdt10.Data
{
    public abstract class AbstractEntiteDao<T, IdT> : IDaoEntite<T, IdT> where T : Entite
    {
        private readonly IDaoSession _daoSession;
        private readonly INHibernateDaoSession _getDaoSession;

        public AbstractEntiteDao(IDaoSession daoSession)
        {
            _daoSession = daoSession;
            _getDaoSession = (INHibernateDaoSession)_daoSession;
        }

        protected ISession NHibernateSession
        {
            get { return _getDaoSession.GetCurrentSession(); }
        }

        public T GetById(IdT id)
        {
            return NHibernateSession.Get<T>(id);
        }

        public int GetEntityVersion(int Id)
        {
            string _entityName = persitentType.Name;
            string _query = "select Version from " + _entityName + " where Id = :ParamId";

            IQuery query = NHibernateSession.CreateQuery(_query).SetString("ParamId", Id.ToString());
            IList<int> _version = query.List<int>();

            if (_version.Count == 0) return 0;

            return (int)_version[0];
        }

        public void RefreshEntity(T entity)
        {
            NHibernateSession.Refresh(entity);
        }

        public List<T> GetAll()
        {


            return GetByCriteria();
        }

        public List<T> GetByCriteria(params ICriterion[] criterion)
        {
            ICriteria criteria = NHibernateSession.CreateCriteria(typeof(T));

            foreach (ICriterion criterium in criterion)
            {
                criteria.Add(criterium);
            }
            return criteria.List<T>() as List<T>;
        }

        public List<T> GetByExample(T exampleInstance, params string[] propertiesToExclude)
        {
            ICriteria criteria = NHibernateSession.CreateCriteria(typeof(T));
            Example example = Example.Create(exampleInstance);

            foreach (string propertyToExclude in propertiesToExclude)
            {
                example.ExcludeProperty(propertyToExclude);
            }
            criteria.Add(example);
            return criteria.List<T>() as List<T>;
        }

        public T GetUniqueByExample(T exampleInstance, params string[] propertiesToExclude)
        {
            List<T> foundList = GetByExample(exampleInstance, propertiesToExclude);

            if (foundList.Count > 1)
            {
                throw new NonUniqueResultException(foundList.Count);
            }

            if (foundList.Count > 0)
            {
                return foundList[0];
            }
            else
            {
                return default(T);
            }
        }

        public T Save(T entity)
        {

            //if (entity.Id>0)
            //{

            //}   
            
            if (entity.TimeStamp == null)
            {
                TimeStamp timeStamp = new TimeStamp()
                {
                    CreateUser = _daoSession.Utilisateur,
                    CreateDate = DateTime.Now
                };
                entity.TimeStamp = timeStamp;
            }
            else
            {
                entity.TimeStamp.UpdateUser = _daoSession.Utilisateur;
                entity.TimeStamp.UpdateDate = DateTime.Now;
            }

            NHibernateSession.Save(entity);
            return entity;
        }

        public void Delete(T entity) { NHibernateSession.Delete(entity); }

        public void AttachObjet(T entity) { NHibernateSession.Lock(entity, LockMode.None); }

        abstract public Boolean CanDelete(IdT id);

        public virtual string GetCanDeleteMessage(IdT id) { return string.Format("Suppression impossible de l'objet {0} identifiant {1}", persitentType.ToString(), id); }

        public CheckEntityVersionResult CheckEntityVersion(int Id, int Version)
        {
            int version = GetEntityVersion(Id);

            if (version > Version) return CheckEntityVersionResult.Updated;

            return CheckEntityVersionResult.UpToDate;
        }

        private Type persitentType = typeof(T);
    }
}
