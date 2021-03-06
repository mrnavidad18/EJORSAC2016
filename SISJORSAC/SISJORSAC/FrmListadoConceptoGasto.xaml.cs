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
    /// Lógica de interacción para FrmListadoConceptoGasto.xaml
    /// </summary>
    public partial class FrmListadoConceptoGasto : MetroWindow
    {
        ConceptoGastoDAO conceptoGastoDAO = new ConceptoGastoDAO();
        public FrmListadoConceptoGasto()
        {
            InitializeComponent();
            ListarConceptoGasto("","ACTIVO");
            txtBusqueda.Focus();
        }

        private void ListarConceptoGasto(string p_busqueda,string estado)
        {
            var listadoConcepto = conceptoGastoDAO.listarConceptoGasto(p_busqueda,estado);
            dgvListadoConceptoGasto.ItemsSource = listadoConcepto;
            if (estado.Equals("ACTIVO"))
            {
                DataGridTextColumn columna = new DataGridTextColumn();
                columna.Width = 950;
                columna.Header = "DESCRIPCION";
                columna.Binding = new Binding("DESCRIPCION");
                dgvListadoConceptoGasto.Columns.Add(columna);          
            }
            else
            {

            }

        }


        private async void actualizarConceptoGasto()
        {
            ConceptoGasto conceptoGasto = dgvListadoConceptoGasto.SelectedItem as ConceptoGasto;
            DataGridRow row = (DataGridRow)dgvListadoConceptoGasto.ItemContainerGenerator.ContainerFromItem(dgvListadoConceptoGasto.SelectedItem);
            int posicion = row.GetIndex();
            if (conceptoGasto.COD_CON_GAS == 0)
            {
                await this.ShowMessageAsync("Información", "No se puede actualizar esta fila");
                dgvListadoConceptoGasto.Columns.Clear();
                ListarConceptoGasto("","ACTIVO");
                return;
            }


            string descripcion = "";            
            if (dgvListadoConceptoGasto.Columns[0].GetCellContent(row) is TextBox)
            {
                descripcion = ((TextBox)dgvListadoConceptoGasto.Columns[0].GetCellContent(row)).Text;

                
            }
            else if (dgvListadoConceptoGasto.Columns[0].GetCellContent(row) is TextBlock)
            {
                descripcion = ((TextBlock)dgvListadoConceptoGasto.Columns[0].GetCellContent(row)).Text;
                
           }            
            else
            {
                MessageBox.Show("ERROR");
            }

            conceptoGasto.DESCRIPCION = descripcion;
            if (await this.ShowMessageAsync("Confirmación", "¿Actualizar este Concepto?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
            {
                string resul = conceptoGastoDAO.Actualizar(conceptoGasto);
                await this.ShowMessageAsync("Correcto", resul);
                dgvListadoConceptoGasto.Columns.Clear();
                ListarConceptoGasto("","ACTIVO");
            }
            else
            {
                dgvListadoConceptoGasto.Columns.Clear();
                ListarConceptoGasto("","ACTIVO");
            }
        }

        private async void dgvListadoConceptoGasto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (this.dgvListadoConceptoGasto.SelectedItem != null)
                {
                    if (e.Key == Key.F5)
                    {
                        actualizarConceptoGasto();
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
                string p_busqueda = txtBusqueda.Text;
                dgvListadoConceptoGasto.Columns.Clear();
                ListarConceptoGasto(p_busqueda, "ACTIVO");
            }
        }




    }
}
