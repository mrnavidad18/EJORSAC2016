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
    /// Lógica de interacción para FrmConceptoGasto.xaml
    /// </summary>
    public partial class FrmConceptoGasto : MetroWindow
    {
        ConceptoGasto conceptoGasto= new ConceptoGasto();
        ConceptoGastoDAO conceptODAO = new ConceptoGastoDAO();
        public FrmConceptoGasto()
        {
            InitializeComponent();
        }

        private async void btnAgregarConcepto_Click(object sender, RoutedEventArgs e)
        {
            if (txtConceptoGasto.Text.Trim() != "")
            {
                string resul = "";
                string concepto = txtConceptoGasto.Text;
                conceptoGasto.DESCRIPCION = concepto;
                resul = conceptODAO.Agregar(conceptoGasto);
                if (resul.Equals("Agregado"))
                {
                    await this.ShowMessageAsync(resul, "¡Concepto de Gasto Agregado Correctamente!");
                }
                else
                {
                    await this.ShowMessageAsync(resul, "¡OH No! Ocurrió un error");
                }
            }
            else
            {
                await this.ShowMessageAsync("Error", "Falta llenar la descripción del concepto de Gasto");
            }
            


        }
    }
}
