using Dominio;
using Helpers;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_Form
{
    public partial class AltaTurno : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
                List<Especialidad> especialidades = especialidadNegocio.ListaEspecialidades();

                ddlEsp.DataSource = especialidades;
                ddlEsp.DataTextField = "Nombre";
                ddlEsp.DataValueField = "Id";
                ddlEsp.DataBind();
            }
        }

        protected void ddlEsp_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            List<Horario> horarios = horarioNegocio.ListaHorarios();
            List<Profesional> profesionales = TurnoHelper.obtenerProfesionales(horarios, Convert.ToInt32(ddlEsp.SelectedValue));


            ddlProfesional.DataSource = profesionales;
            ddlProfesional.DataTextField = "Apellido";
            ddlProfesional.DataValueField = "IdProfesional";
            ddlProfesional.DataBind();
        }

        protected void ddlProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {

            HorarioNegocio horarioNegocio = new HorarioNegocio();
            List<Horario> horarios = horarioNegocio.ListaHorarios();
            List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, Convert.ToInt32(ddlProfesional.SelectedValue));

            ddlDias.DataSource = diasDisponibles;
            ddlDias.DataTextField = "Dias";
            ddlDias.DataValueField = "IdHorario";
            ddlDias.DataBind();
        }

        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {

            HorarioNegocio horarioNegocio = new HorarioNegocio();
            List<Horario> horarios = horarioNegocio.ListaHorarios();

            List<Horario> horarioFiltrado = horarios.FindAll(x => x.Especialidad.Id == Convert.ToInt32(ddlEsp.SelectedValue));
            List<Horario> horarioFiltrado2 = horarioFiltrado.FindAll(x => x.Profesional.IdProfesional == Convert.ToInt32(ddlProfesional.SelectedValue));
            List<Horario> horarioFiltrado3 = horarioFiltrado2.FindAll(x => x.IdDia == Convert.ToInt32(ddlDias.SelectedValue));

            List<int> horariosDropDown = TurnoHelper.ObtenerHorariosDisponibles(horarioFiltrado3[0].HorarioInicio, horarioFiltrado3[0].HorarioFin);

            Ddlhoras.DataSource = horariosDropDown;
            Ddlhoras.DataBind();

        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void buscaTurno_Click(object sender, EventArgs e)
        {
            TurnoAsignadoNegocio turnoAsignadoNegocio = new TurnoAsignadoNegocio();
            List<TurnoAsignado> turnosAsignados = turnoAsignadoNegocio.turnoAsignados(Convert.ToInt32(ddlDias.SelectedValue), Convert.ToInt32(ddlEsp.SelectedValue), Convert.ToInt32(ddlProfesional.SelectedValue));

            DateTime fechaElegida = TurnoHelper.obtenerFecha(Convert.ToInt32(ddlDias.SelectedValue), Convert.ToInt32(Ddlhoras));

            if(turnosAsignados.Count == 0)
            {
                
            }

        }

        protected void Ddlhoras_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
    }
}