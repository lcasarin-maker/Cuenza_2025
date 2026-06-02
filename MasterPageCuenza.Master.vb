
Imports Domain
Imports UsuariosBL

Partial Class MasterPageCuenza
    Inherits System.Web.UI.MasterPage

    Public lU As New List(Of IUsuario)
    Public nombreUsuario As String
    'Shared v_modulo As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        
        'If Not Page.IsPostBack Then

        'Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        'Page.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        'Page.Response.Cache.SetAllowResponseInBrowserHistory(False)
        'Page.Response.Cache.SetNoStore()

        'Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache)
        'Response.Cache.SetAllowResponseInBrowserHistory(False)
        'Response.Cache.SetNoStore()

        If Not Session("usuario") Is Nothing Then

            lU = Session("usuario")
            nombreUsuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno
            lblNombreUsuario.Text = nombreUsuario

            Dim vRolint As Integer = lU.Item(0).id_rol
            Dim vRolstr As String = Replace(Replace(Replace(Replace(Replace(vRolint, "1", "Administrador"), "2", "Socio"), "3", "Gerente"), "4", "Recursos Humanos"), "5", "Sistemas")
            LabelRol.Text = vRolstr

            RadToolBarCiclosNegocio.Items(0).Visible = False
            RadToolBarCiclosNegocio.Items(1).Visible = False
            RadToolBarCiclosNegocio.Items(2).Visible = False

            MenuMP()

            'MClasificacion()
            'MConfiguracion()
            'MProcesos()
            'End If

        Else
            Response.Redirect("~/Login.aspx")
        End If

    End Sub

    Public Sub MenuMP()

        ' Roles
        ' 1 Administrador
        ' 2 Socio
        ' 3 Gerente
        ' 4 R.H.
        ' 5 Sistemas

        If lU.Item(0).id_rol = 1 Or lU.Item(0).id_rol = 2 Then
            RadPanelBarProcesosMenus.Items(1).Visible = True
            RadPanelBarConfiguracionMenus.Items(0).Visible = True
            RadPanelBarConfiguracionMenus.Items(1).Visible = True
        Else
            RadPanelBarProcesosMenus.Items(1).Visible = False
            RadPanelBarConfiguracionMenus.Items(0).Visible = False
            RadPanelBarConfiguracionMenus.Items(1).Visible = False
        End If

        
        ' 0 Pronostico y Programa
        ' 1 Facturación
        ' 2 Control de Cobranza

        ' 0 Pronostico y Programa
        ' 1 Pronostico y Programa V2
        ' 2 Facturación
        ' 3 Control de Cobranza




        ' id_modulo
        '    1 Todos
        '    2 Cuenza
        '    3 Cuenpa
        '    4 AdminSist
        '    5 Cuenza y Cuenpa

        'If lU.Item(0).id_modulo = 1 Then
        '    RadToolBarCiclosNegocio.Items(0).Visible = True
        '    RadToolBarCiclosNegocio.Items(1).Visible = True
        '    RadToolBarCiclosNegocio.Items(2).Visible = True
        'ElseIf lU.Item(0).id_modulo = 2 Then
        '    RadToolBarCiclosNegocio.Items(0).Visible = True
        '    RadToolBarCiclosNegocio.Items(1).Visible = False
        '    RadToolBarCiclosNegocio.Items(2).Visible = False
        'ElseIf lU.Item(0).id_modulo = 3 Then
        '    RadToolBarCiclosNegocio.Items(0).Visible = False
        '    RadToolBarCiclosNegocio.Items(1).Visible = True
        '    RadToolBarCiclosNegocio.Items(2).Visible = False
        'ElseIf lU.Item(0).id_modulo = 4 Then
        '    RadToolBarCiclosNegocio.Items(0).Visible = False
        '    RadToolBarCiclosNegocio.Items(1).Visible = False
        '    RadToolBarCiclosNegocio.Items(2).Visible = True
        'ElseIf lU.Item(0).id_modulo = 5 Then
        '    RadToolBarCiclosNegocio.Items(0).Visible = True
        '    RadToolBarCiclosNegocio.Items(1).Visible = True
        '    RadToolBarCiclosNegocio.Items(2).Visible = False
        'Else
        '    RadToolBarCiclosNegocio.Visible = False
        'End If

        
    End Sub

    Public Sub MClasificacion()
        If lU.Item(0).L01 = True Or lU.Item(0).L02 = True Or lU.Item(0).L03 = True Or lU.Item(0).L04 = True Or lU.Item(0).L05 = True Or lU.Item(0).L06 = True Then
            RadPanelBarClasificacion.Visible = True

            If lU.Item(0).L01 = False Then
                RadPanelBarClasificacionMenus.Items(0).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(0).Visible = True
            End If

            If lU.Item(0).L02 = False Then
                RadPanelBarClasificacionMenus.Items(1).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(1).Visible = True
            End If

            If lU.Item(0).L03 = False Then
                RadPanelBarClasificacionMenus.Items(2).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(2).Visible = True
            End If

            If lU.Item(0).L04 = False Then
                RadPanelBarClasificacionMenus.Items(3).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(3).Visible = True
            End If

            If lU.Item(0).L05 = False Then
                RadPanelBarClasificacionMenus.Items(4).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(4).Visible = True
            End If

            If lU.Item(0).L06 = False Then
                RadPanelBarClasificacionMenus.Items(5).Visible = False
            Else
                RadPanelBarClasificacionMenus.Items(5).Visible = True
            End If

        Else
            RadPanelBarClasificacion.Visible = False
            RadPanelBarClasificacionMenus.Visible = False
        End If
    End Sub
    Public Sub MConfiguracion()
        If lU.Item(0).L07 = True Or lU.Item(0).L08 = True Or lU.Item(0).L09 = True Or lU.Item(0).L10 = True Or lU.Item(0).L11 = True Or lU.Item(0).L12 = True Or lU.Item(0).L13 = True Or lU.Item(0).L14 = True Or lU.Item(0).E07 = True Or lU.Item(0).E10 = True Or lU.Item(0).E11 = True Or lU.Item(0).E12 = True Or lU.Item(0).E14 = True Then
            RadPanelBarConfiguracion.Visible = True

            If lU.Item(0).L07 = False And lU.Item(0).E07 = False Then
                RadPanelBarConfiguracionMenus.Items(0).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(0).Visible = True
            End If

            If lU.Item(0).L08 = False Then
                RadPanelBarConfiguracionMenus.Items(1).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(1).Visible = True
            End If

            If lU.Item(0).L09 = False Then
                RadPanelBarConfiguracionMenus.Items(2).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(2).Visible = True
            End If

            If lU.Item(0).L10 = False And lU.Item(0).E10 = False Then
                RadPanelBarConfiguracionMenus.Items(3).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(3).Visible = True
            End If

            If lU.Item(0).L11 = False And lU.Item(0).E11 = False Then
                RadPanelBarConfiguracionMenus.Items(4).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(4).Visible = True
            End If

            If lU.Item(0).L12 = False And lU.Item(0).E12 = False Then
                RadPanelBarConfiguracionMenus.Items(5).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(5).Visible = True
            End If

            If lU.Item(0).L13 = False And lU.Item(0).E13 = False Then
                RadPanelBarConfiguracionMenus.Items(6).Visible = False
            Else
                RadPanelBarConfiguracionMenus.Items(6).Visible = True
            End If

            'If lU.Item(0).L14 = False And lU.Item(0).E14 = False Then
            '    RadPanelBarConfiguracionMenus.Items(7).Visible = False
            'Else
            '    RadPanelBarConfiguracionMenus.Items(7).Visible = True
            'End If

        Else
            RadPanelBarConfiguracion.Visible = False
            RadPanelBarConfiguracionMenus.Visible = False
        End If

    End Sub
    Public Sub MProcesos()
        If lU.Item(0).E15 = True Or lU.Item(0).E16 = True Or lU.Item(0).E17 = True Or lU.Item(0).E18 = True Or lU.Item(0).E19 = True Or lU.Item(0).E20 = True Or lU.Item(0).E21 = True Or lU.Item(0).E22 = True Or lU.Item(0).E23 = True Or lU.Item(0).E24 = True Or lU.Item(0).E25 = True Or lU.Item(0).E26 = True Or lU.Item(0).L27 = True Then
            RadPanelBarProcesos.Visible = True

            If lU.Item(0).E15 = False And lU.Item(0).E16 = False And lU.Item(0).E17 = False And lU.Item(0).E18 = False And lU.Item(0).E19 = False And lU.Item(0).E20 = False Then
                RadPanelBarProcesosMenus.Items(0).Visible = False
                RadPanelBarProcesosMenus.Items(1).Visible = False
            Else
                RadPanelBarProcesosMenus.Items(0).Visible = True
                RadPanelBarProcesosMenus.Items(1).Visible = True
            End If

            If lU.Item(0).E21 = False And lU.Item(0).E22 = False And lU.Item(0).E23 = False And lU.Item(0).E24 = False And lU.Item(0).E25 = False And lU.Item(0).E26 = False Then
                RadPanelBarProcesosMenus.Items(2).Visible = False
            Else
                RadPanelBarProcesosMenus.Items(2).Visible = True
            End If

            If lU.Item(0).L27 = False Then
                RadPanelBarProcesosMenus.Items(3).Visible = False
            Else
                RadPanelBarProcesosMenus.Items(3).Visible = True
            End If

        Else
            RadPanelBarProcesos.Visible = False
            RadPanelBarProcesosMenus.Visible = False
        End If
    End Sub

    Public ReadOnly Property LabelNombreUsuario() As Label
        Get
            Return Me.lblNombreUsuario
        End Get
    End Property

    Protected Sub RadToolBarCiclosNegocio_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCiclosNegocio.ButtonClick
        'Select Case e.Item.Text
        '    Case "Cuenza"
        '        Response.Redirect("~/PronosticoPrograma.aspx")
        '    Case "Cuenpa"
        '        'Response.Redirect("~/Egresos.aspx")
        '        Response.Redirect("~/PronosticoPrograma.aspx")
        '    Case "Adminsist"
        '        'Response.Redirect("~/EquiposComputo.aspx")
        '        Response.Redirect("~/PronosticoPrograma.aspx")
        'End Select
    End Sub

    Protected Sub RadToolBarCerrar_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCerrar.ButtonClick

        Dim Usuario As String = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        selSql = "SET DATEFORMAT dmy;" _
             & " BEGIN TRAN " _
             & "     " _
             & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Cerró sesión', 0, " & lU.Item(0).id_linea & ")" _
             & "     " _
             & "		IF @@ERROR <> 0  " _
             & "		BEGIN " _
             & "			ROLLBACK " _
             & "			RETURN " _
             & "		END " _
             & "	COMMIT TRANSACTION"
        accessSQL.ExecuteNonQueryD(selSql)
        accessSQL.Close()

        Session("usuario") = Nothing
        Session("nombres") = Nothing
        Session("apellido_paterno") = Nothing
        Session("apellido_materno") = Nothing

        Session("mesI") = Nothing
        Session("añoI") = Nothing
        Session("MesF") = Nothing
        Session("AñoF") = Nothing

        Session("Lineas") = Nothing

        Session("Status1") = Nothing
        Session("Status2") = Nothing
        Session("Status3") = Nothing
        Session("Status4") = Nothing
        Session("TipoFactura1") = Nothing
        Session("TipoFactura2") = Nothing
        Session("TipoFactura3") = Nothing
        Session("TipoFactura4") = Nothing
        Session("TipoFecha") = Nothing

        Session("TipoCambio") = Nothing

        Response.Redirect("~/Login.aspx")

    End Sub

End Class

