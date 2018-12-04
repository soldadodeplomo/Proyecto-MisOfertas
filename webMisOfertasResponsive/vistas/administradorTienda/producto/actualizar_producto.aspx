<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="actualizar_producto.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.producto.actualizar_producto" %>
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
    <asp:Label ID="lblUsuario" runat="server" Text="" Enabled="false" Visible="False"></asp:Label>
    <p class="text-primary text-center" style="font-size: 30px;">ACTUALIZACIÓN DE PRODUCTO</p>
    <div class="container" style="width:700px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align:center;">BUSCAR PRODUCTO A ACTUALIZAR</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">SKU Producto</label>                       
                        <asp:TextBox ID="txtSkuProducto" runat="server" CssClass="form-control form-control-sm left-block" Width="350px" MaxLength="50" placeholder="Ingrese el sku del producto" style="margin-left:10px;" required></asp:TextBox>
                    </div>
<%--                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Nombre producto</label>
                        <asp:TextBox ID="txtNombreProd" runat="server" CssClass="form-control form-control-sm left-block" Width="350px"  style="margin-left:10px;" placeholder="Ingrese el nombre del producto" required></asp:TextBox>
                    </div>--%>
                </div>
                <div class="inner-addon left-addon">
                    <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar Producto" type="submit" CssClass="btn btn-primary" OnClick="btnBuscarProducto_Click"/>
                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
                <p>---------------------------------------- DATOS DEL PRODUCTO A MODIFICAR ---------------------------------------</p>
                <%--ZONA DATOS PRODUCTO--%>
                                <div class="form-group">
                    <div class="inner-addon left-addon"> 
                        <label for="exampleInputEmail1" style="padding-left: 10px;">SKU Producto</label>                       
                        
                        <asp:Label ID="lblSku" runat="server" Text=""></asp:Label>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Nombre producto</label>
                        <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="form-control form-control-sm left-block" Width="650px"  style="margin-left:10px;" placeholder="Ingrese el nombre del producto"></asp:TextBox>
                    </div>
                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Precio producto</label>
                        <asp:TextBox ID="txtPrecioProducto" runat="server" CssClass="form-control form-control-sm left-block" Width="650px"  style="margin-left:10px;" placeholder="Ingrese el precio del producto"></asp:TextBox>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;" >Marca producto</label><asp:Label ID="lblMarcaActual" runat="server" Text=""></asp:Label>
                        <asp:DropDownList ID="ddlMarcaProducto" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:650px; margin-left:10px;"></asp:DropDownList>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Venta mínima producto</label>
                        <asp:TextBox ID="txtVentaMinima" runat="server" CssClass="form-control form-control-sm left-block" Width="650px"  style="margin-left:10px;" placeholder="Ingrese la venta mínima del producto"></asp:TextBox><asp:Label ID="lblVentaMin" runat="server" Text=" unidades" CssClass="right-block" Visible="false"></asp:Label>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Venta máxima producto</label>
                        <asp:TextBox ID="txtVentaMaxima" runat="server" CssClass="form-control form-control-sm left-block" Width="650px"  style="margin-left:10px;" placeholder="Ingrese la venta máxima del producto"></asp:TextBox><asp:Label ID="lblVentaMax" runat="server" Text=" unidades" Visible="false"></asp:Label>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Rubro del producto</label><asp:Label ID="lblRubroActual" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlRubroProducto" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:650px; margin-left:10px;"></asp:DropDownList>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Lote del proveedor</label>
                        <asp:Label ID="lblLoteProveedor" runat="server" Text=""></asp:Label>
                    </div>
                                    <br />
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Sub familia producto</label><asp:Label ID="lblSubFamiliaActual" runat="server" Text="" Visible="false"></asp:Label>
                        <asp:DropDownList ID="ddlSubFamiliaProducto" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" style="width:650px; margin-left:10px;"></asp:DropDownList>
                    </div>
                </div>
                <div class="inner-addon left-addon">
                    <asp:Button ID="Button1" runat="server" Text="Actualizar producto" type="submit" CssClass="btn btn-primary" OnClick="Button1_Click"/>
                </div>
            </div>
            <div class="panel-footer">

            </div>            
        </div>
    </div>        
    <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-sm left-block" Width="350px" MaxLength="50" placeholder="Ingrese el sku del producto" style="margin-left:10px;" required></asp:TextBox>--%>
</asp:Content>
<%--<asp:Content ID="Content4" ContentPlaceHolderID="foot" runat="server">
    <div class="container" style="width:550px; float:initial;">
        <div class="panel panel-default">
            
            <div class="panel-heading" style="text-align:center;">PRODUCTO A ACTUALIZAR</div>
            <div class="panel-body">

            </div>
            <div class="panel-footer">
                
            </div>            
        </div>
    </div>
</asp:Content>--%>
