using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TurnoAsignado
    {
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        public string Observacion { get; set; }
        //
        public int IdProfesional { get; set; } //objeto
        public int IdPaciente { get; set; }
    }
}
