<%@ Page Language="VB" AutoEventWireup="false" CodeFile="aDefault.aspx.vb" Inherits="aDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1000px;
            height: 733px;
        }
        .auto-style4 {
            width: 100%;
        }
        .auto-style5 {
            height: 123px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" class="auto-style1">
            <tr>
                <td style="vertical-align:top; background-image: url('Imagenes/Fondo_Principal_01.png'); background-repeat: no-repeat">
                    <table cellpadding="0" cellspacing="0" class="auto-style4">
                        <tr>
                            <td class="auto-style5" style="height:100px; text-align:right; vertical-align:top; padding-right:10px; padding-top:10px;">
                                <asp:Image ID="Image1" runat="server" Height="60px" ImageUrl="~/Imagenes/Logo_ac_04.png" Width="180px" />
                            </td>
                        </tr>
                        <tr>
                            <td style="background-position: center; height:350px; background-image: url('Imagenes/Fondo_Identificarme.png'); background-repeat: no-repeat">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
