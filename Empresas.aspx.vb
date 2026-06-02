
Imports Domain
Imports UsuariosBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class Empresas
    Inherits System.Web.UI.Page


#Region "Variables"
    Public lU As New List(Of IUsuario)
    Shared Usuario As String
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
            Else
                Response.Redirect("~/Login.aspx")
            End If
        End If
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick
        Dim vOpcion As String = e.Item.Text
        PermisosUsuario(vOpcion)
    End Sub
    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        Dim vOpcion As String = e.Item.Text
        PermisosUsuario(vOpcion)
    End Sub
    Public Sub PermisosUsuario(ByVal vOpcion As String)
        Dim id_permiso As Integer = 0
        Dim scriptString As String = ""

        If id_rol > 1 Then
            'If id_Usuario > 0 Then
            scriptString = "alert('Usuario sin permisos para la opción seleccionada.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        Else
            Dim item As GridDataItem = Nothing
            If RadGrid1.SelectedItems.Count > 0 Then
                item = TryCast(RadGrid1.SelectedItems(0), GridDataItem)
            End If

            Select Case vOpcion
                Case "Agregar"
                    Session("id_empresa_act") = 0
                    Response.Redirect("~/EmpresasAgregar.aspx")
                Case "Modificar"
                    If RadGrid1.SelectedItems.Count = 0 Then
                        scriptString = "alert('Favor de seleccionar una Empresa.');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                        Exit Sub
                    End If
                    If item("ss").Text = "Baja" Then
                        scriptString = "alert('No se puede modificar la Empresa seleccionada porque es Baja.');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                        Exit Sub
                    End If
                    Session("id_empresa_act") = item("id_empresa").Text
                    Response.Redirect("~/EmpresasAgregar.aspx")
                Case "Aplicar Baja"
                    If RadGrid1.SelectedItems.Count = 0 Then
                        scriptString = "alert('Favor de seleccionar una Empresa.');"
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                        Exit Sub
                    End If
                    Session("id_empresa_act") = item("id_empresa").Text
                    AplicarBaja(item)
                Case "Generar Reporte"
                    'GenerarReporte()
                    scriptString = "alert('Opción no disponible');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            End Select
        End If
    End Sub

    Public Sub AplicarBaja(item As GridDataItem)

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try
            Dim v_id_selec As Integer = Val(item("id_empresa").Text)
            Dim v_estatus As String = item("ss").Text

            If v_estatus = "Baja" Then
                scriptString = "alert('La Empresa seleccionada ya es Baja.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            'scriptString = "if(!confirm('¿Deseas aplicar baja a la Línea de Servicio seleccionada?')) { return false; }"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "confirm", scriptString, True)

            '--------------------------------------------------------------------------------
            ' Actualizar el estatus (ss)
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE Empresas SET ss = 0 " _
                & "	    WHERE id_empresa = " & v_id_selec & "; " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Aplicó baja a la Empresa ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Baja aplicada correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            RadGrid1.Rebind()

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar aplicar la baja a la Empresa seleccionada. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

End Class
