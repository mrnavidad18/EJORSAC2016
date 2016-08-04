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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;
using SISJORSAC.DATA.DAO;
using SISJORSAC.DATA.Modelo;

namespace SISJORSAC
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        UsuarioDAO usuDAO = new UsuarioDAO();
        public MainWindow()
        {
            InitializeComponent();
            this.lblUsuarioError.Visibility = Visibility.Hidden;
            this.lblClaveError.Visibility = Visibility.Hidden;
            this.txtUsuario.Focus();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string clave = this.txtClave.Password;

            Usuario user = new Usuario();
            
            user.username = usuario.Trim();
            user.clave = clave.Trim();

            if (usuario.Trim() == "")
            {
                this.lblUsuarioError.Visibility = Visibility.Visible;
                return;
            }

            if (clave.Trim() == "")
            {
                this.lblClaveError.Visibility = Visibility.Visible;
                return;
            }

            VariablesGlobales.usuarioConectado = usuDAO.ValidarUsuario(user);
            if (VariablesGlobales.usuarioConectado != null)
            {
                Menu menu = new Menu();
                this.Close();
                menu.Show();
            }
            else
            {
                await this.ShowMessageAsync("Error", "Usuario Incorrecto");
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            this.lblUsuarioError.Visibility = Visibility.Hidden;
         
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            this.lblClaveError.Visibility = Visibility.Hidden;
        }

        private async void txtClave_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string usuario = this.txtUsuario.Text;
                    string clave = this.txtClave.Password;

                    Usuario user = new Usuario();
                    user.username = usuario.Trim();
                    user.clave = clave.Trim();

                    if (usuario.Trim() == "")
                    {
                        this.lblUsuarioError.Visibility = Visibility.Visible;
                        return;
                    }

                    if (clave.Trim() == "")
                    {
                        this.lblClaveError.Visibility = Visibility.Visible;
                        return;
                    }
                    VariablesGlobales.usuarioConectado = usuDAO.ValidarUsuario(user);
                    if (VariablesGlobales.usuarioConectado != null)
                    {
                        Menu menu = new Menu();
                        this.Close();
                        menu.Show();
                    }
                    else
                    {
                        await this.ShowMessageAsync("Error", "Usuario Incorrecto");
                    }
                }
            }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"Error");
            }
        }    
    }
}
