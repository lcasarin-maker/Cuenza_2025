
Imports System.IO
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Imports Domain
Imports UsuariosBL
Imports IngresosBL
'Imports IngresosPagosBL
Imports BitacoraBL
Imports AlertasBL


Partial Class FacturacionGenerar
    Inherits System.Web.UI.Page

#Region "Variables"
    Shared DirectoryInfoStr As String

    Public lU As New List(Of IUsuario)
    Public oAle As New AlertasBL.AlertasBL
    Public oIng As New IngresosBL.IngresosBL
    Public oInP As New IngresosPagosBL.IngresosPagosBL

    Shared id_Usuario, id_rol, id_linea_servicio, id_pago_pk, id_ingreso_pk, id_ingreso, id_cliente, id_status, id_empresa As Integer
    Shared Usuario, v_n_linea, v_n_cliente As String

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                DirectoryInfoStr = Session("DirectoryInfo")

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                id_pago_pk = Session("id_pago_pk")
                id_ingreso_pk = Session("id_ingreso_pk")

                LlenarDatos()
                VaciarDatos()

            Else
                Response.Redirect("~/Login.aspx")
            End If

        End If
    End Sub

    Public Sub LlenarDatos()

        Dim v_DataTable_Pagos As New DataTable
        v_DataTable_Pagos = oInP.ExtraerIngresosPagosIDpkBL(v_DataTable_Pagos, id_pago_pk, id_ingreso_pk)

        id_empresa = v_DataTable_Pagos.Rows(0).Item("id_empresa")
        id_ingreso = v_DataTable_Pagos.Rows(0).Item("id_ingreso")
        id_linea_servicio = v_DataTable_Pagos.Rows(0).Item("id_linea_servicio")
        id_cliente = v_DataTable_Pagos.Rows(0).Item("id_cliente")
        id_status = v_DataTable_Pagos.Rows(0).Item("id_status")
        v_n_linea = v_DataTable_Pagos.Rows(0).Item("nombre_linea")
        v_n_cliente = v_DataTable_Pagos.Rows(0).Item("nombre_cliente")

        RadTextBoxFechaCz.Text = v_DataTable_Pagos.Rows(0).Item("fecha_fact")
        RadNumericTextBoxImporteCz.Text = v_DataTable_Pagos.Rows(0).Item("importe")
        RadTextBoxConceptoCz.Text = v_DataTable_Pagos.Rows(0).Item("concepto")
        RadTextBoxClienteCz.Text = RTrim(v_DataTable_Pagos.Rows(0).Item("nombre_cliente"))
        'RadTextBoxClienteCz.Text = id_cliente & " " & RTrim(v_DataTable_Pagos.Rows(0).Item("nombre_cliente"))
        
    End Sub
    Public Sub VaciarDatos()
        RadTextBoxFechaFE.Text = ""
        RadNumericTextBoxImporteFE.Text = ""
        RadTextBoxConceptoFE.Text = ""
        RadTextBoxClienteFE.Text = ""

        LabelErrores.Text = ""
        lblMensaje1.Text = ""
        lblMensaje2.Text = ""
        lblMensaje3.Text = ""
        lblMensaje4.Text = ""

        ImageFechaFE.ImageUrl = ""
        ImageImporteFE.ImageUrl = ""
        ImageFechaCz.ImageUrl = ""
        ImageImporteCz.ImageUrl = ""
        ImageConceptoFE.ImageUrl = ""
        ImageConceptoCz.ImageUrl = ""
        ImageClienteFE.ImageUrl = ""
        ImageClienteCz.ImageUrl = ""
    End Sub

    Protected Sub RadToolBarBuscar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarBuscar.ButtonClick

        Try

            VaciarDatos()

            Dim scriptString As String = ""

            If RadNumericTextBoxFolio.Text = "" Then
                scriptString = "alert('Favor de capturar el Folio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            Dim DirectoryInfo As New DirectoryInfo(DirectoryInfoStr)

            Dim vFolio As Integer = RadNumericTextBoxFolio.Text

            ' Validar que la factura no exista en Cuenza
            Dim v_DataTable As New DataTable
            v_DataTable = oInP.BuscarFolioCuenzaBL(v_DataTable, vFolio, id_empresa)

            If v_DataTable.Rows.Count > 0 Then
                scriptString = "alert('El folio capturado ya existe en Cuenza. \n Folio: " & vFolio & "\n\n Favor de revisar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            Dim v_DataTable_Folio As New DataTable
            v_DataTable_Folio = oInP.BuscarFolioEnFacturaEBL(v_DataTable_Folio, vFolio, DirectoryInfo.ToString)

            ' Validar que el folio seleccionado exista en Factura electrónica
            If v_DataTable_Folio.Rows.Count = 0 Then
                scriptString = "alert('No se encontró el folio capturado en Factura electrónica. \n Folio: " & vFolio & "\n\n Favor de revisar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar que el folio seleccionado no esté cancelado en Factura electrónica
            If v_DataTable_Folio.Rows(0).Item("ccancelado") = 1 Then
                scriptString = "alert('El folio seleccionado está cancelado en Factura electrónica. \n Folio: " & vFolio & "\n\n Favor de revisar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            Dim vConcepto As String = ""
            Dim v_DataTable_FolioC As New DataTable
            v_DataTable_FolioC = oInP.BuscarFolioEnFacturaEcBL(v_DataTable_FolioC, v_DataTable_Folio.Rows(0).Item("ciddocum01"), DirectoryInfo.ToString)
            If v_DataTable_FolioC.Rows.Count > 0 Then
                vConcepto = v_DataTable_FolioC.Rows(0).Item("cobserva01")
            End If

            RadTextBoxFechaFE.Text = v_DataTable_Folio.Rows(0).Item("cfecha")
            RadNumericTextBoxImporteFE.Text = v_DataTable_Folio.Rows(0).Item("cneto")
            RadTextBoxConceptoFE.Text = vConcepto

            Dim vCliente As String = Replace(RTrim(v_DataTable_Folio.Rows(0).Item("crazonso01")), "	", "")
            
            RadTextBoxClienteFE.Text = vCliente ' RTrim(v_DataTable_Folio.Rows(0).Item("crazonso01"))
            'RadTextBoxClienteFE.Text = v_DataTable_Folio.Rows(0).Item("cidclien01") & " " & RTrim(v_DataTable_Folio.Rows(0).Item("crazonso01"))

            'cfolio, cfecha, cidclien01, crazonso01, cneto, ccancelado

            Dim vError As Integer = 0

            If RadTextBoxFechaFE.Text <> RadTextBoxFechaCz.Text Then
                ImageFechaFE.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                ImageFechaCz.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                lblMensaje1.Text = "La fecha de la factura electrónica y Cuenza no son iguales, por lo tanto se asignará a Cuenza la fecha de la factura electrónica."
                LabelErrores.Text = "Existe información diferente entre la factura electrónica y Cuenza. Se actualizará la fecha de facturación de Cuenza."
                vError = vError + 1
            Else
                lblMensaje1.ForeColor = Drawing.Color.Black
                lblMensaje1.Text = "La fecha es correcta."
                ImageFechaFE.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
                ImageFechaCz.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
            End If

            If RadNumericTextBoxImporteFE.Text <> RadNumericTextBoxImporteCz.Text Then
                ImageImporteFE.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                ImageImporteCz.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                lblMensaje2.Text = "El importe de la factura electrónica y Cuenza no son iguales."
                LabelErrores.Text = "Existe información diferente entre la factura electrónica y Cuenza, por lo tanto no podrá generar el folio capturado."
                vError = vError + 1
            Else
                lblMensaje2.ForeColor = Drawing.Color.Black
                lblMensaje2.Text = "El importe es correcto."
                ImageImporteFE.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
                ImageImporteCz.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
            End If

            Dim vCza As String = Replace(Replace(RadTextBoxConceptoCz.Text, vbCrLf, ""), vbLf, "")
            Dim vFel As String = Replace(Replace(RadTextBoxConceptoFE.Text, vbCrLf, ""), vbLf, "")

            If vCza <> vFel Then
                'If RadTextBoxConceptoFE.Text <> RadTextBoxConceptoCz.Text Then
                ImageConceptoFE.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                ImageConceptoCz.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                lblMensaje3.Text = "El concepto de la factura electrónica y Cuenza no son iguales."
                LabelErrores.Text = "Existe información diferente entre la factura electrónica y Cuenza, por lo tanto no podrá generar el folio capturado."
                vError = vError + 1
            Else
                lblMensaje3.ForeColor = Drawing.Color.Black
                lblMensaje3.Text = "El concepto es correcto."
                ImageConceptoFE.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
                ImageConceptoCz.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
            End If

            If RadTextBoxClienteFE.Text <> RadTextBoxClienteCz.Text Then
                ImageClienteFE.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                ImageClienteCz.ImageUrl = "~/Imagenes/01_Cancelar_03.png"
                lblMensaje4.Text = "El cliente de la factura electrónica y Cuenza no son iguales."
                LabelErrores.Text = "Existe información diferente entre la factura electrónica y Cuenza, por lo tanto no podrá generar el folio capturado."
                vError = vError + 1
            Else
                lblMensaje4.ForeColor = Drawing.Color.Black
                lblMensaje4.Text = "El cliente es correcto."
                ImageClienteFE.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
                ImageClienteCz.ImageUrl = "~/Imagenes/01_Aceptar_03.png"
            End If

            If vError = 0 Then
                LabelErrores.Text = "La información es correcta entre la factura electrónica y Cuenza, por lo tanto podrá generar el folio capturado."
            End If

        Catch ex As Exception
            lblMensaje1.Text = ex.Message
        End Try

    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Select Case e.Item.Text
            Case "Aceptar"
                GenerarFactura()
            Case "Cancelar"
                Session("id_pago_pk") = Nothing
                Response.Redirect("~/Facturacion.aspx")
        End Select
    End Sub
    Public Sub GenerarFactura()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim vFolio As Integer = 0

        Try

            If RadNumericTextBoxFolio.Text = "" Then
                scriptString = "alert('No es posible generar la factura. \n Favor de capturar el Folio a buscar.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            Else
                vFolio = RadNumericTextBoxFolio.Text
            End If

            If Left(LabelErrores.Text, 26) = "La información es correcta" Then

                ' Generar factura
                oInP.ActualizarFacturadaBL(id_pago_pk, Usuario, vFolio, id_ingreso, id_linea_servicio)

                ' Enviar alerta
                EnviarAlerta(vError, vFolio)

            Else

                Dim vCza As String = Replace(Replace(RadTextBoxConceptoCz.Text, vbCrLf, ""), vbLf, "")
                Dim vFel As String = Replace(Replace(RadTextBoxConceptoFE.Text, vbCrLf, ""), vbLf, "")

                If RadTextBoxFechaFE.Text <> RadTextBoxFechaCz.Text And RadNumericTextBoxImporteFE.Text = RadNumericTextBoxImporteCz.Text And vFel = vCza And RadTextBoxClienteFE.Text = RadTextBoxClienteCz.Text Then

                    ' Generar factura asignando la fecha de facturacion de Cuenza por la de la factura electrónica
                    Dim vFecha As Date = RadTextBoxFechaFE.Text
                    oInP.ActualizarFacturadaFechaBL(id_pago_pk, Usuario, vFolio, id_ingreso, id_linea_servicio, vFecha)

                    ' Enviar alerta
                    EnviarAlerta(vError, vFolio)

                Else
                    scriptString = "alert('No es posible generar la factura. \n Existen errores.');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                    Exit Sub
                End If

            End If

        Catch ex As Exception
            scriptString = "alert('Error al intentar generar la factura. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try
    End Sub
    Public Sub EnviarAlerta(ByRef vError As String, ByVal vFolio As Integer)
        Dim v_status As String = IIf(id_status = 2, "Programa", "Gasto")
        Dim vImporte As Decimal = RadNumericTextBoxImporteCz.Value
        Dim vFecha As String = RadTextBoxFechaCz.Text
        Dim vConcepto As String = RadTextBoxConceptoCz.Text

        Dim urlTemplate As String = Server.MapPath("~/Plantillas/Facturacion.html")

        vError = "Se generó la factura, pero no se envió la alerta al usuario correspondiente."

        oAle.AlertaGeneroFacturaBL(v_status, urlTemplate, id_ingreso, id_linea_servicio, id_cliente, vFolio, vFecha, vImporte, vConcepto, v_n_linea, v_n_cliente)

        vError = ""

        Session("id_pago_pk") = Nothing
        Response.Redirect("~/Facturacion.aspx")
    End Sub

End Class
