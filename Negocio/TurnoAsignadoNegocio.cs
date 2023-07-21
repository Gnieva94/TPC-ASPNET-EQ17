using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataBase;
using Dominio;

namespace Negocio
{
    public class TurnoAsignadoNegocio
    {
        public void AltaTurno(TurnoAsignado turno)
        {
  
            AccesoDatos datos = new AccesoDatos();
        
            try
            {
                datos.setearSP("SP_INSERTAR_TURNO");
                datos.setearParametro("@FECHA", turno.Fecha);
                datos.setearParametro("@id_profesional", turno.Profesional.IdProfesional);
                datos.setearParametro("@id_paciente", turno.Paciente.IdPaciente);
                datos.setearParametro("@observacion", (object)turno.Observacion ?? DBNull.Value);
                datos.setearParametro("@diagnostico", (object)turno.Diagnostico ?? DBNull.Value);
                datos.setearParametro("@idEstado", turno.EstadoTurno.Id);
                datos.setearParametro("@idEspecialidad", turno.Especialidad.Id);
                datos.ejecutarAccion();
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

        public List<TurnoAsignado> turnosAsignados(int dia, int especialidad, int profesional)
        {
            List<TurnoAsignado> lista = new List<TurnoAsignado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC SP_LISTAR_TURNO_ASIGNADO @Dia, @Especialidad, @Profesional");
                datos.setearParametro("@dia", dia);
                datos.setearParametro("@especialidad", especialidad);
                datos.setearParametro("@profesional", profesional);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAsignado aux = new TurnoAsignado();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Profesional.Id = (int)datos.Lector["Id_Profesional"];
                    aux.Paciente.Id = (int)datos.Lector["Id_Paciente"];
                    aux.Observacion = (string)datos.Lector["Observacion"];
                    aux.Diagnostico = (string)datos.Lector["Diagnostico"];
                    aux.Especialidad.Id = (int)datos.Lector["Id_Especialidad"];
                    lista.Add(aux);
                }
                return lista;
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

        public int verificarDisponibilidad(DateTime horaSeleccionada)
        {
           
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_VERIFICAR_DISPONIBILIDAD_TURNO");
                datos.setearParametro("@horaSeleccionada", horaSeleccionada);
                datos.ejecutarLectura();
                int aux = 0;

                while (datos.Lector.Read())
                {   
                    aux = (int)datos.Lector["DisponibilidadTurno"];
                    return aux;
                }

                return aux;

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

        public List<TurnoAsignado> ListaTurnoAsignado(int id)
        {
            List<TurnoAsignado> lista = new List<TurnoAsignado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_TURNOS_PACIENTE");
                datos.setearParametro("@Id_Paciente", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAsignado aux = new TurnoAsignado();
                    //aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.Profesional.Id = (int)datos.Lector["Id_Profesional"];
                    aux.Profesional.Nombre = (string)datos.Lector["Nombre"];
                    aux.Profesional.Apellido = (string)datos.Lector["Apellido"];
                    aux.Profesional.Matricula = (string)datos.Lector["Matricula"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad"];
                    aux.Paciente.Id = (int)datos.Lector["Id_Paciente"];
                    if (!(datos.Lector["Observacion"] is DBNull))
                        aux.Observacion = (string)datos.Lector["Observacion"];
                    if (!(datos.Lector["Diagnostico"] is DBNull))
                        aux.Diagnostico = (string)datos.Lector["Diagnostico"];
                    aux.EstadoTurno.Nombre = (string)datos.Lector["Estado"];

                    lista.Add(aux);
                }
                return lista;

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

        public void CancelarTurno(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_CANCELAR_TURNO");
                datos.setearParametro("@Id", id);
                datos.ejecutarAccion();
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
