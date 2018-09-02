using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdt10.WPF.Model
{
    public class TimeStamp 
    {
        public virtual string CreateUser { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual string UpdateUser { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }
}
