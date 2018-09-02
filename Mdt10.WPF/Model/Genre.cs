using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdt10.WPF.Model
{
    public class Genre : Entite
    {
        private Mdt10.Metier.Entites.Genre _genre;

        public Genre() { }

        public virtual string CleCote { get; set; }

        public string Libelle
        {
            get { return _genre.Libelle; }

            set
            {
                if (value != _genre.Libelle)
                {
                    _genre.Libelle = value;
                    NotifyPropertyChanged();
                }
            }

        }


    }
}
