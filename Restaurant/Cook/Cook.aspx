<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant.Master" AutoEventWireup="true" CodeBehind="Cook.aspx.cs" Inherits="Restaurant.Cook.Cook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="gallery" class="parallax-section">
	        <div class="container">
                <div class="col-lg-8" id="leftDiv">
		        <div class="row">
			           <h3>
                            <asp:Label ID="Labeljela" runat="server" Text="Food"></asp:Label>
                        </h3>
				         <asp:GridView OnRowDataBound="GridViewJela_RowDataBound" OnRowDeleting="GridViewJela_RowDeleting" OnRowUpdating="GridViewJela_RowUpdating" GridLines="Both" onRowCreated="GridViewJela_RowCreated" Width="210px" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewJela" runat="server"  >
                            <RowStyle   Wrap="false"/>
                             
                              <Columns>
                                  <asp:TemplateField HeaderText="Options"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdateJela_Click" runat="server" Text="Update" ID="UpdateJela" CommandName="UpdateDish" CommandArgument='<%# Eval("IdJela") %>'/>
                                        <asp:Button  Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeleteJela_Click" runat="server" Text="Delete" ID="DeleteJela" CommandName="DeleteDish" CommandArgument='<%# Eval("IdJela") %>'/>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>
                        
                       
			       
                    </div>
                     </div>
                <div class="separator2 col-lg-1" ></div>
                 <div class="col-lg-2" id="rightDiv">
                <div class="row">
                        
                     <div class="col-md-12 col-sm-12">
                         <h3>
                            <asp:Label ID="Label1" runat="server" Text="INSERT FOOD"></asp:Label>
                        </h3>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxIme" ForeColor="Purple" ValidationGroup="jelo">*</asp:RequiredFieldValidator>
                         <asp:TextBox  PlaceHolder="Name of food"  CssClass="form-control" ID="TextBoxIme" runat="server"></asp:TextBox>
                            <h5><asp:Label ID="Label3" runat="server" Text="Photo"></asp:Label> 
                             <asp:FileUpload ID="FileSlika" runat="server"  />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong Format" ForeColor="Purple" ControlToValidate="TextBoxCena" ValidationExpression="[0-9]{1,}.[0-9]{1,}" ValidationGroup="jelo"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Purple" Text="*" ControlToValidate="TextBoxCena" ValidationGroup="jelo"></asp:RequiredFieldValidator>
                                 <asp:TextBox  PlaceHolder="Price ($)"  CssClass="form-control" ID="TextBoxCena" runat="server"></asp:TextBox>
                             <asp:Label ID="LabelAkcija" runat="server" Text="On action?"></asp:Label></h5> 
                             <asp:CheckBox ID="CheckBoxAkcija" runat="server" />
                             <h2>
                                 <asp:Label ID="Label2" runat="server" Text="Ingredients"></asp:Label>

                             </h2>
                             <asp:CheckBoxList ID="CheckBoxListSastojci" runat="server" >

                             </asp:CheckBoxList>
                         
                      
                        <asp:HiddenField ID="HiddenField1" runat="server"  />
                        <asp:Button ValidationGroup="jelo"  CssClass="form-control" ID="UpdateInsertDish" OnClick="UpdateInsertDish_Click" runat="server" Text="INSERT DISH" />
                        <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelResult" runat="server" Text="Label"></asp:Label>
		              </div>
                 </div>
               </div>
                
                
                 
	        </div>	
        <div class="container">
            <hr class="zaHR"/>
             <div class="col-lg-8" id="leftDiv">
		        <div class="row" id="forMargins">			    
                        <h3>
                            <asp:Label ID="LabelSastojci" runat="server" Text="Ingredients"></asp:Label>
                        </h3>                   
				         <asp:GridView OnRowDataBound="GridViewSastojci_RowDataBound"  GridLines="Both" onRowCreated="GridViewSastojci_RowCreated" Width="210px" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewSastojci" runat="server"  >
                            <RowStyle   Wrap="false"/>
                             
                              <Columns>
                                  <asp:TemplateField HeaderText="Opcija"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdateSastojak_Click" runat="server" Text="Update" ID="UpdateSastojak" CommandName="UpdateSastojak" CommandArgument='<%# Eval("IdSastojka") %>'/>
                                        <asp:Button  Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeleteSastojak_Click" runat="server" Text="Delete" ID="DeleteSastojak" CommandName="DeleteSastojak" CommandArgument='<%# Eval("IdSastojka") %>'/>
                                      
                                    </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>                    
                    </div>
                     </div>
                <div class="separator2 col-lg-1" ></div>
            
                 <div class="col-lg-3" id="centerDiv">
                     
                <div class="row">
                        
                     <div class="col-md-12 col-sm-12">
                         <h3>
                            <asp:Label ID="LabelSastojakkkk" runat="server" Text="INSERT INGREDIENT"></asp:Label>
                        </h3>
                             <asp:TextBox  PlaceHolder="Name of Ingredient"  CssClass="form-control" ID="TextBoxSastojak" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxSastojak" ForeColor="Purple" ValidationGroup="Sastojak">*</asp:RequiredFieldValidator>
                        <asp:HiddenField ID="HiddenFieldSas" runat="server"  />
                        <asp:Button  ValidationGroup="Sastojak" CssClass="form-control" ID="InsertUpdateSastojak" OnClick="InsertUpdateSastojak_Click" runat="server" Text="INSERT INGREDIENT" />
                        <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelResultSastojak" runat="server" Text="Label"></asp:Label>
		              </div>
                     </div>

        </div>	
      </section>

     <script src="../js/jquery.js"></script>
        <script src="../js/bootstrap.min.js"></script>
        <script src="../js/jquery.parallax.js"></script>
        <script src="../js/smoothscroll.js"></script>
        <script src="../js/nivo-lightbox.min.js"></script>
        <script src="../js/wow.min.js"></script>
        <script src="../js/custom.js"></script>
        <script src="../js/custom.js"></script>
</asp:Content>
