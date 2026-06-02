
Imports System.IO
Imports Domain
Imports UsuariosBL
Imports FacturacionBL
'Imports ClientesBL
Imports LineasServicioBL
'Imports IngresosBL
'Imports IngresosPagosBL
Imports BitacoraBL
'Imports EmpresasBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class FacturacionCargaBatch
    Inherits System.Web.UI.Page


#Region "Variables"

    Shared vLinea As String = ""
    Shared vImporte As Decimal
    Shared vIva As Decimal
    Shared vTotal As Decimal
    Shared vVencido As Decimal
    Shared vPorVencer As Decimal
    'Shared vRowA As Integer
    Shared vRowT As Integer

    Public vRowIn As Integer = 0

    Public vTitulo As Integer
    Private isConfigured As Boolean = False

    Public lU As New List(Of IUsuario)

    Shared mes, año, mes2, año2 As Integer
    Shared Usuario As String

    Public oCli As New ClientesBL.ClientesBL
    Public oFac As New FacturacionBL.FacturacionBL
    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public oIng As New IngresosBL.IngresosBL
    Public oInP As New IngresosPagosBL.IngresosPagosBL
    Public oBit As New BitacoraBL.BitacoraBL
    Public oEmp As New EmpresasBL.EmpresasBL
    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, mesI, añoI, mesF, añoF As Integer
    Shared FToday As Date = Today()
    Shared Fini As Date
    Shared Ffin As Date

    Shared Lineas As String
    Shared v_linea_actual As Integer

    Shared id_ls_1, id_ls_2, id_ls_3, id_ls_4, id_ls_5, id_ls_6, id_ls_7, id_ls_8, id_ls_9, id_ls_10 As Integer
    Shared id_ls_11, id_ls_12, id_ls_13, id_ls_14, id_ls_15, id_ls_16, id_ls_17, id_ls_18, id_ls_19, id_ls_20 As Integer
    Shared id_ls_21, id_ls_22, id_ls_23, id_ls_24, id_ls_25, id_ls_26, id_ls_27, id_ls_28, id_ls_29, id_ls_30 As Integer

    Shared Fini_f, Ffin_f, Fini_p, Ffin_p As String

