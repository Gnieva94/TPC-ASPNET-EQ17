<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="Web_Form.Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-3">
            <div>
                <h3>Bienvenido</h3>

            </div>
            <div>
                <%--Seccion de botones de navegacion--%>
                <h4>Aca van los botones</h4>


            </div>
        </div>
        <div class="col-9">
            <div>
                <%--Seccion Buscador y filtro--%>
                 <h4>Pacientes</h4>

            </div>
            <div>
            <%--Seccion Grilla de pacientes/profesionales--%>
                 <h4>Grilla</h4>
                <asp:GridView ID="dgvPacientes" runat="server"></asp:GridView>
            </div>

        </div>
    </div>


</asp:Content>
