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
            try
            {
                //Tabla DatosContacto
                DatosContactoNegocio datosContactoNegocio = new DatosContactoNegocio();
                nuevo.DatosContacto.IdDatosContacto = datosContactoNegocio.InsertarTablaDatosContacto(nuevo.DatosContacto);
                //Tabla Credencial
                CredencialNegocio credencialNegocio = new CredencialNegocio();
                nuevo.Credencial.IdCredencial = credencialNegocio.InsertarTablaCredencial(nuevo.Credencial);
                //Tabla Persona
                PersonaNegocio personaNegocio = new PersonaNegocio();
                nuevo.Id = personaNegocio.InsertarTablaPersona(nuevo);
                //Tabla Paciente
                nuevo.IdPaciente = InsertarTablaPaciente(nuevo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertarTablaPaciente(Paciente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("EXEC insertPaciente @Id_Persona,@Fecha_Ingreso,@Id_Obra_Social");
                datos.setearParametro("@Id_Persona", nuevo.Id);
                nuevo.FechaAlta = DateTime.Now;
                datos.setearParametro("@Fecha_Ingreso", nuevo.FechaAlta);
                if (nuevo.ObraSocial.IdObraSocial == 0)
                    datos.setearParametro("@Id_Obra_Social", DBNull.Value);
                else
                    datos.setearParametro("@Id_Obra_Social", nuevo.ObraSocial.IdObraSocial);
                return datos.ejecturarAccionScalar();
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

        public int Traerid(string consulta)
        {
            int dato=0;
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    dato = (int)datos.Lector["Id"];
                }
                return dato;
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
