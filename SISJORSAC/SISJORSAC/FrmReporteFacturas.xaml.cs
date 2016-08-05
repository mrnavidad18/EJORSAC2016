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

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmReporteFacturas.xaml
    /// </summary>
    public partial class FrmReporteFacturas : Window
    {
        public FrmReporteFacturas()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime fechaDe = Convert.ToDateTime(this.txtFechaDe.SelectedDate);

            DateTime fechaHasta = Convert.ToDateTime(this.txtFechaHasta.SelectedDate);

            FrnReporteFacturas reporteFacturas = new FrnReporteFacturas();

            reporteFacturas.FechaDe = fechaDe;
            reporteFacturas.FechaHasta = fechaHasta;

            reporteFacturas.ShowDialog();

        }
    }
}
