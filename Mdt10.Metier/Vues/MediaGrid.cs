using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues
{
    public class MediaGrid :  IComparable<MediaGrid>
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Libelle { get; set; }

        public int CompareTo(MediaGrid mediaGrid)
        {
            return 0;
        } 

    }
}
