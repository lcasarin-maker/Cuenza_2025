
'<>

Imports System.Data
Imports System.Data.SqlClient

Imports Domain
Imports UsuariosBL
'Imports FacturacionBL
Imports ClientesBL
'Imports LineasServicioBL
Imports IngresosBL
'Imports IngresosPagosBL
'Imports BitacoraBL
Imports EmpresasBL
Imports ServiciosBL
Imports TiposMonedaBL
Imports AlertasBL

Imports Telerik.Web.UI

Partial Public Class PronosticoProgramaAgregar
    Inherits System.Web.UI.Page

#Region "Variables"

    Shared item As GridDataItem

    Shared TableName As String = ""

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oCli As New ClientesBL.ClientesBL
    'Public oFac As New FacturacionBL.FacturacionBL
    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public oIng As New IngresosBL.IngresosBL
    'Public oInP As New IngresosPagosBL.IngresosPagosBL
    'Public oBit As New BitacoraBL.BitacoraBL
    Public oEmp As New EmpresasBL.EmpresasBL
    Public oSer As New ServiciosBL.ServiciosBL
    Public oTMo As New TiposMonedaBL.TiposMonedaBL
    Public oAle As New AlertasBL.AlertasBL

    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, id_empresa, id_tipo_moneda As Integer
    Shared id_cliente, id_servicio, id_status, id_status_desc As Integer
    'Shared NoLineaS As String
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            'Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
            'Page.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
            'Page.Response.Cache.SetAllowResponseInBrowserHistory(False)
            'Page.Response.Cache.SetNoStore()

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

                AsignarClave()

                SessionLineasS()
                SessionQuienF()
                SessionCliente()
                SessionTipoMoneda()
                SessionServicio()

                id_status = 0
                Status()
                StatusDesc()

                LimpiarGrid()

            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Public Sub AsignarClave()

        If id_linea_servicio = 0 Or id_linea_servicio = 99 Then
            RadNumericTextBoxClave.Text = ""
        Else
            Dim id_ingreso As Integer = 0
            id_ingreso = oIng.ExtraerClaveLineasBL(id_ingreso, id_linea_servicio)
            RadNumericTextBoxClave.Text = id_ingreso
        End If

    End Sub

    Public Sub LimpiarGrid()

        RadNumericTextBoxNoPagos1.Value = 1
        'RadNumericTextBoxImportePagosT.Value = 0

        ' Validar si existe la tabla y eliminarla
        TableName = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""
        Dim dt As New DataTable

        TableName = "IngresosPagos_" & id_Usuario & "_" & Today.Day & "_" & Today.Month & "_" & Today.Year & "_" & Now.Hour & "_" & Now.Minute & "_" & Now.Second
        accessSQL.valida_tabla(TableName, "Drop Table " & TableName, "")
        accessSQL.Close()

        selSql = "CREATE TABLE " & TableName & " ([no_pago] [int] NOT NULL, [folio_factura] [int] NOT NULL, [fecha_fact] [date] NOT NULL, [fecha_pago] [date] NOT NULL, [importe] [decimal](18, 2) NOT NULL, [concepto] [nvarchar](max) NOT NULL, [importe_letra] [nvarchar](max) NULL) "
        accessSQL.ExecuteNonQueryD(selSql)
        accessSQL.Close()

        selSql = "SELECT * FROM " & TableName & " ORDER BY no_pago "
        dt = accessSQL.DataTableFill(selSql)
        accessSQL.Close()

        RadGridPagos.DataSource = Nothing
        RadGridPagos.DataSource = dt

    End Sub

    Public Sub SessionLineasS()
        
        If id_rol = 1 Then
            v_DataTable = New DataTable
            v_DataTable = oLiS.ExtraerLineasS2BL(v_DataTable)
        Else
            v_DataTable = New DataTable
            v_DataTable = oLiS.ExtraerLineasSIdBL(v_DataTable, id_linea_servicio)
        End If

        RadComboBoxLineaServicio.DataSource = v_DataTable
        RadComboBoxLineaServicio.DataTextField = "nombre_linea"
        RadComboBoxLineaServicio.DataValueField = "id_linea_servicio"
        RadComboBoxLineaServicio.DataBind()

    End Sub
    Protected Sub RadComboBoxLineaServicio_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxLineaServicio.SelectedIndexChanged
        id_linea_servicio = e.Value
        SessionServicio()
        AsignarClave()
    End Sub

    Public Sub SessionQuienF()
        v_DataTable = New DataTable
        v_DataTable = oEmp.ExtraerEmpresas2BL(v_DataTable)

        RadComboBoxQuienFactura.DataSource = v_DataTable
        RadComboBoxQuienFactura.DataTextField = "nombre_empresa"
        RadComboBoxQuienFactura.DataValueField = "id_empresa"
        RadComboBoxQuienFactura.DataBind()
    End Sub
    Protected Sub RadComboBoxQuienFactura_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxQuienFactura.SelectedIndexChanged
        id_empresa = e.Value
        'SessionQuienF()
    End Sub

    Public Sub SessionCliente()
        v_DataTable = New DataTable
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
    Protected Sub OnSelectedIndexChangedHandlerCliente(ByVal sender As Object, ByVal e As RadComboBoxSelectedIndexChangedEventArgs)
        Session("id_cliente") = e.Value

        Dim GridRow As GridEditableItem = TryCast(TryCast(sender, RadComboBox).NamingContainer, GridEditableItem)
        Dim rcb As RadComboBox = TryCast(GridRow("id_cliente").FindControl("RadComboBoxCliente"), RadComboBox)

        If e.Value = "" Then

            rcb.Text = ""

            Dim rcb2 As RadComboBox = TryCast(GridRow("nombre_cliente").FindControl("RadComboBoxCliente"), RadComboBox)
            rcb2.Text = ""

            'GridRow.Item("nombre_cliente").Text = ""

        Else

            Dim sql As String = "SELECT id_cliente, REPLACE(RIGHT('0' + CAST(id_cliente AS VARCHAR), 2) + ' ' + nombre_cliente,'00 Seleccione','Seleccione') AS nombre_cliente FROM Clientes WHERE ss = 1 AND id_cliente > 1 AND Clientes.nombre_cliente LIKE '%' + @cliente + '%'"
            Dim adapter As New SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings("CPAdminConnectionString").ConnectionString)
            adapter.SelectCommand.Parameters.AddWithValue("@id_cliente", e.Value)

            Dim dt4 As New DataTable()
            adapter.Fill(dt4)

            rcb.Text = e.Value
            'GridRow.Item("nombre_tipo_rol").Text = dt4.Rows(0).Item(0)

        End If

    End Sub

    Public Sub SessionServicio()
        v_DataTable = New DataTable
        v_DataTable = oSer.ExtraerServicios2BL(v_DataTable, id_linea_servicio)
        
        RadComboBoxServicio.DataSource = v_DataTable
        RadComboBoxServicio.DataTextField = "nombre_servicio"
        RadComboBoxServicio.DataValueField = "id_servicio"
        RadComboBoxServicio.DataBind()
    End Sub
    Protected Sub RadComboBoxServicio_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxServicio.SelectedIndexChanged
        id_servicio = e.Value
        'SessionServicio()
    End Sub

    Public Sub SessionTipoMoneda()
        v_DataTable = New DataTable
        v_DataTable = oTMo.ExtraerTiposMoneda2BL(v_DataTable)

        RadComboBoxTipoMoneda.DataSource = v_DataTable
        RadComboBoxTipoMoneda.DataTextField = "descripcion"
        RadComboBoxTipoMoneda.DataValueField = "id_tipo_moneda"
        RadComboBoxTipoMoneda.DataBind()

        id_tipo_moneda = v_DataTable.Rows(0).Item(0)

    End Sub
    Protected Sub RadComboBoxTipoMoneda_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxTipoMoneda.SelectedIndexChanged
        id_tipo_moneda = e.Value ' RadComboBoxTipoMoneda.SelectedValue - 1
    End Sub

    Public Sub Status()
        v_DataTable = New DataTable
        v_DataTable = oIng.ExtraerStatusBL(v_DataTable)
        
        RadComboBoxStatus.DataSource = v_DataTable
        RadComboBoxStatus.DataTextField = "descripcion"
        RadComboBoxStatus.DataValueField = "id_status"
        RadComboBoxStatus.DataBind()

        id_status = v_DataTable.Rows(0).Item(0)
        StatusDesc()
    End Sub
    Protected Sub RadComboBoxStatus_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxStatus.SelectedIndexChanged
        id_status = e.Value ' RadComboBoxStatus.SelectedValue - 1
        StatusDesc()
    End Sub

    Public Sub StatusDesc()
        v_DataTable = New DataTable
        v_DataTable = oIng.ExtraerStatusDescBL(v_DataTable, id_status)

        RadComboBoxStatusDesc.DataSource = v_DataTable
        RadComboBoxStatusDesc.DataTextField = "descripcion"
        RadComboBoxStatusDesc.DataValueField = "id_status_desc"
        RadComboBoxStatusDesc.DataBind()
    End Sub
    Protected Sub RadComboBoxStatusDesc_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxStatusDesc.SelectedIndexChanged
        id_status_desc = e.Value
        'StatusDesc()
    End Sub

    Protected Sub RadNumericTextBoxNoPagos2_TextChanged(sender As Object, e As EventArgs) Handles RadNumericTextBoxNoPagos2.TextChanged

        Dim scriptString As String = ""

        If RadNumericTextBoxNoPagos2.Value < RadGridPagos.Items.Count Then
            scriptString = "alert('El total de pagos no puede ser menor a los pagos capturados. \n\n Favor de verificar el error y volver a intentarlo.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        RadNumericTextBoxFolio.Value = RadGridPagos.Items.Count + 1

    End Sub

    Protected Sub RadDatePickerFechaFacturacion_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFechaFacturacion.SelectedDateChanged

        Dim scriptString As String = ""

        If RadDatePickerFechaFacturacion.SelectedDate < Today Then
            scriptString = "alert('La fecha de facturación no puede ser menor a la fecha actual. \n\n Favor de verificar el error y volver a intentarlo.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            RadDatePickerFechaFacturacion.Clear()
            'RadDatePickerFechaFacturacion.Focus()
        End If

        If Not RadDatePickerFechaPago.SelectedDate Is Nothing Then
            If RadDatePickerFechaFacturacion.SelectedDate > RadDatePickerFechaPago.SelectedDate Then
                scriptString = "alert('La fecha de facturación no puede ser mayor a la fecha de pago. \n\n Favor de verificar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadDatePickerFechaFacturacion.Clear()
                'RadDatePickerFechaFacturacion.Focus()
            End If
        End If

    End Sub
    Protected Sub RadDatePickerFechaPago_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFechaPago.SelectedDateChanged

        Dim scriptString As String = ""

        If RadDatePickerFechaPago.SelectedDate < Today Then
            scriptString = "alert('La fecha de pago no puede ser menor a la fecha actual. \n\n Favor de verificar el error y volver a intentarlo.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            RadDatePickerFechaPago.Clear()
            'RadDatePickerFechaPago.Focus()
        End If

        If Not RadDatePickerFechaFacturacion.SelectedDate Is Nothing Then
            If RadDatePickerFechaFacturacion.SelectedDate > RadDatePickerFechaPago.SelectedDate Then
                scriptString = "alert('La fecha de pago no puede ser menor a la fecha de facturación. \n\n Favor de verificar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadDatePickerFechaPago.Clear()
                'RadDatePickerFechaPago.Focus()
            End If
        End If

    End Sub

    Protected Sub RadToolBarActualizarPagos_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarAgregarPagos.ButtonClick
        Select Case e.Item.Text
            Case "Agregar"
                AgregarPago()
        End Select
    End Sub
    Protected Sub RadToolBarModificarPagos_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarModificarPagos.ButtonClick
        Select Case e.Item.Text
            Case "Modificar"
                ModificarPago()
        End Select
    End Sub
    Public Sub AgregarPago()

        Dim scriptString As String = ""

        Try

            Dim vImporte As Decimal = IIf(RadNumericTextBoxImporte.Value Is Nothing, 0, RadNumericTextBoxImporte.Value)
            Dim vImportePagosT As Decimal = IIf(RadNumericTextBoxImportePagosT.Value Is Nothing, 0, RadNumericTextBoxImportePagosT.Value)
            Dim vImportePago As Decimal = IIf(RadNumericTextBoxImportePago.Value Is Nothing, 0, RadNumericTextBoxImportePago.Value)

            Dim vNoPagos1 As Decimal = IIf(RadNumericTextBoxNoPagos1.Value Is Nothing, 0, RadNumericTextBoxNoPagos1.Value)
            Dim vNoPagos2 As Decimal = IIf(RadNumericTextBoxNoPagos2.Value Is Nothing, 0, RadNumericTextBoxNoPagos2.Value)

            ' Validar si el total de pagos ya fue capturado
            If RadGridPagos.Items.Count > 0 Then
                If vNoPagos2 = RadGridPagos.Items.Count Then
                    scriptString = "alert('El total de pagos ya fue capturado.');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                    Exit Sub
                End If
            End If

            ' Validar que se capturaron los campos obligatorios.
            If vImporte = 0 Then
                scriptString = "alert('Favor de capturar el importe del pronóstico');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxImporte.Focus()
                Exit Sub
            End If
            If vNoPagos2 = 0 Then
                scriptString = "alert('Favor de capturar el no. de pagos');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxNoPagos2.Focus()
                Exit Sub
            End If
            If RadDatePickerFechaFacturacion.SelectedDate Is Nothing Then
                scriptString = "alert('Favor de capturar la fecha de facturación');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadDatePickerFechaFacturacion.Focus()
                Exit Sub
            End If
            If RadDatePickerFechaPago.SelectedDate Is Nothing Then
                scriptString = "alert('Favor de capturar la fecha de pago');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadDatePickerFechaPago.Focus()
                Exit Sub
            End If
            If vImportePago = 0 Then
                scriptString = "alert('Favor de capturar el importe del pago');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxImportePago.Focus()
                Exit Sub
            End If
            If RadTextBoxConcepto.Text = "" Then
                scriptString = "alert('Favor de capturar el concepto');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxConcepto.Focus()
                Exit Sub
            End If

            'Dim v1 As Integer = IIf(RadNumericTextBoxNoPagos2.Value Is Nothing, 1, 0)
            'Dim v2 As Integer = IIf(RadDatePickerFechaFacturacion.SelectedDate Is Nothing, 1, 0)
            'Dim v3 As Integer = IIf(RadDatePickerFechaPago.SelectedDate Is Nothing, 1, 0)
            'Dim v4 As Integer = IIf(RadNumericTextBoxImportePago.Value Is Nothing, 1, 0)
            'Dim v5 As Integer = IIf(RadTextBoxConcepto.Text = "", 1, 0)

            ''RadNumericTextBoxNoPagos2
            ''RadDatePickerFechaFacturacion
            ''RadDatePickerFechaPago
            ''RadNumericTextBoxImportePago
            ''RadTextBoxConcepto

            'If v1 = 1 And v2 = 1 And v3 = 1 And v4 = 1 And v5 = 1 Then
            '    scriptString = "alert('Favor de capturar lo siguiente: \n\n No. de pagos \n Fecha de facturación \n Fecha de pago \n Importe del pago \n Concepto');"
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            '    RadNumericTextBoxNoPagos2.Focus()
            '    Exit Sub
            'End If
            'If v1 = 1 And v2 = 1 And v3 = 1 And v4 = 1 And v5 = 1 Then
            '    scriptString = "alert('Favor de capturar lo siguiente: \n\n No. de pagos \n Fecha de facturación \n Fecha de pago \n Importe del pago \n Concepto');"
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            '    RadNumericTextBoxNoPagos2.Focus()
            '    Exit Sub
            'End If



            ' Validar el importe del pago con el importe total
            If vImportePago > vImporte Then
                scriptString = "alert('El importe del pago no puede ser mayor al importe del pronóstico. \n\n Favor de verificar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar la suma del importe de los pagos con el importe total
            If vImportePago + vImportePagosT > vImporte Then
                scriptString = "alert('El importe de los pagos no puede ser mayor al importe del pronóstico. \n\n Favor de verificar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar el importe del pago si ya es el ultimo a capturar
            If RadGridPagos.Items.Count > 0 Then
                If RadNumericTextBoxNoPagos1.Value = RadGridPagos.Items.Count Then
                    If vImportePago + vImportePagosT < vImporte Then
                        scriptString = "alert('La suma del importe de los pagos no puede ser menor al importe del pronóstico. \n\n Favor de verificar el error y volver a intentarlo.');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                        Exit Sub
                    End If
                End If
            End If


            ' Insertar datos en tabla temporal y en el grid
            Dim accessSQL As New DataAccess.SQL
            Dim selSql As String = ""
            Dim dt As New DataTable

            selSql = "SET DATEFORMAT dmy; INSERT INTO " & TableName & " VALUES ( " & RadNumericTextBoxNoPagos1.Value & ", " & RadNumericTextBoxFolio.Value & ", '" & RadDatePickerFechaFacturacion.SelectedDate & "', '" & RadDatePickerFechaPago.SelectedDate & "', " & vImportePago & ", '" & RadTextBoxConcepto.Text & "', '" & RadNumericTextBoxImportePagoLetra.Text & "')"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            ' Ordernar por fecha de facturación
            selSql = "SET DATEFORMAT dmy; " _
            & "       SELECT no_pago = ROW_NUMBER() OVER (ORDER BY fecha_fact) " _
            & "            , folio_factura = 0 " _
            & "            , fecha_fact, fecha_pago, importe, concepto, importe_letra " _
            & "       INTO " & TableName & "_1 " _
            & "       FROM " & TableName & " " _
            & "       ORDER BY fecha_fact"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            accessSQL.valida_tabla(TableName, "Drop Table " & TableName, "")
            accessSQL.Close()

            selSql = "exec sp_rename '" & TableName & "_1', '" & TableName & "';"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            selSql = "SELECT * FROM " & TableName & " ORDER BY no_pago "
            dt = accessSQL.DataTableFill(selSql)
            accessSQL.Close()

            RadGridPagos.DataSource = Nothing
            RadGridPagos.DataSource = dt
            RadGridPagos.DataBind()

            RadNumericTextBoxImportePagosT.Value = vImportePagosT + vImportePago

            If vNoPagos2 > RadGridPagos.Items.Count Then
                RadNumericTextBoxFolio.Value = RadGridPagos.Items.Count + 1
                RadNumericTextBoxNoPagos1.Value = RadGridPagos.Items.Count + 1
            End If

            RadDatePickerFechaFacturacion.Clear()
            RadDatePickerFechaPago.Clear()
            RadNumericTextBoxImportePago.Value = Nothing
            RadTextBoxConcepto.Text = ""
            RadNumericTextBoxImportePagoLetra.Text = ""

        Catch ex As Exception
            scriptString = "alert('Se ha detectado un error. \n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub
    Public Sub ModificarPago()

        Dim scriptString As String = ""

        Try

            If RadGridPagos.SelectedItems.Count = 0 Then
                scriptString = "alert('Para modificar pagos favor de seleccionar un registro.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            item = TryCast(RadGridPagos.SelectedItems(0), GridDataItem)

            RadNumericTextBoxNoPagos1.Value = item("no_pago").Text
            RadNumericTextBoxFolio.Value = item("folio_factura").Text
            RadDatePickerFechaFacturacion.SelectedDate = item("fecha_fact").Text
            RadDatePickerFechaPago.SelectedDate = item("fecha_pago").Text
            RadNumericTextBoxImportePago.Value = item("importe").Text
            RadTextBoxConcepto.Text = item("concepto").Text
            RadNumericTextBoxImportePagoLetra.Text = RadNumericTextBoxImportePagoLetra.Text = Replace(item("importe_letra").Text, "&nbsp;", "")

            Dim accessSQL As New DataAccess.SQL
            Dim selSql As String = ""
            Dim dt As New DataTable

            selSql = "DELETE " & TableName & " " _
            & "       WHERE no_pago = " & item("no_pago").Text
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            selSql = "SELECT * FROM " & TableName & " ORDER BY no_pago "
            dt = accessSQL.DataTableFill(selSql)
            accessSQL.Close()

            RadGridPagos.DataSource = Nothing
            RadGridPagos.DataSource = dt
            RadGridPagos.DataBind()

            RadNumericTextBoxImportePagosT.Value = RadNumericTextBoxImportePagosT.Value - item("importe").Text

            PanelActPagos1.Visible = False
            PanelActPagos2.Visible = True
         
            RadNumericTextBoxNoPagos2.ReadOnly = True

        Catch ex As Exception
            scriptString = "alert('Se ha detectado un error. \n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

    Protected Sub ButtonEliminar_Click(sender As Object, e As EventArgs)

        Dim scriptString As String = ""

        Try

            item = TryCast(RadGridPagos.SelectedItems(0), GridDataItem)

            Dim accessSQL As New DataAccess.SQL
            Dim selSql As String = ""
            Dim dt As New DataTable

            selSql = "DELETE " & TableName & " " _
            & "       WHERE no_pago = " & item("no_pago").Text & " "
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            ' Ordernar por fecha de facturación
            selSql = "SET DATEFORMAT dmy; " _
            & "       SELECT no_pago = ROW_NUMBER() OVER (ORDER BY fecha_fact) " _
            & "            , folio_factura " _
            & "            , fecha_fact, fecha_pago, importe, concepto, importe_letra " _
            & "       INTO " & TableName & "_1 " _
            & "       FROM " & TableName & " " _
            & "       ORDER BY fecha_fact"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            accessSQL.valida_tabla(TableName, "Drop Table " & TableName, "")
            accessSQL.Close()

            selSql = "exec sp_rename '" & TableName & "_1', '" & TableName & "';"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            selSql = "SELECT * FROM " & TableName & " ORDER BY no_pago "
            dt = accessSQL.DataTableFill(selSql)
            accessSQL.Close()

            RadGridPagos.DataSource = Nothing
            RadGridPagos.DataSource = dt
            RadGridPagos.DataBind()

            RadNumericTextBoxImportePagosT.Value = RadNumericTextBoxImportePagosT.Value - item("importe").Text

            If RadGridPagos.Items.Count = 0 Then
                RadNumericTextBoxNoPagos1.Value = 1
                RadNumericTextBoxFolio.Value = 1
            Else
                RadNumericTextBoxNoPagos1.Value = RadGridPagos.Items.Count + 1
                RadNumericTextBoxFolio.Value = RadGridPagos.Items.Count + 1
            End If
           
        Catch ex As Exception
            scriptString = "alert('Se ha detectado un error. \n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

    Protected Sub RadToolBarGrabarPagos_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarGrabarPagos.ButtonClick
        Select Case e.Item.Text
            Case "Aceptar"
                AgregarPago()
                PanelActPagos1.Visible = True
                PanelActPagos2.Visible = False
                RadNumericTextBoxNoPagos2.ReadOnly = False
            Case "Cancelar"
                CancelarPago()
        End Select
    End Sub
    Public Sub CancelarPago()

        Dim scriptString As String = ""

        Try

            Dim accessSQL As New DataAccess.SQL
            Dim selSql As String = ""
            Dim dt As New DataTable

            selSql = "SET DATEFORMAT dmy; INSERT INTO " & TableName & " VALUES ( " & item("no_pago").Text & ", " & item("folio_factura").Text & ", '" & item("fecha_fact").Text & "', '" & item("fecha_pago").Text & "', " & item("importe").Text & ", '" & item("concepto").Text & "', '" & item("importe_letra").Text & "')"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            selSql = "SELECT * FROM " & TableName & " ORDER BY no_pago "
            dt = accessSQL.DataTableFill(selSql)
            accessSQL.Close()

            RadGridPagos.DataSource = Nothing
            RadGridPagos.DataSource = dt
            RadGridPagos.DataBind()

            RadNumericTextBoxImportePagosT.Value = RadNumericTextBoxImportePagosT.Value + item("importe").Text

            PanelActPagos1.Visible = True
            PanelActPagos2.Visible = False

            RadNumericTextBoxNoPagos2.ReadOnly = False

            If RadNumericTextBoxNoPagos2.Value < RadGridPagos.Items.Count Then
                RadNumericTextBoxFolio.Value = RadGridPagos.Items.Count + 1
                RadNumericTextBoxNoPagos1.Value = RadGridPagos.Items.Count + 1
            End If

            RadDatePickerFechaFacturacion.Clear()
            RadDatePickerFechaPago.Clear()
            RadNumericTextBoxImportePago.Value = Nothing
            RadTextBoxConcepto.Text = ""
            RadNumericTextBoxImportePagoLetra.Text = ""

        Catch ex As Exception
            scriptString = "alert('Se ha detectado un error. \n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                AgregarPronostico()
            Case "Cancelar"

                'oAle.AlertaAgregoProBL(RadNumericTextBoxClave.Value, id_linea_servicio, id_empresa, id_cliente, id_servicio, 100, "", "", "", "")
                'oAle.AlertaAgregoProBL(id_ingreso, id_linea_servicio, id_empresa, id_cliente, id_servicio, vImporte, n_ls, n_e, n_c, n_s)

                Try
                    Dim accessSQL As New DataAccess.SQL
                    Dim selSql As String = ""
                    Dim dt As New DataTable

                    accessSQL.valida_tabla(TableName, "Drop Table " & TableName, "")
                    accessSQL.Close()

                    TableName = ""

                    Response.Redirect("~/PronosticoPrograma.aspx")
                Catch ex As Exception
                    Response.Redirect("~/PronosticoPrograma.aspx")
                End Try

        End Select

    End Sub

    Public Sub AgregarPronostico()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            ' Validar que se capturaron todos los datos
            If id_linea_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar la línea de servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxLineaServicio.Focus()
                Exit Sub
            End If

            If id_empresa = 0 Then
                scriptString = "alert('Favor de seleccionar ¿Quién factura?.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxQuienFactura.Focus()
                Exit Sub
            End If

            If id_cliente = 0 Then
                scriptString = "alert('Favor de seleccionar el cliente.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxCliente.Focus()
                Exit Sub
            End If

            If id_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar el servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxServicio.Focus()
                Exit Sub
            End If

            If RadNumericTextBoxAño1.Text = "" And RadNumericTextBoxAño2.Text = "" And RadNumericTextBoxAño3.Text = "" And RadNumericTextBoxAño4.Text = "" And RadNumericTextBoxAño5.Text = "" Then
                scriptString = "alert('Favor de capturar por lo menos un año de servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxAño1.Focus()
                Exit Sub
            End If

            Dim vImporte As Decimal = IIf(RadNumericTextBoxImporte.Value Is Nothing, 0, RadNumericTextBoxImporte.Value)
            If vImporte = 0 Then
                scriptString = "alert('Favor de capturar el importe del pronóstico');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxImporte.Focus()
                Exit Sub
            End If

            If id_status = 0 Then
                scriptString = "alert('Favor de seleccionar el estatus.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxStatus.Focus()
                Exit Sub
            End If

            If id_status_desc = 0 Then
                scriptString = "alert('Favor de seleccionar el estatus descripción.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxStatusDesc.Focus()
                Exit Sub
            End If


            ' Validar que se capturó por lo menos un pago
            If RadGridPagos.Items.Count = 0 Then
                scriptString = "alert('Favor de capturar por lo menos un pago.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxNoPagos2.Focus()
                Exit Sub
            End If

            '' Validar que se capturaron todos los pagos
            'Dim vNoPagos2 As Decimal = IIf(RadNumericTextBoxNoPagos2.Value Is Nothing, 0, RadNumericTextBoxNoPagos2.Value)
            'If vNoPagos2 <> RadGridPagos.Items.Count Then
            '    scriptString = "alert('Favor de capturar todos los pagos indicados en el no. de pagos.');"
            '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            '    RadNumericTextBoxNoPagos2.Focus()
            '    Exit Sub
            'End If

            ' Validar que el importe del pronóstico es igual al importe en pagos
            Dim vImportePagosT As Decimal = IIf(RadNumericTextBoxImportePagosT.Value Is Nothing, 0, RadNumericTextBoxImportePagosT.Value)

            If vImporte <> vImportePagosT Then
                scriptString = "alert('El importe del pronóstico debe ser igual al importe en pagos.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxImporte.Value = RadNumericTextBoxImportePagosT.Value
                RadNumericTextBoxImporte.Focus()
                Exit Sub
            End If


            ' Obtener la clave del pronóstico-programa de acuerdo a la línea de servicio
            Dim id_ingreso As Integer = 0
            id_ingreso = oIng.ExtraerClaveLineasBL(id_ingreso, id_linea_servicio)
            RadNumericTextBoxClave.Text = id_ingreso


            'Dim v_años As String = Microsoft.VisualBasic.RTrim(Microsoft.VisualBasic.Left(RDIAño1.Text, 4) & "," & Microsoft.VisualBasic.Left(RDIAño2.Text, 4) & "," & Microsoft.VisualBasic.Left(RDIAño3.Text, 4) & "," & Microsoft.VisualBasic.Left(RDIAño4.Text, 4) & "," & Microsoft.VisualBasic.Left(RDIAño5.Text, 4) & ",")
            Dim v_años As String = RTrim(Left(RadNumericTextBoxAño1.Text, 4)) & "," & RTrim(Left(RadNumericTextBoxAño2.Text, 4)) & "," & RTrim(Left(RadNumericTextBoxAño3.Text, 4)) & "," & RTrim(Left(RadNumericTextBoxAño4.Text, 4)) & "," & RTrim(Left(RadNumericTextBoxAño5.Text, 4))


            Dim v_status As String = IIf(id_status = 1, "Pronóstico", IIf(id_status = 2, "Programa", "Gasto"))
            'v_status = IIf(id_status = 2, "Programa", "Gasto")

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     INSERT INTO Ingresos VALUES ( " _
                & "	                " & id_ingreso & " " _
                & "	               ," & id_linea_servicio & " " _
                & "	               ," & id_empresa & " " _
                & "	               ," & id_cliente & " " _
                & "	               ," & id_servicio & " " _
                & "	               ,'" & v_años & "' " _
                & "	               ," & id_status & " " _
                & "	               ," & id_status_desc & " " _
                & "	               ," & vImporte & " " _
                & "	               ,'" & RadTextBoxDetalle.Text & "' " _
                & "	               ," & RadGridPagos.Items.Count & " " _
                & "	               ,0 " _
                & "	               ,'No' " _
                & "	               ,'" & RadTextBoxEspecificaciones.Text & "' " _
                & "	               ," & id_tipo_moneda & "  " _
                & "                ,1" _
                & "                ,''" _
                & "	               ,NULL); " _
                & "     " _
                & "     DECLARE @id_ingreso_pk INT; " _
                & "     SET @id_ingreso_pk = (SELECT TOP (1) id_ingreso_pk FROM Ingresos WHERE id_ingreso = " & id_ingreso & " AND id_linea_servicio = " & id_linea_servicio & ");" _
                & "     " _
                & "     INSERT INTO IngresosPagos " _
                & "     SELECT " _
                & "	           id_ingreso_pk       = @id_ingreso_pk " _
                & "	          ,no_pago             = PAG.no_pago " _
                & "	          ,folio_factura       = PAG.folio_factura " _
                & "	          ,importe             = PAG.importe " _
                & "	          ,importe_letra       = PAG.importe_letra " _
                & "	          ,fecha_fact          = PAG.fecha_fact " _
                & "	          ,fecha_pago          = PAG.fecha_pago " _
                & "	          ,concepto            = PAG.concepto " _
                & "	          ,id_tipo_factura     = 1 " _
                & "	          ,pago_1              = 0 " _
                & "	          ,pago_2              = 0 " _
                & "	          ,pago_3              = 0 " _
                & "	          ,pago_4              = 0 " _
                & "	          ,pago_5              = 0 " _
                & "	          ,iva                 = PAG.importe * 0.16 " _
                & "	          ,total               = (PAG.importe * 0.16) + PAG.importe " _
                & "	          ,fecha_deposito1     = NULL " _
                & "	          ,fecha_deposito2     = NULL " _
                & "	          ,fecha_deposito3     = NULL " _
                & "	          ,fecha_deposito4     = NULL " _
                & "	          ,fecha_deposito5     = NULL " _
                & "	          ,ss                  = 1 " _
                & "           ,motivo_cancelacion  = '' " _
                & "           ,fecha_cancelacion   = NULL " _
                & "     FROM " & TableName & " PAG " _
                & "     ORDER BY PAG.no_pago; " _
                & "     " _
                & "     Drop Table " & TableName & "; " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó " & v_status & "', " & id_ingreso & ", " & id_linea_servicio & ")" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            
            ' Enviar correo electrónico

            Dim n_ls As String = Trim(Mid(RadComboBoxLineaServicio.Text, 4, 100))
            Dim n_e As String = Trim(Mid(RadComboBoxQuienFactura.Text, 4, 100))
            Dim n_c As String = Trim(Mid(RadComboBoxCliente.Text, 4, 100))
            Dim n_s As String = Trim(Mid(RadComboBoxServicio.Text, 4, 100))

            Dim urlTemplate As String = Server.MapPath("~/Plantillas/PronosticosProgramas.html")

            vError = "El " & v_status & " se agregó, pero no se envió la alerta al usuario correspondiente."

            oAle.AlertaAgregoProBL(v_status, urlTemplate, id_ingreso, id_linea_servicio, id_empresa, id_cliente, id_servicio, vImporte, n_ls, n_e, n_c, n_s)
            
            vError = ""
            TableName = ""

            'scriptString = "alert('Pronóstico agregado correcdtamente. \n\n Clave: " & id_ingreso & " \n Línea de servicio: " & n_ls & "');"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/PronosticoPrograma.aspx")

        Catch ex As Exception

            accessSQL.Close()

            'accessSQL.valida_tabla(TableName, "Drop Table " & TableName, "")
            'accessSQL.Close()
            'TableName = ""

            scriptString = "alert('Error al intentar enviar el pronóstico. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            'Response.Redirect("~/PronosticoPrograma.aspx")

        End Try

        '--------------------
        'Ingresos
        '--------------------
        'id_ingreso_pk       
        'id_ingreso          id_ingreso
        'id_linea_servicio   id_linea_servicio
        'id_empresa          id_empresa
        'id_cliente          id_cliente
        'id_servicio         id_servicio
        'años                v_años
        'id_status           id_status
        'id_status_desc      id_status_desc
        'importe             vImporte
        'detalle             RadTextBoxDetalle.text
        'total_pagos         RadGridPagos.rows.count
        'plazo               = 0
        'autorizado          = 'No'
        'especificacion_pago RadTextBoxEspecificaciones.text
        'id_tipo_moneda      id_tipo_moneda
        'ss                  1
        '--------------------

        '--------------------
        'IngresosPagos
        '--------------------
        'id_pago_pk          
        'id_ingreso       id_ingreso
        'id_linea_servicio   id_linea_servicio
        'no_pago             PAG.no_pago
        'folio_factura       PAG.folio_factura
        'FE                  = 0
        'importe             PAG.importe
        'importe_letra       PAG.importe_letra
        'fecha_fact          PAG.fecha_fact
        'fecha_pago          PAG.fecha_pago
        'concepto            PAG.concepto
        'id_tipo_factura     = 1
        'pago_1              = 0
        'pago_2              = 0
        'pago_3              = 0
        'pago_4              = 0
        'pago_5              = 0
        'iva                 = PAG.importe * 0.16
        'total               = (PAG.importe * 0.16) + PAG.importe
        'fecha_deposito1     = ''
        'fecha_deposito2     = ''
        'fecha_deposito3     = ''
        'fecha_deposito4     = ''
        'fecha_deposito5     = ''
        'ss                  = 1
        '--------------------

        ' RadNumericTextBoxClave
        ' RadComboBoxLineaServicio
        ' RadComboBoxQuienFactura
        ' RadComboBoxCliente
        ' RadComboBoxServicio

        ' RadNumericTextBoxAño1
        ' RadNumericTextBoxAño2
        ' RadNumericTextBoxAño3
        ' RadNumericTextBoxAño4
        ' RadNumericTextBoxAño5

        ' RadNumericTextBoxImporte
        ' RadNumericTextBoxImportePagosT
        ' CheckBoxDlls
        ' RadComboBoxDlls
        ' RadTextBoxDetalle
        ' RadComboBoxStatus
        ' RadComboBoxStatusDesc
        ' RadTextBoxEspecificaciones

        ' id_linea_servicio
        ' id_empresa
        ' id_cliente
        ' id_servicio
        ' id_status
        ' id_status_desc

    End Sub

    ' Comentario
    Protected Sub RadNumericTextBoxImporte_TextChanged(sender As Object, e As EventArgs) 'Handles RadNumericTextBoxImporte.TextChanged

        '    Dim vImportePagosT As Decimal = IIf(RadNumericTextBoxImportePagosT.Value Is Nothing, 0, RadNumericTextBoxImportePagosT.Value)

        '    If vImportePagosT > 0 Then
        '        Dim vImporte As Decimal = IIf(RadNumericTextBoxImporte.Value Is Nothing, 0, RadNumericTextBoxImporte.Value)
        '        If vImporte <> vImportePagosT Then
        '            Dim scriptString As String = "alert('El importe del pronóstico debe ser igual al importe en pagos.');"
        '            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        '            RadNumericTextBoxImporte.Value = RadNumericTextBoxImportePagosT.Value
        '        End If
        '    End If

    End Sub

End Class