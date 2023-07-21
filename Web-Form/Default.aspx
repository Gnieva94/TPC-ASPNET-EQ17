<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web_Form.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <title>Medic</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto&display=swap">
    <style>
        body {
            background-image: url('https://img.freepik.com/vector-gratis/diseno-plantilla-papel-tapiz-medica-abstracta_53876-61805.jpg?w=900&t=st=1689976487~exp=1689977087~hmac=9ed5d837286b7da4716c5feccfff2947c41ade6937d312c562bf6f050953d822');
            background-size: cover;
            background-repeat: no-repeat;
        }
            .titulo-sitio {
            font-family: 'Roboto', sans-serif; 
            color: white;
            font-size: 100px;
            font-weight: bold;
            padding: 100px;

        }
            .bienvenidos {
            font-family: 'Roboto', sans-serif; 
            color: white;
            font-size: 70px;
            font-weight: bolder;
            padding-left: 300px;

        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <h1 class="titulo-sitio">Medic</h1>
        </div>
         <div>
            <h2 class="bienvenidos">Bienvenidos!</h2>
        </div>
    </div>
</asp:Content>
