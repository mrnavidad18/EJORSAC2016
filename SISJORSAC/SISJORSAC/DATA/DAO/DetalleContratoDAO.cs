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
    public class DetalleContratoDAO
    {

        public List<DetalleContrato> listarDetalleContratoxContrato(int codContrato)
        {
            List<DetalleContrato> listaDetalleContrato = new List<DetalleContrato>();
              string query = "SP_TBL_DETALLE_CONTRATO_LISTARXContrato";
              try
                {
                SqlParameter[] dbParams = new SqlParameter[]{
                  DBHelper.MakeParam("@P_COD_CONTRATO ",codContrato)
                };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Servicio servicio;
                        ServicioDAO servicioDAO = new ServicioDAO();
                        ContratoDAO contratoDAO = new ContratoDAO();
                        Contrato contrato;                       
                        DetalleContrato detalleContrato;
                        while (lector.Read())
                        {
                            detalleContrato = new DetalleContrato();
                            servicio =new Servicio();
                            contrato = new Contrato();
                            detalleContrato.COD_DETALLE=int.Parse(lector["COD_DETALLE"].ToString());
                            contrato = contratoDAO.ObtenerContrato(int.Parse(lector["COD_CONTRATO"].ToString()));
                            detalleContrato.CONTRATO = contrato;
                            servicio = servicioDAO.ObtenerServicio(int.Parse(lector["COD_SERV"].ToString()));
                            detalleContrato.SERVICIO = servicio;
                            detalleContrato.ITEM = int.Parse(lector["ITEM"].ToString());
                            detalleContrato.CANTIDAD = int.Parse(lector["CANTIDAD"].ToString());
                            detalleContrato.PRECIO = double.Parse(lector["PRECIO"].ToString());
                            detalleContrato.IMPORTE = double.Parse(lector["IMPORTE"].ToString());
                            listaDetalleContrato.Add(detalleContrato);
                        }
                    }
                }
                return listaDetalleContrato;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
