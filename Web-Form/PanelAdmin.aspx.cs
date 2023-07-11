﻿using System;
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
                        PacienteNegocio negocioPas = new PacienteNegocio();
                        dgvPacientes.DataSource = negocioPas.ListaPacientes();
                        dgvPacientes.DataBind();
                    //}

                    ProfesionalNegocio negocioProf = new ProfesionalNegocio();
                    dgvProfesionales.DataSource = negocioProf.ListaProfesionales();
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