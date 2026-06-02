<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Alertas.aspx.vb" Inherits="Alertas" MasterPageFile="~/MasterPageCuenza.Master" %>

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
                                ForeColor="White" Text="Alertas"></asp:Label>
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
                        <td class="auto-style11">
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
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter1" Height="600px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="gridPane" runat="server" Height="600px" Scrolling="None">
                        <telerik:RadGrid ID="RadGrid1" 
                            runat="server" 
                            DataSourceID="SqlDataSource1"
                            GridLines="None" 
                            Height="600px" 
                            Skin="Sunset" 
                            Width="1000px" 
                            CellSpacing="0" 
                            Culture="es-ES" 
                            AllowFilteringByColumn="True" 
                            AutoGenerateColumns="False"
                            ShowFooter="True">
                            <groupingsettings casesensitive="false" />
                            <MasterTableView 
                                DataKeyNames="id_alerta"
                                TableLayout="Fixed" 
                                NoMasterRecordsText="No hay registros que mostrar."
                                NoDetailRecordsText="No hay registros que mostrar."
                                ShowHeader="True"
                                ShowGroupFooter="True">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Clave"       UniqueName="id_alerta"   DataField="id_alerta"   HeaderStyle-Width="100px" FilterControlWidth="60px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Tipo"        UniqueName="tipo_alerta" DataField="tipo_alerta" HeaderStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Descripción" UniqueName="descripcion" DataField="descripcion" HeaderStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Detalle"     UniqueName="detalle"     DataField="detalle"     HeaderStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Usuario 1"   UniqueName="Usuario1"    DataField="Usuario1"    HeaderStyle-Width="100px" FilterControlWidth="60px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Usuario 2"   UniqueName="Usuario2"    DataField="Usuario2"    HeaderStyle-Width="100px" FilterControlWidth="60px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Usuario 3"   UniqueName="Usuario3"    DataField="Usuario3"    HeaderStyle-Width="100px" FilterControlWidth="60px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                </Columns>
                               <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                    </EditColumn>
                                </EditFormSettings>
                                <ItemStyle Wrap="True" />
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <HeaderStyle Wrap="False" />
                            </MasterTableView>
                            <ExportSettings>
                                <Excel Format="ExcelML" />
                            </ExportSettings>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Resizing AllowColumnResize="True" AllowRowResize="True" />
                            </ClientSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" 
                    SelectCommand="SELECT * FROM Alertas ORDER BY id_alerta">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarActualizar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            width: 500px;
        }
        .auto-style4
        {
            width: 100%;
            height: 35px;
        }
        .auto-style11
        {
            width: 210px;
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

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
