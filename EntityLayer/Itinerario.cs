using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class Itinerario
    {
        public int codItinerario { get; set; }

        public string origen { get; set; }

        public string destino { get; set; }

        public DateTime fechaServicio { get; set; }

        public string horaSalida { get; set; }

        public string tipoAccion { get; set; }

        public string cantidad { get; set; }

      //  public Itinerario itinerario { get; set; }
        public List<Itinerario> itinerarios { get; set; }
    }
}
