<%@ Page Title=""  MaintainScrollPositionOnPostBack="true" Language="C#" MasterPageFile="~/Restaurant.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Restaurant.Index" %>
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
    <section id="home" class="parallax-section">
	        <div class="container">
		        <div class="row">
			        <div class="col-md-12 col-sm-12">
				        <h1 >ZENTRO RESTAURANT</h1>
				        <h2>BEST FOOD &amp; ATMOSPHERE</h2>
				        <a href="#gallery" class="smoothScroll btn btn-default">LEARN MORE</a>
			        </div>
		        </div>
	        </div>		
      </section>


        <!-- gallery section -->
        <section id="gallery" class="parallax-section">
	        <div class="container">
		        <div class="row">
			        <div class="col-md-offset-2 col-md-8 col-sm-12 text-center" >
				        <h1 class="heading">Food Gallery</h1>
				        <hr/>
			        </div>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP (4) naziv, slika FROM Jela"></asp:SqlDataSource>

                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [naziv], [slika] FROM [Jela]"></asp:SqlDataSource>
                   <div class="col-md-8 col-sm-12 col-lg-12" >
                       <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1" RepeatColumns="2" Width="1000px">
                        <ItemTemplate>
                           <asp:HyperLink  ID="HyperLink1" runat="server"  NavigateUrl='<%# Eval("slika") %>'  data-lightbox-gallery="zenda-gallery">
                                <asp:Image  Width="600px" Height="370px" CssClass="FoodImage"  ID="Image2" runat="server" ImageUrl='<%# Eval("slika") %>' />
                            </asp:HyperLink>
                             <h3><asp:Label Text='<%# Eval("naziv") %>' runat="server" ID="nazivLabel" /></h3><br />
                            
                            <br />
                        </ItemTemplate>
                    </asp:DataList>
                    </div> 
             </div>
           </div>
        </section>
        <!-- menu section -->
        <section id="menu" class="parallax-section">
	        <div class="container">
		        <div class="row">
                    <div class="col-md-offset-2 col-md-8 col-sm-12 text-center">
				        <h1 class="heading">Special Menu</h1>
				        <hr>
			        </div>
                  <div class="col-md-offset-2 col-md-8 col-sm-12 ">
                      <asp:DataList ID="DataList2" runat="server" DataSourceID="SqlDataSource3" RepeatColumns="2" Width="100%">
                        <ItemTemplate>
                            <div class="col-lg-8">
                                <h4><asp:Label  Visible="<%# (Container.ItemIndex+1) % 3 == 1 %>" Text='<%# Eval("naziv") %>' runat="server" ID="nazivLabel" /></h4>
                             </div>
                             
                       <div class="col-lg-4">
                           <h4> <asp:Label  Visible="<%# (Container.ItemIndex+1) % 3 == 1 %>" Text='<%# Eval("cena")+"    $" %>' runat="server" ID="cenaLabel" /></h4>
                        </div>
                        </ItemTemplate>
                    </asp:DataList>
                  </div>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Jela.naziv, Jela.cena, Sastojci.naziv AS sastojak FROM Jela INNER JOIN Jela_Sastojci ON Jela.Id_jela = Jela_Sastojci.Id_jela INNER JOIN Sastojci ON Jela_Sastojci.Id_sastojka = Sastojci.Id_sastojka"></asp:SqlDataSource>
			    
	        </div>
        </section>		


        <!-- team section -->
        <section id="team" class="parallax-section">
	        <div class="container">
		        <div class="row ">
                    <div class="col-md-offset-2 col-md-8 col-sm-12 text-center kuvariNaslov">
				        <h1 class="heading">Our Staff</h1>
				        <hr>
			        </div>
			        <div class="col-md-offset-2 col-md-8 col-sm-12 text-center kuvari1" data-wow-delay="0.9s">
                       
                        <asp:DataList ID="DataList3" runat="server" RepeatColumns="3" DataKeyField="Id_kuvara" DataSourceID="SqlDataSource4">
                            <ItemTemplate>
                          
                                <asp:Image CssClass="slikaKuvara"  Width="350px"  ID="Image2" runat="server" ImageUrl='<%# Eval("slika") %>' />
                        
                              <h4>  <asp:Label Text='<%# Eval("ime") %>' runat="server" ID="imeLabel" /></h4>
                               
                              <h3>  <asp:Label Text='<%# Eval("naziv") %>' runat="server" ID="nazivLabel" /></h3>
                            </div>
                            </ItemTemplate>
                        </asp:DataList>
                         
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT TOP 3 * FROM Kuvari INNER JOIN Pozicije ON Kuvari.id_pozicija = Pozicije.Id_pozicija ORDER BY Kuvari.Id_kuvara"></asp:SqlDataSource>
			        </div>
			      </div>
                </div>
            </section>
        <!-- contact section -->
        <section id="contact" class="parallax-section">
	        <div class="container">
		        <div class="row">
			        <div class="col-md-offset-1 col-md-10 col-sm-12 text-center">
				        <h1 class="heading">Reserve Your Spot</h1>
				        <hr>
			        </div>
			        <div class="col-md-offset-1 col-md-10 col-sm-12 wow fadeIn" data-wow-delay="0.3s">
                      <div class="col-lg-12 reservation">
                         <div class="col-md-6 col-sm-6 col-lg-6">
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name is required" ControlToValidate="TextBoxName" Display="Static" ForeColor="Purple"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TextBoxName" placeholder="Name" CssClass="form-control" runat="server"></asp:TextBox>
                       </div>
                         <div class="col-md-6 col-sm-6 col-lg-6">
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Email is required"  ControlToValidate="TextBoxEmail" ForeColor="Purple" Display="Static" ></asp:RequiredFieldValidator>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong Email Format" ForeColor="Purple" ControlToValidate="TextBoxEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                             <asp:TextBox ID="TextBoxEmail"  placeholder="Email" CssClass="form-control" runat="server"></asp:TextBox>
                         </div>
                         </div>
                        <div class="col-md-12 col-sm-12 " >
                            <div class="col-md-6 col-sm-6 reservation"  >
                                <div class="col-md-6 col-sm-6 reservation">
                                 <asp:CustomValidator ID="CustomValidator1"  ClientValidationFunction="proveraTermin"
                                         runat="server" OnServerValidate="CustomValidator1_ServerValidate"
                                          ErrorMessage="Select Time" Display="Static" ForeColor="Purple" ControlToValidate="DropDownListTermin"
                                     ></asp:CustomValidator>
                                <asp:DropDownList   AppendDataBoundItems="true" ID="DropDownListTermin" OnClientClick="return " runat="server" DataSourceID="SqlDataSource5" DataTextField="vreme" DateFormatString="{0:g}"  DataValueField="Id_termin" CssClass="form-control">
                                    <asp:ListItem Text="Choose" Value="0" />
                                </asp:DropDownList>

                                 </div>
                             
                                <div class="col-md-6 col-sm-6 ">
                                      <asp:CustomValidator ID="CustomValidator2"  ClientValidationFunction="proveraLjudi"
                                           runat="server"  OnServerValidate="CustomValidator2_ServerValidate"
                                          ErrorMessage="Select number of people" 
                                          Display="Static" ForeColor="Purple"
                                         ControlToValidate="DropDownListBrojLJudi" >

                                      </asp:CustomValidator>
                                    <asp:DropDownList AppendDataBoundItems="true" ID="DropDownListBrojLJudi" runat="server" DataSourceID="SqlDataSource6" DataTextField="brojLjudi" DataValueField="IdBrojLjudi" CssClass="form-control">
                                         <asp:ListItem Text="Choose" Value="0" />
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-12 col-sm-12 reservation" >
                                    <asp:TextBox PlaceHolder="Message" CssClass="form-control" ID="TextBoxPoruka" TextMode="multiline" Columns="50" Rows="6" runat="server" />
                                </div>
                             </div>
                            <div class="col-md-6 col-sm-6 col-lg-6">
                                <div class="col-lg-8 col-md-6">
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server" Height="650px">
                                  <ContentTemplate>
                                      <asp:Calendar  AutoPostback = "false" EnableViewState="true" SelectedDate="<%# DateTime.Now.Date %>" ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="250px">

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
                                 <div class="col-lg-4 col-md-6">
           
                <ul class="result-poll"></ul>
            <div id="radio-clear">
                <asp:RadioButtonList Width="100%" CssClass=" text-center" ForeColor="#333333" BackColor="#c0c0c0"  RepeatColumns = "3" RepeatDirection="Vertical"  RepeatLayout="Table"   ID="RadioButtonList1" runat="server" >
                </asp:RadioButtonList>
                             </div>
                              </div>
                             </div>
                         
                            <asp:Label ID="ReservationMessagge" runat="server" Text="" Visible="false"></asp:Label>
                             </div>
                        <div class="col-lg-12 col-md-12">
                        <asp:Button Width="100%" OnClick="Button1_Click" CssClass="form-control" ID="Button1" runat="server" Text="Make a reservation" />
                            </div>
                  
                        <asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [brojLjudi]"></asp:SqlDataSource>
                         
                        

                        <asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Restaurant.mdf;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=30;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [Termini]"></asp:SqlDataSource>
                      
			        </div>
			        <div class="col-md-2 col-sm-1"></div>
		        </div>
	        </div>
        </section>


        <!-- footer section -->
        <footer class="parallax-section">
	        <div class="container">
		        <div class="row">
			        <div class="col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.6s">
				        <h2 class="heading">Contact Info.</h2>
				        <div class="ph">
					        <p><i class="fa fa-phone"></i> Phone</p>
					        <h4>090-080-0760</h4>
				        </div>
				        <div class="address">
					        <p><i class="fa fa-map-marker"></i> Our Location</p>
					        <h4>120 Duis aute irure, California, USA</h4>
				        </div>
			        </div>
			        <div class="col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.6s">
				        <h2 class="heading">Open Hours</h2>
					        <p>Sunday <span>10:30 AM - 10:00 PM</span></p>
					        <p>Mon-Fri <span>9:00 AM - 8:00 PM</span></p>
					        <p>Saturday <span>11:30 AM - 10:00 PM</span></p>
			        </div>
			        <div class="col-md-4 col-sm-4 wow fadeInUp" data-wow-delay="0.6s">
				        <h2 class="heading">Follow Us</h2>
				        <ul class="social-icon">
					        <li><a href="#" class="fa fa-facebook wow bounceIn" data-wow-delay="0.3s"></a></li>
					        <li><a href="#" class="fa fa-twitter wow bounceIn" data-wow-delay="0.6s"></a></li>
					        <li><a href="#" class="fa fa-behance wow bounceIn" data-wow-delay="0.9s"></a></li>
					        <li><a href="#" class="fa fa-dribbble wow bounceIn" data-wow-delay="0.9s"></a></li>
					        <li><a href="#" class="fa fa-github wow bounceIn" data-wow-delay="0.9s"></a></li>
				        </ul>
			        </div>
		        </div>
	        </div>
            
            
        </footer>
    
        <!-- JAVASCRIPT JS FILES -->	
        <script src="js/jquery.js"></script>
        <script src="js/bootstrap.min.js"></script>
        <script src="js/jquery.parallax.js"></script>
        <script src="js/smoothscroll.js"></script>
        <script src="js/nivo-lightbox.min.js"></script>
        <script src="js/wow.min.js"></script>
        <script src="js/custom.js"></script>
        <script src="js/custom.js"></script>
    <%--<script type="text/javascript">
        $(document).ready(function () {
            
            $(":radio").click(function () {
                var val = $(this).val();
                $('#radio-clear').html("");
                $.ajax({
                    type: "POST",
                    url: "Ajax.asmx/ajaxPoll",
                    data: { 'val': val },
                    success: function (msg) {
                       
                        msg.forEach(function (entry) {
                            entry = entry.split("@");
                            $('.result-poll').append("<li>" + entry[0] + " : " + entry[1] + "</li>");
                        })
                    }
                })
            });

        });
    </script>--%>
</asp:Content>
