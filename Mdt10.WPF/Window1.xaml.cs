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
using System.Windows.Shapes;

using Mdt10.WPF.Tools;

namespace Mdt10.WPF
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private ModelTool mdlTool = new ModelTool();

        public Window1()
        {
            InitializeComponent();

            var usr = new Mdt10.WPF.UserControl.CornerControl(mdlTool);
            Emplacement.Children.Add(usr);
        }

        private void Activer_Click(object sender, RoutedEventArgs e)
        {
            mdlTool.UserControlActiver(true, "Activer");
        }

        private void DeActiver_Click(object sender, RoutedEventArgs e)
        {
            mdlTool.UserControlActiver(false, "DeActiver");
        }
    }
}
