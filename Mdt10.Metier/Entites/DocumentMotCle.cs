using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class DocumentMotCle : Entite
    {
        public virtual Document Document { get; set; }
        public virtual MotCle MotCle { get; set; }
    }
}
