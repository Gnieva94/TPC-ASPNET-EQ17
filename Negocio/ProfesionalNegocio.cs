﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using DataBase;
using Dominio;

namespace Negocio
{
    public class ProfesionalNegocio
    {
        public List<Profesional> ListaProfesionales()
        {
            List<Profesional> profesionales = new List<Profesional>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearSP("SP_LISTAR_PROFESIONALES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Profesional aux = new Profesional();

                    aux.IdProfesional = (int)datos.Lector["Id"];
                    aux.Id = (int)datos.Lector["Id_Persona"];
                    aux.FechaAlta = (DateTime)datos.Lector["Fecha_Alta"];
                    if (!(datos.Lector["Fecha_Baja"] is DBNull))
                        aux.FechaBaja = (DateTime)datos.Lector["Fecha_Baja"];
                    aux.Matricula = (string)datos.Lector["Matricula"];
                   
                    //aux.Nombre = (string)datos.Lector["Nombre"];
                    //aux.Apellido = (string)datos.Lector["Apellido"];
                    //aux.Dni = (string)datos.Lector["Dni"];
                    //aux.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                    //aux.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                    //aux.DatosContacto = new DatosContacto();
                    //aux.DatosContacto.Email = (string)datos.Lector["Email"];
                    //if (!(datos.Lector["Celular"] is DBNull))
                    //    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                    //if (!(datos.Lector["Telefono"] is DBNull))
                    //    aux.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                    //if (!(datos.Lector["Direccion"] is DBNull))
                    //    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                    //if (!(datos.Lector["Localidad"] is DBNull))
                    //    aux.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                    //if (!(datos.Lector["Provincia"] is DBNull))
                    //    aux.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                    //if (!(datos.Lector["Codigo_Postal"] is DBNull))
                    //    aux.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                    //aux.Credencial = new Credencial();
                    //aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                    //aux.Credencial.Password = (string)datos.Lector["Contrasenia"];


                    profesionales.Add(aux);
                }
                return profesionales;
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

        public int AgregarProfesional(Profesional nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearSP("SP_ALTA_PROFESIONAL");
                datos.setearParametro("@Nombre",nuevo.Nombre);
                datos.setearParametro("@Apellido",nuevo.Apellido);
                datos.setearParametro("@Dni",nuevo.Dni);
                datos.setearParametro("@Fecha_Nacimiento",nuevo.FechaNacimiento);
                datos.setearParametro("@Nacionalidad",nuevo.Nacionalidad);
                datos.setearParametro("@Email",nuevo.DatosContacto.Email);
                datos.setearParametro("@Celular",(object)nuevo.DatosContacto.Celular ?? DBNull.Value);
                datos.setearParametro("@Telefono",(object)nuevo.DatosContacto.Telefono ?? DBNull.Value);
                datos.setearParametro("@Direccion",(object)nuevo.DatosContacto.Direccion ?? DBNull.Value);
                datos.setearParametro("@Localidad",(object)nuevo.DatosContacto.Localidad ?? DBNull.Value);
                datos.setearParametro("@Provincia",(object)nuevo.DatosContacto.Provincia ?? DBNull.Value);
                datos.setearParametro("@Codigo_Postal",(object)nuevo.DatosContacto.CodigoPostal ?? DBNull.Value);
                datos.setearParametro("@Nombre_Usuario",nuevo.Credencial.NombreUsuario);
                datos.setearParametro("@Contrasenia",nuevo.Credencial.Password);
                datos.setearParametro("@Matricula",nuevo.Matricula);
                return datos.ejecutarAccionScalar();

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

            public Profesional buscarUnProfesional(int idProfesional)
            {
                AccesoDatos datos = new AccesoDatos();
                Profesional profesional = new Profesional();

                try
                {
                    datos.setearSP("SP_BUSCAR_PROFESIONAL @IdProfesional");
                    datos.setearParametro("@IdProfesional", idProfesional);
                    datos.ejecutarLectura();


                    while (datos.Lector.Read())
                    {
                        Profesional aux = new Profesional();
                        aux.IdProfesional = (int)datos.Lector["Id_Profesional"];
                        aux.Id = (int)datos.Lector["Id_Persona"];
                        aux.FechaAlta = (DateTime)datos.Lector["Fecha_Alta"];
                        if (!(datos.Lector["Fecha_Baja"] is DBNull))
                            aux.FechaBaja = (DateTime)datos.Lector["Fecha_Baja"];
                        aux.Matricula = (string)datos.Lector["Matricula"];
                        //aux.Nombre = (string)datos.Lector["Nombre"];
                        //aux.Apellido = (string)datos.Lector["Apellido"];
                        //aux.Dni = (string)datos.Lector["Dni"];
                        //aux.FechaNacimiento = (DateTime)datos.Lector["Fecha_Nacimiento"];
                        //aux.Nacionalidad = (string)datos.Lector["Nacionalidad"];
                        //aux.DatosContacto = new DatosContacto();
                        //aux.DatosContacto.Email = (string)datos.Lector["Email"];
                        //if (!(datos.Lector["Celular"] is DBNull))
                        //    aux.DatosContacto.Celular = (string)datos.Lector["Celular"];
                        //if (!(datos.Lector["Telefono"] is DBNull))
                        //    aux.DatosContacto.Telefono = (string)datos.Lector["Telefono"];
                        //if (!(datos.Lector["Direccion"] is DBNull))
                        //    aux.DatosContacto.Direccion = (string)datos.Lector["Direccion"];
                        //if (!(datos.Lector["Localidad"] is DBNull))
                        //    aux.DatosContacto.Localidad = (string)datos.Lector["Localidad"];
                        //if (!(datos.Lector["Provincia"] is DBNull))
                        //    aux.DatosContacto.Provincia = (string)datos.Lector["Provincia"];
                        //if (!(datos.Lector["Codigo_Postal"] is DBNull))
                        //    aux.DatosContacto.CodigoPostal = (string)datos.Lector["Codigo_Postal"];
                        //aux.Credencial = new Credencial();
                        //aux.Credencial.NombreUsuario = (string)datos.Lector["Nombre_Usuario"];
                        //aux.Credencial.Password = (string)datos.Lector["Contrasenia"];
                    }

                    return profesional;
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

