using SISJORSAC.DATA.Conexion;
using SISJORSAC.DATA.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISJORSAC.DATA.DAO
{
    public class BoletaDAO
    {
        public Object[] AgregarBoleta(Boleta boleta)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=Developer2016";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_BOLETA_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",boleta.FECHA_EMISION),
                 DBHelper.MakeParam("@P_COD_CLI",boleta.cliente.COD_CLI), 
                 DBHelper.MakeParam("@P_COD_GUIA",boleta.GUIA==null?System.Data.SqlTypes.SqlInt32.Null:boleta.GUIA.COD_GUIA),
                 DBHelper.MakeParam("@P_MODALIDAD",boleta.MODALIDAD),              
                 DBHelper.MakeParam("@P_OBSERVACION",boleta.OBSERVACION),
                 DBHelper.MakeParam("@P_TOTAL",boleta.TOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleBoleta detalle in boleta.DETALLEBOLETA)
                {
                    Boleta bol = new Boleta();
                    bol.NRO_CP = Convert.ToInt32(salidas[0]);
                    detalle.BOLETA = bol;
                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle de la boleta :" + detalle.SERVICIO.DESCRIPCION);
                    }
                }
                trx.Commit();
                cn.Close();
                return salidas;

            }
            catch (Exception ex)
            {
                trx.Rollback();
                cn.Close();
                throw ex;
            }

        }

        public Object[] AgregarBoletaConNroBoleta(Boleta boleta)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=Developer2016";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_BOLETA_AGREGAR_CON_NRO_BOLETA";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NRO_BOLETA",boleta.NRO_BOLETA),
                 DBHelper.MakeParam("@P_FECHA_EMISION",boleta.FECHA_EMISION),
                 DBHelper.MakeParam("@P_COD_CLI",boleta.cliente.COD_CLI), 
                 DBHelper.MakeParam("@P_COD_GUIA",boleta.GUIA==null?System.Data.SqlTypes.SqlInt32.Null:boleta.GUIA.COD_GUIA),
                 DBHelper.MakeParam("@P_MODALIDAD",boleta.MODALIDAD),              
                 DBHelper.MakeParam("@P_OBSERVACION",boleta.OBSERVACION),
                 DBHelper.MakeParam("@P_TOTAL",boleta.TOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleBoleta detalle in boleta.DETALLEBOLETA)
                {
                    Boleta bol = new Boleta();
                    bol.NRO_CP = Convert.ToInt32(salidas[0]);
                    detalle.BOLETA = bol;
                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle de la boleta :" + detalle.SERVICIO.DESCRIPCION);
                    }
                }
                trx.Commit();
                cn.Close();
                return salidas;

            }
            catch (Exception ex)
            {
                trx.Rollback();
                cn.Close();
                throw ex;
            }

        }
        public string AgregarDetalleSinTransacion(DetalleBoleta detalle)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_BOLETA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_BOLETA",detalle.BOLETA.NRO_CP),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),              
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                msj
             };

            return salidas = DBHelper.ExecuteProcedure(query, dbParams);
        }

        public string AgregarDetalle(DetalleBoleta detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_BOLETA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_BOLETA",detalle.BOLETA.NRO_CP),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),              
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }

        public Boleta ObtenerXCodBoleta(int CodBoleta)
        {
            try
            {
                Boleta boleta = null;
                ClienteDAO clienteDao = new ClienteDAO();
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
                string query = "SP_TBL_BOLETA_LISTAR_XCOD_BOLETA";
                SqlParameter[] param = new SqlParameter[]
                {
                      DBHelper.MakeParam("@P_COD_BOL",CodBoleta),
                      DBHelper.MakeParam("@P_ESTADO","DISPONIBLE")
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, param))
                {

                    if (lector != null && lector.HasRows)
                    {
                        ///COD_BOL, FECHA_EMISION, NRO_BOLETA, COD_CLI, MODALIDAD, OBSERVACION, TOTAL, ESTADO
                        while (lector.Read())
                        {
                            boleta = new Boleta();
                            boleta.NRO_CP = Convert.ToInt32(lector["COD_BOL"].ToString());
                            boleta.FECHA_EMISION = Convert.ToDateTime(lector["FECHA_EMISION"].ToString());
                            boleta.NRO_BOLETA = lector["NRO_BOLETA"].ToString();
                            boleta.MODALIDAD = lector["MODALIDAD"].ToString();
                            boleta.OBSERVACION = lector["OBSERVACION"].ToString();
                            boleta.TOTAL = Convert.ToDouble(lector["TOTAL"].ToString());
                            boleta.ESTADO = lector["ESTADO"].ToString();
                            boleta.cliente = clienteDao.ObtenerCliente(Convert.ToInt32(lector["COD_CLI"].ToString()));
                            if (lector["COD_GUIA"] == DBNull.Value)
                            {
                                boleta.GUIA = null;
                            }
                            else
                            {
                                boleta.GUIA = guiaDao.ObtenerGuiaRemision(Convert.ToInt32(lector["NRO_GUIA"].ToString()));
                            }
                        }
                    }
                }

                return boleta;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al obtener un usuario");
            }

        }

        public List<Boleta> ListarBoletas(string estado)
        {
            try
            {
                List<Boleta> lista = null;
                ClienteDAO clienteDao = new ClienteDAO();
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
                string query = "SP_TBL_BOLETA_LISTAR";

                SqlParameter[] param = new SqlParameter[]
                {
                      DBHelper.MakeParam("@P_ESTADO",estado)
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, param))
                {

                    if (lector != null && lector.HasRows)
                    {
                        lista = new List<Boleta>();
                        Boleta boleta;
                        while (lector.Read())
                        {
                            boleta = new Boleta();
                            boleta.NRO_CP = Convert.ToInt32(lector["COD_BOL"].ToString());
                            boleta.FECHA_EMISION = Convert.ToDateTime(lector["FECHA_EMISION"].ToString());
                            boleta.NRO_BOLETA = lector["NRO_BOLETA"].ToString();
                            boleta.MODALIDAD = lector["MODALIDAD"].ToString();
                            boleta.OBSERVACION = lector["OBSERVACION"].ToString();
                            boleta.TOTAL = Convert.ToDouble(lector["TOTAL"].ToString());
                            boleta.ESTADO = lector["ESTADO"].ToString();
                            boleta.cliente = clienteDao.ObtenerCliente(Convert.ToInt32(lector["COD_CLI"].ToString()));
                            if (lector["COD_GUIA"] == DBNull.Value)
                            {
                                boleta.GUIA = null;
                            }
                            else
                            {
                                boleta.GUIA = guiaDao.ObtenerGuiaRemision(Convert.ToInt32(lector["NRO_GUIA"].ToString()));
                            }
                            lista.Add(boleta);
                        }
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al listar los Boletas");
            }

        }

        public string ActualizarBoleta(Boleta boleta)
        {
            string cadenaConexion = "server=192.168.0.26;DataBase=BDJORSAC;user=sa;password=2015159";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {

                string query = "SP_TBL_BOLETA_ACTUALIZAR";

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",boleta.FECHA_EMISION),
                 DBHelper.MakeParam("@P_COD_CLI",boleta.cliente.COD_CLI),  
                 DBHelper.MakeParam("@P_MODALIDAD",boleta.MODALIDAD),              
                 DBHelper.MakeParam("@P_OBSERVACION",boleta.OBSERVACION),
                 DBHelper.MakeParam("@P_TOTAL",boleta.TOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                 DBHelper.MakeParam("@P_COD_BOL",boleta.NRO_CP),
                 DBHelper.MakeParam("@P_NRO_BOLETA",boleta.NRO_BOLETA),
                 msj
             };



                string mensaje = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);

                foreach (DetalleBoleta detalle in boleta.DETALLEBOLETA)
                {
                    Boleta bol = new Boleta();
                    bol.NRO_CP = boleta.NRO_CP;
                    detalle.BOLETA = bol;
                    if (ActualizarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la ACTUALIZACION del detalle de la boleta :" + detalle.SERVICIO.DESCRIPCION);
                    }
                }
                trx.Commit();
                cn.Close();
                return mensaje;

            }
            catch (Exception ex)
            {
                trx.Rollback();
                cn.Close();
                throw ex;
            }

        }

        public string ActualizarDetalle(DetalleBoleta detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_BOLETA_ACTUALIZAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_BOLETA",detalle.BOLETA.NRO_CP),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),              
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                 DBHelper.MakeParam("@P_COD_DETALLE",detalle.COD_DETALLE),
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }

       


        public string ObtenerNroBoleta()
        {
            try
            {
                string nroFactura = "";
                string query = "SP_TBL_BOLETA_TRAER_ULTIMO_NRO_BOLETA";
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query))
                {

                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {

                            nroFactura = lector["NRO_BOLETA"].ToString();



                        }
                    }
                }

                return nroFactura;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al recuperar el ultimo nro. factura");
            }

        }
    }
}
