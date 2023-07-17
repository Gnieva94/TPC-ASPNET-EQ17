using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class MostrarOpciones
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
        
        public MostrarOpciones(int id, string descripcion, DateTime fecha)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.fecha = fecha;
        }
    }
}
