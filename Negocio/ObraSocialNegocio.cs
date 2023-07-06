using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class ObraSocialNegocio
    {
        public List<ObraSocial> ListaObraSociales()
        {
            List<ObraSocial> obrasSociales = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_OBRASOCIAL");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial aux = new ObraSocial();

                    aux.IdObraSocial = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Estado = (int)datos.Lector["Estado"];
                    aux.DatosContacto = new DatosContacto();
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];

                    obrasSociales.Add(aux);
                }
                return obrasSociales;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }   
        }

    }
}
