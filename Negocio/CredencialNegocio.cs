using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CredencialNegocio
    {
        public int InsertarTablaCredencial(Credencial nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC insertCredenciales @Nombre_Usuario,@Contrasenia");
                datos.setearParametro("@Nombre_Usuario", nuevo.NombreUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Password);
                return datos.ejecutarAccionScalar();
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

        public int BuscarIdCredencial(Credencial credencial)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id from Credenciales where Nombre_Usuario=@User and Contrasenia = @Pass");
                datos.setearParametro("@User", credencial.NombreUsuario);
                datos.setearParametro("@Pass", credencial.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return int.Parse(datos.Lector["Id"].ToString());
                }
                return 0;
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
