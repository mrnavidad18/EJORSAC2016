using SISJORSAC.DATA.Conexion;
using SISJORSAC.DATA.Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.DAO
{
    class DetalleFacturaDAO
    {
        public List<DetalleFactura> ListarDetallesXFactura(int COD_Factura)
        {
            List<DetalleFactura> lista = null;
            ServicioDAO servicioDao = new ServicioDAO();
            FacturaDAO facturaDAO = new FacturaDAO();

            string query = "SP_TBL_DETALLE_FACTURA_LISTAR";

            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    DBHelper.MakeParam("@P_COD_FACTURA",COD_Factura)
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, param))
                {
                    if (lector != null && lector.HasRows)
                    {
                        lista = new List<DetalleFactura>();
                        DetalleFactura detalle;
                        while (lector.Read())
                        {///  
                            detalle = new DetalleFactura();
                            detalle.ITEM = Convert.ToInt32(lector["ITEM"]);
                            detalle.COD_DETALLE = Convert.ToInt32(lector["COD_DETALLE"]);
                            detalle.CANTIDAD = Convert.ToInt32(lector["CANTIDAD"]);
                            detalle.PRECIO = Convert.ToDouble(lector["PRECIO"]);
                            detalle.IMPORTE = Convert.ToInt32(lector["IMPORTE"]);
                            detalle.FACTURA = facturaDAO.ObtenerFacturaXCodigo(Convert.ToInt32(lector["COD_FACTURA"]));
                            detalle.SERVICIO = servicioDao.ObtenerServicio(Convert.ToInt32(lector["COD_SERV"]));
                            lista.Add(detalle);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw new Exception("Se produjo un error al listar el detalle de las facturas");
            }
        }
    }
}
