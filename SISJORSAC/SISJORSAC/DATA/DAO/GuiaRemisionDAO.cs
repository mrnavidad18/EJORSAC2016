﻿using System;
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
        ServicioDAO serviDAO = new ServicioDAO();
        ChoferDAO choferDAO = new ChoferDAO();
        public Object[] Agregar(GuiaRemision guiaRemision)
        {
            string cadenaConexion = "server=" + VariablesGlobales.MiIp() + ";DataBase=BDJORSAC;Integrated Security=True";
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
                 DBHelper.MakeParam("@P_FECHA_EMISION",guiaRemision.FECHA_EMISION==null?System.Data.SqlTypes.SqlDateTime.Null:guiaRemision.FECHA_EMISION),
                 DBHelper.MakeParam("@P_PTO_PARTIDA",guiaRemision.PTO_PARTIDA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PTO_PARTIDA.ToUpper()),  
                 DBHelper.MakeParam("@P_PTO_LLEGADA",guiaRemision.PTO_LLEGADA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PTO_LLEGADA.ToUpper()), 
                 DBHelper.MakeParam("@P_COD_CLIE",guiaRemision.cliente.COD_CLI==null?System.Data.SqlTypes.SqlInt32.Null:guiaRemision.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_COD_CHOFER",guiaRemision.CHOFER==null?System.Data.SqlTypes.SqlInt32.Null:guiaRemision.CHOFER.COD_CHOFER),                                
                 DBHelper.MakeParam("@P_NOMB_TRANSPORTE",guiaRemision.NOMB_TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.NOMB_TRANSPORTE.ToUpper()),
                 DBHelper.MakeParam("@P_RUC_TRANSPORTE",guiaRemision.RUC_TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.RUC_TRANSPORTE.Trim()),
                 DBHelper.MakeParam("@P_TIPO_COMPROB",guiaRemision.TIPO_COMPROB==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.TIPO_COMPROB.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_TRASLADO",guiaRemision.TIPO_TRASLADO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.TIPO_TRASLADO.ToUpper()),
                 DBHelper.MakeParam("@P_MTO_TRASLADO",guiaRemision.MTO_TRASLADO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.MTO_TRASLADO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",guiaRemision.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",guiaRemision.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",guiaRemision.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_SITUACION",guiaRemision.SITUACION==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.SITUACION.ToUpper()),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),              
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleGuiaRemision detalle in guiaRemision.DETALLEGUIAREMISION)
                {
                    Servicio servicioparaActualizar = new Servicio();
                    GuiaRemision guiaa = new GuiaRemision();
                    guiaa.COD_GUIA = Convert.ToInt32(salidas[0]);
                    servicioparaActualizar = serviDAO.ObtenerServicio(detalle.SERVICIO.COD_SERV);
                    if (servicioparaActualizar != null)
                    {
                        servicioparaActualizar.STOCK = servicioparaActualizar.STOCK - detalle.CANTIDAD;
                        serviDAO.ActualizarStock(servicioparaActualizar);
                    }
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
        public Object[] AgregarConNroGuia(GuiaRemision guiaRemision)
        {
            string cadenaConexion = "server=" + VariablesGlobales.MiIp() + ";DataBase=BDJORSAC;Integrated Security=True";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "[SP_TBL_GUIA_REMISION_AGREGAR_CON_NRO_GUIA]";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;


                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NRO_GUIA",guiaRemision.NRO_GUIA),
                DBHelper.MakeParam("@P_FECHA_EMISION",guiaRemision.FECHA_EMISION==null?System.Data.SqlTypes.SqlDateTime.Null:guiaRemision.FECHA_EMISION),
                 DBHelper.MakeParam("@P_PTO_PARTIDA",guiaRemision.PTO_PARTIDA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PTO_PARTIDA.ToUpper()),  
                 DBHelper.MakeParam("@P_PTO_LLEGADA",guiaRemision.PTO_LLEGADA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PTO_LLEGADA.ToUpper()), 
                 DBHelper.MakeParam("@P_COD_CLIE",guiaRemision.cliente.COD_CLI==null?System.Data.SqlTypes.SqlInt32.Null:guiaRemision.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_VEHICULO_MARCA",guiaRemision.VEHICULO_MARCA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.VEHICULO_MARCA.ToUpper()),
                 DBHelper.MakeParam("@P_NRO_CERTIFICADO",guiaRemision.NRO_CERTIFICADO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.NRO_CERTIFICADO.Trim()),
                 DBHelper.MakeParam("@P_COD_CHOFER",guiaRemision.CHOFER==null?System.Data.SqlTypes.SqlInt32.Null:guiaRemision.CHOFER.COD_CHOFER),
                 DBHelper.MakeParam("@P_NOMB_TRANSPORTE",guiaRemision.NOMB_TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.NOMB_TRANSPORTE.ToUpper()),
                 DBHelper.MakeParam("@P_RUC_TRANSPORTE",guiaRemision.RUC_TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.RUC_TRANSPORTE.Trim()),
                 DBHelper.MakeParam("@P_TIPO_COMPROB",guiaRemision.TIPO_COMPROB==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.TIPO_COMPROB.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_TRASLADO",guiaRemision.TIPO_TRASLADO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.TIPO_TRASLADO.ToUpper()),
                 DBHelper.MakeParam("@P_MTO_TRASLADO",guiaRemision.MTO_TRASLADO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.MTO_TRASLADO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",guiaRemision.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",guiaRemision.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",guiaRemision.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_SITUACION",guiaRemision.SITUACION==null?System.Data.SqlTypes.SqlString.Null:guiaRemision.SITUACION.ToUpper()),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),              
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


        public List<GuiaRemision> listarGuiaRemision(string p_busqueda,string estado)
        {
            ChoferDAO choferDao = new ChoferDAO();
            List<GuiaRemision> listaGuiaRemision = new List<GuiaRemision>();
            string query = "SP_TBL_GUIA_REMISION_LISTADOYBUSQUEDA";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@P_busqueda",p_busqueda),
                     DBHelper.MakeParam("@P_ESTADO",estado)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        Chofer chofer;
                        ClienteDAO clienteDAO = new ClienteDAO();
                        GuiaRemision guiaRemision;
                        while (lector.Read())
                        {
                            chofer = new Chofer();
                            cliente = new Cliente();
                            guiaRemision = new GuiaRemision();
                            guiaRemision.COD_GUIA=int.Parse(lector["COD_GUIA"].ToString());
                            guiaRemision.NRO_GUIA = lector["NRO_GUIA"].ToString();
                            guiaRemision.FECHA_EMISION = DateTime.Parse(lector["FECHA_EMISION"].ToString());
                            guiaRemision.PTO_PARTIDA = lector["PTO_PARTIDA"].ToString();
                            guiaRemision.PTO_LLEGADA = lector["PTO_LLEGADA"].ToString();
                            int codCliente = int.Parse(lector["COD_CLIE"].ToString());
                            int codChofer = int.Parse(lector["COD_CHOFER"].ToString());
                            cliente = clienteDAO.ObtenerCliente(codCliente);
                            chofer = choferDAO.obtenerChofer(codChofer);
                            guiaRemision.cliente = cliente;
                            guiaRemision.VEHICULO_MARCA = chofer.VEHICULO_MARCA_PLACA;
                            guiaRemision.NRO_CERTIFICADO = chofer.NRO_CERTIFICADO;
                            guiaRemision.NONBRE_CONDUCTOR = chofer.NOMBRE_COMPLETO;
                            guiaRemision.NRO_BREVETE = chofer.NRO_BREVETE;
                            //guiaRemision.CHOFER = choferDao.obtenerChofer(int.Parse(lector["COD_CHOFER"].ToString()));
                            guiaRemision.CHOFER = chofer;
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
                            guiaRemision.CLIENTEJURIDICONATURAL = lector["CLIENTE"].ToString();
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
            ChoferDAO choferDao = new ChoferDAO();
            GuiaRemision guiaRemision = null;
            Chofer chofer;
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
                            chofer = new Chofer();
                            guiaRemision = new GuiaRemision();
                            guiaRemision.COD_GUIA = int.Parse(lector["COD_GUIA"].ToString());
                            guiaRemision.NRO_GUIA = lector["NRO_GUIA"].ToString();
                            guiaRemision.FECHA_EMISION = DateTime.Parse(lector["FECHA_EMISION"].ToString());
                            guiaRemision.PTO_PARTIDA = lector["PTO_PARTIDA"].ToString();
                            guiaRemision.PTO_LLEGADA = lector["PTO_LLEGADA"].ToString();
                            int codCliente = int.Parse(lector["COD_CLIE"].ToString());
                            cliente = clienteDAO.ObtenerCliente(codCliente);
                            guiaRemision.cliente = cliente;
                            int codChofer = int.Parse(lector["COD_CHOFER"].ToString());                            
                            chofer = choferDAO.obtenerChofer(codChofer);
                            guiaRemision.cliente = cliente;
                            guiaRemision.VEHICULO_MARCA = chofer.VEHICULO_MARCA_PLACA;
                            guiaRemision.NRO_CERTIFICADO = chofer.NRO_CERTIFICADO;
                            guiaRemision.NONBRE_CONDUCTOR = chofer.NOMBRE_COMPLETO;
                            guiaRemision.NRO_BREVETE = chofer.NRO_BREVETE;
                            guiaRemision.VEHICULO_MARCA = lector["VEHICULO_MARCA"].ToString();
                            guiaRemision.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                            guiaRemision.CHOFER = choferDao.obtenerChofer(int.Parse(lector["COD_CHOFER"].ToString()));
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
            Chofer chofer;
            ChoferDAO choferDao = new ChoferDAO();
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
                        chofer = new Chofer();
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

                            int codChofer = int.Parse(lector["COD_CHOFER"].ToString());
                            chofer = choferDAO.obtenerChofer(codChofer);                            
                            guiaRemision.VEHICULO_MARCA = chofer.VEHICULO_MARCA_PLACA;
                            guiaRemision.NRO_CERTIFICADO = chofer.NRO_CERTIFICADO;
                            guiaRemision.NONBRE_CONDUCTOR = chofer.NOMBRE_COMPLETO;
                            guiaRemision.NRO_BREVETE = chofer.NRO_BREVETE;

                            guiaRemision.VEHICULO_MARCA = lector["VEHICULO_MARCA"].ToString();
                            guiaRemision.NRO_CERTIFICADO = lector["NRO_CERTIFICADO"].ToString();
                            guiaRemision.CHOFER = choferDao.obtenerChofer(int.Parse(lector["COD_CHOFER"].ToString()));
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
