﻿using System;
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
        private static string cadenaConexion = "server=192.168.0.29;DataBase=BDJORSAC;user=sa;password=2015159";
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


        public static int ExecuteProcedure(string query, SqlParameter[] dbParams)
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
                return cmd.ExecuteNonQuery();
                

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
    

    }
}
