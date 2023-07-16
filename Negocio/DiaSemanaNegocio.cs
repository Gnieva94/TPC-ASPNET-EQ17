using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class DiaSemanaNegocio
    {
        public List<DiasSemana> Listar()
        {
            List<DiasSemana> lista = new List<DiasSemana>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_LISTAR_DIAS_SEMANA");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    DiasSemana aux = new DiasSemana();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dia = (string)datos.Lector["Dia"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }   
    }
}
