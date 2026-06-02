
Imports System.Data
Imports System.Data.SqlClient
Imports System.Net.NetworkInformation

Imports Domain
Imports UsuariosBL

Imports Telerik.Web.UI

Partial Class ClientesAgregar
    Inherits System.Web.UI.Page

#Region "Variables"

    Public lU As New List(Of IUsuario)
    Shared Usuario As String

    Public oUsu As New UsuariosBL.UsuariosBL
    Public oCli As New ClientesBL.ClientesBL

    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, id_servicio, id_cliente As Integer

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

                RadNumericTextBoxIVA.Text = "16.00"

                If Not Session("id_cliente_act") Is Nothing Then
                    If Session("id_cliente_act") > 0 Then
                        RadTextBoxClave.Text = Session("id_cliente_act")
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

        LabelTitulo.Text = IIf(RadTextBoxClave.Text = 0, "Agregar Cliente", "Modificar Cliente")

        v_DataTable = New DataTable
        v_DataTable = oCli.ExtraerClientesTodoIdBL(v_DataTable, RadTextBoxClave.Text)

        ' id_cliente | nombre_cliente | RFC | Calle_numero | Colonia | CP | Ciudad | Estado | Telefono | contacto_facturacuon | otro_contacto | ss | IVA

        RadTextBoxNombre.Text = v_DataTable.Rows(0).Item("nombre_cliente")
        RadTextBoxRFC.Text = v_DataTable.Rows(0).Item("RFC")
        RadTextBoxCalleNumero.Text = v_DataTable.Rows(0).Item("Calle_numero")
        RadTextBoxColonia.Text = v_DataTable.Rows(0).Item("Colonia")
        RadTextBoxCP.Text = v_DataTable.Rows(0).Item("CP")
        RadNumericTextBoxIVA.Text = v_DataTable.Rows(0).Item("IVA")
        RadTextBoxCiudad.Text = v_DataTable.Rows(0).Item("Ciudad")
        RadTextBoxEstado.Text = v_DataTable.Rows(0).Item("Estado")
        RadTextBoxTelefono.Text = v_DataTable.Rows(0).Item("Telefono")
        RadTextBoxContacto.Text = v_DataTable.Rows(0).Item("contacto_facturacuon")
        RadTextBoxOtroContacto.Text = v_DataTable.Rows(0).Item("otro_contacto")

    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        Select Case e.Item.Text
            Case "Enviar"
                If RadTextBoxClave.Text = 0 Then
                    AgregarCliente()
                Else
                    ModificarCliente()
                End If
            Case "Cancelar"
                Response.Redirect("~/Clientes.aspx")
        End Select

    End Sub

    Public Sub AgregarCliente()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim vNombre As String = Trim(RadTextBoxNombre.Text)
            Dim vRFC As String = Trim(RadTextBoxRFC.Text)
            Dim vCalleN As String = Trim(RadTextBoxCalleNumero.Text)
            Dim vColonia As String = Trim(RadTextBoxColonia.Text)
            Dim vCP As String = Trim(RadTextBoxCP.Text)
            Dim vIVA As Decimal = RadNumericTextBoxIVA.Text
            Dim vCiudad As String = Trim(RadTextBoxCiudad.Text)
            Dim vEstado As String = Trim(RadTextBoxEstado.Text)
            Dim vTelefono As String = Trim(RadTextBoxTelefono.Text)
            Dim vContacto As String = Trim(RadTextBoxContacto.Text)
            Dim vOtroCon As String = Trim(RadTextBoxOtroContacto.Text)

            ' vNombre | vRFC | vCalleN | vColonia | vCP | vCiudad | vEstado | vTelefono | vContacto | vOtroCon | vIVA

            ' Validar que se capturaron todos los datos
            If vNombre = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If vRFC = "" Then
                scriptString = "alert('Favor de capturar el RFC.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxRFC.Focus()
                Exit Sub
            End If

            If vCalleN = "" Then
                scriptString = "alert('Favor de capturar la Calle y Número.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCalleNumero.Focus()
                Exit Sub
            End If

            If vColonia = "" Then
                scriptString = "alert('Favor de capturar la Colonia.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxColonia.Focus()
                Exit Sub
            End If

            If vCP = "" Then
                scriptString = "alert('Favor de capturar el Código Postal.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCP.Focus()
                Exit Sub
            End If

            If vIVA = 0 Then
                scriptString = "alert('Favor de capturar el IVA.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxIVA.Focus()
                Exit Sub
            End If

            If vCiudad = "" Then
                scriptString = "alert('Favor de capturar la Ciudad.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCiudad.Focus()
                Exit Sub
            End If

            If vEstado = "" Then
                scriptString = "alert('Favor de capturar el Estado.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxEstado.Focus()
                Exit Sub
            End If

            If vTelefono = "" Then
                scriptString = "alert('Favor de capturar el Teléfono.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxTelefono.Focus()
                Exit Sub
            End If

            If vContacto = "" Then
                scriptString = "alert('Favor de capturar el Contacto Facturación.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxContacto.Focus()
                Exit Sub
            End If

            If vOtroCon = "" Then
                scriptString = "alert('Favor de capturar el Otro Contacto.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxOtroContacto.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Cliente (mismo nombre_cliente)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_cliente) " _
                  & " FROM Clientes " _
                  & " WHERE nombre_cliente = '" & vNombre & "' " _
                  & "   AND RFC = '" & vRFC & "' " _
                  & "   AND Calle_numero = '" & vCalleN & "' " _
                  & "   AND Colonia = '" & vColonia & "' " _
                  & "   AND CP = '" & vCP & "' " _
                  & "   AND Ciudad = '" & vCiudad & "' " _
                  & "   AND Estado = '" & vEstado & "' "
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Cliente capturado ya existe, favor de capturar otro Nombre, RFC, Calle y Número, Colonia, Código Postal, Ciudad y/o Estado.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Insertar información en tablas de la base de datos
            '--------------------------------------------------------------------------------
            ' vNombre | vRFC | vCalleN | vColonia | vCP | vCiudad | vEstado | vTelefono | vContacto | vOtroCon | vIVA
            ' id_cliente | nombre_cliente | RFC | Calle_numero | Colonia | CP | Ciudad | Estado | Telefono | contacto_facturacuon | otro_contacto | ss | IVA
            selSql = "SET DATEFORMAT dmy;" _
                & " BEGIN TRAN " _
                & "     " _
                & "     INSERT INTO Clientes VALUES ( " _
                & "	               '" & vNombre & "' " _
                & "	             , '" & vRFC & "' " _
                & "	             , '" & vCalleN & "' " _
                & "	             , '" & vColonia & "' " _
                & "	             , '" & vCP & "' " _
                & "	             , '" & vCiudad & "' " _
                & "	             , '" & vEstado & "' " _
                & "	             , '" & vTelefono & "' " _
                & "	             , '" & vContacto & "' " _
                & "	             , '" & vOtroCon & "' " _
                & "	             , 1 " _
                & "	             , " & vIVA & "); " _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Agregó Cliente', 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            scriptString = "alert('Cliente agregado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Clientes.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar enviar el Cliente. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Clientes.aspx")
        End Try

    End Sub
    Public Sub ModificarCliente()

        Dim vError As String = ""
        Dim scriptString As String = ""
        Dim accessSQL As New DataAccess.SQL
        Dim selSql As String = ""

        Try

            Dim v_id_selec As Integer = RadTextBoxClave.Text

            Dim vNombre As String = Trim(RadTextBoxNombre.Text)
            Dim vRFC As String = Trim(RadTextBoxRFC.Text)
            Dim vCalleN As String = Trim(RadTextBoxCalleNumero.Text)
            Dim vColonia As String = Trim(RadTextBoxColonia.Text)
            Dim vCP As String = Trim(RadTextBoxCP.Text)
            Dim vIVA As Decimal = RadNumericTextBoxIVA.Text
            Dim vCiudad As String = Trim(RadTextBoxCiudad.Text)
            Dim vEstado As String = Trim(RadTextBoxEstado.Text)
            Dim vTelefono As String = Trim(RadTextBoxTelefono.Text)
            Dim vContacto As String = Trim(RadTextBoxContacto.Text)
            Dim vOtroCon As String = Trim(RadTextBoxOtroContacto.Text)

            ' vNombre | vRFC | vCalleN | vColonia | vCP | vCiudad | vEstado | vTelefono | vContacto | vOtroCon | vIVA

            ' Validar que se capturaron todos los datos
            If vNombre = "" Then
                scriptString = "alert('Favor de capturar el Nombre.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxNombre.Focus()
                Exit Sub
            End If

            If vRFC = "" Then
                scriptString = "alert('Favor de capturar el RFC.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxRFC.Focus()
                Exit Sub
            End If

            If vCalleN = "" Then
                scriptString = "alert('Favor de capturar la Calle y Número.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCalleNumero.Focus()
                Exit Sub
            End If

            If vColonia = "" Then
                scriptString = "alert('Favor de capturar la Colonia.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxColonia.Focus()
                Exit Sub
            End If

            If vCP = "" Then
                scriptString = "alert('Favor de capturar el Código Postal.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCP.Focus()
                Exit Sub
            End If

            If vIVA = 0 Then
                scriptString = "alert('Favor de capturar el IVA.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadNumericTextBoxIVA.Focus()
                Exit Sub
            End If

            If vCiudad = "" Then
                scriptString = "alert('Favor de capturar la Ciudad.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxCiudad.Focus()
                Exit Sub
            End If

            If vEstado = "" Then
                scriptString = "alert('Favor de capturar el Estado.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxEstado.Focus()
                Exit Sub
            End If

            If vTelefono = "" Then
                scriptString = "alert('Favor de capturar el Teléfono.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxTelefono.Focus()
                Exit Sub
            End If

            If vContacto = "" Then
                scriptString = "alert('Favor de capturar el Contacto Facturación.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxContacto.Focus()
                Exit Sub
            End If

            If vOtroCon = "" Then
                scriptString = "alert('Favor de capturar el Otro Contacto.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                RadTextBoxOtroContacto.Focus()
                Exit Sub
            End If

            '--------------------------------------------------------------------------------
            ' Validar si ya existe el Cliente (mismo nombre_cliente)
            '--------------------------------------------------------------------------------
            selSql = "SELECT Totales = COUNT(id_cliente) " _
                  & " FROM Clientes " _
                  & " WHERE id_cliente <> " & v_id_selec & " " _
                  & "   AND nombre_cliente = '" & vNombre & "' " _
                  & "   AND RFC = '" & vRFC & "' " _
                  & "   AND Calle_numero = '" & vCalleN & "' " _
                  & "   AND Colonia = '" & vColonia & "' " _
                  & "   AND CP = '" & vCP & "' " _
                  & "   AND Ciudad = '" & vCiudad & "' " _
                  & "   AND Estado = '" & vEstado & "' "
            Dim vDataTable As New DataTable
            vDataTable = accessSQL.DataTableFill(selSql)
            accessSQL.Close()
            If vDataTable.Rows(0).Item(0) = 1 Then
                scriptString = "alert('El Cliente capturado ya existe, favor de capturar otro Nombre, RFC, Calle y Número, Colonia, Código Postal, Ciudad y/o Estado.');"
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
                & "     UPDATE Clientes SET " _
                & "	           nombre_cliente = '" & vNombre & "' " _
                & "	         , RFC = '" & vRFC & "' " _
                & "	         , Calle_numero = '" & vCalleN & "' " _
                & "	         , Colonia = '" & vColonia & "' " _
                & "	         , CP = '" & vCP & "' " _
                & "	         , Ciudad = '" & vCiudad & "' " _
                & "	         , Estado = '" & vEstado & "' " _
                & "	         , Telefono = '" & vTelefono & "' " _
                & "	         , contacto_facturacuon = '" & vContacto & "' " _
                & "	         , otro_contacto = '" & vOtroCon & "' " _
                & "	         , IVA = " & vIVA & " " _
                & "	    WHERE id_cliente = " & v_id_selec _
                & "     " _
                & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Actualizó Cliente ID ' + '" & v_id_selec & "' , 0, 0)" _
                & "     " _
                & "		IF @@ERROR <> 0  " _
                & "		BEGIN " _
                & "			ROLLBACK " _
                & "			RETURN " _
                & "		END " _
                & "	COMMIT TRANSACTION"
            accessSQL.ExecuteNonQueryD(selSql)
            accessSQL.Close()

            ' vNombre | vRFC | vCalleN | vColonia | vCP | vCiudad | vEstado | vTelefono | vContacto | vOtroCon | vIVA
            ' id_cliente | nombre_cliente | RFC | Calle_numero | Colonia | CP | Ciudad | Estado | Telefono | contacto_facturacuon | otro_contacto | ss | IVA

            scriptString = "alert('Cliente actualizado correctamente.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)

            Response.Redirect("~/Clientes.aspx")

        Catch ex As Exception
            accessSQL.Close()
            scriptString = "alert('Error al intentar actualizar el Cliente seleccionado. \n\n " & ex.Message & " \n\n " & vError & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Response.Redirect("~/Clientes.aspx")
        End Try

    End Sub

End Class
