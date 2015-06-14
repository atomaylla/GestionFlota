using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{

    public class Solicitud
    {
        public int nroSolicitud { get; set; }
      
        public DateTime fechaServicio { get; set; }

        public int codCliente { get; set; }

        public string razonCliente { get; set; }

        public int codTipoServicio { get; set; }

        public string nomTipoServicio { get; set; }
      //  public string nombreservicio { get; set; }

        public string estado { get; set; }

      

        //  public Itinerario itinerario { get; set; }
        public List<Solicitud> solicitudes { get; set; }
    }
}
