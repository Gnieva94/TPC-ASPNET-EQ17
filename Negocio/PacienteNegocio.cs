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
                datos.setearParametro("@Id_Obra_Social", (object)nuevo.ObraSocial.IdObraSocial ?? DBNull.Value);
                datos.setearParametro("@Nro_Afiliado", nuevo.NumeroAfiliado);
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

        }
        public void EliminarPaciente(int Id)
        {

        }

       
    }
}
