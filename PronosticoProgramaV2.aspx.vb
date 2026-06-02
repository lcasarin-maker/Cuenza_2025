
Imports System.Data
Imports System.Data.SqlClient
Imports Domain
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class PronosticoProgramaV2
    Inherits System.Web.UI.Page


#Region "Variables"

    Public vRowIn As Integer = 0
    Public vTitulo As Integer
    Private isConfigured As Boolean = False

    Shared item As GridDataItem

    Shared TableName As String = ""

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oCli As New ClientesBL.ClientesBL
    Public oIng As New IngresosBL.IngresosBL

    Shared id_Usuario, id_rol, id_linea_servicio, id_empresa, id_tipo_moneda As Integer
    Shared id_cliente, id_servicio, id_status, id_status_desc As Integer

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                'Usuario = Session("nombres") & " " & Session("apellido_paterno") & " " & Session("apellido_materno")
                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                If Not Session("Lineas") Is Nothing Then
                    Session("Lineas") = Session("Lineas")
                End If


                'SqlDataSource1.SelectParameters("IdCliente").DefaultValue = 0
                SqlDataSource1.SelectParameters("vAño").DefaultValue = "1900"
                SqlDataSource1.SelectParameters("vCliente").DefaultValue = "#N/A"
                SqlDataSource1.DataBind()

                SqlDataSource2.SelectParameters("vid_ingreso_pk").DefaultValue = 0
                SqlDataSource2.DataBind()

                SqlDataSource3.SelectParameters("vid_ingreso_pk").DefaultValue = 0
                SqlDataSource3.DataBind()

                'LimpiarRadGrids()

            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Public Sub xLimpiarRadGridGenerales()
        'Dim v_DataTable As New DataTable
        ''v_DataTable = oIng.ExtraerIngresosIDBL(v_DataTable, 0)
        'v_DataTable.Columns.Add("Columna", Type.GetType("System.String"))
        'v_DataTable.Columns.Add("Dato", Type.GetType("System.String"))

        'v_DataTable.Rows.Add("Clave", "")
        'v_DataTable.Rows.Add("Autorizado", "")
        'v_DataTable.Rows.Add("Estatus", "")
        'v_DataTable.Rows.Add("Estatus descripción", "")
        'v_DataTable.Rows.Add("Importe", "")
        'v_DataTable.Rows.Add("Importe en dlls", "")
        'v_DataTable.Rows.Add("Linea de servicio", "")
        'v_DataTable.Rows.Add("Socio", "")
        'v_DataTable.Rows.Add("Gerente", "")
        'v_DataTable.Rows.Add("Quien factura", "")
        'v_DataTable.Rows.Add("Cliente", "")
        'v_DataTable.Rows.Add("Servicio", "")
        'v_DataTable.Rows.Add("Años", "")
        'v_DataTable.Rows.Add("Detalle", "")
        'v_DataTable.Rows.Add("Tipo de moneda", "")
        'v_DataTable.Rows.Add("Total de pagos", "")
        'v_DataTable.Rows.Add("Especificación de pago", "")
        'v_DataTable.Rows.Add("Motivo de cancelación", "")
        'v_DataTable.Rows.Add("Fecha de cancelación", "")

        'RadGridGenerales.DataSource = Nothing
        'RadGridGenerales.DataSource = v_DataTable

    End Sub

    Public Sub SessionCliente()
        Dim v_DataTable As New DataTable
        v_DataTable = oCli.ExtraerClientes2BL(v_DataTable)

        RadComboBoxCliente.DataSource = v_DataTable
        RadComboBoxCliente.DataTextField = "nombre_cliente"
        RadComboBoxCliente.DataValueField = "id_cliente"
        RadComboBoxCliente.DataBind()
    End Sub
    Protected Sub RadComboBoxCliente_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxCliente.SelectedIndexChanged
        id_cliente = e.Value
        'SessionCliente()
    End Sub
    Protected Sub RadComboBoxCliente_ItemsRequested(ByVal sender As Object, ByVal e As RadComboBoxItemsRequestedEventArgs)
        Dim sql As String = "SELECT id_cliente, REPLACE(RIGHT('0' + CAST(id_cliente AS VARCHAR), 2) + ' ' + nombre_cliente,'00 Seleccione','Seleccione') AS nombre_cliente FROM Clientes WHERE ss = 1 AND id_cliente > 1 AND Clientes.nombre_cliente LIKE '%' + @cliente + '%'"
        Dim adapter As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("CPAdminConnectionString").ConnectionString)
        adapter.SelectCommand.Parameters.AddWithValue("@cliente", e.Text)

        Dim dt3 As New DataTable()
        adapter.Fill(dt3)

        Dim comboBox3 As RadComboBox = DirectCast(sender, RadComboBox)
        comboBox3.Items.Clear()

        For Each row3 As DataRow In dt3.Rows
            Dim item3 As New RadComboBoxItem()
            item3.Text = row3("nombre_cliente").ToString()
            item3.Value = row3("id_cliente").ToString()
            comboBox3.Items.Add(item3)
            item3.DataBind()
        Next
    End Sub

    Protected Sub RadToolBarMostrar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMostrar.ButtonClick
        Dim scriptString As String = ""

        Try

            Dim vPos1 As Integer = RadComboBoxCliente.Text.IndexOf(" ") + 1
            Dim vCliente As String = Trim(Mid(RadComboBoxCliente.Text, vPos1))

            'Dim v_DataTable As New DataTable
            'v_DataTable = oIng.ExtraerIngresosAñoCteBL(v_DataTable, RadNumericTextBoxAño1.Value, vCliente)

            'RadGridProgramas.DataSource = Nothing
            'RadGridProgramas.DataSource = v_DataTable


            'If v_DataTable.Rows.Count > 0 Then
            '    Dim v_DataTable2 As New DataTable
            '    v_DataTable2 = oIng.ExtraerIngresosIDBL(v_DataTable2, v_DataTable.Rows(0).Item("id_ingreso_pk"))

            '    RadGridGenerales.DataSource = Nothing
            '    RadGridGenerales.DataSource = v_DataTable2
            'End If


            'SqlDataSource1.SelectParameters("IdCliente").DefaultValue = RadNumericTextBoxAño1.Value
            SqlDataSource1.SelectParameters("vAño").DefaultValue = RadNumericTextBoxAño1.Value
            SqlDataSource1.SelectParameters("vCliente").DefaultValue = vCliente
            SqlDataSource1.DataBind()

            Dim v_DataTable As New DataTable
            v_DataTable = oIng.ExtraerIngresosAñoCteBL(v_DataTable, RadNumericTextBoxAño1.Value, vCliente)


            If v_DataTable.Rows.Count > 0 Then
                'If RadGridProgramas.Items.Count > 0 Then

                'Dim item As GridDataItem = TryCast(RadGridProgramas.Items(0), GridDataItem)
                Dim vID As Integer = v_DataTable.Rows(0).Item("id_ingreso_pk") ' item("id_ingreso_pk").Text

                SqlDataSource2.SelectParameters("vid_ingreso_pk").DefaultValue = vID
                SqlDataSource2.DataBind()

                SqlDataSource3.SelectParameters("vid_ingreso_pk").DefaultValue = vID
                SqlDataSource3.DataBind()

                'Dim v_DataTable As New DataTable
                'v_DataTable = oIng.ExtraerIngresosIDBL(v_DataTable, vID)

                'RadGridGenerales.DataSource = Nothing
                'RadGridGenerales.DataSource = v_DataTable

            Else
                SqlDataSource2.SelectParameters("vid_ingreso_pk").DefaultValue = 0
                SqlDataSource2.DataBind()

                SqlDataSource3.SelectParameters("vid_ingreso_pk").DefaultValue = 0
                SqlDataSource3.DataBind()

            End If

        Catch ex As Exception
            scriptString = "alert('Error al intentar obtener los programas del cliente seleccionado. \n\n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

    Public Sub RadGridProgramas_SelectedIndexChanged(sender As Object, e As EventArgs) 'Handles RadGridProgramas.SelectedIndexChanged
        'Dim scriptString As String = ""



        Dim dataItem As GridDataItem = TryCast(RadGridProgramas.SelectedItems(0), GridDataItem)
        If Not dataItem Is Nothing Then
            Dim vID As String = dataItem("id_ingreso_pk").Text
            'Dim vClave As String = dataItem("id_ingreso").Text

            SqlDataSource2.SelectParameters("vid_ingreso_pk").DefaultValue = vID
            SqlDataSource2.DataBind()

            SqlDataSource3.SelectParameters("vid_ingreso_pk").DefaultValue = vID
            SqlDataSource3.DataBind()

            'scriptString = "alert('Clave y ID: " & vClave & " - " & vID & "');"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Renglon", scriptString, True)

        End If

    End Sub



    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        lblMensaje.Text = ""
        Select Case e.Item.Text
            Case "Generar Reporte"
                GenerarReporte()
        End Select
    End Sub
    Public Sub GenerarReporte()
        Dim scriptString As String = ""

        If RadGridPagos.Items.Count > 0 Then

            Try

                Dim dataItem0 As GridDataItem = TryCast(RadGridGenerales.Items(0), GridDataItem)
                Dim vID As String = dataItem0("Dato").Text

                Dim dataItem1 As GridDataItem = TryCast(RadGridGenerales.Items(5), GridDataItem)
                Dim vLS As String = dataItem1("Dato").Text

                Dim vLSint As Integer = Trim(Left(vLS, 2))

                'Dim Usuario As String = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno
                Dim accessSQL As New DataAccess.SQL
                Dim selSql As String = ""

                selSql = "SET DATEFORMAT dmy;" _
                     & " BEGIN TRAN " _
                     & "     " _
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Pronósticos por Cliente', " & vID & ", " & vLSint & ")" _
                     & "     " _
                     & "		IF @@ERROR <> 0  " _
                     & "		BEGIN " _
                     & "			ROLLBACK " _
                     & "			RETURN " _
                     & "		END " _
                     & "	COMMIT TRANSACTION"
                accessSQL.ExecuteNonQueryD(selSql)
                accessSQL.Close()

                vRowIn = 0
                vTitulo = 0

                RadGridPagos.ExportSettings.ExportOnlyData = True
                RadGridPagos.ExportSettings.IgnorePaging = True
                RadGridPagos.ExportSettings.FileName = "Pronosticos, Programas y Gastos (L.S. " & vLS & " Clave " & vID & ") " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGridPagos.ExportSettings.OpenInNewWindow = True


                'RadGridPagos.MasterTableView.GetColumn("id_ingreso_pk").Visible = False
                'RadGridPagos.MasterTableView.GetColumn("id_linea_servicio").Visible = False
                RadGridPagos.MasterTableView.HierarchyDefaultExpanded = True
                'RadGridPagos.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = True

                RadGridPagos.MasterTableView.HierarchyLoadMode = GridChildLoadMode.Client
                'RadGridPagos.MasterTableView.DetailTables(0).HierarchyLoadMode = GridChildLoadMode.Client

                'RadGridPagos.Rebind()
                'RadGridPagos.MasterTableView.GridLines = GridLines.None
                RadGridPagos.MasterTableView.ExportToExcel()

            Catch ex As Exception
                scriptString = "alert('Error al intentar generar el reporte. \n\n " & ex.Message & "');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            End Try

        Else
            scriptString = "alert('No existen registros en la Base de Datos.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If
    End Sub
    Protected Sub RadGridPagos_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs) Handles RadGridPagos.ExcelMLExportRowCreated

        If e.Row.Cells(0).ColumnName = "no_pago" And e.RowType = GridExportExcelMLRowType.HeaderRow Then
            Dim i As Integer = 0
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).StyleValue = "masterTable"
            Next
        End If

        If e.RowType = GridExportExcelMLRowType.DataRow Then

            Dim vRows As Integer = e.Worksheet.Table.Rows.Count
            Dim vRowTot As Integer = RadGridPagos.Items.Count + 26 ' RowElement = e.Row

            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("no_pago")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("no_pago").StyleValue = "myStyleMT1_1"
                Else
                    e.Row.Cells.GetCellByName("no_pago").StyleValue = "myStyleMT1"
                End If
            End If

            cell2 = e.Row.Cells.GetCellByName("folio_factura")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("folio_factura").StyleValue = "myStyleMT2_2"
                Else
                    e.Row.Cells.GetCellByName("folio_factura").StyleValue = "myStyleMT2"
                End If
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_fact")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("fecha_fact").StyleValue = "myStyleMT2_2"
                Else
                    e.Row.Cells.GetCellByName("fecha_fact").StyleValue = "myStyleMT2"
                End If
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_pago")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("fecha_pago").StyleValue = "myStyleMT2_2"
                Else
                    e.Row.Cells.GetCellByName("fecha_pago").StyleValue = "myStyleMT2"
                End If
            End If
            cell2 = e.Row.Cells.GetCellByName("importe")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("importe").StyleValue = "myStyleDecimalMT_1"
                Else
                    e.Row.Cells.GetCellByName("importe").StyleValue = "myStyleDecimalMT"
                End If
            End If
            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("concepto").StyleValue = "myStyleMT4_4"
                Else
                    e.Row.Cells.GetCellByName("concepto").StyleValue = "myStyleMT4"
                End If
            End If
            cell2 = e.Row.Cells.GetCellByName("tipo_factura")
            If Not cell2 Is Nothing Then
                If vRowTot = vRows Then
                    e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myStyleMT3_3"
                Else
                    e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myStyleMT3"
                End If
            End If

        End If


        If vTitulo = 0 Then
            If e.RowType = Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then

                Dim row As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = "Detalle de los Pagos"
                cell.StyleValue = "MyTitle3"
                row.Cells.Add(cell)
                cell.MergeAcross = 6

                e.Worksheet.Table.Rows.Insert(0, row)

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                row.Cells.Add(cell)


                For i As Integer = RadGridGenerales.MasterTableView.Items.Count - 1 To 0 Step -1

                    e.Worksheet.Table.Rows.Insert(0, row)

                    row = New Telerik.Web.UI.GridExcelBuilder.RowElement()

                    Dim dataItem As GridDataItem = TryCast(RadGridGenerales.Items(i), GridDataItem)
                    Dim vColu As String = dataItem("Columna").Text
                    Dim vDato As String = Replace(dataItem("Dato").Text, "&nbsp;", "")

                    Dim cell_grales1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_grales1.Data.DataItem = vColu
                    cell_grales1.StyleValue = "myStyleGrales1"
                    row.Cells.Add(cell_grales1)

                    Dim cell_grales2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_grales2.Data.DataItem = vDato
                    cell_grales2.StyleValue = "myStyleGrales2"
                    row.Cells.Add(cell_grales2)
                    cell_grales2.MergeAcross = 3

                    If vColu = "Fecha de cancelación" Then
                        cell_grales1.StyleValue = "myStyleGrales3"
                        cell_grales2.StyleValue = "myStyleGrales4"
                    Else

                    End If

                Next

                e.Worksheet.Table.Rows.Insert(0, row)

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = "Datos Generales"
                cell.StyleValue = "MyTitle3"
                row.Cells.Add(cell)
                cell.MergeAcross = 4


                e.Worksheet.Table.Rows.Insert(0, row)

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                row.Cells.Add(cell)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row.Cells.Add(cell_vacia)
                Next


                e.Worksheet.Table.Rows.Insert(0, row)

                Dim row1 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell1.Data.DataItem = "Fecha: " & FormatDateTime(Today, DateFormat.LongDate)
                cell1.StyleValue = "MyTitle2"
                row1.Cells.Add(cell1)


                e.Worksheet.Table.Rows.Insert(0, row1)

                Dim row2 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell2.Data.DataItem = "Reporte de Pronósticos, Programas y Gastos"
                cell2.StyleValue = "MyTitle1"
                row2.Cells.Add(cell2)


                e.Worksheet.Table.Rows.Insert(0, row2)

                Dim row3 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell3 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell3.Data.DataItem = "Cuenza. Control de Cuentas y Cobranza"
                cell3.StyleValue = "MyTitle"
                row3.Cells.Add(cell3)

                e.Worksheet.Table.Rows.Insert(0, row3)

                vTitulo = 1
            End If
        End If

        If e.RowType = GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then
            e.Worksheet.AutoFilter.Range = ""
        End If


        If Not isConfigured Then
            Dim va As Integer = e.Worksheet.Table.Columns.Count
            If va > 0 Then

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                Dim cell2 As CellElement = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                Dim column As ColumnElement = TryCast(e.Worksheet.Table.Columns(0), ColumnElement)
                column.Attributes("ss:Width") = "120"

                column = TryCast(e.Worksheet.Table.Columns(1), ColumnElement)
                column.Attributes("ss:Width") = "88"

                column = TryCast(e.Worksheet.Table.Columns(2), ColumnElement)
                column.Attributes("ss:Width") = "120"

                column = TryCast(e.Worksheet.Table.Columns(3), ColumnElement)
                column.Attributes("ss:Width") = "120"

                column = TryCast(e.Worksheet.Table.Columns(4), ColumnElement)
                column.Attributes("ss:Width") = "120"

                column = TryCast(e.Worksheet.Table.Columns(5), ColumnElement)
                column.Attributes("ss:Width") = "282"

                column = TryCast(e.Worksheet.Table.Columns(6), ColumnElement)
                column.Attributes("ss:Width") = "105"

                'Dim vRow As RowElement = e.Worksheet.Table.Rows(1)
                'vRow.Attributes("ss:Height") = 18
                'vRow.Attributes("ss:InteriorStyle.Color") = "System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))"

                e.Worksheet.Name = "Pronósticos, Programas y Gastos"

                'e.Worksheet.Attributes.Add(GridLines.None)
                'e.Worksheet.WorksheetOptions.PageSetup.Attributes.

                'e.WorkBook.Worksheets(0).WorksheetOptions
                'e.Worksheet.Table(0).WorksheetOptions.

                isConfigured = True
            End If
        End If

    End Sub
    Protected Sub RadGridPagos_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As GridExportExcelMLStyleCreatedArgs) Handles RadGridPagos.ExcelMLExportStylesCreated

        ' border1 Dash       Top
        ' border2 Dash       Bottom
        ' border3 Dash       Left
        ' border4 Dash       Right
        ' border5 Continuous Bottom
        ' border6 Continuous Right
        ' border7 Continuous Left

        ' myStyleMT1 myStyleMT1_1
        ' myStyleMT2 myStyleMT2_2
        ' myStyleDecimalMT myStyleDecimalMT_1
        ' myStyleMT3 myStyleMT3_3



        '--------------------------------------------------
        ' Bordes
        '--------------------------------------------------
        Dim border1 As BorderStyles = New BorderStyles()
        border1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border1.Weight = 1
        border1.LineStyle = LineStyle.Dash
        border1.PositionType = PositionType.Top

        Dim border2 As BorderStyles = New BorderStyles()
        border2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border2.Weight = 1
        border2.LineStyle = LineStyle.Dash
        border2.PositionType = PositionType.Bottom

        Dim border3 As BorderStyles = New BorderStyles()
        border3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border3.Weight = 1
        border3.LineStyle = LineStyle.Dash
        border3.PositionType = PositionType.Left

        Dim border4 As BorderStyles = New BorderStyles()
        border4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border4.Weight = 1
        border4.LineStyle = LineStyle.Dash
        border4.PositionType = PositionType.Right

        Dim border5 As BorderStyles = New BorderStyles()
        border5.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border5.Weight = 1
        border5.LineStyle = LineStyle.Continuous
        border5.PositionType = PositionType.Bottom

        Dim border6 As BorderStyles = New BorderStyles()
        border6.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border6.Weight = 1
        border6.LineStyle = LineStyle.Continuous
        border6.PositionType = PositionType.Right

        Dim border7 As BorderStyles = New BorderStyles()
        border7.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border7.Weight = 1
        border7.LineStyle = LineStyle.Continuous
        border7.PositionType = PositionType.Left



        Dim borderM1 As BorderStyles = New BorderStyles()
        borderM1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM1.Weight = 2
        borderM1.LineStyle = LineStyle.Continuous
        borderM1.PositionType = PositionType.Top

        Dim borderM2 As BorderStyles = New BorderStyles()
        borderM2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM2.Weight = 2
        borderM2.LineStyle = LineStyle.Continuous
        borderM2.PositionType = PositionType.Bottom

        Dim borderM3 As BorderStyles = New BorderStyles()
        borderM3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM3.Weight = 2
        borderM3.LineStyle = LineStyle.Continuous
        borderM3.PositionType = PositionType.Left

        Dim borderM4 As BorderStyles = New BorderStyles()
        borderM4.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM4.Weight = 2
        borderM4.LineStyle = LineStyle.Continuous
        borderM4.PositionType = PositionType.Right


        Dim masterTable As New StyleElement("masterTable")
        masterTable.FontStyle.Bold = True
        masterTable.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        masterTable.FontStyle.Color = Drawing.Color.White
        masterTable.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        masterTable.InteriorStyle.Pattern = InteriorPatternType.Solid
        masterTable.Borders.Add(borderM1)
        masterTable.Borders.Add(borderM3)
        masterTable.Borders.Add(borderM4)
        e.Styles.Add(masterTable)

        Dim styleMyTitle As New StyleElement("MyTitle")
        styleMyTitle.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle.FontStyle.Bold = True
        styleMyTitle.FontStyle.Size = 14
        styleMyTitle.FontStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        e.Styles.Add(styleMyTitle)

        Dim styleMyTitle1 As New StyleElement("MyTitle1")
        styleMyTitle1.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle1.FontStyle.Bold = True
        styleMyTitle1.FontStyle.Size = 14
        e.Styles.Add(styleMyTitle1)

        Dim styleMyTitle2 As New StyleElement("MyTitle2")
        styleMyTitle2.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle2.FontStyle.Bold = True
        styleMyTitle2.FontStyle.Size = 11
        e.Styles.Add(styleMyTitle2)

        Dim styleMyTitle3 As New StyleElement("MyTitle3")
        styleMyTitle3.FontStyle.Bold = True
        styleMyTitle3.FontStyle.Size = 9
        styleMyTitle3.FontStyle.Color = Drawing.Color.White
        styleMyTitle3.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        styleMyTitle3.InteriorStyle.Pattern = InteriorPatternType.Solid
        styleMyTitle3.Borders.Add(borderM1)
        styleMyTitle3.Borders.Add(borderM2)
        styleMyTitle3.Borders.Add(borderM3)
        styleMyTitle3.Borders.Add(borderM4)
        e.Styles.Add(styleMyTitle3)


        Dim myStyleGrales1 As New StyleElement("myStyleGrales1")
        myStyleGrales1.FontStyle.Bold = True
        myStyleGrales1.FontStyle.Size = 9
        myStyleGrales1.Borders.Add(border1)
        myStyleGrales1.Borders.Add(border2)
        myStyleGrales1.Borders.Add(border7)
        e.Styles.Add(myStyleGrales1)

        Dim myStyleGrales2 As New StyleElement("myStyleGrales2")
        myStyleGrales2.FontStyle.Size = 9
        myStyleGrales2.Borders.Add(border1)
        myStyleGrales2.Borders.Add(border2)
        myStyleGrales2.Borders.Add(border3)
        myStyleGrales2.Borders.Add(border6)
        e.Styles.Add(myStyleGrales2)

        Dim myStyleGrales3 As New StyleElement("myStyleGrales3")
        myStyleGrales3.FontStyle.Bold = True
        myStyleGrales3.FontStyle.Size = 9
        myStyleGrales3.Borders.Add(border5)
        myStyleGrales3.Borders.Add(border7)
        e.Styles.Add(myStyleGrales3)

        Dim myStyleGrales4 As New StyleElement("myStyleGrales4")
        myStyleGrales4.FontStyle.Size = 9
        myStyleGrales4.Borders.Add(border3)
        myStyleGrales4.Borders.Add(border5)
        myStyleGrales4.Borders.Add(border6)
        e.Styles.Add(myStyleGrales4)


        Dim myStyleMT1 As New StyleElement("myStyleMT1")
        myStyleMT1.FontStyle.Size = 9
        myStyleMT1.Borders.Add(border1)
        myStyleMT1.Borders.Add(border2)
        myStyleMT1.Borders.Add(border7)
        myStyleMT1.Borders.Add(border4)
        e.Styles.Add(myStyleMT1)

        Dim myStyleMT1_1 As New StyleElement("myStyleMT1_1")
        myStyleMT1_1.FontStyle.Size = 9
        myStyleMT1_1.Borders.Add(border1)
        myStyleMT1_1.Borders.Add(border5)
        myStyleMT1_1.Borders.Add(border7)
        myStyleMT1_1.Borders.Add(border4)
        e.Styles.Add(myStyleMT1_1)

        Dim myStyleMT2 As New StyleElement("myStyleMT2")
        myStyleMT2.FontStyle.Size = 9
        myStyleMT2.Borders.Add(border1)
        myStyleMT2.Borders.Add(border2)
        myStyleMT2.Borders.Add(border3)
        myStyleMT2.Borders.Add(border4)
        e.Styles.Add(myStyleMT2)

        Dim myStyleMT2_2 As New StyleElement("myStyleMT2_2")
        myStyleMT2_2.FontStyle.Size = 9
        myStyleMT2_2.Borders.Add(border1)
        myStyleMT2_2.Borders.Add(border5)
        myStyleMT2_2.Borders.Add(border3)
        myStyleMT2_2.Borders.Add(border4)
        e.Styles.Add(myStyleMT2_2)


        Dim myStyleMT3 As New StyleElement("myStyleMT3")
        myStyleMT3.FontStyle.Size = 9
        myStyleMT3.Borders.Add(border1)
        myStyleMT3.Borders.Add(border2)
        myStyleMT3.Borders.Add(border3)
        myStyleMT3.Borders.Add(border6)
        e.Styles.Add(myStyleMT3)

        Dim myStyleMT3_3 As New StyleElement("myStyleMT3_3")
        myStyleMT3_3.FontStyle.Size = 9
        myStyleMT3_3.Borders.Add(border1)
        myStyleMT3_3.Borders.Add(border5)
        myStyleMT3_3.Borders.Add(border3)
        myStyleMT3_3.Borders.Add(border6)
        e.Styles.Add(myStyleMT3_3)


        Dim myStyleMT4 As New StyleElement("myStyleMT4")
        myStyleMT4.FontStyle.Size = 9
        myStyleMT4.Borders.Add(border1)
        myStyleMT4.Borders.Add(border2)
        myStyleMT4.Borders.Add(border3)
        myStyleMT4.Borders.Add(border4)
        myStyleMT4.AlignmentElement.Attributes.Add("ss:WrapText", "1")
        e.Styles.Add(myStyleMT4)


        Dim myStyleMT4_4 As New StyleElement("myStyleMT4_4")
        myStyleMT4_4.FontStyle.Size = 9
        myStyleMT4_4.Borders.Add(border1)
        myStyleMT4_4.Borders.Add(border5)
        myStyleMT4_4.Borders.Add(border3)
        myStyleMT4_4.Borders.Add(border4)
        myStyleMT4_4.AlignmentElement.Attributes.Add("ss:WrapText", "1")
        e.Styles.Add(myStyleMT4_4)


        Dim myStyleDecMT As New StyleElement("myStyleDecimalMT")
        myStyleDecMT.Borders.Add(border1)
        myStyleDecMT.Borders.Add(border2)
        myStyleDecMT.Borders.Add(border3)
        myStyleDecMT.Borders.Add(border4)
        myStyleDecMT.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDecMT)

        Dim myStyleDecMT_1 As New StyleElement("myStyleDecimalMT_1")
        myStyleDecMT_1.Borders.Add(border1)
        myStyleDecMT_1.Borders.Add(border5)
        myStyleDecMT_1.Borders.Add(border3)
        myStyleDecMT_1.Borders.Add(border4)
        myStyleDecMT_1.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDecMT_1)


        For Each style As StyleElement In e.Styles

            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))

                '--------------------------------------------------
                ' Bordes
                '--------------------------------------------------
                Dim borderH1 As BorderStyles = New BorderStyles()
                borderH1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH1.Weight = 2
                borderH1.LineStyle = LineStyle.Continuous
                borderH1.PositionType = PositionType.Top

                Dim borderH2 As BorderStyles = New BorderStyles()
                borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH2.Weight = 1
                borderH2.LineStyle = LineStyle.Continuous
                borderH2.PositionType = PositionType.Bottom

                Dim borderH3 As BorderStyles = New BorderStyles()
                borderH3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH3.Weight = 2
                borderH3.LineStyle = LineStyle.Continuous
                borderH3.PositionType = PositionType.Left

                Dim borderH4 As BorderStyles = New BorderStyles()
                borderH4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH4.Weight = 2
                borderH4.LineStyle = LineStyle.Continuous
                borderH4.PositionType = PositionType.Right
                style.Borders.Add(borderH1)
                style.Borders.Add(borderH2)
                style.Borders.Add(borderH3)
                style.Borders.Add(borderH4)

            End If

        Next

    End Sub


End Class
