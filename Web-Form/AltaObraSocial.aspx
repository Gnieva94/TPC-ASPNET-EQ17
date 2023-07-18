<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaObraSocial.aspx.cs" Inherits="Web_Form.AltaObraSocial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row justify-content-center mb-4 mt-4">
            <div class="col-3">
                <h2>Alta Obra Social</h2>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label ID="lblNombre" class="form-label" runat="server" Text="Nombre"></asp:Label>
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar" onClick="btnGuardar_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
