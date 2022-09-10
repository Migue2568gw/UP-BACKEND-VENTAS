using Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;

namespace AccesoDatos
{
    public class Persona
    {
        string Conexion = ConfigurationManager.ConnectionStrings["VentaProduc"].ConnectionString;
        public bool CrearPersona(ref InfPersona persona)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PERSONA", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdPersona", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    sqlCommand.Parameters.AddWithValue("@Cedula", persona.Cedula);
                    sqlCommand.Parameters.AddWithValue("@Telefono", persona.Telefono);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CREPER");

                    var result = sqlCommand.ExecuteNonQuery();
                    conection.Dispose();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ModificarPersona(ref InfPersona persona)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PERSONA", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdPersona", persona.IdPersona);
                    sqlCommand.Parameters.AddWithValue("@Nombre", persona.Nombre);
                    sqlCommand.Parameters.AddWithValue("@Apellido", persona.Apellido);
                    sqlCommand.Parameters.AddWithValue("@Cedula", persona.Cedula);
                    sqlCommand.Parameters.AddWithValue("@Telefono", persona.Telefono);
                    sqlCommand.Parameters.AddWithValue("@OPC", "MODPER");

                    var result = sqlCommand.ExecuteNonQuery();
                    conection.Dispose();
                    if (result == 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ConsultarPersona(ref List<InfPersona> persona)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PERSONA", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdPersona", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Apellido", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Cedula", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CONPER");

                    var result = sqlCommand.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dsPersona = new DataSet();
                        da.Fill(dsPersona);
                        conection.Dispose();
                        if (dsPersona.Tables[0].Rows.Count > 0)
                        {
                            MapearDatasetPersona(dsPersona, ref persona);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ConsultarPersona(int IdPesona,ref List<InfPersona> persona)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PERSONA", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdPersona", IdPesona);
                    sqlCommand.Parameters.AddWithValue("@Nombre", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Apellido", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Cedula", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Telefono", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CONPERID");

                    var result = sqlCommand.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dsPersona = new DataSet();
                        da.Fill(dsPersona);
                        conection.Dispose();
                        if (dsPersona.Tables[0].Rows.Count > 0)
                        {
                            MapearDatasetPersona(dsPersona, ref persona);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void MapearDatasetPersona(DataSet dsPersona, ref List<InfPersona> persona)
        {
            try
            {
                if (dsPersona != null && dsPersona.Tables.Count > 0 && dsPersona.Tables[0].Rows.Count > 0)
                {
                    if (persona == null)
                    {
                        persona = new List<InfPersona>();
                    }
                    foreach (DataRow dr in dsPersona.Tables[0].Rows)
                    {
                        InfPersona per = new InfPersona();
                        per.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        per.Nombre = dr["Nombre"].ToString();
                        per.Apellido = dr["Apellido"].ToString();
                        per.Cedula = Convert.ToDecimal(dr["Cedula"].ToString());
                        per.Telefono = Convert.ToDecimal(dr["Telefono"].ToString());
                        persona.Add(per);
                    }
                }
                else
                {
                    persona = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
