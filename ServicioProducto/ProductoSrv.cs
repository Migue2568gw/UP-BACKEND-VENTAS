using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;

namespace ServicioProducto
{
    public class ProductoSrv
    {
        AccesoDatos.Producto producto;
        public InfProducto CrearProducto(InfProducto infoPersona)
        {
            producto = new AccesoDatos.Producto();
            var response = producto.CrearProducto(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }
        public List<InfProducto> ConsultarProducto()
        {
            List<InfProducto> infoPersona = new List<InfProducto>();
            producto = new AccesoDatos.Producto();
            var response = producto.ConsultarProducto(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }

        public List<InfProducto> ConsultarProductoId(int IdPersona)
        {
            List<InfProducto> infoPersona = new List<InfProducto>();
            producto = new AccesoDatos.Producto();
            var response = producto.ConsultarProductoId(IdPersona, ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }

        public InfProducto ModificarProducto(InfProducto infoPersona)
        {
            producto = new AccesoDatos.Producto();
            var response = producto.ModificarProducto(ref infoPersona);
            if (response)
            {
                return infoPersona;
            }
            else
            {
                infoPersona = null;
                return infoPersona;
            }
        }
    }
}
