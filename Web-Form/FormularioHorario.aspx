<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioHorario.aspx.cs" Inherits="Web_Form.FormularioHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center">
        <div class="d-flex flex-column col-3">
            <label for="ddlEspecialidad" class="form-label">Especialidad:</label>
            <asp:DropDownList runat="server" ID="ddlEspecialidad" class="btn btn-secondary dropdown-toggle" TabIndex="15">
            </asp:DropDownList>
            <label for="ddlDia" class="form-label">Dia: </label>
            <asp:DropDownList runat="server" ID="ddlDia" CssClass="btn btn-secondary dropdown-toggle" TabIndex="16">
                <asp:ListItem Text="Lunes" Value="1" />
                <asp:ListItem Text="Martes" Value="2" />
                <asp:ListItem Text="Miercoles" Value="3" />
                <asp:ListItem Text="Jueves" Value="4" />
                <asp:ListItem Text="Viernes" Value="5" />
                <asp:ListItem Text="Sabado" Value="6" />
                <asp:ListItem Text="Domingo" Value="7" />
            </asp:DropDownList>
            <label for="" class="form-label">Rango horario: </label>
            <asp:DropDownList runat="server" ID="ddlHorarioInicio" class="btn btn-secondary dropdown-toggle" TabIndex="17">
                <asp:ListItem Text="00" Value="00" />
                <asp:ListItem Text="01" Value="01" />
                <asp:ListItem Text="02" Value="02" />
                <asp:ListItem Text="03" Value="03" />
                <asp:ListItem Text="04" Value="04" />
                <asp:ListItem Text="05" Value="05" />
                <asp:ListItem Text="06" Value="06" />
                <asp:ListItem Text="07" Value="07" />
                <asp:ListItem Text="08" Value="08" />
                <asp:ListItem Text="09" Value="09" />
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="11" Value="11" />
                <asp:ListItem Text="12" Value="12" />
                <asp:ListItem Text="13" Value="13" />
                <asp:ListItem Text="14" Value="14" />
                <asp:ListItem Text="15" Value="15" />
                <asp:ListItem Text="16" Value="16" />
                <asp:ListItem Text="17" Value="17" />
                <asp:ListItem Text="18" Value="18" />
                <asp:ListItem Text="19" Value="19" />
                <asp:ListItem Text="20" Value="20" />
                <asp:ListItem Text="21" Value="21" />
                <asp:ListItem Text="22" Value="22" />
                <asp:ListItem Text="23" Value="23" />
            </asp:DropDownList>
            <label>a </label>
            <asp:DropDownList runat="server" ID="ddlHorarioFin" class="btn btn-secondary dropdown-toggle" TabIndex="18">
                <asp:ListItem Text="00" Value="00" />
                <asp:ListItem Text="01" Value="01" />
                <asp:ListItem Text="02" Value="02" />
                <asp:ListItem Text="03" Value="03" />
                <asp:ListItem Text="04" Value="04" />
                <asp:ListItem Text="05" Value="05" />
                <asp:ListItem Text="06" Value="06" />
                <asp:ListItem Text="07" Value="07" />
                <asp:ListItem Text="08" Value="08" />
                <asp:ListItem Text="09" Value="09" />
                <asp:ListItem Text="10" Value="10" />
                <asp:ListItem Text="11" Value="11" />
                <asp:ListItem Text="12" Value="12" />
                <asp:ListItem Text="13" Value="13" />
                <asp:ListItem Text="14" Value="14" />
                <asp:ListItem Text="15" Value="15" />
                <asp:ListItem Text="16" Value="16" />
                <asp:ListItem Text="17" Value="17" />
                <asp:ListItem Text="18" Value="18" />
                <asp:ListItem Text="19" Value="19" />
                <asp:ListItem Text="20" Value="20" />
                <asp:ListItem Text="21" Value="21" />
                <asp:ListItem Text="22" Value="22" />
                <asp:ListItem Text="23" Value="23" />
            </asp:DropDownList>
            <br />
            <div>
                <asp:Button Text="" runat="server" ID="btnHorario" class="btn btn-primary" OnClick="btnHorario_Click" TabIndex="19" />
                <asp:Button Text="Regresar" runat="server" CssClass="btn btn-danger" ID="btnRegresar" OnClick="btnRegresar_Click"/>
            </div>
        </div>
<%--        <div class="d-flex flex-column">
            <asp:GridView runat="server" ID="dgvListaHorarios" DataKeyNames="Id" CssClass="table table-striped table-hover table-sm" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaHorarios_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                    <asp:BoundField DataField="Dia" HeaderText="Dia" />
                    <asp:BoundField DataField="HorarioInicio" HeaderText="Inicio" />
                    <asp:BoundField DataField="HorarioFin" HeaderText="Fin" />
                    <asp:CommandField ShowSelectButton="true" HeaderText="" SelectText="Eliminar" />

                </Columns>
            </asp:GridView>
        </div>--%>
    </div>
</asp:Content>
