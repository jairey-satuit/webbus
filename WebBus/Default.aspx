<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebBus._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="container py-5 text-center">
        <h1 class="display-4">🎨 Color Picker Studio</h1>
        <p class="lead">Pick a color. Share it live. Watch the world update.</p>

        <hr class="my-4" />

        <div class="mb-4">
            <a href="PickColor.aspx" class="btn btn-primary btn-lg">Start Picking &raquo;</a>
        </div>

        <section class="mt-5">
            <h5>Powered by:</h5>
            <ul class="list-unstyled">
                <li>✅ ASP.NET Web Forms</li>
                <li>✅ Azure Service Bus (Pub/Sub)</li>
                <li>✅ Real-time color sync</li>
            </ul>
        </section>
    </main>
</asp:Content>
