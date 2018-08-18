using System;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using System.Collections.Generic;

namespace Mdt10.Metier.DataInterfaces
{
    public interface IDaoSession
    {
        string Utilisateur {get; set;}
        void BeginTransactionDao();
        void CommitTransactionDao();
        void RollbackTransactionDao();
        void InitShchema();
        void ClearCache();
    }
}
