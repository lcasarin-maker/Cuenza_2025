<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PronosticoProgramaCancelar.aspx.vb" Inherits="PronosticoProgramaCancelar" MasterPageFile="~/MasterPageCuenza.Master"%>

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
                                ForeColor="White" Text="Cancelar Pronóstico"></asp:Label>
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
                                    <telerik:RadToolBarButton runat="server" Text="Enviar" ToolTip="Cancelar el registro en la base de datos">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="No grabar los cambios del registro">
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
                                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Datos generales"></asp:Label>
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
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxClave" Runat="server" ReadOnly="True" Width="100px" Enabled="False">
                                                                    <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                                                                    <DisabledStyle BackColor="#F2F1F1" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:50%; text-align:right; padding-right:30px;">
                                                                &nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label17" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Importe"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td style="width:35%">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxImporte" Runat="server" Width="129px" MinValue="0" TabIndex="10" Enabled="False">
                                                                    <NumberFormat ZeroPattern="n"></NumberFormat>
                                                                    <DisabledStyle BackColor="#F2F1F1" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:31%; text-align:right; padding-right:5px;">
                                                                <asp:Label ID="Label4" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Importe en pagos"></asp:Label>
                                                            </td>
                                                            <td style="width:34%">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxImportePagosT" Runat="server" Width="129px" MinValue="0" TabIndex="10" ReadOnly="True" Enabled="False">
                                                                    <NumberFormat ZeroPattern="n"></NumberFormat>
                                                                    <DisabledStyle BackColor="#F2F1F1" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label14" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Línea de servicio"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxLineaServicio" Runat="server" AutoPostBack="True" Skin="Default" Width="98%" TabIndex="1" Enabled="False"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label85" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Tipo de moneda"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadComboBox ID="RadComboBoxTipoMoneda" Runat="server" Width="129px" Skin="Default" TabIndex="12" Enabled="False"></telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label15" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="¿Quién factura?"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxQuienFactura" Runat="server" Skin="Default" Width="98%" TabIndex="2" Enabled="False"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label19" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Detalle"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxDetalle" Runat="server" Width="98%" TabIndex="13" Enabled="False">
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label16" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Cliente" Width="80px"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxCliente" Runat="server" Skin="Default" Width="98%" TabIndex="3" Enabled="False"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label20" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Estatus"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadComboBox ID="RadComboBoxStatus" Runat="server" Width="98%" Skin="Default" AutoPostBack="True" TabIndex="14"></telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label81" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Servicio" Width="80px"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxServicio" Runat="server" Skin="Default" Width="98%" TabIndex="4" Enabled="False"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label83" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Estatus descripción"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadComboBox ID="RadComboBoxStatusDesc" Runat="server" Width="98%" Skin="Default" TabIndex="15"></telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label82" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Años de servicio"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAño1" Runat="server" Width="50px" MinValue="0" TabIndex="5" Enabled="False">
                                                        <numberformat decimaldigits="0" GroupSeparator="" />
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAño2" Runat="server" Width="50px" MinValue="0" TabIndex="6" Enabled="False">
                                                        <numberformat decimaldigits="0" GroupSeparator="" />
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAño3" Runat="server" Width="50px" MinValue="0" TabIndex="7" Enabled="False">
                                                        <numberformat decimaldigits="0" GroupSeparator="" />
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAño4" Runat="server" Width="50px" MinValue="0" TabIndex="8" Enabled="False">
                                                        <numberformat decimaldigits="0" GroupSeparator="" />
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadNumericTextBox>
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxAño5" Runat="server" Width="50px" MinValue="0" TabIndex="9" Enabled="False">
                                                        <numberformat decimaldigits="0" GroupSeparator="" />
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label84" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Motivo de la cancelación"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxMotivoCancelacion" Runat="server" Width="98%" Height="50px" TextMode="MultiLine" Skin="Sunset" TabIndex="16" Enabled="True" MaxLength="50">
                                                        <DisabledStyle BackColor="#F2F1F1" />
                                                    </telerik:RadTextBox>
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
                <table cellpadding="0" cellspacing="0" class="auto-style16" style="background-color:#e1e1e1;">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" class="auto-style1" style="border: 1px solid #AAAAAA">
                                <tr>
                                    <td style="height:25px; padding-left:7px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Detalle de pagos"></asp:Label>
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
                                                    <telerik:RadSplitter ID="RadSplitter1" Height="200px" Width="100%" runat="server" Orientation="Horizontal">
                                                        <telerik:RadPane ID="gridPane" runat="server" Height="200px" Width="100%" Scrolling="None">
                                                            <telerik:RadGrid ID="RadGridPagos" runat="server" CellSpacing="0" GridLines="None" Skin="Sunset" Height="200px" Width="100%" AutoGenerateColumns="False">
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
                                                                        <telerik:GridBoundColumn DataField="no_pago"             HeaderStyle-Width="80px"  HeaderText="No. de pago"                UniqueName="no_pago">             
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="90px" /> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="fecha_fact" HeaderStyle-Width="120px" HeaderText="Fecha de facturación" UniqueName="fecha_fact" DataFormatString="{0:d}"> 
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="120px"/> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="fecha_pago"        HeaderStyle-Width="90px"  HeaderText="Fecha de pago"        UniqueName="fecha_pago" DataFormatString="{0:d}">        
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="90px" /> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="importe"           HeaderStyle-Width="100px" HeaderText="Importe"              UniqueName="importe" DataFormatString="{0:#,##0.00}">           
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="90px" /> <ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="concepto"          HeaderStyle-Width="500px" HeaderText="Concepto"             UniqueName="concepto">          
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="400px"/> <ItemStyle Wrap="True" /></telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="importe_letra"     HeaderStyle-Width="200px" HeaderText="Importe en letra"     UniqueName="importe_letra">     
                                                                            <ColumnValidationSettings>
                                                                                <ModelErrorMessage Text="" />
                                                                            </ColumnValidationSettings>
                                                                            <HeaderStyle Width="150px"/> <ItemStyle Wrap="True" /></telerik:GridBoundColumn>
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
                                                    &nbsp;
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
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatus" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatusDesc" />
                                <telerik:AjaxUpdatedControl ControlID="RadTextBoxMotivoCancelacion" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxLineaServicio">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxClave" />
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxServicio" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxCliente">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxCliente" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxStatus">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxStatusDesc" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="CheckBoxDlls">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxDlls" />
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