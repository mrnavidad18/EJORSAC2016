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

       
        private  async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.txtFechaDe.SelectedDate == null || this.txtFechaHasta.SelectedDate == null)
            {
                await this.ShowMessageAsync("Error", "Seleccione el rango de fechas para continuar");
                return;
            }
            DateTime fechaDe = Convert.ToDateTime(this.txtFechaDe.SelectedDate);
            DateTime fechaHasta = Convert.ToDateTime(this.txtFechaHasta.SelectedDate);
                       
            string res = SeleccionarCombo();
            if (this.cboComprobante.SelectedItem != null)
            {
                if (res == "FACTURA")
                {
                    FrnReporFacturas reporteFacturas = new FrnReporFacturas();
                    reporteFacturas.fechaDe = fechaDe;
                    reporteFacturas.fechaHasta = fechaHasta;
                    reporteFacturas.ShowDialog();
                }
                else if (res == "BOLETA")
                {
                    FrmReportBoleta reporBoleta = new FrmReportBoleta();
                    reporBoleta.FechaDe = fechaDe;
                    reporBoleta.FechaHasta = fechaHasta;
                    reporBoleta.ShowDialog();
                }
                else if (res == "GUIA REMISION")
                {
                    FrmReportGuia reporte = new FrmReportGuia();
                    reporte.FechaDe = fechaDe;
                    reporte.FechaHasta = fechaHasta;
                    reporte.ShowDialog();
                }
                else if (res == "CONTRATO ALQUILER")
                {
                    FrmReportContrato reporte = new FrmReportContrato();
                    reporte.FechaDe = fechaDe;
                    reporte.FechaHasta = fechaHasta;
                    reporte.ShowDialog();
                }
                else if (res == "EGRESOS")
                {
                    FrmReportGasto reporte = new FrmReportGasto();
                    reporte.FechaDe = fechaDe;
                    reporte.FechaHasta = fechaHasta;
                    reporte.ShowDialog();
                }
            }
            else
            {
                await this.ShowMessageAsync("ERROR","ESCOJE EL TIPO DE COMPROBANTE");
            }
           

          

        }

        private string SeleccionarCombo()
        {
            return ((ComboBoxItem)this.cboComprobante.SelectedItem).Content.ToString();
          
        }
    }
}
