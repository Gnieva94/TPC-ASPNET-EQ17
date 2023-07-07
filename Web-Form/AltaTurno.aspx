<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Web_Form.AltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="row">
            <h2>Alta turno</h2>
            <div class="mb-3 text-center">
                <h3>Datos del paciente</h3>
            </div>
            <div class="col-3">
                <div class="mb-3">
                    <label for="txbNombre" class="form-label">Nombre:</label>
                    <asp:Textbox ID="txbNombre" runat="server" class="form-control" placeholder="Nombre..."></asp:Textbox>
                </div>
                <div class="mb-3">
                    <label for="txbMail" class="form-label">Email:</label>
                    <asp:TextBox ID="txbMail" runat="server" class="form-control" placeholder="nombre@mail.com"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlObraSocial" class="form-label">Obra Social:</label>
                    <asp:DropDownList runat="server" ID="ddlObraSocial" class="btn btn-secondary dropdown-toggle" placeholder="Selecciona la obra social">
                    </asp:DropDownList>
                </div>
                <div class="mb-3">
                </div>
                <div class="mb-3">
                </div>
                <div>
                    <asp:Button ID="btnAsignar" runat="server" Text="Crear" class="btn btn-primary" />
                </div>
            </div>
            <div class="col-3">

                <div class="mb-3">
                    <label for="txbApellido" class="form-label">Apellido:</label>
                    <asp:TextBox ID="txbApellido" runat="server" class="form-control" placeholder="Apellido..."></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txbDNI" class="form-label">DNI:</label>
                    <asp:TextBox ID="txbDNI" runat="server" class="form-control" placeholder="DNI"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="txbNroAfiliado" class="form-label">Número de afiliado:</label>
                    <asp:TextBox ID="txbNroAfiliado" runat="server" class="form-control" placeholder="1111111111"></asp:TextBox>
                </div>
                <div class="mb-3">
                </div>

            </div>

        </div>
        <div class="row">

        </div>
    </div>
</asp:Content>
