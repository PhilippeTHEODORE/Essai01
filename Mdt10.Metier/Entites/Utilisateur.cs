using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mdt10.Metier.Entites
{
    public class Utilisateur : Entite
    {
        public virtual string Identifiant { get; set; }
        public virtual string MotDePasse { get; set; }
        public virtual string Roles { get; set; }
    }
}
