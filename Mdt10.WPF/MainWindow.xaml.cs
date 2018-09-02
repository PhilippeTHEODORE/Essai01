using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Mdt10.Metier;
using Mdt10.Metier.Entites;
using Mdt10.Metier.Vues;
using Mdt10.Metier.DataInterfaces;

namespace Mdt10.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Windsor.Init();
            Windsor.GetObjet<IMediaDaoEntite>();
            Windsor.GetObjet<ILivreDaoEntite>();
            Windsor.GetObjet<IExemplaireDaoEntite>();

            InitializeComponent();
        }

        private void DeActiver_Click(object sender, RoutedEventArgs e)
        {

            Livre livre = new Livre { Auteur = "auteur", Titre = "Titre", Editeur = "Editeur" };

            LivreContext livreContext = new LivreContext { Livre = livre };

            Mdt10.WPF.ViewModel.MainWindowViewModel aaa = (Mdt10.WPF.ViewModel.MainWindowViewModel)ListeLivres.DataContext;

            aaa.LivresContext.Add(livreContext);

        }


        private void ListeLivres_SelectionChanged(object sender, RoutedEventArgs e)
        {

            var x = ListeLivres.Items.SourceCollection;

            var y = ((LivreContext)ListeLivres.SelectedItem);

            foreach (LivreContext lc in x)
            {
              lc.IsSelected = false;
            }

            y.IsSelected = true;

        }

    }
}
