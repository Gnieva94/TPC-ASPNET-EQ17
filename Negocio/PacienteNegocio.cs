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
                datos.setearConsulta("");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Paciente aux = new Paciente();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Dni = (string)datos.Lector["Dni"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    aux.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                    aux.EstadoCivil = (string)datos.Lector["Estado"];
                    aux.DatosContacto = new DatosContacto();
                    aux.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    aux.Credencial = new Credencial();
                    aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    aux.Permiso = new Permiso();
                    aux.Permiso.Id = (int)datos.Lector["Permiso.Id"];
                    aux.Permiso.Descripcion = (string)datos.Lector["Permiso.Nombre"];
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
                datos.setearConsulta("INSERT INTO Datos_Contacto (Telefono,Celular,Email,Direccion)Values(@Telefono,@Celular,@Email,@Direccion)");
                datos.setearParametro("@Telefono", (object)nuevo.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Celular", nuevo.DatosContacto.Celular);
                datos.setearParametro("@Email", nuevo.DatosContacto.Email);
                datos.setearParametro("@Direccion", (object)nuevo.DatosContacto.Direccion ?? DBNull.Value);
                //Tabla Credencial
                datos.setearConsulta("INSERT INTO Credenciales (Nombre_Usuario,Contrasenia)VALUES(@Nombre_Usuario,@Contrasenia)");
                datos.setearParametro("@Nombre_Usuario", nuevo.Credencial.NombreUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Credencial.Password);
                datos.ejecutarAccion();
                //Tabla Permisos
                //datos.setearConsulta("INSERT INTO Permisos (Nombre)VALUES(@Nombre)");
                //datos.setearParametro("@Nombre", nuevo.Permiso.Descripcion);
                //datos.ejecutarAccion();

                //Tabla Persona
                datos.cerrarConexion();
                //datos = new AccesoDatos();
                //datos.setearConsulta("SELECT TOP 1 Id FROM Credenciales ORDER BY Id DESC");
                //datos.ejecutarAccion();
                //nuevo.Credencial.IdCredencial = (int)datos.Lector["Id"];
                nuevo.Credencial.IdCredencial = traerid("SELECT TOP 1 Id Credenciales ORDER BY Id DESC");
                //datos.cerrarConexion();
                //datos.setearConsulta("SELECT TOP 1 Id FROM Datos_Contacto ORDER BY Id DESC");
                //datos.ejecutarLectura();
                nuevo.DatosContacto.IdDatosContacto = traerid("SELECT TOP 1 Id FROM Datos_Contacto ORDER BY Id DESC");
                //datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("INSERT INTO PERSONAS (Nombre,Apellido,Fecha_Nacimiento,Dni, Id_Permiso, Id_Credencial, Id_Datos_Contacto)VALUES(@Nombre,@Apellido,@Fecha_Nacimiento,@Dni,@Id_Permiso,@Id_Credencial,@Id_Datos_Contacto)");
                //datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Nombre",nuevo.Nombre);
                datos.setearParametro("@Apellido",nuevo.Apellido);
                datos.setearParametro("@Fecha_Nacimiento", nuevo.FechaNacimiento);
                datos.setearParametro("@Id_Permiso", nuevo.Permiso.Id);
                datos.setearParametro("@Id_Credencial", nuevo.Credencial.IdCredencial);
                datos.setearParametro("@Id_Datos_Contacto", nuevo.DatosContacto.IdDatosContacto);
                //datos.setearParametro("Estado",nuevo.EstadoCivil);
                datos.setearParametro("@Dni",nuevo.Dni);
                datos.ejecutarAccion();

                //Tabla Paciente
                datos.cerrarConexion();
                datos = new AccesoDatos();
                datos.setearConsulta("SELECT TOP 1 (Id) FROM Personas ORDER BY ASC");
                nuevo.Id = (int)datos.Lector["Id"];
                datos.setearConsulta("INSERT INTO PACIENTES (Id_Persona,Fecha_Ingreso,Id_Obra_Social)VALUES(@Id_Persona,@Fecha_Ingreso,@Id_Obra_Social)");
                datos.setearParametro("@Id_Persona", nuevo.Id);
                nuevo.FechaIngreso = DateTime.Now;
                datos.setearParametro("@Fecha_Ingreso", nuevo.FechaIngreso);
                datos.setearParametro("@Id_Obra_Social", (object)nuevo.ObraSocial?? DBNull.Value);
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

        public void ModificarPaciente(Paciente modificar)
        {

        }
        public void EliminarPaciente(int Id)
        {

        }

        public int traerid(string consulta)
        {
            int dato = -1;
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    dato = (int)datos.Lector["Id"];
                }
                datos.cerrarConexion();
                return dato;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }



    }
}
