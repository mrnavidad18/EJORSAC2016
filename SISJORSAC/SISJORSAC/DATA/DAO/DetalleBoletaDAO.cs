using SISJORSAC.DATA.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SISJORSAC.DATA.Conexion;

namespace SISJORSAC.DATA.DAO
{
    class DetalleBoletaDAO
    {
        public List<DetalleBoleta> ListarXBoletas(int COD_BOLETA)
        {
            List<DetalleBoleta> lista = null;
            ServicioDAO servicioDao= new ServicioDAO();
            BoletaDAO boletaDao = new BoletaDAO();

            string query = "SP_TBL_DETALLE_BOLETA_LISTAR";

            try
            {
                SqlParameter[] param = new SqlParameter[]
                {
                    DBHelper.MakeParam("@P_COD_BOLETA",COD_BOLETA)
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReader(query, param))
                {
                    if (lector != null && lector.HasRows)
                    {
                        DetalleBoleta detalle;
                        while (lector.Read())
                        {
                            detalle = new DetalleBoleta();
                            detalle.COD_DETALLE = Convert.ToInt32(lector["COD_DETALLE"]);
                            detalle.CANTIDAD = Convert.ToInt32(lector["CANTIDAD"]);
                            detalle.PRECIO = Convert.ToInt32(lector["PRECIO"]);
                            detalle.IMPORTE = Convert.ToInt32(lector["IMPORTE"]);
                            detalle.BOLETA = boletaDao.ObtenerXCodBoleta(Convert.ToInt32(lector["COD_BOLETA"]));
                            detalle.SERVICIO=servicioDao
                            lista.Add(detalle);
                        }
                    }
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
