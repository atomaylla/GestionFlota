using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataLayer;
using EntityLayer;

namespace BusinessLayer
{
    public class NTipoServicio
    {
        MD_TipoServicio md_tipoServicio = new MD_TipoServicio();

        public List<TipoServicio> obtenerTipoServicio()
        {
            return md_tipoServicio.obtenerTipoServicio();
        }
    }
}
