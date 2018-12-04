<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="valorizar_oferta_compra.aspx.cs" Inherits="webMisOfertasResponsive.vistas.consumidor.valorizar_oferta" %>

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
                    <a class="nav-link" href="/vistas/consumidor/ofertas_consumidor.aspx" style="font-family: Calibri; font-size: 20px; color: dodgerblue;">OFERTAS PERSONALIZADAS<span class="sr-only">(current)</span></a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/consumidor/valorizar_oferta_compra.aspx" style="font-family: Calibri; font-size: 20px; color: dodgerblue;">VALORIZAR COMPRA</a>
                </li>
                <li class="nav-item active">
                    <a class="nav-link" href="/vistas/consumidor/descargar_cupon.aspx" style="font-family: Calibri; font-size: 20px; color: dodgerblue;">DESCARGAR CUPON DE DESCUENTO</a>
                </li>
                <li class="nav-item active">
                     <asp:LinkButton ID="btnCerrarSesion" runat="server" CssClass="nav-link" style="font-family:Calibri; font-size:20px; color:dodgerblue;" OnClick="btnCerrarSesion_Click">CERRAR SESION</asp:LinkButton>
                </li>
            </ul>
        </div>
    </nav>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <p class="text-primary text-center" style="font-size: 30px;">
        ¡AQUÍ PODRÁS VALORIZAR TUS COMPRAS!</p>
            <asp:Label ID="lblConsumidor" runat="server" Visible="false"></asp:Label>
        <br />
<%--        <p class="text-primary text-center" style="font-size: 30px;">¡BIENVENIDO
        <asp:Label ID="Label1" runat="server" Visible="false"></asp:Label>
        !<br />
        ¡AQUÍ PODRÁS VALORIZAR TUS COMPRAS!</p>--%>
    <div class="container" style="width: 400px;">
        <div class="panel panel-default">
            <div class="panel-heading" style="text-align: center;">VALORIZAR COMPRA</div>
            <div class="panel-body">
                <div class="form-group">
                    <div class="inner-addon left-addon">
                        <label for="inputImagenBoleta" style="padding-left: 10px;">Seleccionar imagen boleta</label>
                        <asp:FileUpload ID="fuImagenBoleta" runat="server" Style="padding-left: 11px;" required /><br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="inputValoracionOferta" style="padding-left: 10px;">Valorizar oferta</label>
                        <asp:DropDownList ID="ddlPuntajeValoracion" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" Style="width: 350px;" required></asp:DropDownList>
                        <%--                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>--%>
                        <br />
                    </div>
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Rubro compra</label>
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <asp:DropDownList ID="ddlRubroCompra" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" Style="width: 350px;" required></asp:DropDownList>
                    </div>                   
                    <div class="inner-addon left-addon">
                        <label for="exampleInputPassword1" style="padding-left: 10px;">Lugar de la compra</label>
                        <%--<input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">--%>
                        <asp:DropDownList ID="ddlLocalVenta" runat="server" CssClass="custom-select custom-select-lg mb-2 center-block" Style="width: 350px;" required></asp:DropDownList>
                    </div>  
                    <asp:Label ID="lblMensajeError" runat="server"></asp:Label>
                </div>
            </div>
            <div class="panel-footer">
                <%--<button type="submit" class="btn btn-primary">Iniciar Sesión</button>--%>
                <asp:Button ID="btnValorizarOferta" runat="server" Text="Valorizar Oferta" type="submit" CssClass="btn btn-primary" OnClick="btnValorizarOferta_Click" />
            </div>

            <%--<asp:RegularExpressionValidator ID="revCorreoConsumidor" runat="server" ErrorMessage="El correo no tiene el formato correcto" ControlToValidate="txtCorreoConsumidor" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" CssClass="validadores"></asp:RegularExpressionValidator><br />--%>
        </div>
    </div>
</asp:Content>
