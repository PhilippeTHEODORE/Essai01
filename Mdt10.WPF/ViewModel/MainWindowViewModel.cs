using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

using Mdt10.Metier;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using Mdt10.Metier.DataInterfaces;

using System.Collections.ObjectModel;
using System.Windows;

namespace Mdt10.WPF.ViewModel
{
    public class MainWindowViewModel
    {

        ILivreDaoEntite dao = Windsor.GetObjet<ILivreDaoEntite>();

        public List<Livre> _listeLivres;


        public MainWindowViewModel()
        {
            _listeLivres = dao.GetAll();
        }

        public List<Livre> ListeLivres
        {
            get { return _listeLivres; }
        }

    }
}
