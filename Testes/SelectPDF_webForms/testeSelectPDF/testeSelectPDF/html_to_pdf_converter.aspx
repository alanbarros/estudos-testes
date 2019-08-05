<%@ Page Language="C#" AutoEventWireup="true" CodeFile="html_to_pdf_converter.aspx.cs" Inherits="html_to_pdf_converter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblUrl" runat="server" Text="URL:"></asp:Label>
            <asp:TextBox ID="TxtUrl" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnCreatePdf" OnClick="BtnCreatePdf_Click" runat="server" Text="Criar PDF" />
        </div>
    </form>
</body>
</html>
