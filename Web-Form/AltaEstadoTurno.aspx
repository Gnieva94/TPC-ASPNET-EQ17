<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaEstadoTurno.aspx.cs" Inherits="Web_Form.AltaEstadoTurno" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="container">
        <div class="row">
            <div class="col-md-12">
                <h1>Alta Obra Social</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
