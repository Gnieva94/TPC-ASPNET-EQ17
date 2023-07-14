using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class HorarioNegocio
    {

        public List<Horario> ListaHorarios()
        {
            List<Horario> horarios = new List<Horario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_ESPACIALIDADES_PROFESIONAL_HORARIO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horario aux = new Horario();

                    aux.Id = (int)datos.Lector["Id_Horario"];
                    aux.Profesional.Id = (int)datos.Lector["Id_Profesional"];
                    aux.Profesional.Nombre = (string)datos.Lector["Nombre"];
                    aux.Profesional.Apellido = (string)datos.Lector["Apellido"];
                    aux.Profesional.Matricula = (string)datos.Lector["Matricula"];
                    aux.Especialidad.Id = (int)datos.Lector["Id_Especialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Dia = (string)datos.Lector["Dia"];
                    aux.HorarioInicio = (int)datos.Lector["Horario_Inicio"];
                    aux.HorarioFin = (int)datos.Lector["Horario_Fin"];

                    horarios.Add(aux);

                }
                return horarios;

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
