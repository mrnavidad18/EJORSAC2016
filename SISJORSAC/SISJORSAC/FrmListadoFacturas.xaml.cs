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
        ClienteDAO clienteDao = new ClienteDAO();
        List<Factura> lista = new List<Factura>();
        Factura factura;
        public FrmListadoFacturas()
        {
            InitializeComponent();
            ListarFacturas("ACTIVO");
            ListarClientes();
        }


        private void ListarFacturas(string estado)
        {
            try
            {
                lista = facturaDao.listarFacturas(estado,"TODOS");
                
                this.dgvListado.ItemsSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
           
        }

      

        private void txtNroComp_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    TextBox t = (TextBox)sender;
                    string nroFactura = t.Text;
                    var lista = facturaDao.BuscarPorNroFactura(nroFactura);
                    this.dgvListado.ItemsSource = null;
                    this.dgvListado.ItemsSource = lista;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
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

     

     
        private void ListarClientes()
        {
            try
            {
                var listacliente = clienteDao.ListarCliente("JURIDICA");
                this.cboCliente.ItemsSource = listacliente;
                this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
                this.cboCliente.SelectedValuePath = "COD_CLI";
            }
            catch (Exception ex)
            {
                
                 MessageBox.Show(ex.Message,"Error");
            }
            
           



        }

        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
                var cliente = clienteDao.ObtenerCliente(codCliente);
                var listado = facturaDao.BuscarPorCliente(codCliente);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = listado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
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

                var listado = facturaDao.BuscarPorFechas(fechaDe, fechaHasta);
                this.dgvListado.ItemsSource = null;
                this.dgvListado.ItemsSource = listado;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error");
            }
            

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            this.txtNroComp.Text = "";
            this.cboCliente.SelectedIndex = -1;
            //this.txtFechaDe.SelectedDate = null;
            //this.txtFechaHasta.SelectedDate = null;
            this.dgvListado.ItemsSource = null;
            this.dgvListado.ItemsSource = lista;
        }

       

        

        private void cboEstado_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                string estad = ((ComboBoxItem)this.cboEstado.SelectedItem).Content.ToString();
                var lista = facturaDao.listarFacturas("ACTIVO", estad);
                this.dgvListado.ItemsSource = lista;



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "ERROR");
            }
        }

        private  async void btnAgregarPago_Click(object sender, RoutedEventArgs e)
        {

            if (this.dgvListado.SelectedItem != null)
            {
                 factura = this.dgvListado.SelectedItem as Factura;
                 if (factura.CANCELADO == "PENDIENTE")
                 {
                     this.txtAcuenta.Visibility = Visibility.Visible;
                     this.btnPagar.Visibility = Visibility.Visible;
                 }
                 else
                 {
                     await this.ShowMessageAsync("ERROR", "Esta factura ya esta cancelada");
                 }
            }
              else
            {
                await this.ShowMessageAsync("ERROR","Por favor elija una factura");
            }
           
        }

        private async void btnPagar_Click(object sender, RoutedEventArgs e)
        {
          
            if(this.txtAcuenta.Text.Trim()!="")
            {
                double acuenta = double.Parse(this.txtAcuenta.Text);
                factura.ACUENTA = acuenta;
                factura.SALDO = factura.SALDO - acuenta;
                if (factura.SALDO == 0)
                {
                    factura.CANCELADO = "CANCELADO";
                    await this.ShowMessageAsync("AVISO","LA FACTURA HA SIDO CANCELADA");
                    facturaDao.ActulizarSaldo(factura);
                }
                else
                {
                    await this.ShowMessageAsync("AVISO", "SE AGREGO UN PAGO DE: " + acuenta);
                    facturaDao.ActulizarSaldo(factura);
                }
                ListarFacturas("ACTIVO");
                this.txtAcuenta.Visibility = Visibility.Hidden;
                this.btnPagar.Visibility = Visibility.Hidden;
                    this.txtAcuenta.Text=string.Empty;
            }
        }


    }
}
