using Modelos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class Producto
    {
        string Conexion = ConfigurationManager.ConnectionStrings["VentaProduc"].ConnectionString;
        public bool CrearProducto(ref InfProducto producto)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PRODUCTO", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdProducto", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Producto", producto.Producto);
                    sqlCommand.Parameters.AddWithValue("@ValorUnitario", producto.ValorUnitario);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CREPRO");

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

        public bool ModificarProducto(ref InfProducto producto)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PRODUCTO", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                    sqlCommand.Parameters.AddWithValue("@Producto", producto.Producto);
                    sqlCommand.Parameters.AddWithValue("@ValorUnitario", producto.ValorUnitario);
                    sqlCommand.Parameters.AddWithValue("@OPC", "MODPRO");

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

        public bool ConsultarProducto(ref List<InfProducto> producto)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PRODUCTO", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdProducto", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@Producto", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@ValorUnitario", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CONPRO");

                    var result = sqlCommand.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dsProducto = new DataSet();
                        da.Fill(dsProducto);
                        conection.Dispose();
                        if (dsProducto.Tables[0].Rows.Count > 0)
                        {
                            MapearDatasetProducto(dsProducto, ref producto);
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

        public bool ConsultarProductoId(int IdProducto, ref List<InfProducto> producto)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_PRODUCTO", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdProducto", IdProducto);
                    sqlCommand.Parameters.AddWithValue("@Producto", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@ValorUnitario", DBNull.Value);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CONPROID");

                    var result = sqlCommand.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dsProducto = new DataSet();
                        da.Fill(dsProducto);
                        conection.Dispose();
                        if (dsProducto.Tables[0].Rows.Count > 0)
                        {
                            MapearDatasetProducto(dsProducto, ref producto);
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

        private void MapearDatasetProducto(DataSet dsproducto, ref List<InfProducto> producto)
        {
            try
            {
                if (dsproducto != null && dsproducto.Tables.Count > 0 && dsproducto.Tables[0].Rows.Count > 0)
                {
                    if (producto == null)
                    {
                        producto = new List<InfProducto>();
                    }
                    foreach (DataRow dr in dsproducto.Tables[0].Rows)
                    {
                        InfProducto Pro = new InfProducto();
                        Pro.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        Pro.Producto = dr["Producto"].ToString();
                        Pro.ValorUnitario = Convert.ToDecimal(dr["ValorUnitario"].ToString());
                        producto.Add(Pro);
                    }
                }
                else
                {
                    producto = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
