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
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" class="btn btn-primary"  OnClick="btnModificar_Click"/>
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
            <div class="col-3 d-flex flex-column">
                <div>
                    <label for="ddlObraSocial" class="form-label">Obra Social:</label>
                </div>

                <asp:DropDownList runat="server" ID="ddlObraSocial" class="btn btn-secondary dropdown-toggle">
                </asp:DropDownList>
                <div>
                    <label for="txbNumeroAfiliado" class="form-label mt-3">Numero de Afiliado:</label>
                    <asp:TextBox runat="server" ID="txbNumeroAfiliado" TextMode="Number" class="form-control" placeholder="Nº XXXXXXX" />
                </div>

            </div>
        </div>
</asp:Content>
