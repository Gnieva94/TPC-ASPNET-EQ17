using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class ProfesionalNegocio
    {
        public List<Profesional> ListaProfesionales()
        {
            List<Profesional> profesionales = new List<Profesional>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_PROFESIONAL");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();

                    aux.IdProfesional = (int)datos.Lector["Id"];
                    aux.FechaIngreso = (DateTime)datos.Lector["Fecha_Ingreso"];
                    aux.FechaEgreso = (DateTime)datos.Lector["Fecha_Egreso"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    aux.Persona = new Persona();
                    aux.Persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.Persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.Persona.Dni = (string)datos.Lector["Dni"];
                    aux.Persona.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    aux.DatosContacto = new DatosContacto();
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    aux.Especialidad = new Especialidad();
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                    //aux.Horario = new Horario();
                    //aux.Horario.Dia = (string)datos.Lector["Dia"];
                    //aux.Horario.HoraInicio = (DateTime)datos.Lector["Hora_Inicio"];
                    //aux.Horario.HoraFin = (DateTime)datos.Lector["Hora_Fin"];
                    //aux.Credencial = new Credencial();
                    //aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    //aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    //aux.Permiso = new Permiso();
                    //aux.Permiso.Id = (int)datos.Lector["Permiso.Id"];
                    //aux.Permiso.Descripcion = (string)datos.Lector["Permiso.Nombre"];

                    profesionales.Add(aux);
                }
                return profesionales;
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
