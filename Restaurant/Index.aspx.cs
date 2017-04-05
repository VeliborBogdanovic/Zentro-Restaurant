using Restaurant.BusinessLayer;
using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant
{
    public partial class Index : System.Web.UI.Page
    {
        OperationMenager menager =OperationMenager.Singleton;
       
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            Button insert = (Button)sender;
            if (insert != null)
            {
                RezervacijeInsert upis = new RezervacijeInsert { rezervacija = new RezervacijeItem { Ime = TextBoxName.Text, Mail = TextBoxEmail.Text, Datum = Calendar1.SelectedDate.Date, Poruka = TextBoxPoruka.Text, IdTerm = Convert.ToInt32(DropDownListTermin.SelectedValue), idBrojLJudi = Convert.ToInt32(DropDownListBrojLJudi.SelectedValue) } };
 
                OperationResult rez = this.menager.execute(upis);
                if (rez.Success)
                {
                    ReservationMessagge.CssClass = "form-control";
                    ReservationMessagge.Visible = true;
                    ReservationMessagge.Text = "RESERVATION CONFIRM";
                    TextBoxName.Text=String.Empty;
                    TextBoxEmail.Text=String.Empty;
                    DropDownListTermin.SelectedValue = "0";
                    DropDownListBrojLJudi.SelectedValue="0";
                    TextBoxPoruka.Text = String.Empty;
                }

            }
        }

        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {


            if (args.Value != "0")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        
        }
         protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {

            if (args.Value != "0")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        
        }

     
    }
}