using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using EntityLayer;

namespace DataLayer
{
    public class MD_TipoServicio
    {


        Conexion oaccesodedatos = new Conexion();

        public List<TipoServicio> obtenerTipoServicio()
        {
            List<TipoServicio> lsta = new List<TipoServicio>();

            SqlCommand _comando = oaccesodedatos.CrearComando(CommandType.StoredProcedure, "listartiposervicio");
            SqlDataReader dr = oaccesodedatos.ExecuteReaderSelect(_comando);

            while (dr.Read())
            {
                TipoServicio tipoServicio = new TipoServicio();
                tipoServicio.codigo = (int)dr["codTipoServicio"];
                tipoServicio.descripcion = dr["nombre"].ToString();                
                lsta.Add(tipoServicio);
            }

            return lsta;
        }

    }
}
