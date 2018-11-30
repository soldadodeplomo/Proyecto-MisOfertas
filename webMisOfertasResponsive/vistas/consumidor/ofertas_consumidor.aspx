<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ofertas_consumidor.aspx.cs" Inherits="webMisOfertasResponsive.vistas.consumidor.ofertas_consumidor" %>
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
                    <a class="nav-link" href="/vistas/consumidor/ofertas_consumidor.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">OFERTAS PERSONALIZADAS<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/consumidor/valorizar_oferta_compra.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">VALORIZAR COMPRA</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/consumidor/descargar_cupon.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue;">DESCARGAR CUPON DE DESCUENTO</a>
                </li>
                    <%--                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/login_consumidor.aspx" style="font-family:Calibri; font-size:20px; color:dodgerblue; text-align:right">CERRAR SESION</a>
                </li>--%>
                <li class="nav-item active">
                     <asp:LinkButton ID="btnCerrarSesion" runat="server" CssClass="nav-link" style="font-family:Calibri; font-size:20px; color:dodgerblue;" OnClick="btnCerrarSesion_Click">CERRAR SESION</asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <p class="text-primary text-center" style="font-size: 30px;">¡BIENVENIDO A MIS OFERTAS, <asp:Label ID="lblNombreUsuario" runat="server"></asp:Label>
        !<br />¡AQUÍ PODRÁS VISUALIZAR TUS OFERTAS PERSONALIZADAS!</p>
    <div class="container" style="width:1500px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">OFERTAS PERSONALIZADAS</div>
            <div class="panel-body">
                <div class="form-group">

                </div>
            </div>
            <div class="panel-footer">                
            </div>           
        </div>
    </div>
</asp:Content>
