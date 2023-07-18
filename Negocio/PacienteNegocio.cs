using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class PacienteNegocio
    {
        public List<Paciente> ListaPacientes() {

            List<Paciente> pacientes = new List<Paciente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_PACIENTES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.IdPaciente = (int)datos.Lector["Id_Paciente"];
                    aux.Id = (int)datos.Lector["Id_Persona"];
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
                    aux.ObraSocial = new ObraSocial();
                    aux.ObraSocial.Nombre = (string)datos.Lector["Obra_Social"];
                    if (!(datos.Lector["Nro_Afiliado"] is DBNull))
                        aux.NumeroAfiliado = (int)datos.Lector["Nro_Afiliado"];
                    aux.FechaAlta = (DateTime)datos.Lector["Fecha_Alta"];


                    pacientes.Add(aux);
                }

                return pacientes;
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

        public void AgregarPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ALTA_TODO_PACIENTE");
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
                datos.setearParametro("@Id_Obra_Social", nuevo.ObraSocial.IdObraSocial);
                if (nuevo.NumeroAfiliado == 0)
                    datos.setearParametro("@Nro_Afiliado", DBNull.Value);
                else
                    datos.setearParametro("@Nro_Afiliado", (object)nuevo.NumeroAfiliado ?? DBNull.Value);
                nuevo.IdPaciente = datos.ejecutarAccionScalar();
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

        public void ModificarPaciente(Paciente modificar)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_MODIFICAR_PACIENTE");
                datos.setearParametro("@Id_Paciente", modificar.IdPaciente);
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
                datos.setearParametro("@Id_Obra_Social", (object)modificar.ObraSocial.IdObraSocial ?? DBNull.Value);
                datos.setearParametro("@Nro_Afiliado", modificar.NumeroAfiliado);
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
        public void BajaPaciente(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_BAJA_PACIENTE");
                datos.setearParametro("@Id_Paciente", id);
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

        public Paciente traerRegistroPorId(int Id)
        {
            AccesoDatos datos = new AccesoDatos();
            Paciente paciente;
            try
            {
                datos.setearSP("SP_BUSCAR_PACIENTE_POR_ID");
                datos.setearParametro("@Id_Paciente", Id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    paciente = new Paciente();
                    paciente.Id = (int)datos.Lector["Id_Persona"];
                    //paciente.IdPaciente = (int)datos.Lector["Id_Paciente"];
                    paciente.Nombre = (string)datos.Lector["Nombre"];
                    paciente.Apellido = (string)datos.Lector["Apellido"];
                    paciente.Dni = (string)datos.Lector["Dni"];
                    paciente.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    paciente.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                    paciente.DatosContacto = new DatosContacto();
                    paciente.DatosContacto.IdDatosContacto = (int)datos.Lector["Id_Datos_Contacto"];
                    paciente.DatosContacto.Email = (string)datos.Lector["Email"];
                    //paciente.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    //paciente.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    //paciente.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    //paciente.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                    //paciente.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                    //paciente.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                    if (!(datos.Lector["Celular"] is DBNull))
                        paciente.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    if (!(datos.Lector["Telefono"] is DBNull))
                        paciente.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    if (!(datos.Lector["Direccion"] is DBNull))
                        paciente.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    if (!(datos.Lector["Localidad"] is DBNull))
                        paciente.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                    if (!(datos.Lector["Provincia"] is DBNull))
                        paciente.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                    if (!(datos.Lector["Codigo_Postal"] is DBNull))
                        paciente.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                    paciente.ObraSocial = new ObraSocial();
                    paciente.ObraSocial.IdObraSocial = (int)datos.Lector["Id_Obra_Social"];
                    //paciente.NumeroAfiliado = (int)datos.Lector["Nro_Afiliado"];
                    if (!(datos.Lector["Nro_Afiliado"] is DBNull))
                        paciente.NumeroAfiliado = (int)datos.Lector["Nro_Afiliado"];

                    return paciente;
                }
                paciente = null;
                return paciente;
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
