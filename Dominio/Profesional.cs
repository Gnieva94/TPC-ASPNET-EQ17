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
        public Especialidad Especialidad { get; set; } //Lista
        public Horario Horario { get; set; } //Lista - dia / horainicio horafin
        public string Matricula { get; set; }
    }
}
