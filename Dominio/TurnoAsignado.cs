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
        public int IdProfesional { get; set; }
        public int IdPaciente { get; set; }
        public string Observacion { get; set; }
        public string Diagnostico { get; set; }
        public int IdEstado { get; set; }
       
    }
}
