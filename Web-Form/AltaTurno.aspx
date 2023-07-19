<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Web_Form.AltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager runat="server" />
    
        <div class="row">
            <h2>Alta turno</h2>
            <div class="col-3 d-flex flex-column">
                <div class="">
                    <asp:UpdatePanel runat="server" >
                    <ContentTemplate>
                        </div>
                            <div class="col-6 flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:DropDownList runat="server" ID="ddlEsp" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEsp_SelectedIndexChanged1"  ></asp:DropDownList>
                            </div>
                            <div class="flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>                       
                                <asp:DropDownList runat="server" ID="ddlProfesional" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlProfesional_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            <div class="flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:DropDownList runat="server" ID="ddlDias" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            <div class="flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:DropDownList runat="server" ID="ddlHoras" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlHoras_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            <div class="flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:DropDownList runat="server" ID="ddlOpciones" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlOpciones_SelectedIndexChanged" ></asp:DropDownList>
                            </div>
                            <div class="flex-column">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:TextBox runat="server" ID="txbObservaciones" class="form-control" Text="Observaciones: " ></asp:TextBox>
                                <asp:Button runat="server" ID="btnGuardar" class="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" /> 
                            </div>
                        <div>


                    </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="col-3 d-flex flex-column">

                    <label for="txbProfesional" class="form-label">Elegir profesional:</label>
                
                </div>
                <div class="col-3 d-flex flex-column">
                    <label>Observaciones</label>
                    <textarea id="txaObservaciones" rows="4" cols="50"></textarea>

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
