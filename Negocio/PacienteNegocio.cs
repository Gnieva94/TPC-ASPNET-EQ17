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
                //Tabla Persona
                datos.setearConsulta("INSERT INTO PERSONAS (Id,Nombre,Apellido,Fecha_Nacimiento,Estado,Id_Datos_Contacto,Id_Credencial,Id_Permiso,Dni)VALUES(@Id,@Nombre,@Apellido,@Fecha_Nacimiento,@Estado,@Id_Datos_Contacto,@Id_Credencial,@Id_Permiso,@Dni)");
                datos.setearParametro("@Id", nuevo.Id);
                datos.setearParametro("@Nombre",nuevo.Nombre);
                datos.setearParametro("@Apellido",nuevo.Apellido);
                datos.setearParametro("@Fecha_Nacimiento", nuevo.FechaNacimiento);
                datos.setearParametro("Estado",nuevo.EstadoCivil);
                datos.setearParametro("@Id_Datos_Contacto",nuevo.DatosContacto.IdDatosContacto);
                datos.setearParametro("@Id_Credencial",nuevo.Credencial.IdCredencial);
                datos.setearParametro("@Id_Permiso",nuevo.Permiso.Id);
                datos.setearParametro("@Dni",nuevo.Dni);
                datos.ejecutarAccion();
                //Tabla Paciente
                datos.setearConsulta("INSERT INTO PACIENTES (Id,Id_Persona,Fecha_Ingreso,Id_Obra_Social)VALUES(@Id,@Id_Persona,@Fecha_Ingreso,@Id_Obra_Social)");
                datos.setearParametro("@Id", nuevo.IdPaciente);
                datos.setearParametro("@Id_Persona", nuevo.Id);
                datos.setearParametro("@Fecha_Ingreso", nuevo.FechaIngreso);
                datos.setearParametro("@Id_Obra_Social", nuevo.ObraSocial);
                datos.ejecutarAccion();
                //Tabla DatosContacto
                datos.setearConsulta("INSERT INTO Datos_Contacto (Id,Telefono,Celular,Email,Direccion)Values(@Id,@Telefono,@Celular,@Email,@Direccion)");
                datos.setearParametro("@Id", nuevo.DatosContacto.IdDatosContacto);
                datos.setearParametro("@Telefono", nuevo.DatosContacto.Telefono);
                datos.setearParametro("@Celular", nuevo.DatosContacto.Celular);
                datos.setearParametro("@Email", nuevo.DatosContacto.Email);
                datos.setearParametro("@Direccion", nuevo.DatosContacto.Direccion);
                datos.ejecutarAccion();
                //Tabla Credencial
                datos.setearConsulta("INSERT INTO Credenciales (Id,Nombre_Usuario,Contrasenia)VALUES(@Id,@Nombre_Usuario,@Contrasenia)");
                datos.setearParametro("@Id", nuevo.Credencial.IdCredencial);
                datos.setearParametro("@Nombre_Usuario", nuevo.Credencial.NombreUsuario);
                datos.setearParametro("@Contrasenia", nuevo.Credencial.Password);
                datos.ejecutarAccion();
                //Tabla Permisos
                datos.setearConsulta("INSERT INTO Permisos (Id,Nombre)VALUES(@Id,@Nombre)");
                datos.setearParametro("@Id", nuevo.Permiso.Id);
                datos.setearParametro("@Nombre", nuevo.Permiso.Descripcion);
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



    }
}
