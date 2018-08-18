using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Enums;

namespace Mdt10.Metier.BuffersEntites
{
    public abstract class AbstractBuffer
    {
        private StatusBuffer status;
        private Guid guid;

        public StatusBuffer Status
        {
            get { return status; }
            set { status = value; }
        }

        public Guid Guid {
            get { return guid; }
            set { guid = value; }
        }


    }
}
