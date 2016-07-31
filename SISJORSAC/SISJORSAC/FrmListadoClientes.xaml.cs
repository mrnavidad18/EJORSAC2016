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
        public  FrmListadoClientes()
        {
            InitializeComponent();
          
        }

        private void ListarClientes(string tipoCliente)
        {
            var listadoCliente = clienteDAO.ListarCliente(tipoCliente);
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
                columna.Header = "Razón Social";
                columna.Binding = new Binding("RAZON_SOCIAL");
                dgvListadoCliente.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "RUC";
                columna2.Binding = new Binding("RUC");
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
            dgvListadoCliente.Columns.Clear();
            ListarClientes("NATURAL");
        }

        private void rdbJuridica_Checked(object sender, RoutedEventArgs e)
        {           
            dgvListadoCliente.Columns.Clear();
            ListarClientes("JURIDICA");
        }



        private void dgvListadoCliente_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.F5)
            {

                Cliente cli = dgvListadoCliente.SelectedItem as Cliente;
               


              string valor = "";
              DataGridRow row = (DataGridRow)dgvListadoCliente.ItemContainerGenerator.ContainerFromItem(dgvListadoCliente.SelectedItem);
             int posicion = row.GetIndex();

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
                MessageBox.Show(posicion.ToString());
               
            }
      }
            
    }
}
