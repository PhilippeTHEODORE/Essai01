using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Genre : Entite
    {
        public virtual string Libelle { get; set; }
        public virtual string CleCote { get; set; }

        public Genre() { }
    }
}
