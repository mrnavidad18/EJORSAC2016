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
    /// Lógica de interacción para FrmProveedor.xaml
    /// </summary>
    public partial class FrmProveedor : MetroWindow
    {

        ProveedorDAO proveedorDAO = new ProveedorDAO();
        UbigeoDAO ubigeoDAO = new UbigeoDAO();
        string nuevoid = "";
        string nuevoidProvincia = "";
        public FrmProveedor()
        {
            InitializeComponent();
            BloquearTodosLosControles();
            llenarDepartamentos();
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
                Proveedor proveedor = new Proveedor();
                string resul = "";

                if (rdNATUTAL.IsChecked == true)
                {
                    if (txtNombre.Text.Trim() != "" && txtAPMaterno.Text.Trim() != "" && txtDocumento.Text.Trim() != "" && cboDepartamento.SelectedItem != null && cboProvincia.SelectedItem != null && cboDistrito.SelectedItem != null)
                    {
                        proveedor.NOMBRES = txtNombre.Text;
                        proveedor.AP_PATERNO = txtAPPaterno.Text;
                        proveedor.AP_MATERNO = txtAPMaterno.Text;
                        proveedor.DNI = txtDocumento.Text.Trim();
                        proveedor.DIRECCION = txtDireccion.Text;
                        proveedor.DEPARTAMENTO = cboDepartamento.Text.ToString();
                        proveedor.PROVINCIA = cboProvincia.Text.ToString();
                        proveedor.DISTRITO = cboDistrito.Text.ToString();
                        proveedor.TELF_FIJO_CASA = txtTelfFijoCasa.Text;
                        proveedor.CELULAR = txtCelular.Text;
                        proveedor.EMAIL = txtEmail.Text;
                        proveedor.OBSERVACIONES = txtObservaciones.Text;
                        proveedor.TIPO_PRO = rdNATUTAL.Content.ToString();
                        resul = proveedorDAO.Agregar(proveedor);
                        if (resul.Equals("Agregado"))
                            await this.ShowMessageAsync(resul, "Cliente  : " + proveedor.NOMBRES + " , " + proveedor.AP_PATERNO + " , agregado Correctamente");
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
                        proveedor.RUC = txtDocumento.Text.Trim();
                        proveedor.RAZON_SOCIAL = txtRazonSocial.Text;
                        proveedor.DIRECCION = txtDireccion.Text;
                        proveedor.DEPARTAMENTO = cboDepartamento.Text.ToString();
                        proveedor.PROVINCIA = cboProvincia.Text.ToString();
                        proveedor.DISTRITO = cboDistrito.Text.ToString();
                        proveedor.TELF_FIJO_OFICINA = txtTelfFijoOficina.Text;
                        proveedor.EMAIL = txtEmail.Text;
                        proveedor.OBSERVACIONES = txtObservaciones.Text;
                        proveedor.TIPO_PRO = rbJURIDICA.Content.ToString();
                        resul = proveedorDAO.Agregar(proveedor);
                        if (resul.Equals("Agregado"))
                            await this.ShowMessageAsync(resul, "Cliente :   " + proveedor.RAZON_SOCIAL + " , agregado correctamente");
                        else
                            await this.ShowMessageAsync(resul, "¡Lamentablemente ocurrió un error al Agregar!");
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "¡Falta llenar algunos campos!");
                        return;
                    }
                   
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta Llenar Campos, seleccione que Tipo de Proveedor desea agregar.");

                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Debe seleccionar un tipo de Proveedor para comenzar con el Registro");
                return;
            }           

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
                if (c is RadioButton)
                {
                    (c as RadioButton).IsChecked = false;
                }
            }
        }
        private void btnLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            limpiarTodo(Proveedores);
            BloquearTodosLosControles();
        }


    }
}
