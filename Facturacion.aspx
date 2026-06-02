<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Facturacion.aspx.vb" Inherits="Facturacion" MasterPageFile="~/MasterPageCuenza.Master" %>

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
                                ForeColor="White" Text="Facturación"></asp:Label>
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
            <td style="width:700px;" >&nbsp;
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="width:230px;">
                            <telerik:RadToolBar ID="RadToolBarActualizar" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Generar Factura" ToolTip="Generar factura seleccionada">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar Factura" ToolTip="Cancelar factura seleccionada">
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
                        <td style="width:212px;">
                            <telerik:RadToolBar ID="RadToolBarPolizaImp" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Carga Batch" ToolTip="Generar carga batch de facturas generadas para Compac">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Importar Pagos" ToolTip="Importar pagos aplicados en contabilidad">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td style="width:150px;">
                            <asp:Label ID="LabelTipoCambio" runat="server" Font-Bold="True" ForeColor="Black" Text="Tipo de Cambio" Font-Size="Small"></asp:Label>
                            <telerik:radnumerictextbox ID="TBTipoCambio" Runat="server" 
                                Culture="Spanish (Mexico)" Font-Size="8pt" MaxValue="100" MinValue="1" 
                                Skin="Web20" Width="100px">
                                <DisabledStyle ForeColor="#333333" />
                                <NumberFormat DecimalDigits="5" />
                            </telerik:radnumerictextbox>
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
            <td class="auto-style3" style="height:25px; padding-left:4px; background-image: url('/Imagenes/FondoTitulos13.png'); background-repeat: repeat-x;">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                    Font-Size="Small" ForeColor="White" 
                    Text=" Seleccionar parámetros para mostrar información">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3" style="border-color: #AAAAAA; border-style: solid; border-width: 1px 1px 2px 1px; background-color:#e1e1e1;">
                <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="border-style: solid solid none none; border-width: 1px; border-color: #AAAAAA; padding-left:4px; width:220px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Mes y Año Inicial"></asp:Label>
                        <br />
                        <telerik:RadComboBox ID="RCBMesI" Runat="server" Font-Size="Small" 
                            Height="21px" Width="125px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Enero" Value="Enero" />
                                <telerik:RadComboBoxItem runat="server" Text="Febrero" Value="Febrero" />
                                <telerik:RadComboBoxItem runat="server" Text="Marzo" Value="Marzo" />
                                <telerik:RadComboBoxItem runat="server" Text="Abril" Value="Abril" />
                                <telerik:RadComboBoxItem runat="server" Text="Mayo" Value="Mayo" />
                                <telerik:RadComboBoxItem runat="server" Text="Junio" Value="Junio" />
                                <telerik:RadComboBoxItem runat="server" Text="Julio" Value="Julio" />
                                <telerik:RadComboBoxItem runat="server" Text="Agosto" Value="Agosto" />
                                <telerik:RadComboBoxItem runat="server" Text="Septiembre" Value="Septiembre" />
                                <telerik:RadComboBoxItem runat="server" Text="Octubre" Value="Octubre" />
                                <telerik:RadComboBoxItem runat="server" Text="Noviembre" Value="Noviembre" />
                                <telerik:RadComboBoxItem runat="server" Text="Diciembre" Value="Diciembre" />
                            </Items>
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                        <telerik:RadComboBox ID="RCBAñoI" Runat="server" Font-Size="Small" Width="70px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="2008" Value="2008" />
                                <telerik:RadComboBoxItem runat="server" Text="2009" Value="2009" />
                                <telerik:RadComboBoxItem runat="server" Text="2010" Value="2010" />
                                <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
                                <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
                                <telerik:RadComboBoxItem runat="server" Text="2013" Value="2013" />
                                <telerik:RadComboBoxItem runat="server" Text="2014" Value="2014" />
                                <telerik:RadComboBoxItem runat="server" Text="2015" Value="2015" />
                                <telerik:RadComboBoxItem runat="server" Text="2016" Value="2016" />
                                <telerik:RadComboBoxItem runat="server" Text="2017" Value="2017" />
                                <telerik:RadComboBoxItem runat="server" Text="2018" Value="2018" />
                                <telerik:RadComboBoxItem runat="server" Text="2019" Value="2019" />
                                <telerik:RadComboBoxItem runat="server" Text="2020" Value="2020" />
                                <telerik:RadComboBoxItem runat="server" Text="2021" Value="2021" />
                                <telerik:RadComboBoxItem runat="server" Text="2022" Value="2022" />
                                <telerik:RadComboBoxItem runat="server" Text="2023" Value="2023" />
                                <telerik:RadComboBoxItem runat="server" Text="2024" Value="2024" />
                                <telerik:RadComboBoxItem runat="server" Text="2025" Value="2025" />
                                <telerik:RadComboBoxItem runat="server" Text="2026" Value="2026" />
                                <telerik:RadComboBoxItem runat="server" Text="2027" Value="2027" />
                                <telerik:RadComboBoxItem runat="server" Text="2028" Value="2028" />
                                <telerik:RadComboBoxItem runat="server" Text="2029" Value="2029" />
                                <telerik:RadComboBoxItem runat="server" Text="2030" Value="2030" />
                                <telerik:RadComboBoxItem runat="server" Text="2031" Value="2031" />
                                <telerik:RadComboBoxItem runat="server" Text="2032" Value="2032" />
                                <telerik:RadComboBoxItem runat="server" Text="2033" Value="2033" />
                                <telerik:RadComboBoxItem runat="server" Text="2034" Value="2034" />
                                <telerik:RadComboBoxItem runat="server" Text="2035" Value="2035" />
                                <telerik:RadComboBoxItem runat="server" Text="2036" Value="2036" />
                                <telerik:RadComboBoxItem runat="server" Text="2037" Value="2037" />
                                <telerik:RadComboBoxItem runat="server" Text="2038" Value="2038" />
                                <telerik:RadComboBoxItem runat="server" Text="2039" Value="2039" />
                                <telerik:RadComboBoxItem runat="server" Text="2040" Value="2040" />
                            </Items>
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                        <br />
                        <asp:Label ID="Label25" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Mes y Año Final"></asp:Label>
                        <br />
                        <telerik:RadComboBox ID="RCBMesF" Runat="server" Font-Size="Small" 
                            Width="125px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="Enero" Value="Enero" />
                                <telerik:RadComboBoxItem runat="server" Text="Febrero" Value="Febrero" />
                                <telerik:RadComboBoxItem runat="server" Text="Marzo" Value="Marzo" />
                                <telerik:RadComboBoxItem runat="server" Text="Abril" Value="Abril" />
                                <telerik:RadComboBoxItem runat="server" Text="Mayo" Value="Mayo" />
                                <telerik:RadComboBoxItem runat="server" Text="Junio" Value="Junio" />
                                <telerik:RadComboBoxItem runat="server" Text="Julio" Value="Julio" />
                                <telerik:RadComboBoxItem runat="server" Text="Agosto" Value="Agosto" />
                                <telerik:RadComboBoxItem runat="server" Text="Septiembre" Value="Septiembre" />
                                <telerik:RadComboBoxItem runat="server" Text="Octubre" Value="Octubre" />
                                <telerik:RadComboBoxItem runat="server" Text="Noviembre" Value="Noviembre" />
                                <telerik:RadComboBoxItem runat="server" Text="Diciembre" Value="Diciembre" />
                            </Items>
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
                        <telerik:RadComboBox ID="RCBAñoF" Runat="server" Font-Size="Small" Width="70px">
                            <Items>
                                <telerik:RadComboBoxItem runat="server" Text="2008" Value="2008" />
                                <telerik:RadComboBoxItem runat="server" Text="2009" Value="2009" />
                                <telerik:RadComboBoxItem runat="server" Text="2010" Value="2010" />
                                <telerik:RadComboBoxItem runat="server" Text="2011" Value="2011" />
                                <telerik:RadComboBoxItem runat="server" Text="2012" Value="2012" />
                                <telerik:RadComboBoxItem runat="server" Text="2013" Value="2013" />
                                <telerik:RadComboBoxItem runat="server" Text="2014" Value="2014" />
                                <telerik:RadComboBoxItem runat="server" Text="2015" Value="2015" />
                                <telerik:RadComboBoxItem runat="server" Text="2016" Value="2016" />
                                <telerik:RadComboBoxItem runat="server" Text="2017" Value="2017" />
                                <telerik:RadComboBoxItem runat="server" Text="2018" Value="2018" />
                                <telerik:RadComboBoxItem runat="server" Text="2019" Value="2019" />
                                <telerik:RadComboBoxItem runat="server" Text="2020" Value="2020" />
                                <telerik:RadComboBoxItem runat="server" Text="2021" Value="2021" />
                                <telerik:RadComboBoxItem runat="server" Text="2022" Value="2022" />
                                <telerik:RadComboBoxItem runat="server" Text="2023" Value="2023" />
                                <telerik:RadComboBoxItem runat="server" Text="2024" Value="2024" />
                                <telerik:RadComboBoxItem runat="server" Text="2025" Value="2025" />
                                <telerik:RadComboBoxItem runat="server" Text="2026" Value="2026" />
                                <telerik:RadComboBoxItem runat="server" Text="2027" Value="2027" />
                                <telerik:RadComboBoxItem runat="server" Text="2028" Value="2028" />
                                <telerik:RadComboBoxItem runat="server" Text="2029" Value="2029" />
                                <telerik:RadComboBoxItem runat="server" Text="2030" Value="2030" />
                                <telerik:RadComboBoxItem runat="server" Text="2031" Value="2031" />
                                <telerik:RadComboBoxItem runat="server" Text="2032" Value="2032" />
                                <telerik:RadComboBoxItem runat="server" Text="2033" Value="2033" />
                                <telerik:RadComboBoxItem runat="server" Text="2034" Value="2034" />
                                <telerik:RadComboBoxItem runat="server" Text="2035" Value="2035" />
                                <telerik:RadComboBoxItem runat="server" Text="2036" Value="2036" />
                                <telerik:RadComboBoxItem runat="server" Text="2037" Value="2037" />
                                <telerik:RadComboBoxItem runat="server" Text="2038" Value="2038" />
                                <telerik:RadComboBoxItem runat="server" Text="2039" Value="2039" />
                                <telerik:RadComboBoxItem runat="server" Text="2040" Value="2040" />
                            </Items>
                            <CollapseAnimation Duration="200" Type="OutQuint" />
                        </telerik:RadComboBox>
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
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:2px; width:120px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label26" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Estatus"></asp:Label> 
                        <br />
                        <asp:CheckBox ID="CBStatus1" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Pronóstico" />
                        <br />
                        <asp:CheckBox ID="CBStatus2" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Programa" />
                        <br />
                        <asp:CheckBox ID="CBStatus3" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Gastos" />
                        <br />
                        <asp:CheckBox ID="CBStatus4" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Cancelados" />
                    </td>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:2px; width:170px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label24" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Tipo de factura" BorderStyle="None"></asp:Label>
                        <br />
                        <asp:CheckBox ID="CBTipoFactura1" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" No facturadas" />
                        <br />
                        <asp:CheckBox ID="CBTipoFactura2" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Facturadas Generadas" />
                        <br />
                        <asp:CheckBox ID="CBTipoFactura3" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Facturas Pagadas" />
                        <br />
                        <asp:CheckBox ID="CBTipoFactura4" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Facturas Canceladas" />
                    </td>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:2px; width:120px; text-align: left; vertical-align: top; ">
                        <asp:Label ID="Label23" runat="server" Font-Bold="True" Font-Size="Small" 
                            ForeColor="Black" Text="Tipo de fecha"></asp:Label>
                        <br />
                        <asp:CheckBox ID="CBTipoFecha1" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Facturación" AutoPostBack="True" />
                        <asp:CheckBox ID="CBTipoFecha2" runat="server" Font-Size="Small" ForeColor="Black" 
                            Text=" Pago" AutoPostBack="True" />
                        <br />
                    </td>
                    <td style="border-style: solid solid none solid; border-width: 1px; border-color: #AAAAAA; padding-left:2px; padding-right:2px; padding-top:2px; padding-bottom:2px; text-align: left; vertical-align: top; ">
                        <telerik:RadGrid ID="RadGridLineas" runat="server" GridLines="None" 
                            Height="150px" Skin="Sunset" Width="330px" CellSpacing="0" Culture="es-ES" AutoGenerateColumns="False">
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn>
                                <HeaderStyle Width="20px"></HeaderStyle>
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="CheckBoxTemplateColumn">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                oncheckedchanged="CheckBox1_CheckedChanged" Checked="True" />
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridBoundColumn FilterControlAltText="Filter linea_servicio column" HeaderText="Línea de servicio" UniqueName="linea_servicio" DataField="linea_servicio"></telerik:GridBoundColumn>
                                </Columns>
                                <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                                </EditFormSettings>
                            </MasterTableView>
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                            </ClientSettings>
                            <FilterMenu EnableImageSprites="False"></FilterMenu>
                        </telerik:RadGrid>
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
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter1" Height="600px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="gridPane" runat="server" Height="600px" Scrolling="None">
                        <telerik:RadGrid ID="RadGrid1" 
                            runat="server" 
                            AllowFilteringByColumn="True" 
                            AutoGenerateColumns="False" 
                            CellSpacing="0" 
                            Culture="es-ES" 
                            DataSourceID="SqlDataSource1" 
                            GridLines="None" 
                            Height="600px" 
                            ShowFooter="True" 
                            Skin="Sunset" 
                            Width="1000px">
                            <groupingsettings casesensitive="false" />
                            <mastertableview datakeynames="id_pago_pk" nodetailrecordstext="No hay registros que mostrar." nomasterrecordstext="No hay registros que mostrar." showgroupfooter="True" showheader="True" tablelayout="Fixed">
                                <commanditemsettings exporttopdftext="Export to PDF"></commanditemsettings>
                                <rowindicatorcolumn filtercontrolalttext="Filter RowIndicator column" visible="True">
                                </rowindicatorcolumn>
                                <expandcollapsecolumn filtercontrolalttext="Filter ExpandColumn column" visible="True">
                                </expandcollapsecolumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="¿Quién Factura?"         UniqueName="nombre_empresa"      DataField="nombre_empresa"      HeaderStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Línea de servicio"       UniqueName="nombre_linea"        DataField="nombre_linea"        HeaderStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Clave"                   UniqueName="id_ingreso"          DataField="id_ingreso"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Autorizado"              UniqueName="autorizado"          DataField="autorizado"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estatus"                 UniqueName="status"              DataField="status"              HeaderStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Folio de factura"        UniqueName="folio_factura"       DataField="folio_factura"       HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha de facturación"    UniqueName="fecha_fact"          DataField="fecha_fact"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha de pago"           UniqueName="fecha_pago"          DataField="fecha_pago"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Tipo de factura"         UniqueName="tipo_factura"        DataField="tipo_factura"        HeaderStyle-Width="150px" FilterControlWidth="110px" HeaderStyle-HorizontalAlign="Center" FooterText="Totales" FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Tipo de Moneda"          UniqueName="TipoMoneda"          DataField="TipoMoneda"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Importe"                 UniqueName="importe"             DataField="importe"             HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="IVA"                     UniqueName="iva"                 DataField="iva"                 HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total"                   UniqueName="total"               DataField="total"               HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Vencido"                 UniqueName="vencido"             DataField="vencido"             HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Por vencer"              UniqueName="por_vencer"          DataField="por_vencer"          HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Concepto"                UniqueName="concepto"            DataField="concepto"            HeaderStyle-Width="400px" FilterControlWidth="360px" HeaderStyle-HorizontalAlign="Center" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Gerente"                 UniqueName="Gerente"             DataField="Gerente"             HeaderStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Cliente"                 UniqueName="nombre_cliente"      DataField="nombre_cliente"      HeaderStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Servicio"                UniqueName="nombre_servicio"     DataField="nombre_servicio"     HeaderStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha deposito 1"        UniqueName="fecha_deposito1"     DataField="fecha_deposito1"     HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Pago 1"                  UniqueName="pago_1"              DataField="pago_1"              HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha deposito 2"        UniqueName="fecha_deposito2"     DataField="fecha_deposito2"     HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Pago 2"                  UniqueName="pago_2"              DataField="pago_2"              HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha deposito 3"        UniqueName="fecha_deposito3"     DataField="fecha_deposito3"     HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Pago 3"                  UniqueName="pago_3"              DataField="pago_3"              HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha deposito 4"        UniqueName="fecha_deposito4"     DataField="fecha_deposito4"     HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Pago 4"                  UniqueName="pago_4"              DataField="pago_4"              HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha deposito 5"        UniqueName="fecha_deposito5"     DataField="fecha_deposito5"     HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Pago 5"                  UniqueName="pago_5"              DataField="pago_5"              HeaderStyle-Width="120px" FilterControlWidth="80px"  HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Motivo de cancelación"   UniqueName="motivo_cancelacion"  DataField="motivo_cancelacion"  HeaderStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Fecha de cancelación"    UniqueName="fecha_cancelacion"   DataField="fecha_cancelacion"   HeaderStyle-Width="150px" FilterControlWidth="110px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="id_pago_pk"              UniqueName="id_pago_pk"          DataField="id_pago_pk"          HeaderStyle-Width="0px"   FilterControlWidth="0px"   HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="id_ingreso_pk"           UniqueName="id_ingreso_pk"       DataField="id_ingreso_pk"       HeaderStyle-Width="0px"   FilterControlWidth="0px"   HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                </Columns>
                               <editformsettings>
                                    <editcolumn filtercontrolalttext="Filter EditCommandColumn column">
                                    </editcolumn>
                                </editformsettings>
                                <ItemStyle Wrap="True" />
                                <PagerStyle PageSizeControlType="RadComboBox" />
                                <HeaderStyle Wrap="False" />
                            </mastertableview>
                            <exportsettings>
                                <excel format="ExcelML" />
                            </exportsettings>
                            <clientsettings>
                                <selecting allowrowselect="True" />
                                <scrolling allowscroll="True" usestaticheaders="True" />
                                <resizing allowcolumnresize="True" allowrowresize="True" />
                            </clientsettings>
                            <PagerStyle PageSizeControlType="RadComboBox" />
                            <filtermenu enableimagesprites="False"></filtermenu>
                        </telerik:RadGrid>
                    </telerik:RadPane>
                </telerik:RadSplitter>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <asp:SqlDataSource ID="SqlDataSourceLineas" runat="server" ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" SelectCommand="SELECT RIGHT ('0' + CAST(id_linea_servicio AS VARCHAR), 2) + ' ' + nombre_linea AS [linea_servicio] FROM LineasServicio WHERE (ss = 1) ORDER BY id_linea_servicio"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" 
                    SelectCommand="SELECT Empresas.nombre_empresa
	                                     , Ingresos.id_ingreso
	                                     , Status = TiposStatusCuenza.descripcion
	                                     , tipo_factura = TiposFactura.descripcion
	                                     , IngresosPagos.folio_factura
	                                     , fecha_fact = Convert(Nvarchar, IngresosPagos.fecha_fact,103)
	                                     , fecha_pago = Convert(Nvarchar, IngresosPagos.fecha_pago,103)
	                                     , IngresosPagos.concepto
	                                     , TipoMoneda = TiposMoneda.descripcion
	                                     , IngresosPagos.importe
	                                     , IngresosPagos.iva
	                                     , IngresosPagos.total
	                                     , vencido =	case when (IngresosPagos.id_tipo_factura = 1 or IngresosPagos.id_tipo_factura = 2) and (IngresosPagos.fecha_pago < GETDATE())
					                                    then
						                                    case when Ingresos.id_tipo_moneda >= 2
 						                                    then IngresosPagos.total * @TipoCambio
 						                                    else IngresosPagos.total
						                                     End
 					                                    else 0
					                                     End
	                                     , por_vencer = case when (IngresosPagos.id_tipo_factura = 1 or IngresosPagos.id_tipo_factura = 2) and (IngresosPagos.fecha_pago >= GETDATE())
 					                                     then
 						                                    case when Ingresos.id_tipo_moneda >= 2
 						                                    then IngresosPagos.total * @TipoCambio
 						                                    else IngresosPagos.total
						                                    End
 					                                     else 0
					                                     End
	                                     , LineasServicio.nombre_linea 
	                                     , LineasServicio.Gerente 
	                                     , CLIENTES.nombre_cliente
	                                     , SERVICIOS.nombre_servicio
	                                     , IngresosPagos.fecha_deposito1 as fecha_deposito1
	                                     , IngresosPagos.pago_1 as pago_1
	                                     , IngresosPagos.fecha_deposito2 as fecha_deposito2
	                                     , IngresosPagos.pago_2 as pago_2
	                                     , IngresosPagos.fecha_deposito3 as fecha_deposito3
	                                     , IngresosPagos.pago_3 as pago_3
	                                     , IngresosPagos.fecha_deposito4 as fecha_deposito4
	                                     , IngresosPagos.pago_4 as pago_4
	                                     , IngresosPagos.fecha_deposito5 as fecha_deposito5
	                                     , IngresosPagos.pago_5 as pago_5
                                         , IngresosPagos.id_pago_pk
                                         , Ingresos.id_ingreso_pk
                                         , Ingresos.autorizado
                                         , IngresosPagos.motivo_cancelacion
                                         , fecha_cancelacion = Convert(Nvarchar, IngresosPagos.fecha_cancelacion,103)
	                                    FROM IngresosPagos
                                        INNER JOIN Ingresos              ON (IngresosPagos.id_ingreso_pk  = Ingresos.id_ingreso_pk)
                                        INNER JOIN Empresas              ON Ingresos.id_empresa           = Empresas.id_empresa
                                        INNER JOIN CLIENTES              ON Ingresos.id_cliente           = CLIENTES.id_cliente
                                        INNER JOIN SERVICIOS             ON Ingresos.id_servicio          = SERVICIOS.id_servicio AND Ingresos.id_linea_servicio = SERVICIOS.id_linea_servicio
                                        INNER JOIN LineasServicio        ON Ingresos.id_linea_servicio    = LineasServicio.id_linea_servicio
                                        INNER JOIN TiposStatusCuenza     ON Ingresos.id_status            = TiposStatusCuenza.id_status
                                        INNER JOIN TiposStatusDescCuenza ON Ingresos.id_status_desc       = TiposStatusDescCuenza.id_status_desc
                                        INNER JOIN TiposMoneda           ON Ingresos.id_tipo_moneda       = TiposMoneda.id_tipo_moneda
                                        INNER JOIN TiposFactura          ON IngresosPagos.id_tipo_factura = TiposFactura.id_tipo_factura
	                                    WHERE (IngresosPagos.ss = 1) 
	                                      AND (Ingresos.id_linea_servicio = @id_ls_1 OR Ingresos.id_linea_servicio = @id_ls_2 OR Ingresos.id_linea_servicio = @id_ls_3 OR Ingresos.id_linea_servicio = @id_ls_4 OR Ingresos.id_linea_servicio = @id_ls_5 OR Ingresos.id_linea_servicio = @id_ls_6 OR Ingresos.id_linea_servicio = @id_ls_7 OR Ingresos.id_linea_servicio = @id_ls_8 OR Ingresos.id_linea_servicio = @id_ls_9 OR Ingresos.id_linea_servicio = @id_ls_10 OR Ingresos.id_linea_servicio = @id_ls_11 OR Ingresos.id_linea_servicio = @id_ls_12 OR Ingresos.id_linea_servicio = @id_ls_13 OR Ingresos.id_linea_servicio = @id_ls_14 OR Ingresos.id_linea_servicio = @id_ls_15 OR Ingresos.id_linea_servicio = @id_ls_16 OR Ingresos.id_linea_servicio = @id_ls_17 OR Ingresos.id_linea_servicio = @id_ls_18 OR Ingresos.id_linea_servicio = @id_ls_19 OR Ingresos.id_linea_servicio = @id_ls_20 OR Ingresos.id_linea_servicio = @id_ls_21 OR Ingresos.id_linea_servicio = @id_ls_22 OR Ingresos.id_linea_servicio = @id_ls_23 OR Ingresos.id_linea_servicio = @id_ls_24 OR Ingresos.id_linea_servicio = @id_ls_25 OR Ingresos.id_linea_servicio = @id_ls_26 OR Ingresos.id_linea_servicio = @id_ls_27 OR Ingresos.id_linea_servicio = @id_ls_28 OR Ingresos.id_linea_servicio = @id_ls_29 OR Ingresos.id_linea_servicio = @id_ls_30) 
	                                      AND (IngresosPagos.fecha_fact >= @Fini_f AND IngresosPagos.fecha_fact <= @Ffin_f OR IngresosPagos.fecha_pago >= @Fini_p AND IngresosPagos.fecha_pago <= @Ffin_p) 
	                                      AND (Ingresos.id_status = @Status1 OR Ingresos.id_status = @Status2 OR Ingresos.id_status = @Status3 OR Ingresos.id_status = @Status4 OR Ingresos.id_status = @Status5 OR Ingresos.id_status = @Status6 OR Ingresos.id_status = @Status7 OR Ingresos.id_status = @Status8 OR Ingresos.id_status = @Status9) 
	                                      AND (IngresosPagos.id_tipo_factura = @TipoFactura1 OR IngresosPagos.id_tipo_factura = @TipoFactura2 OR IngresosPagos.id_tipo_factura = @TipoFactura3 OR IngresosPagos.id_tipo_factura = @TipoFactura4)
	                                    GROUP BY Ingresos.id_ingreso, IngresosPagos.id_tipo_factura, IngresosPagos.folio_factura
		                                       , IngresosPagos.concepto, Ingresos.id_tipo_moneda, IngresosPagos.importe, IngresosPagos.iva
		                                       , IngresosPagos.total, IngresosPagos.fecha_fact,IngresosPagos.fecha_pago,Ingresos.id_status
		                                       , LineasServicio.id_linea_servicio, LineasServicio.nombre_linea, LineasServicio.gerente, Empresas.nombre_empresa
		                                       , CLIENTES.nombre_cliente, SERVICIOS.nombre_servicio, IngresosPagos.fecha_deposito1, IngresosPagos.pago_1
		                                       , IngresosPagos.fecha_deposito2, IngresosPagos.pago_2, IngresosPagos.fecha_deposito3
		                                       , IngresosPagos.pago_3, IngresosPagos.fecha_deposito4, IngresosPagos.pago_4
		                                       , IngresosPagos.fecha_deposito5, IngresosPagos.pago_5, IngresosPagos.id_pago_pk, Ingresos.id_ingreso_pk
		                                       , TiposStatusCuenza.descripcion, TiposFactura.descripcion, TiposMoneda.descripcion, Ingresos.autorizado
                                               , IngresosPagos.motivo_cancelacion, IngresosPagos.fecha_cancelacion
	                                    ORDER BY Empresas.nombre_empresa
			                                    , LineasServicio.id_linea_servicio
			                                    , IngresosPagos.fecha_fact">
                    <SelectParameters>
                        <asp:SessionParameter Name="TipoCambio" SessionField="@TipoCambio" Type="Decimal" />
                        <asp:SessionParameter Name="id_ls_1" SessionField="id_ls_1" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_2" SessionField="id_ls_2" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_3" SessionField="id_ls_3" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_4" SessionField="id_ls_4" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_5" SessionField="id_ls_5" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_6" SessionField="id_ls_6" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_7" SessionField="id_ls_7" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_8" SessionField="id_ls_8" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_9" SessionField="id_ls_9" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_10" SessionField="id_ls_10" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_11" SessionField="id_ls_11" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_12" SessionField="id_ls_12" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_13" SessionField="id_ls_13" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_14" SessionField="id_ls_14" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_15" SessionField="id_ls_15" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_16" SessionField="id_ls_16" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_17" SessionField="id_ls_17" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_18" SessionField="id_ls_18" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_19" SessionField="id_ls_19" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_20" SessionField="id_ls_20" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_21" SessionField="id_ls_21" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_22" SessionField="id_ls_22" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_23" SessionField="id_ls_23" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_24" SessionField="id_ls_24" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_25" SessionField="id_ls_25" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_26" SessionField="id_ls_26" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_27" SessionField="id_ls_27" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_28" SessionField="id_ls_28" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_29" SessionField="id_ls_29" Type="Int32" />
                        <asp:SessionParameter Name="id_ls_30" SessionField="id_ls_30" Type="Int32" />
                        <asp:SessionParameter Name="Fini_f" SessionField="Fini_f" Type="DateTime" />
                        <asp:SessionParameter Name="Ffin_f" SessionField="Ffin_f" Type="DateTime" />
                        <asp:SessionParameter Name="Fini_p" SessionField="Fini_p" Type="DateTime" />
                        <asp:SessionParameter Name="Ffin_p" SessionField="Ffin_p" Type="DateTime" />
                        <asp:SessionParameter Name="Status1" SessionField="Status1" Type="Int32" />
                        <asp:SessionParameter Name="Status2" SessionField="Status2" Type="Int32" />
                        <asp:SessionParameter Name="Status3" SessionField="Status3" Type="Int32" />
                        <asp:SessionParameter Name="Status4" SessionField="Status4" Type="Int32" />
                        <asp:SessionParameter Name="Status5" SessionField="Status5" Type="Int32" />
                        <asp:SessionParameter Name="Status6" SessionField="Status6" Type="Int32" />
                        <asp:SessionParameter Name="Status7" SessionField="Status7" Type="Int32" />
                        <asp:SessionParameter Name="Status8" SessionField="Status8" Type="Int32" />
                        <asp:SessionParameter Name="Status9" SessionField="Status9" Type="Int32" />
                        <asp:SessionParameter Name="TipoFactura1" SessionField="TipoFactura1" Type="Int32" />
                        <asp:SessionParameter Name="TipoFactura2" SessionField="TipoFactura2" Type="Int32" />
                        <asp:SessionParameter Name="TipoFactura3" SessionField="TipoFactura3" Type="Int32" />
                        <asp:SessionParameter Name="TipoFactura4" SessionField="TipoFactura4" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>"
                    SelectCommand="SELECT IngresosPagos.id_pago_pk
                                        , IngresosPagos.id_ingreso_pk
                                        , IngresosPagos.no_pago
                                        , IngresosPagos.folio_factura
                                        , IngresosPagos.importe AS importe_p
                                        , IngresosPagos.importe_letra
                                        , fecha_fact = Convert(Nvarchar, IngresosPagos.fecha_fact,103)
                                        , fecha_pago = Convert(Nvarchar, IngresosPagos.fecha_pago,103)
                                        , IngresosPagos.concepto
                                        , TiposFactura.descripcion AS tipo_factura
                                        , IngresosPagos.pago_1
                                        , IngresosPagos.pago_2
                                        , IngresosPagos.pago_3
                                        , IngresosPagos.pago_4
                                        , IngresosPagos.pago_5
                                        , IngresosPagos.iva
                                        , IngresosPagos.total
                                        , fecha_deposito1 = Convert(Nvarchar, IngresosPagos.fecha_deposito1,103)
                                        , fecha_deposito2 = Convert(Nvarchar, IngresosPagos.fecha_deposito2,103)
                                        , fecha_deposito3 = Convert(Nvarchar, IngresosPagos.fecha_deposito3,103)
                                        , fecha_deposito4 = Convert(Nvarchar, IngresosPagos.fecha_deposito4,103)
                                        , fecha_deposito5 = Convert(Nvarchar, IngresosPagos.fecha_deposito5,103)
                                        , IngresosPagos.motivo_cancelacion AS motivo_cancelacion_p
                                        , fecha_cancelacion_p = Convert(Nvarchar, IngresosPagos.fecha_cancelacion,103)
                                    FROM IngresosPagos 
                                    INNER JOIN TiposFactura ON (IngresosPagos.id_tipo_factura = TiposFactura.id_tipo_factura)
                                    WHERE IngresosPagos.id_ingreso_pk = @id_ingreso_pk
                                    ORDER BY IngresosPagos.no_pago, IngresosPagos.folio_factura">
                    <SelectParameters>
                        <asp:SessionParameter Name="id_ingreso_pk" SessionField="id_ingreso_pk" Type="Int32" />
                    </SelectParameters>
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
                                <telerik:AjaxUpdatedControl ControlID="lblMensaje" />
                                <telerik:AjaxUpdatedControl ControlID="RadGridPagos" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="CBTipoFecha1">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="CBTipoFecha1" />
                                <telerik:AjaxUpdatedControl ControlID="CBTipoFecha2" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="CBTipoFecha2">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="CBTipoFecha1" />
                                <telerik:AjaxUpdatedControl ControlID="CBTipoFecha2" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGridLineas">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGridLineas" LoadingPanelID="RadAjaxLoadingPanel1" />
                            </updatedcontrols>
                        </telerik:AjaxSetting>
                        <telerik:AjaxSetting AjaxControlID="RadGrid1">
                            <updatedcontrols>
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
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
            width: 120px;
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
