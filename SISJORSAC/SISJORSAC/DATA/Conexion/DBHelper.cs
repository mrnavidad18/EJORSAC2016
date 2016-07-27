using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SISJORSAC.DATA.Conexion
{
    public class DBHelper
    {
        private static string cadenaConexion = "server=192.168.0.27;DataBase=BDJORSAC;user=sa;password=Developer2016";
        public static SqlParameter MakeParam(string paramName,object objValue)
        {
            SqlParameter param;
            param = new SqlParameter(paramName, objValue);
            param.Value = objValue;
            return param;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[] dbParams)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;

                if (dbParams != null)
                {
                    foreach (SqlParameter dbParam in dbParams)
                    {
                        cmd.Parameters.Add(dbParam);
                    }
                }
                return cmd.ExecuteNonQuery();

            }     
        }


        public static string ExecuteProcedure(string query, SqlParameter[] dbParams)
        {
            
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (dbParams != null)
                {
                    foreach (SqlParameter dbParam in dbParams)
                    {
                        cmd.Parameters.Add(dbParam);
                    }
                }
                cmd.ExecuteNonQuery();

                string mensaje = Convert.ToString(cmd.Parameters["@PS_MSJ"].Value);

                
                return mensaje;

            }
        }


        public static SqlDataReader ExecuteDataReaderProcedure(string query)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static SqlDataReader ExecuteDataReaderProcedure(string query, SqlParameter[] parametros)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (parametros != null)
            {
                foreach (SqlParameter parametro in parametros)
                {
                    cmd.Parameters.Add(parametro);
                }
            }
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            return dr;
        }
        public static SqlDataReader ExecuteDataReader(string query)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static SqlDataReader ExecuteDataReader(string query,SqlParameter[] parametros)
        {
            SqlDataReader dr;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.CommandType = CommandType.Text;
            if (parametros != null)
            {
                foreach (SqlParameter parametro in parametros)
                {
                    cmd.Parameters.Add(parametro);
                }
            }
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;
        }

        public static object ExecuteScalar(string query)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteScalar();

            }
        }

        public static object ExecuteScalarProcedure(string query)
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteScalar();
            }
        }
    

        //// Transacciones

        public static Object[] ExecuteProcedure(string query, SqlParameter[] dbParams,SqlTransaction trx,SqlConnection cn)
        {
            Object[] salidas = new Object[2];
            
                SqlCommand cmd = new SqlCommand(query, cn,trx);
                 cmd.CommandTimeout=5;
                cmd.CommandType = CommandType.StoredProcedure;

                if (dbParams != null)
                {
                    foreach (SqlParameter dbParam in dbParams)
                    {
                        cmd.Parameters.Add(dbParam);
                    }
                }

                cmd.ExecuteNonQuery();

                int id = Convert.ToInt32(cmd.Parameters["@PS_COD"].Value);
                string mensaje = Convert.ToString(cmd.Parameters["@PS_MSJ"].Value);

                salidas[0] = id;
                salidas[1] = mensaje;
               
                return salidas;

            }

        public static string ExecuteProcedureDetalles(string query, SqlParameter[] dbParams, SqlTransaction trx, SqlConnection cn)
        {
          

            SqlCommand cmd = new SqlCommand(query, cn, trx);
            cmd.CommandType = CommandType.StoredProcedure;

            if (dbParams != null)
            {
                foreach (SqlParameter dbParam in dbParams)
                {
                    cmd.Parameters.Add(dbParam);
                }
            }

            cmd.ExecuteNonQuery();

           
            string mensaje = Convert.ToString(cmd.Parameters["@PS_MSJ"].Value);



            return mensaje;

        }
        

    }
}
