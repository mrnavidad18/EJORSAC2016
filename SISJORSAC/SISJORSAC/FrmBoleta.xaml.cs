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
    /// Lógica de interacción para FrmBoleta.xaml
    /// </summary>
    public partial class FrmBoleta : MetroWindow
    {

        List<DetalleBoleta> listaDetalle = new List<DetalleBoleta>();
        Cliente cliente;
        Servicio servicio;
        GuiaRemision guiaRemision;
        int item =1;
        double total = 0;
        string mensaje = "";
        ClienteDAO clienteDao = new ClienteDAO();
        ServicioDAO servicioDAO = new ServicioDAO();
        BoletaDAO boletaDao = new BoletaDAO();
        GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();

        public FrmBoleta()
        {
            InitializeComponent();
            this.txtNroBoleta.Text = boletaDao.ObtenerNroBoleta();
            this.txtFechaEmision.Text = DateTime.Now.ToString();
            ListarServicios();

            if (VariablesGlobales.NRO_GUIA_GLOBAL != "")
            {
                
                var guia = ObtenerGuia();
                if (guia.cliente.TIPO_CLIE.Equals("NATURAL")){
                    this.rbNATURAL.IsChecked = true;
                    this.txtDniRuc.Text = guia.cliente.DNI;
                }
                else
                {
                    this.rbJURIDICA.IsChecked = true;
                    this.txtDniRuc.Text = guia.cliente.RUC;
                }
                  

                
            }
           
        }

        private void ListarClientes(string tipoCliente)
        {
            if (VariablesGlobales.NRO_GUIA_GLOBAL == "")
            {
                var listacliente = clienteDao.ListarCliente(tipoCliente);

                this.cboCliente.ItemsSource = listacliente;
                if (tipoCliente.Equals("JURIDICA"))
                {
                    this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
                    this.cboCliente.SelectedValuePath = "COD_CLI";
                }
                else
                {
                    this.cboCliente.DisplayMemberPath = "NOMBRES";
                    this.cboCliente.SelectedValuePath = "COD_CLI";
                } 
            }
           
        }

        private void ListarServicios()
        {

            var listaServicios = servicioDAO.listarServicio("DISPONIBLE");
            this.cboServicio.ItemsSource = listaServicios;
            this.cboServicio.DisplayMemberPath = "DESCRIPCION";
            this.cboServicio.SelectedValuePath = "COD_SERV";


        }

        private void cboServicio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            servicio = servicioDAO.ObtenerServicio(codServicio);
            this.txtPrecio.Text = servicio.PRECIO.ToString();
        }

        private void rbNATURAL_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbNATURAL.Content.ToString());
        }

        private void rbJURIDICA_Checked(object sender, RoutedEventArgs e)
        {
            this.txtDniRuc.Text = "";
            this.cboCliente.IsEnabled = true;
            ListarClientes(rbJURIDICA.Content.ToString());    
        }

        private void Importe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = (TextBox)sender;
                int cantidad = Convert.ToInt32(t.Text);

                var detalleBoleta = this.dgvListado.SelectedItem as DetalleBoleta;
                var detalleEncontrado = listaDetalle.Find(x => x.IMPORTE == detalleBoleta.IMPORTE);
                detalleEncontrado.CANTIDAD = cantidad;
                detalleEncontrado.IMPORTE = cantidad * detalleEncontrado.PRECIO;

                total = 0;
                foreach (var detalle in listaDetalle)
                {
                    total = total + detalle.IMPORTE;
                }
                this.txtTotal.Text = total.ToString();

                LlenarGrid(listaDetalle);
            }

            int ascci = Convert.ToInt32(Convert.ToChar(e.Key));
            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122) e.Handled = false;
            else e.Handled = true;

        }

        private void cboCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCliente.SelectedIndex == -1)
            {

            }
            else
            {
                int codCliente = Convert.ToInt32(this.cboCliente.SelectedValue);
                cliente = clienteDao.ObtenerCliente(codCliente);
                if (cliente.TIPO_CLIE.Equals("NATURAL"))
                {
                    this.txtDniRuc.Text = cliente.DNI;
                }
                else
                {
                    this.txtDniRuc.Text = cliente.RUC;
                }
                this.txtDireccion.Text = cliente.DIRECCION.ToString();
            }
        }

        private DetalleBoleta AgregarDetalles()
        {

            DetalleBoleta detalle = new DetalleBoleta();

            int codServicio = Convert.ToInt32(this.cboServicio.SelectedValue);
            int cantidad = Convert.ToInt32(this.txtCantidad.Text);
            double precio = Convert.ToDouble(this.txtPrecio.Text);

            detalle.SERVICIO = servicioDAO.ObtenerServicio(codServicio);
            detalle.CANTIDAD = cantidad;
            detalle.PRECIO = precio;
            detalle.ITEM = item;
            detalle.IMPORTE = cantidad * precio;
            listaDetalle.Add(detalle);
            LlenarGrid(listaDetalle);
            total = total + detalle.IMPORTE;
            item++;
            return detalle;
        }

        private void LlenarGrid(List<DetalleBoleta> listaDetalles)
        {
            this.dgvListado.ItemsSource = null;
            dgvListado.ItemsSource = listaDetalles;
        }
        private async void btnAgregarDetalle_Click(object sender, RoutedEventArgs e)
        {
            if (this.cboServicio.SelectedItem != null && this.txtCantidad.Text.Trim() != "" && this.txtPrecio.Text.Trim() != "")
                {
                    AgregarDetalles();
                    this.txtTotal.Text = total.ToString();
                    this.txtCantidad.Text = "";
                    this.txtPrecio.Text = "";
                    this.cboServicio.SelectedIndex = -1;
                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
            }
        }

        private void chkObservacion_Checked(object sender, RoutedEventArgs e)
        {
            this.txtObservacion.IsEnabled = true;
        }

        private void chkCambiarNroBol_Checked(object sender, RoutedEventArgs e)
        {
            this.txtNroBoleta.IsEnabled = true;

            this.txtNroBoleta.Focus();
        }

        private void AgregarBoleta()
        {
            Boleta boleta = new Boleta();
            boleta.MODALIDAD = ((ComboBoxItem)this.cboModalidad.SelectedItem).Content.ToString();
            boleta.FECHA_EMISION = DateTime.Now;
            boleta.cliente = cliente;
            boleta.TOTAL = total;
            if (this.txtNroGuia.Text == "")
            {
                boleta.GUIA = null;
            }
            else
            {

                boleta.GUIA = guiaRemision;
            }

            boleta.DETALLEBOLETA = listaDetalle;
            boleta.OBSERVACION = this.txtObservacion.Text;
            if (chkCambiarNroBol.IsChecked == true)
            {
                boleta.NRO_BOLETA = this.txtNroBoleta.Text;
                Object[] result = boletaDao.AgregarBoletaConNroBoleta(boleta);
                mensaje = result[1].ToString();
            }
            else
            {
                Object[] result = boletaDao.AgregarBoleta(boleta);
                mensaje = result[1].ToString();
            }


        }



        private async void btnGenerarBoleta_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                if (this.txtNroBoleta.Text.Trim() != "" && this.cboModalidad.SelectedItem != null && this.cboMoneda.SelectedItem != null &&
             this.cboCliente.SelectedItem != null)
                {
                    if (this.dgvListado.Items.Count == 0)
                    {
                        await this.ShowMessageAsync("Error", "Falta llenar detalles");
                    }
                    else
                    {
                        if (await this.ShowMessageAsync("Confirmacion", "¿Esta seguro de generar esta Boleta?", MessageDialogStyle.AffirmativeAndNegative) == MessageDialogResult.Affirmative)
                        {
                            AgregarBoleta();
                            await this.ShowMessageAsync("Boleta Generada",mensaje);
                            VariablesGlobales.NRO_GUIA_GLOBAL = "";
                            this.Close();
                        }
                    }

                }
                else
                {
                    await this.ShowMessageAsync("Error", "Falta llenar algunos campos");
                }
            }
            catch (Exception ex)
            {
                VariablesGlobales.NRO_GUIA_GLOBAL = "";
                MessageBox.Show( ex.Message,"Error");
            }
        }

        private async void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
             if(this.dgvListado.SelectedIndex != -1)
            {
                var detalleBoleta = this.dgvListado.SelectedItem as DetalleBoleta;
                listaDetalle.RemoveAll(x => x.ITEM==detalleBoleta.ITEM);
                item=1;
                total = 0;
                foreach (var detalle in listaDetalle)
                {
                    detalle.ITEM = item;
                    total=total+detalle.IMPORTE;
                    item++;
                }
              
                this.txtTotal.Text = total.ToString();
                LlenarGrid(listaDetalle);

            }
            else
            {
                await this.ShowMessageAsync("Error", "Seleccione un detalle");
            }
        }

        public GuiaRemision ObtenerGuia()
        {

            DetalleGuiaRemisionDAO detalleGuiaDao = new DetalleGuiaRemisionDAO();
            guiaRemision = guiaDao.ObtenerGuiaRemisionXNroGuia(VariablesGlobales.NRO_GUIA_GLOBAL);
            var listaDetalleGuia = detalleGuiaDao.listarDetalleGuiaxGuia(guiaRemision.COD_GUIA);

            this.cboCliente.DisplayMemberPath = "RAZON_SOCIAL";
            this.cboCliente.SelectedValuePath = "COD_CLI";

            this.cboCliente.Items.Add(guiaRemision.cliente);
            this.cboCliente.SelectedIndex = 0;

            this.txtDniRuc.Text = guiaRemision.cliente.RUC;
            this.txtNroGuia.Text = VariablesGlobales.NRO_GUIA_GLOBAL.ToString();
            this.cboModalidad.Items.Clear();
            ComboBoxItem itemModalidad = new ComboBoxItem();
            itemModalidad.Content = guiaRemision.TIPO_TRASLADO;
            this.cboModalidad.Items.Add(itemModalidad);

            this.cboModalidad.SelectedIndex = 0;

            this.cboModalidad.IsEnabled = false;
            DetalleBoleta detalleBoleta = null;

            foreach (var detalle in listaDetalleGuia)
            {
                detalleBoleta = new DetalleBoleta();
                detalleBoleta.CANTIDAD = detalle.CANTIDAD;
                detalleBoleta.SERVICIO = detalle.SERVICIO;
                detalleBoleta.PRECIO = detalle.SERVICIO.PRECIO;
                detalleBoleta.ITEM = item;
                detalleBoleta.IMPORTE = detalle.CANTIDAD * detalle.SERVICIO.PRECIO;
                listaDetalle.Add(detalleBoleta);



                total = total + detalleBoleta.IMPORTE;
                item++;

            }

            LlenarGrid(listaDetalle);

            this.txtTotal.Text = total.ToString();

            return guiaRemision;
        }

    }
}
