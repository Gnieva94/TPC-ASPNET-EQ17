using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Nacionalidad { get; set; }
        public bool Estado { get; set; }
        public DatosContacto DatosContacto { get; set; }
        public Credencial Credencial { get; set; }
        public Permisos Permisos { get; set; }
    }
}
