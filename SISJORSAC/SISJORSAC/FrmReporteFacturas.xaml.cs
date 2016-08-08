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
    /// Lógica de interacción para FrmReporteFacturas.xaml
    /// </summary>
    public partial class FrmReporteFacturas : MetroWindow
    {
        public FrmReporteFacturas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime fechaDe = Convert.ToDateTime(this.txtFechaDe.SelectedDate);

            DateTime fechaHasta = Convert.ToDateTime(this.txtFechaHasta.SelectedDate);

            FrnReporFacturas reporteFacturas = new FrnReporFacturas();

            reporteFacturas.fechaDe = fechaDe;
            reporteFacturas.fechaHasta = fechaHasta;

            reporteFacturas.ShowDialog();

        }
    }
}
