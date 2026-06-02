
Imports System.Data.OleDb
Imports System.IO
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Imports Domain
Imports UsuariosBL
Imports IngresosPagosBL

Partial Class FacturacionImportarPagos
    Inherits System.Web.UI.Page

#Region "Variables"
    Public lU As New List(Of IUsuario)
    Shared Usuario As String
    Public oPag As New IngresosPagosBL.IngresosPagosBL
    Public oFac As New FacturacionBL.FacturacionBL
    Shared id_Usuario, id_rol, id_linea_servicio As Integer
    Public v_DataTable As DataTable
    Shared dtDepTmp As New DataTable
    Public v_DataTable_Pagos As New DataTable

    Public vRowIn As Integer = 0
    Public vTitulo As Integer
    Private isConfigured As Boolean = False

#End Region

    Public Sub VaciarControles()

        'RadUploadExcel.UploadedFiles.Clear()
        RadNumericTextBoxTotal.Text = ""
        
        'Dim v_DataTable_Pagos As New DataTable
        'v_DataTable_Pagos = oPag.ExtraerIngresosPagosIDBL(v_DataTable_Pagos, 0)
        ''RadGridPagos.DataSource = Nothing
        'RadGridPagos.DataSource = v_DataTable_Pagos

        ' Eliminar tablas
        Dim TableName As String = "DepositosPagosTmp0"
        oFac.ImportarPagosEliminarTablasBL(TableName)
        TableName = "DepositosPagosTmp"
        oFac.ImportarPagosEliminarTablasBL(TableName)

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                VaciarControles()
            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Protected Sub ButtonLeerArchivo_Click(sender As Object, e As EventArgs) Handles ButtonLeerArchivo.Click
        
        Dim scriptString As String = ""

        Try
            
            VaciarControles()

            'If RadUploadExcel.UploadedFiles.Count > 0 Then

            'Dim instancia As HttpRequest
            Dim strMap As String = Server.MapPath("~") & "\Ficheros"
            Dim _carpeta As String = "Recursos\Archivos\"
            Dim _directorioGral As String = Server.MapPath("~") & "\Ficheros"


            Dim _extension As String = Path.GetExtension(RadUploadExcel.UploadedFiles.Item(0).FileName)

            If ChecarExtension(_extension) Then

                Dim _directorioParaGuardar As String = strMap + "\" + RadUploadExcel.UploadedFiles.Item(0).GetName

                ' Eliminar Archivos Existentes
                EliminarArchivos(strMap)

                ' Guardar nuevo archivo
                RadUploadExcel.UploadedFiles.Item(0).SaveAs(_directorioParaGuardar)
                
                ' Importar datos del archivo de Excel
                ImportarExcel(_directorioParaGuardar)

                ' Importar depositos
                Dim TableName As String = "DepositosPagosTmp0"
                oFac.ImportarPagosEliminarTablasBL(TableName)
                oFac.ImportarPagosCrearTablasBL(TableName)
                oFac.ImportarPagosBulkInsertBL(dtDepTmp, TableName)

                ' Corregir depositos
                TableName = "DepositosPagosTmp"
                oFac.ImportarPagosEliminarTablasBL(TableName)
                TableName = "DepositosPagosTmp2"
                oFac.ImportarPagosEliminarTablasBL(TableName)
                oFac.ImportarPagosCorregirBL(TableName)

                ' Procesar depósitos
                oFac.ImportarPagosProcesarBL(Usuario, id_linea_servicio)

                ' Obtener resultados finales
                v_DataTable_Pagos = New DataTable
                oFac.ImportarPagosExtraerBL(v_DataTable_Pagos)

                ' tipo_factura
                ' folio_factura
                ' fecha_fact
                ' fecha_pago
                ' fecha_deposito
                ' importe
                ' importe_pago
                ' concepto
                ' status

                ' LLenar RadGrid
                'RadGridPagos.DataSource = v_DataTable_Pagos
                RadGridPagos.Rebind()
                RadNumericTextBoxTotal.Text = RadGridPagos.Items.Count

                ' Eliminar Archivo Creado
                EliminarArchivos(strMap)

                TableName = "DepositosPagosTmp0"
                oFac.ImportarPagosEliminarTablasBL(TableName)
                'TableName = "DepositosPagosTmp"
                'oFac.ImportarPagosEliminarTablasBL(TableName)
                TableName = "DepositosPagosTmp2"
                oFac.ImportarPagosEliminarTablasBL(TableName)

            End If

        Catch ex As Exception
            LabelError.Text = ex.ToString
            'scriptString = "alert('Error al cargar el archivo " & ex.ToString & ".');"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

        'Else
        'scriptString = "alert('Favor de seleccionar el archivo con los datos de los depósitos..');"
        'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        'End If

    End Sub
    Public Shared Function ChecarExtension(ByVal extension As String) As Boolean

        Select Case extension.ToLower()
            Case ".xls"
                Return True
            Case ".xlsx"
                Return True
            Case Else
                Return False
        End Select

    End Function
    Public Shared Sub EliminarArchivos(ByVal instancia As String)

        'Dim _carpeta As String = "\Recursos\Archivos\"
        Dim _directorioGral As String = instancia

        Dim directorio As New DirectoryInfo(_directorioGral)
        Dim archivos As FileInfo() = directorio.GetFiles()
        Dim archivo As FileInfo

        For Each archivo In archivos
            archivo.Delete()
        Next

    End Sub
    Public Shared Function ImportarExcel(ByVal ruta As String)

        'Dim _cadenaconexion As String = String.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties = 'Excel 8.0;IMEX = 1;HDR = NO'", ruta)
        Dim _cadenaconexion As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties = 'Excel 12.0 Xml;IMEX=1;HDR=NO'", ruta)
        'Dim _cadenaconexion As String = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0", ruta)

        Dim _oledbConn As New OleDbConnection(_cadenaconexion)

        _oledbConn.Open()

        Dim _cmd As OleDbCommand
        _cmd = New OleDbCommand("SELECT F1 AS fecha_deposito, LTRIM(F4) AS folio_factura, F7 AS importe_pago " _
                                & "FROM [Reporte de Compac$]  " _
                                & "WHERE F1 IS NOT NULL AND LEFT(LTRIM(F4),7) = 'Factura' AND F7 IS NOT NULL ", _oledbConn)

        Dim _oleda As OleDbDataAdapter = New OleDbDataAdapter()
        _oleda.SelectCommand = _cmd

        dtDepTmp.Clear()
        dtDepTmp.Rows.Clear()
        dtDepTmp = New DataTable
        _oleda.Fill(dtDepTmp)

        _oleda.Dispose()
        _cmd.Dispose()
        _oledbConn.Close()

        'Dim f_1 As Integer = 0
        'For f_1 = 0 To dtDepTmp.Rows.Count - 1
        '    Dim scriptString As String = "alert('Error al intentar generar el reporte. \n\n " & ex.Message & "');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        'Next

        Return dtDepTmp
    End Function

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Select Case e.Item.Text
            Case "Nuevo"
                RadUploadExcel.UploadedFiles.Clear()
                VaciarControles()
                RadGridPagos.Rebind()
            Case "Cancelar"
                VaciarControles()
                Response.Redirect("~/Facturacion.aspx")
        End Select
    End Sub

    Protected Sub RadGridPagos_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridPagos.NeedDataSource
        v_DataTable_Pagos = New DataTable
        oFac.ImportarPagosExtraerBL(v_DataTable_Pagos)
        RadGridPagos.DataSource = v_DataTable_Pagos
    End Sub

    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        GenerarReporte()
    End Sub
    Public Sub GenerarReporte()
        Dim scriptString As String = ""

        If RadGridPagos.Items.Count > 0 Then

            Try
                Dim accessSQL As New DataAccess.SQL
                Dim selSql As String = ""

                selSql = "SET DATEFORMAT dmy;" _
                     & " BEGIN TRAN " _
                     & "     " _
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Facturas para importar pagos', 0, " & id_linea_servicio & ")" _
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
                RadGridPagos.ExportSettings.FileName = "Facturas para importar pagos " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGridPagos.ExportSettings.OpenInNewWindow = True

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
    Protected Sub RadGridpagos_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs) Handles RadGridPagos.ExcelMLExportRowCreated

        ' tipo_factura     myDetailStyle
        ' folio_factura    myDetailStyleNumeric
        ' fecha_fact       myDetailStyle
        ' fecha_pago       myDetailStyle
        ' fecha_deposito   myDetailStyle
        ' importe          myDetailStyleDecimal
        ' importe_pago     myDetailStyleDecimal
        ' concepto         myDetailStyle
        ' estatus          myDetailStyle

        If e.RowType = GridExportExcelMLRowType.DataRow Then

            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("tipo_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("folio_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("folio_factura").StyleValue = "myDetailStyleNumeric"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_fact")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_fact").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_pago").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe_pago").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("concepto").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("estatus")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("estatus").StyleValue = "myDetailStyle"
            End If

        End If


        If vTitulo = 0 Then
            If e.RowType = Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then

                Dim row As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                'cell.StyleValue = "MyTitle"
                row.Cells.Add(cell)
                e.Worksheet.Table.Rows.Insert(0, row)

                Dim row2 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell2.Data.DataItem = "Fecha: " & Today
                cell2.StyleValue = "MyTitle2"
                row2.Cells.Add(cell2)
                e.Worksheet.Table.Rows.Insert(0, row2)

                ' FormatDateTime(Today, DateFormat.LongDate)
                'CultureInfo.CreateSpecificCulture("es-MX")

                Dim row3 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell3 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell3.Data.DataItem = "Reporte de Facturas para importar pagos"
                cell3.StyleValue = "MyTitle2"
                row3.Cells.Add(cell3)
                e.Worksheet.Table.Rows.Insert(0, row3)

                Dim row4 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell4 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell4.Data.DataItem = "C.P. & A. S.C."
                cell4.StyleValue = "MyTitle2"
                row4.Cells.Add(cell4)
                e.Worksheet.Table.Rows.Insert(0, row4)

                vTitulo = 1
            End If
        End If

        If e.RowType = GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then
            e.Worksheet.AutoFilter.Range = ""
        End If


        If Not isConfigured Then
            Dim va As Integer = e.Worksheet.Table.Columns.Count
            If va > 0 Then

                For Each column As ColumnElement In e.Worksheet.Table.Columns
                    If e.Worksheet.Table.Columns.IndexOf(column) = 7 Or e.Worksheet.Table.Columns.IndexOf(column) = 8 Then
                        column.Attributes("ss:Width") = "266"
                        'ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 8 Then
                        '    column.Attributes("ss:Width") = "161"
                    Else
                        column.Attributes("ss:Width") = "109"
                    End If
                Next

                ' 0 tipo_factura     109
                ' 1 folio_factura    109
                ' 2 fecha_fact       109
                ' 3 fecha_pago       109
                ' 4 fecha_deposito   109
                ' 5 importe          109
                ' 6 importe_pago     109
                ' 7 concepto         266 dif
                ' 8 estatus          161 dif

                Dim vRow As RowElement = e.Worksheet.Table.Rows(4)
                vRow.Attributes("ss:Height") = 20
                vRow.Attributes("ss:InteriorStyle.Color") = "System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))"

                e.Worksheet.Name = "Facturación pagos"

                isConfigured = True
            End If
        End If

    End Sub
    Protected Sub RadGridPagos_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As GridExportExcelMLStyleCreatedArgs) Handles RadGridPagos.ExcelMLExportStylesCreated

        Dim styleMyTitle As New StyleElement("MyTitle")
        styleMyTitle.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle.FontStyle.Bold = True
        styleMyTitle.FontStyle.Size = 14
        e.Styles.Add(styleMyTitle)

        Dim styleMyTitle2 As New StyleElement("MyTitle2")
        styleMyTitle2.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle2.FontStyle.Bold = True
        styleMyTitle2.FontStyle.Size = 11
        e.Styles.Add(styleMyTitle2)

        Dim myStyle As New StyleElement("myDetailStyle")
        e.Styles.Add(myStyle)

        Dim myStyleNum As New StyleElement("myDetailStyleNumeric")
        myStyleNum.NumberFormat.Attributes("ss:Format") = "#,##0" ' "MM/dd"
        e.Styles.Add(myStyleNum)

        Dim myStyleDec As New StyleElement("myDetailStyleDecimal")
        myStyleDec.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDec)


        'Apply background colors 
        For Each style As StyleElement In e.Styles

            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.FontStyle.Color = Drawing.Color.White
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
            End If

            If style.Id.Contains("itemStyle") OrElse style.Id = "alternatingItemStyle" Then
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            End If

            If style.Id.Contains("myDetailStyle") OrElse style.Id = "myDetailStyleNumeric" OrElse style.Id = "myDetailStyleDecimal" Then
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
                'style.InteriorStyle.Pattern = InteriorPatternType.Solid
                'style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(185, Byte), Integer))
            End If

        Next

    End Sub


End Class
