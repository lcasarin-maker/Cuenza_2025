<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FacturacionImportarPagos.aspx.vb" Inherits="FacturacionImportarPagos" MasterPageFile="~/MasterPageCuenza.Master" %>

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
                                ForeColor="White" Text="Importar pagos"></asp:Label>
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
                                    <telerik:RadToolBarButton runat="server" Text="Nuevo" ToolTip="Efectuar nueva carga de pagos">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="Cancelar importar pagos">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td style="width:125px;">
                            <telerik:RadToolBar ID="RadToolBarReportes" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Generar Reporte" ToolTip="Generar reporte en excel">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
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
            <td class="auto-style3">
                <asp:Label ID="LabelError" runat="server" Font-Names="Arial Narrow" Font-Size="Small" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <table cellpadding="0" cellspacing="0" class="auto-style16" style="border: 1px solid #C0C0C0; background-color:#e1e1e1;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="auto-style1" style="border: 1px solid #AAAAAA">
                                <tr>
                                    <td style="height:25px; padding-left:7px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Seleccionar archivo"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color:#e1e1e1;">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td class="auto-style8">
                                                    <telerik:RadUpload ID="RadUploadExcel" Runat="server" ControlObjectsVisibility="None" Culture="Spanish (Mexico)" EnableTheming="True" Height="20px" InputSize="80" MaxFileInputsCount="10" MaxFileSize="200000000" OnClientFileSelected="OnClientFileSelectedSUA" Skin="Sunset" Width="80%">
                                                        <localization select="Cargar" />
                                                    </telerik:RadUpload>
                                                </td>
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
            <td class="auto-style3">
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <table cellpadding="0" cellspacing="0" style="width:210px; background-color:#e1e1e1; height:30px; padding-left:7px; border: 1px solid #AAAAAA">
                    <tr>
                        <td>
                            <asp:Label ID="Label13" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Total de registros"></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="RadNumericTextBoxTotal" Runat="server" ReadOnly="True" Width="100px" Enabled="True">
                                <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                            </telerik:RadNumericTextBox>
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
                <table cellpadding="0" cellspacing="0" class="auto-style16" style="background-color:#e1e1e1;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="auto-style1" style="border: 1px solid #AAAAAA">
                                <tr>
                                    <td style="height:25px; padding-left:7px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Listado de facturas leídas"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color:#e1e1e1;">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td class="auto-style12">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td style="padding-left:5px; padding-right:5px;">
                                                    <telerik:RadSplitter ID="RadSplitter1" Height="400px" Width="100%" runat="server" Orientation="Horizontal">
                                                        <telerik:RadPane ID="gridPane" runat="server" Height="400px" Width="100%" Scrolling="None">
                                                            <telerik:RadGrid ID="RadGridPagos" runat="server" CellSpacing="0" GridLines="None" Skin="Sunset" Height="400px" Width="100%" AutoGenerateColumns="False" AllowFilteringByColumn="True">
                                                                <GroupingSettings CaseSensitive="false" />
                                                                <exportsettings>
                                                                    <excel format="ExcelML" />
                                                                </exportsettings>
                                                                <ClientSettings>
                                                                    <Selecting AllowRowSelect="True" />
                                                                    <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                                                </ClientSettings>
                                                                <MasterTableView NoDetailRecordsText="No hay registros que mostrar." NoMasterRecordsText="No hay registros que mostrar.">
                                                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                                                        <HeaderStyle Width="20px" />
                                                                    </RowIndicatorColumn>
                                                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True" Created="True">
                                                                        <HeaderStyle Width="20px" />
                                                                    </ExpandCollapseColumn>
                                                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="tipo_factura"   HeaderStyle-Width="100px" HeaderText="Tipo de factura"      UniqueName="tipo_factura"   FilterControlWidth="60px">                                 <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="folio_factura"  HeaderStyle-Width="100px" HeaderText="Folio de factura"     UniqueName="folio_factura"  FilterControlWidth="60px">                                 <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="fecha_fact"     HeaderStyle-Width="130px" HeaderText="Fecha de facturación" UniqueName="fecha_fact"     FilterControlWidth="90px" DataFormatString="{0:d}">        <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="fecha_pago"     HeaderStyle-Width="130px" HeaderText="Fecha de pago"        UniqueName="fecha_pago"     FilterControlWidth="90px" DataFormatString="{0:d}">        <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="fecha_deposito" HeaderStyle-Width="130px" HeaderText="Fecha de depósito"    UniqueName="fecha_deposito" FilterControlWidth="90px" DataFormatString="{0:d}">        <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="importe"        HeaderStyle-Width="130px" HeaderText="Importe en Cuenza"    UniqueName="importe"        FilterControlWidth="90px" DataFormatString="{0:#,##0.00}"> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="importe_pago"   HeaderStyle-Width="130px" HeaderText="Importe del pago"     UniqueName="importe_pago"   FilterControlWidth="90px" DataFormatString="{0:#,##0.00}"> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="concepto"       HeaderStyle-Width="600px" HeaderText="Concepto"             UniqueName="concepto"       FilterControlWidth="560px">                                <ItemStyle Wrap="True" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="estatus"        HeaderStyle-Width="600px" HeaderText="Estatus"              UniqueName="estatus"        FilterControlWidth="560px">                                <ItemStyle Wrap="True" /></telerik:GridBoundColumn>
                                                                    </Columns>
                                                                    <EditFormSettings>
                                                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                                                        </EditColumn>
                                                                    </EditFormSettings>
                                                                    <PagerStyle PageSizeControlType="RadComboBox" />
                                                                </MasterTableView>
                                                                <PagerStyle PageSizeControlType="RadComboBox" />
                                                                <FilterMenu EnableImageSprites="False">
                                                                </FilterMenu>
                                                            </telerik:RadGrid>
                                                        </telerik:RadPane>
                                                    </telerik:RadSplitter>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td class="auto-style12">
                                                    <asp:Button ID="ButtonLeerArchivo" runat="server" CssClass="auto-style17" />
                                                </td>
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
                <table cellpadding="0" cellspacing="0" style="width: 99%; border: 1px solid #C0C0C0; background-color:#e1e1e1; padding-left:7px;">
                    <tr>
                        <td>
                            <asp:Label ID="Label14" runat="server" Font-Names="Arial Narrow" Font-Size="14pt" Text="Los importes incluyen IVA."></asp:Label>
                        </td>
                    </tr>
                </table>
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
                                <telerik:AjaxUpdatedControl ControlID="RadUploadExcel" />
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxTotal" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGridPagos">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
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
    <script type="text/javascript">
        function OnClientFileSelectedSUA() {
            var upload = $find("<%= RadUploadExcel.ClientID%>");
            var fileInputs = upload.getFileInputs();

            for (var i = 0; i < fileInputs.length; i++) {
                if (fileInputs[i].value != "") {
                    upload.text = fileInputs[i].value;
                    var btn1 = document.getElementById("<%= ButtonLeerArchivo.ClientID%>");
                    btn1.click();
                    return true;
                }
            }
            alert("Por favor seleccione un archivo");
            return false;
        }
    </script> 
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
            width: 130px;
        }
        .auto-style8
        {
            width: 100%;
            vertical-align: middle;
            height: 50px;
            padding-left: 7px;
        }
        .auto-style12
        {
            padding-left:7px;
            width: 13%;
            height: 20px;
            text-align: left;
            vertical-align: bottom;
        }
        .auto-style16 
        {
            width: 99%;
        }
        .auto-style17 {
            width: 0px;
            height: 0px;
            background-color:transparent;
            border-style:none;
            Border-Width:0px;
        }
    </style>

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>