using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace Negocio
{
    public class PermisoNegocio
    {
        public List<Permiso> ListarPermisos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Permiso> listaPermisos = new List<Permiso>();
            try
            {
                datos.setearConsulta("Select Id,Nombre FROM Permisos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Permiso aux = new Permiso();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Nombre"];
                    listaPermisos.Add(aux);
                }
                return listaPermisos;
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
