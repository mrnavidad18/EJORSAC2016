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
    public class ClienteDAO
    {
        public string Agregar(Cliente cliente)
        {
            string salidas;

            string query = "SP_TBL_CLIENTE_AGREGAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NOMBRES",cliente.NOMBRES==null?System.Data.SqlTypes.SqlString.Null:cliente.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_AP_PATERNO",cliente.AP_PATERNO==null?System.Data.SqlTypes.SqlString.Null:cliente.AP_PATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_AP_MATERNO",cliente.AP_MATERNO==null?System.Data.SqlTypes.SqlString.Null:cliente.AP_MATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_DNI",cliente.DNI==null?System.Data.SqlTypes.SqlString.Null:cliente.DNI),
                 DBHelper.MakeParam("@P_RUC",cliente.RUC==null?System.Data.SqlTypes.SqlString.Null:cliente.RUC),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",cliente.RAZON_SOCIAL==null?System.Data.SqlTypes.SqlString.Null:cliente.RAZON_SOCIAL.ToUpper()),
                 DBHelper.MakeParam("@P_DIRECCION",cliente.DIRECCION==null?System.Data.SqlTypes.SqlString.Null:cliente.DIRECCION.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",cliente.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:cliente.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",cliente.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:cliente.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",cliente.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:cliente.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_TEL_FIJO_CASA",cliente.TEL_FIJO_CASA==null?System.Data.SqlTypes.SqlString.Null:cliente.TEL_FIJO_CASA.Trim()),
                 DBHelper.MakeParam("@P_TEL_FIJO_OFICINA",cliente.TEL_FIJO_OFICINA==null?System.Data.SqlTypes.SqlString.Null:cliente.TEL_FIJO_OFICINA.Trim()),
                 DBHelper.MakeParam("@P_CELULAR",cliente.CELULAR==null?System.Data.SqlTypes.SqlString.Null:cliente.CELULAR.Trim()),
                 DBHelper.MakeParam("@P_EMAIL",cliente.EMAIL==null?System.Data.SqlTypes.SqlString.Null:cliente.EMAIL.ToUpper()),
                 DBHelper.MakeParam("@P_OBSERVACIONES",cliente.OBSERVACIONES==null?System.Data.SqlTypes.SqlString.Null:cliente.OBSERVACIONES.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_CLIE",cliente.TIPO_CLIE==null?System.Data.SqlTypes.SqlString.Null:cliente.TIPO_CLIE),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                 msj
             };

                salidas = DBHelper.ExecuteProcedure(query, dbParams);
                return salidas;
            }
            catch (Exception)
            {
                throw;
            }

        }
        public List<Cliente> ListarCliente(string tipoCliente)
        {
            List<Cliente> listaClientes = new List<Cliente>();
            string query = "SP_TBL_CLIENTE_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@TIPO_CLIE",tipoCliente)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        while (lector.Read())
                        {
                            cliente = new Cliente();
                            if (tipoCliente.Equals("NATURAL"))
                            {
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.NOMBRES = lector["NOMBRES"].ToString();
                                cliente.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                cliente.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                cliente.DNI = lector["DNI"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();
                                cliente.TEL_FIJO_CASA = lector["TEL_FIJO_CASA"].ToString();
                                cliente.CELULAR = lector["CELULAR"].ToString();
                                cliente.EMAIL = lector["EMAIL"].ToString();
                                cliente.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaClientes.Add(cliente);
                            }
                            else if (tipoCliente.Equals("JURIDICA"))
                            {
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.RUC = lector["RUC"].ToString();
                                cliente.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();

                                cliente.TEL_FIJO_OFICINA = lector["TEL_FIJO_OFICINA"].ToString();

                                cliente.EMAIL = lector["EMAIL"].ToString();
                                cliente.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaClientes.Add(cliente);
                            }
                            else
                            {
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.TEL_FIJO_OFICINA = lector["TEL_FIJO_OFICINA"].ToString();
                                cliente.RUC = lector["RUC"].ToString();
                                cliente.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                cliente.NOMBRES = lector["NOMBRES"].ToString();
                                cliente.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                cliente.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                cliente.DNI = lector["DNI"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();
                                cliente.TEL_FIJO_CASA = lector["TEL_FIJO_CASA"].ToString();
                                cliente.CELULAR = lector["CELULAR"].ToString();
                                cliente.EMAIL = lector["EMAIL"].ToString();
                                listaClientes.Add(cliente);
                            }
                        }
                    }

                }
                return listaClientes;
            }
            catch (Exception)
            {

                throw;
            }

        }
        public Cliente ObtenerCliente(int codCli)
        {
            Cliente cliente = new Cliente();
            string query = "SP_TBL_CLIENTE_OBTENERCLIENTEXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_COD_CLI",codCli)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {                        
                        while (lector.Read())
                        {                                                                                  
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.NOMBRES = lector["NOMBRES"].ToString();
                                cliente.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                cliente.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                cliente.DNI = lector["DNI"].ToString();
                                cliente.RUC = lector["RUC"].ToString();
                                cliente.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();
                                cliente.TEL_FIJO_CASA = lector["TEL_FIJO_CASA"].ToString();
                                cliente.TEL_FIJO_OFICINA = lector["TEL_FIJO_OFICINA"].ToString();
                                cliente.CELULAR = lector["CELULAR"].ToString();
                                cliente.EMAIL = lector["EMAIL"].ToString();
                                cliente.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                cliente.TIPO_CLIE = lector["TIPO_CLIE"].ToString();
                        }
                    }                    
                }
                return cliente;
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string Actualizar(Cliente cliente)
        {
            string salidas;

            string query = "SP_TBL_CLIENTE_ACTUALIZAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {                                                  
                 DBHelper.MakeParam("@P_COD_CLI",cliente.COD_CLI),
                 DBHelper.MakeParam("@P_NOMBRES",cliente.NOMBRES==null?System.Data.SqlTypes.SqlString.Null:cliente.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_AP_PATERNO",cliente.AP_PATERNO==null?System.Data.SqlTypes.SqlString.Null:cliente.AP_PATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_AP_MATERNO",cliente.AP_MATERNO==null?System.Data.SqlTypes.SqlString.Null:cliente.AP_MATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_DNI",cliente.DNI==null?System.Data.SqlTypes.SqlString.Null:cliente.DNI.Trim()),
                 DBHelper.MakeParam("@P_RUC",cliente.RUC==null?System.Data.SqlTypes.SqlString.Null:cliente.RUC.Trim()),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",cliente.RAZON_SOCIAL==null?System.Data.SqlTypes.SqlString.Null:cliente.RAZON_SOCIAL.ToUpper()),
                 DBHelper.MakeParam("@P_DIRECCION",cliente.DIRECCION==null?System.Data.SqlTypes.SqlString.Null:cliente.DIRECCION.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",cliente.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:cliente.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",cliente.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:cliente.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",cliente.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:cliente.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_TEL_FIJO_CASA",cliente.TEL_FIJO_CASA==null?System.Data.SqlTypes.SqlString.Null:cliente.TEL_FIJO_CASA.Trim()),
                 DBHelper.MakeParam("@P_TEL_FIJO_OFICINA",cliente.TEL_FIJO_OFICINA==null?System.Data.SqlTypes.SqlString.Null:cliente.TEL_FIJO_OFICINA.Trim()),
                 DBHelper.MakeParam("@P_CELULAR",cliente.CELULAR==null?System.Data.SqlTypes.SqlString.Null:cliente.CELULAR.Trim()),
                 DBHelper.MakeParam("@P_EMAIL",cliente.EMAIL==null?System.Data.SqlTypes.SqlString.Null:cliente.EMAIL.ToUpper()),
                 DBHelper.MakeParam("@P_OBSERVACIONES",cliente.OBSERVACIONES==null?System.Data.SqlTypes.SqlString.Null:cliente.OBSERVACIONES.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_CLIE",cliente.TIPO_CLIE==null?System.Data.SqlTypes.SqlString.Null:cliente.TIPO_CLIE),
                 DBHelper.MakeParam("@P_ESTADO","DISPONIBLE"),
                 msj
             };
                salidas = DBHelper.ExecuteProcedure(query, dbParams);
                return salidas;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Cliente> buscarxNombresyApellidos(string pBuqueda,string tipoCliente)
        {
            List<Cliente> listaCliente = new List<Cliente>();
            string query = "SP_TBL_CLIENTE_BUSCARXNOMBRESYAPELLIDOS";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_BUSQUEDA",pBuqueda),
                     DBHelper.MakeParam("@P_TIPOCLIENTE",tipoCliente)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Cliente cliente;
                        while (lector.Read())
                        {
                            cliente = new Cliente();
                            if (lector["TIPO_CLIE"].ToString().Equals("NATURAL"))
                            {
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.NOMBRES = lector["NOMBRES"].ToString();
                                cliente.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                cliente.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                cliente.DNI = lector["DNI"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();
                                cliente.TEL_FIJO_CASA = lector["TEL_FIJO_CASA"].ToString();
                                cliente.CELULAR = lector["CELULAR"].ToString();
                                cliente.EMAIL = lector["EMAIL"].ToString();
                                cliente.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaCliente.Add(cliente);
                            }
                            else
                            {
                                cliente.COD_CLI = int.Parse(lector["COD_CLI"].ToString());
                                cliente.RUC = lector["RUC"].ToString();
                                cliente.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                cliente.DIRECCION = lector["DIRECCION"].ToString();
                                cliente.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                cliente.PROVINCIA = lector["PROVINCIA"].ToString();
                                cliente.DISTRITO = lector["DISTRITO"].ToString();

                                cliente.TEL_FIJO_OFICINA = lector["TEL_FIJO_OFICINA"].ToString();

                                cliente.EMAIL = lector["EMAIL"].ToString();
                                cliente.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                listaCliente.Add(cliente);
                            }
                        }
                    }

                }
                return listaCliente;
            }
            catch (Exception)
            {

                throw;
            }

        }


    }
}
