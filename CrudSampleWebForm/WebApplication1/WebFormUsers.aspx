<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebFormUsers.aspx.cs" Inherits="WebApplication1.WebFormUsers" EnableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     
<!-- Bootstrap -->
<script type="text/javascript" src='https://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.8.3.min.js'></script>
<script type="text/javascript" src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js'></script>

  <script type="text/javascript">
    function ShowDeleteModal() {
             $("#deleteModal").modal("show");
    }
</script>

    <br />
      <button type="button" runat ="server" onserverclick="AddClick"  class="btn btn-primary" ><span class="glyphicon glyphicon-plus"></span> Add User</button>
      
      
    <div class="table-responsive">
            <asp:GridView ID="gvList" runat="server" AllowPaging="True" AutoGenerateColumns="False"  Width="100%" CssClass="table table-striped" PageSize="20" onpageindexchanging="gvList_PageIndexChanging" OnRowCommand="gvList_RowCommand">
            <Columns>
               
                <asp:BoundField DataField="ID" HeaderText="ID">
                <HeaderStyle HorizontalAlign="Left" />
                <ItemStyle Width="100px" />
                </asp:BoundField>
              
                <asp:BoundField DataField="user_name" HeaderText="User Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="last_name" HeaderText="Last Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>
            
                <asp:BoundField DataField="first_name" HeaderText="First Name">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>

                 <asp:BoundField DataField="account_type" HeaderText="Account Type">
                <HeaderStyle HorizontalAlign="Left" />
                </asp:BoundField>

                <asp:BoundField DataField="Phone" HeaderText="Phone" />
                  <asp:BoundField DataField="email" HeaderText="Email" />
              
                <asp:TemplateField>
                    <ItemTemplate>
                       
                        <button type="button" id="updateButton" title="Edit" data-id ='<%# Eval("id")%>'  runat ="server" onserverclick="UpdateClick" class="btn btn-success btn-xs" data-toggle="modal" data-target="#edit"><span class="glyphicon glyphicon-edit"></span></button>
                     </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>

                        <asp:LinkButton runat="server" ID="deleteButton"  CommandName="DeleteCommand" class="btn btn-danger btn-xs">
                            <i class="glyphicon glyphicon-remove" aria-hidden="true"></i>
                        </asp:LinkButton>

                         <asp:HiddenField id="hfID" Value='<%# Eval("id")%>' runat="server" />
                        <asp:HiddenField id="hfItem" Value='<%# Eval("user_name")%>' runat="server" />

                      </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <PagerStyle CssClass="GridPager" />
        </asp:GridView>
    </div>

     <!-- /delete.modal-content --> 

    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="edit" aria-hidden="true" >
      <div class="modal-dialog">
    <div class="modal-content">
          <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></button>
        <h4 class="modal-title custom_align" id="Heading1">Reason for deletion </h4>
      </div>
          <div class="modal-body">
          <div class="form-group">
         <p> Are you sure to delete insurance provider <asp:Label ID="lblSelectedItem" runat="server" ClientIDMode ="Static" ></asp:Label> ? </p> <asp:HiddenField ID="HiddenFieldItem" ClientIDMode ="Static" runat="server" />
               
        </div>
       
      </div>
          <div class="modal-footer ">
                <asp:Button ID="btnOk" runat="server" Text="OK" class="btn btn-primary" CommandName="DelCommand" OnClick="DeleteButtonClick"/>
         <button type="button" id="closebutupdate" class="btn btn-danger" data-dismiss="modal"><span class="glyphicon glyphicon-remove"></span>Cancel</button>
      </div>
        </div>
  
  </div>
     
    </div>

    
</asp:Content>
