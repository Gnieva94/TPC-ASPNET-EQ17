﻿using System;
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
                datos.setearSP("SP_LISTAR_EMPLEADO");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Empleado aux = new Empleado();

                    aux.IdEmpleado = (int)datos.Lector["Id"];
                    aux.FechaIngreso = (DateTime)datos.Lector["Fecha_Ingreso"];
                    aux.FechaEgreso = (DateTime)datos.Lector["Fecha_Egreso"];
                    aux.Persona = new Persona();
                    aux.Persona.Nombre = (string)datos.Lector["Nombre"];
                    aux.Persona.Apellido = (string)datos.Lector["Apellido"];
                    aux.Persona.Dni = (string)datos.Lector["Dni"];
                    aux.Persona.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    aux.DatosContacto = new DatosContacto();
                    aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    //aux.Credencial = new Credencial();
                    //aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    //aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    //aux.Permiso = new Permiso();
                    //aux.Permiso.Id = (int)datos.Lector["Permiso.Id"];
                    //aux.Permiso.Descripcion = (string)datos.Lector["Permiso.Nombre"];

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


    }
}