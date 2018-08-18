using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class TypeDocument : Entite
    {
        public virtual string Libelle { get; set; }
        public virtual Media Media { get; set; }

        public TypeDocument() { }
    }
}
