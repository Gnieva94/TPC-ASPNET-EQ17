<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelPaciente.aspx.cs" Inherits="Web_Form.PanelPaciente" %>
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
             <%--<%if (chkTurnos.Checked)
                { %>--%>
            <div class="row mb-4 mt-4">
                <%--Seccion Buscador y filtro--%>
                <div class="col-2">
                    <h4>Mis Turnos</h4>
                </div>
                <div class="col-8 d-flex align-items-center ">
                    <asp:Label ID="lblFiltroHorarios" runat="server" Text="Filtrar: "></asp:Label>
                    <asp:TextBox ID="txtFiltroRapidoTurnos" CssClass="form-control mx-3" runat="server" AutoPostBack="true" 
                        OnTextChanged="txtFiltroRapidoTurnos_TextChanged"></asp:TextBox>
                </div>
                <div class=" col-2">
                    <a href="AltaTurno.aspx" class="btn btn-dark ">Nuevo Turno</a>
                </div>

            </div>

            <div class="row mt-5">
                <%--Seccion Grilla de horarios--%>
                <asp:GridView ID="dgvTurnos" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="false" 
                    DataKeyNames="Id" OnSelectedIndexChanged="dgvTurnos_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID Horario" />
                        <asp:BoundField DataField="IdProfesional" HeaderText="ID Profesional" />
                            
                         <%--<asp:BoundField DataField="Profesional.Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Profesional.Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />--%>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="IdEstado" HeaderText="Estado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Cancelar" />

                    </Columns>
                </asp:GridView>

            </div>
            <%--<%} %>--%>
        </div>
    </div>
</asp:Content>
