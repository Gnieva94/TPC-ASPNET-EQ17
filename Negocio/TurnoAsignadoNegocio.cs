﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                datos.setearParametro("@id_profesional", turno.IdProfesional);
                datos.setearParametro("@id_paciente", turno.IdPaciente);
                datos.setearParametro("@observacion", (object)turno.Observacion ?? DBNull.Value);
                datos.setearParametro("@diagnostico", (object)turno.Diagnostico ?? DBNull.Value);
                datos.setearParametro("@idEstado", turno.IdEstado);
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
                    aux.IdProfesional = (int)datos.Lector["Id_Profesional"];
                    aux.IdPaciente = (int)datos.Lector["Id_Paciente"];
                    aux.Observacion = (string)datos.Lector["Observacion"];
                    aux.Diagnostico = (string)datos.Lector["Diagnostico"];
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

        public List<TurnoAsignado> ListaTurnoAsignado()
        {
            List<TurnoAsignado> lista = new List<TurnoAsignado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_TURNOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TurnoAsignado aux = new TurnoAsignado();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.IdProfesional = (int)datos.Lector["Id_Profesional"];
                    aux.IdPaciente = (int)datos.Lector["Id_Paciente"];
                    aux.Observacion = (string)datos.Lector["Observacion"];
                    aux.Diagnostico = (string)datos.Lector["Diagnostico"];

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
    }
}
