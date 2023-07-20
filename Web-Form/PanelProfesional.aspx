<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelProfesional.aspx.cs" Inherits="Web_Form.PanelProfesional" %>

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

                            <asp:Button Text="Horarios" runat="server" CssClass="btn btn-dark btn-radio btn-lg" ID="btnHorarios" OnClick="btnHorarios_Click" />
                            <asp:CheckBox ID="chkHorarios" runat="server" Text="Horarios" AutoPostBack="true" OnCheckedChanged="chkHorarios_CheckedChanged" />
                        </div>
                    </div>
                    <hr>
                    <div class="d-grid mt-3">
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
                    <asp:TextBox ID="txtFiltroRapidoPaciente" CssClass="form-control mx-3" runat="server" AutoPostBack="true" 
                        OnTextChanged="txtFiltroRapidoPacientes_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                </div>
            </div>
            <div class="row mt-5">
                <%--Seccion Grilla de pacientes--%>
                <asp:GridView ID="dgvPacientes" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false"  
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvPacientes_SelectedIndexChanged">
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
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Nuevo turno" />
                    </Columns>
                </asp:GridView>
            </div>
            <%} %>

            <%if (chkHorarios.Checked)
                { %>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Mis horarios</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroHorarios" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoHorarios" CssClass="form-control mx-3" runat="server" AutoPostBack="true" 
                        OnTextChanged="txtFiltroRapidoHorarios_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="HorarioProfesional.aspx" class="btn btn-dark ">Nuevo Horario</a>
                </div>
            </div>

            <div class="row mt-5">
                <%--Seccion Grilla de horarios--%>
                <asp:GridView ID="dgvHorarios" CssClass="table table-striped table-hover" runat="server"
                    AutoGenerateColumns="false"  DataKeyNames="Id" OnSelectedIndexChanged="dgvHorarios_SelectedIndexChanged">
                    <Columns>
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