#End Region

    Public Sub IniciaVariables()

        If id_rol > 2 Then
            RadGridLineas.Visible = False
            Lineas = "AND Ingresos.id_linea_servicio = " & id_linea_servicio
        Else
            RadGridLineas.Visible = True
        End If

        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        RadDatePickerInicial.SelectedDate = Today
        RadDatePickerFinal.SelectedDate = Today
        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        Fini_f = Today
        Ffin_f = Today
        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------

        ' Faltan las líneas de servicio

        lblStatus.Text = "Facturas del: " & RadDatePickerInicial.SelectedDate & " al " & RadDatePickerFinal.SelectedDate
        lblMensaje.Text = ""

    End Sub
    Public Sub LineasS()
        If id_rol = 1 Or id_rol = 2 Then

            'Líneas de servicio
            Dim f_rg As Integer = 0
            Dim f_1 As Integer = 0

            'If Lineas Is Nothing Then
            Lineas = "AND ("
            LimpiarLineas()

            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                Dim v_linea_actual As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))
                Dim item_Check As Integer = CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked
                If item_Check <> 0 Then
                    Dim v_or As String = IIf(f_rg > 0, " OR ", "")
                    f_rg = f_rg + 1
                    Lineas = Lineas & v_or & " Ingresos.id_linea_servicio = " & v_linea_actual

                    AsignarLinea(v_linea_actual)

                End If
            Next

            Lineas = Lineas & ")"

        Else
            LimpiarLineas()
            id_ls_1 = id_linea_servicio
        End If

        'Return Lineas
    End Sub
    Public Sub LineasS_2()
        If id_rol = 1 Or id_rol = 2 Then

            'Líneas de servicio
            Dim f_rg As Integer = 0
            Dim f_1 As Integer = 0

            LimpiarLineas()

            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = False
            Next

            Dim strcadena() As String
            strcadena = Split(Lineas, "OR")

            For f_1 = 0 To strcadena.Length - 1
                Dim vLineaAct As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Right(strcadena(f_1), 3))

                For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                    Dim v_linea_actual As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))

                    If v_linea_actual = vLineaAct Then
                        CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = True
                        AsignarLinea(v_linea_actual)
                        Exit For
                    End If
                Next

            Next

        Else
            LimpiarLineas()
            id_ls_1 = id_linea_servicio
        End If

        'Return Lineas
    End Sub
    Public Sub LimpiarLineas()
        id_ls_1 = -1
        id_ls_2 = -1
        id_ls_3 = -1
        id_ls_4 = -1
        id_ls_5 = -1
        id_ls_6 = -1
        id_ls_7 = -1
        id_ls_8 = -1
        id_ls_9 = -1
        id_ls_10 = -1
        id_ls_11 = -1
        id_ls_12 = -1
        id_ls_13 = -1
        id_ls_14 = -1
        id_ls_15 = -1
        id_ls_16 = -1
        id_ls_17 = -1
        id_ls_18 = -1
        id_ls_19 = -1
        id_ls_20 = -1
        id_ls_21 = -1
        id_ls_22 = -1
        id_ls_23 = -1
        id_ls_24 = -1
        id_ls_25 = -1
        id_ls_26 = -1
        id_ls_27 = -1
        id_ls_28 = -1
        id_ls_29 = -1
        id_ls_30 = -1
    End Sub
    Public Sub AsignarLinea(ByVal v_linea_actual As Integer)

        If id_ls_1 = -1 Then
            id_ls_1 = v_linea_actual
        ElseIf id_ls_2 = -1 Then
            id_ls_2 = v_linea_actual
        ElseIf id_ls_3 = -1 Then
            id_ls_3 = v_linea_actual
        ElseIf id_ls_4 = -1 Then
            id_ls_4 = v_linea_actual
        ElseIf id_ls_5 = -1 Then
            id_ls_5 = v_linea_actual
        ElseIf id_ls_6 = -1 Then
            id_ls_6 = v_linea_actual
        ElseIf id_ls_7 = -1 Then
            id_ls_7 = v_linea_actual
        ElseIf id_ls_8 = -1 Then
            id_ls_8 = v_linea_actual
        ElseIf id_ls_9 = -1 Then
            id_ls_9 = v_linea_actual
        ElseIf id_ls_10 = -1 Then
            id_ls_10 = v_linea_actual
        ElseIf id_ls_11 = -1 Then
            id_ls_11 = v_linea_actual
        ElseIf id_ls_12 = -1 Then
            id_ls_12 = v_linea_actual
        ElseIf id_ls_13 = -1 Then
            id_ls_13 = v_linea_actual
        ElseIf id_ls_14 = -1 Then
            id_ls_14 = v_linea_actual
        ElseIf id_ls_15 = -1 Then
            id_ls_15 = v_linea_actual
        ElseIf id_ls_16 = -1 Then
            id_ls_16 = v_linea_actual
        ElseIf id_ls_17 = -1 Then
            id_ls_17 = v_linea_actual
        ElseIf id_ls_18 = -1 Then
            id_ls_18 = v_linea_actual
        ElseIf id_ls_19 = -1 Then
            id_ls_19 = v_linea_actual
        ElseIf id_ls_20 = -1 Then
            id_ls_20 = v_linea_actual
        ElseIf id_ls_21 = -1 Then
            id_ls_21 = v_linea_actual
        ElseIf id_ls_22 = -1 Then
            id_ls_22 = v_linea_actual
        ElseIf id_ls_23 = -1 Then
            id_ls_23 = v_linea_actual
        ElseIf id_ls_24 = -1 Then
            id_ls_24 = v_linea_actual
        ElseIf id_ls_25 = -1 Then
            id_ls_25 = v_linea_actual
        ElseIf id_ls_26 = -1 Then
            id_ls_26 = v_linea_actual
        ElseIf id_ls_27 = -1 Then
            id_ls_27 = v_linea_actual
        ElseIf id_ls_28 = -1 Then
            id_ls_28 = v_linea_actual
        ElseIf id_ls_29 = -1 Then
            id_ls_29 = v_linea_actual
        ElseIf id_ls_30 = -1 Then
            id_ls_30 = v_linea_actual
        End If

    End Sub

    Public Sub ActualizarSqlDataSource1()

        SqlDataSource1.SelectParameters("id_ls_1").DefaultValue = id_ls_1
        SqlDataSource1.SelectParameters("id_ls_2").DefaultValue = id_ls_2
        SqlDataSource1.SelectParameters("id_ls_3").DefaultValue = id_ls_3
        SqlDataSource1.SelectParameters("id_ls_4").DefaultValue = id_ls_4
        SqlDataSource1.SelectParameters("id_ls_5").DefaultValue = id_ls_5
        SqlDataSource1.SelectParameters("id_ls_6").DefaultValue = id_ls_6
        SqlDataSource1.SelectParameters("id_ls_7").DefaultValue = id_ls_7
        SqlDataSource1.SelectParameters("id_ls_8").DefaultValue = id_ls_8
        SqlDataSource1.SelectParameters("id_ls_9").DefaultValue = id_ls_9
        SqlDataSource1.SelectParameters("id_ls_10").DefaultValue = id_ls_10
        SqlDataSource1.SelectParameters("id_ls_11").DefaultValue = id_ls_11
        SqlDataSource1.SelectParameters("id_ls_12").DefaultValue = id_ls_12
        SqlDataSource1.SelectParameters("id_ls_13").DefaultValue = id_ls_13
        SqlDataSource1.SelectParameters("id_ls_14").DefaultValue = id_ls_14
        SqlDataSource1.SelectParameters("id_ls_15").DefaultValue = id_ls_15
        SqlDataSource1.SelectParameters("id_ls_16").DefaultValue = id_ls_16
        SqlDataSource1.SelectParameters("id_ls_17").DefaultValue = id_ls_17
        SqlDataSource1.SelectParameters("id_ls_18").DefaultValue = id_ls_18
        SqlDataSource1.SelectParameters("id_ls_19").DefaultValue = id_ls_19
        SqlDataSource1.SelectParameters("id_ls_20").DefaultValue = id_ls_20
        SqlDataSource1.SelectParameters("id_ls_21").DefaultValue = id_ls_21
        SqlDataSource1.SelectParameters("id_ls_22").DefaultValue = id_ls_22
        SqlDataSource1.SelectParameters("id_ls_23").DefaultValue = id_ls_23
        SqlDataSource1.SelectParameters("id_ls_24").DefaultValue = id_ls_24
        SqlDataSource1.SelectParameters("id_ls_25").DefaultValue = id_ls_25
        SqlDataSource1.SelectParameters("id_ls_26").DefaultValue = id_ls_26
        SqlDataSource1.SelectParameters("id_ls_27").DefaultValue = id_ls_27
        SqlDataSource1.SelectParameters("id_ls_28").DefaultValue = id_ls_28
        SqlDataSource1.SelectParameters("id_ls_29").DefaultValue = id_ls_29
        SqlDataSource1.SelectParameters("id_ls_30").DefaultValue = id_ls_30

        SqlDataSource1.SelectParameters("Fini_f").DefaultValue = Fini_f
        SqlDataSource1.SelectParameters("Ffin_f").DefaultValue = Ffin_f

        'SqlDataSource1.SelectParameters("Folio").DefaultValue = vFolio

        SqlDataSource1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            vLinea = ""
            vImporte = 0
            vIva = 0
            vTotal = 0
            vVencido = 0
            vPorVencer = 0
            'vRowA = 0
            vRowT = 0

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                'Usuario = Session("nombres") & " " & Session("apellido_paterno") & " " & Session("apellido_materno")
                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                IniciaVariables()

                v_DataTable = New DataTable
                v_DataTable = oLiS.ExtraerLineasSBL(v_DataTable)

                RadGridLineas.DataSource = v_DataTable
                RadGridLineas.DataBind()

                If Not Session("Lineas") Is Nothing Then
                    Lineas = Session("Lineas")
                    LineasS_2()
                Else
                    Session("Lineas") = Lineas
                    LineasS()
                End If

                ActualizarSqlDataSource1()
                'vRowT = RadGrid1.Items.Count + 6

            Else
                Response.Redirect("~/Login.aspx")
            End If

        End If
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Select Case e.Item.Text
            Case "Cancelar"
                Response.Redirect("~/Facturacion.aspx")
        End Select
    End Sub
    Protected Sub RadToolBarReportes_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        Select Case e.Item.Text
            Case "Generar Interface"
                If CBFolio.Checked = True Then
                    CargaBatchFolio()
                Else
                    CargaBatch()
                End If
            Case "Generar Reporte"
                GenerarReporte()
        End Select
    End Sub
    Protected Sub RadToolBarMostrar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMostrar.ButtonClick

        lblMensaje.Text = ""

        ' Validar mes inicial con mes final
        Fini = RadDatePickerInicial.SelectedDate
        Ffin = RadDatePickerFinal.SelectedDate

        If Fini > Ffin Then
            lblMensaje.Text = "La Fecha Inicial no puede ser mayor a la Fecha Final"
            Exit Sub
        End If

        LineasS()
        If Lineas = "" Or Lineas = "AND ()" Then
            lblMensaje.Text = "Favor de seleccionar por lo menos una Línea de Servicio"
            Exit Sub
        End If

        Session("mesI") = Month(RadDatePickerInicial.SelectedDate)
        Session("añoI") = Year(RadDatePickerInicial.SelectedDate)
        Session("MesF") = Month(RadDatePickerFinal.SelectedDate)
        Session("AñoF") = Year(RadDatePickerFinal.SelectedDate)

        Session("Lineas") = Lineas

        Fini_f = RadDatePickerInicial.SelectedDate
        Ffin_f = RadDatePickerFinal.SelectedDate

        vLinea = ""

        ActualizarSqlDataSource1()
        lblStatus.Text = "Facturas del: " & RadDatePickerInicial.SelectedDate & " al " & RadDatePickerFinal.SelectedDate

    End Sub
    Protected Sub RadToolBarMostrarFolio_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMostrarFolio.ButtonClick

        'Dim scriptString As String = ""

        'lblMensaje.Text = ""

        'If RadNumericTextBoxFolio.Text = "" Then
        '    scriptString = "alert('Favor de capturar el folio de facturación.');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        '    Exit Sub
        'End If

        'vFolio = RadNumericTextBoxFolio.Text

        '' Validar que el Folio exista en Cuenza
        'Dim oFac As New FacturacionBL.FacturacionBL
        'Dim v_DataTable_Folio As New DataTable
        'v_DataTable_Folio = oFac.ExtraerFolioFacturaBL(v_DataTable_Folio, vFolio)

        'If v_DataTable_Folio.Rows(0).Item(0) = 0 Then
        '    scriptString = "alert('El folio capturado no existe en Cuenza.');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        '    Exit Sub
        'End If

        'id_ls_1 = 0
        'id_ls_2 = 0
        'id_ls_3 = 0
        'id_ls_4 = 0
        'id_ls_5 = 0
        'id_ls_6 = 0
        'id_ls_7 = 0
        'id_ls_8 = 0
        'id_ls_9 = 0
        'id_ls_10 = 0

        'id_ls_11 = 0
        'id_ls_12 = 0
        'id_ls_13 = 0
        'id_ls_14 = 0
        'id_ls_15 = 0
        'id_ls_16 = 0
        'id_ls_17 = 0
        'id_ls_18 = 0
        'id_ls_19 = 0
        'id_ls_20 = 0

        'id_ls_21 = 0
        'id_ls_22 = 0
        'id_ls_23 = 0
        'id_ls_24 = 0
        'id_ls_25 = 0
        'id_ls_26 = 0
        'id_ls_27 = 0
        'id_ls_28 = 0
        'id_ls_29 = 0
        'id_ls_30 = 0

        'Fini = "01/01/1900"
        'Ffin = "01/01/1900"

        'ActualizarSqlDataSource1()
        'lblStatus.Text = "Facturas del: " & RadDatePickerInicial.SelectedDate & " al " & RadDatePickerFinal.SelectedDate

    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item_sel As GridDataItem = CType(CType(sender, CheckBox).Parent.Parent, GridItem)
        v_linea_actual = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(item_sel("linea_servicio").Text, 2))

        If v_linea_actual = 99 Then
            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = CType(sender, CheckBox).Checked
            Next
        Else
            If CType(sender, CheckBox).Checked = False Then
                For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                    Dim v_linea_bus As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))
                    If v_linea_bus = 99 Then
                        CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = False ' CType(sender, CheckBox).Checked
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub CargaBatch()
        Dim scriptString As String = ""

        If RadGrid1.Items.Count = 0 Then
            scriptString = "alert('No existen facturas en pantalla para generar cargar batch.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Try

            lblMensaje.Text = ""

            ' Validar mes inicial con mes final
            Fini = RadDatePickerInicial.SelectedDate
            Ffin = RadDatePickerFinal.SelectedDate

            If Fini > Ffin Then
                lblMensaje.Text = "La Fecha Inicial no puede ser mayor a la Fecha Final"
                Exit Sub
            End If

            LineasS()
            If Lineas = "" Or Lineas = "AND ()" Then
                lblMensaje.Text = "Favor de seleccionar por lo menos una Línea de Servicio"
                Exit Sub
            End If

            Lineas = Replace(Lineas, "Ingresos.", "ING.")

            Session("mesI") = Month(RadDatePickerInicial.SelectedDate)
            Session("añoI") = Year(RadDatePickerInicial.SelectedDate)
            Session("MesF") = Month(RadDatePickerFinal.SelectedDate)
            Session("AñoF") = Year(RadDatePickerFinal.SelectedDate)

            Session("Lineas") = Lineas

            Fini_f = RadDatePickerInicial.SelectedDate
            Ffin_f = RadDatePickerFinal.SelectedDate


            Dim strMap As String = Server.MapPath("~") & "Ficheros"
            Dim FileName As String = strMap + "\" + "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"
            Dim FileName2 As String = "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

            Dim oFac As New FacturacionBL.FacturacionBL
            oFac.GenerarCargaBatchBL(Fini_f, Ffin_f, Lineas, FileName)
            'Status1, Status2, Status3, Status4, Status5, Status6, Status7, Status8, Status9, TipoFactura1, TipoFactura2, TipoFactura3, TipoFactura4,

            Response.Clear()
            Response.ClearContent()
            Response.ClearHeaders()
            Response.Buffer = True
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName2)
            'Response.OutputStream.Write(FileName.file, 0, FileName.file.length)
            Response.TransmitFile(FileName)
            Response.Flush()
            Response.Close()
            'Response.End()
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

        Catch ex As Exception
            scriptString = "alert('Error al intentar generar la interface. \n\n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub
    Public Sub CargaBatchFolio()
        Dim scriptString As String = ""

        'If RadGrid1.Items.Count = 0 Then
        '    scriptString = "alert('No existen facturas en pantalla para generar cargar batch.');"
        '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        '    Exit Sub
        'End If

        Dim vFolio As String = RadNumericTextBoxFolio.Text

        If vFolio = "" Or vFolio = "0" Then
            scriptString = "alert('Favor de capturar el folio de facturación.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Try

            lblMensaje.Text = ""


            ' Validar que el Folio exista en Cuenza
            Dim oFac As New FacturacionBL.FacturacionBL
            Dim v_DataTable_Folio As New DataTable
            v_DataTable_Folio = oFac.ExtraerFolioFacturaBL(v_DataTable_Folio, vFolio)

            If v_DataTable_Folio.Rows.Count = 0 Then
                scriptString = "alert('El folio capturado no existe en Cuenza.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If


            If v_DataTable_Folio.Rows(0).Item("ss") = 0 Then
                scriptString = "alert('El folio capturado está cancelado en Cuenza.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            '1	No Facturada
            '2	Facturada
            '3	Pagada
            '4	Cancelada

            If v_DataTable_Folio.Rows(0).Item("id_tipo_factura") <> 2 And v_DataTable_Folio.Rows(0).Item("id_tipo_factura") <> 3 Then
                Dim vTipoFac As String = Replace(Replace(v_DataTable_Folio.Rows(0).Item("id_tipo_factura"), "1", "No Facturada"), "4", "Cancelada")
                scriptString = "alert('El folio capturado tiene como tipo de factura '" & vTipoFac & "' en Cuenza.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If


            Dim strMap As String = Server.MapPath("~") & "Ficheros"
            Dim FileName As String = strMap + "\" + "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"
            Dim FileName2 As String = "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

            oFac.GenerarCargaBatchFolioBL(vFolio, FileName)

            Response.Clear()
            Response.ClearContent()
            Response.ClearHeaders()
            Response.Buffer = True
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName2)
            'Response.OutputStream.Write(FileName.file, 0, FileName.file.length)
            Response.TransmitFile(FileName)
            Response.Flush()
            Response.Close()
            'Response.End()
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

        Catch ex As Exception
            scriptString = "alert('Error al intentar generar la interface. \n\n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

    Public Sub GenerarReporte()
        Dim scriptString As String = ""

        lblMensaje.Text = ""

        If RadGrid1.Items.Count > 0 Then

            Try
                Dim accessSQL As New DataAccess.SQL
                Dim selSql As String = ""

                selSql = "SET DATEFORMAT dmy;" _
                     & " BEGIN TRAN " _
                     & "     " _
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Facturación Carga Batch', 0, " & id_linea_servicio & ")" _
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

                RadGrid1.ExportSettings.ExportOnlyData = True
                RadGrid1.ExportSettings.IgnorePaging = True
                RadGrid1.ExportSettings.FileName = "Facturacion Carga Batch " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGrid1.ExportSettings.OpenInNewWindow = True

                RadGrid1.MasterTableView.GetColumn("id_pago_pk").Visible = False
                RadGrid1.MasterTableView.GetColumn("id_ingreso_pk").Visible = False

                RadGrid1.MasterTableView.ExportToExcel()

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
    Protected Sub RadGrid1_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs) Handles RadGrid1.ExcelMLExportRowCreated

        ' ¿Quién Factura?         nombre_empresa         myDetailStyle
        ' Línea de servicio       nombre_linea           myDetailStyle
        ' Clave                   id_ingreso             myDetailStyleNumeric
        ' Autorizado              autorizado             myDetailStyle
        ' Estatus                 status                 myDetailStyle
        ' Folio de factura        folio_factura          myDetailStyleNumeric
        ' Fecha de facturación    fecha_fact             myDetailStyle
        ' Fecha de pago           fecha_pago             myDetailStyle
        ' Tipo de factura         tipo_factura           myDetailStyle
        ' Tipo de Moneda          TipoMoneda             myDetailStyle
        ' Importe                 importe                myDetailStyleDecimal
        ' IVA                     iva                    myDetailStyleDecimal
        ' Total                   total                  myDetailStyleDecimal
        ' Vencido                 vencido                myDetailStyleDecimal
        ' Por vencer              por_vencer             myDetailStyleDecimal
        ' Concepto                concepto               myDetailStyle
        ' Gerente                 Gerente                myDetailStyle
        ' Cliente                 nombre_cliente         myDetailStyle
        ' Servicio                nombre_servicio        myDetailStyle
        ' Fecha deposito 1        fecha_deposito1        myDetailStyle
        ' Pago 1                  pago_1                 myDetailStyleDecimal
        ' Fecha deposito 2        fecha_deposito2        myDetailStyle
        ' Pago 2                  pago_2                 myDetailStyleDecimal
        ' Fecha deposito 3        fecha_deposito3        myDetailStyle
        ' Pago 3                  pago_3                 myDetailStyleDecimal
        ' Fecha deposito 4        fecha_deposito4        myDetailStyle
        ' Pago 4                  pago_4                 myDetailStyleDecimal
        ' Fecha deposito 5        fecha_deposito5        myDetailStyle
        ' Pago 5                  pago_5                 myDetailStyleDecimal
        ' Motivo de cancelación   motivo_cancelacion     myDetailStyle
        ' Fecha de cancelación    fecha_cancelacion      myDetailStyle

        If e.RowType = GridExportExcelMLRowType.DataRow Then

            If vRowT = 0 Then
                vRowT = RadGrid1.Items.Count + 6
            End If

            Dim vRowA As Integer = e.Worksheet.Table.Rows.Count

            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("nombre_empresa")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_empresa").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_empresa")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_empresa").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_linea")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_linea").StyleValue = "myDetailStyle"

                Dim vLineaAct As String = cell2.Data.DataItem

                If (vLinea <> "" And vLinea <> vLineaAct) Or vRowT = vRowA Then

                    Dim row As New Telerik.Web.UI.GridExcelBuilder.RowElement()

                    For i As Integer = 1 To 9
                        Dim cell_L As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_L.Data.DataItem = ""
                        cell_L.StyleValue = "MyStyleLinea1"
                        row.Cells.Add(cell_L)
                    Next

                    Dim cell_L1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_L1.Data.DataItem = vLinea
                    cell_L1.StyleValue = "MyStyleLinea1"
                    row.Cells.Add(cell_L1)

                    If vRowT = vRowA Then
                        Dim cellrowlast As CellElement = e.Row.Cells.GetCellByName("importe")
                        If Not cellrowlast Is Nothing Then
                            vImporte = vImporte + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("iva")
                        If Not cellrowlast Is Nothing Then
                            vIva = vIva + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("total")
                        If Not cellrowlast Is Nothing Then
                            vTotal = vTotal + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("vencido")
                        If Not cellrowlast Is Nothing Then
                            vVencido = vVencido + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("por_vencer")
                        If Not cellrowlast Is Nothing Then
                            vPorVencer = vPorVencer + cellrowlast.Data.DataItem
                        End If
                    End If

                    Dim cell_Importe As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Importe.Data.DataItem = vImporte
                    cell_Importe.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Importe)

                    Dim cell_Iva As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Iva.Data.DataItem = vIva
                    cell_Iva.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Iva)

                    Dim cell_Total As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Total.Data.DataItem = vTotal
                    cell_Total.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Total)

                    Dim cell_Vencido As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Vencido.Data.DataItem = vVencido
                    cell_Vencido.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Vencido)

                    Dim cell_PorVencer As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_PorVencer.Data.DataItem = vPorVencer
                    cell_PorVencer.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_PorVencer)

                    For i As Integer = 1 To 15
                        Dim cell_L As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_L.Data.DataItem = ""
                        cell_L.StyleValue = "MyStyleLinea1"
                        row.Cells.Add(cell_L)
                    Next

                    Dim cell_L2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_L2.Data.DataItem = ""
                    cell_L2.StyleValue = "MyStyleLinea3"
                    row.Cells.Add(cell_L2)

                    If vRowT = vRowA Then
                        e.Worksheet.Table.Rows.Insert(vRowT, row)
                    Else
                        e.Worksheet.Table.Rows.Insert(vRowA - 1, row)
                    End If

                    vImporte = 0
                    vIva = 0
                    vTotal = 0
                    vVencido = 0
                    vPorVencer = 0

                    vRowT = vRowT + 1
                End If

                vLinea = cell2.Data.DataItem

            End If
            cell2 = e.Row.Cells.GetCellByName("id_ingreso")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("id_ingreso").StyleValue = "myDetailStyleNumeric"
            End If
            cell2 = e.Row.Cells.GetCellByName("autorizado")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("autorizado").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("status")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("status").StyleValue = "myDetailStyle"
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
            cell2 = e.Row.Cells.GetCellByName("tipo_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("TipoMoneda")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("TipoMoneda").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe").StyleValue = "myDetailStyleDecimal"
                vImporte = vImporte + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("iva")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("iva").StyleValue = "myDetailStyleDecimal"
                vIva = vIva + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("total")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total").StyleValue = "myDetailStyleDecimal"
                vTotal = vTotal + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("vencido")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("vencido").StyleValue = "myDetailStyleDecimal"
                vVencido = vVencido + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("por_vencer")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("por_vencer").StyleValue = "myDetailStyleDecimal"
                vPorVencer = vPorVencer + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("concepto").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("Gerente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("Gerente").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_cliente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_cliente").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_servicio")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_servicio").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito1").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_1").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito2").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_2").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito3").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_3").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito4").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_4").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito5").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_5").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("motivo_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("motivo_cancelacion").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_cancelacion").StyleValue = "myDetailStyle"
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

                Dim row1 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell1.Data.DataItem = "Fecha: " & FormatDateTime(Today, DateFormat.LongDate)
                cell1.StyleValue = "MyTitle2"
                row1.Cells.Add(cell1)
                e.Worksheet.Table.Rows.Insert(0, row1)

                Dim row2 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell2.Data.DataItem = lblStatus.Text
                cell2.StyleValue = "MyTitle2"
                row2.Cells.Add(cell2)
                e.Worksheet.Table.Rows.Insert(0, row2)

                Dim row3 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell3 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell3.Data.DataItem = "Reporte de Facturación Carga Batch"
                cell3.StyleValue = "MyTitle1"
                row3.Cells.Add(cell3)

                For i As Integer = 1 To 11
                    Dim cell_v As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_v.Data.DataItem = ""
                    row3.Cells.Add(cell_v)
                Next

                'Dim cell_tc As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                'cell_tc.Data.DataItem = "T.C."
                'cell_tc.StyleValue = "MyStyleTC1"
                'row3.Cells.Add(cell_tc)

                'Dim cell_tc2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                'cell_tc2.Data.DataItem = TBTipoCambio.Text
                'cell_tc2.StyleValue = "MyStyleTC2"
                'row3.Cells.Add(cell_tc2)

                e.Worksheet.Table.Rows.Insert(0, row3)

                Dim row4 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell4 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell4.Data.DataItem = "Cuenza. Control de Cuentas y Cobranza"
                cell4.StyleValue = "MyTitle"
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
                    ' 0 1 4 9
                    ' 15 16 17 18 29
                    If e.Worksheet.Table.Columns.IndexOf(column) = 0 Or e.Worksheet.Table.Columns.IndexOf(column) = 1 Or e.Worksheet.Table.Columns.IndexOf(column) = 4 Or e.Worksheet.Table.Columns.IndexOf(column) = 9 Then
                        column.Attributes("ss:Width") = "161"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 15 Or e.Worksheet.Table.Columns.IndexOf(column) = 16 Or e.Worksheet.Table.Columns.IndexOf(column) = 17 Or e.Worksheet.Table.Columns.IndexOf(column) = 18 Or e.Worksheet.Table.Columns.IndexOf(column) = 29 Then
                        column.Attributes("ss:Width") = "266"
                    Else
                        column.Attributes("ss:Width") = "109"
                    End If
                Next

                Dim vRow As RowElement = e.Worksheet.Table.Rows(5)
                vRow.Attributes("ss:Height") = 20

                e.Worksheet.Name = "Facturación"

                isConfigured = True
            End If
        End If

    End Sub
    Protected Sub RadGrid1_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As GridExportExcelMLStyleCreatedArgs) Handles RadGrid1.ExcelMLExportStylesCreated

        Dim borderTC1 As BorderStyles = New BorderStyles()
        borderTC1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC1.Weight = 2
        borderTC1.LineStyle = LineStyle.Continuous
        borderTC1.PositionType = PositionType.Left

        Dim borderTC2 As BorderStyles = New BorderStyles()
        borderTC2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC2.Weight = 2
        borderTC2.LineStyle = LineStyle.Continuous
        borderTC2.PositionType = PositionType.Bottom

        Dim borderTC3 As BorderStyles = New BorderStyles()
        borderTC3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC3.Weight = 2
        borderTC3.LineStyle = LineStyle.Continuous
        borderTC3.PositionType = PositionType.Right

        Dim borderTC4 As BorderStyles = New BorderStyles()
        borderTC4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC4.Weight = 2
        borderTC4.LineStyle = LineStyle.Continuous
        borderTC4.PositionType = PositionType.Top

        Dim MyStyleTC1 As New StyleElement("MyStyleTC1")
        MyStyleTC1.FontStyle.Bold = True
        MyStyleTC1.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTC1.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleTC1.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        MyStyleTC1.Borders.Add(borderTC1)
        MyStyleTC1.Borders.Add(borderTC2)
        MyStyleTC1.Borders.Add(borderTC4)
        e.Styles.Add(MyStyleTC1)

        Dim MyStyleTC2 As New StyleElement("MyStyleTC2")
        MyStyleTC2.FontStyle.Bold = True
        MyStyleTC2.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTC2.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleTC2.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        MyStyleTC2.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        MyStyleTC2.Borders.Add(borderTC2)
        MyStyleTC2.Borders.Add(borderTC3)
        MyStyleTC2.Borders.Add(borderTC4)
        e.Styles.Add(MyStyleTC2)


        Dim borderL1 As BorderStyles = New BorderStyles()
        borderL1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderL1.Weight = 2
        borderL1.LineStyle = LineStyle.Continuous
        borderL1.PositionType = PositionType.Bottom

        Dim borderL2 As BorderStyles = New BorderStyles()
        borderL2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderL2.Weight = 2
        borderL2.LineStyle = LineStyle.Continuous
        borderL2.PositionType = PositionType.Right

        Dim MyStyleLinea1 As New StyleElement("MyStyleLinea1")
        MyStyleLinea1.FontStyle.Bold = True
        MyStyleLinea1.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea1.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea1.Borders.Add(borderL1)
        e.Styles.Add(MyStyleLinea1)

        Dim MyStyleLinea2 As New StyleElement("MyStyleLinea2")
        MyStyleLinea2.FontStyle.Bold = True
        MyStyleLinea2.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea2.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea2.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        MyStyleLinea2.Borders.Add(borderL1)
        e.Styles.Add(MyStyleLinea2)

        Dim MyStyleLinea3 As New StyleElement("MyStyleLinea3")
        MyStyleLinea3.FontStyle.Bold = True
        MyStyleLinea3.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea3.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea3.Borders.Add(borderL1)
        MyStyleLinea3.Borders.Add(borderL2)
        e.Styles.Add(MyStyleLinea3)


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


        '--------------------------------------------------
        ' myDetailStyle
        '--------------------------------------------------
        Dim myStyle As New StyleElement("myDetailStyle")
        myStyle.Borders.Add(border1)
        myStyle.Borders.Add(border2)
        myStyle.Borders.Add(border3)
        myStyle.Borders.Add(border4)
        e.Styles.Add(myStyle)


        '--------------------------------------------------
        ' myDetailStyleNumeric
        '--------------------------------------------------
        Dim myStyleNum As New StyleElement("myDetailStyleNumeric")
        myStyleNum.Borders.Add(border1)
        myStyleNum.Borders.Add(border2)
        myStyleNum.Borders.Add(border3)
        myStyleNum.Borders.Add(border4)
        myStyleNum.NumberFormat.Attributes("ss:Format") = "###0" ' "MM/dd"
        e.Styles.Add(myStyleNum)


        '--------------------------------------------------
        ' myDetailStyleDecimal
        '--------------------------------------------------
        Dim myStyleDec As New StyleElement("myDetailStyleDecimal")
        myStyleDec.Borders.Add(border1)
        myStyleDec.Borders.Add(border2)
        myStyleDec.Borders.Add(border3)
        myStyleDec.Borders.Add(border4)
        myStyleDec.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDec)


        ''--------------------------------------------------
        '' myDetailStyleB
        ''--------------------------------------------------
        'Dim myStyleB As New StyleElement("myDetailStyleB")
        'myStyleB.Borders.Add(border1)
        'myStyleB.Borders.Add(border5)
        'myStyleB.Borders.Add(border3)
        'myStyleB.Borders.Add(border4)
        'e.Styles.Add(myStyleB)


        ''--------------------------------------------------
        '' myDetailStyleNumericB
        ''--------------------------------------------------
        'Dim myStyleNumB As New StyleElement("myDetailStyleNumericB")
        'myStyleNumB.Borders.Add(border1)
        'myStyleNumB.Borders.Add(border5)
        'myStyleNumB.Borders.Add(border3)
        'myStyleNumB.Borders.Add(border4)
        'myStyleNumB.NumberFormat.Attributes("ss:Format") = "###0" ' "MM/dd"
        'e.Styles.Add(myStyleNumB)


        ''--------------------------------------------------
        '' myDetailStyleDecimalB
        ''--------------------------------------------------
        'Dim myStyleDecB As New StyleElement("myDetailStyleDecimalB")
        'myStyleDecB.Borders.Add(border1)
        'myStyleDecB.Borders.Add(border5)
        'myStyleDecB.Borders.Add(border3)
        'myStyleDecB.Borders.Add(border4)
        'myStyleDecB.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        'e.Styles.Add(myStyleDecB)

        For Each style As StyleElement In e.Styles

            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.FontStyle.Color = Drawing.Color.White
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))

                '--------------------------------------------------
                ' Bordes
                '--------------------------------------------------
                Dim borderH1 As BorderStyles = New BorderStyles()
                borderH1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH1.Weight = 2
                borderH1.LineStyle = LineStyle.Continuous
                borderH1.PositionType = PositionType.Top

                Dim borderH2 As BorderStyles = New BorderStyles()
                borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                'borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH2.Weight = 1
                borderH2.LineStyle = LineStyle.Continuous
                borderH2.PositionType = PositionType.Bottom

                Dim borderH3 As BorderStyles = New BorderStyles()
                borderH3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH3.Weight = 2
                borderH3.LineStyle = LineStyle.Continuous
                borderH3.PositionType = PositionType.Left

                Dim borderH4 As BorderStyles = New BorderStyles()
                borderH4.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH4.Weight = 2
                borderH4.LineStyle = LineStyle.Continuous
                borderH4.PositionType = PositionType.Right

                style.Borders.Add(borderH1)
                style.Borders.Add(borderH2)
                style.Borders.Add(borderH3)
                style.Borders.Add(borderH4)

            End If

            If style.Id.Contains("itemStyle") OrElse style.Id = "alternatingItemStyle" Then
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            End If

            'If style.Id.Contains("myDetailStyle") OrElse style.Id = "myDetailStyleNumeric" OrElse style.Id = "myDetailStyleDecimal" Then
            '    'style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    'style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            'End If

        Next

    End Sub


End Class
