
Imports System.IO
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Imports Domain
'Imports UsuariosBL
'Imports IngresosBL
'Imports IngresosPagosBL
'Imports BitacoraBL
'Imports AlertasBL

Partial Class FacturacionCancelar
    Inherits System.Web.UI.Page


#Region "Variables"
    Public lU As New List(Of IUsuario)
    Public oAle As New AlertasBL.AlertasBL
    Public oIng As New IngresosBL.IngresosBL
    Public oInP As New IngresosPagosBL.IngresosPagosBL

    Shared id_Usuario, id_rol, id_linea_servicio, id_pago_pk, id_ingreso_pk, id_ingreso, id_cliente, id_status, id_status_desc As Integer
    Shared Usuario, v_n_linea, v_n_cliente As String
    Shared vCaso As Integer
    Public v_DataTable As DataTable

    '' Variables de sesión
    'Shared mesI, añoI, mesF, añoF As Integer
    'Shared FToday As Date = Today()
    'Shared Fini As Date
    'Shared Ffin As Date


#End Region

    Public Sub IniciaVariables()

        ''----------------------------------------------------------------------------------------------------
        ''----------------------------------------------------------------------------------------------------
        'If Not Session("mesI") Is Nothing Then
        '    mesI = Session("mesI")
        'Else
        '    mesI = 0
        'End If
        'If Not Session("añoI") Is Nothing Then
        '    añoI = Session("añoI")
        'Else
        '    añoI = 0
        'End If
        'If mesI = 0 And añoI = 0 Then
        '    mesI = Month(Today)
        '    añoI = Year(Today)
        'End If
        ''RCBMesI.SelectedIndex = mesI - 1
        ''RCBAñoI.SelectedIndex = añoI - 2008
        ''----------------------------------------------------------------------------------------------------
        ''----------------------------------------------------------------------------------------------------
        'If Not Session("MesF") Is Nothing Then
        '    mesF = Session("MesF")
        'Else
        '    mesF = 0
        'End If
        'If Not Session("AñoF") Is Nothing Then
        '    añoF = Session("AñoF")
        'Else
        '    añoF = 0
        'End If
        'If mesF = 0 And añoF = 0 Then
        '    mesF = Month(Today)
        '    añoF = Year(Today)
        'End If
        ''RCBMesF.SelectedIndex = mesF - 1
        ''RCBAñoF.SelectedIndex = añoF - 2008
        ''----------------------------------------------------------------------------------------------------
        ''----------------------------------------------------------------------------------------------------

        ''----------------------------------------------------------------------------------------------------
        ''----------------------------------------------------------------------------------------------------
        'FToday = Today()
        'Fini = CType("01/" & mesI & "/" & añoI, Date)
        'Ffin = CType(System.DateTime.DaysInMonth(añoF - 2008, mesF) & "/" & mesF & "/" & añoF, Date)

        'If Not Session("Status1") Is Nothing Then

        '    Status1 = Session("Status1")
        '    Status2 = Session("Status2")
        '    Status3 = Session("Status3")
        '    Status4 = Session("Status4")

        '    TipoFactura1 = Session("TipoFactura1")
        '    TipoFactura2 = Session("TipoFactura2")
        '    TipoFactura3 = Session("TipoFactura3")
        '    TipoFactura4 = Session("TipoFactura4")

        '    TipoFecha = Session("TipoFecha")

        '    'CBStatus1.Checked = IIf(Status1 > 0, True, False)
        '    'CBStatus2.Checked = IIf(Status2 > 0, True, False)
        '    'CBStatus3.Checked = IIf(Status3 > 0, True, False)
        '    'CBStatus4.Checked = IIf(Status4 > 0, True, False)

        '    'CBTipoFactura1.Checked = IIf(TipoFactura1 > 0, True, False)
        '    'CBTipoFactura2.Checked = IIf(TipoFactura2 > 0, True, False)
        '    'CBTipoFactura3.Checked = IIf(TipoFactura3 > 0, True, False)
        '    'CBTipoFactura4.Checked = IIf(TipoFactura4 > 0, True, False)

        '    'CBTipoFecha1.Checked = IIf(TipoFecha = "fecha_fact", True, False)
        '    'CBTipoFecha2.Checked = IIf(TipoFecha = "fecha_pago", True, False)

        '    Fini_f = IIf(TipoFecha = "fecha_fact", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
        '    Ffin_f = IIf(TipoFecha = "fecha_fact", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")
        '    Fini_p = IIf(TipoFecha = "fecha_pago", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
        '    Ffin_p = IIf(TipoFecha = "fecha_pago", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")

        'Else

        '    Status1 = 1
        '    Status2 = 2
        '    Status3 = 3
        '    Status4 = 0
        '    TipoFactura1 = 1
        '    TipoFactura2 = 2
        '    TipoFactura3 = 3
        '    TipoFactura4 = 0
        '    TipoFecha = "fecha_fact"

        '    'CBStatus1.Checked = True
        '    'CBStatus2.Checked = True
        '    'CBStatus3.Checked = True
        '    'CBStatus4.Checked = False
        '    'CBTipoFactura1.Checked = True
        '    'CBTipoFactura2.Checked = True
        '    'CBTipoFactura3.Checked = True
        '    'CBTipoFactura4.Checked = False
        '    'CBTipoFecha1.Checked = True
        '    'CBTipoFecha2.Checked = False

        '    Fini_f = Format(Fini, "dd/MM/yyyy")
        '    Ffin_f = Format(Ffin, "dd/MM/yyyy")
        '    Fini_p = "01/01/1900"
        '    Ffin_p = "01/01/1900"

        'End If

        ''lblStatus.Text = "Facturas de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue
        ''lblMensaje.Text = ""

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                id_pago_pk = Session("id_pago_pk")
                id_ingreso_pk = Session("id_ingreso_pk")

                LlenarDatos()

                RadTextBoxMotivo.Text = ""
                CBCancDef.Checked = False

                vCaso = 0

            Else
                Response.Redirect("~/Login.aspx")
            End If

        End If
    End Sub

    Public Sub LlenarDatos()

        Dim v_DataTable_Pagos As New DataTable
        v_DataTable_Pagos = oInP.ExtraerIngresosPagosIDpkBL(v_DataTable_Pagos, id_pago_pk, id_ingreso_pk)

        id_ingreso = v_DataTable_Pagos.Rows(0).Item("id_ingreso")
        id_linea_servicio = v_DataTable_Pagos.Rows(0).Item("id_linea_servicio")
        id_cliente = v_DataTable_Pagos.Rows(0).Item("id_cliente")
        id_status = v_DataTable_Pagos.Rows(0).Item("id_status")
        v_n_linea = v_DataTable_Pagos.Rows(0).Item("nombre_linea")
        v_n_cliente = v_DataTable_Pagos.Rows(0).Item("nombre_cliente")

        RadNumericTextBoxFolio.Text = v_DataTable_Pagos.Rows(0).Item("folio_factura")
        RadTextBoxFechaCz.Text = v_DataTable_Pagos.Rows(0).Item("fecha_fact")
        RadNumericTextBoxImporteCz.Text = v_DataTable_Pagos.Rows(0).Item("importe")
        RadNumericTextBoxImporteTotCz.Text = v_DataTable_Pagos.Rows(0).Item("importe_t")
        RadTextBoxConceptoCz.Text = v_DataTable_Pagos.Rows(0).Item("concepto")
        RadTextBoxClienteCz.Text = id_cliente & " " & RTrim(v_DataTable_Pagos.Rows(0).Item("nombre_cliente"))

        'RadNumericTextBoxFolio
        'RadTextBoxFechaCz
        'RadNumericTextBoxImporteCz
        'RadNumericTextBoxImporteTotCz
        'RadTextBoxConceptoCz
        'RadTextBoxClienteCz

        Dim v_DataTable_Status As New DataTable
        v_DataTable_Status = oIng.ExtraerStatusCancBL(v_DataTable_Status, id_status)

        RadComboBoxStatus.DataSource = v_DataTable_Status
        RadComboBoxStatus.DataTextField = "descripcion"
        RadComboBoxStatus.DataValueField = "id_status"
        RadComboBoxStatus.DataBind()

        id_status = v_DataTable_Status.Rows(0).Item("id_status")
        StatusDesc()

    End Sub

    Public Sub Status()
        v_DataTable = New DataTable
        v_DataTable = oIng.ExtraerStatusCancBL(v_DataTable, id_status)

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
    End Sub

   
    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Select Case e.Item.Text
            Case "Aceptar"
                CancelarFactura()
            Case "Cancelar"
                Session("id_pago_pk") = Nothing
                Response.Redirect("~/Facturacion.aspx")
        End Select
    End Sub
    Public Sub CancelarFactura()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim vFolio As Integer = 0

        Try

            If RadTextBoxMotivo.Text = "" Then
                scriptString = "alert('Favor de capturar el motivo de la cancelación.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            vFolio = RadNumericTextBoxFolio.Text
            Dim v_importe As Decimal = RadNumericTextBoxImporteTotCz.Text

            If vCaso = 0 Then
                ' Agregar pago nuevo
                oInP.CancelarFacturaC0BL(id_pago_pk, Usuario, vFolio, id_ingreso, id_linea_servicio, RadTextBoxMotivo.Text)
            ElseIf vCaso = 1 Then
                ' Cancelar factura y actualizar el importe total
                oInP.CancelarFacturaC1BL(id_pago_pk, Usuario, vFolio, id_ingreso, id_linea_servicio, RadTextBoxMotivo.Text, id_ingreso_pk, v_importe)
            Else
                ' Cancelar factura y cancelar el programa o gasto

                ' Validar que se seleccionaron los estatus
                If id_status = 0 Then
                    scriptString = "alert('Favor de seleccionar el estatus.');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                    RadComboBoxStatusDesc.Focus()
                    Exit Sub
                End If

                If id_status_desc = 0 Then
                    scriptString = "alert('Favor de seleccionar el estatus descripción.');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                    RadComboBoxStatusDesc.Focus()
                    Exit Sub
                End If

                oInP.CancelarFacturaC2BL(id_pago_pk, Usuario, vFolio, id_ingreso, id_linea_servicio, RadTextBoxMotivo.Text, id_ingreso_pk, id_status, id_status_desc)
            End If

            ' Enviar alerta

            Dim v_status As String = IIf(id_status = 2, "Programa", "Gasto")
            Dim vImporte As Decimal = RadNumericTextBoxImporteCz.Value
            Dim vFecha As String = RadTextBoxFechaCz.Text
            Dim vConcepto As String = RadTextBoxConceptoCz.Text

            Dim urlTemplate As String = Server.MapPath("~/Plantillas/Facturacion.html")

            vError = "Se canceló la factura, pero no se envió la alerta al usuario correspondiente."

            oAle.AlertaCanceloFacturaBL(v_status, urlTemplate, id_ingreso, id_linea_servicio, id_cliente, vFolio, vFecha, vImporte, vConcepto, v_n_linea, v_n_cliente)

            vError = ""

            Session("id_pago_pk") = Nothing
            Response.Redirect("~/Facturacion.aspx")

        Catch ex As Exception
            scriptString = "alert('Error al intentar cancelar la factura. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try
    End Sub


    Protected Sub CBCancDef_CheckedChanged(sender As Object, e As EventArgs) Handles CBCancDef.CheckedChanged

        Dim vImportePago As Decimal = RadNumericTextBoxImporteCz.Text
        Dim vImporteTotal As Decimal = RadNumericTextBoxImporteTotCz.Text

        If CBCancDef.Checked = True Then
            If vImporteTotal - vImportePago > 0 Then
                RadNumericTextBoxImporteTotCz.Text = vImporteTotal - vImportePago
                RadComboBoxStatus.Enabled = False
                RadComboBoxStatusDesc.Enabled = False
                vCaso = 1
            Else
                RadComboBoxStatus.Enabled = True
                RadComboBoxStatusDesc.Enabled = True
                vCaso = 2
            End If
        Else
            If vCaso = 1 Then
                RadNumericTextBoxImporteTotCz.Text = vImporteTotal + vImportePago
            End If

            RadComboBoxStatus.Enabled = False
            RadComboBoxStatusDesc.Enabled = False
            vCaso = 0
        End If
    End Sub
End Class
