
Imports System.IO
Imports Domain
Imports UsuariosBL
Imports System.Data
Imports Telerik.Web.UI
Imports Telerik.Web.UI.GridExcelBuilder

Partial Class ControlCobranza
    Inherits System.Web.UI.Page

#Region "Variables"

    Public oIng As New IngresosBL.IngresosBL

    Shared vLinea As String = ""
    Shared vImporte As Decimal
    Shared vIva As Decimal
    Shared vTotal As Decimal
    Shared vTotalPag As Decimal
    Shared vTotalRes As Decimal
    'Shared vRowA As Integer
    Shared vRowT As Integer

    Public vRowIn As Integer = 0

    Public vTitulo As Integer
    Private isConfigured As Boolean = False

    Public lU As New List(Of IUsuario)

    Shared mes, año, mes2, año2 As Integer
    Shared Usuario As String

    Public oLiS As New LineasServicioBL.LineasServicioBL
    Public v_DataTable As DataTable

    Shared id_Usuario, id_rol, id_linea_servicio, mesI, añoI, mesF, añoF As Integer
    Shared FToday As Date = Today()
    Shared Fini As Date
    Shared Ffin As Date
    
    Shared TipoFecha As String
    Shared Lineas As String
    Shared v_linea_actual As Integer

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
        
        '----------------------------------------------------------------------------------------------------
        '----------------------------------------------------------------------------------------------------
        FToday = Today()
        Fini = CType("01/" & mesI & "/" & añoI, Date)
        Ffin = CType(System.DateTime.DaysInMonth(RCBAñoF.SelectedValue, mesF) & "/" & mesF & "/" & añoF, Date)

        If Not Session("Status1") Is Nothing Then

            TipoFecha = Session("TipoFecha")

            CBTipoFecha1.Checked = IIf(TipoFecha = "fecha_fact", True, False)
            CBTipoFecha2.Checked = IIf(TipoFecha = "fecha_pago", True, False)

            Fini_f = IIf(TipoFecha = "fecha_fact", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            Ffin_f = IIf(TipoFecha = "fecha_fact", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")
            Fini_p = IIf(TipoFecha = "fecha_pago", Format(Fini, "dd/MM/yyyy"), "01/01/1900")
            Ffin_p = IIf(TipoFecha = "fecha_pago", Format(Ffin, "dd/MM/yyyy"), "01/01/1900")

        Else

            TipoFecha = "fecha_fact"

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
            'v_select = v_select & ", REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE([" & v_mes_actual & "/" & v_año_actual & "],'12/','Diciembre '),'11/','Noviembre '),'10/','Octubre '),'9/','Septiembre '),'8/','Agosto '),'7/','Julio '),'6/','Junio '),'5/','Mayo '),'4/','Abril '),'3/','Marzo '),'2/','Febrero '),'1/','Enero ')"

            If f_2 = v_total_meses Then
                v_pivot = v_pivot & "[" & v_mes_actual & "/" & v_año_actual & "]"
                v_totales = v_totales & " CASE WHEN [" & v_mes_actual & "/" & v_año_actual & "] IS NULL THEN 0 ELSE [" & v_mes_actual & "/" & v_año_actual & "] END "
            Else
                v_pivot = v_pivot & "[" & v_mes_actual & "/" & v_año_actual & "],"
                v_totales = v_totales & " CASE WHEN [" & v_mes_actual & "/" & v_año_actual & "] IS NULL THEN 0 ELSE [" & v_mes_actual & "/" & v_año_actual & "] END + "
            End If

        Next

        Dim v_data_table_totales As New DataTable
        v_data_table_totales = oIng.ExtraerIngresosTotalesBL(v_data_table_totales, Fini_f, Ffin_f, Fini_p, Ffin_p, 0, 2, 3, 0, 2, 0, 0, id_ls_1, id_ls_2, id_ls_3, id_ls_4, id_ls_5, id_ls_6, id_ls_7, id_ls_8, id_ls_9, id_ls_10, id_ls_11, id_ls_12, id_ls_13, id_ls_14, id_ls_15, id_ls_16, id_ls_17, id_ls_18, id_ls_19, id_ls_20, id_ls_21, id_ls_22, id_ls_23, id_ls_24, id_ls_25, id_ls_26, id_ls_27, id_ls_28, id_ls_29, id_ls_30, v_pivot, v_totales, v_select)
        'v_data_table_totales = oIng.ExtraerIngresosTotalesBL(v_data_table_totales, Fini_f, Ffin_f, Fini_p, Ffin_p, Status1, Status2, Status3, TipoFactura1, TipoFactura2, TipoFactura3, TipoFactura4, id_ls_1, id_ls_2, id_ls_3, id_ls_4, id_ls_5, id_ls_6, id_ls_7, id_ls_8, id_ls_9, id_ls_10, id_ls_11, id_ls_12, id_ls_13, id_ls_14, id_ls_15, id_ls_16, id_ls_17, id_ls_18, id_ls_19, id_ls_20, id_ls_21, id_ls_22, id_ls_23, id_ls_24, id_ls_25, id_ls_26, id_ls_27, id_ls_28, id_ls_29, id_ls_30, v_pivot, v_totales, v_select)

        RadGridTotales.DataSource = Nothing
        RadGridTotales.DataSource = v_data_table_totales
        RadGridTotales.DataBind()
        'RadGridTotales.Rebind()
        'RadGridTotales.MasterTableView.AllowRowResize = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            vLinea = ""
            vImporte = 0
            vIva = 0
            vTotal = 0
            vTotalPag = 0
            vTotalRes = 0
            'vRowA = 0
            vRowT = 0

            If Not Session("usuario") Is Nothing Then

                lU = Session("usuario")
                id_Usuario = lU.Item(0).id_usuario
                id_rol = lU.Item(0).id_rol
                id_linea_servicio = lU.Item(0).id_linea

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
        vTotalPag = 0
        vTotalRes = 0
        'vRowA = 0
        vRowT = 0

        ActualizarSqlDataSource1()
        ObtenerTotales()
        lblStatus.Text = "Facturas de: " & RCBMesI.SelectedItem.Value & " " & RCBAñoI.SelectedValue & " a " & RCBMesF.SelectedItem.Value & " " & RCBAñoF.SelectedValue

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


    Protected Sub RadToolBarReportes_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarReportes.ButtonClick
        lblMensaje.Text = ""
        GenerarReporte()
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
                     & "     INSERT INTO Bitacora VALUES ( '" & Today & "', '" & Format(Now, "hh:mm:ss") & "', '" & Usuario & "', 'Generó reporte de Cobranza', 0, " & id_linea_servicio & ")" _
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
                RadGrid1.ExportSettings.FileName = "Cobranza " & Today.Day & "-" & Right("0" & Today.Month, 2) & "-" & Today.Year
                RadGrid1.ExportSettings.OpenInNewWindow = True
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

        '  0 Clave                   id_ingreso             myDetailStyleNumeric     
        '  1 Importe total           importe_t              myDetailStyleDecimal     nuevo
        '  2 Concepto                concepto               myDetailStyle            266
        '  3 ¿Quién Factura?         nombre_empresa         myDetailStyle            161
        '  4 Línea de servicio       nombre_linea           myDetailStyle            161
        '  5 Cliente                 nombre_cliente         myDetailStyle            266
        '  6 Servicio                nombre_servicio        myDetailStyle            266
        '  7 Tipo de Moneda          TipoMoneda             myDetailStyle            
        '  8 Importe                 importe                myDetailStyleDecimal     
        '  9 IVA                     iva                    myDetailStyleDecimal     
        ' 10 Total                   total                  myDetailStyleDecimal     
        ' 11 Folio de factura        folio_factura          myDetailStyleNumeric     
        ' 12 Fecha de facturación    fecha_fact             myDetailStyle            
        ' 13 Fecha de pago           fecha_pago             myDetailStyle            
        ' 14 Total pagado            total_pagado           myDetailStyleDecimal     nuevo
        ' 15 Total restante          total_restante         myDetailStyleDecimal     nuevo
        ' 16 Estatus                 estatus  (colores)     myDetailStyleNumeric     nuevo
        ' 17 Pago 1                  pago_1                 myDetailStyleDecimal     
        ' 18 Pago 2                  pago_2                 myDetailStyleDecimal     
        ' 19 Pago 3                  pago_3                 myDetailStyleDecimal     
        ' 20 Pago 4                  pago_4                 myDetailStyleDecimal     
        ' 21 Pago 5                  pago_5                 myDetailStyleDecimal     


        If e.RowType = GridExportExcelMLRowType.DataRow Then

            If vRowT = 0 Then
                vRowT = RadGrid1.Items.Count + 7
            End If

            Dim vRowA As Integer = e.Worksheet.Table.Rows.Count

            Dim cell1 As CellElement = e.Row.Cells.GetCellByName("estatus")
            If Not cell1 Is Nothing Then
                Dim estatus As Integer = Val(cell1.Data.DataItem)
                Dim style As String = ""

                'style = "myStyleEstatus4" ' Rojo
                'style = "myStyleEstatus3" ' Naranja
                'style = "myStyleEstatus2" ' Amarillo
                'style = "myStyleEstatus1" ' Verde

                If estatus = 4 Then
                    style = "myStyleEstatus4" ' Rojo
                ElseIf estatus = 3 Then
                    style = "myStyleEstatus3" ' Naranja
                ElseIf estatus = 2 Then
                    style = "myStyleEstatus2" ' Amarillo
                Else
                    style = "myStyleEstatus1" ' Verde
                End If

                For Each cellElement As CellElement In e.Row.Cells
                    cellElement.StyleValue = style
                Next

            End If


            Dim cell2 As CellElement = e.Row.Cells.GetCellByName("id_ingreso")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("id_ingreso").StyleValue = "myDetailStyleNumeric"
            End If
            cell2 = e.Row.Cells.GetCellByName("importe_t")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("importe_t").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("concepto")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("concepto").StyleValue = "myDetailStyle"
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

                    For i As Integer = 1 To 7
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
                        cellrowlast = e.Row.Cells.GetCellByName("total_pagado")
                        If Not cellrowlast Is Nothing Then
                            vTotalPag = vTotalPag + cellrowlast.Data.DataItem
                        End If
                        cellrowlast = e.Row.Cells.GetCellByName("total_restante")
                        If Not cellrowlast Is Nothing Then
                            vTotalRes = vTotalRes + cellrowlast.Data.DataItem
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

                    For i As Integer = 1 To 3
                        Dim cell_L As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                        cell_L.Data.DataItem = ""
                        cell_L.StyleValue = "MyStyleLinea1"
                        row.Cells.Add(cell_L)
                    Next

                    Dim cell_Total_Pag As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Total_Pag.Data.DataItem = vTotalPag
                    cell_Total_Pag.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Total_Pag)

                    Dim cell_Total_Res As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                    cell_Total_Res.Data.DataItem = vTotalRes
                    cell_Total_Res.StyleValue = "MyStyleLinea2"
                    row.Cells.Add(cell_Total_Res)

                    For i As Integer = 1 To 5
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
                    vTotalPag = 0
                    vTotalRes = 0

                    vRowT = vRowT + 1
                End If

                vLinea = cell2.Data.DataItem

            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_cliente")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_cliente").StyleValue = "myDetailStyle"
            End If
            cell2 = e.Row.Cells.GetCellByName("nombre_servicio")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("nombre_servicio").StyleValue = "myDetailStyle"
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
            cell2 = e.Row.Cells.GetCellByName("total_pagado")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total_pagado").StyleValue = "myDetailStyleDecimal"
                vTotalPag = vTotalPag + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("total_restante")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("total_restante").StyleValue = "myDetailStyleDecimal"
                vTotalRes = vTotalRes + cell2.Data.DataItem
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_1")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_1").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_2")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_2").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_3")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_3").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_4")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_4").StyleValue = "myDetailStyleDecimal"
            End If
            cell2 = e.Row.Cells.GetCellByName("pago_5")
            If Not cell2 Is Nothing Then
                e.Row.Cells.GetCellByName("pago_5").StyleValue = "myDetailStyleDecimal"
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

                Dim cell_vacia As New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_vacia.Data.DataItem = ""
                row.Cells.Add(cell_vacia)

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

                cell_vacia = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_vacia.Data.DataItem = ""
                row1.Cells.Add(cell_vacia)

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

                cell_vacia = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_vacia.Data.DataItem = ""
                row2.Cells.Add(cell_vacia)

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
                cell3.Data.DataItem = "Reporte de Cobranza"
                cell3.StyleValue = "MyTitle1"
                row3.Cells.Add(cell3)

                cell_vacia = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_vacia.Data.DataItem = ""
                row3.Cells.Add(cell_vacia)

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

                cell_vacia = New Telerik.Web.UI.GridExcelBuilder.CellElement()
                cell_vacia.Data.DataItem = ""
                row4.Cells.Add(cell_vacia)
                
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

                Dim vCol As Integer = RadGridTotales.MasterTableView.ColumnSettings.Count

                If vCol > va Then
                    vCol = (vCol + 1) - va

                    For i As Integer = 0 To vCol
                        e.Worksheet.Table.Columns.Add(New ColumnElement())
                        Dim cell2 As CellElement = New CellElement()
                        cell2.Data.DataItem = ""
                        e.Row.Cells.Add(cell2)
                    Next
                End If

                For Each column As ColumnElement In e.Worksheet.Table.Columns
                    If e.Worksheet.Table.Columns.IndexOf(column) = 0 Then
                        column.Attributes("ss:Width") = "300"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 3 Or e.Worksheet.Table.Columns.IndexOf(column) = 4 Then
                        column.Attributes("ss:Width") = "161"
                    ElseIf e.Worksheet.Table.Columns.IndexOf(column) = 2 Or e.Worksheet.Table.Columns.IndexOf(column) = 5 Or e.Worksheet.Table.Columns.IndexOf(column) = 6 Then
                        column.Attributes("ss:Width") = "266"
                    Else
                        column.Attributes("ss:Width") = "109"
                    End If
                Next

                Dim vRow As RowElement = e.Worksheet.Table.Rows(6)
                vRow.Attributes("ss:Height") = 20
                'vRow.Attributes("ss:InteriorStyle.Color") = "System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))"

                e.Worksheet.Name = "Cobranza"

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



        'style = "myStyleEstatus4" ' Rojo
        'style = "myStyleEstatus3" ' Naranja
        'style = "myStyleEstatus2" ' Amarillo
        'style = "myStyleEstatus1" ' Verde

        Dim myStyleEstatus1 As New StyleElement("myStyleEstatus1")
        myStyleEstatus1.Borders.Add(border1)
        myStyleEstatus1.Borders.Add(border2)
        myStyleEstatus1.Borders.Add(border3)
        myStyleEstatus1.Borders.Add(border4)
        myStyleEstatus1.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleEstatus1.InteriorStyle.Color = System.Drawing.Color.Green
        myStyleEstatus1.FontStyle.Color = System.Drawing.Color.Green
        e.Styles.Add(myStyleEstatus1)

        Dim myStyleEstatus2 As New StyleElement("myStyleEstatus2")
        myStyleEstatus2.Borders.Add(border1)
        myStyleEstatus2.Borders.Add(border2)
        myStyleEstatus2.Borders.Add(border3)
        myStyleEstatus2.Borders.Add(border4)
        myStyleEstatus2.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleEstatus2.InteriorStyle.Color = System.Drawing.Color.Yellow
        myStyleEstatus2.FontStyle.Color = System.Drawing.Color.Yellow
        e.Styles.Add(myStyleEstatus2)

        Dim myStyleEstatus3 As New StyleElement("myStyleEstatus3")
        myStyleEstatus3.Borders.Add(border1)
        myStyleEstatus3.Borders.Add(border2)
        myStyleEstatus3.Borders.Add(border3)
        myStyleEstatus3.Borders.Add(border4)
        myStyleEstatus3.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleEstatus3.InteriorStyle.Color = System.Drawing.Color.Orange
        myStyleEstatus3.FontStyle.Color = System.Drawing.Color.Orange
        e.Styles.Add(myStyleEstatus3)

        Dim myStyleEstatus4 As New StyleElement("myStyleEstatus4")
        myStyleEstatus4.Borders.Add(border1)
        myStyleEstatus4.Borders.Add(border2)
        myStyleEstatus4.Borders.Add(border3)
        myStyleEstatus4.Borders.Add(border4)
        myStyleEstatus4.InteriorStyle.Pattern = InteriorPatternType.Solid
        myStyleEstatus4.InteriorStyle.Color = System.Drawing.Color.Red
        myStyleEstatus4.FontStyle.Color = System.Drawing.Color.Red
        e.Styles.Add(myStyleEstatus4)




        Dim myStyle As New StyleElement("myDetailStyle")
        myStyle.Borders.Add(border1)
        myStyle.Borders.Add(border2)
        myStyle.Borders.Add(border3)
        myStyle.Borders.Add(border4)
        e.Styles.Add(myStyle)

        Dim myStyleNum As New StyleElement("myDetailStyleNumeric")
        myStyleNum.Borders.Add(border1)
        myStyleNum.Borders.Add(border2)
        myStyleNum.Borders.Add(border3)
        myStyleNum.Borders.Add(border4)
        myStyleNum.NumberFormat.Attributes("ss:Format") = "###0" ' "MM/dd"
        e.Styles.Add(myStyleNum)

        Dim myStyleDec As New StyleElement("myDetailStyleDecimal")
        myStyleDec.Borders.Add(border1)
        myStyleDec.Borders.Add(border2)
        myStyleDec.Borders.Add(border3)
        myStyleDec.Borders.Add(border4)
        myStyleDec.NumberFormat.Attributes("ss:Format") = "#,##0.00"
        e.Styles.Add(myStyleDec)



        'Apply background colors 
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
                borderH2.Color = System.Drawing.Color.FromArgb(CType(CType(153, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(0, Byte), Integer))
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
            '    style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            'End If

            'If style.Id.Contains("myStyleStatus") Then
            '    style.InteriorStyle.Pattern = InteriorPatternType.Solid
            '    style.InteriorStyle.Color = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(140, Byte), Integer))
            'End If

        Next

    End Sub

    Protected Sub RadGrid1_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGrid1.ItemDataBound
        If (TypeOf e.Item Is GridDataItem) Then

            Dim dataItem As GridDataItem = CType(e.Item, GridDataItem)

            If (dataItem("Estatus").Text = "1") Then
                dataItem("Estatus").BackColor = Drawing.Color.Green
                dataItem("Estatus").ForeColor = Drawing.Color.Green
            ElseIf (dataItem("Estatus").Text = "2") Then
                dataItem("Estatus").BackColor = Drawing.Color.Yellow
                dataItem("Estatus").ForeColor = Drawing.Color.Yellow
            ElseIf (dataItem("Estatus").Text = "3") Then
                dataItem("Estatus").BackColor = Drawing.Color.Orange
                dataItem("Estatus").ForeColor = Drawing.Color.Orange
            ElseIf (dataItem("Estatus").Text = "4") Then
                dataItem("Estatus").BackColor = Drawing.Color.Red
                dataItem("Estatus").ForeColor = Drawing.Color.Red
            End If

        End If
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
