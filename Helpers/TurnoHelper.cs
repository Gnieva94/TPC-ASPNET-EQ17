using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class TurnoHelper
    {
        public static List<int> ObtenerHorariosDisponibles( int horarioInicio, int horarioFin)
        {
            List<int> horariosDisponibles = new List<int>();
            for (int i = horarioInicio; i < horarioFin; i++)
            {
                    horariosDisponibles.Add(i);
            }
            return horariosDisponibles;
        }

        public static List<Profesional> obtenerProfesionales(List<Horario> listaHorarios, int idEspecialidad)
        {
            List<Profesional> listaProfesionales = new List<Profesional>();
            foreach (var item in listaHorarios)
            {
                if (item.Especialidad.Id == idEspecialidad)
                {
                    listaProfesionales.Add(item.Profesional);
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
            DateTime hoy = DateTime.Today;

            int diaHoy = (int)hoy.DayOfWeek;

            if (diaHoy == dia)
            {

                hoy = hoy.AddDays(7);
            }
            else
            {
                int diferencia = 7 - ((dia - diaHoy) * -1);
                hoy = hoy.AddDays(diferencia);
            }

            DateTime fechaHora = new DateTime(hoy.Year, hoy.Month, hoy.Day, hora, 0, 0);
            return fechaHora;
        }
    }
}
