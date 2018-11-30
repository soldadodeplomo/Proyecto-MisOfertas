 <%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="registrar_consumidor.aspx.cs" Inherits="webMisOfertasResponsive.vistas.registrar_consumidor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="links" runat="server">
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <img src="../imagenes/test.png" />
        <%--<a class="navbar-brand" href="#">Navbar</a>--%>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/registrar_consumidor.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">REGISTRO CONSUMIDOR<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/login_consumidor.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">LOGIN CONSUMIDOR</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/login_administrador_tienda.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">LOGIN ADMNISTRADOR TIENDA</a>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
     <p class="text-primary text-center" style="font-size: 30px;">REGISTRO DE CONSUMIDORES</p>
    <div class="container" style="width:400px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">REGISTRAR CONSUMIDOR</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">Nombre completo</label>                       
                        <asp:TextBox ID="txtNombreConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" MaxLength="50" placeholder="Ingrese su nombre y apellido" required></asp:TextBox>
<%--                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">R.U.N consumidor</label>
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <asp:TextBox ID="txtRutConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" placeholder="Ej: 12.345.678-9" required ></asp:TextBox>
                        <br />
                    </div>
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">Correo consumidor</label>                       
                        <asp:TextBox ID="txtCorreoConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" MaxLength="50" TextMode="Email" placeholder="Ingrese su correo electrónico" required></asp:TextBox>
<%--                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Contraseña consumidor</label>
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <asp:TextBox ID="txtPasswordConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" TextMode="Password" placeholder="Ingrese su contraseña" required MaxLength="15"></asp:TextBox>
                        <br />
                    </div>
                    <div >
                        <label for="InputComuna" style="padding-left:10px;">Comuna</label>
                        <asp:DropDownList ID="ddlComunaConsumidor" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:350px;" required></asp:DropDownList>
                    </div>
                    <div class="inner-addon left-addon">
                        <asp:CheckBox ID="cbRecibirOferta" runat="server" CssClass="custom-checkbox checkbox-inline" Text="Recibir ofertas por correo"/>
                    </div>                                                         
                </div>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </div>
            <div class="panel-footer">
                <%--<button type="submit" class="btn btn-primary">Iniciar Sesión</button>--%>
                <asp:Button ID="btnIngresarSesionAdminitrador" runat="server" Text="Registrarse" type="submit" CssClass="btn btn-primary" OnClick="btnIngresarSesionAdminitrador_Click"/>
            </div>
            <asp:RegularExpressionValidator ID="revRunConsumidor" runat="server" ErrorMessage="El RUN no tiene el formato correcto" CssClass="validadores" ControlToValidate="txtRutConsumidor" ValidationExpression="\d{1,2}\.\d{3}\.\d{3}[\-][0-9kK]{1}" ValidateRequestMode="Enabled"></asp:RegularExpressionValidator><br />
            <asp:RegularExpressionValidator ID="revCorreoAdministrador" runat="server" ErrorMessage="El correo no tiene el formato correcto" ControlToValidate="txtCorreoConsumidor" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validadores"></asp:RegularExpressionValidator><br />
            <br />
        </div>
    </div>
</asp:Content>
