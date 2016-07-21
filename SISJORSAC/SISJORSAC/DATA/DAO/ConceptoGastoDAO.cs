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
    public class ConceptoGastoDAO
    {
        public string Agregar(ConceptoGasto conceptoGasto)
        {
            string salidas;

            string query = "SP_TBL_CONCEP_GASTO_AGREGAR";
            SqlParameter msj = new SqlParameter("@PS_MSJ", SqlDbType.VarChar, 100);
            msj.Direction = ParameterDirection.Output;
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
             {
                 DBHelper.MakeParam("@P_DESCRIPCION",conceptoGasto.DESCRIPCION),
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

        public ConceptoGasto ObtenerConceptoGasto(int cod_conceptoGasto)
        {
            ConceptoGasto conceptoGasto = new ConceptoGasto();
            string query = "SP_TBL_CONCEP_GASTO_OBTENERCONCEPTOXCODIGO";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@P_COD_CON_GAS",cod_conceptoGasto)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {
                        while (lector.Read())
                        {
                            conceptoGasto.COD_CON_GAS = int.Parse(lector["COD_CON_GAS"].ToString());
                            conceptoGasto.DESCRIPCION = lector["DESCRIPCION"].ToString();
                            conceptoGasto.ESTADO = lector["ESTADO"].ToString();
                        }
                    }
                }
                return conceptoGasto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<ConceptoGasto> listarConceptoGasto(string estado)
        {
            List<ConceptoGasto> listaConceptoGasto = new List<ConceptoGasto>();
            ConceptoGasto conceptoGasto;
            string query = "SP_TBL_CONCEP_GASTO_LISTAR";
            try
            {
                SqlParameter[] dbParams = new SqlParameter[]{
                     DBHelper.MakeParam("@ESTADO",estado)
                 };
                using (SqlDataReader lector = DBHelper.ExecuteDataReaderProcedure(query, dbParams))
                {
                    if (lector != null && lector.HasRows)
                    {

                        while (lector.Read())
                        {
                            conceptoGasto = new ConceptoGasto();
                            conceptoGasto.COD_CON_GAS = int.Parse(lector["COD_CON_GAS"].ToString());
                            conceptoGasto.DESCRIPCION = lector["DESCRIPCION"].ToString();
                            conceptoGasto.ESTADO = lector["ESTADO"].ToString();
                            listaConceptoGasto.Add(conceptoGasto);
                        }
                    }
                }
                return listaConceptoGasto;
            }
            catch (Exception)
            {
                throw;
            }
        
        }

    }
}