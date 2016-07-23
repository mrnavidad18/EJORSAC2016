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
using SISJORSAC.Reportes;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para Menu.xaml
    /// </summary>
    public partial class Menu : MetroWindow
    {
        public Menu()
        {
            InitializeComponent();
        }

        private  void ItemFactura_Click(object sender, RoutedEventArgs e)
        {
            ElegirFactura _frmelegir = new ElegirFactura();
            _frmelegir.Owner = this;
            _frmelegir.Show();
        }

        private void ItemCliente_Click(object sender, RoutedEventArgs e)
        {
            FRTipoCliente frmtipoclienteReport = new FRTipoCliente();
            frmtipoclienteReport.Owner = this;
            frmtipoclienteReport.ShowDialog();
        }



        private void ItemGuiaRemision_Click(object sender, RoutedEventArgs e)
        {
            FrmGuiaRemision FrmGuiaRemision = new FrmGuiaRemision();
            FrmGuiaRemision.Owner = this;
            FrmGuiaRemision.ShowDialog();
        }




    }
}
