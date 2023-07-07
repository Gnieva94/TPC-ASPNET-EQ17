using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Seguridad
    {
        public static bool SesionActiva(object obj)
        {
            Persona persona = obj != null ? (Persona)obj : null;
            if (persona != null && persona.Id != 0)
                return true;
            else
                return false;
        }
        public static bool EsEmpleado(object obj)
        {
            Persona recepcionista = obj != null ? (Persona)obj : null;
            if (recepcionista != null && recepcionista.Id != 0 && recepcionista.Permiso.Id == 2)
                return true;
            return false;
        }
        public static bool EsAdmin(object obj)
        {
            Persona administrador = obj != null ? (Persona)obj : null;
            if (administrador != null && administrador.Id != 0 && administrador.Permiso.Id == 1)
                return true;
            return false;
        }
    }
}
