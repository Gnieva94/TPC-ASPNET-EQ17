<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Web_Form.AltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
            <h2>Alta turno</h2>
            <div class="col-3">
                <div class="mb-3">

                    <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>

                    <asp:DropDownList runat="server" ID="ddlEsp" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEsp_SelectedIndexChanged"></asp:DropDownList>

                </div>
                <div class="mb-3">

                    <label for="txbProfesional" class="form-label">Elegir profesional:</label>
                    <asp:DropDownList runat="server" ID="ddlProfesional" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlProfesional_SelectedIndexChanged"></asp:DropDownList>
                
                </div>
                <div class="mb-3">
                    <label for="txbProfesional" class="form-label">Elegir día:</label>
                    <asp:DropDownList runat="server" ID="ddlDias" AutoPostBack="true" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged"></asp:DropDownList>

                    <% if (ddlProfesional.SelectedIndex != 0 && ddlEsp.SelectedIndex != 0 && ddlDias.SelectedIndex != 0 ) {  %>
                        
                    <asp:Button Text="text" runat="server" />
                        
                    <% } %>
                </div>
                <div class="mb-3">
                    <label for="txbProfesional" class="form-label">Elegir Horario:</label>
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>

                </div>
                <div class="mb-3">
                </div>
                <div>
                    <asp:Button ID="btnAsignar" runat="server" Text="Aceptar" class="btn btn-primary" />
                </div>
            </div>
            <div class="col-3">

                <div class="mb-3">
                   
                </div>
                <div class="mb-3">
                    
                </div>
                <div class="mb-3">
                    
                </div>
                <div class="mb-3">
                </div>

            </div>

        </div>
        <div class="row">
        </div>
    </div>
</asp:Content>
