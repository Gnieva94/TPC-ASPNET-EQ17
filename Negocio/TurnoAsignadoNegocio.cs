using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    internal class TurnoAsignadoNegocio
    {
        public void AltaTurno(TurnoAsignado turno)
        {
            //el turno esta disponible?
            AccesoDatos datos = new AccesoDatos();
        
            try
            {
                datos.setearConsulta("EXEC SP_insertar_turno @FECHA, @ID_PROFESIONAL, @Id_Paciente, @OBSERVACION, @DIAGNOSTICO");
                datos.setearParametro("@FECHA", turno.Fecha);
                datos.setearParametro("@id_profesional", turno.IdProfesional);
                datos.setearParametro("@id_paciente", turno.IdPaciente);
                datos.setearParametro("@observacion", turno.Observacion);
                datos.setearParametro("@diagnostico", turno.Diagnostico);
                datos.ejecutarAccion();
                datos.cerrarConexion();
             

                
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
