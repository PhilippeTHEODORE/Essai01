using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues
{

    public class RevueGrid :  IComparable<RevueGrid>
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Periodicite { get; set; }


        public int CompareTo(RevueGrid revueGrid)
        {
            return 0;
        } 
    }
}
