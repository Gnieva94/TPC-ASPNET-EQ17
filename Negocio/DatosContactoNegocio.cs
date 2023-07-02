using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using DataBase;

namespace Negocio
{
    public class DatosContactoNegocio
    {
        public void InsertarTablaDatosContacto(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO Datos_Contacto (Telefono,Celular,Email,Direccion)Values(@Telefono,@Celular,@Email,@Direccion)");
                datos.setearParametro("@Telefono", (object)nuevo.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Celular", nuevo.DatosContacto.Celular);
                datos.setearParametro("@Email", nuevo.DatosContacto.Email);
                datos.setearParametro("@Direccion", (object)nuevo.DatosContacto.Direccion ?? DBNull.Value);
                datos.ejecutarAccion();
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
