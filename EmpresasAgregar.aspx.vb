
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Imports Domain
Imports UsuariosBL

Imports Telerik.Web.UI

Partial Class EmpresasAgregar
    Inherits System.Web.UI.Page

#Region "Variables"

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oUsu As New UsuariosBL.UsuariosBL
    Public oEmp As New EmpresasBL.EmpresasBL
    'Public oSer As New ServiciosBL.ServiciosBL
    'Public oRol As New TiposRolBL.TiposRolBL

    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, id_servicio, id_empresa As Integer

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

                If Not Session("id_empresa_act") Is Nothing Then
                    If Session("id_empresa_act") > 0 Then
                        RadTextBoxClave.Text = Session("id_empresa_act")
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

        LabelTitulo.Text = IIf(RadTextBoxClave.Text = 0, "Agregar ¿Quién Factura?", "Modificar ¿Quién Factura?")

        v_DataTable = New DataTable
        v_DataTable = oEmp.ExtraerEmpresasTodoIdBL(v_DataTable, RadTextBoxClave.Text)

        RadTextBoxNombre.Text = v_DataTable.Rows(0).Item("nombre_empresa")

    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                If RadTextBoxClave.Text = 0 Then
                    AgregarEmpresa()
                Else
                    ModificarEmpresa()
                End If
            Case "Cancelar"
                Response.Redirect("~/Empresas.aspx")
        End Select

    End Sub

    Public Sub AgregarEmpresa()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe la Empresa (mismo nombre_empresa)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_empresa) FROM Empresas WHERE nombre_empresa = '" & RadTextBoxNombre.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('La Empresa capturada ya existe, favor de capturar otro Nombre.');"
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
                & "     INSERT INTO Empresas VALUES ( " _
                & "	               '" & RadTextBoxNombre.Text & "' " _
                & "	               , 2, 1); " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó Empresa', 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Empresa agregada correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Empresas.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar enviar la Empresa. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Empresas.aspx")
        End Try

    End Sub
    Public Sub ModificarEmpresa()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_selec As Integer = RadTextBoxClave.Text

            ' Validar que se capturaron todos los datos
            If RadTextBoxNombre.Text = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe la Empresa (mismo nombre_empresa)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_empresa) FROM Empresas WHERE id_empresa <> " & v_id_selec & " AND nombre_empresa = '" & RadTextBoxNombre.Text & "'"
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('La Empresa capturada ya existe, favor de capturar otro Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Actualizar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     UPDATE Empresas SET " _
                & "	           nombre_empresa = '" & RadTextBoxNombre.Text & "' " _
                & "	    WHERE id_empresa = " & v_id_selec _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Actualizó Quién Factura ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Quién Factura actualizado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Empresas.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar actualizar Quién Factura seleccionado. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Empresas.aspx")
        End Try

    End Sub

End Class
