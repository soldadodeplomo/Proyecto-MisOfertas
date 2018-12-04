<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="insertar_producto.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.producto.insertar_producto" %>
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
                        <%--<a class="dropdown-item" href="/vistas/administradorTienda/producto/deshabilitar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">DESHABILITAR PRODUCTO</a>--%>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/listar_productos.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">LISTAR PRODUCTOS</a>
                    </div>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <p class="text-primary text-center" style="font-size: 30px;">INSERTAR PRODUCTO</p>
    <div class="container" style="width:400px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">INSERTAR NUEVO PRODUCTO</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">Nombre producto</label>                       
                        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" MaxLength="50" placeholder="Ingrese nombre del producto" required></asp:TextBox>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Precio producto</label>
                        <asp:TextBox ID="txtPrecioProducto" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" placeholder="Ingrese precio del producto (solo números)" required></asp:TextBox>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Marca producto</label>
                        <%--<asp:TextBox ID="txtMarcaProducto" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" placeholder="Ingrese la marca del producto" required></asp:TextBox>--%>
                        <asp:DropDownList ID="ddlMarca"  runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:350px;" required></asp:DropDownList>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Imagen producto</label>
                        <asp:FileUpload ID="inputImagenProducto" runat="server" Style="padding-left: 11px;" required/>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Venta mínima</label>
                        <asp:TextBox ID="txtVentaMinima" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" placeholder="Ingrese la venta mímina del producto" required></asp:TextBox>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Venta máxima</label>
                        <asp:TextBox ID="txtVentaMaxima" runat="server" CssClass="form-control form-control-sm center-block" Width="350px" placeholder="Ingrese la venta mímina del producto" required></asp:TextBox>
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Rubro producto</label>
                        <asp:DropDownList ID="ddlRubro" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:350px;" required></asp:DropDownList>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Sub familia producto</label>
                        <asp:DropDownList ID="ddlSubFamilia" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:350px;" required></asp:DropDownList>
                    </div>
                    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
                </div>
            </div>
            <div class="panel-footer">
                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar Producto" type="submit" CssClass="btn btn-primary" OnClick="btnAgregarProducto_Click"/>
            </div>            
        </div>
    </div>
</asp:Content>
