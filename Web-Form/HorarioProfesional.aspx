<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HorarioProfesional.aspx.cs" Inherits="Web_Form.HorarioProfesional" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-4 mt-4">
            <div class="col-2">
                <h4>Horarios</h4>
            </div>
            <div class="col-8 d-flex align-items-center ">
                <asp:Label ID="lblFiltroHorarios" runat="server" Text="Filtrar: "></asp:Label>
                <asp:TextBox ID="txtFiltroRapidoHorarios" CssClass="form-control mx-3" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoHorarios_TextChanged"></asp:TextBox>
            </div>
            <div class="d-flex col-2">
                <asp:Button Text="Nuevo Horario" CssClass="btn btn-dark" ID="btnNuevoHorario" runat="server" OnClick="btnNuevoHorario_Click" />
                <asp:Button Text="Regresar" runat="server" CssClass="btn btn-danger ms-2" ID="btnRegresar" OnClick="btnRegresar_Click"/>
            </div>
        </div>
        <div class="d-flex flex-column">
            <div>
                <label>Profesional: </label>
                <asp:Label ID="lblNombreApellido" Text="" runat="server" />
            </div>
            <div>
                <label>Especialidades:</label>
                <asp:Label ID="lblEspecialidades" Text="" runat="server" />
            </div>
            <div>
                <label>Matricula:</label>
                <asp:Label ID="lblMatricula" Text="" runat="server" />
            </div>
        </div>

        <div class="row mt-2">
            <asp:GridView ID="dgvHorarios" CssClass="table table-striped table-hover" runat="server" 
                AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvHorarios_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Dia" HeaderText="Dia" />
                    <asp:BoundField DataField="HorarioInicio" HeaderText="Hora Desde" />
                    <asp:BoundField DataField="HorarioFin" HeaderText="Hora Hasta" />
                    <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
