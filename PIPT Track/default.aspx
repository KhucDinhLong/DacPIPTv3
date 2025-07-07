<%@ Page Title="" Language="C#" MasterPageFile="~/TrackSite.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="PIPT.Track.dactrack" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Chống tràn hàng sản phẩm - Dược Việt Đức</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1>Chống tràn sản phẩm!</h1>
            <p>Bạn hãy nhập số an ninh để kiểm tra xuất xứ sản phẩm.</p>
        </div>
    </div>
    <!-- Thông tin truy vấn -->
    <asp:UpdatePanel ID="UpdatePanelLogin" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 col-md-6">
                        <h2>Nhập mã</h2>
                        <asp:TextBox ID="dacCode" runat="server" placeholder="Mã an ninh" CssClass="form-control"></asp:TextBox><br />
                        <asp:Button ID="btnKiemTra" Text="Kiểm tra" CssClass="btn btn-default" runat="server" OnClick="btnKiemTra_Click" />
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
                        <h2>Thông tin đại lý</h2>
                        <asp:Label ID="agencyLabel" runat="server" Text="Thông tin đại lý"></asp:Label>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-4">
                        <h2>Thông tin cửa hàng</h2>
                        <asp:Label ID="storeLabel" runat="server" Text="Thông tin cửa hàng"></asp:Label>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-4">
                        <h2>Thông tin sản phẩm</h2>
                        <asp:Label ID="productLabel" runat="server" Text="Thông tin sản phẩm"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
