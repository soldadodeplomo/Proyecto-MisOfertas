<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="publicar_oferta.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.publicar_oferta"%>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

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
                    <a class="nav-link" href="/vistas/administradorTienda/consultar_ofertas.aspx" style="font-family:Calibri; font-size:19px; color:dodgerblue;">CONSULTAR OFERTAS<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/administradorTienda/publicar_oferta.aspx" style="font-family:Calibri; font-size:19px; color:dodgerblue;">PUBLICAR OFERTA</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/administradorTienda/reporte_valoracion_compra.aspx" style="font-family:Calibri; font-size:19px; color:dodgerblue;">REPORTE VALORACION</a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" style="font-family:Calibri; font-size:19px; color:dodgerblue;" >ADMINISTRAR PRODUCTO</a>                    
                    <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/insertar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">AGREGAR PRODUCTO</a>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/actualizar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">ACTUALIZAR PRODUCTO</a>
                        <%--<a class="dropdown-item" href="/vistas/administradorTienda/producto/deshabilitar_producto.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">DESHABILITAR PRODUCTO</a>--%>
                        <a class="dropdown-item" href="/vistas/administradorTienda/producto/listar_productos.aspx" style="font-family:Calibri; font-size:15px; color:dodgerblue;">LISTAR PRODUCTOS</a>
                    </div>
                </li>
                <li class="nav-item active">
                     <asp:LinkButton ID="btnCerrarSesionAdministrador" runat="server" CssClass="nav-link" style="font-family:Calibri; font-size:19px; color:dodgerblue;" OnClick="btnCerrarSesionAdministrador_Click">CERRAR SESION</asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">    
    <div class="container" style="width: 400px;">
        <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center;">CREAR OFERTA/PROMOCION</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon">
                        <label for="exampleInputEmail1" style="margin-left: 10px;">Precio oferta</label>
                        <asp:TextBox ID="txtPrecioOferta" runat="server" CssClass="form-control form-control-sm left-block" style="margin-left:10px;" Width="350px" MaxLength="9" placeholder="Ingrese el precio de la oferta (solo números)"  required></asp:TextBox>
                        <br />
                    </div>
                    <div class="inner addon left-addon ">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Fecha inicio oferta</label>
                        <asp:Calendar ID="calInicio" runat="server"  CssClass="left-block" Width="250px" required="" style="margin-left:10px;" OnDayRender="calInicio_DayRender" OnSelectionChanged="calInicio_SelectionChanged" SelectedDate="11/08/2018 15:10:24"></asp:Calendar>
                        
                        <br />
                    </div>
<%--                    <div class="inner-addon right-addon">
                        <label for="exampleInputPassword1" style="padding-left:50px;">Fecha termino oferta</label>
                        <asp:Calendar ID="calTermino" runat="server" CssClass="-block" Width="180px" required=""></asp:Calendar>
                        <br />
                    </div>--%>
                   <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Rubro oferta</label><br />
                        <asp:DropDownList ID="ddlRubroOferta" runat="server" CssClass="custom-select custom-select-lg mb-1" Style="width: 250px; margin-left:10px;" required></asp:DropDownList>
                    </div>  
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Tipo oferta/promoción</label><br />
                        <asp:DropDownList ID="ddlTipoOferta" runat="server" CssClass="custom-select custom-select-lg mb-1 left-block" Style="width: 250px; margin-left:10px;" required></asp:DropDownList>
                    </div>  
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Producto</label><br />
                        <asp:DropDownList ID="ddlProducto1" runat="server" CssClass="custom-select custom-select-lg mb-1 left-block" Style="width: 250px; margin-left:10px;" required></asp:DropDownList>
                    </div>  
<%--                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Producto 2 (opcional)</label><br />
                        <asp:DropDownList ID="ddlProducto2" runat="server" CssClass="custom-select custom-select-lg mb-1 left-block" Style="width: 250px; margin-left:10px;"></asp:DropDownList>
                    </div>  --%>
                </div>      
            </div>          
            <div class="panel-footer">
                <asp:Button ID="btnPublicarOferta" runat="server" Text="Publicar Oferta" type="submit" CssClass="btn btn-primary" OnClick="btnPublicarOferta_Click"/>
                <asp:Label ID="lblError" runat="server" style="padding-left: 10px;"></asp:Label>
            </div>
            <asp:RegularExpressionValidator ID="revSoloNumeros" runat="server" ErrorMessage="Por favor ingrese solo números enteros en el precio de la oferta" ValidationExpression="^\d+$" ControlToValidate="txtPrecioOferta"></asp:RegularExpressionValidator>
        </div>
    </div>
</asp:Content>
