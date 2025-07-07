<%@ Page Title="" Language="C#" MasterPageFile="~/TrackSite.Master" AutoEventWireup="true" CodeBehind="getserialbydaccode.aspx.cs" Inherits="PIPT.Track.getserialbydaccode" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tìm số serial theo mã an ninh - Dược Việt Đức</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>Tìm lại số serial!</h1>
            <p>Bạn hãy nhập số an ninh để kiểm tra số serial của nó!</p>
        </div>
    </div>
        <!-- Thông tin truy vấn -->
    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        <h2>Nhập mã an ninh</h2>
                        <asp:TextBox ID="dacCode" runat="server" placeholder="Mã an ninh" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="btnGetSerial" Text="Lấy số Serial" CssClass="btn btn-default" runat="server" OnClick="btnGetSerial_Click" />
                    </div>
                    <div class="col-sm-12 col-md-6">
                        <br />
                        <br />
                        <asp:Label ID="thongBaoLabel" runat="server" Text="Thông báo" Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
            <!-- Thể hiện kết quả -->
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-4">
                        <h2>Số Serial của mã</h2>
                        <asp:Label ID="serialLabel" runat="server" Text="Số Serial"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
