using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ObraSocial
    {
        public int IdObraSocial { get; set; }
        public string Nombre { get; set; }
        public DatosContacto DatosContacto { get; set; }
        public int Estado { get; set; }
    }
}
