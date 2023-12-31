﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Helpers;
using Negocio;

namespace Web_Form
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        public int TipoUser { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null && Request.QueryString["per"] != null)
                TipoUser = int.Parse(Request.QueryString["per"]);
            if (!IsPostBack)
            {
                if (TipoUser == 4)
                {
                    ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                    ddlObraSocial.DataSource = obraSocialNegocio.ListaObrasSociales();
                    ddlObraSocial.DataTextField = "Nombre";
                    ddlObraSocial.DataValueField = "IdObraSocial";
                    ddlObraSocial.DataBind();

                    Paciente paciente;
                    PacienteNegocio negocio = new PacienteNegocio();
                    paciente = negocio.traerRegistroPorId(int.Parse(Request.QueryString["id"].ToString()));
                    Session.Add("ModificarPaciente", paciente);

                    if (paciente != null)
                    {
                        cargarCampos(paciente);
                        ddlObraSocial.SelectedValue = paciente.ObraSocial.IdObraSocial.ToString();
                        txbNumeroAfiliado.Text = paciente.NumeroAfiliado.ToString();
                    }
                    else
                    {
                        Session.Add("Error", "No se encontro el paciente");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                if (TipoUser == 3)
                {
                    Profesional profesional;
                    ProfesionalNegocio negocio = new ProfesionalNegocio();
                    profesional = negocio.traerRegistroPorId(int.Parse(Request.QueryString["id"].ToString()));
                    Session.Add("ModificarProfesional", profesional);

                    if (profesional != null)
                    {
                        cargarCampos(profesional);
                        txbMatricula.Text = profesional.Matricula.ToString();
                    }
                    else
                    {
                        Session.Add("Error", "No se encontro el profesional");
                        Response.Redirect("Error.aspx", false);
                    }
                }
                if (TipoUser == 2 || TipoUser == 1)
                {
                    Empleado empleado;
                    EmpleadoNegocio negocio = new EmpleadoNegocio();
                    empleado = negocio.traerRegistroPorId(int.Parse(Request.QueryString["id"].ToString()));
                    Session.Add("ModificarEmpleado", empleado);

                    if (empleado != null)
                    {
                        cargarCampos(empleado);
                        txtPermiso.Text = empleado.Permiso.Id.ToString();
                    }
                    else
                    {
                        Session.Add("Error", "No se encontro el empleado");
                        Response.Redirect("Error.aspx", false);
                    }
                }
            }
        }

        private void cargarCampos(Persona persona)
        {
            try
            {
                txbNombre.Text = persona.Nombre;
                txbApellido.Text = persona.Apellido;
                txbDNI.Text = persona.Dni;
                txbFechaNacimiento.Text = persona.FechaNacimiento.ToString("yyyy-MM-dd");
                ddlNacionalidad.SelectedValue = persona.Nacionalidad;
                txbCelu.Text = persona.DatosContacto.Celular;
                txbDireccion.Text = persona.DatosContacto.Direccion;
                txbLocalidad.Text = persona.DatosContacto.Localidad;
                txbProvincia.Text = persona.DatosContacto.Provincia;
                txbCodigoPostal.Text = persona.DatosContacto.CodigoPostal;
            }
            catch (Exception ex)
            {
                ex.ToString();
                Session.Add("Error", "Error al cargar campos.");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if(TipoUser == 4)
                {
                    Paciente paciente = (Paciente)Session["ModificarPaciente"];
                    PacienteNegocio negocio = new PacienteNegocio();
                    paciente.IdPaciente = int.Parse(Request.QueryString["id"].ToString());
                    paciente.Nombre = txbNombre.Text;
                    paciente.Apellido = txbApellido.Text;
                    paciente.Dni = txbDNI.Text;
                    paciente.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                    paciente.Nacionalidad = ddlNacionalidad.SelectedValue;
                    paciente.DatosContacto.Celular = txbCelu.Text;
                    paciente.DatosContacto.Direccion = txbDireccion.Text;
                    paciente.DatosContacto.Localidad = txbLocalidad.Text;
                    paciente.DatosContacto.Provincia = txbProvincia.Text;
                    paciente.DatosContacto.CodigoPostal = txbCodigoPostal.Text;
                    paciente.ObraSocial.IdObraSocial = int.Parse(ddlObraSocial.SelectedValue);
                    negocio.ModificarPaciente(paciente);
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
                if(TipoUser == 3)
                {
                    Profesional profesional = (Profesional)Session["ModificarProfesional"];
                    ProfesionalNegocio pro = new ProfesionalNegocio();
                    profesional.IdProfesional = int.Parse(Request.QueryString["id"].ToString());
                    profesional.Nombre = txbNombre.Text;
                    profesional.Apellido = txbApellido.Text;
                    profesional.Dni = txbDNI.Text;
                    profesional.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                    profesional.Nacionalidad = ddlNacionalidad.SelectedValue;
                    profesional.DatosContacto.Celular = txbCelu.Text;
                    profesional.DatosContacto.Direccion = txbDireccion.Text;
                    profesional.DatosContacto.Localidad = txbLocalidad.Text;
                    profesional.DatosContacto.Provincia = txbProvincia.Text;
                    profesional.DatosContacto.CodigoPostal = txbCodigoPostal.Text;
                    profesional.Matricula = txbMatricula.Text;
                    pro.ModificarProfesional(profesional);
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
                if(TipoUser ==1 || TipoUser == 2)
                {
                    Empleado empleado = (Empleado)Session["ModificarEmpleado"];
                    EmpleadoNegocio emp = new EmpleadoNegocio();
                    empleado.IdEmpleado = int.Parse(Request.QueryString["id"].ToString());
                    empleado.Nombre = txbNombre.Text;
                    empleado.Apellido = txbApellido.Text;
                    empleado.Dni = txbDNI.Text;
                    empleado.FechaNacimiento = DateTime.Parse(txbFechaNacimiento.Text);
                    empleado.Nacionalidad = ddlNacionalidad.SelectedValue;
                    empleado.DatosContacto.Celular = txbCelu.Text;
                    empleado.DatosContacto.Direccion = txbDireccion.Text;
                    empleado.DatosContacto.Localidad = txbLocalidad.Text;
                    empleado.DatosContacto.Provincia = txbProvincia.Text;
                    empleado.DatosContacto.CodigoPostal = txbCodigoPostal.Text;
                    empleado.Permiso.Id = int.Parse(txtPermiso.Text);
                    emp.ModificarEmpleado(empleado);
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void ddlObraSocial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlObraSocial.SelectedIndex == 0)
            {
                txbNumeroAfiliado.Visible = false;
                lblNroAfiliado.Visible = false;
            }
            else
            {
                txbNumeroAfiliado.Visible = true;
                lblNroAfiliado.Visible = true;
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["Per"] != null)
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                else
                    Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TipoUser == 4)
                {
                    PacienteNegocio negocio = new PacienteNegocio();
                    negocio.BajaPaciente (int.Parse(Request.QueryString["id"].ToString()));
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
                if (TipoUser == 3)
                {
                    ProfesionalNegocio pro = new ProfesionalNegocio();
                    pro.BajaProfesional(int.Parse(Request.QueryString["id"].ToString()));
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
                if (TipoUser == 1 || TipoUser == 2)
                {
                    EmpleadoNegocio emp = new EmpleadoNegocio();
                    emp.BajaEmpleado(int.Parse(Request.QueryString["id"].ToString()));
                    Response.Redirect(Seguridad.DirigirPanel(Session["Persona"]), false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}