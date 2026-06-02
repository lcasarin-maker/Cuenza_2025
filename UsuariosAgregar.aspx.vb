
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Imports Domain
Imports UsuariosBL

Imports Telerik.Web.UI

Partial Class UsuariosAgregar
    Inherits System.Web.UI.Page

#Region "Variables"

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oUsu As New UsuariosBL.UsuariosBL
    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public oRol As New TiposRolBL.TiposRolBL

    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio As Integer

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

                'AsignarClave()

                SessionLineasS()
                SessionRoles()

                If Not Session("id_usuario_act") Is Nothing Then
                    If Session("id_usuario_act") > 0 Then
                        RadTextBoxClave.Text = Session("id_usuario_act")
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

        LabelTitulo.Text = IIf(RadTextBoxClave.Text = 0, "Agregar Usuario", "Modificar Usuario")

        v_DataTable = New DataTable
        v_DataTable = oUsu.ExtraerUsuarioIDBL(v_DataTable, RadTextBoxClave.Text)

        RadComboBoxRol.SelectedIndex = RadComboBoxRol.FindItemIndexByText(v_DataTable.Rows(0).Item("nombre_rol"))
        RadComboBoxLineaServicio.SelectedIndex = RadComboBoxLineaServicio.FindItemIndexByText(v_DataTable.Rows(0).Item("nombre_linea"))

        RadTextBoxUsuario.Text = v_DataTable.Rows(0).Item("usuario")
        RadTextBoxPassword.Text = v_DataTable.Rows(0).Item("password")
        RadTextBoxNombres.Text = v_DataTable.Rows(0).Item("nombres")
        RadTextBoxApPaterno.Text = v_DataTable.Rows(0).Item("apellido_paterno")
        RadTextBoxApMaterno.Text = v_DataTable.Rows(0).Item("apellido_materno")
        RadTextBoxCorreo.Text = v_DataTable.Rows(0).Item("correo")

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

    Public Sub SessionRoles()
        v_DataTable = New DataTable
        v_DataTable = oRol.ExtraerRolesBL(v_DataTable)
        RadComboBoxRol.DataSource = v_DataTable
        RadComboBoxRol.DataTextField = "descripcion"
        RadComboBoxRol.DataValueField = "id_rol"
        RadComboBoxRol.DataBind()
    End Sub
    Protected Sub RadComboBoxRol_SelectedIndexChanged(ByVal o As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxRol.SelectedIndexChanged
        id_rol = e.Value
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                If RadTextBoxClave.Text = 0 Then
                    AgregarUsuario()
                Else
                    ModificarUsuario()
                End If
            Case "Cancelar"
                Response.Redirect("~/Usuarios.aspx")
        End Select

    End Sub

    Public Sub AgregarUsuario()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_rol As Integer = Val(RadComboBoxRol.SelectedValue)
            Dim v_id_linea_servicio As Integer = Val(RadComboBoxLineaServicio.SelectedValue)

            ' Validar que se capturaron todos los datos
            If v_id_rol = 0 Then
                scriptString = "alert('Favor de seleccionar el Rol del Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxRol.Focus()
                Exit Sub
            End If

            If RadTextBoxUsuario.Text = "" Then
                scriptString = "alert('Favor de capturar el Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxUsuario.Focus()
                Exit Sub
            End If

            If RadTextBoxPassword.Text = "" Then
                scriptString = "alert('Favor de capturar el Password.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxPassword.Focus()
                Exit Sub
            End If

            If RadTextBoxNombres.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre (s).');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombres.Focus()
                Exit Sub
            End If

            If RadTextBoxApPaterno.Text = "" Then
                scriptString = "alert('Favor de capturar el Apellido Paterno.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxApPaterno.Focus()
                Exit Sub
            End If

            If RadTextBoxApMaterno.Text = "" Then
                scriptString = "alert('Favor de capturar el Apellido Materno.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxApMaterno.Focus()
                Exit Sub
            End If

            If v_id_linea_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar la Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxLineaServicio.Focus()
                Exit Sub
            End If

            If RadTextBoxCorreo.Text = "" Then
                scriptString = "alert('Favor de capturar el Correo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCorreo.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Usuario (mismo usuario)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_usuario) FROM Usuarios WHERE usuario = '" & RadTextBoxUsuario.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Usuario capturado ya existe, favor de capturar otro Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxUsuario.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     INSERT INTO Usuarios VALUES ( " _
                & "	                " & id_rol & ", 1 " _
                & "	               ,'" & RadTextBoxUsuario.Text & "' " _
                & "	               ,'" & RadTextBoxPassword.Text & "' " _
                & "	               ,'" & RadTextBoxNombres.Text & "' " _
                & "	               ,'" & RadTextBoxApPaterno.Text & "' " _
                & "	               ,'" & RadTextBoxApMaterno.Text & "' " _
                & "	               ," & id_linea_servicio & " " _
                & "	               ,'" & RadTextBoxCorreo.Text & "' " _
                & "	               , 1, '', 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0); " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó usuario', 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Usuario agregado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Usuarios.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar enviar el usuario. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Usuarios.aspx")
        End Try

    End Sub
    Public Sub ModificarUsuario()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_selec As Integer = RadTextBoxClave.Text
            Dim v_id_rol As Integer = Val(RadComboBoxRol.SelectedValue)
            Dim v_id_linea_servicio As Integer = Val(RadComboBoxLineaServicio.SelectedValue)

            ' Validar que se capturaron todos los datos
            If v_id_rol = 0 Then
                scriptString = "alert('Favor de seleccionar el Rol del Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxRol.Focus()
                Exit Sub
            End If

            If RadTextBoxUsuario.Text = "" Then
                scriptString = "alert('Favor de capturar el Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxUsuario.Focus()
                Exit Sub
            End If

            If RadTextBoxPassword.Text = "" Then
                scriptString = "alert('Favor de capturar el Password.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxPassword.Focus()
                Exit Sub
            End If

            If RadTextBoxNombres.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre (s).');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombres.Focus()
                Exit Sub
            End If

            If RadTextBoxApPaterno.Text = "" Then
                scriptString = "alert('Favor de capturar el Apellido Paterno.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxApPaterno.Focus()
                Exit Sub
            End If

            If RadTextBoxApMaterno.Text = "" Then
                scriptString = "alert('Favor de capturar el Apellido Materno.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxApMaterno.Focus()
                Exit Sub
            End If

            If v_id_linea_servicio = 0 Then
                scriptString = "alert('Favor de seleccionar la Línea de Servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadComboBoxLineaServicio.Focus()
                Exit Sub
            End If

            If RadTextBoxCorreo.Text = "" Then
                scriptString = "alert('Favor de capturar el Correo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCorreo.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Usuario (mismo usuario)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_usuario) FROM Usuarios WHERE id_usuario <> " & v_id_selec & " AND usuario = '" & RadTextBoxUsuario.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Usuario capturado ya existe, favor de capturar otro Usuario.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxUsuario.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE Usuarios SET " _
                & "	           id_rol = " & id_rol & " " _
                & "	         , usuario = '" & RadTextBoxUsuario.Text & "' " _
                & "	         , password = '" & RadTextBoxPassword.Text & "' " _
                & "	         , nombres = '" & RadTextBoxNombres.Text & "' " _
                & "	         , apellido_paterno = '" & RadTextBoxApPaterno.Text & "' " _
                & "	         , apellido_materno = '" & RadTextBoxApMaterno.Text & "' " _
                & "	         , id_linea_servicio = " & id_linea_servicio & " " _
                & "	         , correo = '" & RadTextBoxCorreo.Text & "' " _
                & "	    WHERE id_usuario = " & v_id_selec & "; " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Actualizó usuario ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Usuario actualizado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Usuarios.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar actualizar el usuario seleccionado. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Usuarios.aspx")
        End Try

    End Sub

End Class
