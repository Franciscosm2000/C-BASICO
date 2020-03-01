using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_de_ProgramacionII_en_wpf.Clases
{
    class Ventas
    {
        private String cliente;
        private String vendedor;
        private String vehiculo;
        private String cantidad;
        private String total;

        public string Cliente { get => cliente; set => cliente = value; }
        public string Vendedor { get => vendedor; set => vendedor = value; }
        public string Vehiculo { get => vehiculo; set => vehiculo = value; }
        public string Cantidad { get => cantidad; set => cantidad = value; }
        public string Total { get => total; set => total = value; }
    }
}
