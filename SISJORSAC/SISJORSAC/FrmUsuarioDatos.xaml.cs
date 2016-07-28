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
    /// Lógica de interacción para FrmUsuarioDatos.xaml
    /// </summary>
    public partial class FrmUsuarioDatos : MetroWindow
    {
        public FrmUsuarioDatos()
        {
            InitializeComponent();
            ocultarCambioPassword();
        }
        public void ocultarCambioPassword()
        {
            lblConfirmarContra.Visibility = Visibility.Hidden;
            lblNuevaContra.Visibility = Visibility.Hidden;
            txtnuevaContra.Visibility = Visibility.Hidden;
            txtConfirmacionNuevaContra.Visibility = Visibility.Hidden;
          
        }

        public void mostrarCambioPassword()
        {
            lblConfirmarContra.Visibility = Visibility.Visible;
            lblNuevaContra.Visibility = Visibility.Visible;
            txtnuevaContra.Visibility = Visibility.Visible;
            txtConfirmacionNuevaContra.Visibility = Visibility.Visible;
        }

        private void chkCambiarContraseña_Checked(object sender, RoutedEventArgs e)
        {
            mostrarCambioPassword();
        }

        private void chkCambiarContraseña_Unchecked(object sender, RoutedEventArgs e)
        {
            ocultarCambioPassword();
        }


    }
}
