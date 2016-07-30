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
    /// Lógica de interacción para FrmGuiaRemision.xaml
    /// </summary>
    public partial class FrmGuiaRemision : MetroWindow
    {

        List<DetalleGuiaRemision> listaDetalleGuiaRemision = new List<DetalleGuiaRemision>();
        UbigeoDAO ubigeoDAO = new UbigeoDAO();
        ClienteDAO clienteDAO = new ClienteDAO();
        GuiaRemisionDAO guiaDAO = new GuiaRemisionDAO();
        Cliente cliente = new Cliente();
        ServicioDAO servicioDAO = new ServicioDAO();
        string nuevoid = "";
        int item = 1;
        string nuevoidProvincia = "";
        public FrmGuiaRemision()
        {
            InitializeComponent();
            this.txtPtoPartida.Text = "Av. SANTIAGO DE SURCO 4676 - URB. SAN ROQUE, SURCO";
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            string nroGuia =guiaDAO.traerUltimoNroGuia();
            llenarDepartamentos();
            this.txtNroGuiaRemision.Text = nroGuia;
            Listarservicios("DISPONIBLE");
            this.cboCliente.IsEnabled = false;                       
        }
        private void Listarservicios(string estado)
        {
            var listaServicios = servicioDAO.listarServicio(estado);
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";
            this.cboServicio.SelectedIndex = 0;
        }

        private void ListarClientes(string tipoCliente)
        {
            var listacliente = clienteDAO.ListarCliente(tipoCliente);
            this.cboCliente.ItemsSource = listacliente;
            if(tipoCliente.Equals("JURIDICA")){
            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            }
            else { 
             this.cboCliente.DisplayMemberPath = "NOMBRES";
            this.cboCliente.SelectedValuePath = "COD_CLI";
            }
        }

        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDNIRUC.Text = "";
            this.lblDNIRUC.Content = "DNI:";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
           
            
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDNIRUC.Text= "";
            this.lblDNIRUC.Content = "RUC:";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());            
            
        }

        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {

            }
            else {
                VariablesGlobales.indexCliente = this.cboCliente.SelectedIndex;
            int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
            cliente = clienteDAO.ObtenerCliente(codCliente);
            if (cliente.TIPO_CLIE.Equals("NATURAL"))
            {
                this.txtDNIRUC.Text = cliente.DNI;                
            }
            else
            {               
                this.txtDNIRUC.Text = cliente.RUC;
            }
            }
            
        }


        private void llenarDepartamentos()
        {
            var listaDepartamentos = ubigeoDAO.llenarDepartamentos();
            this.cboDepartamento.ItemsSource = listaDepartamentos;
            this.cboDepartamento.DisplayMemberPath = "Departamento";
            this.cboDepartamento.SelectedValuePath = "IdUbigeo";           
        }

        private void llenarProvincias(string idprovincia)
        {
            var listaProvincias = ubigeoDAO.llenarProvincias(idprovincia);
            this.cboProvincia.ItemsSource = listaProvincias;
            this.cboProvincia.DisplayMemberPath = "Provincia";
            this.cboProvincia.SelectedValuePath = "IdUbigeo";
        }

        private void llenarDistritos(string idprovincia,string idDepartamento)
        {
            var listaDistritos = ubigeoDAO.llenarDistritos(idprovincia,idDepartamento);
            this.cboDistrito.ItemsSource = listaDistritos;
            this.cboDistrito.DisplayMemberPath = "Distrito";
            this.cboDistrito.SelectedValuePath = "IdUbigeo";
        }

        private void cboDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idDepartamento =this.cboDepartamento.SelectedValue.ToString();
          //  string nuevoid =  Mid(idDepartamento, 1, 2);
            nuevoid = idDepartamento.Substring(0, 2);
           llenarProvincias(nuevoid);
            
        }

        private void cboProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboProvincia.SelectedIndex == -1)
            {

            }
            else
            {
                string idProvincia = this.cboProvincia.SelectedValue.ToString();
                string hola = nuevoid;
                nuevoidProvincia = idProvincia.Substring(2, 2);
                llenarDistritos(nuevoid, nuevoidProvincia);
            }
          
        }

        private DetalleGuiaRemision AgregarDetallesGuiaButton()
        {
            DetalleGuiaRemision detalle = new DetalleGuiaRemision();
            
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidadServicio.Text);
            double precio = Convert.ToDouble(this.txtPrecioServicio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.ITEM = item;

            listaDetalleGuiaRemision.Add(detalle);

            item++;
            return detalle;
        
        }

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var servicio = servicioDAO.ObtenerServicio(int.Parse(cboServicio.SelectedValue.ToString()));
            this.txtPrecioServicio.Text = servicio.PRECIO.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var detalle = AgregarDetallesGuiaButton();
            dgvDetalleGuia.Items.Add(detalle);
        }

        private void agregarGuiaRemision()
        {
            GuiaRemision guiaRemision = new GuiaRemision();
            guiaRemision.PTO_PARTIDA = this.txtPtoPartida.Text;
            guiaRemision.PTO_LLEGADA = this.txtptoLlegada.Text;
            guiaRemision.FECHA_EMISION =Convert.ToDateTime(this.txtFechaEmision.Text);
            guiaRemision.cliente = cliente;
            guiaRemision.VEHICULO_MARCA = this.txtVehiculoMarca.Text;
            guiaRemision.NONBRE_CONDUCTOR = this.txtNombreConductor.Text;
            guiaRemision.NRO_CERTIFICADO = this.txtNroCertificado.Text;
            guiaRemision.NRO_BREVETE = this.txtNroBrevete.Text;
            //transportista:
            guiaRemision.NOMB_TRANSPORTE = this.txtNombreTransporte.Text;
            guiaRemision.RUC_TRANSPORTE = this.txtRUC.Text.Trim();
            guiaRemision.TIPO_TRASLADO = ((ComboBoxItem)cboTipoTraslado.SelectedItem).Content.ToString();
            guiaRemision.MTO_TRASLADO = this.txtMotivoTraslado.Text;
            //Direcciones:
            guiaRemision.DEPARTAMENTO = cboDepartamento.Text.ToString();
            guiaRemision.PROVINCIA = cboProvincia.Text.ToString();
            guiaRemision.DISTRITO = cboDistrito.Text.ToString();
            guiaRemision.SITUACION = "GENERADA";
            guiaRemision.DETALLEGUIAREMISION = listaDetalleGuiaRemision;
            //tipo
            guiaRemision.TIPO_COMPROB = "FACTURA";
            guiaDAO.Agregar(guiaRemision);
            MessageBox.Show("Agregado Correctamente", "Gracias");
           
        }

        private void btnAgregarGuiaFinal_Click(object sender, RoutedEventArgs e)
        {
            agregarGuiaRemision();
        }

        private void btnBotonPrueba_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((ComboBoxItem)cboTipoTraslado.SelectedItem).Content.ToString());
            MessageBox.Show(cboDepartamento.Text.ToString());
        }




    }
}
