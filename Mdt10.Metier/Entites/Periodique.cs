using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Periodique : Document
    {
        //public virtual int Id { get; set; }
        public virtual string NumeroSpecial { get; set; }
        public virtual DateTime DateFinParution { get; set; }
        public virtual Revue Revue { get; set; }
    }
}
