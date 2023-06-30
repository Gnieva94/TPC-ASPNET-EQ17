<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Web_Form.AltaUsuario1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <h2>Crear cuenta de usuario</h2>
        <div class="col-3">
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txbNombre" runat="server" class="form-control" placeholder="Nombre..."></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbMail" class="form-label">Email:</label>
                <asp:TextBox ID="txbMail" runat="server" class="form-control" placeholder="nombre@mail.com"></asp:TextBox>
            </div>
            <div class="mb-3">
                 <label for="txbFechaNacimiento" class="form-label">Fecha de nacimiento:</label>
                <asp:TextBox ID="txbFechaNacimiento" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txbPass" runat="server" class="form-control" placeholder="" type="password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="ddlTipoUsuario" class="form-label">Tipo de usuario</label>
                <asp:DropDownList runat="server" ID="ddlTipoUsuario" class="btn btn-secondary dropdown-toggle" placeholder="Selecciona el tipo de usuario">
              
                </asp:DropDownList>
            </div>
            <div>
                <asp:Button ID="btnCrear" runat="server" Text="Crear" class="btn btn-primary" OnClick="btnCrear_Click" />
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
                <label for="txbCelu" class="form-label">Celular:</label>
                <asp:TextBox ID="txbCelu" runat="server" class="form-control" placeholder="11 1111 1111"></asp:TextBox>
            </div>
                <div class="mb-3">
                <label for="txbPassConf" class="form-label">Confirmar contraseña</label>
                <asp:TextBox ID="txbPassConf" runat="server" class="form-control" placeholder="" type="password"></asp:TextBox>
            </div>

        </div>

    </div>
</asp:Content>
