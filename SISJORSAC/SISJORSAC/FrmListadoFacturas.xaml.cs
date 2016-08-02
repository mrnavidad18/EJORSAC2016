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
using SISJORSAC.DATA.DAO;
using SISJORSAC.DATA.Modelo;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para FrmListadoFacturas.xaml
    /// </summary>
    public partial class FrmListadoFacturas : MetroWindow
    {
        FacturaDAO facturaDao = new FacturaDAO();
        public FrmListadoFacturas()
        {
            InitializeComponent();
            ListarFacturas("ACTIVO");
        }


        private void ListarFacturas(string estado)
        {
            var lista = facturaDao.listarFacturas(estado);
            this.dgvListado.ItemsSource = lista;
        }

      

        private void txtNroComp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string nroFactura =t.Text;
                var lista = facturaDao.BuscarPorNroFactura(nroFactura);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = lista;
            }
        }

       
        private async void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvListado.SelectedItem != null)
            {
                var factura = this.dgvListado.SelectedItem as Factura;
                FrmVerDetalleFactura detalle = new FrmVerDetalleFactura();
                detalle.nroFacturea = factura.NRO_FACTURA;
                detalle.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("ERROR","Por favor elija una factura");
            }
           

        }
    }
}
