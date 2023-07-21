<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaTurno.aspx.cs" Inherits="Web_Form.AltaTurno" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:ScriptManager runat="server" />

        <div class="row justify-content-center mb-4 mt-4">
            <div class="col-4">
                <h2>Alta turno</h2>
            </div>
        </div>
        <div class="row justify-content-center">
            <div class="col-4">
                
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            </div>
                            <div class="mb-3">
                                <label for="txbEspecialidad" class="form-label">Elegir especialidad:</label>
                                <asp:DropDownList runat="server" ID="ddlEsp" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEsp_SelectedIndexChanged1"  > <asp:ListItem Enabled="true" Selected="True" Text="Seleccione una opcioón:"> </asp:ListItem></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label for="ddlProfesional" class="form-label">Elegir profesional:</label>
                                <asp:DropDownList runat="server" ID="ddlProfesional" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlProfesional_SelectedIndexChanged" DataValueField="mjinuhbygvftcdrx"><asp:ListItem Text="Seleccione una opción" Value="" Disabled="true" Selected="true"></asp:ListItem></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label for="ddlDias" class="form-label">Elegir día:</label>
                                <asp:DropDownList runat="server" ID="ddlDias" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlDias_SelectedIndexChanged"><asp:ListItem Text="Seleccione una opción" Value="" Disabled="true" Selected="true"></asp:ListItem></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label for="ddlHoras" class="form-label">Elegir hora:</label>
                                <asp:DropDownList runat="server" ID="ddlHoras" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlHoras_SelectedIndexChanged"><asp:ListItem Text="Seleccione una opción" Value="" Disabled="true" Selected="true"></asp:ListItem></asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <asp:DropDownList runat="server" ID="ddlOpciones" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlOpciones_SelectedIndexChanged">

                                </asp:DropDownList>
                            </div>
                            <div class="mb-3">
                                <label for="txbObservaciones" class="form-label">Elegir especialidad:</label>
                                <asp:TextBox runat="server" ID="txbObservaciones" class="form-control" Text="Observaciones: "></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Button runat="server" ID="btnGuardar" class="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                            </div>
                            <div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
               
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
    </div>
</asp:Content>
