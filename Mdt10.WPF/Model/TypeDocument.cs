using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdt10.WPF.Model
{
    public class TypeDocument : Entite
    {
        public virtual string Libelle { get; set; }
        public virtual Media Media { get; set; }

        public TypeDocument() { }
    }
}
