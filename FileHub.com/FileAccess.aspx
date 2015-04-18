<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FileAccess.aspx.cs" Inherits="FileHub.com.FilesAccess" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div style="text-align:right; width: 100%;">
     <asp:Label style="font-family:'Nova Square';font-size:larger" ID="lblGreet" runat="server" Text="Label" ForeColor="#CCCCCC"></asp:Label>
     &nbsp;&nbsp;&nbsp;&nbsp;
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
                    <asp:Button ID="btnFiles" CssClass="btn btn-7 btn-8d" Width="200px" runat="server" Text="Files" />
                    </p>
                </td>
                <td style="vertical-align:top">
                    <div>
                        <table style="width:100%">
                            <tr>
                                <td>
                                    
                                <asp:GridView ID="GridView1" Font-Names="Nova Square" runat="server" BackColor="Black" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="White" Width="859px" OnRowCommand="GridView1_RowCommand" OnRowEditing="GridView1_RowEditing" OnRowUpdated="GridView1_RowUpdated">
                                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#242121" />
                                    <Columns>
                                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Download" HeaderText="Download" >
                                        <ControlStyle Font-Names="Nova Square" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:ButtonField>
                                        <asp:ButtonField ButtonType="Button" CommandName="ToggleAccess" HeaderText="Change Access" Text="Toggla Access">
                                        <ControlStyle Font-Names="nova Square" />
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                        </asp:ButtonField>
                                    </Columns>
                                </asp:GridView>   
                                    </td>   
                            </tr>
                            </table>
                    </div>
                </td>
                </tr>
        </table>

    </div>
</asp:Content>
