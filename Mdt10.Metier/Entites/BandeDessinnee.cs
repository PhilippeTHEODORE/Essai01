using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class BandeDessinnee : Document
    {
        public virtual string Auteur { get; set; }
        public virtual string NomSerie { get; set; }
        public virtual string NumeroSerie { get; set; }
    }
}