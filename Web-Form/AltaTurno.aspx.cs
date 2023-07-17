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
            int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);

            cargarDias(idProfesional, idEspecialidad);
        }


        protected void ddlDias_SelectedIndexChanged(object sender, EventArgs e)
        {

            int idDia = Convert.ToInt32(ddlDias.SelectedValue);
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);

            cargarHoras(idDia, idProfesional, idEspecialidad);

        }


        protected void ddlHoras_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idHora = Convert.ToInt32(ddlHoras.SelectedValue);
            int idDia = Convert.ToInt32(ddlDias.SelectedValue);
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);

            cargarOpciones(idHora, idDia, idProfesional, idEspecialidad);
        }
        protected void ddlOpciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idOpcion = Convert.ToInt32(ddlOpciones.SelectedValue);
            int idDia = Convert.ToInt32(ddlDias.SelectedValue);
            int idProfesional = Convert.ToInt32(ddlProfesional.SelectedValue);
            int idEspecialidad = Convert.ToInt32(ddlEsp.SelectedValue);

            
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
                cargarDias(idProfesional, idEspecialidad);
            }
            else
            {
                ddlDias.Items.Clear();
            }
        }

        protected void cargarDias(int idProfesional, int idEspecialidad)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();

            List<Horario> horarios = horarioNegocio.ListaHorarios().FindAll(x => x.Profesional.IdProfesional == idProfesional && x.Especialidad.Id == idEspecialidad);
            List<DiasSemana> dias = diaSemanaNegocio.Listar();

            //List<Horario> diasDisponibles = TurnoHelper.obtenerDiasDisponibles(horarios, idProfesional);
            List<DiasSemana> listaFiltrada = TurnoHelper.devolverDiasDeAtencion(dias, horarios);

            ddlDias.DataSource = listaFiltrada;
            ddlDias.DataTextField = "Dia";
            ddlDias.DataValueField = "Id";
            ddlDias.DataBind();

            if(ddlHoras.SelectedIndex != 0)
            {
                int idDia = Convert.ToInt32(ddlDias.SelectedValue);
                cargarHoras(idDia, idProfesional, idEspecialidad);
            }
            else
            {
                ddlHoras.Items.Clear();
            }
        }

        protected void cargarHoras(int idDia, int idProfesional, int idEspecialidad)
        {

            ddlHoras.DataSource = listarHorasAMostrar(idDia, idProfesional, idEspecialidad);
            ddlHoras.DataTextField = "descripcion";
            ddlHoras.DataValueField = "idSeleccionado";
            ddlHoras.DataBind();

            if(ddlHoras.SelectedIndex != 0)
            {
                int horaSeleccionada = Convert.ToInt32(ddlHoras.SelectedValue);

                cargarOpciones(horaSeleccionada, idDia, idProfesional, idEspecialidad);
            }
            else
            {
                ddlOpciones.Items.Clear();
            }
        }

        protected void cargarOpciones(int horaSeleccionada, int idDia, int idProfesional, int idEspecialidad)
        {
            int cantidadDeTurnos = 3;
            int horaAux = horaSeleccionada;
            TurnoAsignadoNegocio turnoAsignadoNegocio = new TurnoAsignadoNegocio();
            List<MostrarOpciones> opciones = new List<MostrarOpciones>();


            for (int i = 0; i < cantidadDeTurnos; i++)
            {
                int respuesta = turnoAsignadoNegocio.verificarDisponibilidad(TurnoHelper.obtenerFecha(horaAux, idDia));

                if (respuesta == 1)
                {   DateTime fecha = TurnoHelper.obtenerFecha(horaAux, idDia);
                    opciones.Add(new MostrarOpciones(i + 1, "Turno disponible para el " + fecha.ToString("dd/MM HH:mm"), fecha));
                                        
                }
            }

            ddlOpciones.DataSource = opciones;
            ddlOpciones.DataTextField = "descripcion";
            ddlOpciones.DataValueField = "id";
            ddlOpciones.DataBind();

            if (ddlOpciones.SelectedIndex != 0)
            {
                int idOpcion = Convert.ToInt32(ddlOpciones.SelectedValue);
            }
            else
            {
              
            }
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

        protected List<MostrarHorario> listarHorasAMostrar(int idDia, int idProfesional, int idEspecialidad)
        {
            HorarioNegocio horarioNegocio = new HorarioNegocio();
            DiaSemanaNegocio diaSemanaNegocio = new DiaSemanaNegocio();
            List<Horario> horarios = horarioNegocio.ListaHorarios().FindAll(h => h.IdDia == idDia && h.Profesional.IdProfesional == idProfesional && h.Especialidad.Id == idEspecialidad);

            List<MostrarHorario> lista = TurnoHelper.ObtenerHorariosDisponibles(horarios);

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
