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
                datos.setearSP("SP_LISTAR_PACIENTE");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();

                    aux.IdPaciente = (int)datos.Lector["Id"];
                    //aux.NumeroAfiliado = (string)datos.Lector["Numero_Afiliado"];
                    //aux.FechaIngreso = (DateTime)datos.Lector["Fecha_Ingreso"];
                    aux.Persona = new Persona();
                    aux.Persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.Persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.Persona.Dni = (string)datos.Lector["Dni"];
                    aux.Persona.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                   // aux.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                   // aux.EstadoCivil = (string)datos.Lector["Estado"];
                    aux.DatosContacto = new DatosContacto();
                    //aux.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    if (!(datos.Lector["Direccion"] is DBNull))
                        aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    aux.ObraSocial = new ObraSocial();
                    aux.ObraSocial.Nombre = (string)datos.Lector["Obra_Social"];
                   // aux.Credencial = new Credencial();
                    //aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    //aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    //aux.Permiso = new Permiso();
                    //aux.Permiso.Id = (int)datos.Lector["Permiso.Id"];
                    //aux.Permiso.Descripcion = (string)datos.Lector["Permiso.Nombre"];
                    
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
                nuevo.FechaIngreso = DateTime.Now;
                datos.setearParametro("@Fecha_Ingreso", nuevo.FechaIngreso);
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
