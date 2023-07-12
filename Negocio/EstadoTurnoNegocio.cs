using DataBase;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoTurnoNegocio
    {

        public List<EstadoTurno> Listar()
        {
            List<EstadoTurno> turno = new List<EstadoTurno>();
            AccesoDatos datos = new AccesoDatos();
            
            try
            {
                datos.setearSP("SP_LISTAR_ESTADOTURNO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    EstadoTurno aux = new EstadoTurno();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    turno.Add(aux);
                }
                return turno;
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

        public bool AgregarEstadoTurno(EstadoTurno estadoTurno)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_AGREGAR_ESTADOTURNO");
                datos.setearParametro("@Nombre", estadoTurno.Nombre);
                datos.ejecutarAccion();
                return true;
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
