
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Imports Domain
Imports UsuariosBL
Imports LineasServicioBL

Imports Telerik.Web.UI
Imports System.ServiceModel.MsmqIntegration

Partial Class LineasServicioAgregar
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

                If Not Session("id_linea_act") Is Nothing Then
                    If Session("id_linea_act") > 0 Then
                        RadTextBoxClave.Text = Session("id_linea_act")
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

        LabelTitulo.Text = IIf(RadTextBoxClave.Text = 0, "Agregar Línea de Servicio", "Modificar Línea de Servicio")

        v_DataTable = New DataTable
        v_DataTable = oLiS.ExtraerLineasSTodoIdBL(v_DataTable, RadTextBoxClave.Text)

        RadTextBoxNombre.Text = v_DataTable.Rows(0).Item("nombre_linea")
        RadTextBoxSocio.Text = v_DataTable.Rows(0).Item("socio")
        RadTextBoxGerente.Text = v_DataTable.Rows(0).Item("gerente")

    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                If RadTextBoxClave.Text = 0 Then
                    AgregarLineaS()
                Else
                    ModificarLineaS()
                End If
            Case "Cancelar"
                Response.Redirect("~/LineasServicio.aspx")
        End Select

    End Sub

    Public Sub AgregarLineaS()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            'Dim v_id_rol As Integer = Val(RadComboBoxRol.SelectedValue)
            'Dim v_id_linea_servicio As Integer = Val(RadComboBoxLineaServicio.SelectedValue)

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If RadTextBoxSocio.Text = "" Then
                scriptString = "alert('Favor de capturar el Socio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxSocio.Focus()
                Exit Sub
            End If

            If RadTextBoxGerente.Text = "" Then
                scriptString = "alert('Favor de capturar el Gerente.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxGerente.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe la Línea de Servicio (mismo nombre)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_linea_servicio) FROM LineasServicio WHERE nombre_linea = '" & RadTextBoxNombre.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('La Línea de Servicio capturada ya existe, favor de capturar otro Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Obtener el id_linea_servicio
            '--------------------------------------------------------------------------------
            selSql = "SELECT id_linea_servicio = 1 + CASE WHEN MAX(id_linea_servicio) IS NULL THEN 0 ELSE MAX(id_linea_servicio) END FROM LineasServicio WHERE id_linea_servicio <> 99"
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
                & "     INSERT INTO LineasServicio VALUES ( " _
                & "	                 " & v_id_nuevo & " " _
                & "	              , '" & RadTextBoxNombre.Text & "' " _
                & "	               ,'" & RadTextBoxSocio.Text & "' " _
                & "	               ,'" & RadTextBoxGerente.Text & "' " _
                & "	               , 1); " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó línea de servicio', 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Línea de Servicio agregada correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/LineasServicio.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar enviar la Línea de Servicio. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/LineasServicio.aspx")
        End Try

    End Sub
    Public Sub ModificarLineaS()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_selec As Integer = RadTextBoxClave.Text

            ' RadTextBoxClave | RadTextBoxNombre | RadTextBoxSocio | RadTextBoxGerente

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If RadTextBoxSocio.Text = "" Then
                scriptString = "alert('Favor de capturar el Socio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxSocio.Focus()
                Exit Sub
            End If

            If RadTextBoxGerente.Text = "" Then
                scriptString = "alert('Favor de capturar el Gerente.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxGerente.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe la Línea de Servicio (mismo nombre_linea)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_linea_servicio) FROM LineasServicio WHERE id_linea_servicio <> " & v_id_selec & " AND nombre_linea = '" & RadTextBoxNombre.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('La Línea de Servicio capturada ya existe, favor de capturar otro Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE LineasServicio SET " _
                & "	           nombre_linea = '" & RadTextBoxNombre.Text & "' " _
                & "	         , socio = '" & RadTextBoxSocio.Text & "' " _
                & "	         , gerente = '" & RadTextBoxGerente.Text & "' " _
                & "	    WHERE id_linea_servicio = " & v_id_selec & "; " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Actualizó Línea de Servicio ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Línea de Servicio actualizada correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/LineasServicio.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar actualizar la Línea de Servicio seleccionada. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/LineasServicio.aspx")
        End Try

    End Sub

End Class
