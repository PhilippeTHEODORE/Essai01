using System;
using System.Collections.Generic;
using Mdt10.Metier.Enums;
using Mdt10.Metier.Sorting;

namespace Mdt10.Metier.DataInterfaces
{
    public interface IDaoVue<T>
    {
        List<T> GetVue(Dictionary<string, string> parameters);
        List<T> Sort(List<T> list, List<SortingProperty<T>> sortingProperties);
        string GetIdColumnName();
    }
}
