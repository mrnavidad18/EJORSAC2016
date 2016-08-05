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
    public class ContratoDAO
    {

        public Object[] Agregar(Contrato contrato)
        {
            string cadenaConexion = "server=10.0.2.15;DataBase=BDJORSAC;user=sa;password=BaseDeDatos2015";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_CONTRATO_AGREGAR";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;

                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_FECHA_CONTRATO",contrato.FECHA_CONTRATO==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_CONTRATO),
                 DBHelper.MakeParam("@P_COD_CLI",contrato.cliente.COD_CLI==null?System.Data.SqlTypes.SqlInt32.Null:contrato.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_DIRECCION_OBRA",contrato.DIRECCION_OBRA==null?System.Data.SqlTypes.SqlString.Null:contrato.DIRECCION_OBRA.ToUpper()),
                 DBHelper.MakeParam("@P_TRANSPORTE",contrato.TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:contrato.TRANSPORTE.ToUpper()),
                 DBHelper.MakeParam("@P_idUsuario",contrato.usuario.idUsuario==null?System.Data.SqlTypes.SqlInt32.Null:contrato.usuario.idUsuario),
                 DBHelper.MakeParam("@P_TOTAL_DIAS",contrato.TOTAL_DIAS==null?System.Data.SqlTypes.SqlInt32.Null:contrato.TOTAL_DIAS),
                 DBHelper.MakeParam("@P_FECHA_ENTREGA",contrato.FECHA_ENTREGA==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_ENTREGA),
                 DBHelper.MakeParam("@P_HORA_ENTREGA",contrato.HORA_ENTREGA),
                 DBHelper.MakeParam("@P_FECHA_DEVOLUCION",contrato.FECHA_DEVOLUCION==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_DEVOLUCION),
                 DBHelper.MakeParam("@P_HORA_DEVOLUCION",contrato.HORA_DEVOLUCION),
                 DBHelper.MakeParam("@P_MONEDA",contrato.MONEDA==null?System.Data.SqlTypes.SqlString.Null:contrato.MONEDA.ToUpper()),
                 DBHelper.MakeParam("@P_GARANTIA",contrato.GARANTIA==null?System.Data.SqlTypes.SqlDouble.Null:contrato.GARANTIA),
                 DBHelper.MakeParam("@P_CHEQUE",contrato.CHEQUE==null?System.Data.SqlTypes.SqlString.Null:contrato.CHEQUE),
                 DBHelper.MakeParam("@P_DOCUMENTO",contrato.DOCUMENTO==null?System.Data.SqlTypes.SqlString.Null:contrato.DOCUMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_RECIBO",contrato.RECIBO==null?System.Data.SqlTypes.SqlString.Null:contrato.RECIBO),
                 DBHelper.MakeParam("@P_IGV",contrato.IGV==null?System.Data.SqlTypes.SqlDouble.Null:contrato.IGV),
                 DBHelper.MakeParam("@P_SUBTOTAL",contrato.SUBTOTAL==null?System.Data.SqlTypes.SqlDouble.Null:contrato.SUBTOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),                             
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleContrato detalle in contrato.DETALLECONTRATO)
                {
                    Contrato contra = new Contrato();
                    contra.COD_CONTRATO = Convert.ToInt32(salidas[0]);
                    detalle.CONTRATO = contra;
                   
                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle del Contrato :" + detalle.SERVICIO.DESCRIPCION);
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
        public string AgregarDetalle(DetalleContrato detalle, SqlTransaction trx, SqlConnection cn)
        {

            string salidas;
            string query = "SP_TBL_DETALLE_CONTRATO_AGREGAR";

            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;


            SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_COD_CONTRATO",detalle.CONTRATO.COD_CONTRATO),
                 DBHelper.MakeParam("@P_COD_SERV",detalle.SERVICIO.COD_SERV),
                 DBHelper.MakeParam("@P_ITEM",detalle.ITEM),  
                 DBHelper.MakeParam("@P_CANTIDAD",detalle.CANTIDAD),                               
                 DBHelper.MakeParam("@P_PRECIO",detalle.PRECIO),
                msj
             };

            return salidas = DBHelper.ExecuteProcedureDetalles(query, dbParams, trx, cn);
        }
        public List<Contrato> listarContrato(string p_busqueda,string estado)
        {
            List<Contrato> listaContrato = new List<Contrato>();
            string query = "SP_TBL_CONTRATO_LISTADOYBUSQUEDA";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                    DBHelper.MakeParam("@P_Busqueda",p_busqueda),
                     DBHelper.MakeParam("@P_ESTADO",estado)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        Usuario usuario;
                        ClienteDAO clienteDAO = new ClienteDAO();
                        UsuarioDAO usuarioDAO = new UsuarioDAO();
                        Contrato contrato;
                        while (lector.Read())
                        {
                            usuario = new Usuario();
                            cliente = new Cliente();
                            contrato = new Contrato();
                            contrato.COD_CONTRATO=int.Parse(lector["COD_CONTRATO"].ToString());
                            contrato.NRO_CONTRATO=lector["NRO_CONTRATO"].ToString();
                            contrato.FECHA_CONTRATO=DateTime.Parse(lector["FECHA_CONTRATO"].ToString());
                            cliente=clienteDAO.ObtenerCliente(int.Parse(lector["COD_CLI"].ToString()));
                            contrato.cliente=cliente;
                            contrato.DIRECCION_OBRA=lector["DIRECCION_OBRA"].ToString();
                            contrato.TRANSPORTE=lector["TRANSPORTE"].ToString();
                            usuario=usuarioDAO.ObtenerUsuario(int.Parse(lector["idUsuario"].ToString()));
                            contrato.usuario=usuario;
                            contrato.TOTAL_DIAS = int.Parse(lector["TOTAL_DIAS"].ToString());
                            contrato.FECHA_ENTREGA = DateTime.Parse(lector["FECHA_ENTREGA"].ToString());
                            contrato.HORA_ENTREGA = TimeSpan.Parse(lector["HORA_ENTREGA"].ToString());
                            contrato.FECHA_DEVOLUCION = DateTime.Parse(lector["FECHA_DEVOLUCION"].ToString());
                            contrato.HORA_DEVOLUCION = TimeSpan.Parse(lector["HORA_DEVOLUCION"].ToString());
                            contrato.MONEDA = lector["MONEDA"].ToString();
                            contrato.GARANTIA = double.Parse(lector["GARANTIA"].ToString());
                            contrato.CHEQUE = lector["CHEQUE"].ToString();
                            contrato.DOCUMENTO = lector["DOCUMENTO"].ToString();
                            contrato.RECIBO = lector["RECIBO"].ToString();
                            contrato.IGV = double.Parse(lector["IGV"].ToString());
                            contrato.SUBTOTAL = double.Parse(lector["SUBTOTAL"].ToString());
                            contrato.TOTAL = double.Parse(lector["TOTAL"].ToString());
                            contrato.ESTADO = lector["ESTADO"].ToString();
                            contrato.USUARIONOMBRE = lector["USUARIO"].ToString();
                            contrato.CLIENTEJURIDICONATURAL = lector["CLIENTE"].ToString();
                            listaContrato.Add(contrato);
                        }
                    }
                }
                return listaContrato;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al buscar el contrato");
            }

        }

        public Contrato ObtenerContrato(int codContra)
        {

            Contrato contrato = new Contrato();
            string query = "SP_TBL_CONTRATO_OBTENERCONTRATOXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_COD_CONTRATO ",codContra)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        Usuario usuario;
                        ClienteDAO clienteDAO = new ClienteDAO();
                        UsuarioDAO usuarioDAO = new UsuarioDAO();
                        
                        while (lector.Read())
                        {
                            usuario = new Usuario();
                            cliente = new Cliente();
                            
                            contrato.COD_CONTRATO = int.Parse(lector["COD_CONTRATO"].ToString());
                            contrato.NRO_CONTRATO = lector["NRO_CONTRATO"].ToString();
                            contrato.FECHA_CONTRATO = DateTime.Parse(lector["FECHA_CONTRATO"].ToString());
                            cliente = clienteDAO.ObtenerCliente(int.Parse(lector["COD_CLI"].ToString()));
                            contrato.cliente = cliente;
                            contrato.DIRECCION_OBRA = lector["DIRECCION_OBRA"].ToString();
                            contrato.TRANSPORTE = lector["TRANSPORTE"].ToString();
                            usuario = usuarioDAO.ObtenerUsuario(int.Parse(lector["idUsuario"].ToString()));
                            contrato.usuario = usuario;
                            contrato.TOTAL_DIAS = int.Parse(lector["TOTAL_DIAS"].ToString());
                            contrato.FECHA_ENTREGA = DateTime.Parse(lector["FECHA_ENTREGA"].ToString());
                            contrato.HORA_ENTREGA = TimeSpan.Parse(lector["HORA_ENTREGA"].ToString());
                            contrato.FECHA_DEVOLUCION = DateTime.Parse(lector["FECHA_DEVOLUCION"].ToString());
                            contrato.HORA_DEVOLUCION = TimeSpan.Parse(lector["HORA_DEVOLUCION"].ToString());
                            contrato.MONEDA = lector["MONEDA"].ToString();
                            contrato.GARANTIA = double.Parse(lector["GARANTIA"].ToString());
                            contrato.CHEQUE = lector["CHEQUE"].ToString();
                            contrato.DOCUMENTO = lector["DOCUMENTO"].ToString();
                            contrato.RECIBO = lector["RECIBO"].ToString();
                            contrato.IGV = double.Parse(lector["IGV"].ToString());
                            contrato.SUBTOTAL = double.Parse(lector["SUBTOTAL"].ToString());
                            contrato.TOTAL = double.Parse(lector["TOTAL"].ToString());
                            contrato.ESTADO = lector["ESTADO"].ToString();
                            
                        }
                    }
                }
                return contrato;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public string ObtenerNroContrato()
        {
            try
            {
                string nroContrato = "";
                string query = "SP_TBL_CONTRATO_TRAER_ULTIMO_NRO_CONTRATO";
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query))
                {

                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {

                            nroContrato = lector["NRO_CONTRATO"].ToString();



                        }
                    }
                }

                return nroContrato;
            }
            catch (Exception)
            {
                throw new Exception("Ocurio un error al recuperar el ultimo nro. Contrato");
            }

        }

        public Object[] AgregarConNroContrato(Contrato contrato)
        {
            string cadenaConexion = "server=10.0.2.15;DataBase=BDJORSAC;user=sa;password=BaseDeDatos2015";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlTransaction trx = cn.BeginTransaction();

            try
            {
                Object[] salidas = null;
                string query = "SP_TBL_CONTRATO_AGREGAR_CON_NRO_CONTRATO";

                SqlParameter id = new SqlParameter("@PS_COD", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;

                SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
                msj.Direction = ParameterDirection.Output;

                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NRO_CONTRATO",contrato.NRO_CONTRATO),
                 DBHelper.MakeParam("@P_FECHA_CONTRATO",contrato.FECHA_CONTRATO==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_CONTRATO),
                 DBHelper.MakeParam("@P_COD_CLI",contrato.cliente.COD_CLI==null?System.Data.SqlTypes.SqlInt32.Null:contrato.cliente.COD_CLI),
                 DBHelper.MakeParam("@P_DIRECCION_OBRA",contrato.DIRECCION_OBRA==null?System.Data.SqlTypes.SqlString.Null:contrato.DIRECCION_OBRA.ToUpper()),
                 DBHelper.MakeParam("@P_TRANSPORTE",contrato.TRANSPORTE==null?System.Data.SqlTypes.SqlString.Null:contrato.TRANSPORTE.ToUpper()),
                 DBHelper.MakeParam("@P_idUsuario",contrato.usuario.idUsuario==null?System.Data.SqlTypes.SqlInt32.Null:contrato.usuario.idUsuario),
                 DBHelper.MakeParam("@P_TOTAL_DIAS",contrato.TOTAL_DIAS==null?System.Data.SqlTypes.SqlInt32.Null:contrato.TOTAL_DIAS),
                 DBHelper.MakeParam("@P_FECHA_ENTREGA",contrato.FECHA_ENTREGA==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_ENTREGA),
                 DBHelper.MakeParam("@P_HORA_ENTREGA",contrato.HORA_ENTREGA),
                 DBHelper.MakeParam("@P_FECHA_DEVOLUCION",contrato.FECHA_DEVOLUCION==null?System.Data.SqlTypes.SqlDateTime.Null:contrato.FECHA_DEVOLUCION),
                 DBHelper.MakeParam("@P_HORA_DEVOLUCION",contrato.HORA_DEVOLUCION),
                 DBHelper.MakeParam("@P_MONEDA",contrato.MONEDA==null?System.Data.SqlTypes.SqlString.Null:contrato.MONEDA.ToUpper()),
                 DBHelper.MakeParam("@P_GARANTIA",contrato.GARANTIA==null?System.Data.SqlTypes.SqlDouble.Null:contrato.GARANTIA),
                 DBHelper.MakeParam("@P_CHEQUE",contrato.CHEQUE==null?System.Data.SqlTypes.SqlString.Null:contrato.CHEQUE),
                 DBHelper.MakeParam("@P_DOCUMENTO",contrato.DOCUMENTO==null?System.Data.SqlTypes.SqlString.Null:contrato.DOCUMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_RECIBO",contrato.RECIBO==null?System.Data.SqlTypes.SqlString.Null:contrato.RECIBO),
                 DBHelper.MakeParam("@P_IGV",contrato.IGV==null?System.Data.SqlTypes.SqlDouble.Null:contrato.IGV),
                 DBHelper.MakeParam("@P_SUBTOTAL",contrato.SUBTOTAL==null?System.Data.SqlTypes.SqlDouble.Null:contrato.SUBTOTAL),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),                             
                id,
                msj
             };



                salidas = DBHelper.ExecuteProcedure(query, dbParams, trx, cn);

                foreach (DetalleContrato detalle in contrato.DETALLECONTRATO)
                {
                    Contrato contra = new Contrato();
                    contra.COD_CONTRATO = Convert.ToInt32(salidas[0]);
                    detalle.CONTRATO = contra;

                    if (AgregarDetalle(detalle, trx, cn) == null)
                    {
                        throw new Exception("Ocurrio un error en la insercion del detalle del Contrato :" + detalle.SERVICIO.DESCRIPCION);
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
