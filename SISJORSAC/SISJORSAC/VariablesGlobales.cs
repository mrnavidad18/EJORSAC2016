using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SISJORSAC.DATA.Modelo;

namespace SISJORSAC
{
    public class VariablesGlobales
    {
        public static string NRO_GUIA_GLOBAL = "";
        public static string MiIp()
        {

            IPHostEntry host;
            string localIp = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    localIp = ip.ToString();
                }
            }
            return localIp;
        }

        public static Usuario usuarioConectado;
        public static int indexCliente;
        public static List<DetalleFactura> listaDetallesFactura = new List<DetalleFactura>();
        public static List<DetalleContrato> listaDetallesContrato = new List<DetalleContrato>();
        public static List<DetalleBoleta> listaDetallesBoleta= new List<DetalleBoleta>();
        public static Cliente clienteFactura=null;
        public static Cliente clienteBoleta = null;
        public static Cliente clienteContrato = null;
        public static bool ClickFacturaContrato = false;
        public static bool ClickFacturaBoleta = false;
        public static bool ClickFacturaGuia = false;
        public static bool ClickBoletaFactura = false;
        public static bool ClickBoletaContrato = false;
        public static bool ClickFacturaConGuia = false;
        public static bool ClickBoletaConGuia = false;
        public static bool ClickBoletaGuia = false;
        public static List<DetalleGuiaRemision> listaDetallesGuia = new List<DetalleGuiaRemision>();
        
    }
}
