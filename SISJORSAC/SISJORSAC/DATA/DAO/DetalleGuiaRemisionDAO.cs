using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISJORSAC.DATA.Conexion;
using SISJORSAC.DATA.Modelo;
using System.Data;
using System.Data.SqlClient;

namespace SISJORSAC.DATA.DAO
{
    public class DetalleGuiaRemisionDAO
    {
        public List<DetalleGuiaRemision> listarDetalleGuiaxGuia(int codGuia)
        {
            List<DetalleGuiaRemision> listaDetalleGuia = new List<DetalleGuiaRemision>();
            string query = "SP_TBL_DETALLE_GUIA_LISTARXGUIA";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                  DBHelper.MakeParam("@P_NRO_GUIA ",codGuia)
                };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Servicio servicio;
                        ServicioDAO servicioDAO = new ServicioDAO();
                        GuiaRemisionDAO guiaRemisionDAO = new GuiaRemisionDAO();
                        GuiaRemision guiaRemision;
                        DetalleGuiaRemision detalleGuiaRemision;
                        while (lector.Read())
                        {
                            detalleGuiaRemision = new DetalleGuiaRemision();
                            servicio = new Servicio();
                            guiaRemision = new GuiaRemision();
                            detalleGuiaRemision.COD_DETALLE = int.Parse(lector["COD_DETALLE"].ToString());
                            guiaRemision=guiaRemisionDAO.ObtenerGuiaRemision(int.Parse(lector["NRO_GUIA"].ToString()));
                            detalleGuiaRemision.GUIA_REMISION = guiaRemision;
                            servicio = servicioDAO.ObtenerServicio(int.Parse(lector["COD_SERV"].ToString()));
                            detalleGuiaRemision.SERVICIO = servicio;
                            detalleGuiaRemision.ITEM = int.Parse(lector["ITEM"].ToString());
                            detalleGuiaRemision.CANTIDAD = int.Parse(lector["CANTIDAD"].ToString());
                            listaDetalleGuia.Add(detalleGuiaRemision);
                        }
                    }
                }
                return listaDetalleGuia;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
