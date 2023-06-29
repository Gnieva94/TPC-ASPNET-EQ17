using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente : Persona
    {
        public int IdPaciente { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string ObraSocial { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

    }
}
