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
                cargarEspecialidades();
            }
        }

        protected void ddlEsp_SelectedIndexChanged1(object sender, EventArgs e)
        {
            int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);

            cargarProfesionales(idEspecialidad);
        }
        protected void ddlProfesional_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);

            cargarDias(idProfesional);
        }




        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();
            List<Horario> horarios = horarioNegocio.ListaHorarios();
            List<DiasSemana> dias = diaSemanaNegocio.Listar();
            List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, Convert.ToInt32(ddlProfesional.SelectedValue));
            List<DiasSemana> listaFiltrada = TurnoHelper.devolverDiasDeAtencion(dias, horarios);

            ddlDias.DataSource = listaFiltrada;
            ddlDias.DataTextField = "Dia";
            ddlDias.DataValueField = "Id";
            ddlDias.DataBind();

        }

        protected void cargarEspecialidades()
        {
            EspecialidadNegocio especialidadNegocio = new EspecialidadNegocio();
            List<Especialidad> especialidades = especialidadNegocio.ListaEspecialidades();

            ddlEsp.DataSource = especialidades;
            ddlEsp.DataTextField = "Nombre";
            ddlEsp.DataValueField = "Id";
            ddlEsp.DataBind();

            if (ddlEsp.SelectedIndex != 0)
            {
                int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);
                cargarProfesionales(idEspecialidad);
            }
            else
            {
                ddlProfesional.Items.Clear();
                ddlDias.Items.Clear();
            }
        }

        protected void cargarProfesionales(int idEspecialidad)
        {
            ddlProfesional.DataSource = buscarProfesionales(idEspecialidad);
            ddlProfesional.DataTextField = "Apellido";
            ddlProfesional.DataValueField = "IdProfesional";
            ddlProfesional.DataBind();

            if (ddlProfesional.SelectedIndex != 0)
            {
                int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
                cargarDias(idProfesional);
            }
            else
            {
                ddlDias.Items.Clear();
            }
        }

        protected void cargarDias(int idProfesional)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();

            List<Horario> horarios = horarioNegocio.ListaHorarios().FindAll(x => x.Profesional.IdProfesional == idProfesional);
            List<DiasSemana> dias = diaSemanaNegocio.Listar();

            //List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, idProfesional);
            List<DiasSemana> listaFiltrada = TurnoHelper.devolverDiasDeAtencion(dias, horarios);

            ddlDias.DataSource = listaFiltrada;
            ddlDias.DataTextField = "Dia";
            ddlDias.DataValueField = "Id";
            ddlDias.DataBind();
        }


        protected List<Profesional> buscarProfesionales(int idEspecialidad)
        {
            ProfesionalNegocio profesionalNegocio = new ProfesionalNegocio();
            HorarioNegocio horarioNegocio = new HorarioNegocio();

            List<Horario> horarios = horarioNegocio.ListaHorarios().FindAll(x => x.Especialidad.Id == idEspecialidad);
            List<Profesional> profesionales = profesionalNegocio.ListaProfesionales();
            List<Profesional> lista = TurnoHelper.obtenerProfesionales(horarios, profesionales);

            return lista;
        }
    }
}






//    protected void ddlProfesional_SelectedIndexChanged(object sender, EventArgs e)
//    {


//    }

//    protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
//    {

//        HorarioNegocio horarioNegocio = new HorarioNegocio();
//        List<Horario> horarios = horarioNegocio.ListaHorarios();

//        List<Horario> horarioFiltrado = horarios.FindAll(x => x.Especialidad.Id == Convert.ToInt32(ddlEsp.SelectedValue));
//        List<Horario> horarioFiltrado2 = horarioFiltrado.FindAll(x => x.Profesional.IdProfesional == Convert.ToInt32(ddlProfesional.SelectedValue));
//        List<Horario> horarioFiltrado3 = horarioFiltrado2.FindAll(x => x.IdDia == Convert.ToInt32(ddlDias.SelectedValue));

//        List<int> horariosDropDown = TurnoHelper.ObtenerHorariosDisponibles(horarioFiltrado3[0].HorarioInicio, horarioFiltrado3[0].HorarioFin);

//        Ddlhoras.DataSource = horariosDropDown;
//        Ddlhoras.DataBind();

//    }

//    protected void Unnamed_Click(object sender, EventArgs e)
//    {

//    }

//    protected void buscaTurno_Click(object sender, EventArgs e)
//    {
//        TurnoAsignadoNegocio turnoAsignadoNegocio = new TurnoAsignadoNegocio();
//        List<TurnoAsignado> turnosAsignados = turnoAsignadoNegocio.turnoAsignados(Convert.ToInt32(ddlDias.SelectedValue), Convert.ToInt32(ddlEsp.SelectedValue), Convert.ToInt32(ddlProfesional.SelectedValue));

//        DateTime fechaElegida = TurnoHelper.obtenerFecha(Convert.ToInt32(ddlDias.SelectedValue), Convert.ToInt32(Ddlhoras));

//        if(turnosAsignados.Count == 0)
//        {

//        }

//    }

//    protected void Ddlhoras_SelectedIndexChanged(object sender, EventArgs e)
//    {


//    }

//    protected void ddlHoras2_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        HorarioNegocio horarioNegocio = new HorarioNegocio();
//        DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();
//        List<Horario> horarios = horarioNegocio.ListaHorarios();
//        List<DiasSemana> dias = diaSemanaNegocio.Listar();
//        //List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, Convert.ToInt32(ddlProfesional.SelectedValue));
//        List<DiasSemana> listaFiltrada = TurnoHelper.devolverDiasDeAtencion(dias, horarios);

//        ddlDias.DataSource = listaFiltrada;
//        ddlDias.DataTextField = "Dia";
//        ddlDias.DataValueField = "Id";
//        ddlDias.DataBind();
//    }

//    protected void ddlProfesional2_SelectedIndexChanged(object sender, EventArgs e)
//    {
//        HorarioNegocio horarioNegocio = new HorarioNegocio();
//        DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();
//        List<Horario> horarios = horarioNegocio.ListaHorarios();
//        List<DiasSemana> dias = diaSemanaNegocio.Listar();
//        //List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, Convert.ToInt32(ddlProfesional.SelectedValue));
//        List<DiasSemana> listaFiltrada = TurnoHelper.devolverDiasDeAtencion(dias, horarios);

//        ddlDias.DataSource = listaFiltrada;
//        ddlDias.DataTextField = "Dia";
//        ddlDias.DataValueField = "Id";
//        ddlDias.DataBind();

//    }
