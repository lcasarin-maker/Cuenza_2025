<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PronosticoPrograma.aspx.vb" Inherits="PronosticoPrograma" MasterPageFile="~/MasterPageCuenza.Master" %>

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
                                ForeColor="White" Text="Pronóstico y Programa"></asp:Label>
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
                            <telerik:RadToolBar ID="RadToolBarActualizar" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Agregar" ToolTip="Agregar pronóstico nuevo">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Autorizar" ToolTip="Autorizar pronóstico seleccionado">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Modificar" ToolTip="Modificar pronóstico seleccionado">
                                    </telerik:RadToolBarButton>
                                    <telerik:RadToolBarButton runat="server" Text="Cancelar" ToolTip="Cancelar pronóstico seleccionado">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <telerik:RadToolBar ID="RadToolBarReportes" runat="server" Skin="Sunset">
                                <CollapseAnimation Duration="200" Type="OutQuint" />
                                <Items>
                                    <telerik:RadToolBarButton runat="server" Text="Generar Reporte" ToolTip="Generar reporte en excel de la información mostrada">
                                    </telerik:RadToolBarButton>
                                </Items>
                            </telerik:RadToolBar>
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
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                <telerik:RadSplitter ID="RadSplitter2" Height="200px" Width="1000px" runat="server" Orientation="Horizontal">
                    <telerik:RadPane ID="RadPane1" runat="server" Height="200px" Scrolling="None">
                        <telerik:RadGrid ID="RadGridTotales" runat="server" Height="200px" Skin="Sunset" Width="1000px">
                            <ClientSettings>
                                <Selecting AllowRowSelect="True" />
                                <Scrolling AllowScroll="True" UseStaticHeaders="True" />
                                <Resizing AllowColumnResize="True" AllowRowResize="True" />
                            </ClientSettings>
                            <MasterTableView>
                                <CommandItemSettings ExportToPdfText="Export to PDF" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                    <HeaderStyle Width="20px" />
                                </ExpandCollapseColumn>
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
                                DataKeyNames="id_ingreso_pk"
                                TableLayout="Fixed" 
                                NoMasterRecordsText="No hay registros que mostrar."
                                NoDetailRecordsText="No hay registros que mostrar."
                                ShowHeader="True"
                                ShowGroupFooter="True">
                                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <DetailTables>
                                    <telerik:GridTableView 
                                        Name="DTPagos"
                                        runat="server"
                                        DataSourceID="SqlDataSource2"
                                        CommandItemDisplay="Top"
                                        AllowFilteringByColumn="False"
                                        CssClass="rgDetailTable2"
                                        NoMasterRecordsText="No hay registros que mostrar."
                                        NoDetailRecordsText="No hay registros que mostrar."
                                        Width="98%">
                                        <EditFormSettings>
                                            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                            </EditColumn>
                                        </EditFormSettings>
                                        <PagerStyle PageSizeControlType="RadComboBox" />
                                        <CommandItemTemplate>
                                            <div id="Div1" style="text-align:left; height:20px; padding-left:5px; padding-top:5px;">
                                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Detalle de Pagos"></asp:Label>
                                            </div>
                                        </CommandItemTemplate>
                                        <ParentTableRelation>
                                            <telerik:GridRelationFields DetailKeyField="id_ingreso_pk" MasterKeyField="id_ingreso_pk" />
                                        </ParentTableRelation>
                                        <CommandItemSettings ExportToPdfText="Export to PDF" />
                                        <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        </RowIndicatorColumn>
                                        <ExpandCollapseColumn Visible="True">
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle Width="20px" />
                                        </ExpandCollapseColumn>
                                        <Columns>
                                            <telerik:GridBoundColumn UniqueName="no_pago"              DataField="no_pago"              HeaderText="No. de pago"           HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="folio_factura"        DataField="folio_factura"        HeaderText="Folio de factura"      HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_fact"           DataField="fecha_fact"           HeaderText="Fecha de facturación"  HeaderStyle-Width="90px" ItemStyle-Width="90px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_pago"           DataField="fecha_pago"           HeaderText="Fecha de pago"         HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="concepto"             DataField="concepto"             HeaderText="Concepto"              HeaderStyle-Width="300px" ItemStyle-Width="300px" HeaderStyle-HorizontalAlign="Center" ></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="tipo_factura"         DataField="tipo_factura"         HeaderText="Tipo de factura"       HeaderStyle-Width="70px" ItemStyle-Width="70px" HeaderStyle-HorizontalAlign="Center" ></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="importe_p"            DataField="importe_p"            HeaderText="Importe"               HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="iva"                  DataField="iva"                  HeaderText="IVA"                   HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="total"                DataField="total"                HeaderText="Total"                 HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pago_1"               DataField="pago_1"               HeaderText="Pago 1"                HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_deposito1"      DataField="fecha_deposito1"      HeaderText="Fecha deposito 1"      HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pago_2"               DataField="pago_2"               HeaderText="Pago 2"                HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_deposito2"      DataField="fecha_deposito2"      HeaderText="Fecha deposito 2"      HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pago_3"               DataField="pago_3"               HeaderText="Pago 3"                HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_deposito3"      DataField="fecha_deposito3"      HeaderText="Fecha deposito 3"      HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pago_4"               DataField="pago_4"               HeaderText="Pago 4"                HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_deposito4"      DataField="fecha_deposito4"      HeaderText="Fecha deposito 4"      HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="pago_5"               DataField="pago_5"               HeaderText="Pago 5"                HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_deposito5"      DataField="fecha_deposito5"      HeaderText="Fecha deposito 5"      HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="importe_letra"        DataField="importe_letra"        HeaderText="Importe en letra"      HeaderStyle-Width="200px" ItemStyle-Width="200px" HeaderStyle-HorizontalAlign="Center" ></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="motivo_cancelacion_p" DataField="motivo_cancelacion_p" HeaderText="Motivo de cancelación" HeaderStyle-Width="250px" ItemStyle-Width="250px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="fecha_cancelacion_p"  DataField="fecha_cancelacion_p"  HeaderText="Fecha de cancelación"  HeaderStyle-Width="80px" ItemStyle-Width="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                            <telerik:GridBoundColumn UniqueName="id_pago_pk"           DataField="id_pago_pk"           HeaderText="id_pago_pk"            HeaderStyle-Width="100px" ItemStyle-Width="120px" HeaderStyle-HorizontalAlign="Center" Visible="False" ></telerik:GridBoundColumn>
                                        </Columns>
                                    </telerik:GridTableView>
                                </DetailTables>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridBoundColumn HeaderText="¿Quién Factura?"         UniqueName="nombre_empresa"      DataField="nombre_empresa"      HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Línea de servicio"       UniqueName="nombre_linea"        DataField="nombre_linea"        HeaderStyle-Width="250px" ItemStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Clave"                   UniqueName="id_ingreso"          DataField="id_ingreso"          HeaderStyle-Width="150px" ItemStyle-Width="150px" FilterControlWidth="110px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Autorizado"              UniqueName="autorizado"          DataField="autorizado"          HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estatus"                 UniqueName="Status"              DataField="Status"              HeaderStyle-Width="250px" ItemStyle-Width="250px" FilterControlWidth="210px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Estatus Descripción"     UniqueName="StatusDesc"          DataField="StatusDesc"          HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"                                                                                   FooterText="" FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Importe"                 UniqueName="importe"             DataField="importe"             HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" FooterText=""        FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Importe en Dlls."        UniqueName="importe_dlls"        DataField="importe_dlls"        HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" FooterText=""        FooterStyle-HorizontalAlign="Right" ></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Tipo de Moneda"          UniqueName="TipoMoneda"          DataField="TipoMoneda"          HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Total de pagos"          UniqueName="total_pagos"         DataField="total_pagos"         HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Right"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Socio"                   UniqueName="socio"               DataField="socio"               HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Gerente"                 UniqueName="Gerente"             DataField="Gerente"             HeaderStyle-Width="200px" ItemStyle-Width="200px" FilterControlWidth="160px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Cliente"                 UniqueName="nombre_cliente"      DataField="nombre_cliente"      HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Servicio"                UniqueName="nombre_servicio"     DataField="nombre_servicio"     HeaderStyle-Width="300px" ItemStyle-Width="300px" FilterControlWidth="260px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Años"                    UniqueName="años"                DataField="años"                HeaderStyle-Width="120px" ItemStyle-Width="120px" FilterControlWidth="80px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="Detalle"                 UniqueName="detalle"             DataField="detalle"             HeaderStyle-Width="400px" ItemStyle-Width="400px" FilterControlWidth="360px" HeaderStyle-HorizontalAlign="Center"></telerik:GridBoundColumn>
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
                <asp:SqlDataSource ID="SqlDataSourceLineas" runat="server" ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" SelectCommand="SELECT RIGHT ('0' + CAST(id_linea_servicio AS VARCHAR), 2) + ' ' + nombre_linea AS [linea_servicio] FROM LineasServicio WHERE (ss = 1) ORDER BY id_linea_servicio"></asp:SqlDataSource>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:CPAdminConnectionString %>" 
                    SelectCommand="SELECT Ingresos.id_ingreso, Ingresos.autorizado, TiposStatusCuenza.descripcion AS Status, TiposStatusDescCuenza.descripcion AS StatusDesc, importe = CASE WHEN (Ingresos.id_tipo_moneda = 1 OR Ingresos.id_tipo_moneda = 2) THEN Ingresos.importe ELSE 0 END, importe_dlls = CASE WHEN (Ingresos.id_tipo_moneda > 2) THEN Ingresos.importe ELSE 0 END, LineasServicio.nombre_linea, LineasServicio.socio AS Socio, LineasServicio.Gerente AS Gerente, Empresas.nombre_empresa, CLIENTES.nombre_cliente, SERVICIOS.nombre_servicio, Ingresos.años, Ingresos.detalle, TiposMoneda.descripcion AS TipoMoneda, Ingresos.total_pagos, Ingresos.especificacion_pago, Ingresos.id_ingreso_pk, LineasServicio.id_linea_servicio, Ingresos.motivo_cancelacion, Ingresos.fecha_cancelacion FROM IngresosPagos
                                    INNER JOIN Ingresos              ON (IngresosPagos.id_ingreso_pk = Ingresos.id_ingreso_pk)
                                    INNER JOIN Empresas              ON Ingresos.id_empresa          = Empresas.id_empresa
                                    INNER JOIN CLIENTES              ON Ingresos.id_cliente          = CLIENTES.id_cliente
                                    INNER JOIN SERVICIOS             ON Ingresos.id_servicio         = SERVICIOS.id_servicio AND Ingresos.id_linea_servicio = SERVICIOS.id_linea_servicio
                                    INNER JOIN LineasServicio        ON Ingresos.id_linea_servicio   = LineasServicio.id_linea_servicio
                                    INNER JOIN TiposStatusCuenza     ON Ingresos.id_status           = TiposStatusCuenza.id_status
                                    INNER JOIN TiposStatusDescCuenza ON Ingresos.id_status_desc      = TiposStatusDescCuenza.id_status_desc
                                    INNER JOIN TiposMoneda           ON Ingresos.id_tipo_moneda      = TiposMoneda.id_tipo_moneda
                                    WHERE (IngresosPagos.ss = 1) AND (Ingresos.id_linea_servicio = @id_ls_1 OR Ingresos.id_linea_servicio = @id_ls_2 OR Ingresos.id_linea_servicio = @id_ls_3 OR Ingresos.id_linea_servicio = @id_ls_4 OR Ingresos.id_linea_servicio = @id_ls_5 OR Ingresos.id_linea_servicio = @id_ls_6 OR Ingresos.id_linea_servicio = @id_ls_7 OR Ingresos.id_linea_servicio = @id_ls_8 OR Ingresos.id_linea_servicio = @id_ls_9 OR Ingresos.id_linea_servicio = @id_ls_10 OR Ingresos.id_linea_servicio = @id_ls_11 OR Ingresos.id_linea_servicio = @id_ls_12 OR Ingresos.id_linea_servicio = @id_ls_13 OR Ingresos.id_linea_servicio = @id_ls_14 OR Ingresos.id_linea_servicio = @id_ls_15 OR Ingresos.id_linea_servicio = @id_ls_16 OR Ingresos.id_linea_servicio = @id_ls_17 OR Ingresos.id_linea_servicio = @id_ls_18 OR Ingresos.id_linea_servicio = @id_ls_19 OR Ingresos.id_linea_servicio = @id_ls_20 OR Ingresos.id_linea_servicio = @id_ls_21 OR Ingresos.id_linea_servicio = @id_ls_22 OR Ingresos.id_linea_servicio = @id_ls_23 OR Ingresos.id_linea_servicio = @id_ls_24 OR Ingresos.id_linea_servicio = @id_ls_25 OR Ingresos.id_linea_servicio = @id_ls_26 OR Ingresos.id_linea_servicio = @id_ls_27 OR Ingresos.id_linea_servicio = @id_ls_28 OR Ingresos.id_linea_servicio = @id_ls_29 OR Ingresos.id_linea_servicio = @id_ls_30) 
                                      AND (IngresosPagos.fecha_fact >= @Fini_f AND IngresosPagos.fecha_fact <= @Ffin_f OR IngresosPagos.fecha_pago >= @Fini_p AND IngresosPagos.fecha_pago <= @Ffin_p) 
                                      AND (Ingresos.id_status = @Status1 OR Ingresos.id_status = @Status2 OR Ingresos.id_status = @Status3 OR Ingresos.id_status = @Status4 OR Ingresos.id_status = @Status5 OR Ingresos.id_status = @Status6 OR Ingresos.id_status = @Status7 OR Ingresos.id_status = @Status8 OR Ingresos.id_status = @Status9) 
                                      AND (IngresosPagos.id_tipo_factura = @TipoFactura1 OR IngresosPagos.id_tipo_factura = @TipoFactura2 OR IngresosPagos.id_tipo_factura = @TipoFactura3 OR IngresosPagos.id_tipo_factura = @TipoFactura4)
                                    GROUP BY Ingresos.id_ingreso_pk, Ingresos.id_ingreso, Ingresos.id_tipo_moneda, Ingresos.id_status, LineasServicio.id_linea_servicio, LineasServicio.nombre_linea, LineasServicio.gerente, LineasServicio.socio, Empresas.nombre_empresa, CLIENTES.nombre_cliente, SERVICIOS.nombre_servicio, Ingresos.autorizado, TiposStatusCuenza.descripcion, TiposStatusDescCuenza.descripcion, Ingresos.importe, Ingresos.años, Ingresos.detalle, TiposMoneda.descripcion, Ingresos.total_pagos, Ingresos.especificacion_pago, Ingresos.motivo_cancelacion, Ingresos.fecha_cancelacion
                                    ORDER BY Empresas.nombre_empresa, LineasServicio.id_linea_servicio, Ingresos.id_ingreso">
                    <SelectParameters>
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
                                <telerik:AjaxUpdatedControl ControlID="RadGrid1" LoadingPanelID="RadAjaxLoadingPanel1" />
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
                                <telerik:AjaxUpdatedControl ControlID="RadGridTotales" LoadingPanelID="RadAjaxLoadingPanel1" />
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

    </style>

    <link href="../Skin/ToolBar.Orange.css" rel="stylesheet" type="text/css" />

</asp:Content>
