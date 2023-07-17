using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MostrarOpciones
    {
        int id { get; set; }
        string descripcion { get; set; }
        DateTime fecha { get; set; }
        
        public MostrarOpciones(int id, string descripcion, DateTime fecha)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }
    }
}
