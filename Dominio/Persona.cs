using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Persona
    {
        int id;
        int dni;
        string nombre;
        string apellido;
        DateTime fechaNacimiento;
        string nacionalidad;
        string estado;
        DatosContacto datosContacto;
        Credencial credencial;
        Permisos permisos;

        public int Dni { get => dni; set => dni = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
        public string Estado { get => estado; set => estado = value; }
        internal DatosContacto DatosContacto { get => datosContacto; set => datosContacto = value; }
        internal Credencial Credencial { get => credencial; set => credencial = value; }
        internal Permisos Permisos { get => permisos; set => permisos = value; }

    }
}
