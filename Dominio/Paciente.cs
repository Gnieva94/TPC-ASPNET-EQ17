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
        public Persona Persona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public ObraSocial ObraSocial { get; set; }
        public string NumeroAfiliado { get; set; }
        public List<TurnoAsignado> TurnosAsignados { get; set; }

        //public HistoriaClinica HistoriaClinica { get; set; }

    }
}
