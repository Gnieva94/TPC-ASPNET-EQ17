<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="Web_Form.FormularioUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="row">
        <h2>Modificar cuenta</h2>
        <div class="col-3">
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txbNombre" runat="server" class="form-control" placeholder="Nombre..."></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbDNI" class="form-label">DNI:</label>
                <asp:TextBox ID="txbDNI" runat="server" class="form-control" placeholder="DNI"></asp:TextBox>
            </div>
            <div class="mb-3 d-flex flex-column">
                <label for="ddlNacionalidad" class="form-label">Nacionalidad:</label>
                <asp:DropDownList runat="server" ID="ddlNacionalidad" class="btn btn-secondary dropdown-toggle">
                    <asp:ListItem Text="Argentine" Value="Argentine" />
                    <asp:ListItem Text="Chilene" Value="Chilene" />
                    <asp:ListItem Text="Paraguaye" Value="Paraguaye" />
                    <asp:ListItem Text="Boliviane" Value="Boliviane" />
                    <asp:ListItem Text="Uruguaye" Value="Uruguaye" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txbDireccion" class="form-label">Direccion:</label>
                <asp:TextBox runat="server" ID="txbDireccion" class="form-control" placeholder="Av. Falsa 123" />
            </div>
            <div class="mb-3">
                <label for="txbProvincia" class="form-label">Provincia:</label>
                <asp:TextBox runat="server" ID="txbProvincia" class="form-control" placeholder="Burzaco" />
            </div>
            <div>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary" OnClick="btnModificar_Click" />
                <asp:Button Text="Regresar" cssclass="btn btn-danger" ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" TabIndex="21" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="txbApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txbApellido" runat="server" class="form-control" placeholder="Apellido..."></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbFechaNacimiento" class="form-label">Fecha de nacimiento:</label>
                <asp:TextBox ID="txbFechaNacimiento" TextMode="Date" runat="server" class="form-control" placeholder=""></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbCelu" class="form-label">Celular:</label>
                <asp:TextBox ID="txbCelu" runat="server" class="form-control" placeholder="11 1111 1111"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbLocalidad" class="form-label">Localidad:</label>
                <asp:TextBox runat="server" ID="txbLocalidad" class="form-control" placeholder="SpringField" />
            </div>
            <div class="mb-3">
                <label for="txbCodigoPostal" class="form-label">Codigo Postal:</label>
                <asp:TextBox runat="server" ID="txbCodigoPostal" class="form-control" placeholder="B2055" />
            </div>
        </div>
        <div class="col-6">
      
                    <%if (TipoUser == 4)
                        {
                    %>
                    <div class="col-3 d-flex flex-column">
                        <div>
                            <label for="ddlObraSocial" class="form-label">Obra Social:</label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlObraSocial" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged ="ddlObraSocial_SelectedIndexChanged">
                        </asp:DropDownList>
                        <div class="mt-3">
                            <asp:Label ID="lblNroAfiliado" Text="Numero de Afiliado:" CssClass="form-label mt-3" runat="server" />
                            <asp:TextBox runat="server" ID="txbNumeroAfiliado" TextMode="Number" class="form-control mt-2" placeholder="Nº XXXXXXX"/>
                        </div>
                    </div>
                    <%} %>
                    <%if (TipoUser == 3)
                        {  %>
                    <div class="d-flex">
                        <div class="col-3 d-flex flex-column me-4">
                            <label for="" class="form-label">Matricula:</label>
                            <asp:TextBox runat="server" ID="txbMatricula" CssClass="form-control" placeholder="XX-XXXXXX"/>
                        </div>
                    </div>
                    <%} %>
                    <%if (TipoUser == 1 || TipoUser == 2)
                        {  %>
                    <div class="d-flex">
                        <div class="col-3 d-flex flex-column me-4">
                            <label for="txtPermiso" class="form-label">ID Permiso:</label>
                            <asp:TextBox runat="server" ID="txtPermiso" CssClass="form-control" placeholder="XX-XXXXXXX" />
                        </div>
                    </div>
                    <%} %>
       
        </div>
    </div>
</asp:Content>
