using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InfVentaList
    {
        public int IdVentas { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int CantidadProducto { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
