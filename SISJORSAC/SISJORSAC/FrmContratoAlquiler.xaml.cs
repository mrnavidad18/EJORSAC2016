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
    /// Lógica de interacción para FrmContratoAlquiler.xaml
    /// </summary>
    public partial class FrmContratoAlquiler : MetroWindow
    {
        Cliente cliente;
        Servicio servicio;
        GuiaRemision guiaRemision;
        double subtotal = 0;
        double total = 0;
        double IGV = 0.18;
        double igvMonto = 0;
        int item = 1;
        string mensaje = "";

        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        FacturaDAO facturaDao = new FacturaDAO();
        GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();

        public FrmContratoAlquiler()
        {
            InitializeComponent();
            
        }

        private void ListarClientes(string tipoCliente)
        {
            if (VariablesGlobales.NRO_GUIA_GLOBAL == "")
            {
                var listacliente = clienteDao.ListarCliente(tipoCliente);


                this.cboRazonsocial.ItemsSource = listacliente;
                if (tipoCliente.Equals("JURIDICA"))
                {
                    this.cboRazonsocial.DisplayMemberPath = "RAZON_SOCIAL";
                    this.cboRazonsocial.SelectedValuePath = "COD_CLI";
                   
                }
                else
                {
                    this.cboRazonsocial.DisplayMemberPath = "NOMBRES";
                    this.cboRazonsocial.SelectedValuePath = "COD_CLI";
                }
            }

        }
        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.txtTelf.Text = "";
            this.txtDireccion.Text = "";
            this.cboRazonsocial.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.txtTelf.Text = "";
            this.txtDireccion.Text = "";
            this.cboRazonsocial.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());
        }

        private void cboRazonsocial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cboRazonsocial.SelectedIndex == -1)
            {

            }
            else
            {
                int codCliente = Convert.ToInt32(this.cboRazonsocial.SelectedValue);
                cliente = clienteDao.ObtenerCliente(codCliente);
                if (cliente.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.txtDniRuc.Text = cliente.DNI;
                    this.txtTelf.Text = cliente.TEL_FIJO_CASA;
                }
                else
                {
                    this.txtDniRuc.Text = cliente.RUC;
                    this.txtTelf.Text = cliente.TEL_FIJO_OFICINA;
                }
                this.txtDireccion.Text = cliente.DIRECCION.ToString();
            }
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("DISPONIBLE");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }
    }
}
