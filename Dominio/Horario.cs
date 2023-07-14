using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public Profesional Profesional { get; set; }
        public Especialidad Especialidad { get; set; }
        public string Dia { get; set; }
        public int HorarioInicio { get; set; }
        public int HorarioFin { get; set; }

        public Horario()
        {
            Profesional = new Profesional();
            Especialidad = new Especialidad();
        }
    }
}
