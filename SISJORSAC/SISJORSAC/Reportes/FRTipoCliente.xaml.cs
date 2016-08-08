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

namespace SISJORSAC.Reportes
{
    /// <summary>
    /// Lógica de interacción para FRTipoCliente.xaml
    /// </summary>
    public partial class FRTipoCliente : MetroWindow
    {
        public FRTipoCliente()
        {
           
            InitializeComponent();
        }

        private async void btnReportCliente_Click(object sender, RoutedEventArgs e)
        {
            //ReporteClientesNaturales rn = new ReporteClientesNaturales();
            //ReporteClientesJuridicos rj = new ReporteClientesJuridicos();
            //int op = cboRTipoCiente.SelectedIndex;
            //if (op == 0)
            //{
            //    await this.ShowMessageAsync("Fallo", "Elija una Opcion");
            //}

            //if (op == 1)
            //{
            //    rn.ShowDialog();
            //}

            //if (op == 2)
            //{
            //    rj.ShowDialog();
            //}

        }

        private void btnReportCliente_Loaded(object sender, RoutedEventArgs e)
        {
            cboRTipoCiente.SelectedIndex = 0;
        }
    }
}
