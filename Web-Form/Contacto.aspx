<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Web_Form.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mb-4 mt-4">
            <div class="col-4">
                <h2>Contacto</h2>
            </div>
            <div class="row justify-content-center">
                <div class="col-4">
                    <div class="mb-3">
                        <label for="txbNombre" class="form-label">Nombre:</label>
                        <asp:TextBox ID="txbNombre" runat="server" class="form-control" placeholder="Nombre..."></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txbMail" class="form-label">Email:</label>
                        <asp:TextBox ID="txbMail" runat="server" class="form-control" placeholder="nombre@mail.com"></asp:TextBox>
                    </div>
                    <div class="mb-3">
                        <label for="txbTMensaje" class="form-label">Dejanos tu comentario</label>
                        <asp:TextBox ID="txbTMensaje" runat="server" TextMode="multiLine" class="form-control" placeholder="Mensaje..."></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
