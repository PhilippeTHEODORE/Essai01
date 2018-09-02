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
using System.Windows.Controls;

namespace Mdt10.WPF.ViewModel
{
    public class MainWindowViewModel
    {
        private ILivreDaoEntite daoLivres = Windsor.GetObjet<ILivreDaoEntite>();
        private IExemplaireDaoEntite daoExemplaires = Windsor.GetObjet<IExemplaireDaoEntite>();

        private List<Livre> _listeLivres;
        private List<Exemplaire> _listeExemplaires;

        private ObservableCollection<LivreContext> _livres;

        public MainWindowViewModel()
        {
            _listeLivres = daoLivres.GetAll();
            _listeExemplaires = daoExemplaires.GetAll();

            _livres = new ObservableCollection<LivreContext>(_listeLivres.Select(livre => new LivreContext
                {
                    IsSelected = false,
                    Livre = livre,
                    Exemplaires = _listeExemplaires.Select(exemplaire => exemplaire).Where(exemplaire => exemplaire.Document.Id == livre.Id).ToList()
                }
            ).ToList());

            //_livres[0].IsSelected = true;
        }

        public ObservableCollection<LivreContext> LivresContext
        {
            get { return _livres; }
        }

        public List<Livre> ListeLivres
        {
            get { return _listeLivres; }
        }

        public List<Exemplaire> ListeExemplaires
        {
            get { return _listeExemplaires; }
        }


    }



}



