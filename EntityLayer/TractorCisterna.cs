using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
  public class TractorCisterna
    {
        public int codConfiguracion { get; set; }

        public int nroPlaProgramacion { get; set; }

        public int codCisterna{ get; set; }
        public string nroPlacaCisterna { get; set; }

        public int codTractor { get; set; }
        public string nroPlacaTractor { get; set; }

        public string configuracionVehicular { get; set; }

        public int valorConfiguracion { get; set; }

        public DateTime fecaIniConfiguracion { get; set; }
        public DateTime fecaFinConfiguracion { get; set; }
        public string estado { get; set; }

        //  public Itinerario itinerario { get; set; }
        public List<TractorCisterna> tractorcisternas { get; set; }
    }
}
