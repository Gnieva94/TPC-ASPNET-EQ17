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
        public List<Horario> ListarHorarios()
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

        public List<Horario> ListaHorarios()
        {
            List<Horario> horarios = new List<Horario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_ESPACIALIDADES_PROFESIONAL_HORARIO_2");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Horario aux = new Horario();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Profesional.IdProfesional = (int)datos.Lector["Id_Profesional"];
                    aux.IdDia = (int)datos.Lector["Id_Dia"];
                    aux.HorarioInicio = (int)datos.Lector["Horario_Inicio"];
                    aux.HorarioFin = (int)datos.Lector["Horario_Fin"];
                    aux.Especialidad.Id = (int)datos.Lector["Id_Especialidad"];
                    
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

        public void AgregarHorarios(Horario horario, int idProfesional)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ALTA_HORARIO_PROFESIONAL");
                datos.setearParametro("@Id_Profesional",idProfesional);
                datos.setearParametro("@Id_Dia",horario.IdDia);
                datos.setearParametro("@HorarioInicio",horario.HorarioInicio);
                datos.setearParametro("@HorarioFin",horario.HorarioFin);
                datos.setearParametro("@Id_Especialidad",horario.Especialidad.Id);
                datos.ejecutarLectura();
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

        public void ModificarHorario(Horario horario) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_MODIFICAR_HORARIO_X_PROFESIONAL");
                datos.setearParametro("@Id_Horario",horario.Id);
                datos.setearParametro("@Id_Profesional",horario.Profesional.IdProfesional);
                datos.setearParametro("@Id_Dia",horario.IdDia);
                datos.setearParametro("@Horario_Inicio",horario.HorarioInicio);
                datos.setearParametro("@Horario_Fin",horario.HorarioFin);
                datos.setearParametro("@Id_Especialidad",horario.Especialidad.Id);
                datos.ejecutarLectura();
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

        public List<Horario> BuscarHorarioPorProfesional(int idProfesional)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Horario> horarios = new List<Horario>();
            try
            {
                datos.setearSP("SP_BUSCAR_HORARIO_X_PROFESIONAL");
                datos.setearParametro("@Id_Profesional", idProfesional);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Horario aux = new Horario();
                    aux.Id = (int)datos.Lector["Id_Horario"];
                    aux.Profesional.IdProfesional = (int)datos.Lector["Id_Profesional"];
                    aux.Especialidad.Id = (int)datos.Lector["Id_Especialidad"];
                    aux.Especialidad.Nombre = (string)datos.Lector["Especialidad_Nombre"];
                    aux.IdDia = (int)datos.Lector["Id_Dia"];
                    aux.Dia = (string)datos.Lector["Dia_Nombre"];
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
