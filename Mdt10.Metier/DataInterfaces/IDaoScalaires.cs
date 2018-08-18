using System;
using System.Collections.Generic;

namespace Mdt10.Metier.DataInterfaces
{
    public interface IDaoScalaireGetLastCote : IDaoScalaire<string, int> { }
    
    public interface IDaoScalaireGetDateFirstExemplaire : IDaoScalaire<int, DateTime?> { }
}
