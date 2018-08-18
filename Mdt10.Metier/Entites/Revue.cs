using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Revue : Entite
    {
        //public virtual int Id { get; set; }
        public virtual string Libelle { get; set; }
        public virtual Periodicite Periodicite { get; set; }
    }
}
