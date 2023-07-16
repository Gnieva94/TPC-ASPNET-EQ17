<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AltaUsuario.aspx.cs" Inherits="Web_Form.AltaUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <h2>Crear cuenta de usuario</h2>
        <div class="col-3">
            <div class="mb-3">
                <label for="txbNombre" class="form-label">Nombre:</label>
                <asp:TextBox ID="txbNombre" runat="server" class="form-control" placeholder="Nombre..." TabIndex="1"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbDNI" class="form-label">DNI:</label>
                <asp:TextBox ID="txbDNI" runat="server" class="form-control" placeholder="DNI" TabIndex="3"></asp:TextBox>
            </div>
            <div class="mb-3 d-flex flex-column">
                <label for="ddlNacionalidad" class="form-label">Nacionalidad:</label>
                <asp:DropDownList runat="server" ID="ddlNacionalidad" class="btn btn-secondary dropdown-toggle" TabIndex="5">
                    <asp:ListItem Text="Argentine" Value="Argentine" />
                    <asp:ListItem Text="Chilene" Value="Chilene" />
                    <asp:ListItem Text="Paraguaye" Value="Paraguaye" />
                    <asp:ListItem Text="Boliviane" Value="Boliviane" />
                    <asp:ListItem Text="Uruguaye" Value="Uruguaye" />
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txbDireccion" class="form-label">Direccion:</label>
                <asp:TextBox runat="server" ID="txbDireccion" class="form-control" placeholder="Av. Falsa 123" TabIndex="7"/>
            </div>
            <div class="mb-3">
                <label for="txbProvincia" class="form-label">Provincia:</label>
                <asp:TextBox runat="server" ID="txbProvincia" class="form-control" placeholder="Burzaco" TabIndex="9"/>
            </div>
            <div class="mb-3">
                <label for="txbMail" class="form-label">Email:</label>
                <asp:TextBox ID="txbMail" runat="server" class="form-control" placeholder="nombre@mail.com" TabIndex="11"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbPassConf" class="form-label">Confirmar contraseña</label>
                <asp:TextBox ID="txbPassConf" runat="server" class="form-control" placeholder="" type="password" TabIndex="13" AutoPostBack="true" OnTextChanged="txbPassConf_TextChanged"></asp:TextBox>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <label for="txbApellido" class="form-label">Apellido:</label>
                <asp:TextBox ID="txbApellido" runat="server" class="form-control" placeholder="Apellido..." TabIndex="2"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbFechaNacimiento" class="form-label">Fecha de nacimiento:</label>
                <asp:TextBox ID="txbFechaNacimiento" TextMode="Date" runat="server" class="form-control" placeholder="" TabIndex="4"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbCelu" class="form-label">Celular:</label>
                <asp:TextBox ID="txbCelu" runat="server" class="form-control" placeholder="11 1111 1111" TabIndex="6"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txbLocalidad" class="form-label">Localidad:</label>
                <asp:TextBox runat="server" ID="txbLocalidad" class="form-control" placeholder="SpringField" TabIndex="8"/>
            </div>
            <div class="mb-3">
                <label for="txbCodigoPostal" class="form-label">Codigo Postal:</label>
                <asp:TextBox runat="server" ID="txbCodigoPostal" class="form-control" placeholder="B2055" TabIndex="10"/>
            </div>
            <div class="mb-3">
                <label for="txbPass" class="form-label">Contraseña</label>
                <asp:TextBox ID="txbPass" runat="server" class="form-control" placeholder="" type="password" TabIndex="12"></asp:TextBox>
            </div>
            <div class="mb-3 d-flex flex-column">
                <asp:Label Text="" ID="lblPassValidacion" CssClass="form-label" runat="server" />
                <asp:Button ID="btnCrear" runat="server" Text="Crear" class="btn btn-primary" OnClick="btnCrear_Click" TabIndex="20"/>
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <%if (Session["Persona"] == null || TipoUser == 4)
                        {
                    %>
                    <div class="col-3 d-flex flex-column">
                        <div>
                            <label for="ddlObraSocial" class="form-label">Obra Social:</label>
                        </div>
                        <asp:DropDownList runat="server" ID="ddlObraSocial" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlObraSocial_SelectedIndexChanged" TabIndex="14">
                        </asp:DropDownList>
                        <div class="mt-3">
                            <asp:Label ID="lblNroAfiliado" Text="Numero de Afiliado:" CssClass="form-label mt-3" runat="server" />
                            <asp:TextBox runat="server" ID="txbNumeroAfiliado" TextMode="Number" class="form-control mt-2" placeholder="Nº XXXXXXX" TabIndex="15"/>
                        </div>
                    </div>
                    <%} %>
                    <%if (TipoUser == 3)
                        {  %>
                    <div class="d-flex">
                        <div class="col-3 d-flex flex-column me-4">
                            <label for="" class="form-label">Matricula:</label>
                            <asp:TextBox runat="server" ID="txbMatricula" CssClass="form-control" placeholder="XX-XXXXXXX" TabIndex="14"/>
                            <label for="ddlEspecialidad" class="form-label">Especialidad:</label>
                            <asp:DropDownList runat="server" ID="ddlEspecialidad" class="btn btn-secondary dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged" TabIndex="15">
                            </asp:DropDownList>
                            <label for="ddlDia" class="form-label">Dia: </label>
                            <asp:DropDownList runat="server" ID="ddlDia" CssClass="btn btn-secondary dropdown-toggle" TabIndex="16">
                                <asp:ListItem Text="Lunes" Value="1" />
                                <asp:ListItem Text="Martes" Value="2" />
                                <asp:ListItem Text="Miercoles" Value="3" />
                                <asp:ListItem Text="Jueves" Value="4" />
                                <asp:ListItem Text="Viernes" Value="5" />
                                <asp:ListItem Text="Sabado" Value="6" />
                                <asp:ListItem Text="Domingo" Value="7" />
                            </asp:DropDownList>
                            <label for="" class="form-label">Rango horario: </label>
                            <asp:DropDownList runat="server" ID="ddlHorarioInicio" class="btn btn-secondary dropdown-toggle" TabIndex="17">
                                <asp:ListItem Text="00" Value="00" />
                                <asp:ListItem Text="01" Value="01" />
                                <asp:ListItem Text="02" Value="02" />
                                <asp:ListItem Text="03" Value="03" />
                                <asp:ListItem Text="04" Value="04" />
                                <asp:ListItem Text="05" Value="05" />
                                <asp:ListItem Text="06" Value="06" />
                                <asp:ListItem Text="07" Value="07" />
                                <asp:ListItem Text="08" Value="08" />
                                <asp:ListItem Text="09" Value="09" />
                                <asp:ListItem Text="10" Value="10" />
                                <asp:ListItem Text="11" Value="11" />
                                <asp:ListItem Text="12" Value="12" />
                                <asp:ListItem Text="13" Value="13" />
                                <asp:ListItem Text="14" Value="14" />
                                <asp:ListItem Text="15" Value="15" />
                                <asp:ListItem Text="16" Value="16" />
                                <asp:ListItem Text="17" Value="17" />
                                <asp:ListItem Text="18" Value="18" />
                                <asp:ListItem Text="19" Value="19" />
                                <asp:ListItem Text="20" Value="20" />
                                <asp:ListItem Text="21" Value="21" />
                                <asp:ListItem Text="22" Value="22" />
                                <asp:ListItem Text="23" Value="23" />
                            </asp:DropDownList>
                            <label>a </label>
                            <asp:DropDownList runat="server" ID="ddlHorarioFin" class="btn btn-secondary dropdown-toggle" TabIndex="18">
                                <asp:ListItem Text="00" Value="00" />
                                <asp:ListItem Text="01" Value="01" />
                                <asp:ListItem Text="02" Value="02" />
                                <asp:ListItem Text="03" Value="03" />
                                <asp:ListItem Text="04" Value="04" />
                                <asp:ListItem Text="05" Value="05" />
                                <asp:ListItem Text="06" Value="06" />
                                <asp:ListItem Text="07" Value="07" />
                                <asp:ListItem Text="08" Value="08" />
                                <asp:ListItem Text="09" Value="09" />
                                <asp:ListItem Text="10" Value="10" />
                                <asp:ListItem Text="11" Value="11" />
                                <asp:ListItem Text="12" Value="12" />
                                <asp:ListItem Text="13" Value="13" />
                                <asp:ListItem Text="14" Value="14" />
                                <asp:ListItem Text="15" Value="15" />
                                <asp:ListItem Text="16" Value="16" />
                                <asp:ListItem Text="17" Value="17" />
                                <asp:ListItem Text="18" Value="18" />
                                <asp:ListItem Text="19" Value="19" />
                                <asp:ListItem Text="20" Value="20" />
                                <asp:ListItem Text="21" Value="21" />
                                <asp:ListItem Text="22" Value="22" />
                                <asp:ListItem Text="23" Value="23" />
                            </asp:DropDownList>
                            <br />
                            <div>
                                <asp:Button Text="Seleccionar" runat="server" ID="btnMasProfesional" class="btn btn-primary" OnClick="btnSeleccionarProfesional_Click" TabIndex="19"/>
                            </div>
                        </div>
                        <div class="col-8 d-flex flex-column">
                            <asp:GridView runat="server" ID="dgvListaHorarios" DataKeyNames="Id" CssClass="table table-striped table-hover table-sm" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvListaHorarios_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Especialidad.Nombre" HeaderText="Especialidad" />
                                    <asp:BoundField DataField="Dia" HeaderText="Dia" />
                                    <asp:BoundField DataField="HorarioInicio" HeaderText="Inicio" />
                                    <asp:BoundField DataField="HorarioFin" HeaderText="Fin" />
                                    <asp:CommandField ShowSelectButton="true" HeaderText="" SelectText="Eliminar" />

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
