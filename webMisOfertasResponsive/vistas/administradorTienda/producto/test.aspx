<%@ Page Title="" Language="C#" MasterPageFile="~/master/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="webMisOfertasResponsive.vistas.administradorTienda.producto.test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="links" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="container" style="width:550px;float:left">
        <div class="panel panel-default">
    <form class="form-horizontal">
        <fieldset>

            <!-- Form Name -->
            <legend>Actualizar producto</legend>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput" runat="server">SKU producto</label>
                <div class="col-md-4">
                    <input id="txtSkuProducto" name="textinput" type="text" placeholder="Ingrese el SKU del producto" class="form-control input-md">
                    <%--<span class="help-block">help</span>--%>
                </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Nombre del producto</label>
                <div class="col-md-4">
                    <input id="txtNombreProducto" name="textinput" type="text" placeholder="Ingrese el nombre del producto" class="form-control input-md">
                    <%--<span class="help-block">help</span>--%>
                </div>
            </div>

            <!-- Button -->
            <div class="form-group">
                <%--<label class="col-md-4 control-label" for="singlebutton"></label>--%>
                <div class="col-md-4">
                    <button id="btnBuscarProducto" name="singlebutton" class="btn btn-primary" onclick="btnBuscarProducto_Click">Button</button>
                </div>
            </div>

            <label class="col-md-4 control-label" for="textinput">SKU producto</label>
            <label id="lblSku" runat="server" class="col-md-4 control-label" for="textinput"></label>
            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Text Input</label>
                <div class="col-md-4">
                    <input id="textinput" name="textinput" type="text" placeholder="placeholder" class="form-control input-md">
                    <span class="help-block">help</span>
                </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Text Input</label>
                <div class="col-md-4">
                    <input id="textinput" name="textinput" type="text" placeholder="placeholder" class="form-control input-md">
                    <span class="help-block">help</span>
                </div>
            </div>

            <!-- Button Drop Down -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="buttondropdown">Button Drop Down</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <input id="buttondropdown" name="buttondropdown" class="form-control" placeholder="placeholder" type="text">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                Action
          <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">Option one</a></li>
                                <li><a href="#">Option two</a></li>
                                <li><a href="#">Option three</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Text Input</label>
                <div class="col-md-4">
                    <input id="textinput" name="textinput" type="text" placeholder="placeholder" class="form-control input-md">
                    <span class="help-block">help</span>
                </div>
            </div>

            <!-- Text input-->
            <div class="form-group">
                <label class="col-md-4 control-label" for="textinput">Text Input</label>
                <div class="col-md-4">
                    <input id="textinput" name="textinput" type="text" placeholder="placeholder" class="form-control input-md">
                    <span class="help-block">help</span>
                </div>
            </div>

            <!-- Button Drop Down -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="buttondropdown">Button Drop Down</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <input id="buttondropdown" name="buttondropdown" class="form-control" placeholder="placeholder" type="text">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                Action
          <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">Option one</a></li>
                                <li><a href="#">Option two</a></li>
                                <li><a href="#">Option three</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Button Drop Down -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="buttondropdown">Button Drop Down</label>
                <div class="col-md-4">
                    <div class="input-group">
                        <input id="buttondropdown" name="buttondropdown" class="form-control" placeholder="placeholder" type="text">
                        <div class="input-group-btn">
                            <button type="button" class="btn btn-default dropdown-toggle" data-toggle="dropdown">
                                Action
          <span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu pull-right">
                                <li><a href="#">Option one</a></li>
                                <li><a href="#">Option two</a></li>
                                <li><a href="#">Option three</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <!-- Button -->
            <div class="form-group">
                <label class="col-md-4 control-label" for="singlebutton">Single Button</label>
                <div class="col-md-4">
                    <button id="singlebutton" name="singlebutton" class="btn btn-primary">Button</button>
                </div>
            </div>

        </fieldset>
    </form>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="foot" runat="server">
</asp:Content>
