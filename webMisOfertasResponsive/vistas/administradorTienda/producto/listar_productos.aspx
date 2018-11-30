<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="listar_productos.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.producto.listar_productos" %>
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
    <p class="text-primary text-center" style="font-size: 30px;"></p>
</asp:Content>
