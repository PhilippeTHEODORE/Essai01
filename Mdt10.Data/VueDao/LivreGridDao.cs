using Mdt10.Metier.DataInterfaces;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;
using Mdt10.Metier.Filters;
using Mdt10.Metier.Sorting;
using Mdt10.Metier.Enums;

namespace Mdt10.Data.VueDao
{
    public class LivreGridDao : AbstractVueDao<LivreGrid>, ILivreGridDao
    {
        private ComparePropertieGeneric<LivreGrid> compareTitre = (n1, n2) => n1.Titre.CompareTo(n2.Titre);
        private ComparePropertieGeneric<LivreGrid> compareAuteur = (n1, n2) => n1.Auteur.CompareTo(n2.Auteur);
        private ComparePropertieGeneric<LivreGrid> compareGenre = (n1, n2) => n1.Genre.CompareTo(n2.Genre);
        private ComparePropertieGeneric<LivreGrid> compareTypeDocument = (n1, n2) => n1.TypeDocument.CompareTo(n2.TypeDocument);
        
        public LivreGridDao(IDaoSession daoSession)
            : base(daoSession)
        {
            _idColumnName = "Id";
        }

        protected override List<SortingProperty<LivreGrid>> SortingPropertiesBuilder(List<SortingProperty<LivreGrid>> sortingProperties)
        {
            foreach (SortingProperty<LivreGrid> property in sortingProperties)
            {
                switch (property.DataPropertyName)
                {
                    case "Titre":
                        property.ComparePropertie = compareTitre;
                        break;
                    case "Auteur":
                        property.ComparePropertie = compareAuteur;
                        break;
                    case "Genre":
                        property.ComparePropertie = compareGenre;
                        break;
                    case "TypeDocument":
                        property.ComparePropertie = compareTypeDocument;
                        break;
                }
            }
            return sortingProperties;
        }

        protected override string QueryBuilder(Dictionary<string, string> filters)
        {
            string select =
                "select livre.Id as Id, livre.Version as Version, livre.Titre as Titre, livre.Auteur as Auteur, genre.Libelle as Genre, typedocument.Libelle as TypeDocument " +
                "from Livre livre inner join livre.Genre genre inner join livre.TypeDocument typedocument ";

            string where = "";
            string order = "order by lower(livre.Titre)";
            return select + where + order;
        }
    }
}
