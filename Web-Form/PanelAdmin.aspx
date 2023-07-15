<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="Web_Form.PanelAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .btn-radio {
            position: relative;
        }

            .btn-radio.active:before {
                content: '';
                position: absolute;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                border: 2px solid #007bff;
                border-radius: 50%;
                box-sizing: border-box;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row h-100">
        <div class="col-2 h-100">
            <div class="h-100">
                <%--Seccion de botones de navegacion--%>
                <div class="d-flex flex-column flex-shrink-0 p-3 text-bg-dark h-100">

                    <span class="fs-4">Bienvenido!</span>
                    <%--Label con el nombre del usuario logueado--%>
                    <asp:Label Text="" ID="lblUsuarioLogueado" runat="server" />

                    <hr>
                    <div class="d-grid gap-3">
                        <asp:Button Text="Pacientes" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnPacientes" OnClick="btnPacientes_Click" />
                        <asp:CheckBox ID="chkPacientes" runat="server" AutoPostBack="true" OnCheckedChanged="chkPacientes_CheckedChanged" />

                        <asp:Button Text="Profesionales" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnProfesionales" OnClick="btnProfesionales_Click" />
                        <asp:CheckBox ID="chkProfesionales" runat="server" Text="Profesionales" AutoPostBack="true" OnCheckedChanged="chkProfesionales_CheckedChanged" />

                        <asp:Button Text="Empleados" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnEmpleados" OnClick="btnEmpleados_Click" />
                        <asp:CheckBox ID="chkEmpleados" runat="server" Text="Empleados" AutoPostBack="true" OnCheckedChanged="chkEmpleados_CheckedChanged" />

                        <asp:Button Text="Especialidades" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnEspecialidades" OnClick="btnEspecialidades_Click" />
                        <asp:CheckBox ID="chkEspecialidades" runat="server" Text="Especialidades" AutoPostBack="true" OnCheckedChanged="chkEspecialidades_CheckedChanged" />

                        <asp:Button Text="Obras Sociales" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnObrasSociales" OnClick="btnObrasSociales_Click" />
                        <asp:CheckBox ID="chkObrasSociales" runat="server" Text="Obra Social" AutoPostBack="true" OnCheckedChanged="chkObrasSociales_CheckedChanged" />

                        <asp:Button Text="Horarios" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnHorarios" OnClick="btnHorarios_Click" />
                        <asp:CheckBox ID="chkHorarios" runat="server" Text="Horarios" AutoPostBack="true" OnCheckedChanged="chkHorarios_CheckedChanged" />

                        <asp:Button Text="Turnos" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnTurnos" OnClick="btnTurnos_Click" />
                        <asp:CheckBox ID="chkTurnos" runat="server" Text="Turnos" AutoPostBack="true" OnCheckedChanged="chkTurnos_CheckedChanged" />
                    </div>

                    <hr>
                    <div class="d-grid">
                        <asp:Button ID="btnLogout" runat="server" Text="Salir" CssClass="btn btn-outline-light" type="button" aria-expanded="false" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-10">
            <%if (chkPacientes.Checked)
                { %>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Pacientes</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroPas" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoPaciente" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoPacientes_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="AltaUsuario.aspx?Per=4" class="btn btn-dark ">Nuevo Paciente</a>
                </div>
            </div>
            <div class="row mt-5">
                <%--Seccion Grilla de pacientes--%>
                <asp:GridView ID="dgvPacientes" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false" DataKeyNames="IdPaciente" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged1"
                    >
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="ObraSocial.Nombre" HeaderText="Obra Social" />
                        <asp:BoundField DataField="NumeroAfiliado" HeaderText="Nro Afiliado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <%} %>

            <%if (chkProfesionales.Checked)
                { %>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Profesionales</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroProf" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoProfesionales" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoProfesionales_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="AltaUsuario.aspx?Per=3" class="btn btn-dark ">Nuevo Profesional</a>
                </div>

            </div>
            <div class="row mt-5">
                <%--Seccion Grilla de profesionales--%>
                <asp:GridView ID="dgvProfesionales" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <%} %>

            <%if (chkEmpleados.Checked)
                { %>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Empleados</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroEmp" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoEmpleados" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoEmpleados_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2" >
                    <a href="AltaUsuario.aspx?Per=2" class="btn btn-dark ">Nuevo Empleado</a>
                    <a href="AltaUsuario.aspx?Per=1" class="btn btn-dark mt-2">Nuevo Admin</a>
                </div>

            </div>

            <div class="row mt-5">
                <%--Seccion Grilla de empleados--%>
                <asp:GridView ID="dgvEmpleados" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Permiso.Descripcion" HeaderText="Permiso" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>

            </div>
            <%} %>


            <%if (chkEspecialidades.Checked)
                { %>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Especialidades</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroEsp" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoEspecialidades" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoEspecialidades_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="AltaEspecialidad.aspx" class="btn btn-dark ">Nueva Especialidad</a>
                </div>

            </div>

            <div class="row mt-5">
                <%--Seccion Grilla de especialidades--%>
                <asp:GridView ID="dgvEspecialidades" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Especialidad" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>

            </div>
            <%} %>

            <%if (chkObrasSociales.Checked)
                { %>
           <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Obras Sociales</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroOS" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoObrasSociales" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoObrasSociales_TextChanged"  ></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="AltaObraSocial.aspx" class="btn btn-dark ">Nueva Obra Social</a>
                </div>

            </div>

            <div class="row mt-5">
                <%--Seccion Grilla de obras sociales--%>
                <asp:GridView ID="dgvObrasSociales" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="IdObraSocial" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Obra Social" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>

            </div>
            <%} %>

            <%if (chkHorarios.Checked)
                { %>
                      <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Horarios</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroHorarios" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoHorarios" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoHorarios_TextChanged" ></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="#" class="btn btn-dark ">Nuevo Horario</a>
                </div>

            </div>
    
            <div class="row mt-5">
                <%--Seccion Grilla de horarios--%>
                <asp:GridView ID="dgvHorarios" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID Horario" />
                        <asp:BoundField DataField="Profesional.Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Profesional.Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                        <asp:BoundField DataField="Dia" HeaderText="Dia" />
                        <asp:BoundField DataField="HorarioInicio" HeaderText="Hora Desde" />
                        <asp:BoundField DataField="HorarioFin" HeaderText="Hora Hasta" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>

            </div>
            <%} %>
        </div>
    </div>

</asp:Content>
