<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PanelAdmin.aspx.cs" Inherits="Web_Form.Panel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row h-100" >
        <div class="col-2 h-100">
            <div class="h-100" >
                <%--Seccion de botones de navegacion--%>
                <div class="d-flex flex-column flex-shrink-0 p-3 text-bg-dark h-75">
                    <a href="/" class="d-flex align-items-center mb-3 mb-md-0 me-md-auto text-white text-decoration-none">
                        <span class="fs-4">Bienvenido!</span>


                    </a>
                    <hr>
                    <ul class="nav nav-pills flex-column mb-auto">
                        <li class="nav-item">
                            <a href="#" class="nav-link active" aria-current="page">
                                Pacientes
                            </a>
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">
                                Profesionales
                            </a>
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">
                                Empleados
                            </a>
                        </li>
                        <li>
                            <a href="#" class="nav-link text-white">
                                Seteos varios
                            </a>
                        </li>
                    </ul>
                    <hr>
                    <div class="dropdown">
                        <a href="#" class="d-flex align-items-center text-white text-decoration-none dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="https://github.com/mdo.png" alt="" width="32" height="32" class="rounded-circle me-2">
                            <strong>mdo</strong>
                        </a>
                        <ul class="dropdown-menu dropdown-menu-dark text-small shadow">
                            <li><a class="dropdown-item" href="#">New project...</a></li>
                            <li><a class="dropdown-item" href="#">Settings</a></li>
                            <li><a class="dropdown-item" href="#">Profile</a></li>
                            <li>
                                <hr class="dropdown-divider">
                            </li>
                            <li><a class="dropdown-item" href="#">Sign out</a></li>
                        </ul>
                    </div>
                </div>


            </div>
        </div>
        <div class="col-10">
            <div>
                <%--Seccion Buscador y filtro--%>
                <h4>Pacientes</h4>

            </div>
            <div>
                <%--Seccion Grilla de pacientes--%>
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
