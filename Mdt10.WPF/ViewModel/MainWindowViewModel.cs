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
        private ILivreDaoEntite daoLivres = Windsor.GetObjet<ILivreDaoEntite>();
        private IExemplaireDaoEntite daoExemplaires = Windsor.GetObjet<IExemplaireDaoEntite>();

        private List<Livre> _listeLivres;
        private List<Exemplaire> _listeExemplaires;

        private List<LivreContext> _livres;

        public MainWindowViewModel()
        {
            _listeLivres = daoLivres.GetAll();
            _listeExemplaires = daoExemplaires.GetAll();

            _livres = _listeLivres.Select(livre => new LivreContext 
                { 
                    Livre = livre, 
                    Exemplaires = _listeExemplaires.Select(exemplaire => exemplaire).Where(exemplaire => exemplaire.Document.Id == livre.Id).ToList() 
                }
            ).ToList();
        }


        public IList<LivreContext> LivresContext
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



