<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="publicar_oferta.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.publicar_oferta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="links" runat="server">
          <nav class="navbar navbar-expand-lg navbar-light bg-light">
         <asp:Image ID="Image1" runat="server" ImageUrl="~/imagenes/test.png" />
        <%--<a class="navbar-brand" href="#">Navbar</a>--%>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>

       <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/administradorTienda/consultar_ofertas.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">CONSULTAR OFERTAS<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/administradorTienda/publicar_oferta.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">PUBLICAR OFERTA</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/administradorTienda/reporte_valoracion_compra.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">REPORTE VALORACION</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="font-family:Calibri; font-size:20px; color:dodgerblue;" >ADMINISTRAR PRODUCTO</a>                    
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/insertar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">AGREGAR PRODUCTO</a>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/actualizar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">ACTUALIZAR PRODUCTO</a>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/deshabilitar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">DESHABILITAR PRODUCTO</a>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/listar_productos.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">LISTAR PRODUCTOS</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <p class="text-primary text-center" style="font-size: 30px;">¡BIENVENIDO ENCARGADO DE TIENDA!</p>
    <div class="container" style="width:1500px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">CREAR OFERTA/PROMOCION</div>
            <div class="panel-body">
                <div class="form-group">
<%--                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">Correo consumidor</label>                       
                        <asp:TextBox ID="txtCorreoConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" MaxLength="50" TextMode="Email" placeholder="Ingrese su correo electrónico" required></asp:TextBox>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Contraseña consumidor</label>
                        <asp:TextBox ID="txtPasswordConsumidor" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" TextMode="Password" placeholder="Ingrese su contraseña" required></asp:TextBox>
                    </div>--%>
                </div>
            </div>
            <div class="panel-footer">
<%--                <asp:Button ID="btnIngresarSesionConsumidor" runat="server" Text="Iniciar Sesión" type="submit" CssClass="btn btn-primary"/>
            </div>
            <asp:RegularExpressionValidator ID="revCorreoConsumidor" runat="server" ErrorMessage="El correo no tiene el formato correcto" ControlToValidate="txtCorreoConsumidor" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validadores"></asp:RegularExpressionValidator><br />--%>
        </div>
    </div>
</asp:Content>
