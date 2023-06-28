using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Permisos
    {
        int codigoPermiso;
        string descripcion;

        public int CodigoPermiso { get => codigoPermiso; set => codigoPermiso = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }

    }
}
