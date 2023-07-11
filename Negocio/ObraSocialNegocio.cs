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
        public List<ObraSocial> ListaObrasSociales()
        {
            List<ObraSocial> obrasSociales = new List<ObraSocial>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_OBRAS_SOCIALES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ObraSocial aux = new ObraSocial();

                    aux.IdObraSocial = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

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

        public List<ObraSocial> ListarObraSocial()
        {
            AccesoDatos datos = new AccesoDatos();
            List<ObraSocial> listaObraSocial = new List<ObraSocial>();
            try
            {
                datos.setearConsulta("Select Id,Nombre,Id_Estado FROM Obras_Sociales");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ObraSocial aux = new ObraSocial();
                    aux.IdObraSocial = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    listaObraSocial.Add(aux);
                }
                return listaObraSocial;
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
