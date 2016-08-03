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
    /// Lógica de interacción para FrmClienteRegistro.xaml
    /// </summary>
    public partial class FrmClienteRegistro : MetroWindow
    {

        ClienteDAO clienteDAO = new ClienteDAO();
        UbigeoDAO ubigeoDAO = new UbigeoDAO();
        string nuevoid = "";
        string nuevoidProvincia = "";
        public FrmClienteRegistro()
        {
            InitializeComponent();
        }
        private void limpiarTodosLosControles()
        {
            txtNombre.Text = "";
            txtAPPaterno.Text = "";
            txtAPMaterno.Text = "";
            txtDocumento.Text = ""; txtDireccion.Text = "";
            txtRazonSocial.Text = "";
            txtTelfFijoCasa.Text = "";
            txtTelfFijoOficina.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtObservaciones.Text = "";
            cboDepartamento.SelectedIndex = -1;
            cboProvincia.SelectedIndex = -1;
            cboDistrito.SelectedIndex = -1;
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

        private void llenarDistritos(string idprovincia, string idDepartamento)
        {
            var listaDistritos = ubigeoDAO.llenarDistritos(idprovincia, idDepartamento);
            this.cboDistrito.ItemsSource = listaDistritos;
            this.cboDistrito.DisplayMemberPath = "Distrito";
            this.cboDistrito.SelectedValuePath = "IdUbigeo";
        }
        private void BloquearTodosLosControles()
        {
            txtNombre.IsEnabled = false;
            txtAPPaterno.IsEnabled = false;
            txtAPMaterno.IsEnabled = false;
            txtDocumento.IsEnabled = false; txtDireccion.IsEnabled = false;
            txtRazonSocial.IsEnabled = false;
            txtTelfFijoCasa.IsEnabled = false;
            txtTelfFijoOficina.IsEnabled = false;
            txtCelular.IsEnabled = false;
            txtEmail.IsEnabled = false;
            txtObservaciones.IsEnabled = false;
            cboDepartamento.IsEnabled = false;
            cboProvincia.IsEnabled = false;
            cboDistrito.IsEnabled = false;
        }
        private void Clientesss_Loaded(object sender, RoutedEventArgs e)
        {
            llenarDepartamentos();
            BloquearTodosLosControles();
        }

        private void activarParaNaturales()
        {
            txtRazonSocial.BorderBrush = Brushes.Transparent;
            txtTelfFijoOficina.BorderBrush = Brushes.Transparent;
            txtEmail.BorderBrush = Brushes.Transparent;
            txtDireccion.BorderBrush = Brushes.Transparent;
            txtDocumento.BorderBrush = Brushes.Transparent;
            BloquearTodosLosControles();
            lblTipoDocumento.Content = "DNI:";
            txtNombre.IsEnabled = true;
            txtAPPaterno.IsEnabled = true;
            txtAPMaterno.IsEnabled = true;
            txtDocumento.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtTelfFijoCasa.IsEnabled = true;
            txtCelular.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtObservaciones.IsEnabled = true;
            cboDepartamento.IsEnabled = true;
            txtNombre.BorderBrush = Brushes.SkyBlue;
            txtAPPaterno.BorderBrush = Brushes.SkyBlue;
            txtAPMaterno.BorderBrush = Brushes.SkyBlue;
            txtDocumento.BorderBrush = Brushes.SkyBlue;
            txtDireccion.BorderBrush = Brushes.SkyBlue;
            txtTelfFijoCasa.BorderBrush = Brushes.SkyBlue;
            txtCelular.BorderBrush = Brushes.SkyBlue;
            txtEmail.BorderBrush = Brushes.SkyBlue;
            txtObservaciones.BorderBrush = Brushes.SkyBlue;
        }

        private void activarParaJuridicas()
        {
            txtNombre.BorderBrush = Brushes.Transparent;
            txtAPPaterno.BorderBrush = Brushes.Transparent;
            txtAPMaterno.BorderBrush = Brushes.Transparent;
            txtTelfFijoCasa.BorderBrush = Brushes.Transparent;
            txtCelular.BorderBrush = Brushes.Transparent;
            txtObservaciones.BorderBrush = Brushes.Transparent;
            BloquearTodosLosControles();
            lblTipoDocumento.Content = "RUC:";
            txtDocumento.IsEnabled = true;
            txtDireccion.IsEnabled = true;
            txtRazonSocial.IsEnabled = true;
            txtTelfFijoOficina.IsEnabled = true;
            txtEmail.IsEnabled = true;
            txtObservaciones.IsEnabled = true;
            cboDepartamento.IsEnabled = true;
            txtRazonSocial.BorderBrush = Brushes.SkyBlue;
            txtTelfFijoOficina.BorderBrush = Brushes.SkyBlue;
            txtEmail.BorderBrush = Brushes.SkyBlue;
            txtDireccion.BorderBrush = Brushes.SkyBlue;
            txtDocumento.BorderBrush = Brushes.SkyBlue;
            txtObservaciones.BorderBrush = Brushes.SkyBlue;
        }
        private void rdNATUTAL_Checked(object sender, RoutedEventArgs e)
        {
            limpiarTodosLosControles();
            activarParaNaturales();
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            limpiarTodosLosControles();
            activarParaJuridicas();
        }

        private void cboDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboDepartamento.SelectedIndex == -1)
            {

            }
            else
            {
                string idDepartamento = this.cboDepartamento.SelectedValue.ToString();
                //  string nuevoid =  Mid(idDepartamento, 1, 2);
                nuevoid = idDepartamento.Substring(0, 2);
                llenarProvincias(nuevoid);
                cboProvincia.IsEnabled = true;
            }

        }

        private void cboProvincia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cboDistrito.IsEnabled = true;
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

        private async void btnCrearCliente_Click(object sender, RoutedEventArgs e)
        {


            if (rdNATUTAL.IsChecked == true || rbJURIDICA.IsChecked == true)
            {
                string resul = "";
                Cliente clienteAgregar = new Cliente();
                if (rdNATUTAL.IsChecked == true)
                {
                    if (txtNombre.Text.Trim() != "" && txtAPMaterno.Text.Trim() != "" && txtDocumento.Text.Trim() != "" && cboDepartamento.SelectedItem != null && cboProvincia.SelectedItem != null && cboDistrito.SelectedItem != null)
                    {
                        clienteAgregar.NOMBRES = txtNombre.Text;
                        clienteAgregar.AP_PATERNO = txtAPPaterno.Text;
                        clienteAgregar.AP_MATERNO = txtAPMaterno.Text;
                        clienteAgregar.DNI = txtDocumento.Text.Trim();
                        clienteAgregar.DIRECCION = txtDireccion.Text;
                        clienteAgregar.DEPARTAMENTO = cboDepartamento.Text.ToString();
                        clienteAgregar.PROVINCIA = cboProvincia.Text.ToString();
                        clienteAgregar.DISTRITO = cboDistrito.Text.ToString();
                        clienteAgregar.TEL_FIJO_CASA = txtTelfFijoCasa.Text;
                        clienteAgregar.CELULAR = txtCelular.Text;
                        clienteAgregar.EMAIL = txtEmail.Text;
                        clienteAgregar.OBSERVACIONES = txtObservaciones.Text;
                        clienteAgregar.TIPO_CLIE = rdNATUTAL.Content.ToString();
                        resul = clienteDAO.Agregar(clienteAgregar);
                        if (resul.Equals("Agregado"))
                            await this.ShowMessageAsync(resul, "Cliente  : " + clienteAgregar.NOMBRES + " , " + clienteAgregar.AP_PATERNO + " , agregado Correctamente");
                        else
                            await this.ShowMessageAsync(resul, "¡Lamentablemente ocurrió un error al Agregar!");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "¡Falta llenar algunos campos!");
                        return;
                    }


                }
                else if (rbJURIDICA.IsChecked == true)
                {
                    if (txtRazonSocial.Text.Trim() != "" && txtDocumento.Text.Trim() != "" && cboDepartamento.SelectedItem != null && cboProvincia.SelectedItem != null && cboDistrito.SelectedItem != null)
                    {
                        clienteAgregar.RUC = txtDocumento.Text.Trim();
                        clienteAgregar.RAZON_SOCIAL = txtRazonSocial.Text;
                        clienteAgregar.DIRECCION = txtDireccion.Text;
                        clienteAgregar.DEPARTAMENTO = cboDepartamento.Text.ToString();
                        clienteAgregar.PROVINCIA = cboProvincia.Text.ToString();
                        clienteAgregar.DISTRITO = cboDistrito.Text.ToString();
                        clienteAgregar.TEL_FIJO_OFICINA = txtTelfFijoOficina.Text;
                        clienteAgregar.EMAIL = txtEmail.Text;
                        clienteAgregar.OBSERVACIONES = txtObservaciones.Text;
                        clienteAgregar.TIPO_CLIE = rbJURIDICA.Content.ToString();
                        resul = clienteDAO.Agregar(clienteAgregar);
                        if (resul.Equals("Agregado"))
                            await this.ShowMessageAsync(resul, "Cliente :   " + clienteAgregar.RAZON_SOCIAL + " , agregado correctamente");
                        else
                            await this.ShowMessageAsync(resul, "¡Lamentablemente ocurrió un error al Agregar!");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "¡Falta llenar algunos campos!");
                        return;
                    }


                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Debe seleccionar un tipo de cliente para comenzar con el Registro");
                return;
            }

        }

        private void btnLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            limpiarTodo(Clientesss);
            BloquearTodosLosControles();
        }

        public void limpiarTodo(Grid Formulario)
        {
                    foreach (object c in Formulario.Children)
                    {
                        if (c is TextBox)
                        {
                            (c as TextBox).Text = String.Empty;

                        }
                        if (c is ComboBox)
                        {
                            (c as ComboBox).SelectedIndex = -1;
                        }
                        if( c is RadioButton)
                        {
                            (c as RadioButton).IsChecked = false;
                        }
                    }
       }
    }
}
