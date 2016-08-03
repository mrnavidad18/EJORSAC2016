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
    public class FacturaDAO
    {

      

        public Object[] AgregarFactura(Factura factura)
        {

            string cadenaConexion = "server=YOVANNY\\SQLEXPRESS;DataBase=BDJORSAC;user=sa;password=Developer2016";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            
            cn.Open();

            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_FACTURA_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;

                //SqlParameter pguia;
                //if (factura.guiaRemision == null)
                //{
                //    pguia = new SqlParameter("@P_NRO_GUIA",DBNull.Value);
                //    pguia.Value = DBNull.Value;
                //}
                //else
                //{
                //    pguia = new SqlParameter("@P_NRO_GUIA",factura.guiaRemision.COD_GUIA);
                //    pguia.Value = factura.guiaRemision.COD_GUIA;
                //}

                SqlParameter[] dbParams = new SqlParameter[]
             {
                DBHelper.MakeParam("@P_FECHA_EMISION",factura.FECHA_EMISION),
                DBHelper.MakeParam("@P_COD_CLI",factura.cliente.COD_CLI ),
                DBHelper.MakeParam("@P_NRO_GUIA",factura.guiaRemision==null?System.Data.SqlTypes.SqlInt32.Null:factura.guiaRemision.COD_GUIA),
                DBHelper.MakeParam("@P_MODALIDAD", factura.MODALIDAD==null?System.Data.SqlTypes.SqlString.Null:factura.MODALIDAD.ToUpper()),
                DBHelper.MakeParam("@P_OBSERVACION", factura.OBSERVACION==null?System.Data.SqlTypes.SqlString.Null:factura.OBSERVACION.ToUpper()),
                DBHelper.MakeParam("@P_SUB_TOTAL",factura.SUB_TOTAL==null?System.Data.SqlTypes.SqlDouble.Null:factura.SUB_TOTAL),
                DBHelper.MakeParam("@P_IGV",factura.IGV==null?System.Data.SqlTypes.SqlDouble.Null:factura.IGV ),                     
                DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),              
                id,
                msj
                
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleFactura detalle in factura.DETALLEFACTURA)
                {
                    Factura factu = new Factura();
                    factu.COD_FAC = Convert.ToInt32(salidas[0]);
                    detalle.FACTURA = factu;
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

        public string AgregarDetalle(DetalleFactura detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_FACTURA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_COD_FACTURA",detalle.FACTURA.COD_FAC),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),                               
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }

        public Factura ObtenerFacturaXCodigo(int CodFactura)
        {
            try
            {
                Factura factura = null;
                ClienteDAO clienteDao = new ClienteDAO();
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
             
                string query = "SP_TBL_FACTURA_LISTAR_XcODIGO";
                SqlParameter[] param = new SqlParameter[]
                {
                      DBHelper.MakeParam("@P_COD_FAC",CodFactura),
                      DBHelper.MakeParam("@P_ESTADO","DISPONIBLE")
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query,param))
                {

                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {
                            factura = new Factura();
                            factura.COD_FAC = Convert.ToInt32(lector["COD_FAC"].ToString());
                            factura.FECHA_EMISION = Convert.ToDateTime(lector["FECHA_EMISION"].ToString());
                            factura.NRO_FACTURA = lector["NRO_FACTURA"].ToString();
                            factura.MODALIDAD = lector["MODALIDAD"].ToString();
                            factura.OBSERVACION = lector["OBSERVACION"].ToString();
                            factura.SUB_TOTAL = Convert.ToDouble(lector["SUB_TOTAL"].ToString());
                            factura.IGV = Convert.ToDouble(lector["IGV"].ToString());
                            factura.TOTAL = Convert.ToDouble(lector["TOTAL"].ToString());
                            factura.ESTADO = lector["ESTADO"].ToString();
                            factura.cliente = clienteDao.ObtenerCliente(Convert.ToInt32(lector["COD_CLI"].ToString()));
                            if (lector["NRO_GUIA"] == DBNull.Value)
                            {
                                factura.guiaRemision = null;
                            }
                            else
                            {
                                factura.guiaRemision = guiaDao.ObtenerGuiaRemision(Convert.ToInt32(lector["NRO_GUIA"].ToString()));
                            }
                        
                            
                        }
                    }
                }

                return factura;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al obtener la factura");
            }

        }

        public List<Factura> listarFacturas(string estado)
        {
            try
            {
                List<Factura> lista = null;

                ClienteDAO clienteDao = new ClienteDAO();
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();
                
                string query = "SP_TBL_FACTURA_LISTAR";
                SqlParameter[] param = new SqlParameter[]
                {
                      DBHelper.MakeParam("@P_ESTADO",estado)
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, param))
                {

                    if (lector != null && lector.HasRows)
                    {
                        lista = new List<Factura>();
                        Factura factura;
                        while (lector.Read())
                        {
                            factura = new Factura();
                            factura.COD_FAC = Convert.ToInt32(lector["COD_FAC"].ToString());
                            factura.FECHA_EMISION = Convert.ToDateTime(lector["FECHA_EMISION"].ToString());
                            factura.NRO_FACTURA = lector["NRO_FACTURA"].ToString();
                            factura.MODALIDAD = lector["MODALIDAD"].ToString();
                            factura.OBSERVACION = lector["OBSERVACION"].ToString();
                            factura.SUB_TOTAL = Convert.ToDouble(lector["SUB_TOTAL"].ToString());
                            factura.IGV = Convert.ToDouble(lector["IGV"].ToString());
                            factura.TOTAL = Convert.ToDouble(lector["TOTAL"].ToString());
                            factura.ESTADO = lector["ESTADO"].ToString();
                            factura.cliente = clienteDao.ObtenerCliente(Convert.ToInt32(lector["COD_CLI"].ToString()));
                            
                            if (lector["NRO_GUIA"]== DBNull.Value)
                            {
                                factura.guiaRemision = null;
                            }
                            else
                            {
                                factura.guiaRemision = guiaDao.ObtenerGuiaRemision(Convert.ToInt32(lector["NRO_GUIA"].ToString()));
                            }
                           
                            lista.Add(factura);
                        }
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al obtener la factura");
            }

        }
        public List<Factura> BuscarPorNroFactura(string NroFactura)
        {
            try
            {
                List<Factura> lista = null;

                ClienteDAO clienteDao = new ClienteDAO();
                GuiaRemisionDAO guiaDao = new GuiaRemisionDAO();

                string query = "SP_TBL_FACTURA_BUSCAR_NRO_FACTURA";
                SqlParameter[] param = new SqlParameter[]
                {
                      DBHelper.MakeParam("@P_NRO_FACTURA",NroFactura)
                };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, param))
                {

                    if (lector != null && lector.HasRows)
                    {
                        lista = new List<Factura>();
                        Factura factura;
                        while (lector.Read())
                        {
                            factura = new Factura();
                            factura.COD_FAC = Convert.ToInt32(lector["COD_FAC"].ToString());
                            factura.FECHA_EMISION = Convert.ToDateTime(lector["FECHA_EMISION"].ToString());
                            factura.NRO_FACTURA = lector["NRO_FACTURA"].ToString();
                            factura.MODALIDAD = lector["MODALIDAD"].ToString();
                            factura.OBSERVACION = lector["OBSERVACION"].ToString();
                            factura.SUB_TOTAL = Convert.ToDouble(lector["SUB_TOTAL"].ToString());
                            factura.IGV = Convert.ToDouble(lector["IGV"].ToString());
                            factura.TOTAL = Convert.ToDouble(lector["TOTAL"].ToString());
                            factura.ESTADO = lector["ESTADO"].ToString();
                            factura.cliente = clienteDao.ObtenerCliente(Convert.ToInt32(lector["COD_CLI"].ToString()));

                            if (lector["NRO_GUIA"] == DBNull.Value)
                            {
                                factura.guiaRemision = null;
                            }
                            else
                            {
                                factura.guiaRemision = guiaDao.ObtenerGuiaRemision(Convert.ToInt32(lector["NRO_GUIA"].ToString()));
                            }

                            lista.Add(factura);
                        }
                    }
                }

                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al obtener la factura");
            }

        }

        public string ObtenerNroFactura()
        {
            try
            {
                string nroFactura="";
                string query = "SP_TBL_FACTURA_TRAER_ULTIMO_NRO_FACTURA";
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query))
                {

                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {

                            nroFactura = lector["NRO_FACTURA"].ToString();
                          


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

        public Object[] AgregarFacturaConNroFac(Factura factura)
        {
            string cadenaConexion = "server=YOVANNY\\SQLEXPRESS;DataBase=BDJORSAC;user=sa;password=Developer2016";

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
                 DBHelper.MakeParam("@P_NRO_FACTURA",factura.NRO_FACTURA),
                 DBHelper.MakeParam("@P_FECHA_EMISION",factura.FECHA_EMISION ),
                DBHelper.MakeParam("@P_COD_CLI",factura.cliente.COD_CLI ),
                 DBHelper.MakeParam("@P_NRO_GUIA",factura.guiaRemision==null?System.Data.SqlTypes.SqlInt32.Null:factura.guiaRemision.COD_GUIA),                  
                DBHelper.MakeParam("@P_MODALIDAD", factura.MODALIDAD==null?System.Data.SqlTypes.SqlString.Null:factura.MODALIDAD.ToUpper()),
                DBHelper.MakeParam("@P_OBSERVACION", factura.OBSERVACION==null?System.Data.SqlTypes.SqlString.Null:factura.OBSERVACION.ToUpper()),
                DBHelper.MakeParam("@P_SUB_TOTAL",factura.SUB_TOTAL==null?System.Data.SqlTypes.SqlDouble.Null:factura.SUB_TOTAL),
                DBHelper.MakeParam("@P_IGV",factura.IGV==null?System.Data.SqlTypes.SqlDouble.Null:factura.IGV ),                      
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),              
                id,
                msj
                
             };
                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleFactura detalle in factura.DETALLEFACTURA)
                {
                    Factura factu = new Factura();
                    factu.COD_FAC = Convert.ToInt32(salidas[0]);
                    detalle.FACTURA = factu;
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
    }
}
