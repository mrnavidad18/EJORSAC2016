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
    /// Lógica de interacción para FrmListadoProveedor.xaml
    /// </summary>
    public partial class FrmListadoProveedor : MetroWindow
    {

        ProveedorDAO proveedorDAO = new ProveedorDAO();
        List<Proveedor> listadoProveedor = new List<Proveedor>();
        public FrmListadoProveedor()
        {
            InitializeComponent();
            txtBusqueda.Visibility = Visibility.Hidden;
            dgvListadoProveedor.Visibility = Visibility.Hidden;
        }

        private  async void dgvListadoProveedor_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {

                if (rdbNatural.IsChecked == true)
                {
                    if (e.Key == Key.F5)
                    {
                        actualizarNatural();
                    }

                }
                else if (rdbJuridica.IsChecked == true)
                {
                    if (e.Key == Key.F5)
                    {
                        actualizarJuridica();
                    }
                   
                }
                else
                {
                    await this.ShowMessageAsync("Información", "está tecla no está habilitada");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void ListarProveedores(string tipoProveedor)
        {
            if (listadoProveedor == null)
            {
                listadoProveedor = proveedorDAO.ListarProveedor(tipoProveedor);
            }
             
            dgvListadoProveedor.ItemsSource = listadoProveedor;
            if (tipoProveedor.Equals("NATURAL"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "Nombre";
                columna.Binding = new Binding("NOMBRES");
                dgvListadoProveedor.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Apellido Paterno";
                columna2.Binding = new Binding("AP_PATERNO");
                dgvListadoProveedor.Columns.Add(columna2);
                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Apellido Materno";
                columna3.Binding = new Binding("AP_MATERNO");
                dgvListadoProveedor.Columns.Add(columna3);
                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "DNI";
                columna4.Binding = new Binding("DNI");
                dgvListadoProveedor.Columns.Add(columna4);
                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Dirección";
                columna5.Binding = new Binding("DIRECCION");
                dgvListadoProveedor.Columns.Add(columna5);
                DataGridTextColumn columna6 = new DataGridTextColumn();
                columna6.Header = "Departamento";
                columna6.Binding = new Binding("DEPARTAMENTO");
                dgvListadoProveedor.Columns.Add(columna6);
                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Provincia";
                columna7.Binding = new Binding("PROVINCIA");
                dgvListadoProveedor.Columns.Add(columna7);
                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Distrito";
                columna8.Binding = new Binding("DISTRITO");
                dgvListadoProveedor.Columns.Add(columna8);
                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Telf. Casa";
                columna9.Binding = new Binding("TELF_FIJO_CASA");
                dgvListadoProveedor.Columns.Add(columna9);
                DataGridTextColumn columna10 = new DataGridTextColumn();
                columna10.Header = "Celular";
                columna10.Binding = new Binding("CELULAR");
                dgvListadoProveedor.Columns.Add(columna10);
                DataGridTextColumn columna11 = new DataGridTextColumn();
                columna11.Header = "Email";
                columna11.Binding = new Binding("EMAIL");
                dgvListadoProveedor.Columns.Add(columna11);
                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Observaciones";
                columna12.Binding = new Binding("OBSERVACIONES");
                dgvListadoProveedor.Columns.Add(columna12);
            }
            else
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "RUC";
                columna.Binding = new Binding("RUC");
                dgvListadoProveedor.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Razón Social";
                columna2.Binding = new Binding("RAZON_SOCIAL");
                dgvListadoProveedor.Columns.Add(columna2);
                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Dirección";
                columna5.Binding = new Binding("DIRECCION");
                dgvListadoProveedor.Columns.Add(columna5);
                DataGridTextColumn columna6 = new DataGridTextColumn();
                columna6.Header = "Departamento";
                columna6.Binding = new Binding("DEPARTAMENTO");
                dgvListadoProveedor.Columns.Add(columna6);
                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Provincia";
                columna7.Binding = new Binding("PROVINCIA");
                dgvListadoProveedor.Columns.Add(columna7);
                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Distrito";
                columna8.Binding = new Binding("DISTRITO");
                dgvListadoProveedor.Columns.Add(columna8);
                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Telf. Oficina";
                columna9.Binding = new Binding("TELF_FIJO_OFICINA");
                dgvListadoProveedor.Columns.Add(columna9);
                DataGridTextColumn columna11 = new DataGridTextColumn();
                columna11.Header = "Email";
                columna11.Binding = new Binding("EMAIL");
                dgvListadoProveedor.Columns.Add(columna11);
                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Observaciones";
                columna12.Binding = new Binding("OBSERVACIONES");
                dgvListadoProveedor.Columns.Add(columna12);
            }

        }

        private void rdbNatural_Checked(object sender, RoutedEventArgs e)
        {
            dgvListadoProveedor.Visibility = Visibility.Visible;           
            dgvListadoProveedor.Columns.Clear();
            listadoProveedor = null;
            ListarProveedores("NATURAL");
            txtBusqueda.Visibility = Visibility.Visible;
            lblBusqueda.Content = "Busca por DNI / Nombre o Apellidos";
        }

        private void rdbJuridica_Checked(object sender, RoutedEventArgs e)
        {
            dgvListadoProveedor.Visibility = Visibility.Visible;
            dgvListadoProveedor.Columns.Clear();
            listadoProveedor = null;
            ListarProveedores("JURIDICA");
            txtBusqueda.Visibility = Visibility.Visible;
            lblBusqueda.Content = "Busca por RUC o Razón Social";
        }

        private async void actualizarNatural()
        {
            Proveedor proveedor = dgvListadoProveedor.SelectedItem as Proveedor;
            DataGridRow row = (DataGridRow)dgvListadoProveedor.ItemContainerGenerator.ContainerFromItem(dgvListadoProveedor.SelectedItem);
            int posicion = row.GetIndex();
            if (proveedor.COD_PROV == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoProveedor.Columns.Clear();
                ListarProveedores("NATURAL");
                return;
            }


            string nombre = "";
            string apPaterno = "";
            string apMaterno = "";
            string DNI = "";
            string direccion = "";
            string departamento = "";
            string provincia = "";
            string distrito = "";
            string telfFijocasa = "";
            string celular = "";
            string email = "";
            string observaciones = "";

            if (dgvListadoProveedor.Columns[0].GetCellContent(row) is TextBox)
            {
                nombre = ((TextBox)dgvListadoProveedor.Columns[0].GetCellContent(row)).Text;

                
            }
            else if (dgvListadoProveedor.Columns[0].GetCellContent(row) is TextBlock)
            {
                nombre = ((TextBlock)dgvListadoProveedor.Columns[0].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[1].GetCellContent(row) is TextBox)
            {
                apPaterno = ((TextBox)dgvListadoProveedor.Columns[1].GetCellContent(row)).Text;
                
            }
            else if (dgvListadoProveedor.Columns[1].GetCellContent(row) is TextBlock)
            {
                apPaterno = ((TextBlock)dgvListadoProveedor.Columns[1].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[2].GetCellContent(row) is TextBox)
            {
                apMaterno = ((TextBox)dgvListadoProveedor.Columns[2].GetCellContent(row)).Text;

                
            }
            else if (dgvListadoProveedor.Columns[2].GetCellContent(row) is TextBlock)
            {
                apMaterno = ((TextBlock)dgvListadoProveedor.Columns[2].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[3].GetCellContent(row) is TextBox)
            {
                DNI = ((TextBox)dgvListadoProveedor.Columns[3].GetCellContent(row)).Text;
                
            }
            else if (dgvListadoProveedor.Columns[3].GetCellContent(row) is TextBlock)
            {
                DNI = ((TextBlock)dgvListadoProveedor.Columns[3].GetCellContent(row)).Text;
               
            }
            if (dgvListadoProveedor.Columns[4].GetCellContent(row) is TextBox)
            {
                direccion = ((TextBox)dgvListadoProveedor.Columns[4].GetCellContent(row)).Text;
               
            }
            else if (dgvListadoProveedor.Columns[4].GetCellContent(row) is TextBlock)
            {
                direccion = ((TextBlock)dgvListadoProveedor.Columns[4].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[5].GetCellContent(row) is TextBox)
            {
                departamento = ((TextBox)dgvListadoProveedor.Columns[5].GetCellContent(row)).Text;
                
            }
            else if (dgvListadoProveedor.Columns[5].GetCellContent(row) is TextBlock)
            {
                departamento = ((TextBlock)dgvListadoProveedor.Columns[5].GetCellContent(row)).Text;

               
            }
            if (dgvListadoProveedor.Columns[6].GetCellContent(row) is TextBox)
            {
                provincia = ((TextBox)dgvListadoProveedor.Columns[6].GetCellContent(row)).Text;
               
            }
            else if (dgvListadoProveedor.Columns[6].GetCellContent(row) is TextBlock)
            {

                provincia = ((TextBlock)dgvListadoProveedor.Columns[6].GetCellContent(row)).Text;
               
            }
            if (dgvListadoProveedor.Columns[7].GetCellContent(row) is TextBox)
            {

                distrito = ((TextBox)dgvListadoProveedor.Columns[7].GetCellContent(row)).Text;
                
            }
            else if (dgvListadoProveedor.Columns[7].GetCellContent(row) is TextBlock)
            {
                distrito = ((TextBlock)dgvListadoProveedor.Columns[7].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[8].GetCellContent(row) is TextBox)
            {
                telfFijocasa = ((TextBox)dgvListadoProveedor.Columns[8].GetCellContent(row)).Text;
               
            }

            else if (dgvListadoProveedor.Columns[8].GetCellContent(row) is TextBlock)
            {
                telfFijocasa = ((TextBlock)dgvListadoProveedor.Columns[8].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[9].GetCellContent(row) is TextBox)
            {
                celular = ((TextBox)dgvListadoProveedor.Columns[9].GetCellContent(row)).Text;
              
            }
            else if (dgvListadoProveedor.Columns[9].GetCellContent(row) is TextBlock)
            {
                celular = ((TextBlock)dgvListadoProveedor.Columns[9].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[10].GetCellContent(row) is TextBox)
            {
                email = ((TextBox)dgvListadoProveedor.Columns[10].GetCellContent(row)).Text;
               
            }
            else if (dgvListadoProveedor.Columns[10].GetCellContent(row) is TextBlock)
            {
                email = ((TextBlock)dgvListadoProveedor.Columns[10].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[11].GetCellContent(row) is TextBox)
            {

                observaciones = ((TextBox)dgvListadoProveedor.Columns[11].GetCellContent(row)).Text;
                
            }

            else if (dgvListadoProveedor.Columns[11].GetCellContent(row) is TextBlock)
            {
                observaciones = ((TextBlock)dgvListadoProveedor.Columns[11].GetCellContent(row)).Text;

                
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            proveedor.NOMBRES = nombre;
            proveedor.AP_PATERNO = apPaterno;
            proveedor.AP_MATERNO = apMaterno;
            proveedor.DNI = DNI;
            proveedor.DIRECCION = direccion;
            proveedor.DEPARTAMENTO = departamento;
            proveedor.PROVINCIA = provincia;
            proveedor.DISTRITO = distrito;
            proveedor.TELF_FIJO_CASA = telfFijocasa;
            proveedor.CELULAR = celular;
            proveedor.EMAIL = email;
            proveedor.OBSERVACIONES = observaciones;
            proveedor.TIPO_PRO = "NATURAL";

            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Proveedor?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = proveedorDAO.Actualizar(proveedor);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoProveedor.Columns.Clear();
                ListarProveedores("NATURAL");
            }
            else
            {

            }
        }

        private async void actualizarJuridica()
        {
            Proveedor proveedor = dgvListadoProveedor.SelectedItem as Proveedor;
            DataGridRow row = (DataGridRow)dgvListadoProveedor.ItemContainerGenerator.ContainerFromItem(dgvListadoProveedor.SelectedItem);
            int posicion = row.GetIndex();
            if (proveedor.COD_PROV == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoProveedor.Columns.Clear();
                ListarProveedores("JURIDICA");
                return;
            }
            string RUC = "";
            string razonSocial = "";
            string direccion = "";
            string departamento = "";
            string provincia = "";
            string distrito = "";
            string telfOficina = "";
            string email = "";
            string observaciones = "";

            if (dgvListadoProveedor.Columns[0].GetCellContent(row) is TextBox)
            {
                RUC = ((TextBox)dgvListadoProveedor.Columns[0].GetCellContent(row)).Text;

               
            }
            else if (dgvListadoProveedor.Columns[0].GetCellContent(row) is TextBlock)
            {
                RUC = ((TextBlock)dgvListadoProveedor.Columns[0].GetCellContent(row)).Text;
               
            }
            if (dgvListadoProveedor.Columns[1].GetCellContent(row) is TextBox)
            {
                razonSocial = ((TextBox)dgvListadoProveedor.Columns[1].GetCellContent(row)).Text;
               
            }
            else if (dgvListadoProveedor.Columns[1].GetCellContent(row) is TextBlock)
            {
                razonSocial = ((TextBlock)dgvListadoProveedor.Columns[1].GetCellContent(row)).Text;
               
            }
            if (dgvListadoProveedor.Columns[2].GetCellContent(row) is TextBox)
            {
                direccion = ((TextBox)dgvListadoProveedor.Columns[2].GetCellContent(row)).Text;

            }
            else if (dgvListadoProveedor.Columns[2].GetCellContent(row) is TextBlock)
            {
                direccion = ((TextBlock)dgvListadoProveedor.Columns[2].GetCellContent(row)).Text;
                
            }
            if (dgvListadoProveedor.Columns[3].GetCellContent(row) is TextBox)
            {
                departamento = ((TextBox)dgvListadoProveedor.Columns[3].GetCellContent(row)).Text;                
            }
            else if (dgvListadoProveedor.Columns[3].GetCellContent(row) is TextBlock)
            {
                departamento = ((TextBlock)dgvListadoProveedor.Columns[3].GetCellContent(row)).Text;                
            }
            if (dgvListadoProveedor.Columns[4].GetCellContent(row) is TextBox)
            {
                provincia = ((TextBox)dgvListadoProveedor.Columns[4].GetCellContent(row)).Text;                
            }
            else if (dgvListadoProveedor.Columns[4].GetCellContent(row) is TextBlock)
            {
                provincia = ((TextBlock)dgvListadoProveedor.Columns[4].GetCellContent(row)).Text;                
            }
            if (dgvListadoProveedor.Columns[5].GetCellContent(row) is TextBox)
            {
                distrito = ((TextBox)dgvListadoProveedor.Columns[5].GetCellContent(row)).Text;                
            }
            else if (dgvListadoProveedor.Columns[5].GetCellContent(row) is TextBlock)
            {
                distrito = ((TextBlock)dgvListadoProveedor.Columns[5].GetCellContent(row)).Text;              
            }
            if (dgvListadoProveedor.Columns[6].GetCellContent(row) is TextBox)
            {
                telfOficina = ((TextBox)dgvListadoProveedor.Columns[6].GetCellContent(row)).Text;               
            }
            else if (dgvListadoProveedor.Columns[6].GetCellContent(row) is TextBlock)
            {
                telfOficina = ((TextBlock)dgvListadoProveedor.Columns[6].GetCellContent(row)).Text;                
            }
            if (dgvListadoProveedor.Columns[7].GetCellContent(row) is TextBox)
            {
                email = ((TextBox)dgvListadoProveedor.Columns[7].GetCellContent(row)).Text;               
            }
            else if (dgvListadoProveedor.Columns[7].GetCellContent(row) is TextBlock)
            {
                email = ((TextBlock)dgvListadoProveedor.Columns[7].GetCellContent(row)).Text;           
            }
            if (dgvListadoProveedor.Columns[8].GetCellContent(row) is TextBox)
            {
                observaciones = ((TextBox)dgvListadoProveedor.Columns[8].GetCellContent(row)).Text;                
            }

            else if (dgvListadoProveedor.Columns[8].GetCellContent(row) is TextBlock)
            {
                observaciones = ((TextBlock)dgvListadoProveedor.Columns[8].GetCellContent(row)).Text;                
            }
            else
            {
                MessageBox.Show("ERROR");
            }
            proveedor.RUC = RUC;
            proveedor.RAZON_SOCIAL = razonSocial;
            proveedor.DIRECCION = direccion;
            proveedor.DEPARTAMENTO = departamento;
            proveedor.PROVINCIA = provincia;
            proveedor.DISTRITO = distrito;
            proveedor.TELF_FIJO_OFICINA = telfOficina;
            proveedor.EMAIL = email;
            proveedor.OBSERVACIONES = observaciones;
            proveedor.TIPO_PRO = "JURIDICA";

            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Proveedor?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = proveedorDAO.Actualizar(proveedor);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoProveedor.Columns.Clear();
                ListarProveedores("JURIDICA");
            }
            else
            {
            }
        }
        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (rdbJuridica.IsChecked == true)
            {
                if (e.Key == Key.Enter)
                {
                    listadoProveedor = null;
                    listadoProveedor = proveedorDAO.buscarxDatos(txtBusqueda.Text, "JURIDICA");
                    dgvListadoProveedor.Columns.Clear();
                    ListarProveedores("JURIDICA");
                }
            }
            else
            {
                if (e.Key == Key.Enter)
                {
                    listadoProveedor = null;
                    listadoProveedor = proveedorDAO.buscarxDatos(txtBusqueda.Text, "NATURAL");
                    dgvListadoProveedor.Columns.Clear();
                    ListarProveedores("NATURAL");
                }
            }
        }


    }
}
