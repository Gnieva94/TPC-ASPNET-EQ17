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
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
        public string Matricula { get; set; }
        public List<Especialidad> Especialidad { get; set; }
        public List<Horario> Horarios { get; set; }
        public List<TurnoAsignado> TurnosAsignados { get; set; }
        
    }
}
