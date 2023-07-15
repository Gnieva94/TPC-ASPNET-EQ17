using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Web_Form
{
    public partial class FormularioUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ObraSocialNegocio obraSocialNegocio = new ObraSocialNegocio();
                ddlObraSocial.DataSource = obraSocialNegocio.ListaObrasSociales();
                ddlObraSocial.DataTextField = "Nombre";
                ddlObraSocial.DataValueField = "IdObraSocial";
                ddlObraSocial.DataBind();


                if (Request.QueryString["id"] != null)
                {
                    Paciente paciente;
                    PacienteNegocio negocio = new PacienteNegocio();
                    paciente = negocio.traerRegistroPorId(int.Parse(Request.QueryString["id"].ToString()));
                    Session.Add("ModificarPaciente", paciente);

                    if (paciente != null)
                    {
                        txbNombre.Text = paciente.Nombre;
                        txbApellido.Text = paciente.Apellido;
                        txbDNI.Text = paciente.Dni;
                        txbFechaNacimiento.Text = paciente.FechaNacimiento.ToString();
                        ddlNacionalidad.SelectedValue = paciente.Nacionalidad;
                        txbCelu.Text = paciente.DatosContacto.Celular;
                        txbDireccion.Text = paciente.DatosContacto.Direccion;
                        txbLocalidad.Text = paciente.DatosContacto.Localidad;
                        txbProvincia.Text = paciente.DatosContacto.Provincia;
                        txbCodigoPostal.Text = paciente.DatosContacto.CodigoPostal;
                        txbNumeroAfiliado.Text = paciente.NumeroAfiliado.ToString();

                    }
                    else
                    {
                        Session.Add("Error", "No se encontro el paciente");
                        Response.Redirect("Error.aspx", false);
                    }

                }
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Paciente paciente = (Paciente)Session["ModificarPaciente"];
            PacienteNegocio negocio = new PacienteNegocio();
            try
            {
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
                Response.Redirect("PanelAdmin.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }


        }
    }
}