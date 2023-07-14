<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web_Form.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-4 d-flex flex-column ">
            <h2>Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txbEmail"/>
            </div>
            <div class="mb-3">
                <label class="form-label">Contraseña</label>
                <asp:TextBox runat="server" cssclass="form-control" ID="txbPass" TextMode="Password"/>
            </div>
            <div class="d-flex">
                <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" runat="server" OnClick="btnLogin_Click"/>
                <asp:Button Text="Regresar" cssclass="btn btn-danger ms-3" ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" />
            </div>
            
        </div>
    </div>
</asp:Content>
