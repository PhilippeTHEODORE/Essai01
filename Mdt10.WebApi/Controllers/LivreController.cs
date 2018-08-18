using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Mdt10.Metier;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using Mdt10.Metier.DataInterfaces;
//using System.Web.Routing;
//using System.Web.Http.Routing;

namespace Mdt10.WebApi.Controllers
{
    public class LivreController : ApiController
    {
        ILivreDaoEntite dao = Windsor.GetObjet<ILivreDaoEntite>();
        IGenreDaoEntite daoGenre = Windsor.GetObjet<IGenreDaoEntite>();
        ITypeDocumentDaoEntite daoTypeDocument = Windsor.GetObjet<ITypeDocumentDaoEntite>();

        ILivreGridDao daoLivreGrid = Windsor.GetObjet<ILivreGridDao>();

        //public IEnumerable<Livre> GetServerDataByIP(string ip)
        //{
        //    return dao.GetAll();
        //}

        //public IEnumerable<Livre> GetServerDataByIP1(string ip1)
        //{
        //    return dao.GetAll();
        //}

        //[HttpGet]
        public string GetIndex()
        { return "erreur"; }

        //[HttpGet]
        public IEnumerable<Livre> GetAll()
        {
            return dao.GetAll();
        }

        [HttpGet]
        public IEnumerable<LivreGrid> GrilleGenerale()
        {
            return daoLivreGrid.GetVue(null);
        }

        //[HttpGet]
        public Livre GetById(int id)
        {
            return dao.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Livre livre)
        {
            if (livre == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            DaoHelper.BeginTransaction();
            dao.Save(livre);
            try
            {
                DaoHelper.CommitTransaction();
            }
            catch { }

            return new HttpResponseMessage();
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]Livre livre)
        {
            var x = new HttpResponseMessage();

            Livre _livre = dao.GetById(id);

            if (_livre.Version == livre.Version)
            {
                _livre.Auteur = livre.Auteur;
                _livre.Titre = livre.Titre;

                if (_livre.Genre != livre.Genre) _livre.Genre = daoGenre.GetById(livre.Genre.Id);
                if (_livre.TypeDocument.Id != livre.TypeDocument.Id) _livre.TypeDocument = daoTypeDocument.GetById(livre.TypeDocument.Id);

                DaoHelper.BeginTransaction();
                dao.Save(_livre);

                try
                {
                    DaoHelper.CommitTransaction();
                }
                catch { }
                return new HttpResponseMessage(HttpStatusCode.OK);

            }
            else
                x.ReasonPhrase = "coucou";
            return x;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            Livre _livre;
            _livre = dao.GetById(id);

            DaoHelper.BeginTransaction();
            dao.Delete(_livre);

            try
            {
                DaoHelper.CommitTransaction();
            }
            catch { }
        }
    }
}
