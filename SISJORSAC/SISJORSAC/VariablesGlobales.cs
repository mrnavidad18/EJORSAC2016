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
        public static Cliente clienteFactura=null;
        public static bool ClickFacturaContrato = false;
        
    }
}
