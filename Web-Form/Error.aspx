﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Web_Form.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>HUBO UN ERROR!</h2>
    <asp:Label runat="server" ID="lblError"></asp:Label>
    <p>Te pedimos disculpas, vuelve a intentar mas tarde</p>
    <p>Redirigiendo...</p>
</asp:Content>
