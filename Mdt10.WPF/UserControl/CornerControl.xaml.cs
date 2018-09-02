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
using Mdt10.WPF.Tools;

namespace Mdt10.WPF.UserControl
{
    /// <summary>
    /// Logique d'interaction pour CornerControl.xaml
    /// </summary>
    public partial class CornerControl : System.Windows.Controls.UserControl
    {

        private bool mode = false;
        private ModelTool _modelTool;

        public CornerControl()
        {
            InitializeComponent();
        }

        public CornerControl(ModelTool modelTool)
        {
            InitializeComponent();
            _modelTool = modelTool;
            modelTool.UserControlActiver = fnt;
            fnt(false, "");
        }

        private void BtnHaF_Click(object sender, RoutedEventArgs e)
        {
            if (mode)
                BtnHaF.IsChecked = true;
        }

        private void fnt(bool b, string s)
        {
            mode = b;

            if (b)
            {
                BtnHaF.IsChecked = true;
                TxtHaF.Text = "Halte au Feu";
                this.IsEnabled = true;
            }
            else
            {
                this.IsEnabled = false;
                TxtHaF.Text = "";
            }

        }
    }
}
