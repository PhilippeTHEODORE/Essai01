using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class TimeStamp
    {
        public virtual string CreateUser { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string UpdateUser { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

}
