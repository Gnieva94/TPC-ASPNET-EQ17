<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelRecepcionista.aspx.cs" Inherits="Web_Form.PanelRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-2">
            <div>
                <h3>Bienvenido</h3>

            </div>
            <div>
                <%--Seccion de botones de navegacion--%>
                <h4>Aca van los links a las difentes listas</h4>

                


            </div>
        </div>
        <div class="col-10">
            <div>
                <%--Seccion Buscador y filtro--%>
                 <h4>Pacientes</h4>

            </div>
            <div>
            <%--Seccion Grilla de pacientes/profesionales--%>
                 <h4>Grilla</h4>
                <asp:GridView ID="dgvPacientes" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Persona.Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Persona.Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Persona.Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="Persona.FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="ObraSocial.Nombre" HeaderText="Obra Social" />
                        <%-- <asp:BoundField DataField="ObraSocial.NroAfiliado" HeaderText="Nro Afiliado" />--%>
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />


                    </Columns>

                </asp:GridView>
            </div>

        </div>
    </div>
</asp:Content>
