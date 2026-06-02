<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<head>
    <style type="text/css">
        .style1
        {
            width: 1200px;
            height: 276px;
        }
        .style2
        {
            width: 21px;
        }
        .style3
        {
            height: 149px;
            width: 1200px;
            background-color: #FFF4DF;
            border-color:#AAAAAA;
            border-width: 1px; 
            border-style: solid;
        }
        .style8
        {
        }
        .style12
        {
            width: 51%;
            height: 147px;
            margin-top: 0px;
        }
        .style13
        {
            width: 1200px;
        }
        #form1
        {
            width: 1200px;
        }
    </style>   
</head>
<form id="form1" runat="server">
    <table cellspacing="0" class="style1">
        <tr>
            <td class="style3">
                <table cellspacing="0" style="width: 100%; height: 100%; background-image: url('/Imagenes/Fondo_Cuenza_04.png'); background-repeat: no-repeat" >
                    <tr>
                        <td></td>
                    </tr>
                </table>
            </td>
            <td rowspan="3">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td style="background-color:#FFF4DF; background-image: url('../../Imagenes/FondoNaranja1.jpg'); background-repeat: no-repeat; border-left-style: solid; border-left-color: #AAAAAA; border-left-width: 1px; border-right-style: solid; border-right-width: 1px; border-right-color: #AAAAAA;" 
                class="style13">
                <table style="text-align:left;" cellspacing="0" class="style1">
                    <tr>
                        <td class="style2">
                            <asp:Image ID="Image2" runat="server" Height="203px" 
                                ImageUrl="~/Imagenes/user.png" Width="206px" />
                        </td>
                        <td class="style8" style="vertical-align:middle;">
                            <table cellspacing="0" class="style12">
                                <tr>
                                    <td colspan="2" 
                                        style="text-align:center; background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #FFFFFF;">
                                        <asp:Label ID="Label10" runat="server" Text="Inicio de sesión" Font-Names="Calibri" Font-Size="Large"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        &nbsp;
                                        <asp:Label ID="Label1" runat="server" Text="Usuario:" Font-Names="Arial Narrow"></asp:Label>
                                    </td>
                                    <td style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        <asp:TextBox ID="txtUsuario" runat="server" Width="128px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                            ControlToValidate="txtUsuario" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        &nbsp;
                                        <asp:Label ID="Label9" runat="server" Text="Contraseña:" 
                                            Font-Names="Arial Narrow"></asp:Label>
                                    </td>
                                    <td style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" 
                                            Width="128px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                            ControlToValidate="txtContraseña" ErrorMessage="*"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                                        </telerik:RadScriptManager>
                                    </td>
                                    <td style="padding-left:53px; text-align:left; background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        <asp:Button ID="btnLogin" runat="server" Cursor="Habd" BackColor="Black" BorderColor="Black" 
                                            BorderStyle="None" Font-Bold="False" ForeColor="White" Height="32px" 
                                            Text="Aceptar" Width="75px" style="cursor:hand;" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" 
                                        style="background-image: url('../../Imagenes/FondoNaranja2.jpg'); background-repeat: no-repeat">
                                        <asp:Label ID="lblMensaje" runat="server" Font-Names="Arial Narrow" 
                                            Font-Size="X-Small" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="style8" style="vertical-align:middle;">
                            &nbsp;</td>
                        <td class="style8" style="vertical-align:middle; width:20%;">
                            <asp:Image ID="Image3" runat="server" Height="257px" 
                                ImageUrl="~/Imagenes/Fachada2.jpg" Width="344px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style13" style="text-align:right; background-color:#EF6815; border-right-style: solid; border-left-style: solid; border-right-color: #AAAAAA; border-left-color: #AAAAAA; border-right-width: 1px; border-left-width: 1px; border-bottom-style: solid; border-bottom-width: 1px; border-bottom-color: #AAAAAA;">
                <asp:Label ID="Label2" runat="server" Font-Size="Small" ForeColor="White" 
                    Text="Todos los derechos reservados C.P. & A."></asp:Label>
            </td>
        </tr>
    </table>
</form>
