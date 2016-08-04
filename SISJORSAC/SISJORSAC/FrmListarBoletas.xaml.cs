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
    /// Lógica de interacción para FrmListarBoletas.xaml
    /// </summary>
    public partial class FrmListarBoletas : MetroWindow
    {
        BoletaDAO boletaDao = new BoletaDAO();
        ClienteDAO clienteDao=new ClienteDAO();
        public FrmListarBoletas()
        {
            InitializeComponent();
            ListarBoletas();
            ListarClientes();
            
        }

        private void ListarBoletas()
        {


            var lista = boletaDao.ListarBoletasConClientes("ACTIVO");

            this.dgvListado.ItemsSource = lista;
        }

        private void txtNroComp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                string nroBoleta = t.Text;
                var lista = boletaDao.BuscarBoletasNroBoleta(nroBoleta);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = lista;
            }
        }

        private async void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (this.dgvListado.SelectedItem != null)
            {
                var boleta = this.dgvListado.SelectedItem as Boleta;
                FrmVerDetalleBoleta detalle = new FrmVerDetalleBoleta();
                detalle.nroBoleta = boleta.NRO_BOLETA;
                detalle.ShowDialog();
            }
            else
            {
                await this.ShowMessageAsync("ERROR","Por favor elija una factura");
            }
        }

        private void ListarClientes()
        {
            try
            {
                var listacliente = clienteDao.ListarCliente("TODOS");

                this.cboCliente.ItemsSource = listacliente;
                this.cboCliente.DisplayMemberPath = "NOMBRES";
                this.cboCliente.SelectedValuePath = "COD_CLI";
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }
            
        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
                var cliente = clienteDao.ObtenerCliente(codCliente);
                var listado = boletaDao.BuscarBoletasXCliente(codCliente);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = listado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void txtFechaDe_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            this.txtFechaHasta.IsEnabled = true;
        }

        private void txtFechaHasta_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DateTime fechaDe = Convert.ToDateTime(this.txtFechaDe.SelectedDate);

                DateTime fechaHasta = Convert.ToDateTime(this.txtFechaHasta.SelectedDate);

                var listado = boletaDao.BuscarBoletasXFechas(fechaDe, fechaHasta);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = listado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
        }
    }
}
