using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        public List<Empleado> ListaEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_EMPLEADOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.IdEmpleado = (int)datos.Lector["Id_Empleado"];
                    aux.Id = (int)datos.Lector["Id_Persona"];
                    aux.FechaAlta = (DateTime)datos.Lector["Fecha_Alta"];
                    if (!(datos.Lector["Fecha_Baja"] is DBNull))
                        aux.FechaBaja = (DateTime)datos.Lector["Fecha_Baja"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    aux.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                    aux.DatosContacto = new DatosContacto();
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    if (!(datos.Lector["Celular"] is DBNull))
                        aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                        aux.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    if (!(datos.Lector["Direccion"] is DBNull))
                        aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    if (!(datos.Lector["Localidad"] is DBNull))
                        aux.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                    if (!(datos.Lector["Provincia"] is DBNull))
                        aux.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                    if (!(datos.Lector["Codigo_Postal"] is DBNull))
                        aux.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                    aux.Credencial = new Credencial();
                    aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    aux.Permiso = new Permiso();
                    aux.Permiso.Descripcion = (string)datos.Lector["Permiso"];

                    empleados.Add(aux);
                }
                return empleados;
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

        public void AgregarEmpleado(Empleado nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ALTA_EMPLEADO");
                datos.setearParametro("@Nombre", nuevo.Nombre);
                datos.setearParametro("@Apellido", nuevo.Apellido);
                datos.setearParametro("@Dni", nuevo.Dni);
                datos.setearParametro("@Fecha_Nacimiento", nuevo.FechaNacimiento);
                datos.setearParametro("@Nacionalidad", nuevo.Nacionalidad);
                datos.setearParametro("@Email", nuevo.DatosContacto.Email);
                datos.setearParametro("@Celular", (object)nuevo.DatosContacto.Celular ?? DBNull.Value);
                datos.setearParametro("@Telefono", (object)nuevo.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)nuevo.DatosContacto.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad", (object)nuevo.DatosContacto.Localidad ?? DBNull.Value);
                datos.setearParametro("@Provincia", (object)nuevo.DatosContacto.Provincia ?? DBNull.Value);
                datos.setearParametro("@Codigo_Postal", (object)nuevo.DatosContacto.CodigoPostal ?? DBNull.Value);
                datos.setearParametro("@Nombre_Usuario", nuevo.Credencial.NombreUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Credencial.Password);
                nuevo.IdEmpleado = datos.ejecutarAccionScalar();
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

        public void ModificarEmpleado(Empleado modificar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_MODIFICAR_EMPLEADO");
                datos.setearParametro("@Id_Empleado", modificar.IdEmpleado);
                datos.setearParametro("@Id_Persona", modificar.Id);
                datos.setearParametro("@Id_Datos_Contacto", modificar.DatosContacto.IdDatosContacto);
                datos.setearParametro("@Nombre", modificar.Nombre);
                datos.setearParametro("@Apellido", modificar.Apellido);
                datos.setearParametro("@Dni", modificar.Dni);
                datos.setearParametro("@Fecha_Nacimiento", modificar.FechaNacimiento);
                datos.setearParametro("@Nacionalidad", modificar.Nacionalidad);
                datos.setearParametro("@Email", modificar.DatosContacto.Email);
                datos.setearParametro("@Celular", (object)modificar.DatosContacto.Celular ?? DBNull.Value);
                datos.setearParametro("@Telefono", (object)modificar.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion", (object)modificar.DatosContacto.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad", (object)modificar.DatosContacto.Localidad ?? DBNull.Value);
                datos.setearParametro("@Provincia", (object)modificar.DatosContacto.Provincia ?? DBNull.Value);
                datos.setearParametro("@Codigo_Postal", (object)modificar.DatosContacto.CodigoPostal ?? DBNull.Value);
                datos.setearParametro("@Id_Permiso", modificar.Permiso.Id);
                datos.ejecutarLectura();
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

        public Empleado traerRegistroPorId (int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Empleado empleado;
            try
            {
                datos.setearSP("SP_BUSCAR_EMPLEADO_POR_ID");
                datos.setearParametro("@Id_Empleado", Id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    empleado = new Empleado();
                    //empleado.IdEmpleado = (int)datos.Lector["Id_Empleado"];
                    empleado.Id = (int)datos.Lector["Id_Persona"];
                    empleado.Nombre = (string)datos.Lector["Nombre"];
                    empleado.Apellido = (string)datos.Lector["Apellido"];
                    empleado.Dni = (string)datos.Lector["Dni"];
                    empleado.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    empleado.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                    empleado.DatosContacto = new DatosContacto();
                    empleado.DatosContacto.IdDatosContacto = (int)datos.Lector["Id_Datos_Contacto"];
                    empleado.DatosContacto.Email = (string)datos.Lector["Email"];
                    empleado.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    empleado.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    empleado.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    empleado.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                    empleado.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                    empleado.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                    empleado.Permiso = new Permiso();
                    empleado.Permiso.Id = (int)datos.Lector["Id_Permiso"];
             
                    return empleado;
                }
                empleado = null;
                return empleado;
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

        public void BajaEmpleado(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_BAJA_EMPLEADO");
                datos.setearParametro("@Id_Empleado", id);
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
