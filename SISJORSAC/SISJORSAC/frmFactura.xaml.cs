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
        double subtotal = 0;
        double total = 0;
        double IGV = 0.18;
        double igvMonto = 0;

        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        FacturaDAO facturaDao = new FacturaDAO();
        public frmFactura()
        {
            InitializeComponent();
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            this.txtNroFactura.Text =facturaDao.ObtenerNroFactura()+1;
            ListarClientes();
            ListarServicios();

        }


       
        private void dgvListado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
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


        private void AgregarFactura()
        {
            Factura factura = new Factura();
            factura.MODALIDAD = ((ComboBoxItem)this.cboModalidad.SelectedItem).Content.ToString();
            factura.SUB_TOTAL = subtotal;
            factura.IGV = igvMonto;
            factura.FECHA_EMISION = DateTime.Now;
            factura.cliente = cliente;
            factura.guiaRemision = null;
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

        private void btnGenerarFactura_Click(object sender, RoutedEventArgs e)
        {
            AgregarFactura();
        }


        
       
      
    }
}
