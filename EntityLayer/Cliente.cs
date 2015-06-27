using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Cliente
    {
        public int codCliente { get; set; }

        public string razonSocial { get; set; }

        public string numeroRuc { get; set; }

        public int codPersona{ get; set; }
        public int codTipoCliente { get; set; }
    }
}
