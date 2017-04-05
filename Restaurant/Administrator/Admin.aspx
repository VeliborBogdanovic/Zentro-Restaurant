<%@ Page Title="" Language="C#" MasterPageFile="~/Restaurant.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Restaurant.Administrator.Admin"  enableEventValidation="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="gallery" class="parallax-section">
	        <div class="container">
                <div class="col-lg-6" id="leftDiv">
		        <div class="row">
			 
                    
                        <h3>
                            <asp:Label ID="Label2" CssClass="cooksMargins" runat="server" Text="COOKS"></asp:Label>
                        </h3>
				         <asp:GridView Width="210px" OnRowDataBound="GridView1_RowDataBound" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridView1" runat="server"   OnRowCreated="GridView1_RowCreated">
                            <RowStyle   Wrap="false"/>
                             
                              <Columns>
                                  <asp:TemplateField HeaderText="Opcija"   ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="Update_Click" runat="server" Text="Update" ID="Update1" CommandName="Update" CommandArgument='<%# Eval("IdKuvar") %>'/>
                                        <asp:Button  Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="Delete_Click" runat="server" Text="Delete" ID="Delete1" CommandName="Delete" CommandArgument='<%# Eval("IdKuvar") %>'/>
                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  
                             </Columns>
				         </asp:GridView>
                        
                    </div>
                <div class="row">
                        
                     <div class="col-md-12 col-sm-12">
                         <h3>
                            <asp:Label ID="Label1" runat="server" Text="INSERT COOK"></asp:Label>
                        </h3>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ForeColor="Purple" ValidationGroup="cook">*</asp:RequiredFieldValidator>
                    <asp:TextBox Width="96%" PlaceHolder="Name of the Cook"  CssClass="form-control" ID="TextBox1" runat="server"></asp:TextBox>
                         <h5>&nbsp;<asp:Label ID="Label3" runat="server" Text="Photo"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:FileUpload ID="File1" runat="server"  />
                       &nbsp;</h5>
                         
                       <h5><asp:Label ID="Label4" runat="server" Text="Position"></asp:Label>
                            <asp:DropDownList ID="DropDownListPozicije" runat="server" AppendDataBoundItems="true" >
                                <asp:ListItem Text="Choose Position" Value="0" />
                            </asp:DropDownList>
                         </h5> 
                        <asp:HiddenField ID="HiddenField1" runat="server"  />
                        <asp:Button ValidationGroup="cook" Width="96%"  CssClass="form-control" ID="UpdateFinally" OnClick="UpdateFinally_Click" runat="server" Text="INSERT COOK" />
                        <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelResult" runat="server" Text="Label"></asp:Label>
		              </div>
                 </div>
                </div>
                <div class="col-lg-1 separator3" ></div>
                <div class="col-lg-3 text-center" id="centerDiv" >
                      <div class="row">
			            <h3>
                            <asp:Label ID="Label7" CssClass="positionsMargins1" runat="server" Text="COOKS POSITIONS"></asp:Label>
                        </h3>
				         <asp:GridView OnRowDataBound="GridViewPozicije_RowDataBound" Width="210px" CssClass="table-hover positionsMargins "  ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewPozicije" OnRowCreated="GridViewPozicije_RowCreated" runat="server"   >
                            <RowStyle   Wrap="false"/>
                              <Columns>
                                  <asp:TemplateField HeaderText="Opcija"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdatePositions_Click" runat="server" Text="Update" ID="UpdatePositions" CommandName="UpdatePositions" CommandArgument='<%# Eval("idPozicije") %>'/>
                                        <asp:Button  Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeletePositions_Click" runat="server" Text="Delete" ID="DeletePositions" CommandName="DeletePositions" CommandArgument='<%# Eval("idPozicije") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>
                     </div>
                    <div class="row">
                        
                     <div class="col-md-12 col-sm-12 insertPositionMargins">
                         <h3>
                            <asp:Label ID="LabelPositions" runat="server" Text="INSERT POSITION"></asp:Label>
                        </h3>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" Font-Bold="False" ControlToValidate="TextBoxPositionName" ForeColor="Purple" ValidationGroup="poz">*</asp:RequiredFieldValidator>
                            <asp:TextBox Width="96%" PlaceHolder="Name of the Position"  CssClass="form-control" ID="TextBoxPositionName" runat="server"></asp:TextBox><br/>
                            <asp:HiddenField ID="HiddenFieldPosition" runat="server"  />
                            <asp:Button Width="96%"  ValidationGroup="poz"  CssClass="form-control" ID="ButtonInsertUpdatePosition" OnClick="ButtonInsertUpdatePosition_Click" runat="server" Text="INSERT POSITION" />
                            <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelPositionResult" runat="server" Text="Label"></asp:Label>
		              </div>
                 </div>

                </div>
                 <div class="col-lg-1 separator3" ></div>
                <div class="col-lg-2" id="rightDiv">
                  <div class="row">
			        <div class="col-md-12 col-sm-12">
                        <h3>
                            <asp:Label ID="Label5" runat="server" CssClass="menagerMargins" Text="MENAGERS"></asp:Label>
                        </h3>
				         <asp:GridView OnRowDataBound="GridViewMenager_RowDataBound"  CssClass="table-hover table-responsive animated" ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewMenager" runat="server"   OnRowCreated="GridViewMenager_RowCreated">
                             <RowStyle Wrap="false" />
                             <Columns>
                                  <asp:TemplateField HeaderText="Opcija">
                                    <ItemTemplate>
                                        <asp:Button  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdateMenager_Click" runat="server" Text="Update" ID="UpdateMenager" CommandName="Update" CommandArgument='<%# Eval("Id") %>'/>
                                        <asp:Button BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeleteMenager_Click" runat="server" Text="Delete" ID="DeleteMenager" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'/>
                                    </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>
                        
                       
			        </div>
                    </div>
                    <div class="row">
                        
                     <div class="col-md-12 col-sm-12">
                         <h3>
                            <asp:Label ID="Label6" runat="server" Text="INSERT MENAGER"></asp:Label>
                        </h3>
                          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxIme" ForeColor="Purple" ValidationGroup="men">*</asp:RequiredFieldValidator>
                             <asp:TextBox Width="96%" PlaceHolder="Name of the Menager"  CssClass="form-control" ID="TextBoxIme" runat="server"></asp:TextBox><br/>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPrezime" ForeColor="Purple" ValidationGroup="men">*</asp:RequiredFieldValidator>  
                          <asp:TextBox Width="96%" PlaceHolder="LastName of the Menager"  CssClass="form-control" ID="TextBoxPrezime" runat="server"></asp:TextBox><br/>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxIskustvo" ForeColor="Purple" ValidationGroup="men">*</asp:RequiredFieldValidator>         
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="WrongFormat" ControlToValidate="TextBoxIskustvo" ForeColor="Purple" ValidationGroup="men" ValidationExpression="[0-9]{1,}"></asp:RegularExpressionValidator>
                         
                         <asp:TextBox Width="96%" PlaceHolder="Experience of the Cook (whole numbers)"  CssClass="form-control" ID="TextBoxIskustvo" runat="server"></asp:TextBox><br/>
   
                         <asp:HiddenField ID="HiddenField2" runat="server"  />
                        <asp:Button Width="96%" ValidationGroup="men" CssClass="form-control" ID="ButtonInsertUpdateMenager" OnClick="ButtonInsertUpdateMenager_Click" runat="server" Text="INSERT MENAGER" />
                        <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelMenagerResult" runat="server" Text="Label"></asp:Label>
		              </div>
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
