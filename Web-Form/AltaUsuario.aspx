<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Web_Form.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" />
    <div class="row">
        <h2>Crear cuenta de usuario</h2>
        <%if (Helpers.Seguridad.EsEmpleado(Session["Persona"]) || Helpers.Seguridad.EsAdmin(Session["Persona"])) { %>
            <div class="mb-3">
                <label for="ddlTipoUsuario" class="form-label">Tipo de usuario</label>
                <asp:DropDownList runat="server" ID="ddlTipoUsuario" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoUsuario_SelectedIndexChanged" placeholder="Selecciona el tipo de usuario">
                </asp:DropDownList>
            </div>
           <%}  %>
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
        <div class="col-3">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if(Session["Persona"] == null || TipoUser == 4) {
%>
                    <div class="mb-3 d-flex flex-column">
                        <div>
                            <label for="ddlObraSocial" class="form-label">Obra Social:</label>
                            <asp:CheckBox ID="chkObraSocial" runat="server" OnCheckedChanged="chkObraSocial_CheckedChanged" AutoPostBack="true"/>
                        </div>
                        <%if (chkObraSocial.Checked) {  %>
                        <asp:DropDownList runat="server" ID="ddlObraSocial" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlObraSocial_SelectedIndexChanged">
                        </asp:DropDownList>
                        <%} %>
                    </div>
                    <%} %>
                    <%if(TipoUser == 3) {  %>
                    <div class="mb-3 d-flex flex-column">
                        <label for="ddlObraSocial" class="form-label">Profesional:</label>
                        <asp:DropDownList runat="server" ID="ddlProfesional" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlObraSocial_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
