using Dominio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class TurnoHelper
    {
        public static List<MostrarHorario> ObtenerHorariosDisponibles( List<Horario> lista)
        {
            List<MostrarHorario> listaHorarios = new List<MostrarHorario>();

            foreach (var item in lista)
            {

                int horas = item.HorarioFin - item.HorarioInicio;

                for (int i = 0; i < horas; i++)
                {
                    string descripcion = (item.HorarioInicio + i) + " hs";
                    int aux = item.HorarioInicio + i;
                    MostrarHorario mostrarHorario = new MostrarHorario(aux, descripcion);
                    listaHorarios.Add(mostrarHorario);
                }
            }

            return listaHorarios;
        }

        public static List<Profesional> obtenerProfesionales(List<Horario> listaHorarios, List<Profesional> profesional)
        {
            List<Profesional> listaProfesionales = new List<Profesional>();
            foreach (var item in listaHorarios)
            {
                foreach(var item2 in profesional)
                {
                    if (item.Profesional.IdProfesional == item2.IdProfesional)
                    {
                        listaProfesionales.Add(item2);
                    }
                }
            }
            return listaProfesionales;
        }

        public static List<Horario> obtenerDiasDisponibles(List<Horario> listaHorarios, int idProfesional)
        {
            List<Horario> listaDiasDisponibles = new List<Horario>();
            foreach (var item in listaHorarios)
            {
                if (item.Profesional.IdProfesional == idProfesional)
                {
                    listaDiasDisponibles.Add(item);
                }
            }
            return listaDiasDisponibles;
        }

        public static DateTime obtenerFecha( int hora, int dia)
        {
            DateTime hoy = DateTime.Now;


            int diaHoy = (int)hoy.DayOfWeek;

            if (diaHoy == dia)
            {

                hoy = hoy.AddDays(7);
            }
            else
            {
                int diferencia = dia - diaHoy;

                if (diferencia < 0) diferencia = diferencia + 7;

                hoy = hoy.AddDays(diferencia);
            }

            DateTime fechaHora = new DateTime(hoy.Year, hoy.Month, hoy.Day, hora, 0, 0);
            return fechaHora;
        }

        public static List<DiasSemana> devolverDiasDeAtencion(List<DiasSemana> dias, List<Horario> horarios)
        {
            List<DiasSemana> aux = new List<DiasSemana>();

            foreach (var item in dias)
            {
                foreach (var item2 in horarios)
                {
                    if (item.Id == item2.IdDia)
                    {
                        aux.Add(item);
                    }
                }
            }

            return aux;
        }

        //public static List<MostrarOpciones> cargarOpciones(List<Horario> horarios, int horaAtencion, int idDia)
        //{
        //    DateTime HoraAGuardar = obtenerFecha(horaAtencion, idDia);
            
        //    List<TurnoAsignado> asignados 
            

        //    return opciones;
        //}   
    }
}
