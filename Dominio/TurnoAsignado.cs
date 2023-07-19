using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TurnoAsignado
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Profesional Profesional { get; set; }
        public Especialidad Especialidad { get; set; }
        public Paciente Paciente { get; set; }
        public string Observacion { get; set; }
        public string Diagnostico { get; set; }
        public EstadoTurno EstadoTurno { get; set; }

        public TurnoAsignado()
        {
            Profesional = new Profesional();
            Paciente = new Paciente();
            EstadoTurno = new EstadoTurno();
            Especialidad = new Especialidad();
        }
       
    }
}
