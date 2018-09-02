using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdt10.WPF.Model
{
    public class Document
    {


        public virtual Genre Genre { get; set; }
        public virtual string Titre { get; set; }
        public virtual string Resume { get; set; }
        public virtual int IdNationalite { get; set; }

        public virtual DateTime DateParution { get; set; }
        public virtual DateTime? DateEntree { get; set; }
        public virtual Boolean Disponible { get; set; }
        public virtual TypeDocument TypeDocument { get; set; }
        public virtual string NomEnfant { get; set; }


    }
}
