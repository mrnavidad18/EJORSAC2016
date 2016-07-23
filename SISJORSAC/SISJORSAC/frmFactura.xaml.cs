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
using SISJORSAC.DATA.Modelo;
using SISJORSAC.DATA.DAO;
namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interasdsdcción para frmFactura.xaml
    /// </summary>
    public partial class frmFactura : MetroWindow
    {
        List<DetalleFactura> listaDetalle = new List<DetalleFactura>();
        Cliente cliente;
        Servicio servicio;
        GuiaRemision guiaRemision;
        double subtotal = 0;
        double total = 0;
        double IGV = 0.18;
        double igvMonto = 0;

        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        FacturaDAO facturaDao = new FacturaDAO();
        GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
        public frmFactura()
        {
            InitializeComponent();
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            this.txtNroFactura.Text =facturaDao.ObtenerNroFactura().ToString();

            if (VariablesGlobales.NRO_GUIA_GLOBAL == "")
            {
                ListarClientes();
            }
            else
            {
                ObtenerGuia();
            }
           
            ListarServicios();
            

          
           

        }


        private  async void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

            if (this.cboServicio.SelectedItem != null && this.txtCantidad.Text.Trim() != "" && this.txtPrecio.Text.Trim() != "")
            {
                var detalle = AgregarDetalles();
                dgvListado.Items.Add(detalle);

                subtotal = subtotal + detalle.IMPORTE;
                this.txtSubtotal.Text = subtotal.ToString();

                igvMonto = subtotal * IGV;
                this.txtIgv.Text = igvMonto.ToString();

                total = subtotal + igvMonto;
                this.txtTotal.Text = total.ToString();

                this.txtCantidad.Text = "";
                this.txtPrecio.Text = "";
                this.cboServicio.SelectedIndex = 0;
            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
            }
             
           
        }


        private void AgregarFactura()
        {
            Factura factura = new Factura();
            factura.MODALIDAD = ((ComboBoxItem)this.cboModalidad.SelectedItem).Content.ToString();
            factura.SUB_TOTAL = subtotal;
            factura.IGV = igvMonto;
            factura.FECHA_EMISION = DateTime.Now;
            factura.cliente = cliente;
            if (this.txtNroGuia.Text == "")
            {
                factura.guiaRemision = null;
            }
            else
            {

                factura.guiaRemision = guiaRemision;
            }
            
            factura.DETALLEFACTURA = listaDetalle;
            factura.OBSERVACION = "dsdsdsds";
            facturaDao.AgregarFactura(factura);

        }

        private DetalleFactura AgregarDetalles()
        {
            
            DetalleFactura detalle = new DetalleFactura();
            
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidad.Text);
            double precio = Convert.ToDouble(this.txtPrecio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.PRECIO = precio;
          
            listaDetalle.Add(detalle);

            detalle.IMPORTE = cantidad * precio;

            return detalle;
        }

        private void ListarClientes()
        {
            
            var listacliente = clienteDao.ListarCliente("JURIDICA");
            
            this.cboRazonsocial.ItemsSource = listacliente;
            this.cboRazonsocial.DisplayMemberPath="RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
       

           
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("DISPONIBLE");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }

        private void cboRazonsocial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codCliente=Convert.ToInt32(this.cboRazonsocial.SelectedValue);
            cliente = clienteDao.ObtenerCliente(codCliente);
            this.txtDireccion.Text = cliente.DIRECCION;
            this.txtRuc.Text = cliente.RUC;
        }

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            servicio = servicioDAO.ObtenerServicio(codServicio);
            this.txtPrecio.Text = servicio.PRECIO.ToString();
        }

        private async void btnGenerarFactura_Click(object sender, RoutedEventArgs e)
        {

            if (this.txtNroFactura.Text.Trim() != "" && this.cboModalidad.SelectedItem != null && this.cboMoneda.SelectedItem != null ||
                this.cboRazonsocial.SelectedItem == null && this.cboServicio.SelectedItem != null && this.txtPrecio.Text.Trim() != ""
                && this.txtCantidad.Text.Trim() != "" )
            {
                if (this.dgvListado.Items.Count == 0)
                {
                    await this.ShowMessageAsync("Error", "Falta llenar detalles");
                }
                else
                {
                    if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar esta factura?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                    {
                        AgregarFactura();
                        this.Close();
                    }
                }

            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
            }

          
            

        }

        public void ObtenerGuia()
        {
          
             DetalleGuiaRemisionDAO detalleGuiaDao= new DetalleGuiaRemisionDAO();
             guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);
            var detalleGuia = detalleGuiaDao.listarDetalleGuiaxGuia(guiaRemision.COD_GUIA);
            this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboRazonsocial.SelectedValuePath = "COD_CLI";
       
            this.cboRazonsocial.Items.Add(guiaRemision.cliente);
            this.cboRazonsocial.SelectedIndex = 0;
            this.txtRuc.Text = guiaRemision.cliente.DNI;
            this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL.ToString();

            //foreach (var item in this.cboModalidad.Items)
            //{
                
            //        this.cboModalidad.Items.Remove((ComboBoxItem)item);
            //        this.cboModalidad.Items.Refresh();
                
                
            //}
            

            

            this.cboModalidad.IsEnabled = false;
            DetalleFactura detalleFactura = new DetalleFactura();

            foreach (var item in detalleGuia)
            {
                detalleFactura.CANTIDAD = item.CANTIDAD;
                detalleFactura.SERVICIO = item.SERVICIO;
                detalleFactura.PRECIO = item.SERVICIO.PRECIO;
                
                listaDetalle.Add(detalleFactura);
                detalleFactura.IMPORTE = item.CANTIDAD * item.SERVICIO.PRECIO;
                
                dgvListado.Items.Add(detalleFactura);
                subtotal = subtotal + detalleFactura.IMPORTE;
                

            }

            igvMonto = subtotal * IGV;
            total = subtotal + igvMonto;

            this.txtSubtotal.Text = subtotal.ToString();
            this.txtIgv.Text = igvMonto.ToString();
            this.txtTotal.Text = total.ToString();
           

          

        }

       


        
       
      
    }
}
