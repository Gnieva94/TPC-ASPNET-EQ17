using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Profesional : Persona
    {
        public int Id { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaEgreso { get; set; }
        public Especialidad Especialidad { get; set; }
        public Horario Horario { get; set; }
        public string Matricula { get; set; }
    }
}
