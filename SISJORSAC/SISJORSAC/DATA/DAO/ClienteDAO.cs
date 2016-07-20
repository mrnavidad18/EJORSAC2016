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
                 DBHelper.MakeParam("@P_NOMBRES",cliente.NOMBRES),
                 DBHelper.MakeParam("@P_AP_PATERNO",cliente.AP_PATERNO),
                 DBHelper.MakeParam("@P_AP_MATERNO",cliente.AP_MATERNO),
                 DBHelper.MakeParam("@P_DNI",cliente.DNI),
                 DBHelper.MakeParam("@P_RUC",cliente.RUC),
                 DBHelper.MakeParam("@P_RAZON_SOCIAL",cliente.RAZON_SOCIAL),
                 DBHelper.MakeParam("@P_DIRECCION",cliente.DIRECCION),
                 DBHelper.MakeParam("@P_DEPARTAMENTO",cliente.DEPARTAMENTO),
                 DBHelper.MakeParam("@P_PROVINCIA",cliente.PROVINCIA),
                 DBHelper.MakeParam("@P_DISTRITO",cliente.DISTRITO),
                 DBHelper.MakeParam("@P_TEL_FIJO_CASA",cliente.TEL_FIJO_CASA),
                 DBHelper.MakeParam("@P_TEL_FIJO_OFICINA",cliente.TEL_FIJO_OFICINA),
                 DBHelper.MakeParam("@P_CELULAR",cliente.CELULAR),
                 DBHelper.MakeParam("@P_EMAIL",cliente.EMAIL),
                 DBHelper.MakeParam("@P_OBSERVACIONES",cliente.OBSERVACIONES),
                 DBHelper.MakeParam("@P_TIPO_CLIE",cliente.TIPO_CLIE),
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
            List<Cliente> listaProveedor = new List<Cliente>();
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
                                listaProveedor.Add(cliente);
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
                                listaProveedor.Add(cliente);
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
