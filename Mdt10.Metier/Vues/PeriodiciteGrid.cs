using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues
{
    public class PeriodiciteGrid : IComparable<PeriodiciteGrid>
    {
        public int Id { get; set; }
        public string Libelle { get; set; }

        public int CompareTo(PeriodiciteGrid periodiciteGrid)
        {
            return 0;
        }
    }
}
