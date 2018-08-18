using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mdt10.Metier.Exception
{
    [Serializable]
    public class UpdatedOrDeletedObject : System.Exception
    {
        public UpdatedOrDeletedObject()
            : base("Un objet à été modifié ou supprimé par un autre utilisateur")
        {

        }
    }


    [Serializable]
    public class DeletedObject : System.Exception
    {
        public DeletedObject()
            : base("Un objet à été supprimé par un autre utilisateur")
        {

        }
    }

}
