using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PersonaNegocio
    {
        public int InsertarTablaPersona(Persona nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC insertPersona @Nombre,@Apellido,@Dni,@Fecha_Nacimiento,@Nacionalidad,@EstadoCivil,@Id_Datos_Contacto,@Id_Credencial,@Id_Permiso");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@Fecha_Nacimiento", nuevo.FechaNacimiento);
                nuevo.Nacionalidad = "Argentina";
                datos.setearParametro("@Nacionalidad", nuevo.Nacionalidad);
                datos.setearParametro("@EstadoCivil", (object)nuevo.EstadoCivil ?? DBNull.Value);
                datos.setearParametro("@Id_Datos_Contacto", nuevo.DatosContacto.IdDatosContacto);
                datos.setearParametro("@Id_Credencial", nuevo.Credencial.IdCredencial);
                datos.setearParametro("@Id_Permiso", nuevo.Permiso.Id);
                return datos.ejecturarAccionScalar();
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

        public bool Login(Persona login)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT Id, Id_Permiso FROM Personas where Id_Credencial = @Id_Credencial");
                datos.setearParametro("@Id_Credencial", login.Credencial.IdCredencial);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    login.Id = (int)datos.Lector["Id"];
                    login.Permiso.Id = (int)datos.Lector["Id_Permiso"];
                    return true;
                }
                return false;
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
