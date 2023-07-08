using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public int IdProfesional { get; set; }
        public Dias Dia { get; set; }
        public DateTime HorarioInicio { get; set; }
        public DateTime HorarioFin { get; set; }

        public enum Dias { 
            Lunes, 
            Martes, 
            Miercoles, 
            Jueves, 
            Viernes, 
            Sabado, 
            Domingo }
        //Agregar dia enum 1 : lunes
    }
}
