
Imports Domain
Imports UsuariosBL
Imports FacturacionBL
Imports ClientesBL
Imports LineasServicioBL
Imports IngresosBL
Imports IngresosPagosBL
Imports BitacoraBL
Imports EmpresasBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder


Partial Class PronosticoPrograma
    Inherits System.Web.UI.Page

#Region "Variables"

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

    Dim Num2Text As String = ""
    Dim v_unidades_int As Integer
    Dim v_unidades_str As String = ""
    Dim v_decenas_int As Integer
    Dim v_decenas_str As String = ""
    Dim v_centenas_int As Integer
    Dim v_centenas_str As String = ""
    Dim v_miles_int As Integer
    Dim v_miles_str As String = ""
    Dim v_unmiles_int As Integer
    Dim v_unmiles_str As String = ""
    Dim v_dosmiles_int As Integer
    Dim v_dosmiles_str As String = ""

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

    Public Sub vShared()

        lU = Nothing
        id_Usuario = 0
        id_rol = 0
        id_linea_servicio = 0
        Usuario = ""

        mes = 0
        año = 0
        mes2 = 0
        año2 = 0
        mesI = 0
        añoI = 0
        mesF = 0
        añoF = 0

        'Shared FToday As Date = Today()
        'Shared Fini As Date
        'Shared Ffin As Date

        Status1 = 0
        Status2 = 0
        Status3 = 0
        Status4 = 0
        Status5 = 0
        Status6 = 0
        Status7 = 0
        Status8 = 0
        Status9 = 0

        TipoFactura1 = 0
        TipoFactura2 = 0
        TipoFactura3 = 0
        TipoFactura4 = 0
        TipoFecha = ""
        Lineas = ""
        v_linea_actual = 0

        id_ls_1 = 0
        id_ls_2 = 0
        id_ls_3 = 0
        id_ls_4 = 0
        id_ls_5 = 0
        id_ls_6 = 0
        id_ls_7 = 0
        id_ls_8 = 0
        id_ls_9 = 0
        id_ls_10 = 0

        id_ls_11 = 0
        id_ls_12 = 0
        id_ls_13 = 0
        id_ls_14 = 0
        id_ls_15 = 0
        id_ls_16 = 0
        id_ls_17 = 0
        id_ls_18 = 0
        id_ls_19 = 0
        id_ls_20 = 0

        id_ls_21 = 0
        id_ls_22 = 0
        id_ls_23 = 0
        id_ls_24 = 0
        id_ls_25 = 0
        id_ls_26 = 0
        id_ls_27 = 0
        id_ls_28 = 0
        id_ls_29 = 0
        id_ls_30 = 0

        Fini_f = ""
        Ffin_f = ""
        Fini_p = ""
        Ffin_p = ""

    End Sub
    Public Sub IniciaVariables()

        If id_rol > 2 Then
            RadToolBarActualizar.Items(1).Visible = False
        End If

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

        lblStatus.Text = "Detalle de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue
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

        SqlDataSource1.DataBind()

    End Sub
    Public Sub ObtenerTotales()

        ' Formar la cadena para los meses

        Dim v_fecha_inicial As Date = "01/" & mesI & "/" & añoI
        Dim v_fecha_final As Date = "01/" & mesF & "/" & añoF
        Dim v_fecha_para_dias As String = v_fecha_inicial
        Dim v_total_meses As Integer = (DateDiff("m", v_fecha_inicial, v_fecha_final)) + 1
        Dim v_pivot As String = ""
        Dim v_select As String = ""
        Dim v_totales As String = ""

        For f_2 As Integer = 1 To v_total_meses

            Dim v_mes_actual As Integer = Mid(v_fecha_para_dias, 4, 2)
            Dim v_año_actual As Integer = Microsoft.VisualBasic.Right(v_fecha_para_dias, 4)

            v_fecha_para_dias = (DateAdd("m", +1, v_fecha_para_dias))
            v_select = v_select & ", [" & v_mes_actual & "/" & v_año_actual & "]"

            If f_2 = v_total_meses Then
                v_pivot = v_pivot & "[" & v_mes_actual & "/" & v_año_actual & "]"
                v_totales = v_totales & " CASE WHEN [" & v_mes_actual & "/" & v_año_actual & "] IS NULL THEN 0 ELSE [" & v_mes_actual & "/" & v_año_actual & "] END "
            Else
                v_pivot = v_pivot & "[" & v_mes_actual & "/" & v_año_actual & "],"
                v_totales = v_totales & " CASE WHEN [" & v_mes_actual & "/" & v_año_actual & "] IS NULL THEN 0 ELSE [" & v_mes_actual & "/" & v_año_actual & "] END + "
            End If

        Next

        Dim v_data_table_totales As New DataTable
        v_data_table_totales = oIng.ExtraerIngresosTotalesBL(v_data_table_totales, Fini_f, Ffin_f, Fini_p, Ffin_p, Status1, Status2, Status3, TipoFactura1, TipoFactura2, TipoFactura3, TipoFactura4, id_ls_1, id_ls_2, id_ls_3, id_ls_4, id_ls_5, id_ls_6, id_ls_7, id_ls_8, id_ls_9, id_ls_10, id_ls_11, id_ls_12, id_ls_13, id_ls_14, id_ls_15, id_ls_16, id_ls_17, id_ls_18, id_ls_19, id_ls_20, id_ls_21, id_ls_22, id_ls_23, id_ls_24, id_ls_25, id_ls_26, id_ls_27, id_ls_28, id_ls_29, id_ls_30, v_pivot, v_totales, v_select)

        RadGridTotales.DataSource = Nothing
        RadGridTotales.DataSource = v_data_table_totales
        RadGridTotales.DataBind()

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Not Session("usuario") Is Nothing Then

                vShared()

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

                'Usuario = Session("nombres") & " " & Session("apellido_paterno") & " " & Session("apellido_materno")
                Usuario = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno

                IniciaVariables()

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
                ObtenerTotales()
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

        'RadGrid1.Rebind()
        ActualizarSqlDataSource1()
        ObtenerTotales()
        lblStatus.Text = "Detalle de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue

    End Sub

    Protected Sub CBEmpresa1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) 'Handles CBEmpresa1.CheckedChanged
        'If CBEmpresa1.Checked = True Then
        '    Empresa1 = 1
        'Else
        '    Empresa1 = 0
        'End If
    End Sub
    Protected Sub CBEmpresa2_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) 'Handles CBEmpresa2.CheckedChanged
        'If CBEmpresa2.Checked = True Then
        '    Empresa2 = 2
        'Else
        '    Empresa2 = 0
        'End If
    End Sub
    Protected Sub CBEmpresa3_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) 'Handles CBEmpresa3.CheckedChanged
        'If CBEmpresa3.Checked = True Then
        '    Empresa3 = 3
        'Else
        '    Empresa3 = 0
        'End If
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
    Protected Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim item_sel As GridDataItem = CType(CType(sender, CheckBox).Parent.Parent, GridItem)
        'v_empresa_actual = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(item_sel("Empresa").Text, 2))

        'If v_linea_actual = 99 Then
        '    For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
        '        CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = CType(sender, CheckBox).Checked
        '    Next
        'Else
        '    If CType(sender, CheckBox).Checked = False Then
        '        For Each dataItem As GridDataItem In RadGridLineas.MasterTableView.Items
        '            Dim v_linea_bus As Integer = Microsoft.VisualBasic.Val(Microsoft.VisualBasic.Left(dataItem("linea_servicio").Text, 2))
        '            If v_linea_bus = 99 Then
        '                CType(dataItem.FindControl("CheckBox1"), CheckBox).Checked = False ' CType(sender, CheckBox).Checked
        '            End If
        '        Next
        '    End If
        'End If
    End Sub

    Protected Sub RadToolBarActualizar_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarActualizar.ButtonClick

        lblMensaje.Text = ""

        Select Case e.Item.Text
            Case "Agregar"
                Session("Lineas") = Lineas
                Response.Redirect("~/PronosticoProgramaAgregar.aspx")
            Case "Autorizar"
                Autorizar()
            Case "Modificar"
                Modificar()
            Case "Cancelar"
                Cancelar()
        End Select
    End Sub
    Public Sub Autorizar()

        Dim scriptString As String = ""

        If id_rol > 2 Then
            scriptString = "alert('Usuario sin permisos para autorizar.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

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
        If vAutorizado = "Si" Then
            scriptString = "alert('El registro seleccionado ya está autorizado.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        ' Validar si el pronostico está cancelado
        If vStatus.Trim().TrimEnd().TrimStart().Contains("Cancelado") Then
            scriptString = "alert('No puede autorizar registros cancelados.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If

        Session("Lineas") = Lineas
        Session("id_ingreso_pk") = item("id_ingreso_pk").Text
        Response.Redirect("~/PronosticoProgramaAutorizar.aspx")

    End Sub
    Public Sub Modificar()

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

        Session("facturas_generaddas") = 0

        'If id_rol > 1 Then
        If v_DataTable_Pagos.Rows.Count > 0 Then
            'scriptString = "alert('No puede modificar registros con facturas generadas, pagadas o canceladas. \n Favor de revisarlo con el administrador del sistema.');"
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            'Exit Sub
            Session("facturas_generaddas") = 1
        End If
        'End If

        Session("Lineas") = Lineas
        Session("id_ingreso_pk") = item("id_ingreso_pk").Text
        Response.Redirect("~/PronosticoProgramaModificar.aspx")

    End Sub
    Public Sub Cancelar()

        Dim scriptString As String = ""

        ' Validar que se seleccionó un registro
        If RadGrid1.SelectedItems.Count = 0 Then
            scriptString = "alert('Para cancelar favor de seleccionar un registro.');"
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

        '' Validar que el registro seleccionado no esté autorizado
        'If id_rol > 1 Then
        '    If vAutorizado = "Si" Then
        '        scriptString = "alert('No puede cancelar registros autorizados. \n Favor de revisarlo con el administrador del sistema.');"
        '        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
        '        Exit Sub
        '    End If
        'End If

        ' Validar si el pronostico está cancelado
        If vStatus.Trim().TrimEnd().TrimStart().Contains("Cancelado") Then
            scriptString = "alert('El registro seleccionado ya está cancelado.');"
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
            Exit Sub
        End If


        ' Validar si el pronostico tiene por lo menos una factura generada, pagada o cancelada
        ' No se pueden cancelar estos pagos porque lo tiene que hacer el administrador
        If id_rol > 1 Then
            Dim v_DataTable_Pagos As New DataTable
            v_DataTable_Pagos = oInP.ExtraerIngresosPagosGeneradosBL(v_DataTable_Pagos, item("id_ingreso_pk").Text)

            If v_DataTable_Pagos.Rows.Count > 0 Then
                scriptString = "alert('No puede cancelar registros con facturas generadas, pagadas o canceladas. \n Favor de revisarlo con el administrador del sistema.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If
        End If

        ' Validar si el pronostico tiene por lo menos una factura generada, pagada o cancelada
        ' No se pueden cancelar estos pagos porque el administrador primero debe cancelar las facturas generadas
        If id_rol = 1 Then
            Dim v_DataTable_Pagos As New DataTable
            v_DataTable_Pagos = oInP.ExtraerIngresosPagosGeneradosAdmBL(v_DataTable_Pagos, item("id_ingreso_pk").Text)

            If v_DataTable_Pagos.Rows.Count > 0 Then
                scriptString = "alert('No puede cancelar registros con facturas generadas. \n Favor de cancelar primero dichas facturas.');"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "Error", scriptString, True)
                Exit Sub
            End If
        End If


        Session("Lineas") = Lineas
        Session("id_ingreso_pk") = item("id_ingreso_pk").Text
        Response.Redirect("~/PronosticoProgramaCancelar.aspx")

        'Correo()

    End Sub

    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick

        lblMensaje.Text = ""

        Select Case e.Item.Text
            Case "Generar Reporte"
                GenerarReporte()
            Case "Generar Detalle"
                'GenerarDetalle
        End Select

    End Sub
    Public Sub GenerarReporte()
        Dim scriptString As String = ""

        If RadGrid1.Items.Count > 0 Then

            Try
                'Dim Usuario As String = lU.Item(0).nombres & " " & lU.Item(0).apellido_paterno & " " & lU.Item(0).apellido_materno
                Dim accessSQL As New DataAccess.SQL
                Dim selSql As String = ""

                selSql = "SET DATEFORMAT dmy;" _
                     & " BEGIN TRAN " _
                     & "     " _
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Pronósticos, Programas y Gastos', 0, " & id_linea_servicio & ")" _
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
                RadGrid1.ExportSettings.FileName = "Pronosticos, Programas y Gastos " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGrid1.ExportSettings.OpenInNewWindow = True

                RadGrid1.MasterTableView.GetColumn("id_ingreso_pk").Visible = False
                RadGrid1.MasterTableView.GetColumn("id_linea_servicio").Visible = False
                RadGrid1.MasterTableView.HierarchyDefaultExpanded = True
                RadGrid1.MasterTableView.DetailTables(0).HierarchyDefaultExpanded = True

                RadGrid1.MasterTableView.HierarchyLoadMode = GridChildLoadMode.Client
                RadGrid1.MasterTableView.DetailTables(0).HierarchyLoadMode = GridChildLoadMode.Client

                'RadGrid1.Rebind()
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

        If e.Row.Cells(0).ColumnName = "nombre_empresa" And e.RowType = GridExportExcelMLRowType.HeaderRow Then
            Dim i As Integer = 0
            For i = 0 To e.Row.Cells.Count - 1
                e.Row.Cells(i).StyleValue = "masterTable"
            Next
        End If

        If e.RowType = GridExportExcelMLRowType.DataRow Then

            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("nombre_empresa")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_empresa").StyleValue = "myStyleMT"
                Dim vRow1 As RowElement = e.Row
                vRow1.Attributes("ss:Height") = 20
            End If

            cell2 = e.Row.Cells.GetCellByName("nombre_linea")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_linea").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("id_ingreso")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("id_ingreso").StyleValue = "myStyleNumericMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("autorizado")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("autorizado").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("Status")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("Status").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("StatusDesc")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("StatusDesc").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe").StyleValue = "myStyleDecimalMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe_dlls")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe_dlls").StyleValue = "myStyleDecimalMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("TipoMoneda")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("TipoMoneda").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("total_pagos")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total_pagos").StyleValue = "myStyleNumericMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("socio")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("socio").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("Gerente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("Gerente").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_cliente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_cliente").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_servicio")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_servicio").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("años")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("años").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("detalle")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("detalle").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("especificacion_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("especificacion_pago").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("motivo_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("motivo_cancelacion").StyleValue = "myStyleMT"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_cancelacion")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_cancelacion").StyleValue = "myStyleMT"
            End If
      




            '--------------------------------------------------
            ' Detalle
            '--------------------------------------------------

            cell2 = e.Row.Cells.GetCellByName("no_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("no_pago").StyleValue = "myStyleNumeric"
                Dim vRow1 As RowElement = e.Row
                vRow1.Attributes("ss:Height") = 15
            End If

            cell2 = e.Row.Cells.GetCellByName("folio_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("folio_factura").StyleValue = "myStyleNumeric"
            End If

            cell2 = e.Row.Cells.GetCellByName("fecha_fact")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_fact").StyleValue = "myStyle"
            End If

            cell2 = e.Row.Cells.GetCellByName("fecha_pago")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_pago").StyleValue = "myStyle"
            End If

            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("concepto").StyleValue = "myStyle"
            End If

            cell2 = e.Row.Cells.GetCellByName("tipo_factura")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("tipo_factura").StyleValue = "myStyle"
            End If

            cell2 = e.Row.Cells.GetCellByName("importe_p")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe_p").StyleValue = "myStyleDecimal"
            End If

            cell2 = e.Row.Cells.GetCellByName("iva")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("iva").StyleValue = "myStyleDecimal"
            End If

            cell2 = e.Row.Cells.GetCellByName("total")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total").StyleValue = "myStyleDecimal"
            End If

            cell2 = e.Row.Cells.GetCellByName("pago_1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_1").StyleValue = "myStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_2").StyleValue = "myStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_3").StyleValue = "myStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_4").StyleValue = "myStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_5").StyleValue = "myStyleDecimal"
            End If

            cell2 = e.Row.Cells.GetCellByName("fecha_deposito1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito1").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito2").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito3").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito4").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_deposito5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_deposito5").StyleValue = "myStyle"
            End If

            cell2 = e.Row.Cells.GetCellByName("importe_letra")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe_letra").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("motivo_cancelacion_p")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("motivo_cancelacion_p").StyleValue = "myStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("fecha_cancelacion_p")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("fecha_cancelacion_p").StyleValue = "myStyle"
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

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                row.Cells.Add(cell)
                
                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 6 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(5).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row)

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                row.Cells.Add(cell)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 5 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(4).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row)

                row = New Telerik.Web.UI.GridExcelBuilder.RowElement()
                cell = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell.Data.DataItem = ""
                row.Cells.Add(cell)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 4 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(3).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row)

                Dim row1 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell1 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell1.Data.DataItem = "Fecha: " & FormatDateTime(Today, DateFormat.LongDate)
                cell1.StyleValue = "MyTitle2"
                row1.Cells.Add(cell1)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row1.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 3 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(2).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row1.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row1)

                Dim row2 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell2 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell2.Data.DataItem = lblStatus.Text
                cell2.StyleValue = "MyTitle2"
                row2.Cells.Add(cell2)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row2.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 2 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(1).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row2.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row2)

                Dim row3 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell3 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell3.Data.DataItem = "Resumen de Pronósticos, Programas y Gastos"
                cell3.StyleValue = "MyTitle1"
                row3.Cells.Add(cell3)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row3.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 1 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(RadGridTotales.Items(0).Cells(i).Text, "&nbsp;", "")
                        cell_totales.StyleValue = "MyStyleTotales2"
                        row3.Cells.Add(cell_totales)
                    Next
                End If

                e.Worksheet.Table.Rows.Insert(0, row3)

                Dim row4 As New Telerik.Web.UI.GridExcelBuilder.RowElement()
                Dim cell4 As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell4.Data.DataItem = "Cuenza. Control de Cuentas y Cobranza"
                cell4.StyleValue = "MyTitle"
                row4.Cells.Add(cell4)

                For i As Integer = 1 To 3
                    Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_vacia.Data.DataItem = ""
                    row4.Cells.Add(cell_vacia)
                Next

                If RadGridTotales.Items.Count >= 1 Then
                    For i As Integer = 2 To RadGridTotales.MasterTableView.ColumnSettings.Count - 1
                        Dim cell_totales As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_totales.Data.DataItem = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(RadGridTotales.MasterTableView.ColumnSettings(i).UniqueName, "12/", "Diciembre "), "11/", "Noviembre "), "10/", "Octubre "), "9/", "Septiembre "), "8/", "Agosto "), "7/", "Julio "), "6/", "Junio "), "5/", "Mayo "), "4/", "Abril "), "3/", "Marzo "), "2/", "Febrero "), "1/", "Enero ")
                        cell_totales.StyleValue = "MyStyleTotales1"
                        row4.Cells.Add(cell_totales)
                    Next
                End If

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

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                Dim cell2 As CellElement = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                e.Worksheet.Table.Columns.Add(New ColumnElement())
                cell2 = New CellElement()
                cell2.Data.DataItem = ""
                e.Row.Cells.Add(cell2)

                For Each column As ColumnElement In e.Worksheet.Table.Columns
                    If e.Worksheet.Table.Columns.IndexOf(column) = 0 Then
                        column.Attributes("ss:Width") = "300"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 1 Or e.Worksheet.Table.Columns.IndexOf(column) = 4 Or e.Worksheet.Table.Columns.IndexOf(column) = 5 Or e.Worksheet.Table.Columns.IndexOf(column) = 10 Or e.Worksheet.Table.Columns.IndexOf(column) = 11 Or e.Worksheet.Table.Columns.IndexOf(column) = 13 Or e.Worksheet.Table.Columns.IndexOf(column) = 14 Then
                        column.Attributes("ss:Width") = "161"
                        'ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 2 Or e.Worksheet.Table.Columns.IndexOf(column) = 3 Or e.Worksheet.Table.Columns.IndexOf(column) = 6 Or e.Worksheet.Table.Columns.IndexOf(column) = 7 Or e.Worksheet.Table.Columns.IndexOf(column) = 8 Or e.Worksheet.Table.Columns.IndexOf(column) = 9 Or e.Worksheet.Table.Columns.IndexOf(column) = 18 Or e.Worksheet.Table.Columns.IndexOf(column) = 19 Or e.Worksheet.Table.Columns.IndexOf(column) = 22 Then
                        'column.Attributes("ss:Width") = "109"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 12 Or e.Worksheet.Table.Columns.IndexOf(column) = 15 Or e.Worksheet.Table.Columns.IndexOf(column) = 16 Or e.Worksheet.Table.Columns.IndexOf(column) = 17 Or e.Worksheet.Table.Columns.IndexOf(column) = 20 Or e.Worksheet.Table.Columns.IndexOf(column) = 21 Then
                        column.Attributes("ss:Width") = "266"
                    Else
                        column.Attributes("ss:Width") = "109"
                    End If
                Next

                Dim vRow As RowElement = e.Worksheet.Table.Rows(8)
                vRow.Attributes("ss:Height") = 20
                vRow.Attributes("ss:InteriorStyle.Color") = "System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))"

                e.Worksheet.Name = "Pronósticos, Programas y Gastos"

                isConfigured = True
            End If
        End If

    End Sub
    Protected Sub RadGrid1_ExcelMLExportStylesCreated(ByVal source As Object, ByVal e As GridExportExcelMLStyleCreatedArgs) Handles RadGrid1.ExcelMLExportStylesCreated

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


        Dim borderM1 As BorderStyles = New BorderStyles()
        borderM1.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM1.Weight = 2
        borderM1.LineStyle = LineStyle.Continuous
        borderM1.PositionType = PositionType.Top

        Dim borderM2 As BorderStyles = New BorderStyles()
        borderM2.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM2.Weight = 2
        borderM2.LineStyle = LineStyle.Continuous
        borderM2.PositionType = PositionType.Bottom

        Dim borderM3 As BorderStyles = New BorderStyles()
        borderM3.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM3.Weight = 2
        borderM3.LineStyle = LineStyle.Continuous
        borderM3.PositionType = PositionType.Left

        Dim borderM4 As BorderStyles = New BorderStyles()
        borderM4.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(0, Byte), Integer))
        borderM4.Weight = 2
        borderM4.LineStyle = LineStyle.Continuous
        borderM4.PositionType = PositionType.Right


        Dim MyStyleTotales1 As New StyleElement("MyStyleTotales1")
        MyStyleTotales1.FontStyle.Bold = True
        MyStyleTotales1.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        MyStyleTotales1.FontStyle.Color = Drawing.Color.White
        MyStyleTotales1.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        MyStyleTotales1.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTotales1.Borders.Add(borderM1)
        MyStyleTotales1.Borders.Add(borderM2)
        MyStyleTotales1.Borders.Add(borderM3)
        MyStyleTotales1.Borders.Add(borderM4)
        e.Styles.Add(MyStyleTotales1)

        Dim MyStyleTotales2 As New StyleElement("MyStyleTotales2")
        MyStyleTotales2.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Right
        MyStyleTotales2.Borders.Add(border1)
        MyStyleTotales2.Borders.Add(border2)
        MyStyleTotales2.Borders.Add(border3)
        MyStyleTotales2.Borders.Add(border4)
        MyStyleTotales2.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        MyStyleTotales2.InteriorStyle.Pattern = InteriorPatternType.Solid
        MyStyleTotales2.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(165, Byte), Integer))
        e.Styles.Add(MyStyleTotales2)

        Dim masterTable As New StyleElement("masterTable")
        masterTable.FontStyle.Bold = True
        masterTable.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
        masterTable.FontStyle.Color = Drawing.Color.White
        masterTable.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
        masterTable.InteriorStyle.Pattern = InteriorPatternType.Solid
        masterTable.Borders.Add(borderM1)
        masterTable.Borders.Add(borderM3)
        masterTable.Borders.Add(borderM4)
        e.Styles.Add(masterTable)

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


        'myStyleMT
        'myStyleNumericMT
        'myStyleDecimalMT
        Dim myStyleMT As New StyleElement("myStyleMT")
        myStyleMT.Borders.Add(border1)
        myStyleMT.Borders.Add(border2)
        myStyleMT.Borders.Add(border3)
        myStyleMT.Borders.Add(border4)
        myStyleMT.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleMT.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(165, Byte), Integer))
        e.Styles.Add(myStyleMT)

        Dim myStyleNumMT As New StyleElement("myStyleNumericMT")
        myStyleNumMT.Borders.Add(border1)
        myStyleNumMT.Borders.Add(border2)
        myStyleNumMT.Borders.Add(border3)
        myStyleNumMT.Borders.Add(border4)
        myStyleNumMT.NumberFormat.Attributes("ss:Format") = "#,##0" ' "MM/dd"
        myStyleNumMT.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleNumMT.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(165, Byte), Integer))
        e.Styles.Add(myStyleNumMT)

        Dim myStyleDecMT As New StyleElement("myStyleDecimalMT")
        myStyleDecMT.Borders.Add(border1)
        myStyleDecMT.Borders.Add(border2)
        myStyleDecMT.Borders.Add(border3)
        myStyleDecMT.Borders.Add(border4)
        myStyleDecMT.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        myStyleDecMT.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleDecMT.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(230, Byte), Integer), CType(CType(165, Byte), Integer))
        e.Styles.Add(myStyleDecMT)

        Dim myStyle As New StyleElement("myStyle")
        myStyle.Borders.Add(border1)
        myStyle.Borders.Add(border2)
        myStyle.Borders.Add(border3)
        myStyle.Borders.Add(border4)
        e.Styles.Add(myStyle)

        Dim myStyleNum As New StyleElement("myStyleNumeric")
        myStyleNum.Borders.Add(border1)
        myStyleNum.Borders.Add(border2)
        myStyleNum.Borders.Add(border3)
        myStyleNum.Borders.Add(border4)
        myStyleNum.NumberFormat.Attributes("ss:Format") = "#,##0" ' "MM/dd"
        e.Styles.Add(myStyleNum)

        Dim myStyleDec As New StyleElement("myStyleDecimal")
        myStyleDec.Borders.Add(border1)
        myStyleDec.Borders.Add(border2)
        myStyleDec.Borders.Add(border3)
        myStyleDec.Borders.Add(border4)
        myStyleDec.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDec)


        For Each style As StyleElement In e.Styles

            If style.Id = "headerStyle" Then
                style.FontStyle.Bold = True
                style.AlignmentElement.HorizontalAlignment = HorizontalAlignmentType.Center
                style.InteriorStyle.Pattern = InteriorPatternType.Solid
                style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(140, Byte), Integer))
                
                '--------------------------------------------------
                ' Bordes
                '--------------------------------------------------
                Dim borderH1 As BorderStyles = New BorderStyles()
                borderH1.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH1.Weight = 2
                borderH1.LineStyle = LineStyle.Continuous
                borderH1.PositionType = PositionType.Top

                Dim borderH2 As BorderStyles = New BorderStyles()
                borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH2.Weight = 1
                borderH2.LineStyle = LineStyle.Continuous
                borderH2.PositionType = PositionType.Bottom

                Dim borderH3 As BorderStyles = New BorderStyles()
                borderH3.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH3.Weight = 2
                borderH3.LineStyle = LineStyle.Continuous
                borderH3.PositionType = PositionType.Left

                Dim borderH4 As BorderStyles = New BorderStyles()
                borderH4.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
                borderH4.Weight = 2
                borderH4.LineStyle = LineStyle.Continuous
                borderH4.PositionType = PositionType.Right
                style.Borders.Add(borderH1)
                style.Borders.Add(borderH2)
                style.Borders.Add(borderH3)
                style.Borders.Add(borderH4)

            End If

            'If style.Id.Contains("itemStyle") OrElse style.Id = "alternatingItemStyle" Then
            '    style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            'End If

            'If style.Id.Contains("myStyle") OrElse style.Id = "myStyleNumeric" OrElse style.Id = "myStyleDecimal" Then
            '    style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(185, Byte), Integer))
            'End If

        Next

    End Sub


    Public Sub EjemploEnvioCorreo()
        'Public Sub Correo()

        '    'Dim strPath As String = ""
        '    'If (Not HttpContext.Current.Request.Url Is Nothing) Then
        '    '    strPath = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, (HttpContext.Current.Request.Url.AbsoluteUri.ToLower.IndexOf(HttpContext.Current.Request.ApplicationPath.ToLower, CType((HttpContext.Current.Request.Url.AbsoluteUri.ToLower.IndexOf(HttpContext.Current.Request.Url.Authority.ToLower) + HttpContext.Current.Request.Url.Authority.Length), Integer)) + HttpContext.Current.Request.ApplicationPath.Length))
        '    'End If
        '    'strPath = strPath & "/"

        '    Dim urlTemplate As String = Server.MapPath("~/Plantillas/PronosticosProgramas.html")


        '    Dim Template As New StringBuilder
        '    Template.Append(GetHTMLFromAddress(urlTemplate))
        '    Template.Replace("$TITULO$", "Se ha agregado un pronóstico a su línea de servicio, favor de autorizarlo.")
        '    Template.Replace("$TituloClave$", "Clave del pronóstico")
        '    Template.Replace("$TituloLinea$", "Línea de servicio:")
        '    Template.Replace("$TituloQuienFactura$", "¿Quién factura?:")

        '    Template.Replace("$Clave$", "")
        '    Template.Replace("$idL$", "")
        '    Template.Replace("$Linea$", "")
        '    Template.Replace("$idQ$", "")
        '    Template.Replace("$QuienFactura$", "")
        '    Template.Replace("$idC$", "")
        '    Template.Replace("$Cliente$", "")
        '    Template.Replace("$idS$", "")
        '    Template.Replace("$Servicio$", "")
        '    Template.Replace("$Importe$", "")

        '    sendMail("paola.sanchez@cpamty.com", "rocio.garcia@cpaadvanzed.com", "Bienvenido al mundo .NET", Template.ToString)

        'End Sub
        'Public Shared Function GetHTMLFromAddress(ByVal Address As String) As String
        '    Dim ASCII As New System.Text.ASCIIEncoding
        '    Dim netWeb As New System.Net.WebClient
        '    Dim lsWeb As String
        '    Dim laWeb As Byte()

        '    Try
        '        laWeb = netWeb.DownloadData(Address)
        '        lsWeb = ASCII.GetString(laWeb)
        '    Catch ex As Exception
        '        Throw New Exception(ex.Message.ToString + ex.ToString)
        '    End Try
        '    Return lsWeb
        'End Function
        ''Public Shared Function GetApplicationPath() As String
        ''    Dim strPath As String = ""
        ''    If (Not HttpContext.Current.Request.Url Is Nothing) Then
        ''        strPath = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, (HttpContext.Current.Request.Url.AbsoluteUri.ToLower.IndexOf(HttpContext.Current.Request.ApplicationPath.ToLower, CType((HttpContext.Current.Request.Url.AbsoluteUri.ToLower.IndexOf(HttpContext.Current.Request.Url.Authority.ToLower) + HttpContext.Current.Request.Url.Authority.Length), Integer)) + HttpContext.Current.Request.ApplicationPath.Length))
        ''    End If
        ''    strPath = strPath & "/"
        ''    Return strPath
        ''End Function
        'Public Shared Function sendMail(ByVal strFrom As String, ByVal strTo As String, ByVal strSubject As String, ByVal strBody As String) As Boolean
        '    Try
        '        'Dim Email As New System.Net.Mail.MailMessage(strFrom, strTo)
        '        'Email.Subject = strSubject
        '        'Email.IsBodyHtml = True
        '        'Email.Body = strBody

        '        'Dim mailClient As New System.Net.Mail.SmtpClient()
        '        'Dim basicAuthenticationInfo As New System.Net.NetworkCredential("paola.sanchez@cpamty.com", "Pasa8512")
        '        'mailClient.Host = "mail.cpamty.com"
        '        'mailClient.UseDefaultCredentials = False
        '        'mailClient.Credentials = basicAuthenticationInfo
        '        'mailClient.Send(Email)

        '        Dim correo_From As String = "paola.sanchez@cpamty.com"
        '        Dim correo_to_1 As String = "rocio.garcia@cpamty.com"
        '        Dim correo_to_2 As String = "rocio.garcia@cpaadvanzed.com"
        '        Dim correo_to_3 As String = ""
        '        Dim correo_From_c As String = "Pasa8512"

        '        Dim correo As New System.Net.Mail.MailMessage
        '        correo.From = New System.Net.Mail.MailAddress(correo_From)
        '        correo.To.Add(correo_to_1)

        '        If correo_to_2 <> "" Then
        '            correo.To.Add(correo_to_2)
        '        End If
        '        If correo_to_3 <> "" Then
        '            correo.To.Add(correo_to_3)
        '        End If

        '        'correo.CC.Add(correo_From)

        '        correo.Subject = "Correo de prueba"
        '        correo.Body = strBody
        '        correo.IsBodyHtml = True
        '        correo.Priority = System.Net.Mail.MailPriority.Normal

        '        Dim smtp As New System.Net.Mail.SmtpClient
        '        smtp.Host = "mail.cpamty.com"
        '        smtp.Credentials = New System.Net.NetworkCredential(correo_From, correo_From_c)
        '        smtp.EnableSsl = False
        '        smtp.Port = 25
        '        smtp.Send(correo)


        '    Catch ex As Exception
        '        Return False

        '    End Try

        '    Return True
        'End Function

    End Sub

    Protected Sub RadGridTotales_ColumnCreated(sender As Object, e As GridColumnCreatedEventArgs) Handles RadGridTotales.ColumnCreated

        If e.Column.DataType.Name = "Decimal" Or e.Column.DataType.Name = "Double" Then
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).DataFormatString = "{0:N2}"
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).HeaderStyle.Width = 150
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).HeaderStyle.HorizontalAlign = HorizontalAlign.Center
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).ItemStyle.HorizontalAlign = HorizontalAlign.Right

            e.Column.HeaderText = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(e.Column.HeaderText, "12/", "Diciembre "), "11/", "Noviembre "), "10/", "Octubre "), "9/", "Septiembre "), "8/", "Agosto "), "7/", "Julio "), "6/", "Junio "), "5/", "Mayo "), "4/", "Abril "), "3/", "Marzo "), "2/", "Febrero "), "1/", "Enero ")

            'CType(e.Column, Telerik.Web.UI.GridBoundColumn).Groupable = True
            'CType(e.Column, Telerik.Web.UI.GridBoundColumn).Aggregate = Telerik.Web.UI.GridAggregateFunction.Sum
        End If

        If e.Column.UniqueName = "Estatus" Then
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).HeaderStyle.Width = 220
            CType(e.Column, Telerik.Web.UI.GridBoundColumn).HeaderStyle.HorizontalAlign = HorizontalAlign.Center
        End If

        '    If e.Column.UniqueName = "Estatus" Then
        '        Dim boundColumn As GridBoundColumn = CType(e.Column, GridBoundColumn)
        '        boundColumn.ReadOnly = True
        '        boundColumn.DataFormatString = "{0:d}"
        '    End If

    End Sub

End Class
