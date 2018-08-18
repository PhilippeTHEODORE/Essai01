using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues {
    public class TypeDocumentGrid :  IComparable<TypeDocumentGrid>
    {
        public int Id { get; set; }
        public int Version { get; set; }
        public string Libelle { get; set; }
        public string Media { get; set; }

        public int CompareTo(TypeDocumentGrid typeDocumentGrid)
        {
            return 0;
        } 
    }
}
