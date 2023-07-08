using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helpers;
using Negocio;

namespace Web_Form
{
    public partial class Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    //if (Seguridad.SesionActiva(Session["Persona"]))
                    //{
                        PacienteNegocio negocio = new PacienteNegocio();
                        dgvPacientes.DataSource = negocio.ListaPacientes();
                        dgvPacientes.DataBind();
                    //}

                    ProfesionalNegocio negocio = new ProfesionalNegocio();
                    dgvProfesionales.DataSource = negocio.ListaProfesionales();
                    dgvProfesionales.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.ToString());
            }
        }
    }
}