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
    public class GuiaRemisionDAO
    {

        public Object[] Agregar(GuiaRemision guiaRemision)
        {
            string cadenaConexion = "server=YOVANNY\\SQLEXPRESS;DataBase=BDJORSAC;user=sa;password=Developer2016";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_GUIA_REMISION_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_EMISION",guiaRemision.FECHA_EMISION),
                 DBHelper.MakeParam("@P_PTO_PARTIDA",guiaRemision.PTO_PARTIDA),  
                 DBHelper.MakeParam("@P_PTO_LLEGADA",guiaRemision.PTO_LLEGADA), 
                 DBHelper.MakeParam("@P_COD_CLIE",guiaRemision.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_VEHICULO_MARCA",guiaRemision.VEHICULO_MARCA),
                 DBHelper.MakeParam("@P_NRO_CERTIFICADO",guiaRemision.NRO_CERTIFICADO),
                 DBHelper.MakeParam("@P_NOMBRE_CONDUCTOR",guiaRemision.NONBRE_CONDUCTOR),
                 DBHelper.MakeParam("@P_NRO_BREVETE",guiaRemision.NRO_BREVETE),
                 DBHelper.MakeParam("@P_NOMB_TRANSPORTE",guiaRemision.NOMB_TRANSPORTE),
                 DBHelper.MakeParam("@P_RUC_TRANSPORTE",guiaRemision.RUC_TRANSPORTE),
                 DBHelper.MakeParam("@P_TIPO_COMPROB",guiaRemision.TIPO_COMPROB),
                 DBHelper.MakeParam("@P_TIPO_TRASLADO",guiaRemision.TIPO_TRASLADO),
                 DBHelper.MakeParam("@P_MTO_TRASLADO",guiaRemision.MTO_TRASLADO),
                 DBHelper.MakeParam("@P_PROVINCIA",guiaRemision.PROVINCIA),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",guiaRemision.DEPARTAMENTO),
                 DBHelper.MakeParam("@P_DISTRITO",guiaRemision.DISTRITO),
                 DBHelper.MakeParam("@P_SITUACION",guiaRemision.SITUACION),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),              
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleGuiaRemision detalle in guiaRemision.DETALLEGUIAREMISION)
                {
                    GuiaRemision guiaa = new GuiaRemision();
                    guiaa.COD_GUIA = Convert.ToInt32(salidas[0]);

                    detalle.GUIA_REMISION = guiaa;
                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle de la GUIA DE REMISIÓN :" + detalle.SERVICIO.DESCRIPCION);
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

        public string AgregarDetalle(DetalleGuiaRemision detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_GUIA_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_NRO_GUIA",detalle.GUIA_REMISION.COD_GUIA),
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }


        public List<GuiaRemision> listarGuiaRemision(string estado)
        {
            List<GuiaRemision> listaGuiaRemision = new List<GuiaRemision>();
            string query = "SP_TBL_GUIA_REMISION_LISTARTODO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_ESTADO",estado)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        ClienteDAO clienteDAO = new ClienteDAO();
                        GuiaRemision guiaRemision;
                        while (lector.Read())
                        {
                            cliente = new Cliente();
                            guiaRemision = new GuiaRemision();
                            guiaRemision.COD_GUIA=int.Parse(lector["COD_GUIA"].ToString());
                            guiaRemision.NRO_GUIA = lector["NRO_GUIA"].ToString();
                            guiaRemision.FECHA_EMISION = DateTime.Parse(lector["FECHA_EMISION"].ToString());
                            guiaRemision.PTO_PARTIDA = lector["PTO_PARTIDA"].ToString();
                            guiaRemision.PTO_LLEGADA = lector["PTO_LLEGADA"].ToString();
                            int codCliente = int.Parse(lector["COD_CLIE"].ToString());
                            cliente = clienteDAO.ObtenerCliente(codCliente);
                            guiaRemision.cliente = cliente;
                            guiaRemision.VEHICULO_MARCA = lector["VEHICULO_MARCA"].ToString();
                            guiaRemision.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                            guiaRemision.NONBRE_CONDUCTOR = lector["NOMBRE_CONDUCTOR"].ToString();
                            guiaRemision.NRO_BREVETE = lector["NRO_BREVETE"].ToString();
                            guiaRemision.NOMB_TRANSPORTE = lector["NOMB_TRANSPORTE"].ToString();
                            guiaRemision.RUC_TRANSPORTE = lector["RUC_TRANSPORTE"].ToString();
                            guiaRemision.TIPO_COMPROB = lector["TIPO_COMPROB"].ToString();
                            guiaRemision.TIPO_TRASLADO = lector["TIPO_TRASLADO"].ToString();
                            guiaRemision.MTO_TRASLADO = lector["MTO_TRASLADO"].ToString();
                            guiaRemision.PROVINCIA = lector["PROVINCIA"].ToString();
                            guiaRemision.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                            guiaRemision.DISTRITO = lector["DISTRITO"].ToString();
                            guiaRemision.SITUACION = lector["SITUACION"].ToString();
                            guiaRemision.ESTADO = lector["ESTADO"].ToString();

                            listaGuiaRemision.Add(guiaRemision);
                        }
                    }
                }
                return listaGuiaRemision;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public GuiaRemision ObtenerGuiaRemision(int codGuia)
        {
            GuiaRemision guiaRemision = null;
            string query = "SP_TBL_GUIA_REMISION_OBTENERGUIAXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                DBHelper.MakeParam("@P_COD_GUIA",codGuia)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        ClienteDAO clienteDAO = new ClienteDAO();
                        Cliente cliente = new Cliente();
                        while (lector.Read())
                        {
                            guiaRemision = new GuiaRemision();
                            guiaRemision.COD_GUIA = int.Parse(lector["COD_GUIA"].ToString());
                            guiaRemision.NRO_GUIA = lector["NRO_GUIA"].ToString();
                            guiaRemision.FECHA_EMISION = DateTime.Parse(lector["FECHA_EMISION"].ToString());
                            guiaRemision.PTO_PARTIDA = lector["PTO_PARTIDA"].ToString();
                            guiaRemision.PTO_LLEGADA = lector["PTO_LLEGADA"].ToString();
                            int codCliente = int.Parse(lector["COD_CLIE"].ToString());
                            cliente = clienteDAO.ObtenerCliente(codCliente);
                            guiaRemision.cliente = cliente;
                            guiaRemision.VEHICULO_MARCA = lector["VEHICULO_MARCA"].ToString();
                            guiaRemision.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                            guiaRemision.NONBRE_CONDUCTOR = lector["NOMBRE_CONDUCTOR"].ToString();
                            guiaRemision.NRO_BREVETE = lector["NRO_BREVETE"].ToString();
                            guiaRemision.NOMB_TRANSPORTE = lector["NOMB_TRANSPORTE"].ToString();
                            guiaRemision.RUC_TRANSPORTE = lector["RUC_TRANSPORTE"].ToString();
                            guiaRemision.TIPO_COMPROB = lector["TIPO_COMPROB"].ToString();
                            guiaRemision.TIPO_TRASLADO = lector["TIPO_TRASLADO"].ToString();
                            guiaRemision.MTO_TRASLADO = lector["MTO_TRASLADO"].ToString();
                            guiaRemision.PROVINCIA = lector["PROVINCIA"].ToString();
                            guiaRemision.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                            guiaRemision.DISTRITO = lector["DISTRITO"].ToString();
                            guiaRemision.SITUACION = lector["SITUACION"].ToString();
                            guiaRemision.ESTADO = lector["ESTADO"].ToString();

                        }
                    }

                }
                return guiaRemision;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public GuiaRemision ObtenerGuiaRemisionXNroGuia(string nroGuia)
        {
            GuiaRemision guiaRemision = null;
            string query = "SP_TBL_GUIA_REMISION_OBTENERGUIAXNROGUIA";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                DBHelper.MakeParam("@P_NRO_GUIA",nroGuia)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        ClienteDAO clienteDAO = new ClienteDAO();
                        Cliente cliente = new Cliente();
                        while (lector.Read())
                        {
                            guiaRemision = new GuiaRemision();
                            guiaRemision.COD_GUIA = int.Parse(lector["COD_GUIA"].ToString());
                            guiaRemision.NRO_GUIA = lector["NRO_GUIA"].ToString();
                            guiaRemision.FECHA_EMISION = DateTime.Parse(lector["FECHA_EMISION"].ToString());
                            guiaRemision.PTO_PARTIDA = lector["PTO_PARTIDA"].ToString();
                            guiaRemision.PTO_LLEGADA = lector["PTO_LLEGADA"].ToString();
                            int codCliente = int.Parse(lector["COD_CLIE"].ToString());
                            cliente = clienteDAO.ObtenerCliente(codCliente);
                            guiaRemision.cliente = cliente;
                            guiaRemision.VEHICULO_MARCA = lector["VEHICULO_MARCA"].ToString();
                            guiaRemision.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                            guiaRemision.NONBRE_CONDUCTOR = lector["NOMBRE_CONDUCTOR"].ToString();
                            guiaRemision.NRO_BREVETE = lector["NRO_BREVETE"].ToString();
                            guiaRemision.NOMB_TRANSPORTE = lector["NOMB_TRANSPORTE"].ToString();
                            guiaRemision.RUC_TRANSPORTE = lector["RUC_TRANSPORTE"].ToString();
                            guiaRemision.TIPO_COMPROB = lector["TIPO_COMPROB"].ToString();
                            guiaRemision.TIPO_TRASLADO = lector["TIPO_TRASLADO"].ToString();
                            guiaRemision.MTO_TRASLADO = lector["MTO_TRASLADO"].ToString();
                            guiaRemision.PROVINCIA = lector["PROVINCIA"].ToString();
                            guiaRemision.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                            guiaRemision.DISTRITO = lector["DISTRITO"].ToString();
                            guiaRemision.SITUACION = lector["SITUACION"].ToString();
                            guiaRemision.ESTADO = lector["ESTADO"].ToString();

                        }
                    }

                }
                return guiaRemision;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public string traerUltimoNroGuia()
        {
            string nro_guia = "";
            string query = "SP_TBL_GUIA_REMISION_TRAER_ULTIMO_NRO_GUIA";
            try
            {
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query))
                {
                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {
                            nro_guia = lector["NRO_GUIA"].ToString();
                        }
                    }
                }
                return nro_guia;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
