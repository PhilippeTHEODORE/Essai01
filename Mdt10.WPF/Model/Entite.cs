using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Mdt10.WPF.Model
{
    public abstract class Entite : INotifyPropertyChanged
    {
        public virtual int Id { get; set; }
        public virtual int Version { get; set; }
        public virtual TimeStamp TimeStamp { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName]  String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
