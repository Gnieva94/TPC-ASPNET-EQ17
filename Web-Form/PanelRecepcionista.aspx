﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelRecepcionista.aspx.cs" Inherits="Web_Form.PanelRecepcionista" %>

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
                    <div class="h-50">
                        <div class="d-grid gap-5 mb-5 mt-5">
                            <asp:Button Text="Pacientes" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnPacientes" OnClick="btnPacientes_Click" />
                            <asp:CheckBox ID="chkPacientes" runat="server" AutoPostBack="true" OnCheckedChanged="chkPacientes_CheckedChanged" />

                            <asp:Button Text="Profesionales" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnProfesionales" OnClick="btnProfesionales_Click" />
                            <asp:CheckBox ID="chkProfesionales" runat="server" Text="Profesionales" AutoPostBack="true" OnCheckedChanged="chkProfesionales_CheckedChanged" />

                            <asp:Button Text="Especialidades" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnEspecialidades" OnClick="btnEspecialidades_Click" />
                            <asp:CheckBox ID="chkEspecialidades" runat="server" Text="Especialidades" AutoPostBack="true" OnCheckedChanged="chkEspecialidades_CheckedChanged" />

                            <asp:Button Text="Obras Sociales" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnObrasSociales" OnClick="btnObrasSociales_Click" />
                            <asp:CheckBox ID="chkObrasSociales" runat="server" Text="Obra Social" AutoPostBack="true" OnCheckedChanged="chkObrasSociales_CheckedChanged" />
                        </div>
                    </div>
                    <hr>
                    <div class="d-grid mt-3">
                        <asp:Button ID="btnLogout" runat="server" Text="Salir" CssClass="btn btn-outline-light" type="button" aria-expanded="false" OnClick="btnLogout_Click" />
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
                <asp:GridView ID="dgvPacientes" CssClass="table table-striped table-hover" runat="server"
                    AutoGenerateColumns="false" DataKeyNames="IdPaciente" OnRowCommand="dgvPacientes_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="ObraSocial.Nombre" HeaderText="Obra Social" />
                        <asp:BoundField DataField="NumeroAfiliado" HeaderText="Nro Afiliado" />
                        <asp:TemplateField HeaderText="Modificar">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnModificar" Text="Modificar" CssClass="btn btn-secondary" CommandName="Modificar" CommandArgument='<%# Eval("IdPaciente") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Turno">
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnTurno" Text="Turno" CssClass="btn btn-secondary" CommandName="Turno" CommandArgument='<%# Eval("IdPaciente") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                <asp:GridView ID="dgvProfesionales" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false" OnRowCommand="dgvProfesionales_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:TemplateField HeaderText="Modificar">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Modificar"  CssClass="btn btn-secondary" CommandName="modificar" CommandArgument='<%#Eval("IdProfesional") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ver Horarios">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Horario"  CssClass="btn btn-secondary" CommandName="verHorarios" CommandArgument='<%#Eval("IdProfesional") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
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
                    <asp:TextBox ID="txtFiltroRapidoObrasSociales" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoObrasSociales_TextChanged"></asp:TextBox>
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
        </div>
    </div>
</asp:Content>
