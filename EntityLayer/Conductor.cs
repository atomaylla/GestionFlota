using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class Conductor
    {
        public int codConductor { get; set; }
        public string nomConductor { get; set; }
        public int codPersona { get; set; }
        public int codTipoConductor{ get; set; }
        public string licencia { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string telefonoParticular { get; set; }
        public string telefonoEmpresa { get; set; }
       public List<Conductor> conductores { get; set; }
    }
}
