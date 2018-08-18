using System;
using System.Collections.Generic;
using System.Text;
using Mdt10.Metier.Enums;
using Mdt10.Metier.Entites;
using NHibernate.Criterion;


namespace Mdt10.Metier.DataInterfaces
{
    /// <summary>
    /// Interface de manipulation d'un objet, fonctions CRUD, version objet ...
    /// </summary>
    /// <typeparam name="T">Type de l'objet métier</typeparam>
    /// <typeparam name="IdT">Identifiant de l'objet métier</typeparam>
    public interface IDaoEntite<T, IdT>
    {
        T GetById(IdT id);
        void RefreshEntity(T entity);
        List<T> GetAll();

        List<T> GetByCriteria(params ICriterion[] criterion);

        List<T> GetByExample(T exampleInstance, params string[] propertiesToExclude);
        T GetUniqueByExample(T exampleInstance, params string[] propertiesToExclude);
        T Save(T entity);
        int GetEntityVersion(int id);
        CheckEntityVersionResult CheckEntityVersion(int Id, int Version);
        void Delete(T entity);
        void AttachObjet(T entity);
        Boolean CanDelete(IdT id);
        string GetCanDeleteMessage(IdT id);
    }
}
