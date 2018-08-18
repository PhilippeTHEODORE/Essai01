using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Livre : Document
    {
        public virtual string Auteur { get; set; }
        public virtual string Editeur { get; set; }
        public virtual string Isbn { get; set; }

        //todo exemplaires

    }
}
