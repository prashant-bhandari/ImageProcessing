<%@ Page Language="C#" Inherits="ImageColor.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>Default</title>
</head>
<body>
	<form id="form1" runat="server">
			
				Upload an Image:
				<asp:FileUpload ID="FileUpload1" runat="server" /> 
				
		<asp:Button id="btnUpload" runat="server" Text="Upload" OnClick="btnUpload_Click" />
			
				<asp:Button ID="btnInvert" runat="server" Text="Invert Image Color" OnClick="btnInvert_Click" />
			<asp:Image ID="Img" runat="server" />
	</form>
</body>
</html>
