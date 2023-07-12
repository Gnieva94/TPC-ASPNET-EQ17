<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="Web_Form.Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        
         
    <div class="row h-100">
        <div class="col-2 h-100">
            <div class="h-100">
                <%--Seccion de botones de navegacion--%>
                <div class="d-flex flex-column flex-shrink-0 p-3 text-bg-dark h-75">
                    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                        <span class="fs-4">Bienvenido!</span>


                    </a>
                    <hr>
                    <ul class="nav nav-pills flex-column mb-auto">
                        <li class="nav-item">

                            <a href="#" class="nav-link active" aria-current="page">Pacientes
                            </a>
                            <asp:CheckBox ID="chkPacientes" runat="server" Text="Pacientes" AutoPostBack="true" OnCheckedChanged="chkPacientes_CheckedChanged" />
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">Profesionales
                            </a>
                            <asp:CheckBox ID="chkProfesionales" runat="server" Text="Profesionales" AutoPostBack="true" OnCheckedChanged="chkProfesionales_CheckedChanged" />
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">Empleados
                            </a>
                            <asp:CheckBox ID="chkEmpleados" runat="server" Text="Empleados" AutoPostBack="true" OnCheckedChanged="chkEmpleados_CheckedChanged" />
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">Seteos varios
                            </a>
                        </li>
                    </ul>
                    <hr>
                    <div>
                        <asp:Button ID="btnLogout" runat="server" Text="Salir" CssClass="btn btn-secondary" type="button" aria-expanded="false" />

                    </div>
                </div>


            </div>
        </div>
        <div class="col-10">

            <%if (checkPacientes)
                { %>
            <div>
                <%--Seccion Buscador y filtro--%>
                <h4>Pacientes</h4>

                <asp:label id="lblFiltro" runat="server" text="Filtro"></asp:label>
                <asp:TextBox ID="txtFiltroRapidoPaciente" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoPaciente_TextChanged"></asp:TextBox>


            </div>
            <div>
                <asp:GridView ID="Prueba" CssClass="table" runat="server">
                </asp:GridView>
                <%--Seccion Grilla de pacientes--%>
                <asp:GridView ID="dgvPacientes" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="ObraSocial.Nombre" HeaderText="Obra Social" />
                        <asp:BoundField DataField="NumeroAfiliado" HeaderText="Nro Afiliado" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <%} %>

            <%if (checkProfesionales)
                { %>
            <div>
                <%--Seccion Buscador y filtro--%>
                <h4>Profesionales</h4>
                <asp:label id="Label1" runat="server" text="Filtro"></asp:label>
                <asp:TextBox ID="txtFiltroRapidoProfesionales" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoProfesionales_TextChanged"></asp:TextBox>

            </div>
            <div>
                <%--Seccion Grilla de profesionales--%>
                <asp:GridView ID="dgvProfesionales" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>
            </div>
            <%} %>

            <%if (checkEmpleados)
                { %>
            <div>
                <%--Seccion Buscador y filtro--%>
                <h4>Empleados</h4>
                 <asp:label id="Label2" runat="server" text="Filtro"></asp:label>
                <asp:TextBox ID="txtFiltroRapidoEmpleados" runat="server" AutoPostBack="true" OnTextChanged="txtFiltroRapidoEmpleados_TextChanged"></asp:TextBox>

            </div>

            <div>
                <%--Seccion Grilla de empleados--%>
                <asp:GridView ID="dgvEmpleados" CssClass="table" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Dni" HeaderText="DNI" />
                        <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" />
                        <asp:BoundField DataField="DatosContacto.Email" HeaderText="Email" />
                        <asp:BoundField DataField="DatosContacto.Celular" HeaderText="Celular" />
                        <asp:BoundField DataField="DatosContacto.Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Permiso.Descripcion" HeaderText="Permiso" />
                        <asp:CommandField ShowSelectButton="true" SelectText="X" HeaderText="Modificar" />
                    </Columns>
                </asp:GridView>

            </div>
            <%} %>
        </div>
    </div>
      


</asp:Content>
