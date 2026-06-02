
Imports Domain
Imports UsuariosBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class Alertas
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

    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        Dim vOpcion As String = e.Item.Text
        PermisosUsuario(vOpcion)
    End Sub
    Public Sub PermisosUsuario(ByVal vOpcion As String)
        Dim id_permiso As Integer = 0
        Dim scriptString As String = ""

        If id_Usuario > 0 Then
            scriptString = "alert('Usuario sin permisos para la opción seleccionada.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        Else
            Select Case vOpcion
                Case "Generar Reporte"
                    'GenerarReporte()
                    scriptString = "alert('Generar Reporte');"
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            End Select
        End If
    End Sub

End Class
