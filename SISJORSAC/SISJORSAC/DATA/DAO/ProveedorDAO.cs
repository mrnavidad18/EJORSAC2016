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
    public class ProveedorDAO
    {

        public string Agregar(Proveedor proveedor)
        {
            string salidas;

            string query = "SP_TBL_PROVEEDOR_AGREGAR";


            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_NOMBRES",proveedor.NOMBRES==null?System.Data.SqlTypes.SqlString.Null:proveedor.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_AP_PATERNO",proveedor.AP_PATERNO==null?System.Data.SqlTypes.SqlString.Null:proveedor.AP_PATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_AP_MATERNO",proveedor.AP_MATERNO==null?System.Data.SqlTypes.SqlString.Null:proveedor.AP_MATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_DNI",proveedor.DNI==null?System.Data.SqlTypes.SqlString.Null:proveedor.DNI.Trim()),
                 DBHelper.MakeParam("@P_RUC",proveedor.RUC==null?System.Data.SqlTypes.SqlString.Null:proveedor.RUC.Trim()),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",proveedor.RAZON_SOCIAL==null?System.Data.SqlTypes.SqlString.Null:proveedor.RAZON_SOCIAL.ToUpper()),
                 DBHelper.MakeParam("@P_DIRECCION",proveedor.DIRECCION==null?System.Data.SqlTypes.SqlString.Null:proveedor.DIRECCION.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",proveedor.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:proveedor.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",proveedor.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:proveedor.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",proveedor.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:proveedor.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_TELF_FIJO_CASA",proveedor.TELF_FIJO_CASA==null?System.Data.SqlTypes.SqlString.Null:proveedor.TELF_FIJO_CASA.Trim()),
                 DBHelper.MakeParam("@P_TELF_FIJO_OFICINA",proveedor.TELF_FIJO_OFICINA==null?System.Data.SqlTypes.SqlString.Null:proveedor.TELF_FIJO_OFICINA.Trim()),
                 DBHelper.MakeParam("@P_CELULAR",proveedor.CELULAR==null?System.Data.SqlTypes.SqlString.Null:proveedor.CELULAR.Trim()),
                 DBHelper.MakeParam("@P_EMAIL",proveedor.EMAIL==null?System.Data.SqlTypes.SqlString.Null:proveedor.EMAIL.ToUpper()),
                 DBHelper.MakeParam("@P_OBSERVACIONES",proveedor.OBSERVACIONES==null?System.Data.SqlTypes.SqlString.Null:proveedor.OBSERVACIONES.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_PRO",proveedor.TIPO_PRO==null?System.Data.SqlTypes.SqlString.Null:proveedor.TIPO_PRO),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),
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


        public List<Proveedor> ListarProveedor(string tipoProveedor)
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();
            string query = "SP_TBL_PROVEEDOR_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@TIPO_PRO",tipoProveedor)
                 };

                using(SqlDataReader lector =DBHelper.ExecuteDataReaderProcedure(query,dbParams)){
                    if (lector != null && lector.HasRows)
                    {
                        Proveedor proveedor;
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();
                            if (lector["TIPO_PRO"].ToString().Equals("NATURAL"))
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.NOMBRES = lector["NOMBRES"].ToString();
                                proveedor.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                proveedor.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                proveedor.DNI = lector["DNI"].ToString();                               
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();
                                proveedor.TELF_FIJO_CASA = lector["TELF_FIJO_CASA"].ToString();
                                proveedor.CELULAR = lector["CELULAR"].ToString();
                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                proveedor.TIPO_PRO = lector["TIPO_PRO"].ToString();
                                proveedor.ESTADO = lector["ESTADO"].ToString();  
                                listaProveedor.Add(proveedor);
                            }
                            else
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.RUC = lector["RUC"].ToString();
                                proveedor.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();

                                proveedor.TELF_FIJO_OFICINA = lector["TELF_FIJO_OFICINA"].ToString();

                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                proveedor.TIPO_PRO = lector["TIPO_PRO"].ToString();
                                proveedor.ESTADO = lector["ESTADO"].ToString();  
                                listaProveedor.Add(proveedor);
                            }
                        }
                    }

                }
                return listaProveedor;
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        public Proveedor ObtenerProveedor(int codprov)
        {
            Proveedor proveedor = new Proveedor();
            string query = "SP_TBL_PROVEEDOR_OBTENERPROVEEDORXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_COD_PROV",codprov)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();

                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.NOMBRES = lector["NOMBRES"].ToString();
                                proveedor.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                proveedor.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                proveedor.DNI = lector["DNI"].ToString();
                                proveedor.RUC = lector["RUC"].ToString();
                                proveedor.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();
                                proveedor.TELF_FIJO_CASA = lector["TELF_FIJO_CASA"].ToString();
                                proveedor.TELF_FIJO_OFICINA = lector["TELF_FIJO_OFICINA"].ToString();
                                proveedor.CELULAR = lector["CELULAR"].ToString();
                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                proveedor.TIPO_PRO = lector["TIPO_PRO"].ToString();
                                proveedor.ESTADO = lector["ESTADO"].ToString();   
                            }
                        }
                    }
                return proveedor;
                }
            
            catch (Exception)
            {
                throw;
            }
        }


        public string Actualizar(Proveedor proveedor)
        {
            string salidas;

            string query = "SP_TBL_PROVEEDOR_ACTUALIZAR";


            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {

                 DBHelper.MakeParam("@P_NOMBRES",proveedor.NOMBRES==null?System.Data.SqlTypes.SqlString.Null:proveedor.NOMBRES.ToUpper()),
                 DBHelper.MakeParam("@P_AP_PATERNO",proveedor.AP_PATERNO==null?System.Data.SqlTypes.SqlString.Null:proveedor.AP_PATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_AP_MATERNO",proveedor.AP_MATERNO==null?System.Data.SqlTypes.SqlString.Null:proveedor.AP_MATERNO.ToUpper()),
                 DBHelper.MakeParam("@P_DNI",proveedor.DNI==null?System.Data.SqlTypes.SqlString.Null:proveedor.DNI.Trim()),
                 DBHelper.MakeParam("@P_RUC",proveedor.RUC==null?System.Data.SqlTypes.SqlString.Null:proveedor.RUC.Trim()),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",proveedor.RAZON_SOCIAL==null?System.Data.SqlTypes.SqlString.Null:proveedor.RAZON_SOCIAL.ToUpper()),
                 DBHelper.MakeParam("@P_DIRECCION",proveedor.DIRECCION==null?System.Data.SqlTypes.SqlString.Null:proveedor.DIRECCION.ToUpper()),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",proveedor.DEPARTAMENTO==null?System.Data.SqlTypes.SqlString.Null:proveedor.DEPARTAMENTO.ToUpper()),
                 DBHelper.MakeParam("@P_PROVINCIA",proveedor.PROVINCIA==null?System.Data.SqlTypes.SqlString.Null:proveedor.PROVINCIA.ToUpper()),
                 DBHelper.MakeParam("@P_DISTRITO",proveedor.DISTRITO==null?System.Data.SqlTypes.SqlString.Null:proveedor.DISTRITO.ToUpper()),
                 DBHelper.MakeParam("@P_TELF_FIJO_CASA",proveedor.TELF_FIJO_CASA==null?System.Data.SqlTypes.SqlString.Null:proveedor.TELF_FIJO_CASA.Trim()),
                 DBHelper.MakeParam("@P_TELF_FIJO_OFICINA",proveedor.TELF_FIJO_OFICINA==null?System.Data.SqlTypes.SqlString.Null:proveedor.TELF_FIJO_OFICINA.Trim()),
                 DBHelper.MakeParam("@P_CELULAR",proveedor.CELULAR==null?System.Data.SqlTypes.SqlString.Null:proveedor.CELULAR.Trim()),
                 DBHelper.MakeParam("@P_EMAIL",proveedor.EMAIL==null?System.Data.SqlTypes.SqlString.Null:proveedor.EMAIL.Trim()),
                 DBHelper.MakeParam("@P_OBSERVACIONES",proveedor.OBSERVACIONES==null?System.Data.SqlTypes.SqlString.Null:proveedor.OBSERVACIONES.ToUpper()),
                 DBHelper.MakeParam("@P_TIPO_PRO",proveedor.TIPO_PRO==null?System.Data.SqlTypes.SqlString.Null:proveedor.TIPO_PRO.Trim()),
                 DBHelper.MakeParam("@P_ESTADO","ACTIVO"),
                 DBHelper.MakeParam("@P_COD_PROV",proveedor.COD_PROV),               
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

        public List<Proveedor> buscarxDatos(string pBusqueda, string tipoProveedor)
        {
            List<Proveedor> listaProveedor = new List<Proveedor>();
            string query = "SP_TBL_PROVEEDOR_BUSCARXNOMBRESYAPELLIDOS";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{

                     DBHelper.MakeParam("@P_TIPOPROVEEDOR",tipoProveedor),
                     DBHelper.MakeParam("@P_BUSQUEDA",pBusqueda)
                 };

                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        Proveedor proveedor;
                        while (lector.Read())
                        {
                            proveedor = new Proveedor();
                            if (lector["TIPO_PRO"].ToString().Equals("NATURAL"))
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.NOMBRES = lector["NOMBRES"].ToString();
                                proveedor.AP_PATERNO = lector["AP_PATERNO"].ToString();
                                proveedor.AP_MATERNO = lector["AP_MATERNO"].ToString();
                                proveedor.DNI = lector["DNI"].ToString();
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();
                                proveedor.TELF_FIJO_CASA = lector["TELF_FIJO_CASA"].ToString();
                                proveedor.CELULAR = lector["CELULAR"].ToString();
                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                proveedor.TIPO_PRO = lector["TIPO_PRO"].ToString();
                                proveedor.ESTADO = lector["ESTADO"].ToString();
                                listaProveedor.Add(proveedor);
                            }
                            else
                            {
                                proveedor.COD_PROV = int.Parse(lector["COD_PROV"].ToString());
                                proveedor.RUC = lector["RUC"].ToString();
                                proveedor.RAZON_SOCIAL = lector["RAZON_SOCIAL"].ToString();
                                proveedor.DIRECCION = lector["DIRECCION"].ToString();
                                proveedor.DEPARTAMENTO = lector["DEPARTAMENTO"].ToString();
                                proveedor.PROVINCIA = lector["PROVINCIA"].ToString();
                                proveedor.DISTRITO = lector["DISTRITO"].ToString();

                                proveedor.TELF_FIJO_OFICINA = lector["TELF_FIJO_OFICINA"].ToString();

                                proveedor.EMAIL = lector["EMAIL"].ToString();
                                proveedor.OBSERVACIONES = lector["OBSERVACIONES"].ToString();
                                proveedor.TIPO_PRO = lector["TIPO_PRO"].ToString();
                                proveedor.ESTADO = lector["ESTADO"].ToString();
                                listaProveedor.Add(proveedor);
                            }
                        }
                    }

                }
                return listaProveedor;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
