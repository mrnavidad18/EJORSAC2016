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
    /// Lógica de interacción para FrmServicioRegistro.xaml
    /// </summary>
    public partial class FrmServicioRegistro : MetroWindow
    {
        ServicioDAO serviDAO = new ServicioDAO();

        public FrmServicioRegistro()
        {
            InitializeComponent();
            
        }

        private async void btnServicio_Click(object sender, RoutedEventArgs e)
        {

            if (txtDescripcion.Text.Trim() != "" && txtPrecio.Text.Trim() != "" && txtPeso.Text.Trim() != ""
                && txtStock.Text.Trim() != "" && txtUnidadMedida.Text.Trim() !="")
            {
                Servicio servicio = new Servicio();
                servicio.DESCRIPCION = txtDescripcion.Text;
                servicio.PESO = double.Parse(txtPeso.Text.ToString().Replace(@".", ","));
                servicio.PRECIO = double.Parse(txtPrecio.Text.ToString().Replace(@".", ","));
                servicio.STOCK = int.Parse(txtStock.Text.Trim());
                servicio.UNIDAD_MEDIDA = txtUnidadMedida.Text;
                string resul = serviDAO.Agregar(servicio);
                if (resul.Equals("Agregado"))
                {
                    await this.ShowMessageAsync(resul, "Servicio : " + servicio.DESCRIPCION + " , agregado con éxito");
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Ocurrió un error al Agregar este servicio.");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar algunos campos.");
            }            
        }


        private void btnLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            limpiarTodo(Servicios);
            txtDescripcion.Focus();
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
                    (c as ComboBox).SelectedIndex = 0;
                }
                if (c is RadioButton)
                {
                    (c as RadioButton).IsChecked = false;
                }
            }
        }

        private void txtUnidadMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;            
            else
                e.Handled = true;
        }

        private void txtPeso_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtPrecio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key == Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else if (e.Key==Key.Tab)
                e.Handled = false;
            else
                e.Handled = true;
        }


    }
}
