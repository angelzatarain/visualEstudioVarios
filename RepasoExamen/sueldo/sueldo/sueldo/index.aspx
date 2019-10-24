<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="sueldo.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<br />
        Nombre vendedor:
        <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
    
        <br />
        <br />
        <asp:Button ID="bSiguiente" runat="server" Text="Siguiente" OnClick="bSiguiente_Click" />
    
        <br />
        <br />
        <asp:Button ID="bReporte" runat="server" Text="Reporte" OnClick="bReporte_Click" />

        </div>
    </form>
</body>
</html>
