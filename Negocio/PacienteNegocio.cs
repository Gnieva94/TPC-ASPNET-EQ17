using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

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

                    aux.Id = (int)datos.Lector["Id"];
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
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //Tabla DatosContacto
                datos.setearConsulta("EXEC insertDatosContacto @Telefono,@Celular,@Email,@Direccion;EXEC insertCredenciales @Nombre_Usuario,@Contrasenia;");
                datos.setearParametro("@Telefono", (object)nuevo.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Celular", nuevo.DatosContacto.Celular);
                datos.setearParametro("@Email", nuevo.DatosContacto.Email);
                datos.setearParametro("@Direccion", (object)nuevo.DatosContacto.Direccion ?? DBNull.Value);
                //Tabla Credencial
                datos.setearParametro("@Nombre_Usuario", nuevo.Credencial.NombreUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Credencial.Password);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                //Tabla Persona
                nuevo.Credencial.IdCredencial = Traerid("SELECT TOP 1 Id FROM Credenciales ORDER BY Id DESC");
                nuevo.DatosContacto.IdDatosContacto = Traerid("SELECT TOP 1 Id FROM Datos_Contacto ORDER BY Id DESC");
                datos = new AccesoDatos();
                datos.setearConsulta("EXEC insertPersona @Nombre,@Apellido,@Dni,@Fecha_Nacimiento,@Nacionalidad,@EstadoCivil,@Id_Datos_Contacto,@Id_Credencial,@Id_Permiso;");
                datos.setearParametro("@Nombre",nuevo.Nombre);
                datos.setearParametro("@Apellido",nuevo.Apellido);
                datos.setearParametro("@Dni",nuevo.Dni);
                datos.setearParametro("@Fecha_Nacimiento", nuevo.FechaNacimiento);
                nuevo.Nacionalidad = "Argentina";
                datos.setearParametro("@Nacionalidad", nuevo.Nacionalidad);
                datos.setearParametro("@EstadoCivil",(object)nuevo.EstadoCivil??DBNull.Value);
                datos.setearParametro("@Id_Datos_Contacto", nuevo.DatosContacto.IdDatosContacto);
                datos.setearParametro("@Id_Credencial", nuevo.Credencial.IdCredencial);
                datos.setearParametro("@Id_Permiso",nuevo.Permiso.Id);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                //Tabla Paciente
                datos = new AccesoDatos();
                nuevo.Id = Traerid("SELECT TOP 1 Id FROM Personas ORDER BY Id DESC");
                datos.setearConsulta("EXEC insertPaciente @Id_Persona,@Fecha_Ingreso,@Id_Obra_Social");
                datos.setearParametro("@Id_Persona", nuevo.Id);
                nuevo.FechaIngreso = DateTime.Now;
                datos.setearParametro("@Fecha_Ingreso", nuevo.FechaIngreso);
                datos.setearParametro("@Id_Obra_Social", (object)nuevo.ObraSocial?? DBNull.Value);
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
