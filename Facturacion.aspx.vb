
Imports System.IO
Imports Domain
Imports UsuariosBL
Imports FacturacionBL
'Imports ClientesBL
Imports LineasServicioBL
'Imports IngresosBL
'Imports IngresosPagosBL
Imports BitacoraBL
'Imports EmpresasBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder


Partial Class Facturacion
    Inherits System.Web.UI.Page

#Region "Variables"

    Shared vLinea As String = ""
    Shared vImporte As Decimal
    Shared vIva As Decimal
    Shared vTotal As Decimal
    Shared vVencido As Decimal
    Shared vPorVencer As Decimal
    'Shared vRowA As Integer
    Shared vRowT As Integer
    
    Public vRowIn As Integer = 0

    Public vTitulo As Integer
    Private isConfigured As Boolean = False

    Public lU As New List(Of IUsuario)

    Shared mes, año, mes2, año2 As Integer
    Shared Usuario As String

    Public oCli As New ClientesBL.ClientesBL
    Public oFac As New FacturacionBL.FacturacionBL
    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public oIng As New IngresosBL.IngresosBL
    Public oInP As New IngresosPagosBL.IngresosPagosBL
    Public oBit As New BitacoraBL.BitacoraBL
    Public oEmp As New EmpresasBL.EmpresasBL
    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, mesI, añoI, mesF, añoF As Integer
    Shared FToday As Date = Today()
    Shared Fini As Date
    Shared Ffin As Date
    'Shared Empresa1 As Integer
    'Shared Empresa2 As Integer
    'Shared Empresa3 As Integer
    'Shared Empresas As String
    Shared Status1 As Integer
    Shared Status2 As Integer
    Shared Status3 As Integer
    Shared Status4 As Integer
    Shared Status5 As Integer
    Shared Status6 As Integer
    Shared Status7 As Integer
    Shared Status8 As Integer
    Shared Status9 As Integer

    Shared TipoFactura1 As Integer
    Shared TipoFactura2 As Integer
    Shared TipoFactura3 As Integer
    Shared TipoFactura4 As Integer
    Shared TipoFecha As String
    Shared Lineas As String
    'Shared TipoFechaSort As String
    'Shared TipoCambio As Decimal
    Shared v_linea_actual As Integer

    'Dim Num2Text As String = ""
    'Dim v_unidades_int As Integer
    'Dim v_unidades_str As String = ""
    'Dim v_decenas_int As Integer
    'Dim v_decenas_str As String = ""
    'Dim v_centenas_int As Integer
    'Dim v_centenas_str As String = ""
    'Dim v_miles_int As Integer
    'Dim v_miles_str As String = ""
    'Dim v_unmiles_int As Integer
    'Dim v_unmiles_str As String = ""
    'Dim v_dosmiles_int As Integer
    'Dim v_dosmiles_str As String = ""

    Shared id_ls_1, id_ls_2, id_ls_3, id_ls_4, id_ls_5, id_ls_6, id_ls_7, id_ls_8, id_ls_9, id_ls_10 As Integer
    Shared id_ls_11, id_ls_12, id_ls_13, id_ls_14, id_ls_15, id_ls_16, id_ls_17, id_ls_18, id_ls_19, id_ls_20 As Integer
    Shared id_ls_21, id_ls_22, id_ls_23, id_ls_24, id_ls_25, id_ls_26, id_ls_27, id_ls_28, id_ls_29, id_ls_30 As Integer

    Shared Fini_f, Ffin_f, Fini_p, Ffin_p As String

