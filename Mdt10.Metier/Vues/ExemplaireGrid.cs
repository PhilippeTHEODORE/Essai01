using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues
{
    public class ExemplaireGrid
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public int Id_Document { get; set; }
        public DateTime DateEntree { get; set; }
        public string Cote { get; set; }
    }
}
