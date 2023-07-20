using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Web_Form
{
    public partial class HorarioProfesional : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int IdProfesional = int.Parse(Request.QueryString["id"].ToString());
                    Session.Add("idHorarioProfesionalUrl", IdProfesional);
                    ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
                    Profesional profesional = profesionalNegocio.traerRegistroPorId(IdProfesional);
                    profesional.IdProfesional = IdProfesional;
                    HorarioNegocio negocioHor = new HorarioNegocio();
                    List<Horario> horarios = negocioHor.BuscarHorarioPorProfesional(profesional.IdProfesional);
                    dgvHorarios.DataSource = horarios;
                    dgvHorarios.DataBind();
                    foreach (Horario h in horarios)
                    {
                        lblEspecialidades.Text += h.Especialidad.Nombre + "/";
                    }
                    lblNombreApellido.Text = profesional.Nombre + ", "+ profesional.Apellido;
                    lblMatricula.Text = profesional.Matricula;
                    Session.Add("ListaHorarioProfesional", horarios);
                }
            }
        }

        protected void btnNuevoHorario_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormularioHorario.aspx", false);
        }

        protected void dgvHorarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("FormularioHorario.aspx?id="+dgvHorarios.SelectedDataKey.Value.ToString(),false);
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PanelAdmin.aspx", false);
        }
    }
}