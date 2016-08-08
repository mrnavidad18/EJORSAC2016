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
    /// Lógica de interacción para FrmListadoServicios.xaml
    /// </summary>
    public partial class FrmListadoServicios : MetroWindow
    {
        ServicioDAO serviciosDAO = new ServicioDAO();
        public FrmListadoServicios()
        {
            InitializeComponent();
            ListarServicios("ACTIVO","");
           
        }

        private void ListarServicios(string estado,string p_busqueda)
        {
            var listadoServicios = serviciosDAO.listarServicio(estado, p_busqueda);
            dgvListadoServicios.ItemsSource = listadoServicios;
            if (estado.Equals("ACTIVO"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Width = 600;
                columna.Header = "DESCRIPCION";
                columna.Binding = new Binding("DESCRIPCION");
                dgvListadoServicios.Columns.Add(columna);
                DataGridTextColumn columna2 = new DataGridTextColumn();
                columna2.Header = "PRECIO";
                columna.HeaderStringFormat = "{0:F2}";
                columna2.Binding = new Binding("PRECIO");
                dgvListadoServicios.Columns.Add(columna2);
                DataGridTextColumn columna3 = new DataGridTextColumn();
                columna3.Header = "Tipo de Moneda";
                columna3.Binding = new Binding("TIPO_MONE");
                dgvListadoServicios.Columns.Add(columna3);
                DataGridTextColumn columna4 = new DataGridTextColumn();
                columna4.Header = "PESO";
                columna4.Binding = new Binding("PESO");
                dgvListadoServicios.Columns.Add(columna4);               
            }
            else
            {
               
            }

        }

        private async void actualizarServicio()
        {
            Servicio servicio = dgvListadoServicios.SelectedItem as Servicio;
            DataGridRow row = (DataGridRow)dgvListadoServicios.ItemContainerGenerator.ContainerFromItem(dgvListadoServicios.SelectedItem);
            int posicion = row.GetIndex();
            if (servicio.COD_SERV == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoServicios.Columns.Clear();
                ListarServicios("ACTIVO","");
                return;
            }


            string descripcion = "";
            double precio = 0;
            string tipoMoneda = "";
            string peso = "";
          

            if (dgvListadoServicios.Columns[0].GetCellContent(row) is TextBox)
            {
                descripcion = ((TextBox)dgvListadoServicios.Columns[0].GetCellContent(row)).Text;
            }
            else if (dgvListadoServicios.Columns[0].GetCellContent(row) is TextBlock)
            {
                descripcion = ((TextBlock)dgvListadoServicios.Columns[0].GetCellContent(row)).Text;               
            }
            if (dgvListadoServicios.Columns[1].GetCellContent(row) is TextBox)
            {
                precio =Convert.ToDouble( ((TextBox)dgvListadoServicios.Columns[1].GetCellContent(row)).Text.ToString().Replace(@",","."));                
            }
            else if (dgvListadoServicios.Columns[1].GetCellContent(row) is TextBlock)
            {
                precio = Convert.ToDouble(((TextBlock)dgvListadoServicios.Columns[1].GetCellContent(row)).Text.ToString().Replace(@",", "."));                
            }
            if (dgvListadoServicios.Columns[2].GetCellContent(row) is TextBox)
            {
                tipoMoneda = ((TextBox)dgvListadoServicios.Columns[2].GetCellContent(row)).Text;
            }
            else if (dgvListadoServicios.Columns[2].GetCellContent(row) is TextBlock)
            {
                tipoMoneda = ((TextBlock)dgvListadoServicios.Columns[2].GetCellContent(row)).Text;             
            }
            if (dgvListadoServicios.Columns[3].GetCellContent(row) is TextBox)
            {
                peso = ((TextBox)dgvListadoServicios.Columns[3].GetCellContent(row)).Text;              
            }
            else if (dgvListadoServicios.Columns[3].GetCellContent(row) is TextBlock)
            {
                peso = ((TextBlock)dgvListadoServicios.Columns[3].GetCellContent(row)).Text;               
            }

            else
            {
                MessageBox.Show("ERROR");
            }
            
            servicio.DESCRIPCION = descripcion;
            servicio.PRECIO = double.Parse(precio.ToString().Replace(@".",","));
            servicio.TIPO_MONE = tipoMoneda;
            servicio.PESO = double.Parse(peso.ToString().Replace(@".", ","));                       
            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Servicio?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = serviciosDAO.Actualizar(servicio);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoServicios.Columns.Clear();
                ListarServicios("ACTIVO","");
            }
            else
            {
                dgvListadoServicios.Columns.Clear();
                ListarServicios("ACTIVO","");
            }
        }

        private async void dgvListadoServicios_KeyDown_1(object sender, KeyEventArgs e)
        {            
            try
            {

                if (this.dgvListadoServicios.SelectedItem != null)
                {
                    if (e.Key == Key.F5)
                    {
                        actualizarServicio();
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

        private void txtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string p_busqueda= txtBusqueda.Text;                
                dgvListadoServicios.Columns.Clear();
                ListarServicios("ACTIVO", p_busqueda);
            }
        }



    }
}
