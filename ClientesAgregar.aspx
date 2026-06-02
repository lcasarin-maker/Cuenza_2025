<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ClientesAgregar.aspx.vb" Inherits="ClientesAgregar" MasterPageFile="~/MasterPageCuenza.Master"%>

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
                                ForeColor="White" Text="Agregar Cliente"></asp:Label>
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
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Datos del Cliente"></asp:Label>
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
                                                    <asp:Label ID="Label13" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Clave"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td style="width:50%;">
                                                                <telerik:RadNumericTextBox ID="RadTextBoxClave" Runat="server" ReadOnly="True" ForeColor="Red" Width="100px" Enabled="True">
                                                                    <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:50%; text-align:right; padding-right:30px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label86" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="IVA"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxIVA" Runat="server" LabelWidth="64px" MaxValue="300" MinValue="0" Width="50px">
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label14" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Nombre"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxNombre" Runat="server" Width="98%" TabIndex="13" MaxLength="200"></telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label85" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Ciudad"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxCiudad" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label15" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="R.F.C."></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxRFC" Runat="server" Width="50%" TabIndex="13" MaxLength="20"></telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label19" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Estado"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxEstado" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label16" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Calle y Número" Width="80px"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxCalleNumero" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label20" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Teléfono"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxTelefono" Runat="server" Width="50%" TabIndex="13" MaxLength="50"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label81" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Colonia" Width="80px"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxColonia" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label83" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Contacto Facturación"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxContacto" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label82" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Código Postal"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadTextBox ID="RadTextBoxCP" Runat="server" Width="50%" TabIndex="13" MaxLength="10"></telerik:RadTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label84" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Otro Contacto"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxOtroContacto" Runat="server" Width="98%" TabIndex="13" MaxLength="100"></telerik:RadTextBox>
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
                        <telerik:AjaxSetting AjaxControlID="RadNumericTextBoxImporte">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImporte" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarActualizar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxClave" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxLineaServicio" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxQuienFactura" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxCliente" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxServicio" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño3" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño4" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño5" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImporte" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagosT" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxTipoMoneda" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxDetalle" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatus" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatusDesc" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxEspecificaciones" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxLineaServicio">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxClave" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxServicio" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxQuienFactura">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxQuienFactura" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxCliente">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxCliente" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxTipoMoneda">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxTipoMoneda" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxStatus">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatusDesc" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadNumericTextBoxNoPagos2">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadDatePickerFechaFacturacion">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadDatePickerFechaPago">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarAgregarPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagosT" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagoLetra" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConcepto" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarModificarPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagosT" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagoLetra" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConcepto" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos2" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarEliminarPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagosT" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagoLetra" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConcepto" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos2" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarGrabarPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagosT" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxNoPagos2" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaFacturacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadDatePickerFechaPago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePago" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImportePagoLetra" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConcepto" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos1" />
                                <telerik:AjaxUpdatedControl ControlID="PanelActPagos2" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGridPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarMostrar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="lblStatus" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
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
