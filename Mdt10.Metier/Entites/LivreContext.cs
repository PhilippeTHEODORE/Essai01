using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class LivreContext
    {
        public Livre Livre { get; set; }
        public List<Exemplaire> Exemplaires { get; set; }
    }
}
