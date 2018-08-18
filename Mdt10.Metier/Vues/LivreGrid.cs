using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier;
using Mdt10.Metier.Enums;
using Mdt10.Metier.Sorting;

namespace Mdt10.Metier.Vues
{
    public class LivreGrid
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Titre { get; set; }
        public string Auteur { get; set; }
        public string Genre { get; set; }
        public string TypeDocument { get; set; }
    }
}