using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mdt10.Metier.Enums;

namespace Mdt10.Metier.Sorting
{
    public class SortingProperty<T>
    {
        public string DataPropertyName { get; set; }
        public SortingDirections SortingDirection { get; set; }
        public ComparePropertieGeneric<T> ComparePropertie { get; set; }
    }
}
