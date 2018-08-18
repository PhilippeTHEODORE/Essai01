using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Vues
{
    public class DocumentMotCleGrid
    {

        public DocumentMotCleGrid()
        {

        }

        public int Id { get; set; }
        public Boolean Checked { get; set; }

        private int idDocument;
        public int Id_Document
        {
            get { return idDocument; }

            set
            {
                idDocument = value;

                if (value > 0) Checked = true; else Checked = false;

            }
        }

        public int Id_Mot_Cle { get; set; }
        public string Mot { get; set; }
    }
}
