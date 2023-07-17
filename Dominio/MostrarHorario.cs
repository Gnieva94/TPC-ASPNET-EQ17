using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MostrarHorario
    {
        public int idSeleccionado { get; set; }
        public string descripcion { get; set; }

        public MostrarHorario(int idSeleccionado, string descripcion)
        {
            this.idSeleccionado = idSeleccionado;
            this.descripcion = descripcion;
        }
    }

    
}
