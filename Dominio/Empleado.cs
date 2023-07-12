using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : Persona
    {
        public int IdEmpleado { get; set; }
        public Persona Persona { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaBaja { get; set; }
    }
}
