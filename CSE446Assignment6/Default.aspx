<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CSE446Assignment6._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <p>
            File Selection (Have to upload file then choose the file again to MapReduce):
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button1" runat="server" Text="Upload" OnClick="uploadFile" />
        </p>

        <p>
            Choose N, Number of Parallel Threads (N>=1):
            <asp:TextBox ID="TextBox1" runat="server" Text="1"></asp:TextBox>
        </p>

        <p>
            Web service for the map function (WSDL and localhost):
            <asp:Label ID="Label2" runat="server" Text="http://localhost:58763/Service1.svc"></asp:Label>
        </p>

        <p>
            Web service for the reduce function (WSDL and localhost):
            <asp:Label ID="Label3" runat="server" Text="http://localhost:58763/Service1.svc"></asp:Label>
        </p>

         <p>
            Web service for the combiner function (WSDL and localhost):
             <asp:Label ID="Label4" runat="server" Text="http://localhost:58763/Service1.svc"></asp:Label>
        </p>

        <p>
            <asp:Button ID="Button2" runat="server" Text="Perform Map/Reduce/Combine" OnClick="mainFunc" />
        </p>

        <p>
            Output:
        </p>

        <p>
            <asp:Label ID="Label5" runat="server" Text="Output"></asp:Label>
        </p>
    </main>

</asp:Content>
