using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Planificacion
    {
        public int nroPlaProgramacion{ get; set; }

        public int nroSolicitud { get; set; }

        public DateTime fechaServicio { get; set; }

        public string estado { get; set; }

        

        //  public Itinerario itinerario { get; set; }
      //  public List<Itinerar> itinerarios { get; set; }
      ////  public List<conductor> conductores { get; set; }
    }
}
