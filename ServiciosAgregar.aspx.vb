
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Imports Domain
Imports UsuariosBL

Imports Telerik.Web.UI

Partial Class ServiciosAgregar
    Inherits System.Web.UI.Page

#Region "Variables"

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oUsu As New UsuariosBL.UsuariosBL
    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public oSer As New ServiciosBL.ServiciosBL
    Public oRol As New TiposRolBL.TiposRolBL

    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, id_servicio, id_linaea_orig As Integer

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                If Not Session("Lineas") Is Nothing Then
                    Session("Lineas") = Session("Lineas")
                End If

                SessionLineasS()

                If Not Session("id_servicio_act") Is Nothing Then
                    If Session("id_servicio_act") > 0 Then
                        RadTextBoxClave.Text = Session("id_servicio_act")
                        LlenarDatos()
                    Else
                        RadTextBoxClave.Text = 0
                    End If
                Else
                    RadTextBoxClave.Text = 0
                End If

            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Public Sub LlenarDatos()

        LabelTitulo.Text = IIf(RadTextBoxClave.Text = 0, "Agregar Servicio", "Modificar Servicio")

        v_DataTable = New DataTable
        v_DataTable = oSer.ExtraerServiciosTodoIdBL(v_DataTable, RadTextBoxClave.Text)

        id_linaea_orig = v_DataTable.Rows(0).Item("id_linea_servicio")
        RadComboBoxLineaServicio.SelectedIndex = RadComboBoxLineaServicio.FindItemIndexByText(v_DataTable.Rows(0).Item("nombre_linea"))

        RadTextBoxNombre.Text = v_DataTable.Rows(0).Item("nombre_servicio")

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
        'SessionServicio()
        'AsignarClave()
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                If RadTextBoxClave.Text = 0 Then
                    AgregarServicio()
                Else
                    ModificarServicio()
                End If
            Case "Cancelar"
                Response.Redirect("~/Servicios.aspx")
        End Select

    End Sub

    Public Sub AgregarServicio()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_linea_servicio As Integer = Val(RadComboBoxLineaServicio.SelectedValue)

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If v_id_linea_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar la Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxLineaServicio.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Servicio (mismo nombre_servicio)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_servicio) FROM Servicios WHERE id_linea_servicio = " & v_id_linea_servicio & " AND nombre_servicio = '" & RadTextBoxNombre.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Servicio capturado ya existe, favor de capturar otro Nombre y/u otra Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Obtener el id_servicio
            '--------------------------------------------------------------------------------
            selSql = "SELECT id_servicio = 1 + CASE WHEN MAX(id_servicio) IS NULL THEN 0 ELSE MAX(id_servicio) END FROM Servicios WHERE id_linea_servicio = " & v_id_linea_servicio
            vDataTable = New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            Dim v_id_nuevo As Integer = vDataTable.Rows(0).Item(0)

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     INSERT INTO Servicios VALUES ( " _
                & "	                " & v_id_nuevo & " " _
                & "	               ,'" & RadTextBoxNombre.Text & "' " _
                & "	               ," & id_linea_servicio & " " _
                & "	               , 1); " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó Servicio', 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Servicio agregado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Servicios.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar enviar el Servicio. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Servicios.aspx")
        End Try

    End Sub
    Public Sub ModificarServicio()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_selec As Integer = RadTextBoxClave.Text
            Dim v_id_linea_servicio As Integer = Val(RadComboBoxLineaServicio.SelectedValue)

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If v_id_linea_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar la Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxLineaServicio.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Servicio (mismo nombre_servicio)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_servicio) FROM Servicios WHERE id_servicio <> " & v_id_selec & " AND nombre_servicio = '" & RadTextBoxNombre.Text & "' AND id_linea_servicio = " & v_id_linea_servicio
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Servicio capturado ya existe, favor de capturar otro Nombre y/u otra Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Obtener el id_servicio
            '--------------------------------------------------------------------------------
            selSql = "SELECT id_servicio = 1 + CASE WHEN MAX(id_servicio) IS NULL THEN 0 ELSE MAX(id_servicio) END FROM Servicios WHERE id_linea_servicio = " & v_id_linea_servicio
            vDataTable = New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            Dim v_id_nuevo As Integer = vDataTable.Rows(0).Item(0)

            '--------------------------------------------------------------------------------
            ' Actualizar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE Servicios SET " _
                & "	           id_servicio = " & v_id_nuevo _
                & "	         , nombre_servicio = '" & RadTextBoxNombre.Text & "' " _
                & "	         , id_linea_servicio = " & id_linea_servicio & " " _
                & "	    WHERE id_servicio = " & v_id_selec _
                & "       AND id_linea_servicio = " & id_linaea_orig & "; " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Actualizó Servicio ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Servicio actualizado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Servicios.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar actualizar el Servicio seleccionado. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Servicios.aspx")
        End Try

    End Sub


End Class
