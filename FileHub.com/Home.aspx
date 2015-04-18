<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FileHub.com.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:right">
     <asp:Label style="font-family:'Nova Square';font-size:larger" ID="lblGreet" runat="server" Text="Label" ForeColor="#CCCCCC"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
        <br /><br />
     <asp:Label ID="lblSpaceAllocated" runat="server" Text="Label" ForeColor="#CCCCCC" Font-Names="Nova Square"></asp:Label><br />
     <asp:Label ID="lblSpaceUsed" runat="server" Text="Label" ForeColor="#CCCCCC" Font-Names="Nova Square"></asp:Label><br />
     
   </div>
    <div>
        <table>
            <tr>
                <td>
                    <p class="perspective">
                    <asp:Button ID="btnSearch" CssClass="btn btn-7 btn-8d"  Width="200px" runat="server" Text="Search  " OnClick="btnSearch_Click"/>
                    </p><br />
                    <p class="perspective">
                    <asp:Button ID="btnUpload" CssClass="btn btn-7 btn-8d" Width="200px" runat="server" Text="Upload" OnClick="btnUpload_Click" />
                    </p><br />
                    <p class="perspective">
                    <asp:Button ID="btnFiles" CssClass="btn btn-7 btn-8d" Width="200px" runat="server" Text="Files" OnClick="btnFiles_Click" />
                    </p>
                </td>
                <td style="vertical-align:top">
                    <div>
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                        <table>
                            <tr>
                            <td style="vertical-align:bottom">
                              <asp:TextBox ID="txtSearch" CssClass="inputs" runat="server" placeholder="Search" Font-Size="Large" ForeColor="#666699" Height="40px" Width="500px"></asp:TextBox><br /><br />
                            </td>
                            <td style="vertical-align:middle">
                              <asp:Button ID="btnSearchFile" CssClass="btn btn-4 btn-4a icon-arrow-right" runat="server" Text="Search" OnClick="btnSearchFile_Click"/>
                            </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    
                                <asp:GridView ID="GridView1" Font-Names="Nova Square" runat="server" BackColor="Black" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="White" OnRowCommand="GridView1_RowCommand" Width="859px">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                    <Columns>
                                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download" HeaderText="Doanload" >
                                        <ControlStyle Font-Names="Nova Square" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>   
                                    </td>   
                            </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                    </div>
                </td>
                </tr>
        </table>
    </div>
</asp:Content>
