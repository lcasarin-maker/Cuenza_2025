<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FacturacionGenerar.aspx.vb" Inherits="FacturacionGenerar" MasterPageFile="~/MasterPageCuenza.Master" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" runat = "server" ContentPlaceHolderID ="Contenido1">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style4">
                <table cellpadding="0" cellspacing="0" style="height: 35px; width:100%;">
                    <tr>
                        <td style="padding-left:5px; width:265px; background-image: url('/Imagenes/Fondo_Titulos_Menus_04.png'); background-repeat: no-repeat; ">
                            <asp:Label ID="Label3" runat="server" Font-Names="Arial" Font-Size="Large" 
                                ForeColor="White" Text="Generar Factura"></asp:Label>
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
            <td class="auto-style3" >&nbsp;
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:230px;">
                            <telerik:RadToolBar ID="RadToolBarActualizar" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Aceptar" ToolTip="Generar factura">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="Cancelar movimiento">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td>
                        </td>
                        <td>
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
            <td class="auto-style5">
                <table cellpadding="0" cellspacing="0" class="auto-style5" style="background-color:#e1e1e1;">
                    <tr>
                        <td style="height:25px; padding-left:4px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;" colspan="3">
                            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text=" Buscar factura electrónica"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:10%; background-color:#999999; height:30px; vertical-align:bottom; border-style: none solid none none; border-width: 1px; border-color: #C0C0C0;">
                            &nbsp;
                        </td>
                        <td style="width:45%; background-color:#999999; height:30px; vertical-align:bottom; padding-left:7px; border-style: none solid none solid; border-width: 1px; border-color: #C0C0C0;">
                            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="FACTURA ELECTRÓNICA"></asp:Label>
                        </td>
                        <td style="width:45%; background-color:#999999; height:30px; vertical-align:bottom; padding-left:7px; border-style: none none none solid; border-width: 1px; border-color: #C0C0C0;">
                            <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Black" Text="CUENZA"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:7px; width:10%; height:30px; vertical-align:bottom; padding-left:7px; ">
                            <asp:Label ID="Label12" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Folio"></asp:Label>
                        </td>
                        <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:7px; width:45%; height:30px; vertical-align:bottom;">
                            <table cellpadding="0" cellspacing="0" class="auto-style1">
                                <tr>
                                    <td style="width:50%; vertical-align:bottom;">
                                        <asp:Label ID="Label13" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Fecha"></asp:Label>
                                    </td>
                                    <td style="width:50%;">
                                        <asp:Label ID="Label19" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Importe"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:7px; width:45%; height:30px; vertical-align:bottom;">
                            <table cellpadding="0" cellspacing="0" class="auto-style1">
                                <tr>
                                    <td style="width:50%;">
                                        <asp:Label ID="Label14" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Fecha"></asp:Label>
                                    </td>
                                    <td style="width:50%;">
                                        <asp:Label ID="Label20" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Importe"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:10%; padding-left:7px;">
                            <telerik:RadNumericTextBox ID="RadNumericTextBoxFolio" Runat="server" Width="70px" MinValue="1" TabIndex="5" MaxValue="1000000">
                                <numberformat decimaldigits="0" GroupSeparator="" />
                            </telerik:RadNumericTextBox>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px;">
                            <table cellpadding="0" cellspacing="0" class="auto-style1">
                                <tr>
                                    <td style="width:50%;">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:50%;">
                                                    <telerik:RadTextBox ID="RadTextBoxFechaFE" Runat="server" Width="100px" TabIndex="21" ReadOnly="True"></telerik:RadTextBox>
                                                </td>
                                                <td style="width:50%;">
                                                    <asp:Image ID="ImageFechaFE" runat="server" Height="12px" Width="12px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:50%;">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:50%;">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxImporteFE" Runat="server" Width="100px" MinValue="0" TabIndex="20" ReadOnly="True"></telerik:RadNumericTextBox>
                                                </td>
                                                <td style="width:50%;">
                                                    <asp:Image ID="ImageImporteFE" runat="server" Height="12px" Width="12px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px;">
                            <table cellpadding="0" cellspacing="0" class="auto-style1">
                                <tr>
                                    <td style="width:50%;">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:50%;">
                                                    <telerik:RadTextBox ID="RadTextBoxFechaCz" Runat="server" Width="100px" TabIndex="21" ReadOnly="True"></telerik:RadTextBox>
                                                </td>
                                                <td style="width:50%;">
                                                    <asp:Image ID="ImageFechaCz" runat="server" Height="12px" Width="12px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:50%;">
                                        <table cellpadding="0" cellspacing="0" style="width:100%;">
                                            <tr>
                                                <td style="width:50%;">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxImporteCz" Runat="server" Width="100px" MinValue="0" TabIndex="20" ReadOnly="True"></telerik:RadNumericTextBox>
                                                </td>
                                                <td style="width:50%;">
                                                    <asp:Image ID="ImageImporteCz" runat="server" Height="12px" Width="12px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:10%; height:25px; vertical-align:bottom; padding-left:7px;">&nbsp;</td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="Label15" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Concepto"></asp:Label>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="Label16" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Concepto"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:10%; vertical-align:top; padding-left:7px;">
                            <telerik:RadToolBar ID="RadToolBarBuscar" Runat="server" Skin="Black">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Buscar" ToolTip="Buscar factura electrónica de acuerdo al folio capturado">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px; vertical-align:middle;">
                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:90%;">
                                        <telerik:RadTextBox ID="RadTextBoxConceptoFE" Runat="server" Height="100px" TextMode="MultiLine" Width="100%" TabIndex="22" ReadOnly="True"></telerik:RadTextBox>
                                    </td>
                                    <td style="width:10%; padding-left:10px;">
                                        <asp:Image ID="ImageConceptoFE" runat="server" Height="12px" Width="12px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px; vertical-align:middle;">
                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:90%;">
                                        <telerik:RadTextBox ID="RadTextBoxConceptoCz" Runat="server" Height="100px" TextMode="MultiLine" Width="100%" TabIndex="22" ReadOnly="True"></telerik:RadTextBox>
                                    </td>
                                    <td style="width:10%; padding-left:10px;">
                                        <asp:Image ID="ImageConceptoCz" runat="server" Height="12px" Width="12px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:10%; height:25px; vertical-align:bottom; padding-left:7px;">&nbsp;</td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="Label17" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Cliente"></asp:Label>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="Label18" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Black" Text="Cliente"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:10%; padding-left:7px;">&nbsp;</td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px;">
                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:90%;">
                                        <telerik:RadTextBox ID="RadTextBoxClienteFE" Runat="server" Width="100%" TabIndex="21" ReadOnly="True"></telerik:RadTextBox>
                                    </td>
                                    <td style="width:10%; padding-left:10px;">
                                        <asp:Image ID="ImageClienteFE" runat="server" Height="12px" Width="12px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:45%; padding-left:7px;">
                            <table cellpadding="0" cellspacing="0" style="width:100%;">
                                <tr>
                                    <td style="width:90%;">
                                        <telerik:RadTextBox ID="RadTextBoxClienteCz" Runat="server" Width="100%" TabIndex="21" ReadOnly="True"></telerik:RadTextBox>
                                    </td>
                                    <td style="width:10%; padding-left:10px;">
                                        <asp:Image ID="ImageClienteCz" runat="server" Height="12px" Width="12px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid solid solid; border-width: 1px 1px 2px 1px; border-color: #AAAAAA; width:10%;">&nbsp;</td>
                        <td style="border-style: none solid solid solid; border-width: 1px 1px 2px 1px; border-color: #AAAAAA; width:45%;">&nbsp;</td>
                        <td style="border-style: none solid solid solid; border-width: 1px 1px 2px 1px; border-color: #AAAAAA; width:45%;">&nbsp;</td>
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
            <td class="auto-style5">
                <table cellpadding="0" cellspacing="0" class="auto-style5" style="background-color:#e1e1e1;">
                    <tr>
                        <td style="height:25px; padding-left:4px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;" colspan="3">
                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text=" Resultados para la búsqueda de la factura electrónica"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:100%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="LabelErrores" runat="server" Font-Bold="True" Font-Names="Arial Narrow" ForeColor="Black"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:100%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="lblMensaje1" runat="server" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:100%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="lblMensaje2" runat="server" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid none solid; border-width: 1px; border-color: #AAAAAA; width:100%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="lblMensaje3" runat="server" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="border-style: none solid solid solid; border-width: 1px 1px 2px 1px; border-color: #AAAAAA; width:100%; height:25px; vertical-align:bottom; padding-left:7px;">
                            <asp:Label ID="lblMensaje4" runat="server" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarActualizar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxFolio" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarBuscar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxFechaFE" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImporteFE" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConceptoFE" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxClienteFE" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxFechaCz" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxImporteCz" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxConceptoCz" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxClienteCz" />
                                <telerik:AjaxUpdatedControl ControlID="LabelErrores" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje1" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje2" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje3" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje4" />
                                <telerik:AjaxUpdatedControl ControlID="ImageFechaFE" />
                                <telerik:AjaxUpdatedControl ControlID="ImageImporteFE" />
                                <telerik:AjaxUpdatedControl ControlID="ImageFechaCz" />
                                <telerik:AjaxUpdatedControl ControlID="ImageImporteCz" />
                                <telerik:AjaxUpdatedControl ControlID="ImageConceptoFE" />
                                <telerik:AjaxUpdatedControl ControlID="ImageConceptoCz" />
                                <telerik:AjaxUpdatedControl ControlID="ImageClienteFE" />
                                <telerik:AjaxUpdatedControl ControlID="ImageClienteCz" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                    </AjaxSettings>                                
                </telerik:RadAjaxManager>
                <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" Runat="server" 
                    height="75px" width="75px" HorizontalAlign="Center" Transparency="3" 
                    CssClass="LoadingPanel">
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
        .auto-style1 {
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
            width: 99%;
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

    .RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}.RadInput_Default{font:12px "segoe ui",arial,sans-serif}.RadInput{vertical-align:middle}
        
        </style>

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
