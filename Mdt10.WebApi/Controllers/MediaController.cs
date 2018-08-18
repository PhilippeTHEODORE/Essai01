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



namespace Mdt10.WebApi.Controllers
{
    public class MediaController : ApiController
    {
        IMediaDaoEntite dao = Windsor.GetObjet<IMediaDaoEntite>();

        private IMediaDaoEntite Dao
        {
            get { return Windsor.GetObjet<IMediaDaoEntite>(); }
        }

        public IEnumerable<Media> Get()
        {
            return dao.GetAll();
        }

        public Media Get(int id)
        {
            return (Media)dao.GetById(id);
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]Media media)
        {
            if (media == null)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            DaoHelper.BeginTransaction();
            dao.Save(media);
            try
            {
                DaoHelper.CommitTransaction();
            }
            catch { }
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        // PUT api/media/5
        [HttpPut]
        public void Put(int id, [FromBody]Media media)
        {
            int i = media.Id;

            Media _media;
            _media = dao.GetById(id);
            _media.Libelle = media.Libelle;

            DaoHelper.BeginTransaction();
            dao.Save(_media);
            try
            {
                DaoHelper.CommitTransaction();
            }
            catch { }
        }

        public void Delete(int id)
        {
            Media _media;
            _media = dao.GetById(id);

            DaoHelper.BeginTransaction();
            dao.Delete(_media);

            try
            {
                DaoHelper.CommitTransaction();
            }
            catch { }
        }
    }
}
