<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="login_administrador_tienda.aspx.cs" Inherits="webMisOfertasResponsive.vistas.login_administrador_tienda" %>
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
    <p class="text-primary text-center" style="font-size: 30px;">¡BIENVENIDO ADMINISTRADOR!</p>
    <div class="container" style="width:400px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">LOGIN ADMINISTRADOR TIENDA</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">R.U.N administrador</label>                       
                        <asp:TextBox ID="txtRunAdmTienda" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" MaxLength="50" placeholder="Ej: xx.xxx.xxx-x" required></asp:TextBox>
                        <%--                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Contraseña administrador</label>
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <asp:TextBox ID="txtPasswordAdmTienda" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" TextMode="Password" placeholder="Ingrese su contraseña" required></asp:TextBox>
                    </div>
                    <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                </div>
            </div>
            <div class="panel-footer">
                <%--<button type="submit" class="btn btn-primary">Iniciar Sesión</button>--%>
                <asp:Button ID="btnIngresarSesionAdminitrador" runat="server" Text="Iniciar Sesión" type="submit" CssClass="btn btn-primary" OnClick="btnIngresarSesionAdminitrador_Click"/>
            </div>
            <asp:RegularExpressionValidator ID="revRunAdministrador" runat="server" ErrorMessage="El R.U.N no tiene el formato correcto" ControlToValidate="txtRunAdmTienda" ValidationExpression="\d{1,2}\.\d{3}\.\d{3}[\-][0-9kK]{1}" CssClass="validadores"></asp:RegularExpressionValidator><br />
        </div>
    </div>
</asp:Content>
