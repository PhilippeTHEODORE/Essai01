using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class VueAudioDao : AbstractVueDao<AudioGrid>, IAudioVueDao 
    {
        public VueAudioDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            string select = "select a.Id as Id, a.Titre as Titre,a.Album as Album, g.Libelle as Genre from Audio a inner join a.Genre g  ";
            string where="";
            string order = "order by a.Titre";
            return select + where + order;
        }
    }
}