#End Region

    Public Enum Meses
        Enero = 1
        Febrero = 2
        Marzo = 3
        Abril = 4
        Mayo = 5
        Junio = 6
        Julio = 7
        Agosto = 8
        Septiembre = 9
        Octubre = 10
        Noviembre = 11
        Diciembre = 12
        'Ninguno = 13
    End Enum

    Public Sub IniciaVariables()

        If id_rol > 2 Then
            RadGridLineas.Visible = False
            Lineas = "AND Ingresos.id_linea_servicio = " & id_linea_servicio
        Else
            RadGridLineas.Visible = True
        End If

        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        If Not Session("mesI") Is Nothing Then
            mesI = Session("mesI")
        Else
            mesI = 0
        End If
        If Not Session("añoI") Is Nothing Then
            añoI = Session("añoI")
        Else
            añoI = 0
        End If
        If mesI = 0 And añoI = 0 Then
            mesI = Month(Today)
            añoI = Year(Today)
        End If
        RCBMesI.SelectedIndex = mesI - 1
        RCBAñoI.SelectedIndex = añoI - 2008
        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        If Not Session("MesF") Is Nothing Then
            mesF = Session("MesF")
        Else
            mesF = 0
        End If
        If Not Session("AñoF") Is Nothing Then
            añoF = Session("AñoF")
        Else
            añoF = 0
        End If
        If mesF = 0 And añoF = 0 Then
            mesF = Month(Today)
            añoF = Year(Today)
        End If
        RCBMesF.SelectedIndex = mesF - 1
        RCBAñoF.SelectedIndex = añoF - 2008
        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        'CBEmpresa1.Checked = False
        'CBEmpresa2.Checked = True
        'CBEmpresa3.Checked = True

        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        FToday = Today()
        Fini = CType("01/" & mesI & "/" & añoI, Date)
        Ffin = CType(System.DateTime.DaysInMonth(RCBAñoF.SelectedValue, mesF) & "/" & mesF & "/" & añoF, Date)

        If Not Session("Status1") Is Nothing Then

            Status1 = Session("Status1")
            Status2 = Session("Status2")
            Status3 = Session("Status3")
            Status4 = Session("Status4")
            Status5 = Session("Status5")
            Status6 = Session("Status6")
            Status7 = Session("Status7")
            Status8 = Session("Status8")
            Status9 = Session("Status9")

            TipoFactura1 = Session("TipoFactura1")
            TipoFactura2 = Session("TipoFactura2")
            TipoFactura3 = Session("TipoFactura3")
            TipoFactura4 = Session("TipoFactura4")

            TipoFecha = Session("TipoFecha")

            CBStatus1.Checked = IIf(Status1 > 0, True, False)
            CBStatus2.Checked = IIf(Status2 > 0, True, False)
            CBStatus3.Checked = IIf(Status3 > 0, True, False)
            CBStatus4.Checked = IIf(Status4 > 0 Or Status5 > 0 Or Status6 > 0 Or Status7 > 0 Or Status8 > 0 Or Status9 > 0, True, False)

            CBTipoFactura1.Checked = IIf(TipoFactura1 > 0, True, False)
            CBTipoFactura2.Checked = IIf(TipoFactura2 > 0, True, False)
            CBTipoFactura3.Checked = IIf(TipoFactura3 > 0, True, False)
            CBTipoFactura4.Checked = IIf(TipoFactura4 > 0, True, False)

            CBTipoFecha1.Checked = IIf(TipoFecha = "fecha_fact", True, False)
            CBTipoFecha2.Checked = IIf(TipoFecha = "fecha_pago", True, False)

            Fini_f = IIf(TipoFecha = "fecha_fact", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            Ffin_f = IIf(TipoFecha = "fecha_fact", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")
            Fini_p = IIf(TipoFecha = "fecha_pago", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            Ffin_p = IIf(TipoFecha = "fecha_pago", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")

        Else

            Status1 = 1
            Status2 = 2
            Status3 = 3
            Status4 = 0
            Status5 = 0
            Status6 = 0
            Status7 = 0
            Status8 = 0
            Status9 = 0

            TipoFactura1 = 1
            TipoFactura2 = 2
            TipoFactura3 = 3
            TipoFactura4 = 0
            TipoFecha = "fecha_fact"

            CBStatus1.Checked = True
            CBStatus2.Checked = True
            CBStatus3.Checked = True
            CBStatus4.Checked = False
            CBTipoFactura1.Checked = True
            CBTipoFactura2.Checked = True
            CBTipoFactura3.Checked = True
            CBTipoFactura4.Checked = False
            CBTipoFecha1.Checked = True
            CBTipoFecha2.Checked = False

            Fini_f = Format(Fini, "dd/MM/yyyy")
            Ffin_f = Format(Ffin, "dd/MM/yyyy")
            Fini_p = "01/01/1900"
            Ffin_p = "01/01/1900"

        End If

        lblStatus.Text = "Facturas de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue
        lblMensaje.Text = ""

    End Sub
    Public Sub LineasS()
        If id_rol = 1 Or id_rol = 2 Then

            'Líneas de servicio
            Dim f_rg As Integer = 0
            Dim f_1 As Integer = 0

            'If Lineas Is Nothing Then
            Lineas = "AND ("
            LimpiarLineas()

            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                Dim v_linea_actual As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))
                Dim item_Check As Integer = CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked
                If item_Check <> 0 Then
                    Dim v_or As String = IIf(f_rg > 0, " OR ", "")
                    f_rg = f_rg + 1
                    Lineas = Lineas & v_or & " Ingresos.id_linea_servicio = " & v_linea_actual

                    AsignarLinea(v_linea_actual)

                End If
            Next

            Lineas = Lineas & ")"

        Else
            LimpiarLineas()
            id_ls_1 = id_linea_servicio
        End If

        'Return Lineas
    End Sub
    Public Sub LineasS_2()
        If id_rol = 1 Or id_rol = 2 Then

            'Líneas de servicio
            Dim f_rg As Integer = 0
            Dim f_1 As Integer = 0

            LimpiarLineas()

            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = False
            Next

            Dim strcadena() As String
            strcadena = Split(Lineas, "OR")

            For f_1 = 0 To strcadena.Length - 1
                Dim vLineaAct As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Right(strcadena(f_1), 3))

                For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                    Dim v_linea_actual As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))

                    If v_linea_actual = vLineaAct Then
                        CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = True
                        AsignarLinea(v_linea_actual)
                        Exit For
                    End If
                Next

            Next

        Else
            LimpiarLineas()
            id_ls_1 = id_linea_servicio
        End If

        'Return Lineas
    End Sub
    Public Sub LimpiarLineas()
        id_ls_1 = -1
        id_ls_2 = -1
        id_ls_3 = -1
        id_ls_4 = -1
        id_ls_5 = -1
        id_ls_6 = -1
        id_ls_7 = -1
        id_ls_8 = -1
        id_ls_9 = -1
        id_ls_10 = -1
        id_ls_11 = -1
        id_ls_12 = -1
        id_ls_13 = -1
        id_ls_14 = -1
        id_ls_15 = -1
        id_ls_16 = -1
        id_ls_17 = -1
        id_ls_18 = -1
        id_ls_19 = -1
        id_ls_20 = -1
        id_ls_21 = -1
        id_ls_22 = -1
        id_ls_23 = -1
        id_ls_24 = -1
        id_ls_25 = -1
        id_ls_26 = -1
        id_ls_27 = -1
        id_ls_28 = -1
        id_ls_29 = -1
        id_ls_30 = -1
    End Sub
    Public Sub AsignarLinea(ByVal v_linea_actual As Integer)

        If id_ls_1 = -1 Then
            id_ls_1 = v_linea_actual
        ElseIf id_ls_2 = -1 Then
            id_ls_2 = v_linea_actual
        ElseIf id_ls_3 = -1 Then
            id_ls_3 = v_linea_actual
        ElseIf id_ls_4 = -1 Then
            id_ls_4 = v_linea_actual
        ElseIf id_ls_5 = -1 Then
            id_ls_5 = v_linea_actual
        ElseIf id_ls_6 = -1 Then
            id_ls_6 = v_linea_actual
        ElseIf id_ls_7 = -1 Then
            id_ls_7 = v_linea_actual
        ElseIf id_ls_8 = -1 Then
            id_ls_8 = v_linea_actual
        ElseIf id_ls_9 = -1 Then
            id_ls_9 = v_linea_actual
        ElseIf id_ls_10 = -1 Then
            id_ls_10 = v_linea_actual
        ElseIf id_ls_11 = -1 Then
            id_ls_11 = v_linea_actual
        ElseIf id_ls_12 = -1 Then
            id_ls_12 = v_linea_actual
        ElseIf id_ls_13 = -1 Then
            id_ls_13 = v_linea_actual
        ElseIf id_ls_14 = -1 Then
            id_ls_14 = v_linea_actual
        ElseIf id_ls_15 = -1 Then
            id_ls_15 = v_linea_actual
        ElseIf id_ls_16 = -1 Then
            id_ls_16 = v_linea_actual
        ElseIf id_ls_17 = -1 Then
            id_ls_17 = v_linea_actual
        ElseIf id_ls_18 = -1 Then
            id_ls_18 = v_linea_actual
        ElseIf id_ls_19 = -1 Then
            id_ls_19 = v_linea_actual
        ElseIf id_ls_20 = -1 Then
            id_ls_20 = v_linea_actual
        ElseIf id_ls_21 = -1 Then
            id_ls_21 = v_linea_actual
        ElseIf id_ls_22 = -1 Then
            id_ls_22 = v_linea_actual
        ElseIf id_ls_23 = -1 Then
            id_ls_23 = v_linea_actual
        ElseIf id_ls_24 = -1 Then
            id_ls_24 = v_linea_actual
        ElseIf id_ls_25 = -1 Then
            id_ls_25 = v_linea_actual
        ElseIf id_ls_26 = -1 Then
            id_ls_26 = v_linea_actual
        ElseIf id_ls_27 = -1 Then
            id_ls_27 = v_linea_actual
        ElseIf id_ls_28 = -1 Then
            id_ls_28 = v_linea_actual
        ElseIf id_ls_29 = -1 Then
            id_ls_29 = v_linea_actual
        ElseIf id_ls_30 = -1 Then
            id_ls_30 = v_linea_actual
        End If

    End Sub

    Public Sub ActualizarSqlDataSource1()

        SqlDataSource1.SelectParameters("id_ls_1").DefaultValue = id_ls_1
        SqlDataSource1.SelectParameters("id_ls_2").DefaultValue = id_ls_2
        SqlDataSource1.SelectParameters("id_ls_3").DefaultValue = id_ls_3
        SqlDataSource1.SelectParameters("id_ls_4").DefaultValue = id_ls_4
        SqlDataSource1.SelectParameters("id_ls_5").DefaultValue = id_ls_5
        SqlDataSource1.SelectParameters("id_ls_6").DefaultValue = id_ls_6
        SqlDataSource1.SelectParameters("id_ls_7").DefaultValue = id_ls_7
        SqlDataSource1.SelectParameters("id_ls_8").DefaultValue = id_ls_8
        SqlDataSource1.SelectParameters("id_ls_9").DefaultValue = id_ls_9
        SqlDataSource1.SelectParameters("id_ls_10").DefaultValue = id_ls_10
        SqlDataSource1.SelectParameters("id_ls_11").DefaultValue = id_ls_11
        SqlDataSource1.SelectParameters("id_ls_12").DefaultValue = id_ls_12
        SqlDataSource1.SelectParameters("id_ls_13").DefaultValue = id_ls_13
        SqlDataSource1.SelectParameters("id_ls_14").DefaultValue = id_ls_14
        SqlDataSource1.SelectParameters("id_ls_15").DefaultValue = id_ls_15
        SqlDataSource1.SelectParameters("id_ls_16").DefaultValue = id_ls_16
        SqlDataSource1.SelectParameters("id_ls_17").DefaultValue = id_ls_17
        SqlDataSource1.SelectParameters("id_ls_18").DefaultValue = id_ls_18
        SqlDataSource1.SelectParameters("id_ls_19").DefaultValue = id_ls_19
        SqlDataSource1.SelectParameters("id_ls_20").DefaultValue = id_ls_20
        SqlDataSource1.SelectParameters("id_ls_21").DefaultValue = id_ls_21
        SqlDataSource1.SelectParameters("id_ls_22").DefaultValue = id_ls_22
        SqlDataSource1.SelectParameters("id_ls_23").DefaultValue = id_ls_23
        SqlDataSource1.SelectParameters("id_ls_24").DefaultValue = id_ls_24
        SqlDataSource1.SelectParameters("id_ls_25").DefaultValue = id_ls_25
        SqlDataSource1.SelectParameters("id_ls_26").DefaultValue = id_ls_26
        SqlDataSource1.SelectParameters("id_ls_27").DefaultValue = id_ls_27
        SqlDataSource1.SelectParameters("id_ls_28").DefaultValue = id_ls_28
        SqlDataSource1.SelectParameters("id_ls_29").DefaultValue = id_ls_29
        SqlDataSource1.SelectParameters("id_ls_30").DefaultValue = id_ls_30

        SqlDataSource1.SelectParameters("Fini_f").DefaultValue = Fini_f ' "01/06/2014" ' "01/05/2008"
        SqlDataSource1.SelectParameters("Ffin_f").DefaultValue = Ffin_f ' "30/06/2014" ' "31/12/2008"
        SqlDataSource1.SelectParameters("Fini_p").DefaultValue = Fini_p ' "01/01/1900" ' "01/05/2008"
        SqlDataSource1.SelectParameters("Ffin_p").DefaultValue = Ffin_p ' "01/01/1900" ' "31/12/2008"

        SqlDataSource1.SelectParameters("Status1").DefaultValue = Status1
        SqlDataSource1.SelectParameters("Status2").DefaultValue = Status2
        SqlDataSource1.SelectParameters("Status3").DefaultValue = Status3
        SqlDataSource1.SelectParameters("Status4").DefaultValue = Status4
        SqlDataSource1.SelectParameters("Status5").DefaultValue = Status5
        SqlDataSource1.SelectParameters("Status6").DefaultValue = Status6
        SqlDataSource1.SelectParameters("Status7").DefaultValue = Status7
        SqlDataSource1.SelectParameters("Status8").DefaultValue = Status8
        SqlDataSource1.SelectParameters("Status9").DefaultValue = Status9

        SqlDataSource1.SelectParameters("TipoFactura1").DefaultValue = TipoFactura1
        SqlDataSource1.SelectParameters("TipoFactura2").DefaultValue = TipoFactura2
        SqlDataSource1.SelectParameters("TipoFactura3").DefaultValue = TipoFactura3
        SqlDataSource1.SelectParameters("TipoFactura4").DefaultValue = TipoFactura4

        SqlDataSource1.SelectParameters("TipoCambio").DefaultValue = TBTipoCambio.Text
        
        SqlDataSource1.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            vLinea = ""
            vImporte = 0
            vIva = 0
            vTotal = 0
            vVencido = 0
            vPorVencer = 0
            'vRowA = 0
            vRowT = 0

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                'Usuario = Session("nombres") & " " & Session("apellido_paterno") & " " & Session("apellido_materno")
                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                IniciaVariables()

                If Not Session("vTipoCambio") Is Nothing Then
                    TBTipoCambio.Text = Session("vTipoCambio")
                Else
                    TBTipoCambio.Text = 13.5
                End If

                v_DataTable = New DataTable
                v_DataTable = oLiS.ExtraerLineasSBL(v_DataTable)

                RadGridLineas.DataSource = v_DataTable
                RadGridLineas.DataBind()

                If Not Session("Lineas") Is Nothing Then
                    Lineas = Session("Lineas")
                    LineasS_2()
                Else
                    Session("Lineas") = Lineas
                    LineasS()
                End If

                ActualizarSqlDataSource1()
                'vRowT = RadGrid1.Items.Count + 6

            Else
                Response.Redirect("~/Login.aspx")
            End If

        End If
    End Sub

    Protected Sub RadToolBarMostrar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarMostrar.ButtonClick

        lblMensaje.Text = ""

        ' Validar mes inicial con mes final
        mesI = [Enum].Parse(GetType(Meses), RCBMesI.SelectedValue)
        Fini = CType("01/" & mesI & "/" & RCBAñoI.SelectedValue, Date)
        mesF = [Enum].Parse(GetType(Meses), RCBMesF.SelectedValue)
        Ffin = CType(System.DateTime.DaysInMonth(RCBAñoF.SelectedValue, mesF) & "/" & mesF & "/" & RCBAñoF.SelectedValue, Date)

        If Fini > Ffin Then
            lblMensaje.Text = "El Rango Inicial no puede ser mayor al Rango Final"
            Exit Sub
        End If

        'If Empresa1 = 0 And Empresa2 = 0 And Empresa3 = 0 Then
        '    'Response.Write("<script>alert('Seleccionar empresa')</script>")
        '    lblMensaje.Text = "Favor de seleccionar por lo menos una Empresa"
        '    Exit Sub
        'End If

        If Status1 = 0 And Status2 = 0 And Status3 = 0 And Status4 = 0 Then
            lblMensaje.Text = "Favor de seleccionar por lo menos un Status"
            Exit Sub
        End If

        If TipoFactura1 = 0 And TipoFactura2 = 0 And TipoFactura3 = 0 And TipoFactura4 = 0 Then
            lblMensaje.Text = "Favor de seleccionar por lo menos un Tipo de Factura"
            Exit Sub
        End If

        LineasS()
        If Lineas = "" Or Lineas = "AND ()" Then
            lblMensaje.Text = "Favor de seleccionar por lo menos una Línea de Servicio"
            Exit Sub
        End If

        Session("mesI") = mesI
        Session("añoI") = RCBAñoI.SelectedValue
        Session("MesF") = mesF
        Session("AñoF") = RCBAñoF.SelectedValue
        Session("Lineas") = Lineas

        Session("Status1") = Status1
        Session("Status2") = Status2
        Session("Status3") = Status3
        Session("Status4") = Status4
        Session("Status5") = Status5
        Session("Status6") = Status6
        Session("Status7") = Status7
        Session("Status8") = Status8
        Session("Status9") = Status9

        Session("TipoFactura1") = TipoFactura1
        Session("TipoFactura2") = TipoFactura2
        Session("TipoFactura3") = TipoFactura3
        Session("TipoFactura4") = TipoFactura4
        Session("TipoFecha") = TipoFecha

        mes = mesI
        año = RCBAñoI.SelectedValue
        añoI = año
        mes2 = mesF
        año2 = RCBAñoF.SelectedValue
        añoF = año2

        Fini_f = IIf(TipoFecha = "fecha_fact", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
        Ffin_f = IIf(TipoFecha = "fecha_fact", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")
        Fini_p = IIf(TipoFecha = "fecha_pago", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
        Ffin_p = IIf(TipoFecha = "fecha_pago", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")

        vLinea = ""
        vImporte = 0
        vIva = 0
        vTotal = 0
        vVencido = 0
        vPorVencer = 0
        'vRowA = 0
        vRowT = 0

        Session("vTipoCambio") = TBTipoCambio.Text

        ActualizarSqlDataSource1()
        lblStatus.Text = "Facturas de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue
        'vRowT = RadGrid1.Items.Count + 6

    End Sub

    Protected Sub CBStatus1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBStatus1.CheckedChanged
        If CBStatus1.Checked = True Then
            Status1 = 1
        Else
            Status1 = 0
        End If
    End Sub
    Protected Sub CBStatus2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBStatus2.CheckedChanged
        If CBStatus2.Checked = True Then
            Status2 = 2
        Else
            Status2 = 0
        End If
    End Sub
    Protected Sub CBStatus3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBStatus3.CheckedChanged
        If CBStatus3.Checked = True Then
            Status3 = 3
        Else
            Status3 = 0
        End If
    End Sub
    Protected Sub CBStatus4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBStatus4.CheckedChanged
        If CBStatus4.Checked = True Then
            Status4 = 4
            Status5 = 5
            Status6 = 6
            Status7 = 7
            Status8 = 8
            Status9 = 9
        Else
            Status4 = 0
            Status5 = 0
            Status6 = 0
            Status7 = 0
            Status8 = 0
            Status9 = 0
        End If
    End Sub

    Protected Sub CBTipoFactura1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFactura1.CheckedChanged
        If CBTipoFactura1.Checked = True Then
            TipoFactura1 = 1
        Else
            TipoFactura1 = 0
        End If
    End Sub
    Protected Sub CBTipoFactura2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFactura2.CheckedChanged
        If CBTipoFactura2.Checked = True Then
            TipoFactura2 = 2
        Else
            TipoFactura2 = 0
        End If
    End Sub
    Protected Sub CBTipoFactura3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFactura3.CheckedChanged
        If CBTipoFactura3.Checked = True Then
            TipoFactura3 = 3
        Else
            TipoFactura3 = 0
        End If
    End Sub
    Protected Sub CBTipoFactura4_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFactura4.CheckedChanged
        If CBTipoFactura4.Checked = True Then
            TipoFactura4 = 4
        Else
            TipoFactura4 = 0
        End If
    End Sub

    Protected Sub CBTipoFecha1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFecha1.CheckedChanged
        If CBTipoFecha1.Checked = True Then
            TipoFecha = "fecha_fact"
            CBTipoFecha2.Checked = False
        Else
            TipoFecha = "fecha_pago"
            CBTipoFecha2.Checked = True
        End If
    End Sub
    Protected Sub CBTipoFecha2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles CBTipoFecha2.CheckedChanged
        If CBTipoFecha2.Checked = True Then
            TipoFecha = "fecha_pago"
            CBTipoFecha1.Checked = False
        Else
            TipoFecha = "fecha_fact"
            CBTipoFecha1.Checked = True
        End If
    End Sub


    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim item_sel As GridDataItem = CType(CType(sender, CheckBox).Parent.Parent, GridItem)
        v_linea_actual = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(item_sel("linea_servicio").Text, 2))

        If v_linea_actual = 99 Then
            For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = CType(sender, CheckBox).Checked
            Next
        Else
            If CType(sender, CheckBox).Checked = False Then
                For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
                    Dim v_linea_bus As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))
                    If v_linea_bus = 99 Then
                        CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = False ' CType(sender, CheckBox).Checked
                    End If
                Next
            End If
        End If
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        lblMensaje.Text = ""

        Select Case e.Item.Text
            Case "Generar Factura"
                GenerarFactura()
            Case "Cancelar Factura"
                CancelarFactura()
        End Select
    End Sub
    Public Sub GenerarFactura()

        Dim scriptString As String = ""

        ' Validar que se seleccionó un registro
        If RadGrid1.SelectedItems.Count = 0 Then
            scriptString = "alert('Para generar factura favor de seleccionar un registro.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Dim item As GridDataItem = TryCast(RadGrid1.SelectedItems(0), GridDataItem)

        Dim vFolio As Integer = item("folio_factura").Text
        Dim vTipo As String = item("tipo_factura").Text
        Dim vEstatus As String = item("status").Text
        Dim vAutorizado As String = item("autorizado").Text



        ' Validar que el registro sea Programa o Gasto autorizado
        If vEstatus <> "Programa (Confirmado)" And vEstatus <> "Gasto" Then
            scriptString = "alert('Solo puede generar facturas de Programas o Gastos Confirmados.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        Else
            If vAutorizado = "No" Then
                scriptString = "alert('Solo puede generar facturas de Programas o Gastos Autorizados.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If
        End If

        '1	Pronóstico (No Confirmado)
        '2: Programa(Confirmado)
        '3: Gasto
        '4	Pronóstico (Cancelado Cliente)
        '5	Pronóstico (Cancelado CPA)
        '6	Programa (Cancelado Cliente)
        '7	Programa (Cancelado CPA)
        '8	Gasto (Cancelado Cliente)
        '9	Gasto (Cancelado CPA)

        ' Validar que el tipo de factura sea No Facturada
        If vTipo <> "No Facturada" Then
            scriptString = "alert('Solo puede generar facturas de tipo No Facturada.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        
        ' Validar el directorio de la empresa
        Dim vDirectory As String = "C:\Compacw\Empresas\" & item("nombre_empresa").Text & "\"
        'Dim DirectoryInfo As New DirectoryInfo("C:\FactE\Antes\")
        Dim DirectoryInfo As New DirectoryInfo(vDirectory)
        'Dim DirectoryInfo As New DirectoryInfo("\\192.168.2.34\Compacw\Empresas\" & item("nombre_empresa").Text & "\")
        '\Compacw\Empresas

        If DirectoryInfo.Exists = False Then
            scriptString = "alert('No se encontró el directorio para obtener la factura electrónica de la empresa seleccionada. \n " & vDirectory & " \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        ' Validar que existan los archivos MGW10008.dbf y MGW10008.fpt
        If File.Exists(DirectoryInfo.ToString & "MGW10008.dbf") = False Then
            scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10008.dbf" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        If File.Exists(DirectoryInfo.ToString & "MGW10008.fpt") = False Then
            scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10008.fpt" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If


        ' Validar que existan los archivos MGW10010.dbf y MGW10010.fpt
        If File.Exists(DirectoryInfo.ToString & "MGW10010.dbf") = False Then
            scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10010.dbf" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        If File.Exists(DirectoryInfo.ToString & "MGW10010.fpt") = False Then
            scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10010.fpt" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Session("Lineas") = Lineas
        Session("DirectoryInfo") = DirectoryInfo.ToString
        Session("id_pago_pk") = item("id_pago_pk").Text
        Session("id_ingreso_pk") = item("id_ingreso_pk").Text
        Response.Redirect("~/FacturacionGenerar.aspx")

    End Sub
    Public Sub NoSeUsaModificar()

        Dim scriptString As String = ""

        ' Validar que se seleccionó un registro
        If RadGrid1.SelectedItems.Count = 0 Then
            scriptString = "alert('Para autorizar favor de seleccionar un registro.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Dim item As GridDataItem = TryCast(RadGrid1.SelectedItems(0), GridDataItem)
        Dim vLS As Integer = item("id_linea_servicio").Text
        Dim vAutorizado As String = item("autorizado").Text
        Dim vStatus As String = item("Status").Text

        ' Validar que el socio sea de la línea seleccionada
        If id_rol > 1 Then
            If vLS <> id_linea_servicio Then
                scriptString = "alert('El registro seleccionado no corresponde a su línea de servicio.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If
        End If

        ' Validar que el registro seleccionado no esté autorizado
        If id_rol > 1 Then
            If vAutorizado = "Si" Then
                scriptString = "alert('No puede modificar registros autorizados. \n Favor de revisarlo con el administrador del sistema.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If
        End If

        ' Validar si el pronostico está cancelado
        If vStatus.Trim().TrimEnd().TrimStart().Contains("Cancelado") Then
            scriptString = "alert('No puede modificar registros cancelados.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        ' Validar si el pronostico tiene por lo menos una factura generada, pagada o cancelada
        ' No se pueden modificar estos pagos porque no se puede facturar a clientes diferentes
        Dim v_DataTable_Pagos As New DataTable
        v_DataTable_Pagos = oInP.ExtraerIngresosPagosGeneradosBL(v_DataTable_Pagos, item("id_ingreso_pk").Text)

        'If id_rol > 1 Then
        If v_DataTable_Pagos.Rows.Count > 0 Then
            scriptString = "alert('No puede modificar registros con facturas generadas, pagadas o canceladas. \n Favor de revisarlo con el administrador del sistema.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If
        'End If

        Session("Lineas") = Lineas
        Session("id_ingreso_pk") = item("id_ingreso_pk").Text
        Response.Redirect("~/PronosticoProgramaModificar.aspx")

    End Sub
    Public Sub CancelarFactura()

        Dim scriptString As String = ""

        Try

            ' Validar que se seleccionó un registro
            If RadGrid1.SelectedItems.Count = 0 Then
                scriptString = "alert('Para cancelar favor de seleccionar un registro.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            Dim item As GridDataItem = TryCast(RadGrid1.SelectedItems(0), GridDataItem)
            Dim vFolio As Integer = item("folio_factura").Text
            Dim vTipo As String = item("tipo_factura").Text


            ' Validar que el tipo de factura sea Facturada
            If vTipo <> "Facturada" Then
                scriptString = "alert('Solo puede cancelar facturas de tipo Facturada.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If


            ' Validar el directorio de la empresa
            Dim vDirectory As String = "C:\Compacw\Empresas\" & item("nombre_empresa").Text & "\"
            'Dim DirectoryInfo As New DirectoryInfo("C:\FactE\Antes\")
            'Dim DirectoryInfo As New DirectoryInfo("Z:\" & item("nombre_empresa").Text & "\")
            Dim DirectoryInfo As New DirectoryInfo(vDirectory)
            'Dim DirectoryInfo As New DirectoryInfo("\\192.168.2.34\Compacw\Empresas\" & item("nombre_empresa").Text & "\")


            If DirectoryInfo.Exists = False Then
                scriptString = "alert('No se encontró el directorio para obtener la factura electrónica de la empresa seleccionada. \n " & vDirectory & " \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar que existan los archivos MGW10008.dbf y MGW10008.fpt
            If File.Exists(DirectoryInfo.ToString & "MGW10008.dbf") = False Then
                scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10008.dbf" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            If File.Exists(DirectoryInfo.ToString & "MGW10008.fpt") = False Then
                scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10008.fpt" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar que existan los archivos MGW10010.dbf y MGW10010.fpt
            If File.Exists(DirectoryInfo.ToString & "MGW10010.dbf") = False Then
                scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10010.dbf" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            If File.Exists(DirectoryInfo.ToString & "MGW10010.fpt") = False Then
                scriptString = "alert('No se encontró el archivo " & vDirectory & "MGW10010.fpt" & " para obtener la información de la factura electrónica seleccionada. \n\n Favor de ponerse en contacto con el encargado de sistemas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            'vFolio = 3704
            'vFolio = 3668
            'vFolio = 3652
            'vFolio = 3647


            ' Validar el folio seleccionado en Factura electrónica

            Dim v_DataTable_Folio As New DataTable
            v_DataTable_Folio = oInP.BuscarFolioEnFacturaEBL(v_DataTable_Folio, vFolio, DirectoryInfo.ToString)

            ' Validar que el folio seleccionado exista en Factura electrónica
            If v_DataTable_Folio.Rows.Count = 0 Then
                scriptString = "alert('No se encontró el folio seleccionado en Factura electrónica. \n Folio: " & vFolio & "\n\n Favor de revisar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            ' Validar que el folio seleccionado esté cancelado en Factura electrónica
            If v_DataTable_Folio.Rows(0).Item("ccancelado") <> 1 Then
                scriptString = "alert('El folio seleccionado no está cancelado en Factura electrónica. \n Folio: " & vFolio & "\n\n Favor de revisar el error y volver a intentarlo.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If

            'cfolio, cfecha, cidclien01, crazonso01, cneto, ccancelado

            Session("Lineas") = Lineas
            Session("id_pago_pk") = item("id_pago_pk").Text
            Session("id_ingreso_pk") = item("id_ingreso_pk").Text
            Response.Redirect("~/FacturacionCancelar.aspx")

            'Session("DirectoryInfo") = DirectoryInfo.ToString
            'Session("id_pago_pk") = item("id_pago_pk").Text
            'Session("id_ingreso_pk") = item("id_ingreso_pk").Text
            'Response.Redirect("~/FacturacionGenerar.aspx")

        Catch ex As Exception
            lblMensaje.Text = ex.Message
        End Try
    End Sub

    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick

        lblMensaje.Text = ""
        GenerarReporte()

        'Select Case e.Item.Text
        '    Case "Generar Reporte"
        '        GenerarReporte()
        '    Case "Generar Detalle"
        '        'GenerarDetalle
        'End Select

    End Sub
    Public Sub GenerarReporte()
        Dim scriptString As String = ""

        If RadGrid1.Items.Count > 0 Then

            Try
                Dim accessSQL As New DataAccess.SQL
                Dim selSql As String = ""

                selSql = "SET DATEFORMAT dmy;" _
                     & " BEGIN TRAN " _
                     & "     " _
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Facturación', 0, " & id_linea_servicio & ")" _
                     & "     " _
                     & "		IF @@ERROR <> 0  " _
                     & "		BEGIN " _
                     & "			ROLLBACK " _
                     & "			RETURN " _
                     & "		END " _
                     & "	COMMIT TRANSACTION"
                accessSQL.ExecuteNonQueryD(selSql)
                accessSQL.Close()

                vRowIn = 0
                vTitulo = 0

                RadGrid1.ExportSettings.ExportOnlyData = True
                RadGrid1.ExportSettings.IgnorePaging = True
                RadGrid1.ExportSettings.FileName = "Facturacion " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGrid1.ExportSettings.OpenInNewWindow = True

                RadGrid1.MasterTableView.GetColumn("id_pago_pk").Visible = False
                RadGrid1.MasterTableView.GetColumn("id_ingreso_pk").Visible = False

                RadGrid1.MasterTableView.ExportToExcel()

            Catch ex As Exception
                scriptString = "alert('Error al intentar generar el reporte. \n\n " & ex.Message & "');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            End Try

        Else
            scriptString = "alert('No existen registros en la Base de Datos.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If
    End Sub
    Protected Sub RadGrid1_ExcelMLExportRowCreated(ByVal source As Object, ByVal e As Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowCreatedArgs) Handles RadGrid1.ExcelMLExportRowCreated

        ' ¿Quién Factura?         nombre_empresa         myDetailStyle
        ' Línea de servicio       nombre_linea           myDetailStyle
        ' Clave                   id_ingreso             myDetailStyleNumeric
        ' Autorizado              autorizado             myDetailStyle
        ' Estatus                 status                 myDetailStyle
        ' Folio de factura        folio_factura          myDetailStyleNumeric
        ' Fecha de facturación    fecha_fact             myDetailStyle
        ' Fecha de pago           fecha_pago             myDetailStyle
        ' Tipo de factura         tipo_factura           myDetailStyle
        ' Tipo de Moneda          TipoMoneda             myDetailStyle
        ' Importe                 importe                myDetailStyleDecimal
        ' IVA                     iva                    myDetailStyleDecimal
        ' Total                   total                  myDetailStyleDecimal
        ' Vencido                 vencido                myDetailStyleDecimal
        ' Por vencer              por_vencer             myDetailStyleDecimal
        ' Concepto                concepto               myDetailStyle
        ' Gerente                 Gerente                myDetailStyle
        ' Cliente                 nombre_cliente         myDetailStyle
        ' Servicio                nombre_servicio        myDetailStyle
        ' Fecha deposito 1        fecha_deposito1        myDetailStyle
        ' Pago 1                  pago_1                 myDetailStyleDecimal
        ' Fecha deposito 2        fecha_deposito2        myDetailStyle
        ' Pago 2                  pago_2                 myDetailStyleDecimal
        ' Fecha deposito 3        fecha_deposito3        myDetailStyle
        ' Pago 3                  pago_3                 myDetailStyleDecimal
        ' Fecha deposito 4        fecha_deposito4        myDetailStyle
        ' Pago 4                  pago_4                 myDetailStyleDecimal
        ' Fecha deposito 5        fecha_deposito5        myDetailStyle
        ' Pago 5                  pago_5                 myDetailStyleDecimal
        ' Motivo de cancelación   motivo_cancelacion     myDetailStyle
        ' Fecha de cancelación    fecha_cancelacion      myDetailStyle

        If e.RowType = GridExportExcelMLRowType.DataRow Then

            If vRowT = 0 Then
                vRowT = RadGrid1.Items.Count + 6
            End If

            Dim vRowA As Integer = e.Worksheet.Table.Rows.Count

            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("nombre_empresa")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_empresa").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_empresa")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_empresa").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_linea")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_linea").StyleValue = "myDetailStyle"

                Dim vLineaAct As String = cell2.Data.DataItem

                If (vLinea <> "" And vLinea <> vLineaAct) Or vRowT = vRowA Then

                    Dim row As New Telerik.Web.UI.GridExcelBuilder.RowElement()

                    For i As Integer = 1 To 9
                        Dim cell_L As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_L.Data.DataItem = ""
                        cell_L.StyleValue = "MyStyleLinea1"
                        row.Cells.Add(cell_L)
                    Next

                    Dim cell_L1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_L1.Data.DataItem = vLinea
                    cell_L1.StyleValue = "MyStyleLinea1"
                    row.Cells.Add(cell_L1)

                    If vRowT = vRowA Then
                        Dim cellrowlast As CellElement = e.Row.Cells.GetCellByName("importe")
                        If Not cellrowlast Is Nothing Then
                            vImporte = vImporte + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("iva")
                        If Not cellrowlast Is Nothing Then
                            vIva = vIva + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("total")
                        If Not cellrowlast Is Nothing Then
                            vTotal = vTotal + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("vencido")
                        If Not cellrowlast Is Nothing Then
                            vVencido = vVencido + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("por_vencer")
                        If Not cellrowlast Is Nothing Then
                            vPorVencer = vPorVencer + cellrowlast.Data.DataItem
                        End If
                    End If

                    Dim cell_Importe As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Importe.Data.DataItem = vImporte
                    cell_Importe.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Importe)

                    Dim cell_Iva As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Iva.Data.DataItem = vIva
                    cell_Iva.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Iva)

                    Dim cell_Total As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Total.Data.DataItem = vTotal
                    cell_Total.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Total)

                    Dim cell_Vencido As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Vencido.Data.DataItem = vVencido
                    cell_Vencido.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Vencido)

                    Dim cell_PorVencer As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_PorVencer.Data.DataItem = vPorVencer
                    cell_PorVencer.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_PorVencer)

                    For i As Integer = 1 To 15
                        Dim cell_L As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_L.Data.DataItem = ""
                        cell_L.StyleValue = "MyStyleLinea1"
                        row.Cells.Add(cell_L)
                    Next

                    Dim cell_L2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_L2.Data.DataItem = ""
                    cell_L2.StyleValue = "MyStyleLinea3"
                    row.Cells.Add(cell_L2)

                    If vRowT = vRowA Then
                        e.Worksheet.Table.Rows.Insert(vRowT, row)
                    Else
                        e.Worksheet.Table.Rows.Insert(vRowA - 1, row)
                    End If

                    vImporte = 0
                    vIva = 0
                    vTotal = 0
                    vVencido = 0
                    vPorVencer = 0

                    vRowT = vRowT + 1
                End If

                vLinea = cell2.Data.DataItem

            End If
            cell2 = e.Row.Cells.GetCellByName("id_ingreso")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("id_ingreso").StyleValue = "myDetailStyleNumeric"
            End If
            cell2 = e.Row.Cells.GetCellByName("autorizado")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("autorizado").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("status")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("status").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("folio_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("folio_factura").StyleValue = "myDetailStyleNumeric"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_fact")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_fact").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_pago").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("tipo_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("TipoMoneda")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("TipoMoneda").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe").StyleValue = "myDetailStyleDecimal"
                vImporte = vImporte + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("iva")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("iva").StyleValue = "myDetailStyleDecimal"
                vIva = vIva + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("total")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total").StyleValue = "myDetailStyleDecimal"
                vTotal = vTotal + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("vencido")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("vencido").StyleValue = "myDetailStyleDecimal"
                vVencido = vVencido + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("por_vencer")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("por_vencer").StyleValue = "myDetailStyleDecimal"
                vPorVencer = vPorVencer + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("concepto").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("Gerente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("Gerente").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_cliente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_cliente").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_servicio")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_servicio").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito1").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_1").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito2").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_2").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito3").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_3").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito4").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_4").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito5").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_5").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("motivo_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("motivo_cancelacion").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_cancelacion").StyleValue = "myDetailStyle"
            End If
           
        End If


        If vTitulo = 0 Then
            If e.RowType = Telerik.Web.UI.GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then

                Dim row As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                'cell.StyleValue = "MyTitle"
                row.Cells.Add(cell)
                e.Worksheet.Table.Rows.Insert(0, row)

                Dim row1 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell1.Data.DataItem = "Fecha: " & FormatDateTime(Today, DateFormat.LongDate)
                cell1.StyleValue = "MyTitle2"
                row1.Cells.Add(cell1)
                e.Worksheet.Table.Rows.Insert(0, row1)

                Dim row2 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell2.Data.DataItem = lblStatus.Text
                cell2.StyleValue = "MyTitle2"
                row2.Cells.Add(cell2)
                e.Worksheet.Table.Rows.Insert(0, row2)

                Dim row3 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell3 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell3.Data.DataItem = "Reporte de Facturación"
                cell3.StyleValue = "MyTitle1"
                row3.Cells.Add(cell3)

                For i As Integer = 1 To 11
                    Dim cell_v As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_v.Data.DataItem = ""
                    row3.Cells.Add(cell_v)
                Next

                Dim cell_tc As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_tc.Data.DataItem = "T.C."
                cell_tc.StyleValue = "MyStyleTC1"
                row3.Cells.Add(cell_tc)

                Dim cell_tc2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_tc2.Data.DataItem = TBTipoCambio.Text
                cell_tc2.StyleValue = "MyStyleTC2"
                row3.Cells.Add(cell_tc2)

                e.Worksheet.Table.Rows.Insert(0, row3)

                Dim row4 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell4 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell4.Data.DataItem = "Cuenza. Control de Cuentas y Cobranza"
                cell4.StyleValue = "MyTitle"
                row4.Cells.Add(cell4)
                e.Worksheet.Table.Rows.Insert(0, row4)

                vTitulo = 1
            End If
        End If

        If e.RowType = GridExcelBuilder.GridExportExcelMLRowType.HeaderRow Then
            e.Worksheet.AutoFilter.Range = ""
        End If


        If Not isConfigured Then
            Dim va As Integer = e.Worksheet.Table.Columns.Count
            If va > 0 Then

                For Each column As ColumnElement In e.Worksheet.Table.Columns
                    ' 0 1 4 9
                    ' 15 16 17 18 29
                    If e.Worksheet.Table.Columns.IndexOf(column) = 0 Or e.Worksheet.Table.Columns.IndexOf(column) = 1 Or e.Worksheet.Table.Columns.IndexOf(column) = 4 Or e.Worksheet.Table.Columns.IndexOf(column) = 9 Then
                        column.Attributes("ss:Width") = "161"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 15 Or e.Worksheet.Table.Columns.IndexOf(column) = 16 Or e.Worksheet.Table.Columns.IndexOf(column) = 17 Or e.Worksheet.Table.Columns.IndexOf(column) = 18 Or e.Worksheet.Table.Columns.IndexOf(column) = 29 Then
                        column.Attributes("ss:Width") = "266"
                    Else
                        column.Attributes("ss:Width") = "109"
                    End If
                Next

                Dim vRow As RowElement = e.Worksheet.Table.Rows(5)
                vRow.Attributes("ss:Height") = 20

                e.Worksheet.Name = "Facturación"

                isConfigured = True
            End If
        End If

    End Sub
    Protected Sub RadGrid1_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As GridExportExcelMLStyleCreatedArgs) Handles RadGrid1.ExcelMLExportStylesCreated

        Dim borderTC1 As BorderStyles = New BorderStyles()
        borderTC1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC1.Weight = 2
        borderTC1.LineStyle = LineStyle.Continuous
        borderTC1.PositionType = PositionType.Left

        Dim borderTC2 As BorderStyles = New BorderStyles()
        borderTC2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC2.Weight = 2
        borderTC2.LineStyle = LineStyle.Continuous
        borderTC2.PositionType = PositionType.Bottom

        Dim borderTC3 As BorderStyles = New BorderStyles()
        borderTC3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC3.Weight = 2
        borderTC3.LineStyle = LineStyle.Continuous
        borderTC3.PositionType = PositionType.Right

        Dim borderTC4 As BorderStyles = New BorderStyles()
        borderTC4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderTC4.Weight = 2
        borderTC4.LineStyle = LineStyle.Continuous
        borderTC4.PositionType = PositionType.Top

        Dim MyStyleTC1 As New StyleElement("MyStyleTC1")
        MyStyleTC1.FontStyle.Bold = True
        MyStyleTC1.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTC1.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleTC1.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        MyStyleTC1.Borders.Add(borderTC1)
        MyStyleTC1.Borders.Add(borderTC2)
        MyStyleTC1.Borders.Add(borderTC4)
        e.Styles.Add(MyStyleTC1)

        Dim MyStyleTC2 As New StyleElement("MyStyleTC2")
        MyStyleTC2.FontStyle.Bold = True
        MyStyleTC2.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTC2.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleTC2.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        MyStyleTC2.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        MyStyleTC2.Borders.Add(borderTC2)
        MyStyleTC2.Borders.Add(borderTC3)
        MyStyleTC2.Borders.Add(borderTC4)
        e.Styles.Add(MyStyleTC2)


        Dim borderL1 As BorderStyles = New BorderStyles()
        borderL1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderL1.Weight = 2
        borderL1.LineStyle = LineStyle.Continuous
        borderL1.PositionType = PositionType.Bottom

        Dim borderL2 As BorderStyles = New BorderStyles()
        borderL2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        borderL2.Weight = 2
        borderL2.LineStyle = LineStyle.Continuous
        borderL2.PositionType = PositionType.Right

        Dim MyStyleLinea1 As New StyleElement("MyStyleLinea1")
        MyStyleLinea1.FontStyle.Bold = True
        MyStyleLinea1.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea1.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea1.Borders.Add(borderL1)
        e.Styles.Add(MyStyleLinea1)

        Dim MyStyleLinea2 As New StyleElement("MyStyleLinea2")
        MyStyleLinea2.FontStyle.Bold = True
        MyStyleLinea2.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea2.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea2.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        MyStyleLinea2.Borders.Add(borderL1)
        e.Styles.Add(MyStyleLinea2)

        Dim MyStyleLinea3 As New StyleElement("MyStyleLinea3")
        MyStyleLinea3.FontStyle.Bold = True
        MyStyleLinea3.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleLinea3.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
        MyStyleLinea3.Borders.Add(borderL1)
        MyStyleLinea3.Borders.Add(borderL2)
        e.Styles.Add(MyStyleLinea3)


        Dim styleMyTitle As New StyleElement("MyTitle")
        styleMyTitle.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle.FontStyle.Bold = True
        styleMyTitle.FontStyle.Size = 14
        styleMyTitle.FontStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        e.Styles.Add(styleMyTitle)
        
        Dim styleMyTitle1 As New StyleElement("MyTitle1")
        styleMyTitle1.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle1.FontStyle.Bold = True
        styleMyTitle1.FontStyle.Size = 14
        e.Styles.Add(styleMyTitle1)

        Dim styleMyTitle2 As New StyleElement("MyTitle2")
        styleMyTitle2.FontStyle.FontName = "Footlight MT Light"
        styleMyTitle2.FontStyle.Bold = True
        styleMyTitle2.FontStyle.Size = 11
        e.Styles.Add(styleMyTitle2)


        '--------------------------------------------------
        ' Bordes
        '--------------------------------------------------
        Dim border1 As BorderStyles = New BorderStyles()
        border1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border1.Weight = 1
        border1.LineStyle = LineStyle.Dash
        border1.PositionType = PositionType.Top
        
        Dim border2 As BorderStyles = New BorderStyles()
        border2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border2.Weight = 1
        border2.LineStyle = LineStyle.Dash
        border2.PositionType = PositionType.Bottom
        
        Dim border3 As BorderStyles = New BorderStyles()
        border3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border3.Weight = 1
        border3.LineStyle = LineStyle.Dash
        border3.PositionType = PositionType.Left
        
        Dim border4 As BorderStyles = New BorderStyles()
        border4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border4.Weight = 1
        border4.LineStyle = LineStyle.Dash
        border4.PositionType = PositionType.Right

        Dim border5 As BorderStyles = New BorderStyles()
        border5.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border5.Weight = 1
        border5.LineStyle = LineStyle.Continuous
        border5.PositionType = PositionType.Bottom

        Dim border6 As BorderStyles = New BorderStyles()
        border6.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        border6.Weight = 1
        border6.LineStyle = LineStyle.Continuous
        border6.PositionType = PositionType.Right

        
        '--------------------------------------------------
        ' myDetailStyle
        '--------------------------------------------------
        Dim myStyle As New StyleElement("myDetailStyle")
        myStyle.Borders.Add(border1)
        myStyle.Borders.Add(border2)
        myStyle.Borders.Add(border3)
        myStyle.Borders.Add(border4)
        e.Styles.Add(myStyle)
        

        '--------------------------------------------------
        ' myDetailStyleNumeric
        '--------------------------------------------------
        Dim myStyleNum As New StyleElement("myDetailStyleNumeric")
        myStyleNum.Borders.Add(border1)
        myStyleNum.Borders.Add(border2)
        myStyleNum.Borders.Add(border3)
        myStyleNum.Borders.Add(border4)
        myStyleNum.NumberFormat.Attributes("ss:Format") = "###0" ' "MM/dd"
        e.Styles.Add(myStyleNum)


        '--------------------------------------------------
        ' myDetailStyleDecimal
        '--------------------------------------------------
        Dim myStyleDec As New StyleElement("myDetailStyleDecimal")
        myStyleDec.Borders.Add(border1)
        myStyleDec.Borders.Add(border2)
        myStyleDec.Borders.Add(border3)
        myStyleDec.Borders.Add(border4)
        myStyleDec.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDec)


        ''--------------------------------------------------
        '' myDetailStyleB
        ''--------------------------------------------------
        'Dim myStyleB As New StyleElement("myDetailStyleB")
        'myStyleB.Borders.Add(border1)
        'myStyleB.Borders.Add(border5)
        'myStyleB.Borders.Add(border3)
        'myStyleB.Borders.Add(border4)
        'e.Styles.Add(myStyleB)


        ''--------------------------------------------------
        '' myDetailStyleNumericB
        ''--------------------------------------------------
        'Dim myStyleNumB As New StyleElement("myDetailStyleNumericB")
        'myStyleNumB.Borders.Add(border1)
        'myStyleNumB.Borders.Add(border5)
        'myStyleNumB.Borders.Add(border3)
        'myStyleNumB.Borders.Add(border4)
        'myStyleNumB.NumberFormat.Attributes("ss:Format") = "###0" ' "MM/dd"
        'e.Styles.Add(myStyleNumB)


        ''--------------------------------------------------
        '' myDetailStyleDecimalB
        ''--------------------------------------------------
        'Dim myStyleDecB As New StyleElement("myDetailStyleDecimalB")
        'myStyleDecB.Borders.Add(border1)
        'myStyleDecB.Borders.Add(border5)
        'myStyleDecB.Borders.Add(border3)
        'myStyleDecB.Borders.Add(border4)
        'myStyleDecB.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        'e.Styles.Add(myStyleDecB)

        For Each style As StyleElement In e.Styles

            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.FontStyle.Color = Drawing.Color.White
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))

                '--------------------------------------------------
                ' Bordes
                '--------------------------------------------------
                Dim borderH1 As BorderStyles = New BorderStyles()
                borderH1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH1.Weight = 2
                borderH1.LineStyle = LineStyle.Continuous
                borderH1.PositionType = PositionType.Top

                Dim borderH2 As BorderStyles = New BorderStyles()
                borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                'borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH2.Weight = 1
                borderH2.LineStyle = LineStyle.Continuous
                borderH2.PositionType = PositionType.Bottom

                Dim borderH3 As BorderStyles = New BorderStyles()
                borderH3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH3.Weight = 2
                borderH3.LineStyle = LineStyle.Continuous
                borderH3.PositionType = PositionType.Left

                Dim borderH4 As BorderStyles = New BorderStyles()
                borderH4.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH4.Weight = 2
                borderH4.LineStyle = LineStyle.Continuous
                borderH4.PositionType = PositionType.Right

                style.Borders.Add(borderH1)
                style.Borders.Add(borderH2)
                style.Borders.Add(borderH3)
                style.Borders.Add(borderH4)

            End If

            If style.Id.Contains("itemStyle") OrElse style.Id = "alternatingItemStyle" Then
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            End If

            'If style.Id.Contains("myDetailStyle") OrElse style.Id = "myDetailStyleNumeric" OrElse style.Id = "myDetailStyleDecimal" Then
            '    'style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    'style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            'End If

        Next

    End Sub


    Protected Sub RadToolBarPolizaImp_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarPolizaImp.ButtonClick
        lblMensaje.Text = ""

        Select Case e.Item.Text
            Case "Carga Batch"
                Session("Lineas") = Lineas
                Response.Redirect("~/FacturacionCargaBatch.aspx")
            Case "Importar Pagos"
                Session("Lineas") = Lineas
                Response.Redirect("~/FacturacionImportarPagos.aspx")
        End Select

    End Sub
    Public Sub CargaBatch()
        Dim scriptString As String = ""

        If RadGrid1.Items.Count = 0 Then
            scriptString = "alert('No existen facturas en pantalla para generar cargar batch.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Try

            lblMensaje.Text = ""

            ' Validar mes inicial con mes final
            mesI = [Enum].Parse(GetType(Meses), RCBMesI.SelectedValue)
            Fini = CType("01/" & mesI & "/" & RCBAñoI.SelectedValue, Date)
            mesF = [Enum].Parse(GetType(Meses), RCBMesF.SelectedValue)
            Ffin = CType(System.DateTime.DaysInMonth(RCBAñoF.SelectedValue, mesF) & "/" & mesF & "/" & RCBAñoF.SelectedValue, Date)

            If Fini > Ffin Then
                lblMensaje.Text = "El Rango Inicial no puede ser mayor al Rango Final"
                Exit Sub
            End If

            'If Status1 = 0 And Status2 = 0 And Status3 = 0 And Status4 = 0 And Status5 = 0 And Status6 = 0 And Status7 = 0 And Status8 = 0 And Status9 Then
            '    lblMensaje.Text = "Favor de seleccionar por lo menos un Status"
            '    Exit Sub
            'End If

            'If TipoFactura1 = 0 And TipoFactura2 = 0 And TipoFactura3 = 0 And TipoFactura4 = 0 Then
            '    lblMensaje.Text = "Favor de seleccionar por lo menos un Tipo de Factura"
            '    Exit Sub
            'End If

            LineasS()
            If Lineas = "" Or Lineas = "AND ()" Then
                lblMensaje.Text = "Favor de seleccionar por lo menos una Línea de Servicio"
                Exit Sub
            End If

            Lineas = Replace(Lineas, "Ingresos.", "ING.")

            Session("mesI") = mesI
            Session("añoI") = RCBAñoI.SelectedValue
            Session("MesF") = mesF
            Session("AñoF") = RCBAñoF.SelectedValue
            Session("Lineas") = Lineas

            'Session("Status1") = Status1
            'Session("Status2") = Status2
            'Session("Status3") = Status3
            'Session("Status4") = Status4
            'Session("Status5") = Status5
            'Session("Status6") = Status6
            'Session("Status7") = Status7
            'Session("Status8") = Status8
            'Session("Status9") = Status9

            'Session("TipoFactura1") = TipoFactura1
            'Session("TipoFactura2") = TipoFactura2
            'Session("TipoFactura3") = TipoFactura3
            'Session("TipoFactura4") = TipoFactura4
            'Session("TipoFecha") = TipoFecha

            mes = mesI
            año = RCBAñoI.SelectedValue
            añoI = año
            mes2 = mesF
            año2 = RCBAñoF.SelectedValue
            añoF = año2

            Fini_f = IIf(TipoFecha = "fecha_fact", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            Ffin_f = IIf(TipoFecha = "fecha_fact", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")
            'Fini_p = IIf(TipoFecha = "fecha_pago", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            'Ffin_p = IIf(TipoFecha = "fecha_pago", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")


            Dim strMap As String = Server.MapPath("~") & "Ficheros"
            Dim FileName As String = strMap + "\" + "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"
            Dim FileName2 As String = "Carga Batch Facturas Generadas " & Right("0" & Today.Day, 2) & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year & ".txt"

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

            'Dim _directorioGral As String = strMap

            'Dim directorio As New System.IO.DirectoryInfo(_directorioGral)
            'Dim archivos As System.IO.FileInfo() = directorio.GetFiles()
            'Dim archivo As System.IO.FileInfo

            'For Each archivo In archivos
            '    archivo.Delete()
            'Next


            Dim oFac As New FacturacionBL.FacturacionBL
            oFac.GenerarCargaBatchBL(Fini_f, Ffin_f, Lineas, FileName)
            'Status1, Status2, Status3, Status4, Status5, Status6, Status7, Status8, Status9, TipoFactura1, TipoFactura2, TipoFactura3, TipoFactura4,

            Response.Clear()
            Response.ContentType = "application/octet-stream"
            Response.AddHeader("Content-Disposition", "attachment; filename=" & FileName2)
            Response.TransmitFile(FileName)
            Response.Flush()
            'Response.End()
            HttpContext.Current.ApplicationInstance.CompleteRequest()

            If System.IO.File.Exists(FileName) Then
                System.IO.File.Delete(FileName)
            End If

        Catch ex As Exception
            scriptString = "alert('Error al intentar generar el reporte. \n\n " & ex.Message & "');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        End Try

    End Sub

End Class
