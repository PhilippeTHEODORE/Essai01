using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System;
namespace Mdt10.Data.Dao
{
    public class VideoDao : AbstractEntiteDao<Video, int>, IVideoDaoEntite
    {
        //public VideoDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public VideoDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }

        //public IList<VideoGrid> GetVueGrid()
        //{
        //    return (IList<VideoGrid>)GetListe<VideoGrid>("select v.Id as Id, v.Titre as Titre, v.Realisateur as Realisateur, g.Libelle as Genre from Video v inner join v.Genre g order by v.Titre");
        //}

        //public IList<VideoGrid> GetVueDao(Dictionary<string, string> x)
        //{
        //    return (IList<VideoGrid>)GetListe<VideoGrid>("select v.Id as Id, v.Titre as Titre, v.Realisateur as Realisateur, g.Libelle as Genre from Video v inner join v.Genre g order by v.Titre");
        //}
        //public Type GetTypeObjetMetier()
        //{ return typeof(Media); }
        //public string GetIdColumnName() { return "Id"; }

    }
}
