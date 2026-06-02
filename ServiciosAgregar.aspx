<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ServiciosAgregar.aspx.vb" Inherits="ServiciosAgregar" MasterPageFile="~/MasterPageCuenza.Master"%>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" runat = "server" ContentPlaceHolderID ="Contenido1">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                <table cellpadding="0" cellspacing="0" style="height: 35px; width:100%;">
                    <tr>
                        <td style="padding-left:5px; width:265px; background-image: url('/Imagenes/Fondo_Titulos_Menus_04.png'); background-repeat: no-repeat; ">
                            <asp:Label ID="LabelTitulo" runat="server" Font-Names="Arial" Font-Size="Large" 
                                ForeColor="White" Text="Agregar Servicio"></asp:Label>
                        </td>
                        <td style="border-bottom-style: solid; border-width: 1px; border-color: #000000">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="auto-style5">
                            <telerik:RadToolBar ID="RadToolBarActualizar" runat="server" Skin="Sunset" TabIndex="24">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Enviar" ToolTip="Agregar registro a la base de datos">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="Cancelar la captura del registro">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="lblMensaje" runat="server" BackColor="#FFFF66" Font-Bold="True" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <table cellpadding="0" cellspacing="0" class="auto-style16" style="background-color:#e1e1e1;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="auto-style1" style="border: 1px solid #AAAAAA">
                                <tr>
                                    <td style="height:25px; padding-left:7px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Datos del Servicio"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color:#e1e1e1;">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td class="auto-style8">&nbsp;</td>
                                                <td class="auto-style9" style="text-align:right; padding-right:30px;">
                                                    &nbsp;</td>
                                                <td class="auto-style10">&nbsp;</td>
                                                <td class="auto-style11">&nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label5" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Clave"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxClave" Runat="server" ReadOnly ="True" ForeColor="Red" Width="60%" TabIndex="13" MaxLength="20"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label13" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Nombre"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxNombre" Runat="server" Width="100%" TabIndex="13" MaxLength="50"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label2" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Línea de Servicio"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxLineaServicio" Runat="server" AutoPostBack="True" Skin="Default" Width="60%" TabIndex="1"></telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">&nbsp;</td>
                                                <td class="auto-style9">&nbsp;</td>
                                                <td class="auto-style10">&nbsp;</td>
                                                <td class="auto-style11">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarActualizar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxClave" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxNombre" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxLineaServicio" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                    </AjaxSettings>                                
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                    height="75px" width="75px" HorizontalAlign="Center" Transparency="3" 
                    CssClass="LoadingPanel">
                    <telerik:RadWindowManager ID="RadWindowManager1" runat="server">
                    </telerik:RadWindowManager>
                </telerik:RadAjaxLoadingPanel>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .LoadingPanel  
        {  
            background: url('<%= RadAjaxLoadingPanel.GetWebResourceUrl(Page, "Telerik.Web.UI.Skins.Default.Ajax.loading.gif") %>') center center no-repeat ;  
        }
    </style>
    <style type="text/css">
        .rgDetailTable
        {
    	    margin-top: 10px;
    	    margin-bottom: 10px;
            margin-left: 35px;
            border: 10px solid #46463C !important;
        }
        .rgDetailTable2
        {
    	    margin-top: 5px;
    	    margin-bottom: 5px;
            margin-left: 35px;
            border: 10px solid #46463C !important;
        }
    </style>
    <style type="text/css">
        .auto-style1 
        {
            width: 100%;
        }
        .auto-style2
        {
            width: 5px;
        }
        .auto-style3
        {
            width: 900px;
        }
        .auto-style4
        {
            width: 100%;
            height: 35px;
        }
        .auto-style5
        {
            width: 260px;
        }
        .auto-style8
        {
            width: 10%;
            vertical-align: top;
            height: 26px;
            padding-left: 7px;
        }
        .auto-style9
        {
            width: 39%;
            vertical-align: top;
            height: 26px;
        }
        .auto-style10
        {
            width: 11%;
            vertical-align: top;
            height: 26px;
        }
        .auto-style11
        {
            width: 40%;
            vertical-align: top;
            height: 26px;
        }
        .auto-style12
        {
            padding-left:7px;
            width: 13%;
            height: 20px;
            text-align: left;
            vertical-align: bottom;
        }
        .auto-style13
        {
            width: 9%;
            height: 20px;
            text-align: left;
            vertical-align: bottom;
        }
        .auto-style14
        {
            width: 12%;
            height: 20px;
            text-align: left;
            vertical-align: bottom;
        }
        .auto-style15
        {
            width: 33%;
            height: 20px;
            text-align: left;
            vertical-align: bottom;
        }
        .auto-style16 
        {
            width: 99%;
        }
    
    </style>

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
