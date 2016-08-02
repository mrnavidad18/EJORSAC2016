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
    /// Lógica de interacción para FrmListadoClientes.xaml
    /// </summary>
    public partial class FrmListadoClientes : MetroWindow
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        List<Cliente> listadoCliente = new List<Cliente>();
        public  FrmListadoClientes()
        {
            InitializeComponent();
            txtBusqueda.Visibility = Visibility.Hidden;
            dgvListadoCliente.Visibility = Visibility.Hidden;
        }
        private void ListarClientes(string tipoCliente)
        {
            if (listadoCliente ==null)
            {
                listadoCliente = clienteDAO.ListarCliente(tipoCliente);

            }

            dgvListadoCliente.ItemsSource = listadoCliente;
            if (tipoCliente.Equals("NATURAL"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "Nombre";
                columna.Binding = new Binding("NOMBRES");
                dgvListadoCliente.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Apellido Paterno";
                columna2.Binding = new Binding("AP_PATERNO");
                dgvListadoCliente.Columns.Add(columna2);
                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Apellido Materno";
                columna3.Binding = new Binding("AP_MATERNO");
                dgvListadoCliente.Columns.Add(columna3);
                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "DNI";
                columna4.Binding = new Binding("DNI");
                dgvListadoCliente.Columns.Add(columna4);
                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Dirección";
                columna5.Binding = new Binding("DIRECCION");
                dgvListadoCliente.Columns.Add(columna5);
                DataGridTextColumn columna6 = new DataGridTextColumn();
                columna6.Header = "Departamento";
                columna6.Binding = new Binding("DEPARTAMENTO");
                dgvListadoCliente.Columns.Add(columna6);
                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Provincia";
                columna7.Binding = new Binding("PROVINCIA");
                dgvListadoCliente.Columns.Add(columna7);
                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Distrito";
                columna8.Binding = new Binding("DISTRITO");
                dgvListadoCliente.Columns.Add(columna8);
                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Telf. Casa";
                columna9.Binding = new Binding("TEL_FIJO_CASA");
                dgvListadoCliente.Columns.Add(columna9);
                DataGridTextColumn columna10 = new DataGridTextColumn();
                columna10.Header = "Celular";
                columna10.Binding = new Binding("CELULAR");
                dgvListadoCliente.Columns.Add(columna10);
                DataGridTextColumn columna11 = new DataGridTextColumn();
                columna11.Header = "Email";
                columna11.Binding = new Binding("EMAIL");
                dgvListadoCliente.Columns.Add(columna11);
                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Observaciones";
                columna12.Binding = new Binding("OBSERVACIONES");
                dgvListadoCliente.Columns.Add(columna12);               
            }
            else
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Header = "RUC";
                columna.Binding = new Binding("RUC");
                dgvListadoCliente.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "Razón Social";
                columna2.Binding = new Binding("RAZON_SOCIAL");
                dgvListadoCliente.Columns.Add(columna2);                              
                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "Dirección";
                columna5.Binding = new Binding("DIRECCION");
                dgvListadoCliente.Columns.Add(columna5);
                DataGridTextColumn columna6 = new DataGridTextColumn();
                columna6.Header = "Departamento";
                columna6.Binding = new Binding("DEPARTAMENTO");
                dgvListadoCliente.Columns.Add(columna6);
                DataGridTextColumn columna7 = new DataGridTextColumn();
                columna7.Header = "Provincia";
                columna7.Binding = new Binding("PROVINCIA");
                dgvListadoCliente.Columns.Add(columna7);
                DataGridTextColumn columna8 = new DataGridTextColumn();
                columna8.Header = "Distrito";
                columna8.Binding = new Binding("DISTRITO");
                dgvListadoCliente.Columns.Add(columna8);
                DataGridTextColumn columna9 = new DataGridTextColumn();
                columna9.Header = "Telf. Oficina";
                columna9.Binding = new Binding("TEL_FIJO_OFICINA");
                dgvListadoCliente.Columns.Add(columna9);               
                DataGridTextColumn columna11 = new DataGridTextColumn();
                columna11.Header = "Email";
                columna11.Binding = new Binding("EMAIL");
                dgvListadoCliente.Columns.Add(columna11);
                DataGridTextColumn columna12 = new DataGridTextColumn();
                columna12.Header = "Observaciones";
                columna12.Binding = new Binding("OBSERVACIONES");
                dgvListadoCliente.Columns.Add(columna12);                
            }            
                                 
        }

        private void rdbNatural_Checked(object sender, RoutedEventArgs e)
        {
            dgvListadoCliente.Visibility = Visibility.Visible;
            dgvListadoCliente.Columns.Clear();
            listadoCliente = null;
            ListarClientes("NATURAL");
            txtBusqueda.Visibility = Visibility.Visible;
            lblBusqueda.Content = "Busca por DNI / Nombre o Apellidos";
        }

        private void rdbJuridica_Checked(object sender, RoutedEventArgs e)
        {
            dgvListadoCliente.Visibility = Visibility.Visible;
            dgvListadoCliente.Columns.Clear();
            listadoCliente = null;
            ListarClientes("JURIDICA");
            txtBusqueda.Visibility = Visibility.Visible;
            lblBusqueda.Content = "Busca por RUC o Razón Social";
        }
        private async void actualizarNatural()
        {
             Cliente cli = dgvListadoCliente.SelectedItem as Cliente;                          
             DataGridRow row = (DataGridRow)dgvListadoCliente.ItemContainerGenerator.ContainerFromItem(dgvListadoCliente.SelectedItem);
             int posicion = row.GetIndex();
             if (cli.COD_CLI == 0)
             {
                 await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                 dgvListadoCliente.Columns.Clear();
                 ListarClientes("NATURAL");
                 return;
             }
            //foreach (var item in dgvListadoCliente.Items)
            //{
            //    DataGridRow row = (DataGridRow)dgvListadoCliente.ItemContainerGenerator.ContainerFromItem(item);
                
            //    if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBox)
            //    {
            //        valor = ((TextBox)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;

            //    }
            //    else if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBlock)
            //    {
            //        valor = ((TextBlock)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;
            //    }

            //    MessageBox.Show(row.GetIndex().ToString());
            //}
            //for (int i = 0; i < 12; i++){
            //    valor = ((TextBlock)dgvListadoCliente.Columns[i].GetCellContent(row)).Text;

            //    MessageBox.Show(valor);
            //}

           //    valor = Convert.ToString(((TextBlock)dgvListadoCliente.Columns[0].GetCellContent(row)).Text);
            
                //   valor = ((TextBox)dgvListadoCliente.Columns[0].GetCellContent(row)).Text;

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

                   if (dgvListadoCliente.Columns[0].GetCellContent(row) is TextBox)
                    {
                           nombre = ((TextBox)dgvListadoCliente.Columns[0].GetCellContent(row)).Text;
                           
                           MessageBox.Show(nombre);
                    }
                    else if (dgvListadoCliente.Columns[0].GetCellContent(row) is TextBlock)
                       {
                            nombre = ((TextBlock)dgvListadoCliente.Columns[0].GetCellContent(row)).Text;
                           MessageBox.Show(nombre);
                       }
                   if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBox)
                   {
                       apPaterno = ((TextBox)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;
                       MessageBox.Show(apPaterno);
                   }
                   else if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBlock)
                   {
                       apPaterno = ((TextBlock)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;
                       MessageBox.Show(apPaterno);
                   }
                    if (dgvListadoCliente.Columns[2].GetCellContent(row) is TextBox)
                   {
                       apMaterno = ((TextBox)dgvListadoCliente.Columns[2].GetCellContent(row)).Text;

                       MessageBox.Show(apMaterno);
                   }
                   else if (dgvListadoCliente.Columns[2].GetCellContent(row) is TextBlock)
                   {
                       apMaterno = ((TextBlock)dgvListadoCliente.Columns[2].GetCellContent(row)).Text;
                       MessageBox.Show(apMaterno);
                   }
                    if (dgvListadoCliente.Columns[3].GetCellContent(row) is TextBox)
                   {
                       DNI = ((TextBox)dgvListadoCliente.Columns[3].GetCellContent(row)).Text;
                       MessageBox.Show(DNI);
                   }
                   else if (dgvListadoCliente.Columns[3].GetCellContent(row) is TextBlock)
                   {
                       DNI = ((TextBlock)dgvListadoCliente.Columns[3].GetCellContent(row)).Text;
                       MessageBox.Show(DNI);
                   }
                    if (dgvListadoCliente.Columns[4].GetCellContent(row) is TextBox)
                   {
                       direccion = ((TextBox)dgvListadoCliente.Columns[4].GetCellContent(row)).Text;
                       MessageBox.Show(direccion);
                   }
                   else if (dgvListadoCliente.Columns[4].GetCellContent(row) is TextBlock)
                   {
                       direccion = ((TextBlock)dgvListadoCliente.Columns[4].GetCellContent(row)).Text;
                       MessageBox.Show(direccion);
                   }
                    if (dgvListadoCliente.Columns[5].GetCellContent(row) is TextBox)
                   {
                       departamento = ((TextBox)dgvListadoCliente.Columns[5].GetCellContent(row)).Text;
                       MessageBox.Show(departamento);
                   }
                   else if (dgvListadoCliente.Columns[5].GetCellContent(row) is TextBlock)
                   {
                       departamento = ((TextBlock)dgvListadoCliente.Columns[5].GetCellContent(row)).Text;

                       MessageBox.Show(departamento);
                   }
                    if (dgvListadoCliente.Columns[6].GetCellContent(row) is TextBox)
                   {
                       provincia = ((TextBox)dgvListadoCliente.Columns[6].GetCellContent(row)).Text;
                       MessageBox.Show(provincia);
                   }
                   else if (dgvListadoCliente.Columns[6].GetCellContent(row) is TextBlock)
                   {

                       provincia = ((TextBlock)dgvListadoCliente.Columns[6].GetCellContent(row)).Text;
                       MessageBox.Show(provincia);
                   }
                    if (dgvListadoCliente.Columns[7].GetCellContent(row) is TextBox)
                   {

                       distrito = ((TextBox)dgvListadoCliente.Columns[7].GetCellContent(row)).Text;
                       MessageBox.Show(distrito);
                   }
                   else if (dgvListadoCliente.Columns[7].GetCellContent(row) is TextBlock)
                   {
                       distrito = ((TextBlock)dgvListadoCliente.Columns[7].GetCellContent(row)).Text;
                       MessageBox.Show(distrito);
                   }
                    if (dgvListadoCliente.Columns[8].GetCellContent(row) is TextBox)
                   {
                       telfFijocasa = ((TextBox)dgvListadoCliente.Columns[8].GetCellContent(row)).Text;
                       MessageBox.Show(telfFijocasa);
                   }

                   else if (dgvListadoCliente.Columns[8].GetCellContent(row) is TextBlock)
                   {
                       telfFijocasa = ((TextBlock)dgvListadoCliente.Columns[8].GetCellContent(row)).Text;
                       MessageBox.Show(telfFijocasa);
                   }
                    if (dgvListadoCliente.Columns[9].GetCellContent(row) is TextBox)
                   {
                       celular = ((TextBox)dgvListadoCliente.Columns[9].GetCellContent(row)).Text;
                       MessageBox.Show(celular);
                   }
                   else if (dgvListadoCliente.Columns[9].GetCellContent(row) is TextBlock)
                   {
                       celular = ((TextBlock)dgvListadoCliente.Columns[9].GetCellContent(row)).Text;
                       MessageBox.Show(celular);
                   }
                    if (dgvListadoCliente.Columns[10].GetCellContent(row) is TextBox)
                   {
                       email = ((TextBox)dgvListadoCliente.Columns[10].GetCellContent(row)).Text;
                       MessageBox.Show(email);
                   }
                   else if (dgvListadoCliente.Columns[10].GetCellContent(row) is TextBlock)
                   {
                       email = ((TextBlock)dgvListadoCliente.Columns[10].GetCellContent(row)).Text;
                       MessageBox.Show(email);
                   }
                    if (dgvListadoCliente.Columns[11].GetCellContent(row) is TextBox)
                   {

                       observaciones = ((TextBox)dgvListadoCliente.Columns[11].GetCellContent(row)).Text;
                       MessageBox.Show(observaciones);
                   }

                   else if (dgvListadoCliente.Columns[11].GetCellContent(row) is TextBlock)
                   {
                       observaciones = ((TextBlock)dgvListadoCliente.Columns[11].GetCellContent(row)).Text;

                       MessageBox.Show(observaciones);
                   }
                   else
                   {
                       MessageBox.Show("ESTÁ MAL");
                   }
                cli.NOMBRES = nombre;
                cli.AP_PATERNO = apPaterno;
                cli.AP_MATERNO = apMaterno;
                cli.DNI = DNI;
                cli.DIRECCION = direccion;
                cli.DEPARTAMENTO = departamento;
                cli.PROVINCIA = provincia;
                cli.DISTRITO = distrito;
                cli.TEL_FIJO_CASA = telfFijocasa;
                cli.CELULAR =celular;
                cli.EMAIL =email;
                cli.OBSERVACIONES =observaciones;
                cli.TIPO_CLIE = "NATURAL";

             if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Cliente?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
             {
                 string resul=clienteDAO.Actualizar(cli);
                 await this.ShowMessageAsync("Correcto", resul);
                 dgvListadoCliente.Columns.Clear();
                 ListarClientes("NATURAL");
             }
             else
             {
                 
             }                                           
        }

        private async void actualizarJuridica()
        {
            Cliente cli = dgvListadoCliente.SelectedItem as Cliente;           
            DataGridRow row = (DataGridRow)dgvListadoCliente.ItemContainerGenerator.ContainerFromItem(dgvListadoCliente.SelectedItem);
            int posicion = row.GetIndex();
            if (cli.COD_CLI == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoCliente.Columns.Clear();
                ListarClientes("JURIDICA");
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

            if (dgvListadoCliente.Columns[0].GetCellContent(row) is TextBox)
            {
                RUC = ((TextBox)dgvListadoCliente.Columns[0].GetCellContent(row)).Text;

                MessageBox.Show(RUC);
            }
            else if (dgvListadoCliente.Columns[0].GetCellContent(row) is TextBlock)
            {
                RUC = ((TextBlock)dgvListadoCliente.Columns[0].GetCellContent(row)).Text;
                MessageBox.Show(RUC);
            }
            if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBox)
            {
                razonSocial = ((TextBox)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;
                MessageBox.Show(razonSocial);
            }
            else if (dgvListadoCliente.Columns[1].GetCellContent(row) is TextBlock)
            {
                razonSocial = ((TextBlock)dgvListadoCliente.Columns[1].GetCellContent(row)).Text;
                MessageBox.Show(razonSocial);
            }
            if (dgvListadoCliente.Columns[2].GetCellContent(row) is TextBox)
            {
                direccion = ((TextBox)dgvListadoCliente.Columns[2].GetCellContent(row)).Text;

                MessageBox.Show(direccion);
            }
            else if (dgvListadoCliente.Columns[2].GetCellContent(row) is TextBlock)
            {
                direccion = ((TextBlock)dgvListadoCliente.Columns[2].GetCellContent(row)).Text;
                MessageBox.Show(direccion);
            }
            if (dgvListadoCliente.Columns[3].GetCellContent(row) is TextBox)
            {
                departamento = ((TextBox)dgvListadoCliente.Columns[3].GetCellContent(row)).Text;
                MessageBox.Show(departamento);
            }
            else if (dgvListadoCliente.Columns[3].GetCellContent(row) is TextBlock)
            {
                departamento = ((TextBlock)dgvListadoCliente.Columns[3].GetCellContent(row)).Text;
                MessageBox.Show(departamento);
            }
            if (dgvListadoCliente.Columns[4].GetCellContent(row) is TextBox)
            {
                provincia = ((TextBox)dgvListadoCliente.Columns[4].GetCellContent(row)).Text;
                MessageBox.Show(provincia);
            }
            else if (dgvListadoCliente.Columns[4].GetCellContent(row) is TextBlock)
            {
                provincia = ((TextBlock)dgvListadoCliente.Columns[4].GetCellContent(row)).Text;
                MessageBox.Show(provincia);
            }
            if (dgvListadoCliente.Columns[5].GetCellContent(row) is TextBox)
            {
                distrito = ((TextBox)dgvListadoCliente.Columns[5].GetCellContent(row)).Text;
                MessageBox.Show(distrito);
            }
            else if (dgvListadoCliente.Columns[5].GetCellContent(row) is TextBlock)
            {
                distrito = ((TextBlock)dgvListadoCliente.Columns[5].GetCellContent(row)).Text;

                MessageBox.Show(distrito);
            }
            if (dgvListadoCliente.Columns[6].GetCellContent(row) is TextBox)
            {
                telfOficina = ((TextBox)dgvListadoCliente.Columns[6].GetCellContent(row)).Text;
                MessageBox.Show(telfOficina);
            }
            else if (dgvListadoCliente.Columns[6].GetCellContent(row) is TextBlock)
            {
                telfOficina = ((TextBlock)dgvListadoCliente.Columns[6].GetCellContent(row)).Text;
                MessageBox.Show(telfOficina);
            }
            if (dgvListadoCliente.Columns[7].GetCellContent(row) is TextBox)
            {

                email = ((TextBox)dgvListadoCliente.Columns[7].GetCellContent(row)).Text;
                MessageBox.Show(email);
            }
            else if (dgvListadoCliente.Columns[7].GetCellContent(row) is TextBlock)
            {
                email = ((TextBlock)dgvListadoCliente.Columns[7].GetCellContent(row)).Text;
                MessageBox.Show(email);
            }
            if (dgvListadoCliente.Columns[8].GetCellContent(row) is TextBox)
            {
                observaciones = ((TextBox)dgvListadoCliente.Columns[8].GetCellContent(row)).Text;
                MessageBox.Show(observaciones);
            }

            else if (dgvListadoCliente.Columns[8].GetCellContent(row) is TextBlock)
            {
                observaciones = ((TextBlock)dgvListadoCliente.Columns[8].GetCellContent(row)).Text;
                MessageBox.Show(observaciones);
            }
            else
            {
                MessageBox.Show("ESTÁ MAL");
            }
            cli.RUC = RUC;
            cli.RAZON_SOCIAL = razonSocial;
            cli.DIRECCION = direccion;
            cli.DEPARTAMENTO = departamento;
            cli.PROVINCIA = provincia;
            cli.DISTRITO = distrito;
            cli.TEL_FIJO_OFICINA = telfOficina;
            cli.EMAIL = email;           
            cli.OBSERVACIONES = observaciones;
            cli.TIPO_CLIE = "JURIDICA";

            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Cliente?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = clienteDAO.Actualizar(cli);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoCliente.Columns.Clear();
                ListarClientes("JURIDICA");
            }
            else
            {
            }
        }


        private async void dgvListadoCliente_KeyDown_1(object sender, KeyEventArgs e)
        {

            try
            {

                if (rdbNatural.IsChecked == true)
                {
                    if (e.Key == Key.F5)
                    {

                        actualizarNatural();
                    }
                    if (e.Key == Key.F1)
                    {
                        await this.ShowMessageAsync("Información", "Selecccione el tipo de cliente que desea actualizar, de doble click sobre la celda que desea actualizar. Una vez realizado los cambios presione F5 y confirme.");
                        return;
                    }
                }
                else if (rdbJuridica.IsChecked == true)
                {
                    if (e.Key == Key.F5)
                    {

                        actualizarJuridica();
                    }

                    if (e.Key == Key.F1)
                    {
                        await this.ShowMessageAsync("Información", "Selecccione el tipo de cliente que desea actualizar, de doble click sobre la celda que desea actualizar. Una vez realizado los cambios presione F5 y confirme.");
                        return;

                    }
                }
                else
                {
                    if (e.Key == Key.F1)
                    {
                        await this.ShowMessageAsync("Información", "Selecccione el tipo de cliente que desea actualizar, de doble click sobre la celda que desea actualizar. Una vez realizado los cambios presione F5 y confirme.");
                        return;
                       
                    }
                    
                }
            }
            catch (Exception)
            {
                
                throw;
            }


      }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {

            if (rdbJuridica.IsChecked == true)
            {
                if (e.Key == Key.Enter)
                {
                    listadoCliente = null;
                    listadoCliente = clienteDAO.buscarxNombresyApellidos(txtBusqueda.Text, "JURIDICA");
                    dgvListadoCliente.Columns.Clear();
                    ListarClientes("JURIDICA");
                }
            }
            else
            {
                if (e.Key == Key.Enter)
                {
                    listadoCliente = null;
                    listadoCliente = clienteDAO.buscarxNombresyApellidos(txtBusqueda.Text, "NATURAL");
                    dgvListadoCliente.Columns.Clear();
                    ListarClientes("NATURAL");
                }
            }

            
        }




            
    }
}
