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
    /// Lógica de interacción para FrmChoferRegistro.xaml
    /// </summary>
    public partial class FrmChoferRegistro : MetroWindow
    {

        ChoferDAO choferDAO = new ChoferDAO();
        public FrmChoferRegistro()
        {
            InitializeComponent();
        }

        private async void btnServicio_Click(object sender, RoutedEventArgs e)
        {

            if (txtNombres.Text.Trim() != "" && txtApellidos.Text.Trim() != "" && txtNroBrevete.Text.Trim() != ""
                    && txtNroCertificado.Text.Trim() != "" && txtVehiculoMARCA.Text.Trim() != "")
            {
                Chofer chofer = new Chofer();
                chofer.NOMBRES = txtNombres.Text;
                chofer.APELLIDOS = txtApellidos.Text;
                chofer.NRO_CERTIFICADO = txtNroCertificado.Text.Trim();
                chofer.NRO_BREVETE = txtNroBrevete.Text.Trim();
                chofer.VEHICULO_MARCA_PLACA = txtVehiculoMARCA.Text.ToUpper();
                string resul = choferDAO.Agregar(chofer);
                if (resul.Equals("Agregado"))
                {
                    await this.ShowMessageAsync(resul, "Chofer : " + chofer.NOMBRES + " , AGREGADO CON ÉXITO");
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Ocurrió un error al Agregar este chofer.");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar algunos campos.");
            }    
        }

        private void btnLimpiarTodo_Click(object sender, RoutedEventArgs e)
        {
            limpiarTodo(GridChofer);
            txtNombres.Focus();
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
    }
}
