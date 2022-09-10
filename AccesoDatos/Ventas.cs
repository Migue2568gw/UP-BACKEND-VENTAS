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
    public class Ventas
    {
        string Conexion = ConfigurationManager.ConnectionStrings["VentaProduc"].ConnectionString;
        public bool CrearVenta(ref InfVenta Venta)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_VENTAS", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdProducto", Venta.IdProducto);
                    sqlCommand.Parameters.AddWithValue("@IdPersona", Venta.IdPersona);
                    sqlCommand.Parameters.AddWithValue("@CantidadProducto", Venta.CantidadProducto);
                    sqlCommand.Parameters.AddWithValue("@OPC", "ADIVEN");

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
        public bool ConsultarVentasId(int IdPersona, ref List<InfVentaList> Venta)
        {
            try
            {
                using (SqlConnection conection = new SqlConnection(Conexion))
                {
                    conection.Open();

                    SqlCommand sqlCommand = new SqlCommand("PA_LOGICA_VENTAS", conection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    List<SqlParameter> ListaParametros = new List<SqlParameter>();
                    sqlCommand.Parameters.AddWithValue("@IdPersona", IdPersona);
                    sqlCommand.Parameters.AddWithValue("@OPC", "CONVEN");

                    var result = sqlCommand.ExecuteNonQuery();

                    using (SqlDataAdapter da = new SqlDataAdapter(sqlCommand))
                    {
                        DataSet dsVentas = new DataSet();
                        da.Fill(dsVentas);
                        conection.Dispose();
                        if (dsVentas.Tables[0].Rows.Count > 0)
                        {
                            MapearDatasetVenta(dsVentas, ref Venta);
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

        private void MapearDatasetVenta(DataSet dsVenta, ref List<InfVentaList> Venta)
        {
            try
            {
                if (dsVenta != null && dsVenta.Tables.Count > 0 && dsVenta.Tables[0].Rows.Count > 0)
                {
                    if (Venta == null)
                    {
                        Venta = new List<InfVentaList>();
                    }
                    foreach (DataRow dr in dsVenta.Tables[0].Rows)
                    {
                        InfVentaList ven = new InfVentaList();
                        ven.IdVentas = Convert.ToInt32(dr["IdVentas"]);
                        ven.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        ven.Producto = dr["Producto"].ToString();
                        ven.CantidadProducto = Convert.ToInt32(dr["CantidadProducto"]);
                        ven.ValorUnitario = Convert.ToDecimal(dr["ValorUnitario"]);
                        ven.ValorTotal = Convert.ToDecimal(dr["ValorTotal"]);
                        Venta.Add(ven);
                    }
                }
                else
                {
                    Venta = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
