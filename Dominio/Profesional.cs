using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional : Persona
    {
        public int IdProfesional { get; set; }
        public Persona Persona { get; set; }
        public DateTime FechaIngreso { get; set; } //alta
        public DateTime FechaEgreso { get; set; } //baja
        public List<Especialidad> Especialidad { get; set; } //Lista
        public List<Horario> Horarios { get; set; } //Lista - dia / horainicio horafin
        public List<TurnoAsignado> TurnosAsignados { get; set; } //Lista - fecha / horario / observacion
        public string Matricula { get; set; }
    }
}
