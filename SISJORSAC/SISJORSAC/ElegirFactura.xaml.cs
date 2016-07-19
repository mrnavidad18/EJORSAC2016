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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para ElegirFactura.xaml
    /// </summary>
    public partial class ElegirFactura : MetroWindow
    {
        public ElegirFactura()
        {
            InitializeComponent();
        }

        private void rbtConGuia_Checked(object sender, RoutedEventArgs e)
        {
            this.txtnroGuia.Visibility = Visibility.Visible;
            this.btnIngresar.Visibility = Visibility.Visible;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            frmFactura factura = new frmFactura();
            this.Close();
            factura.ShowDialog();
        }
    }
}
