using Restaurant.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Restaurant.Menager
{
    public partial class Menager : System.Web.UI.Page
    {

        OperationMenager menager = OperationMenager.Singleton;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                CalendarReservation.SelectedDate = DateTime.Now.Date;
                fillBrojLjudi();
                fillTermini();
                fillReservations();
                fillNumberOfPeople();
                fillTermins();
            }          
        }

        private void fillTermins()
        {
            TerminiSelect selectTermini = new TerminiSelect();
            TerminiResult rez = this.menager.execute(selectTermini) as TerminiResult;
            if (rez.Success)
            {
                GridViewTimes.DataSource = rez.termini.ToList();

                GridViewTimes.DataBind();
            }
        }

        private void fillNumberOfPeople()
        {
            BrojLjudiSelect selectPeople = new BrojLjudiSelect();
            BrojLjudiResult rez = this.menager.execute(selectPeople) as BrojLjudiResult;
           
        }

        private void fillTermini()
        {
            TerminiSelect termini = new TerminiSelect();
            TerminiResult result = this.menager.execute(termini) as TerminiResult;
            if (result.Success)
            {
                DropDownListTermin.DataSource = result.termini;
                for (int i = 0; i < result.termini.Count; i++)
                {
                    DropDownListTermin.DataValueField = "Id";
                    DropDownListTermin.DataTextField = "vreme";
                }
                DropDownListTermin.DataBind();
            }
        }

        private void fillBrojLjudi()
        {
            BrojLjudiSelect ljudi = new BrojLjudiSelect();
            BrojLjudiResult result = this.menager.execute(ljudi) as BrojLjudiResult;
            if (result.Success)
            {
                 DropDownListBrojLJudi.DataSource = result.brojLjudi;
                for(int i=0;i<result.brojLjudi.Count;i++)
                {
                    DropDownListBrojLJudi.DataValueField = "IdBroj";
                    DropDownListBrojLJudi.DataTextField = "Broj";
                }
                DropDownListBrojLJudi.DataBind();
            }
        }
       
        private void fillReservations()
        {
            RezervazijaTerminSelect select = new RezervazijaTerminSelect();

            RezervacijaTerminResult result = this.menager.execute(select) as RezervacijaTerminResult;
            if (result.Success)
            {
                GridViewReservation.DataSource = result.Rezervacije.ToList();
              
                GridViewReservation.DataBind();
            }
        }

        protected void GridViewReservation_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
        }

        protected void DeleteReservation_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            RezervacijeDelete delete = new RezervacijeDelete { rezervacija = new RezervacijeItem { IdRez = Convert.ToInt32(deleteBtn.CommandArgument) } };
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillReservations();
            }
        }

        protected void UpdateReservation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                ButtonInsertUpdateReservation.Text = "Update reservation";
                Label1.Text = "Update reservation";
                RezervazijaTerminSelect select = new RezervazijaTerminSelect() { rezervacija = new RezervacijeItem { IdRez=id } };
                RezervacijaTerminResult rez = (RezervacijaTerminResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenFieldReservation.Value = rez.Rezervacije[0].IdRez.ToString();
                    TextBoxName.Text = rez.Rezervacije[0].Ime.ToString();
                    TextBoxEmail.Text = rez.Rezervacije[0].Mail.ToString();
                    CalendarReservation.SelectedDate = rez.Rezervacije[0].Datum;
                    TextBoxPoruka.Text = rez.Rezervacije[0].Poruka.ToString();
                    DropDownListBrojLJudi.SelectedValue = rez.Rezervacije[0].idBrojLJudi.ToString();
                    DropDownListTermin.SelectedValue = rez.Rezervacije[0].IdTerm.ToString();
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

        protected void ButtonInsertUpdateReservation_Click(object sender, EventArgs e)
        {
            if (ButtonInsertUpdateReservation.Text == "Make a reservation")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    RezervacijeInsert upis = new RezervacijeInsert { rezervacija = new RezervacijeItem { Ime = TextBoxName.Text, Mail = TextBoxEmail.Text, Datum = CalendarReservation.SelectedDate.Date, Poruka = TextBoxPoruka.Text, IdTerm = Convert.ToInt32(DropDownListTermin.SelectedValue), idBrojLJudi = Convert.ToInt32(DropDownListBrojLJudi.SelectedValue) } };
                    OperationResult rez = this.menager.execute(upis);
                    if (rez.Success)
                    {
                       LabelReservationResult.CssClass = "form-control";
                       LabelReservationResult.Visible = true;
                       LabelReservationResult.Text = "RESERVATION INSERTED";
                        TextBoxName.Text = String.Empty;
                        TextBoxEmail.Text = String.Empty;
                        DropDownListTermin.SelectedValue = "0";
                        DropDownListBrojLJudi.SelectedValue = "0";
                        TextBoxPoruka.Text = String.Empty;
                        fillReservations();
                    }
                }

            }
            if (ButtonInsertUpdateReservation.Text == "Update reservation")
            {
                 Button insert = (Button)sender;
                if (insert != null)
                {
                    RezervacijeUpdate updateRezervacije = new RezervacijeUpdate { rezervacija = new RezervacijeItem { Ime = TextBoxName.Text, Mail=TextBoxEmail.Text, Datum = CalendarReservation.SelectedDate.Date, Poruka = TextBoxPoruka.Text, IdTerm = Convert.ToInt32(DropDownListTermin.SelectedValue), idBrojLJudi = Convert.ToInt32(DropDownListBrojLJudi.SelectedValue), IdRez = Convert.ToInt32(HiddenFieldReservation.Value) } };            
                        OperationResult result = this.menager.execute(updateRezervacije);
                    LabelReservationResult.Visible = true;
                    if (result.Success)
                    {
                        LabelReservationResult.Text = "Successfully updated";
                        TextBoxName.Text = String.Empty;
                        TextBoxEmail.Text = String.Empty;
                        DropDownListTermin.SelectedValue = "0";
                        DropDownListBrojLJudi.SelectedValue = "0";
                        TextBoxPoruka.Text = String.Empty;
                        fillReservations();
                        ButtonInsertUpdateReservation.Text = "Make a reservation";                        
                    }
                    else
                    {
                        ButtonInsertUpdateReservation.Text = "Update failed";
                        ButtonInsertUpdateReservation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
                    }
                }
            }
        }

        protected void DeleteNumberOfPeople_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;

            BrojLjudiDelete delete = new BrojLjudiDelete { brojLjudi = new BrojLjudiItem { IdBroj=Convert.ToInt32(deleteBtn.CommandArgument) } };           
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillNumberOfPeople();
            }
        }

        protected void UpdateNumberOfPeople_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
               ButtonIsertUpdatePeople.Text = "Update Number";
                Label1.Text = "Update number";
                BrojLjudiSelect select = new BrojLjudiSelect() { brojLjudi = new BrojLjudiItem { IdBroj=id } };
                BrojLjudiResult rez = (BrojLjudiResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenFieldPeople.Value = rez.brojLjudi[0].IdBroj.ToString();

                    TextBoxPeople.Text = rez.brojLjudi[0].Broj.ToString();                    
                }
            }
        }

        protected void GridViewPeople_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;

        }
        protected void GridViewTimes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;           
        }

        protected void UpdateTime_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                ButtonInsertUpdateTime.Text = "Update Time Period";
                LabelTime.Text = "Update time";
                TerminiSelect select = new TerminiSelect() { termin = new TerminItem { Id=id } };
                TerminiResult rez = (TerminiResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenFieldTime.Value = rez.termini[0].Id.ToString();
                    TextBoxTime.Text = rez.termini[0].vreme.ToString();
                }
            }
        }

        protected void DeleteTime_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            TerminiDelete delete = new TerminiDelete { termin = new TerminItem { Id = Convert.ToInt32(deleteBtn.CommandArgument) } };         
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillTermins();
            }
        }
        
        protected void ButtonInsertUpdateTime_Click(object sender, EventArgs e)
        {
            if (ButtonInsertUpdateTime.Text == "Insert Time Period")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    TerminiInsert upis = new TerminiInsert { termin = new TerminItem { vreme = TimeSpan.Parse(TextBoxTime.Text) } };       
                    OperationResult rez = this.menager.execute(upis);
                    if (rez.Success)
                    {
                        LabelTimeResult.CssClass = "form-control";
                        LabelTimeResult.Visible = true;
                        LabelTimeResult.Text = "Time Period INSERTED";
                        TextBoxTime.Text = String.Empty;

                        fillTermins();
                    }
                }
            }
            if (ButtonInsertUpdateTime.Text == "Update Time Period")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    TerminiUpdate updateTermini = new TerminiUpdate { termin = new TerminItem { Id = Convert.ToInt32(HiddenFieldTime.Value), vreme = TimeSpan.Parse(TextBoxTime.Text) } };           
                    OperationResult result = this.menager.execute(updateTermini);
                    LabelTimeResult.Visible = true;
                    if (result.Success)
                    {
                        LabelTimeResult.Text = "Successfully updated";
                        TextBoxTime.Text = String.Empty;
                        fillTermins();
                        ButtonInsertUpdateTime.Text = "Insert Time Period";
                    }
                    else
                    {
                        ButtonInsertUpdateReservation.Text = "Update failed";
                        ButtonInsertUpdateReservation.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
                    }
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void GridViewTimes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[2].Text = "Time";
            }
        }

        protected void GridViewReservation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Name";
                e.Row.Cells[3].Text = "Email";
                e.Row.Cells[4].Text = "Date";
                e.Row.Cells[5].Text = "Message";
                e.Row.Cells[8].Text = "People";
                e.Row.Cells[9].Text = "Time";
            }
        }
    }
}