<%@ Page Title="Autor" Language="C#" MasterPageFile="~/Restaurant.Master" AutoEventWireup="true" CodeBehind="Autor.aspx.cs" Inherits="Restaurant.Autor.Autor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="gallery" class="parallax-section">
	        <div class="container">
                        <div class="wrap-col">
                            <div >
                                <div class="col-lg-8">
                                     
                                    <asp:Image ImageUrl="~/images/1545727_10205685376990538_5980901426701663694_n.jpg" Width="480px" Height="480px"  ID="Image1" runat="server" />
                                </div>
                                <div class="col-lg-4">
                               
                               <p>Moje ime je Velibor Bogdanović rodjen sam 17 novembra 1994 godine u Beogradu.Završio sam srednju elektrotehničku školu "Nikola Tesla",smer elektrotehničar multimedija.
                                   Student sam zavrsne godine Visoke ICT škole </p>
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
