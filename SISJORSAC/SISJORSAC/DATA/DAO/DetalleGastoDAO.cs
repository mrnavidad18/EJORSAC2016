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
    public class DetalleGastoDAO
    {

        public List<DetalleGasto> listarDetalleGasto(int codGasto)
        {
            List<DetalleGasto> listaDetalleGasto = new List<DetalleGasto>();
            string query = "SP_TBL_DETALLE_GASTO_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                  DBHelper.MakeParam("@P_COD_GASTO ",codGasto)
                };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        
                        GastoDAO gastoDAO = new GastoDAO();
                        ConceptoGastoDAO conceptoGastoDAO = new ConceptoGastoDAO();
                        Gasto gasto;
                        ConceptoGasto conceptoGasto;
                        DetalleGasto detallegasto;

                        while (lector.Read())
                        {
                            detallegasto = new DetalleGasto();
                            gasto = new Gasto();
                            conceptoGasto = new ConceptoGasto();

                            detallegasto.COD_DETALLE=int.Parse(lector["COD_DETALLE"].ToString());
                            gasto = gastoDAO.ObtenerGasto(int.Parse(lector["COD_GASTO"].ToString()));
                            detallegasto.GASTO = gasto;
                            conceptoGasto = conceptoGastoDAO.ObtenerConceptoGasto(int.Parse(lector["COD_CON_GAS"].ToString()));
                            detallegasto.ConceptoGasto = conceptoGasto;
                            detallegasto.ITEM = int.Parse(lector["ITEM"].ToString());
                            detallegasto.CANTIDAD = int.Parse(lector["CANTIDAD"].ToString());
                            detallegasto.PRECIO = double.Parse(lector["PRECIO"].ToString());
                            listaDetalleGasto.Add(detallegasto);
                        }
                    }
                }
                return listaDetalleGasto;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
