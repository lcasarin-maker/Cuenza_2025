<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PronosticoProgramaV2.aspx.vb" Inherits="PronosticoProgramaV2" MasterPageFile="~/MasterPageCuenza.Master" %>

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
                                ForeColor="White" Text="Programas por Cliente"></asp:Label>
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
                                    <telerik:RadToolBarButton runat="server" Text="Generar Reporte" ToolTip="Generar reporte en excel de la información mostrada">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;</td>
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
            <td class="auto-style3" style="height:25px; padding-left:4px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="White" 
                    Text=" Seleccionar parámetros para mostrar información"> </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3" style="border-color: #AAAAAA; border-style: solid; border-width: 1px 1px 2px 1px; background-color:#e1e1e1;">
                <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border-style: solid solid none none; border-width: 1px; border-color: #AAAAAA; padding-left:4px; width:220px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Año del servicio"></asp:Label>
                        <br />
                            <telerik:RadNumericTextBox ID="RadNumericTextBoxAño1" Runat="server" Width="50px" MinValue="1" TabIndex="5">
                                <numberformat decimaldigits="0" GroupSeparator="" />
                            </telerik:RadNumericTextBox>
                        <br />
                        <br />
                        <br />
                        <telerik:RadToolBar ID="RadToolBarMostrar" Runat="server" Skin="Black">
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                            <Items>
                                <telerik:RadToolBarButton runat="server" Text="Mostrar" ToolTip="Mostrar información de acuerdo a los parámetros seleccionados">
                                </telerik:RadToolBarButton>
                            </Items>
                        </telerik:RadToolBar>
                    </td>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:2px; width:700px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Cliente"></asp:Label> 
                        <br />
                            <telerik:RadComboBox ID="RadComboBoxCliente" Runat="server" Skin="Default" Width="98%" EnableLoadOnDemand="True" DataTextField="nombre_cliente" DataValueField="id_cliente" AutoPostBack="true" OnItemsRequested="RadComboBoxCliente_ItemsRequested" TabIndex="3"></telerik:RadComboBox>
                        <br />
                        <br />
                        <br />
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
                <asp:Label ID="lblMensaje" runat="server" BackColor="#FFFF66" Font-Bold="True" Font-Names="Arial Narrow" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="lblStatus" runat="server" Font-Bold="True" ForeColor="Blue" Font-Names="Arial Narrow"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Blue" Font-Names="Arial Narrow">Pronósticos y Programas</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter2" Height="200px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="RadPane1" runat="server" Height="200px" Scrolling="None">
                        <telerik:RadGrid ID="RadGridProgramas" 
                            runat="server" 
                            DataSourceID="SqlDataSource1"
                            GridLines="None" 
                            Height="200px" 
                            Skin="Sunset" 
                            Width="1000px" 
                            CellSpacing="0" 
                            Culture="es-ES" 
                            AllowFilteringByColumn="True" 
                            AutoGenerateColumns="False"
                            ShowFooter="True"
                            OnSelectedIndexChanged="RadGridProgramas_SelectedIndexChanged">
                            <MasterTableView 
                                DataKeyNames="id_ingreso_pk"
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
                                    <telerik:GridBoundColumn HeaderText="Clave"                   UniqueName="id_ingreso"          DataField="id_ingreso"          HeaderStyle-Width="150px" ItemStyle-Width="150px" FilterControlWidth="110px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Autorizado"              UniqueName="autorizado"          DataField="autorizado"          HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estatus"                 UniqueName="Estatus"             DataField="Estatus"             HeaderStyle-Width="250px" ItemStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estatus Descripción"     UniqueName="EstatusDesc"         DataField="EstatusDesc"         HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"                                                                                   FooterText="" FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Importe"                 UniqueName="importe"             DataField="importe"             HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" FooterText=""        FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Línea de servicio"       UniqueName="nombre_linea"        DataField="nombre_linea"        HeaderStyle-Width="250px" ItemStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Socio"                   UniqueName="socio"               DataField="socio"               HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Gerente"                 UniqueName="Gerente"             DataField="Gerente"             HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="¿Quién Factura?"         UniqueName="nombre_empresa"      DataField="nombre_empresa"      HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Cliente"                 UniqueName="nombre_cliente"      DataField="nombre_cliente"      HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Servicio"                UniqueName="nombre_servicio"     DataField="nombre_servicio"     HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Años"                    UniqueName="años"                DataField="años"                HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Detalle"                 UniqueName="detalle"             DataField="detalle"             HeaderStyle-Width="400px" ItemStyle-Width="400px" FilterControlWidth="360px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Tipo de Moneda"          UniqueName="TipoMoneda"          DataField="TipoMoneda"          HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total de pagos"          UniqueName="total_pagos"         DataField="total_pagos"         HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Especificación del pago" UniqueName="especificacion_pago" DataField="especificacion_pago" HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="id_ingreso_pk"           UniqueName="id_ingreso_pk"       DataField="id_ingreso_pk"       HeaderStyle-Width="0px"   ItemStyle-Width="0px"   FilterControlWidth="0px"   HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridNumericColumn HeaderText="id_linea_servicio"     UniqueName="id_linea_servicio"   DataField="id_linea_servicio"   HeaderStyle-Width="0px"   ItemStyle-Width="0px"   FilterControlWidth="0px"   HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridNumericColumn>
                                    <telerik:GridBoundColumn HeaderText="Motivo de cancelación"   UniqueName="motivo_cancelacion"  DataField="motivo_cancelacion"  HeaderStyle-Width="250px" ItemStyle-Width="250px" FilterControlWidth="360px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha de cancelación"    UniqueName="fecha_cancelacion"   DataField="fecha_cancelacion"   HeaderStyle-Width="150px" ItemStyle-Width="150px" FilterControlWidth="100px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
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
                            <ClientSettings EnablePostBackOnRowClick="True">
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
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
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="Label4" runat="server" Font-Bold="True" ForeColor="Blue" Font-Names="Arial Narrow">Datos Generales</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter1" Height="300px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="gridPane" runat="server" Height="300px" Scrolling="None">
                        <telerik:RadGrid ID="RadGridGenerales" 
                            runat="server" 
                            DataSourceID="SqlDataSource2"
                            CellSpacing="0" 
                            GridLines="None" 
                            Skin="Sunset" 
                            Height="300px" 
                            Width="1000px" 
                            Culture="es-ES" 
                            AutoGenerateColumns="False">
                            <MasterTableView 
                                NoMasterRecordsText="No hay registros que mostrar."
                                NoDetailRecordsText="No hay registros que mostrar.">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column"></RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True" Created="True"></ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="Columna" UniqueName="Columna" DataField="Columna" HeaderStyle-Width="20%" ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle HorizontalAlign="Center" Width="20%" /><ItemStyle Width="20%" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Dato"    UniqueName="Dato"    DataField="Dato"    HeaderStyle-Width="80%" ItemStyle-Width="80%" HeaderStyle-HorizontalAlign="Center"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle HorizontalAlign="Center" Width="80%" /><ItemStyle Width="80%" /></telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings><ItemStyle Wrap="True" />
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <HeaderStyle Wrap="False" />
                            </MasterTableView>
                            <ExportSettings>
                                <Excel Format="ExcelML" />
                            </ExportSettings>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
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
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Blue" Font-Names="Arial Narrow">Detalle de Pagos</asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter3" Height="400px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="RadPane2" runat="server" Height="400px" Scrolling="None">
                        <telerik:RadGrid ID="RadGridPagos" 
                            runat="server" 
                            DataSourceID="SqlDataSource3" 
                            CellSpacing="0" 
                            GridLines="None" 
                            Skin="Sunset" 
                            Height="400px" 
                            Width="100%" 
                            AutoGenerateColumns="False">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <MasterTableView NoDetailRecordsText="No hay registros que mostrar." 
                                NoMasterRecordsText="No hay registros que mostrar.">
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                                    Visible="True" 
                                    Created="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <Columns>
                                    <telerik:GridBoundColumn DataField="no_pago"       HeaderStyle-Width="75px"  HeaderText="No. de pago"          UniqueName="no_pago"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="75px" /><ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="folio_factura" HeaderStyle-Width="95px"  HeaderText="Folio de factura"     UniqueName="folio_factura"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="95px" /><ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fecha_fact"    HeaderStyle-Width="120px" HeaderText="Fecha de facturación" UniqueName="fecha_fact" DataFormatString="{0:d}"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="120px"/><ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="fecha_pago"    HeaderStyle-Width="90px"  HeaderText="Fecha de pago"        UniqueName="fecha_pago" DataFormatString="{0:d}"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="90px" /><ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="importe"       HeaderStyle-Width="100px" HeaderText="Importe (sin IVA)"    UniqueName="importe" DataFormatString="{0:#,##0.00}"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="100px" /><ItemStyle Wrap="False" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="concepto"      HeaderStyle-Width="390px" HeaderText="Concepto"             UniqueName="concepto"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="390px"/><ItemStyle Wrap="True" /></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn DataField="tipo_factura"  HeaderStyle-Width="90px"  HeaderText="Tipo de factura"      UniqueName="tipo_factura"><ColumnValidationSettings><ModelErrorMessage Text="" /></ColumnValidationSettings><HeaderStyle Width="90px"/><ItemStyle Wrap="True" /></telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                    <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>
                                <PagerStyle PageSizeControlType="RadComboBox" />
                            </MasterTableView>
                            <ExportSettings>
                                <Excel Format="ExcelML" />
                            </ExportSettings>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid></telerik:RadPane>
                </telerik:RadSplitter>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:SqlDataSource ID="SqlDataSourceLineas" runat="server" ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" SelectCommand="SELECT RIGHT ('0' + CAST(id_linea_servicio AS VARCHAR), 2) + ' ' + nombre_linea AS [linea_servicio] FROM LineasServicio WHERE (ss = 1) ORDER BY id_linea_servicio"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" 
                    SelectCommand="SELECT Ingresos.id_ingreso, Ingresos.autorizado, TiposStatusCuenza.descripcion AS Estatus, TiposStatusDescCuenza.descripcion AS EstatusDesc, importe = CASE WHEN (Ingresos.id_tipo_moneda = 1 OR Ingresos.id_tipo_moneda = 2) THEN Ingresos.importe ELSE 0 END, LineasServicio.nombre_linea, LineasServicio.socio AS Socio, LineasServicio.Gerente AS Gerente, Empresas.nombre_empresa, CLIENTES.nombre_cliente, SERVICIOS.nombre_servicio, Ingresos.años, Ingresos.detalle, TiposMoneda.descripcion AS TipoMoneda, Ingresos.total_pagos, Ingresos.especificacion_pago, Ingresos.id_ingreso_pk, LineasServicio.id_linea_servicio, Ingresos.motivo_cancelacion, Ingresos.fecha_cancelacion FROM IngresosPagos
                                    INNER JOIN Ingresos              ON (IngresosPagos.id_ingreso_pk = Ingresos.id_ingreso_pk)
                                    INNER JOIN Empresas              ON Ingresos.id_empresa          = Empresas.id_empresa
                                    INNER JOIN CLIENTES              ON Ingresos.id_cliente          = CLIENTES.id_cliente
                                    INNER JOIN SERVICIOS             ON Ingresos.id_servicio         = SERVICIOS.id_servicio AND Ingresos.id_linea_servicio = SERVICIOS.id_linea_servicio
                                    INNER JOIN LineasServicio        ON Ingresos.id_linea_servicio   = LineasServicio.id_linea_servicio
                                    INNER JOIN TiposStatusCuenza     ON Ingresos.id_status           = TiposStatusCuenza.id_status
                                    INNER JOIN TiposStatusDescCuenza ON Ingresos.id_status_desc      = TiposStatusDescCuenza.id_status_desc
                                    INNER JOIN TiposMoneda           ON Ingresos.id_tipo_moneda      = TiposMoneda.id_tipo_moneda
                                    WHERE Ingresos.años LIKE '%' + @vAño + '%' AND CLIENTES.nombre_cliente LIKE '%' + @vCliente + '%'
                                    GROUP BY Ingresos.id_ingreso_pk, Ingresos.id_ingreso, Ingresos.id_tipo_moneda, Ingresos.id_status, LineasServicio.id_linea_servicio, LineasServicio.nombre_linea, LineasServicio.gerente, LineasServicio.socio, Empresas.nombre_empresa, CLIENTES.nombre_cliente, SERVICIOS.nombre_servicio, Ingresos.autorizado, TiposStatusCuenza.descripcion, TiposStatusDescCuenza.descripcion, Ingresos.importe, Ingresos.años, Ingresos.detalle, TiposMoneda.descripcion, Ingresos.total_pagos, Ingresos.especificacion_pago, Ingresos.motivo_cancelacion, Ingresos.fecha_cancelacion
                                    ORDER BY Empresas.nombre_empresa, LineasServicio.id_linea_servicio, Ingresos.id_ingreso">
                    <SelectParameters>
                        <asp:SessionParameter Name="vAño" SessionField="vAño" Type="String" />
                        <asp:SessionParameter Name="vCliente" SessionField="vCliente" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" 
                    SelectCommand="SELECT Columna, Dato
                                   FROM
                                       (SELECT Clave                    = CASE WHEN Ingresos.id_ingreso IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.id_ingreso) END
                                             , Autorizado               = CASE WHEN Ingresos.Autorizado IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), autorizado) END
                                             , Estatus                  = CASE WHEN TiposStatusCuenza.descripcion IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), TiposStatusCuenza.descripcion) END
                                             , [Estatus descripción]    = CASE WHEN TiposStatusDescCuenza.descripcion IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), TiposStatusDescCuenza.descripcion) END
                                             , Importe                  = CASE WHEN Ingresos.importe IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), CASE WHEN (Ingresos.id_tipo_moneda = 1 OR Ingresos.id_tipo_moneda = 2) THEN Ingresos.importe ELSE 0 END) END
                                             , [Linea de servicio]      = CASE WHEN LineasServicio.nombre_linea IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), CONVERT(NVARCHAR(MAX), LineasServicio.id_linea_servicio) + ' - ' + LineasServicio.nombre_linea) END
                                             , Socio                    = CASE WHEN LineasServicio.socio IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), LineasServicio.socio) END
                                             , Gerente                  = CASE WHEN LineasServicio.Gerente IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), LineasServicio.Gerente) END
                                             , [¿Quién factura?]        = CASE WHEN Empresas.nombre_empresa IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Empresas.nombre_empresa) END
                                             , Cliente                  = CASE WHEN CLIENTES.nombre_cliente IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), CONVERT(NVARCHAR(MAX), CLIENTES.id_cliente) + ' - ' + CLIENTES.nombre_cliente) END
                                             , Servicio                 = CASE WHEN SERVICIOS.nombre_servicio IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), SERVICIOS.nombre_servicio) END
            		                         , [Años del servicio]      = CASE WHEN Ingresos.años IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.años) END
		                                     , Detalle                  = CASE WHEN Ingresos.detalle IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.detalle) END
                                             , [Tipo de moneda]         = CASE WHEN TiposMoneda.descripcion IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), TiposMoneda.descripcion) END
            		                         , [Total de pagos]         = CASE WHEN Ingresos.total_pagos IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.total_pagos) END
		                                     , [Especificación de pago] = CASE WHEN Ingresos.especificacion_pago IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.especificacion_pago) END
                                             , [Motivo de cancelación]  = CASE WHEN Ingresos.motivo_cancelacion IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.motivo_cancelacion) END
                                             , [Fecha de cancelación]   = CASE WHEN Ingresos.fecha_cancelacion IS NULL THEN CONVERT(NVARCHAR(MAX), '') ELSE CONVERT(NVARCHAR(MAX), Ingresos.fecha_cancelacion) END
                                        FROM Ingresos
	                                    INNER JOIN Empresas              ON Ingresos.id_empresa          = Empresas.id_empresa
            	                        INNER JOIN CLIENTES              ON Ingresos.id_cliente          = CLIENTES.id_cliente
	                                    INNER JOIN SERVICIOS             ON Ingresos.id_servicio         = SERVICIOS.id_servicio AND Ingresos.id_linea_servicio = SERVICIOS.id_linea_servicio
	                                    INNER JOIN LineasServicio        ON Ingresos.id_linea_servicio   = LineasServicio.id_linea_servicio
	                                    INNER JOIN TiposStatusCuenza     ON Ingresos.id_status           = TiposStatusCuenza.id_status
            	                        INNER JOIN TiposStatusDescCuenza ON Ingresos.id_status_desc      = TiposStatusDescCuenza.id_status_desc
	                                    INNER JOIN TiposMoneda           ON Ingresos.id_tipo_moneda      = TiposMoneda.id_tipo_moneda
                                        WHERE id_ingreso_pk = @vid_ingreso_pk) P
                                    UNPIVOT (Dato FOR Columna IN (Clave, Autorizado, Estatus, [Estatus descripción], Importe, [Linea de servicio], Socio, Gerente, [¿Quién factura?], Cliente, Servicio, [Años del servicio], Detalle, [Tipo de moneda], [Total de pagos], [Especificación de pago], [Motivo de cancelación], [Fecha de cancelación])) AS UNPVT">
                    <SelectParameters>
                        <asp:SessionParameter Name="vid_ingreso_pk" SessionField="vid_ingreso_pk" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>"
                    SelectCommand="SELECT IngresosPagos.id_pago_pk
                                        , IngresosPagos.id_ingreso_pk
                                        , IngresosPagos.no_pago
                                        , IngresosPagos.folio_factura
                                        , fecha_fact = Convert(Nvarchar, IngresosPagos.fecha_fact,103)
                                        , fecha_pago = Convert(Nvarchar, IngresosPagos.fecha_pago,103)
                                        , IngresosPagos.importe AS importe
                                        , IngresosPagos.concepto
                                        , TiposFactura.descripcion AS tipo_factura
                                    FROM IngresosPagos 
                                    INNER JOIN TiposFactura ON (IngresosPagos.id_tipo_factura = TiposFactura.id_tipo_factura)
                                    WHERE IngresosPagos.id_ingreso_pk = @vid_ingreso_pk
                                    ORDER BY IngresosPagos.no_pago, IngresosPagos.folio_factura">
                    <SelectParameters>
                        <asp:SessionParameter Name="vid_ingreso_pk" SessionField="vid_ingreso_pk" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;
                <telerik:RadAjaxManager ID="RadAjaxManager2" runat="server">
                    <AjaxSettings>
                        <telerik:AjaxSetting AjaxControlID="RadComboBoxCliente">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadComboBoxCliente" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadNumericTextBoxAño1">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadNumericTextBoxAño1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGridProgramas">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGridGenerales" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadToolBarMostrar">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="lblStatus" />
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridProgramas" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridGenerales" LoadingPanelID="RadAjaxLoadingPanel1" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            width: 260px;
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

    .RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox{margin:0;padding:0;*zoom:1;display:-moz-inline-stack;display:inline-block;*display:inline;text-align:left;vertical-align:middle;_vertical-align:top;white-space:nowrap}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbReadOnly .rcbInputCellLeft{background-position:0 -88px}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbInputCellLeft{background-position:0 0}.RadComboBox_Default .rcbInputCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbInputCell{width:100%;height:20px;_height:22px;line-height:20px;_line-height:22px;text-align:left;vertical-align:middle}.RadComboBox .rcbInputCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbReadOnly .rcbInput{color:#333}.RadComboBox .rcbReadOnly .rcbInput{cursor:default}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbInput{color:#333;font:normal 12px "Segoe UI",Arial,Helvetica,sans-serif;line-height:16px}.RadComboBox .rcbInput{margin:0;padding:0;border:0;background:0;padding:2px 0 1px;_padding:2px 0 0;width:100%;_height:18px;outline:0;vertical-align:middle;-webkit-appearance:none}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbReadOnly .rcbArrowCellRight{background-position:-162px -176px}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}.RadComboBox_Default .rcbArrowCellRight{background-position:-18px -176px}.RadComboBox_Default .rcbArrowCell{background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSprite.png');_background-image:url('mvwres://Telerik.Web.UI, Version=2013.1.417.45, Culture=neutral, PublicKeyToken=121fae78165ba3d4/Telerik.Web.UI.Skins.Default.Common.radFormSpriteIE6.png')}.RadComboBox .rcbArrowCell{width:18px}.RadComboBox .rcbArrowCell{margin:0;padding:0;background-color:transparent;background-repeat:no-repeat;*zoom:1}
        
    </style>

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
