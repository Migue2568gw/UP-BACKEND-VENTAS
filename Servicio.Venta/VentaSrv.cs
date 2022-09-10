using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Venta
{
    public class VentaSrv
    {
        AccesoDatos.Ventas ventas;
        public InfVenta CrearVenta(InfVenta infVenta)
        {
            ventas = new AccesoDatos.Ventas();
            var response = ventas.CrearVenta(ref infVenta);
            if (response)
            {
                return infVenta;
            }
            else
            {
                infVenta = null;
                return infVenta;
            }
        }

        public List<InfVentaList> ConsultarVentaId(int IdPersona)
        {
            List<InfVentaList> infoVenta = new List<InfVentaList>();
            ventas = new AccesoDatos.Ventas();
            var response = ventas.ConsultarVentasId(IdPersona, ref infoVenta);
            if (response)
            {
                return infoVenta;
            }
            else
            {
                infoVenta = null;
                return infoVenta;
            }
        }
    }
}
