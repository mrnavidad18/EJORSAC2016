﻿using System;
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
    /// Lógica de interasdsdcción para frmFactura.xaml
    /// </summary>
    public partial class frmFactura : MetroWindow
    {
        public frmFactura()
        {
            InitializeComponent();
            Listar();
        }


        public void Listar()
        {
            Usuario usu= new Usuario();
            usu.Apellidos="juan";
            usu.Nombre="Pepe";
            usu.DNI="11111";
            
            List<Usuario> lista = new List<Usuario>();
            FacturaDAO facturadao = new FacturaDAO();
            ClienteDAO clientedao = new ClienteDAO();
            GuiaRemisionDAO guidao = new GuiaRemisionDAO();
            var lisss = guidao.listarGuiaRemision("DISPONIBLE");
          
            lista.Add(usu);
            this.dgvListado.ItemsSource = lisss;
             
        }

        private void dgvListado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       
      
    }
}
