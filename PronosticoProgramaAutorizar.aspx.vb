
'<>
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports Domain
Imports UsuariosBL
Imports IngresosBL
Imports IngresosPagosBL
Imports AlertasBL
Imports Telerik.Web.UI

Partial Class PronosticoProgramaAutorizar
    Inherits System.Web.UI.Page

#Region "Variables"
    Shared item As GridDataItem
    Shared TableName As String = ""
    Public lU As New List(Of IUsuario)
    Shared Usuario As String
    Public oIng As New IngresosBL.IngresosBL
    Public oPag As New IngresosPagosBL.IngresosPagosBL
    Public oAle As New AlertasBL.AlertasBL
    Shared id_Usuario, id_rol, id_linea_servicio, id_status, id_status_desc, id_ingreso_pk As Integer
    Public v_DataTable As DataTable
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

                If Not Session("id_ingreso_pk") Is Nothing Then
                    id_ingreso_pk = Session("id_ingreso_pk")
                    LlenarDatos()
                Else
                    Response.Redirect("~/Login.aspx")
                End If

            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Public Sub LlenarDatos()

        v_DataTable = New DataTable
        v_DataTable = oIng.ExtraerIngresosIDBL(v_DataTable, id_ingreso_pk)

        id_status = v_DataTable.Rows(0).Item("id_status")
        id_status_desc = v_DataTable.Rows(0).Item("id_status_desc")

        LabelTitulo.Text = IIf(id_status = 1, "Autorizar Pronóstico", IIf(id_status = 2, "Autorizar Programa", "Autorizar Gasto"))
        '1	Pronóstico (No Confirmado)
        '2	Programa (Confirmado)
        '3	Gasto

        RadNumericTextBoxClave.Text = v_DataTable.Rows(0).Item("id_ingreso")

        id_linea_servicio = v_DataTable.Rows(0).Item("id_linea_servicio")

        Dim selectedItem1 As New RadComboBoxItem()
        selectedItem1.Text = v_DataTable.Rows(0).Item("nombre_linea")
        selectedItem1.Value = v_DataTable.Rows(0).Item("nombre_linea")
        RadComboBoxLineaServicio.Items.Add(selectedItem1)

        Dim selectedItem2 As New RadComboBoxItem()
        selectedItem2.Text = v_DataTable.Rows(0).Item("nombre_empresa")
        selectedItem2.Value = v_DataTable.Rows(0).Item("nombre_empresa")
        RadComboBoxQuienFactura.Items.Add(selectedItem2)

        Dim selectedItem3 As New RadComboBoxItem()
        selectedItem3.Text = v_DataTable.Rows(0).Item("nombre_cliente")
        selectedItem3.Value = v_DataTable.Rows(0).Item("nombre_cliente")
        RadComboBoxCliente.Items.Add(selectedItem3)

        Dim selectedItem4 As New RadComboBoxItem()
        selectedItem4.Text = v_DataTable.Rows(0).Item("nombre_servicio")
        selectedItem4.Value = v_DataTable.Rows(0).Item("nombre_servicio")
        RadComboBoxServicio.Items.Add(selectedItem4)

        RadNumericTextBoxAño1.Text = v_DataTable.Rows(0).Item("años1")
        RadNumericTextBoxAño2.Text = v_DataTable.Rows(0).Item("años2")
        RadNumericTextBoxAño3.Text = v_DataTable.Rows(0).Item("años3")
        RadNumericTextBoxAño4.Text = v_DataTable.Rows(0).Item("años4")
        RadNumericTextBoxAño5.Text = v_DataTable.Rows(0).Item("años5")

        RadNumericTextBoxImporte.Text = v_DataTable.Rows(0).Item("importe")
        RadNumericTextBoxImportePagosT.Text = v_DataTable.Rows(0).Item("importe")

        Dim selectedItem5 As New RadComboBoxItem()
        selectedItem5.Text = v_DataTable.Rows(0).Item("descripcion_tipo_moneda")
        selectedItem5.Value = v_DataTable.Rows(0).Item("descripcion_tipo_moneda")
        RadComboBoxTipoMoneda.Items.Add(selectedItem5)

        RadTextBoxDetalle.Text = v_DataTable.Rows(0).Item("detalle")

        If id_status = 1 Then
            id_status = 2
        End If

        Dim v_DataTable_Status As New DataTable
        v_DataTable_Status = oIng.ExtraerStatusAutBL(v_DataTable_Status, id_status)

        RadComboBoxStatus.DataSource = v_DataTable_Status
        RadComboBoxStatus.DataTextField = "descripcion"
        RadComboBoxStatus.DataValueField = "id_status"
        RadComboBoxStatus.DataBind()

        RadTextBoxEspecificaciones.Text = v_DataTable.Rows(0).Item("especificacion_pago")

        'id_status = v_DataTable_Status.Rows(0).Item("id_status")
        StatusDesc()

        If id_status = 3 Then
            RadComboBoxStatusDesc.SelectedValue = id_status_desc
        End If

        Dim v_DataTable_Pagos As New DataTable
        v_DataTable_Pagos = oPag.ExtraerIngresosPagosIDBL(v_DataTable_Pagos, id_ingreso_pk)

        RadGridPagos.DataSource = Nothing
        RadGridPagos.DataSource = v_DataTable_Pagos

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
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Select Case e.Item.Text
            Case "Autorizar"
                AutorizarPronostico()
            Case "Rechazar"
                RechazarPronostico()
        End Select
    End Sub
    Public Sub AutorizarPronostico()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            ' Validar que se capturaron todos los datos
            If id_status_desc = 0 Then
                scriptString = "alert('Favor de seleccionar el estatus descripción.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxStatusDesc.Focus()
                Exit Sub
            End If

            Dim id_ingreso As Integer = RadNumericTextBoxClave.Text

            'Dim v_status1 As String = Right(LabelTitulo.Text, 5)
            'Dim v_status As String = IIf(v_status1 = "stico", "Pronóstico", IIf(v_status1 = "grama", "Programa", "Gasto"))

            Dim v_status As String = IIf(id_status = 1, "Pronóstico", IIf(id_status = 2, "Programa", "Gasto"))
            'Dim v_status As String = IIf(id_status = 1, "Pronóstico", "Programa")
            'v_status = IIf(id_status = 2, "Programa", "Gasto")

            '--------------------------------------------------------------------------------
            ' Actualizar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE Ingresos SET id_status = " & id_status & ", id_status_desc = " & id_status_desc & ", autorizado = 'Si' WHERE id_ingreso_pk = " & id_ingreso_pk _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Autorizó " & v_status & "', " & id_ingreso & ", " & id_linea_servicio & ")" _
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

            Dim id_empresa As Integer = Val(Left(RadComboBoxQuienFactura.Text, 2))
            Dim id_cliente As Integer = Val(Left(RadComboBoxCliente.Text, 3))
            Dim id_servicio As Integer = Val(Left(RadComboBoxServicio.Text, 2))

            Dim n_ls As String = Trim(Mid(RadComboBoxLineaServicio.Text, 4, 100))
            Dim n_e As String = Trim(Mid(RadComboBoxQuienFactura.Text, 4, 100))
            Dim n_c As String = Trim(Mid(RadComboBoxCliente.Text, 4, 100))
            Dim n_s As String = Trim(Mid(RadComboBoxServicio.Text, 4, 100))

            Dim vImporte As Decimal = RadNumericTextBoxImporte.Value
            
            Dim urlTemplate As String = Server.MapPath("~/Plantillas/PronosticosProgramas.html")

            vError = "El " & v_status & " se autorizó, pero no se envió la alerta al usuario correspondiente."

            oAle.AlertaAutorizoProBL(v_status, urlTemplate, id_ingreso, id_linea_servicio, id_empresa, id_cliente, id_servicio, vImporte, n_ls, n_e, n_c, n_s)
            
            vError = ""
            TableName = ""

            'scriptString = "alert('Pronóstico autorizado correcdtamente. \n\n Clave: " & id_ingreso & " \n Línea de servicio: " & n_ls & "');"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/PronosticoPrograma.aspx")

        Catch ex As Exception

            accessSQL.Close()

            scriptString = "alert('Error al intentar autorizar el pronóstico. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

        End Try

    End Sub
    Public Sub RechazarPronostico()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim id_ingreso As Integer = RadNumericTextBoxClave.Text

            'Dim v_status1 As String = Right(LabelTitulo.Text, 5)
            'Dim v_status As String = IIf(v_status1 = "stico", "Pronóstico", IIf(v_status1 = "grama", "Programa", "Gasto"))
            Dim v_status As String = IIf(id_status = 1, "Pronóstico", IIf(id_status = 2, "Programa", "Gasto"))

            '--------------------------------------------------------------------------------
            ' Actualizar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Rechazó " & v_status & "', " & id_ingreso & ", " & id_linea_servicio & ")" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            '--------------------------------------------------------------------------------
            ' Enviar correo electrónico
            '--------------------------------------------------------------------------------

            Dim id_empresa As Integer = Val(Left(RadComboBoxQuienFactura.Text, 2))
            Dim id_cliente As Integer = Val(Left(RadComboBoxCliente.Text, 3))
            Dim id_servicio As Integer = Val(Left(RadComboBoxServicio.Text, 2))

            Dim n_ls As String = Trim(Mid(RadComboBoxLineaServicio.Text, 4, 100))
            Dim n_e As String = Trim(Mid(RadComboBoxQuienFactura.Text, 4, 100))
            Dim n_c As String = Trim(Mid(RadComboBoxCliente.Text, 4, 100))
            Dim n_s As String = Trim(Mid(RadComboBoxServicio.Text, 4, 100))

            Dim vImporte As Decimal = RadNumericTextBoxImporte.Value

            Dim urlTemplate As String = Server.MapPath("~/Plantillas/PronosticosProgramas.html")

            vError = "El " & v_status & " se rechazó, pero no se envió la alerta al usuario correspondiente."

            oAle.AlertaRechazoProBL(v_status, urlTemplate, id_ingreso, id_linea_servicio, id_empresa, id_cliente, id_servicio, vImporte, n_ls, n_e, n_c, n_s)

            vError = ""
            TableName = ""

            Response.Redirect("~/PronosticoPrograma.aspx")

        Catch ex As Exception

            accessSQL.Close()

            scriptString = "alert('Error al intentar rechazar el pronóstico. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

        End Try

    End Sub


End Class
