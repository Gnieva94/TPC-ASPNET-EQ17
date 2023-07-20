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
    public partial class FormularioHorario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                ddlEspecialidad.DataSource = especialidadNegocio.ListaEspecialidades();
                ddlEspecialidad.DataTextField = "Nombre";
                ddlEspecialidad.DataValueField = "Id";
                ddlEspecialidad.DataBind();
                
                if (Request.QueryString["id"] != null)
                {
                    List<Horario> listaHorarios = (List<Horario>)Session["ListaHorarioProfesional"];
                    Horario horario = listaHorarios.Find(x => x.Id == int.Parse(Request.QueryString["id"].ToString()));
                    Session.Add("HorarioProfesionalModificar", horario);
                    ddlEspecialidad.SelectedValue = horario.Especialidad.Id.ToString();
                    ddlDia.SelectedValue = horario.IdDia.ToString();
                    ddlHorarioInicio.SelectedValue = horario.HorarioInicio.ToString();
                    ddlHorarioFin.SelectedValue = horario.HorarioFin.ToString();
                    btnHorario.Text = "Modificar";
                }
                else
                {
                    btnHorario.Text = "Crear";
                }
            }
        }
        protected void btnHorario_Click(object sender, EventArgs e)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            Horario horario;



            if (Request.QueryString["id"] != null)
            {
                horario = (Horario)Session["HorarioProfesionalModificar"];
                horario.Especialidad.Id = ddlEspecialidad.SelectedIndex + 1;
                horario.IdDia = int.Parse(ddlDia.SelectedValue);
                horario.HorarioInicio = int.Parse(ddlHorarioInicio.SelectedValue);
                horario.HorarioFin = int.Parse(ddlHorarioFin.SelectedValue);
                horarioNegocio.ModificarHorario(horario);
                Response.Redirect("HorarioProfesional.aspx?id=" + Session["idHorarioProfesionalUrl"].ToString(), false);
            }
            else
            {
                horario = new Horario();
                horario.Especialidad.Id = ddlEspecialidad.SelectedIndex + 1;
                horario.IdDia = int.Parse(ddlDia.SelectedValue);
                horario.HorarioInicio = int.Parse(ddlHorarioInicio.SelectedValue);
                horario.HorarioFin = int.Parse(ddlHorarioFin.SelectedValue);
                horarioNegocio.AgregarHorarios(horario, int.Parse(Session["idHorarioProfesionalUrl"].ToString()));
                Response.Redirect("HorarioProfesional.aspx?id=" + Session["idHorarioProfesionalUrl"].ToString(), false);
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HorarioProfesional.aspx?id=" + Session["idHorarioProfesionalUrl"].ToString(),false);
        }
    }
}