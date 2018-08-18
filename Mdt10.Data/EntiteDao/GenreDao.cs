using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using System;
namespace Mdt10.Data.Dao
{
    public class GenreDao : AbstractEntiteDao<Genre, int>, IGenreDaoEntite
    {
        //public GenreDao(string sessionFactoryConfigPath) : base(sessionFactoryConfigPath) { }
        public GenreDao(IDaoSession daoSession) : base(daoSession) { }

        public override Boolean CanDelete(int id)
        {
            return true;
        }
    }
}
