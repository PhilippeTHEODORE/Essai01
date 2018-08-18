using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System;
namespace Mdt10.Data.Dao
{
    public class AudioDao : AbstractEntiteDao<Audio, int>, IAudioDaoEntite
    {
        //public AudioDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public AudioDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }

        //public IList<AudioGrid> GetVueGrid()
        //{
        //    return (IList<AudioGrid>)GetListe<AudioGrid>("select a.Id as Id, a.Titre as Titre,a.Album as Album, g.Libelle as Genre from Audio a inner join a.Genre g order by a.Titre");
        //}

        //public IList<AudioGrid> GetVueDao(Dictionary<string, string> x)
        //{
        //    return (IList<AudioGrid>)GetListe<AudioGrid>("select a.Id as Id, a.Titre as Titre,a.Album as Album, g.Libelle as Genre from Audio a inner join a.Genre g order by a.Titre");
        //}
        //public Type GetTypeObjetMetier()
        //{ return typeof(Media); }
        //public string GetIdColumnName() { return "Id"; }


    }
}
