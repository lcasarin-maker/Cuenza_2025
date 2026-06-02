<%@ Page Language="vb" AutoEventWireup="false" CodeFile="PronosticoProgramaAgregar.aspx.vb" Inherits="PronosticoProgramaAgregar" MasterPageFile="~/MasterPageCuenza.Master"%>

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
                                ForeColor="White" Text="Agregar Pronóstico"></asp:Label>
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
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxClave" Runat="server" ReadOnly="True" Width="100px" Enabled="True">
                                                                    <NumberFormat ZeroPattern="n" DecimalDigits="0"></NumberFormat>
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:50%; text-align:right; padding-right:30px;">
                                                                <asp:CheckBox ID="CheckBoxGasto" runat="server" Font-Size="Small" ForeColor="Black" Text="Gasto" Visible="False" />
                                                            </td>
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
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxImporte" Runat="server" Width="129px" MinValue="0" TabIndex="10"></telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:31%; text-align:right; padding-right:5px;">
                                                                <asp:Label ID="Label4" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Importe en pagos"></asp:Label>
                                                            </td>
                                                            <td style="width:34%">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxImportePagosT" Runat="server" Width="129px" MinValue="0" TabIndex="10" ReadOnly="True"></telerik:RadNumericTextBox>
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
                                                    <telerik:RadComboBox ID="RadComboBoxLineaServicio" Runat="server" AutoPostBack="True" Skin="Default" Width="98%" TabIndex="1"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label85" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Tipo de moneda"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadComboBox ID="RadComboBoxTipoMoneda" Runat="server" Width="129px" Skin="Default" TabIndex="12" AutoPostBack="true"></telerik:RadComboBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label15" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="¿Quién factura?"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxQuienFactura" Runat="server" Skin="Default" Width="98%" TabIndex="2" AutoPostBack="true"></telerik:RadComboBox>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label19" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Detalle"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxDetalle" Runat="server" Width="98%" TabIndex="13" MaxLength="50"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style8">
                                                    <asp:Label ID="Label16" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Cliente" Width="80px"></asp:Label>
                                                </td>
                                                <td class="auto-style9">
                                                    <telerik:RadComboBox ID="RadComboBoxCliente" Runat="server" Skin="Default" Width="98%" EnableLoadOnDemand="True" DataTextField="nombre_cliente" DataValueField="id_cliente" AutoPostBack="true" OnItemsRequested="RadComboBoxCliente_ItemsRequested" TabIndex="3"></telerik:RadComboBox>
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
                                                    <telerik:RadComboBox ID="RadComboBoxServicio" Runat="server" Skin="Default" Width="98%" TabIndex="4"></telerik:RadComboBox>
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
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td style="width:15%;">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAño1" Runat="server" Width="50px" MinValue="2000" TabIndex="5">
                                                                    <numberformat decimaldigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:15%;">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAño2" Runat="server" Width="50px" MinValue="2000" TabIndex="6">
                                                                    <numberformat decimaldigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:15%;">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAño3" Runat="server" Width="50px" MinValue="2000" TabIndex="7" style="margin-right: 0px">
                                                                    <numberformat decimaldigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:15%;">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAño4" Runat="server" Width="50px" MinValue="2000" TabIndex="8">
                                                                    <numberformat decimaldigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:40%;">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxAño5" Runat="server" Width="50px" MinValue="2000" TabIndex="9">
                                                                    <numberformat decimaldigits="0" GroupSeparator="" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style10">
                                                    <asp:Label ID="Label84" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Especificaciones del pago"></asp:Label>
                                                </td>
                                                <td class="auto-style11">
                                                    <telerik:RadTextBox ID="RadTextBoxEspecificaciones" Runat="server" Width="98%" Height="50px" TextMode="MultiLine" Skin="Sunset" TabIndex="16" MaxLength="50"></telerik:RadTextBox>
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
                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="White" Text="Captura de pagos"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color:#e1e1e1;">
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td class="auto-style12">
                                                    &nbsp;</td>
                                                <td class="auto-style13">
                                                    &nbsp;</td>
                                                <td class="auto-style14">
                                                    &nbsp;</td>
                                                <td class="auto-style14">
                                                    &nbsp;</td>
                                                <td class="auto-style14">
                                                    &nbsp;</td>
                                                <td class="auto-style15">
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style12">
                                                    <asp:Label ID="Label86" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="No. de pagos"></asp:Label>
                                                </td>
                                                <td class="auto-style13">
                                                    <asp:Label ID="Label2" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Folio"></asp:Label>
                                                </td>
                                                <td class="auto-style14">
                                                    <asp:Label ID="Label6" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Fecha de facturación"></asp:Label>
                                                </td>
                                                <td class="auto-style14">
                                                    <asp:Label ID="Label7" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Fecha de pago"></asp:Label>
                                                </td>
                                                <td class="auto-style14">
                                                    <asp:Label ID="Label8" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Importe del pago"></asp:Label>
                                                </td>
                                                <td class="auto-style15">
                                                    <asp:Label ID="Label9" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Importe en letra"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style12">
                                                    <table cellpadding="0" cellspacing="0" class="auto-style1">
                                                        <tr>
                                                            <td style="width:40%">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxNoPagos1" Runat="server" Width="89%" MinValue="0" ReadOnly="True">
                                                                    <numberformat decimaldigits="0" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                            <td style="width:13%">
                                                                <asp:Label ID="Label87" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="de"></asp:Label>
                                                            </td>
                                                            <td style="width:47%">
                                                                <telerik:RadNumericTextBox ID="RadNumericTextBoxNoPagos2" Runat="server" Width="86%" MinValue="1" AutoPostBack="True" MaxValue="50" TabIndex="17">
                                                                    <numberformat decimaldigits="0" />
                                                                </telerik:RadNumericTextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="auto-style13">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxFolio" Runat="server" Width="90%" MinValue="0" ReadOnly="True">
                                                        <numberformat decimaldigits="0" />
                                                    </telerik:RadNumericTextBox>
                                                </td>
                                                <td class="auto-style14">
                                                    <telerik:RadDatePicker ID="RadDatePickerFechaFacturacion" Runat="server" Culture="es-MX" MinDate="2008-01-01" Skin="Default" Width="90%" TabIndex="18" AutoPostBack="True">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                                                            <SpecialDays> 
                                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="Orange"/>  
                                                            </SpecialDays>
                                                        </Calendar>
                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="18"></DateInput>
                                                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="18"></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td class="auto-style14">
                                                    <telerik:RadDatePicker ID="RadDatePickerFechaPago" Runat="server" Culture="es-MX" MinDate="2008-01-01" Skin="Default" Width="90%" TabIndex="19" AutoPostBack="True">
                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False">
                                                            <SpecialDays> 
                                                                <telerik:RadCalendarDay Repeatable="Today" ItemStyle-BackColor="Orange"/>  
                                                            </SpecialDays>
                                                        </Calendar>
                                                        <DateInput DisplayDateFormat="dd/MM/yyyy" DateFormat="dd/MM/yyyy" LabelWidth="40%" TabIndex="19"></DateInput>
                                                        <DatePopupButton ImageUrl="" HoverImageUrl="" TabIndex="19"></DatePopupButton>
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td class="auto-style14">
                                                    <telerik:RadNumericTextBox ID="RadNumericTextBoxImportePago" Runat="server" Width="92%" MinValue="0" TabIndex="20"></telerik:RadNumericTextBox>
                                                </td>
                                                <td class="auto-style15">
                                                    <telerik:RadTextBox ID="RadNumericTextBoxImportePagoLetra" Runat="server" Width="94%" TabIndex="21" MaxLength="50"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table cellpadding="0" cellspacing="0" class="auto-style1">
                                            <tr>
                                                <td style="padding-left:7px;width: 24%;height: 10px;text-align: left;vertical-align: bottom;">
                                                </td>
                                                <td style="padding-left:7px;width: 76%;height: 10px;text-align: left;vertical-align: bottom;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:7px;width: 24%;height: 20px;text-align: left;vertical-align: bottom;">
                                                </td>
                                                <td style="padding-left:3px; width: 76%;height: 20px;text-align: left;vertical-align: bottom;">
                                                    <asp:Label ID="Label10" runat="server" Font-Names="Arial Narrow" Font-Size="Small" Text="Concepto"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:7px;width: 24%;height: 20px;text-align: left;vertical-align: bottom;">
                                                    <asp:Panel ID="PanelActPagos1" runat="server">
                                                        <telerik:RadToolBar ID="RadToolBarAgregarPagos" Runat="server" Skin="Black" TabIndex="23">
                                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                                            <Items>
                                                                <telerik:RadToolBarButton runat="server" Text="Agregar" ToolTip="Agregar pago capturado">
                                                                </telerik:RadToolBarButton>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                        <telerik:RadToolBar ID="RadToolBarModificarPagos" Runat="server" Skin="Black" TabIndex="23">
                                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                                            <Items>
                                                                <telerik:RadToolBarButton runat="server" Text="Modificar" ToolTip="Modificar pago seleccionado">
                                                                </telerik:RadToolBarButton>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                        <telerik:RadToolBar ID="RadToolBarEliminarPagos" Runat="server" Skin="Black" TabIndex="23" OnClientButtonClicking="onClientButtonClicking" OnButtonClick="ButtonEliminar_Click">
                                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                                            <Items>
                                                                <telerik:RadToolBarButton runat="server" Text="Eliminar" ToolTip="Eliminar pago seleccionado">
                                                                </telerik:RadToolBarButton>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </asp:Panel>
                                                    <asp:Panel ID="PanelActPagos2" runat="server" Visible="False">
                                                        <telerik:RadToolBar ID="RadToolBarGrabarPagos" Runat="server" Skin="Black" TabIndex="23">
                                                            <CollapseAnimation Duration="200" Type="OutQuint" />
                                                            <Items>
                                                                <telerik:RadToolBarButton runat="server" Text="Aceptar" ToolTip="Grabar cambios del pago seleccionado">
                                                                </telerik:RadToolBarButton>
                                                                <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="Cancelar cambios del pago seleccionado">
                                                                </telerik:RadToolBarButton>
                                                            </Items>
                                                        </telerik:RadToolBar>
                                                    </asp:Panel>
                                                </td>
                                                <td style="padding-left:3px; width: 76%;height: 20px;text-align: left;vertical-align: top;">
                                                    <telerik:RadTextBox ID="RadTextBoxConcepto" Runat="server" Height="80px" TextMode="MultiLine" Width="97%" TabIndex="22" MaxLength="1000"></telerik:RadTextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left:7px;width: 24%;height: 10px;text-align: left;vertical-align: bottom;">
                                                    &nbsp;</td>
                                                <td style="padding-left:7px;width: 76%;height: 10px;text-align: left;vertical-align: bottom;">
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
                                                                        <telerik:GridBoundColumn DataField="folio_factura"             HeaderStyle-Width="90px"  HeaderText="Folio de factura"                UniqueName="folio_factura">             
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

    <script lang="JavaScript">
        function confirmAspUpdatePanelPostback(button) {
            function aspUpdatePanelCallbackFn(arg) {
                if (arg) {
                    __doPostBack(button.name, "");
                }
            }
            radconfirm("¿Está seguro que desea eliminar el pago seleccionado?", aspUpdatePanelCallbackFn, 330, 180, null, "Confirm");
        }

        function RadConfirm(sender, args) {
            var callBackFunction = Function.createDelegate(sender, function (shouldSubmit) {
                if (shouldSubmit) {
                    this.click();
                }
            });
            var text = "Are you sure you want to submit the page?";
            radconfirm(text, callBackFunction, 300, 160, null, "RadConfirm");
            args.set_cancel(true);
        }

        function onClientButtonClicking(sender, args) {
            
            var grid = $find("<%=RadGridPagos.ClientID%>");
            var MasterTable = grid.get_masterTableView();
            var tRows = MasterTable.get_dataItems();
            var selectedRows = MasterTable.get_selectedItems();

            if (tRows.length == 0) {
                alert('No existen pagos capturados.');
                return args.set_cancel(true);
            } else {
                if (selectedRows.length == 0) {
                    alert('Para eliminar pagos favor de seleccionar un registro.');
                    return args.set_cancel(true);
                } else {
                    var radToolBar = $find("<%=RadToolBarEliminarPagos.ClientID%>");
                    var button = radToolBar.findItemByText("Eliminar");
                    var ok = confirm("¿Está seguro que desea eliminar el pago seleccionado?");
                    if (ok)
                        return true;
                    else
                        return args.set_cancel(true);
                }
            }
        }
    </script>
</asp:Content>
