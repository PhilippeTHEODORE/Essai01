using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Exemplaire : Entite
    {
        public Exemplaire() { }

        public virtual DateTime DateEntree { get; set; }
        public virtual string Cote { get; set; }
        public virtual Document Document { get; set; }
    }
}
