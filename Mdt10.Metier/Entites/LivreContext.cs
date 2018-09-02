using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;

namespace Mdt10.Metier.Entites
{
    public class LivreContext : INotifyPropertyChanged
    {
        public Livre Livre { get; set; }
        public List<Exemplaire> Exemplaires { get; set; }

        private bool _isSelected;
        private bool _isExpanded;
        private bool _saveIsExpanded;

        public bool IsSelected
        {
            get { return _isSelected; }

            set
            {
                if (value != _isSelected)
                {
                    if (value)
                    { IsExpanded = _saveIsExpanded; }
                    else
                    {
                        _saveIsExpanded = _isExpanded;
                        IsExpanded = false;
                    }

                    _isSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }

        }

        public bool IsExpanded
        {
            get { return _isExpanded; }

            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    NotifyPropertyChanged("IsExpanded");
                }
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
