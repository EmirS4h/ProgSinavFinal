<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="Numara" runat="server"></asp:TextBox>
            <asp:Button ID="EkleBtn" runat="server" Text="EKLE File" OnClick="EkleBtn_Click" />
            <asp:Button ID="OkuBtn" runat="server" Text="OKU File" OnClick="OkuBtn_Click"/>
            <asp:Button ID="DegistirBtn" runat="server" Text="Değiştir File" OnClick="DegistirBtn_Click"/>
        </div>
        <div>
            <asp:Button ID="ListeleBtn" runat="server" Text="Listele SQL" OnClick="ListeleBtn_Click" />
            <asp:Button ID="EkleBtnSql" runat="server" Text="Ekle SQL" OnClick="EkleBtnSql_Click" />
        </div>
    </form>
</body>
</html>
