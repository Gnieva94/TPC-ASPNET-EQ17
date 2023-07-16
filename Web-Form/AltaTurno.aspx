<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Web_Form.AltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server" />
    
        <div class="row">
            <h2>Alta turno</h2>
            <div class="col-3">
                <div>
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                    <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                    <asp:DropDownList runat="server" ID="ddlEsp" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEsp_SelectedIndexChanged1"  ></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlProfesional" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlProfesional_SelectedIndexChanged" ></asp:DropDownList>
                    <asp:DropDownList runat="server" ID="ddlDias" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged" ></asp:DropDownList>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-3 d-flex flex-column">

                    <label for="txbProfesional" class="form-label">Elegir profesional:</label>
                
                </div>
                <div class="col-3 d-flex flex-column">


                </div>

                <%--<div class="col-3 d-flex flex-column">

                    <label for="txbProfesional" class="form-label">Elegir Horas:</label>
                    <asp:DropDownList runat="server" ID="ddlHoras2" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlHoras2_SelectedIndexChanged" ></asp:DropDownList>  

                    <div class="mb-3">

                        <label for="txbProfesional" class="form-label">Elegir Horas:</label>
                        <asp:DropDownList runat="server" ID="Ddlhoras" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="Ddlhoras_SelectedIndexChanged" ></asp:DropDownList>
                    </div>
                </div>--%>
            </div>
        </div>

</asp:Content>
