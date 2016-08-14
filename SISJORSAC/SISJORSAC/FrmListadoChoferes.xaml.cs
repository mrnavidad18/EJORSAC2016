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
    /// Lógica de interacción para FrmListadoChoferes.xaml
    /// </summary>
    public partial class FrmListadoChoferes : MetroWindow
    {

        ChoferDAO choferrDAO = new ChoferDAO();
        public FrmListadoChoferes()
        {
            InitializeComponent();
            ListarChoferes("");
        }


        private void ListarChoferes(string pBusqueda)
        {
            try
            {
                var listadoChoferes = choferrDAO.Listar(pBusqueda);
                dgvListadoChoferes.ItemsSource = listadoChoferes;

                //            
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Width = 280;
                columna.Header = "NOMBRES";
                columna.Binding = new Binding("NOMBRES");
                dgvListadoChoferes.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Width = 280;
                columna2.Header = "APELLIDOS";
                columna2.Binding = new Binding("APELLIDOS");
                dgvListadoChoferes.Columns.Add(columna2);
                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Nº DE BREVETE";
                columna3.Binding = new Binding("NRO_BREVETE");
                dgvListadoChoferes.Columns.Add(columna3);
                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "Nº DE CERTIFICADO";
                columna4.Binding = new Binding("NRO_CERTIFICADO");
                dgvListadoChoferes.Columns.Add(columna4);
                DataGridTextColumn columna5 = new DataGridTextColumn();
                columna5.Header = "VEHÍCULO MARCA | PLACA";
                columna5.Binding = new Binding("VEHICULO_MARCA_PLACA");
                dgvListadoChoferes.Columns.Add(columna5);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string pBusqueda = txtBusqueda.Text;
                dgvListadoChoferes.Columns.Clear();
                ListarChoferes(pBusqueda);
            }
        }


        private async void actualizarChofer()
        {
            Chofer chofer = dgvListadoChoferes.SelectedItem as Chofer;
            DataGridRow row = (DataGridRow)dgvListadoChoferes.ItemContainerGenerator.ContainerFromItem(dgvListadoChoferes.SelectedItem);
            int posicion = row.GetIndex();
            if (chofer.COD_CHOFER == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoChoferes.Columns.Clear();
                ListarChoferes("");
                return;
            }

            string nombres = "";
            string apellidos = "";
            string nro_brevete = "";
            string nro_certificado = "";
            string vehiculoMarca_Placa = "";


            if (dgvListadoChoferes.Columns[0].GetCellContent(row) is TextBox)
            {
                nombres = ((TextBox)dgvListadoChoferes.Columns[0].GetCellContent(row)).Text;
            }
            else if (dgvListadoChoferes.Columns[0].GetCellContent(row) is TextBlock)
            {
                nombres = ((TextBlock)dgvListadoChoferes.Columns[0].GetCellContent(row)).Text;
            }
            if (dgvListadoChoferes.Columns[1].GetCellContent(row) is TextBox)
            {
                apellidos =((TextBox)dgvListadoChoferes.Columns[1].GetCellContent(row)).Text;
            }
            else if (dgvListadoChoferes.Columns[1].GetCellContent(row) is TextBlock)
            {
                apellidos = ((TextBlock)dgvListadoChoferes.Columns[1].GetCellContent(row)).Text;
            }
            if (dgvListadoChoferes.Columns[2].GetCellContent(row) is TextBox)
            {
                nro_brevete = ((TextBox)dgvListadoChoferes.Columns[2].GetCellContent(row)).Text;
            }
            else if (dgvListadoChoferes.Columns[2].GetCellContent(row) is TextBlock)
            {
                nro_brevete = ((TextBlock)dgvListadoChoferes.Columns[2].GetCellContent(row)).Text;
            }
            if (dgvListadoChoferes.Columns[3].GetCellContent(row) is TextBox)
            {
                nro_certificado = ((TextBox)dgvListadoChoferes.Columns[3].GetCellContent(row)).Text;
            }
            else if (dgvListadoChoferes.Columns[3].GetCellContent(row) is TextBlock)
            {
                nro_certificado = ((TextBlock)dgvListadoChoferes.Columns[3].GetCellContent(row)).Text;
            }
            if (dgvListadoChoferes.Columns[4].GetCellContent(row) is TextBox)
            {
                vehiculoMarca_Placa = ((TextBox)dgvListadoChoferes.Columns[4].GetCellContent(row)).Text;
            }
            else if (dgvListadoChoferes.Columns[4].GetCellContent(row) is TextBlock)
            {
                vehiculoMarca_Placa = ((TextBlock)dgvListadoChoferes.Columns[4].GetCellContent(row)).Text;
            }


            else
            {
                MessageBox.Show("ERROR");
            }

            chofer.NOMBRES = nombres;
            chofer.APELLIDOS = apellidos;
            chofer.NRO_BREVETE = nro_brevete;
            chofer.NRO_CERTIFICADO = nro_certificado;
            chofer.VEHICULO_MARCA_PLACA = vehiculoMarca_Placa;
            
            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Chofer?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = choferrDAO.Actualizar(chofer);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoChoferes.Columns.Clear();
                ListarChoferes("");
            }
            else
            {
                dgvListadoChoferes.Columns.Clear();
                ListarChoferes("");
            }
        }

        private async void dgvListadoChoferes_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (this.dgvListadoChoferes.SelectedItem != null)
                {
                    if (e.Key == Key.F5)
                    {
                        actualizarChofer();
                    }

                }
                
                else
                {
                    await this.ShowMessageAsync("Información", "Seleccione la fila que desee modificar");
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }




    }
}
