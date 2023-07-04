using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Web_Form
{
    public partial class Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PacienteNegocio negocio = new PacienteNegocio();
            dgvPacientes.DataSource = negocio.ListaPacientes();
            dgvPacientes.DataBind();
        }
    }
}