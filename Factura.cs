using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSTANCIATAREA
{
    class Factura
    {
      //  public int Id { get; set; }
        public string Observacion { get; set; }
        
        public int Idcliente { get; set; }

        
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
    }
}
