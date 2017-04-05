<%@ Page Title="Menager"  MaintainScrollPositionOnPostBack="true" EnableEventValidation="true" Language="C#" MasterPageFile="~/Restaurant.Master" AutoEventWireup="true" CodeBehind="Menager.aspx.cs" Inherits="Restaurant.Menager.Menager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
       
         function proveraTermin(objSource, objArgs) {
             if (objArgs.Value != "0") {
                 objArgs.IsValid = true;
             }
             else {
                 objArgs.IsValid = false;
             }
         }
         function proveraLjudi(objSource, objArgs) {
             if (objArgs.Value != "0") {
                 objArgs.IsValid = true;
             }
             else {
                 objArgs.IsValid = false;
             }
         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManger1" runat="Server">
</asp:ScriptManager>
   <section id="gallery" class="parallax-section">
	        <div class="container">
        <div class="col-lg-12">
                         <h3 >
                            <asp:Label ID="Label2" runat="server" Text="RESERVATIONS"></asp:Label>
				        </h3>
				         <asp:GridView  CausesValidation="False"  Width="210px" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewReservation" runat="server"   OnRowCreated="GridViewReservation_RowCreated" OnRowDataBound="GridViewReservation_RowDataBound">
                            <RowStyle   Wrap="false"/>
                              <Columns>
                                  
                                  <asp:TemplateField HeaderText="Opcija"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button CausesValidation="False" Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdateReservation_Click" runat="server" Text="Update" ID="UpdateReservation" CommandName="UpdateRezervation" CommandArgument='<%# Eval("IdRez") %>'/>
                                        <asp:Button   CausesValidation="False" Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeleteReservation_Click" runat="server" Text="Delete" ID="DeleteReservation" CommandName="DeleteReservation" CommandArgument='<%# Eval("IdRez") %>'/>
                                     </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>
                        </div>
                </div>
       </section>
        <!-- contact section -->
        <section id="contact" class="parallax-section">
	        <div class="container">
		        <div class="col-lg-12">
				        <h3 >
                            <asp:Label CssClass="ReservationMargin" ID="Label1" runat="server" Text="INSERT RESERVATION"></asp:Label>
				        </h3>				       
			        <div class="col-md-12 col-sm-12 wow fadeIn" data-wow-delay="0.3s">
                      <div class="col-lg-12 reservation">
                         <div class="col-md-6 col-sm-6 col-lg-6">
                           <asp:RequiredFieldValidator ValidationGroup="rez" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required" ControlToValidate="TextBoxName" Display="Static" ForeColor="Purple"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxName"  placeholder="Name" CssClass="form-control" runat="server"></asp:TextBox>
                       </div>
                         <div class="col-md-6 col-sm-6 col-lg-6">
                             <asp:RequiredFieldValidator ValidationGroup="rez"  ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required"  ControlToValidate="TextBoxEmail" ForeColor="Purple" Display="Static" ></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ValidationGroup="rez" Display="Static"  ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong Email Format" ForeColor="Purple" ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                             <asp:TextBox ID="TextBoxEmail"  placeholder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                         </div>
                        <div class="col-md-12 col-sm-12 " >
                            <div class="col-md-6 col-sm-6 reservation"  >
                                <div class="col-md-6 col-sm-6 reservation">
                                 <asp:CustomValidator ValidationGroup="rez" ID="CustomValidator1"  ClientValidationFunction="proveraTermin"
                                         runat="server" OnServerValidate="CustomValidator1_ServerValidate"
                                          ErrorMessage="Select Time" Display="Static" ForeColor="Purple" ControlToValidate="DropDownListTermin"
                                     ></asp:CustomValidator>
                                <asp:DropDownList   AppendDataBoundItems="true" ID="DropDownListTermin" OnClientClick="return " runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Choose" Value="0" />
                                </asp:DropDownList>

                                 </div>
                             
                                <div class="col-md-6 col-sm-6 ">
                                      <asp:CustomValidator ValidationGroup="rez" ID="CustomValidator2"  ClientValidationFunction="proveraLjudi"
                                           runat="server"  OnServerValidate="CustomValidator2_ServerValidate" 
                                          ErrorMessage="Select number of people" 
                                          Display="Static" ForeColor="Purple"
                                         ControlToValidate="DropDownListBrojLJudi" >

                                      </asp:CustomValidator>
                                    <asp:DropDownList AppendDataBoundItems="true" ID="DropDownListBrojLJudi" runat="server"  CssClass="form-control">
                                         <asp:ListItem Text="Choose" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 col-sm-12 reservation" >
                                    <asp:TextBox PlaceHolder="Message" CssClass="form-control" ID="TextBoxPoruka" TextMode="multiline" Columns="50" Rows="6" runat="server" />
                                </div>
                             </div>
                            <div class="col-md-4 col-sm-4">
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server" Height="650px">
                                  <ContentTemplate>
                                      <asp:Calendar  AutoPostback = "false" EnableViewState="true"  ID="CalendarReservation" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="250px">

                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt"></DayHeaderStyle>

                                    <NextPrevStyle VerticalAlign="Bottom" Font-Bold="True" Font-Size="8pt" ForeColor="#333333"></NextPrevStyle>

                                    <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>

                                    <SelectedDayStyle BackColor="#333399" ForeColor="White"></SelectedDayStyle>

                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="0px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399"></TitleStyle>

                                    <TodayDayStyle BackColor="#CCCCCC"></TodayDayStyle>
                                </asp:Calendar>                                      
                              </ContentTemplate>                                  
                              </asp:UpdatePanel>
                             </div>
                          </div>
                            <asp:Label ID="ReservationMessagge" runat="server" Text="" Visible="false"></asp:Label>
                             </div>
                        <div class="col-lg-12 col-md-12">
                            <asp:HiddenField ID="HiddenFieldReservation" runat="server" />
                        <asp:Button ValidationGroup="rez" Width="100%" OnClick="ButtonInsertUpdateReservation_Click" CssClass="form-control" ID="ButtonInsertUpdateReservation" runat="server" Text="Make a reservation" />
                             <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelReservationResult" runat="server" Text="Label"></asp:Label>
                            </div>
                             </div>     
			        <div class="col-md-2 col-sm-1"></div>
		        </div>
        </section>
    <section id="team" class="parallax-section">
	        <div class="container">
        <div class="col-lg-12 reservation">
            <div class="col-lg-5" id="leftDiv">
            <div class="col-lg-6 reservation">
                         <h3 >
                            <asp:Label CssClass="numberMargins" ID="Label3" runat="server" Text="Number Of People"></asp:Label>
				        </h3>                 
                <asp:GridView ID="GridView1"  Width="210px" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7"  runat="server" AutoGenerateColumns="False" DataKeyNames="IdBrojLjudi" DataSourceID="SqlDataSource1" >
                    <Columns>
                        <asp:CommandField HeaderText="Options" ShowEditButton="True" >
                            <ItemStyle BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" />
                        </asp:CommandField>
                        <asp:CommandField ShowDeleteButton="true" >
                            <ItemStyle Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" />
                        </asp:CommandField >
                        <asp:BoundField DataField="IdBrojLjudi" HeaderText="IdBrojLjudi" ReadOnly="True" InsertVisible="False" Visible="false" SortExpression="IdBrojLjudi"></asp:BoundField>
                        <asp:BoundField DataField="brojLjudi" HeaderText="Number" SortExpression="brojLjudi"></asp:BoundField>
                    </Columns>
                </asp:GridView>
                    </div>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" DeleteCommand="DELETE FROM [brojLjudi] WHERE [IdBrojLjudi] = @original_IdBrojLjudi AND (([brojLjudi] = @original_brojLjudi) OR ([brojLjudi] IS NULL AND @original_brojLjudi IS NULL))" InsertCommand="INSERT INTO [brojLjudi] ([brojLjudi]) VALUES (@brojLjudi)" OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [brojLjudi]" UpdateCommand="UPDATE [brojLjudi] SET [brojLjudi] = @brojLjudi WHERE [IdBrojLjudi] = @original_IdBrojLjudi AND (([brojLjudi] = @original_brojLjudi) OR ([brojLjudi] IS NULL AND @original_brojLjudi IS NULL))">
                    <DeleteParameters>
                        <asp:Parameter Name="original_IdBrojLjudi" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="original_brojLjudi" Type="Int32"></asp:Parameter>
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:Parameter Name="brojLjudi" Type="Int32"></asp:Parameter>
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="brojLjudi" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="original_IdBrojLjudi" Type="Int32"></asp:Parameter>
                        <asp:Parameter Name="original_brojLjudi" Type="Int32"></asp:Parameter>
                    </UpdateParameters>
                </asp:SqlDataSource>
            <div class="col-lg-6">
                    <h3 >
                         <asp:Label ID="Label4" runat="server"  Text="Insert Number"></asp:Label>
				     </h3>               
                <asp:TextBox Width="100%" CssClass="form-control" PlaceHolder="Insert Number of People" ID="TextBoxPeople" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPeople" ForeColor="Purple" ValidationGroup="broj" ErrorMessage="Wrong format" ValidationExpression="[0-9]{1,}"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxPeople" Text="*" ForeColor="Purple" ValidationGroup="broj"></asp:RequiredFieldValidator>

                <asp:Button ID="triggerButton" Visible="false" runat="server" Text="Button" ClientIDMode="Static"/>
                <asp:Button OnClientClick="return dugme();" UseSubmitBehavior="False" CssClass="form-control" ValidationGroup="broj"  ID="ButtonIsertUpdatePeople"  runat="server" Text="Insert Number" />
                <asp:HiddenField ID="HiddenFieldPeople" runat="server" />
                <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelResultPeople" runat="server" Text="Label"></asp:Label>
            </div>
                </div>
            <div class="col-lg-1 separator1" ></div>
            <div class="col-lg-6" id="rightDiv">
                <div class="col-lg-6 reservation">              
                         <h3 >
                            <asp:Label CssClass="timeMargins" ID="Label5" runat="server" Text="Time Periods"></asp:Label>
				        </h3>                 
				         <asp:GridView  CausesValidation="False"  Width="210px" CssClass="table-hover " ForeColor="#f0ad4e" BackColor="#337ab7" ID="GridViewTimes" runat="server" OnRowDataBound="GridViewTimes_RowDataBound"  OnRowCreated="GridViewTimes_RowCreated">
                            <RowStyle   Wrap="false"/>
                              <Columns>                                  
                                  <asp:TemplateField HeaderText="Options"  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="130px">
                                    <ItemTemplate>
                                        <asp:Button CausesValidation="False" Width="60px"  BackColor="#f0ad4e" BorderStyle="None" ForeColor="white" OnClick="UpdateTime_Click" runat="server" Text="Update" ID="UpdateTime" CommandName="UpdateTime" CommandArgument='<%# Eval("Id") %>'/>
                                        <asp:Button   CausesValidation="False" Width="60px" BackColor="#d9534f" BorderStyle="None" ForeColor="white" OnClick="DeleteTime_Click" runat="server" Text="Delete" ID="DeleteTime" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'/>
                                     </ItemTemplate>
                                </asp:TemplateField>
                             </Columns>
				         </asp:GridView>
                    </div>
            <div class="col-lg-6">
                    <h3 >
                         <asp:Label ID="LabelTime" runat="server" Text="Insert Time Period"></asp:Label>
				     </h3>               
                <asp:TextBox Width="100%" CssClass="form-control" PlaceHolder="Insert Time Period" ID="TextBoxTime" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Purple" Text="*" ControlToValidate="TextBoxTime" ValidationGroup="time"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Wrong Format" ValidationGroup="time" ValidationExpression="[0-9]{1,}:[0-9]{1,}:[0-9]{1,}" ForeColor="Purple" Display="Static" ControlToValidate="TextBoxTime"></asp:RegularExpressionValidator>
                <asp:Button UseSubmitBehavior="false"  ValidationGroup="time" CssClass="form-control" ID="ButtonInsertUpdateTime" OnClick="ButtonInsertUpdateTime_Click" runat="server" Text="Insert Time Period" />
                <asp:HiddenField ID="HiddenFieldTime" runat="server" />
                <asp:Label Visible="false" ForeColor="White" BackColor="#5cb85c" ID="LabelTimeResult" runat="server" Text="Label"></asp:Label>
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
                     <script type="text/javascript">
                         function dugme() {

                          
                             
                                 var val = $('#<%=TextBoxPeople.ClientID %>').val();
                               
                              $.ajax({

                                  type: "POST",
                                 
                                  url: "../Ajax.asmx/People",
                                  data: { 'val': val },
                                  success: function () {
                                      alert("Number inserted");
                                      location.reload();
                                      $('#<%=triggerButton.ClientID %>').click();
                                      return false;
                                      
                                  }
                                 
                                 })
                             
                         }
                        
    </script>
</asp:Content>
