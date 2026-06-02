
Imports System.Data
Imports Domain
Imports UsuariosBL
Imports System.Web.Services
Imports System.Xml

Partial Class Login
    Inherits System.Web.UI.Page

#Region "Variables"
    'Dim tipoCambio As mx.org.banxico.www.DgieWS = New mx.org.banxico.www.DgieWS
    Public oU As New UsuariosBL.UsuariosBL
    Public lU As New List(Of IUsuario)
#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lU = Session("usuario")
        txtUsuario.Focus()
    End Sub

    Public Sub IniciarSesion()
        oU.usuario = txtUsuario.Text
        oU.password = txtContraseña.Text
        lU = oU.ExtraerUsuarioBL(oU)

        If lU.Count = 1 Then
            'If lU.Item(0).activo = True Then
            '    lblMensaje.Text = "*El usuario se encuentra bloqueado o activo en otra sesión."
            'Else
            Dim id_usuario As Integer = lU.Item(0).id_usuario
            'oU.ActualizarStatusTrueBL(id_usuario)
            Session("usuario") = lU
            Session("mes") = 0
            Session("año") = 0
            Session("id_modulo") = 0

            Session("Lineas") = Nothing

            Session("mesI") = Nothing
            Session("MesF") = Nothing
            Session("añoI") = Nothing
            Session("AñoF") = Nothing

            Session("Status1") = Nothing
            Session("Status2") = Nothing
            Session("Status3") = Nothing
            Session("Status4") = Nothing
            Session("Status5") = Nothing
            Session("Status6") = Nothing
            Session("Status7") = Nothing
            Session("Status8") = Nothing
            Session("Status9") = Nothing

            Session("TipoFactura1") = Nothing
            Session("TipoFactura2") = Nothing
            Session("TipoFactura3") = Nothing
            Session("TipoFactura4") = Nothing

            Session("TipoFecha") = Nothing


            Dim Usuario As String = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno
            Dim accessSQL As New DataAccess.SQL
            Dim selSql As String = ""

            selSql = "SET DATEFORMAT dmy;" _
                 & " BEGIN TRAN " _
                 & "     " _
                 & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Acceso al sistema', 0, " & lU.Item(0).id_linea & ")" _
                 & "     " _
                 & "		IF @@ERROR <> 0  " _
                 & "		BEGIN " _
                 & "			ROLLBACK " _
                 & "			RETURN " _
                 & "		END " _
                 & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            ' id_rol
            '    1 Administrador
            '    2 Socio
            '    3 Gerente
            '    4 R.H.
            '    5 Sistemas

            ' id_modulo
            '    1 Todos
            '    2 Cuenza
            '    3 Cuenpa
            '    4 AdminSist
            '    5 Cuenza y Cuenpa

            If lU.Item(0).id_modulo = 1 Or lU.Item(0).id_modulo = 2 Or lU.Item(0).id_modulo = 5 Then
                Response.Redirect("~/PronosticoPrograma.aspx")
                'Response.Redirect("~/PronosticoPrograma.aspx")
            ElseIf lU.Item(0).id_modulo = 3 Then
                Response.Redirect("~/Facturacion.aspx")
                'Response.Redirect("~/Egresos.aspx")
            ElseIf lU.Item(0).id_modulo = 4 Then
                Response.Redirect("~/Facturacion.aspx")
                'Response.Redirect("~/EquiposComputo.aspx")
            Else
                Response.Redirect("~/Login.aspx")
            End If

            'If lU.Item(0).id_rol = 1 Or lU.Item(0).id_rol = 2 Then

            '    If lU.Item(0).id_modulo = 1 Or lU.Item(0).id_modulo = 2 Or lU.Item(0).id_modulo = 5 Then
            '        Response.Redirect("~/Facturacion.aspx")
            '        'Response.Redirect("~/PronosticoPrograma.aspx")
            '    ElseIf lU.Item(0).id_modulo = 3 Then
            '        Response.Redirect("~/Facturacion.aspx")
            '        'Response.Redirect("~/Egresos.aspx")
            '    ElseIf lU.Item(0).id_modulo = 4 Then
            '        Response.Redirect("~/Facturacion.aspx")
            '        'Response.Redirect("~/EquiposComputo.aspx")
            '    Else
            '        Response.Redirect("~/Login.aspx")
            '    End If

            'ElseIf lU.Item(0).id_rol = 3 Then

            '    If lU.Item(0).id_modulo = 2 Then
            '        Response.Redirect("~/PronosticoPrograma.aspx")
            '        'Response.Redirect("~/PronosticoPrograma.aspx")
            '    ElseIf lU.Item(0).id_modulo = 3 Then
            '        Response.Redirect("~/Facturacion.aspx")
            '        'Response.Redirect("~/EquiposComputo.aspx")
            '    Else
            '        Response.Redirect("~/Login.aspx")
            '    End If

            'ElseIf lU.Item(0).id_rol = 4 Or lU.Item(0).id_rol = 5 Then
            '    Response.Redirect("~/Facturacion.aspx")
            '    'Response.Redirect("~/EquiposComputo.aspx")

            'Else
            '    Response.Redirect("~/Login.aspx")
            'End If


            'End If
        Else
            lblMensaje.Text = "*Error al iniciar sesión, verifique su usuario y contraseña."
        End If
    End Sub

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click

        IniciarSesion()

    End Sub

End Class
