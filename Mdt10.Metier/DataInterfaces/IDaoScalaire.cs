using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.DataInterfaces
{
    public interface IDaoScalaire<T, U>
    // T est le paramètre d'appel, type valeur ou type référence
    // U est la valeur de retour, type valeur ou type référence
    {
        U GetScalaire(T parametre);
    }
}
