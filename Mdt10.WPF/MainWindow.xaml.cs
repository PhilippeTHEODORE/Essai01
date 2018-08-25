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
            ///////


            Windsor.Init();
            Windsor.GetObjet<IMediaDaoEntite>();
            Windsor.GetObjet<ILivreDaoEntite>();
            Windsor.GetObjet<IExemplaireDaoEntite>();

            InitializeComponent();
        }




    }
}
