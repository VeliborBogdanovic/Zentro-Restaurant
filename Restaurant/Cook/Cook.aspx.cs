using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.DataLayer;
using Restaurant.BusinessLayer;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.IO;

namespace Restaurant.Cook
{
    public partial class Cook : System.Web.UI.Page
    {
        OperationMenager menager = OperationMenager.Singleton;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDishes();
                fillSastojci();
                fillIngredients();
            }
        }

        private void fillIngredients()
        {
            SastojciSelect selectSastojci = new SastojciSelect();
            SastojciResult rez = this.menager.execute(selectSastojci) as SastojciResult;
            if (rez.Success)
            {
                GridViewSastojci.DataSource = rez.sastojci.ToList();
                GridViewSastojci.DataBind();
            }
        }

        private void fillSastojci()
        {
            SastojciSelect sastojciSelect = new SastojciSelect();
            SastojciResult rezultat = this.menager.execute(sastojciSelect) as SastojciResult;
            if (rezultat.Success)
            {
                CheckBoxListSastojci.DataSource = rezultat.sastojci;
                for (int i = 0; i < rezultat.sastojci.Count; i++)
                {
                    CheckBoxListSastojci.DataValueField = "IdSastojka";
                    CheckBoxListSastojci.DataTextField = "NazivSastojka";
                }
                CheckBoxListSastojci.DataBind();
            }
        }

        private void fillDishes()
        {
            JelaSastojciSelect jelaSelect = new JelaSastojciSelect();
            JelaSastojciResult rezultat = this.menager.execute(jelaSelect) as JelaSastojciResult;
            if (rezultat.Success)
            {
                GridViewJela.DataSource = rezultat.JelaSastojci.ToList();
                GridViewJela.DataBind();
            }
            for (int count = 0; count < GridViewJela.Rows.Count; count++)
            {
                if (GridViewJela.Rows[count].Cells[3].Text != string.Empty)
                {
                    GridViewJela.Rows[count].Style.Add("border-bottom-color", "black");
                }
            }
        }
        protected void GridViewJela_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Text = "Sastojci";
            for (int count = 0; count < GridViewJela.Rows.Count; count++)
            {
                if (count % 3 == 0 || count % 3 == 1)
                {
                    GridViewJela.Rows[count].Cells[0].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[1].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[2].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[3].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[4].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[5].Text = string.Empty;
                    GridViewJela.Rows[count].Cells[6].Text = string.Empty;
                }
            }
        }

        protected void UpdateJela_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                UpdateInsertDish.Text = "UPDATE DISH";
                Label1.Text = "UPDATE DISH";
                JelaSastojciSelect select = new JelaSastojciSelect() { jelosastojak = new JelaSastojciItem { IdJela = id } };
                JelaSastojciResult rez = (JelaSastojciResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenField1.Value = rez.JelaSastojci[0].IdJela.ToString();
                    string oldImage = rez.JelaSastojci[0].Slika;
                    FileInfo info = new FileInfo(Server.MapPath(oldImage));
                    if (info.Exists)
                    {
                        File.Delete(Server.MapPath(oldImage));
                    }
                    TextBoxIme.Text = rez.JelaSastojci[0].Naziv;
                    TextBoxCena.Text = rez.JelaSastojci[0].Cena.ToString();
                    CheckBoxAkcija.Checked = (bool)rez.JelaSastojci[0].akcija;
                    for (int i = 0; i < rez.JelaSastojci.Count; i++)
                    {
                        for (int j = 0; j < CheckBoxListSastojci.Items.Count; j++)
                        {
                            if (CheckBoxListSastojci.Items[j].Value == rez.JelaSastojci[i].IdSastojka.ToString())
                            {
                                CheckBoxListSastojci.Items[j].Selected = true;
                            }
                        }
                    }                    
                }
            }
        }

        protected void DeleteJela_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            JelaSastojciDelete deleteJela = new JelaSastojciDelete { jelo = new JelaItem { IdJela = Convert.ToInt32(deleteBtn.CommandArgument) } };
            //JelaSastojciSelect select = new JelaSastojciSelect() { Id = deleteJela.id };
            JelaSastojciSelect select = new JelaSastojciSelect { jelosastojak = new JelaSastojciItem { IdJela = deleteJela.jelo.IdJela } };
            JelaSastojciResult rez = (JelaSastojciResult)menager.execute(select);
            String slika = rez.JelaSastojci[0].Slika.ToString();
            FileInfo info = new FileInfo(Server.MapPath(slika));
            if (info.Exists)
            {
                File.Delete(Server.MapPath(slika));
            }
            OperationResult rezultat = this.menager.execute(deleteJela);
            if (rezultat.Success)
            {
                fillDishes();
            }
        }
        protected void UpdateInsertDish_Click(object sender, EventArgs e)
        {
            if (UpdateInsertDish.Text == "UPDATE DISH")
            {
                int idJela = Convert.ToInt32(HiddenField1.Value);
                JelaSastojciSelect select = new JelaSastojciSelect() { jelosastojak = new JelaSastojciItem { IdJela = idJela } };
                JelaSastojciResult rez = (JelaSastojciResult)menager.execute(select);
                string NazivJela = TextBoxIme.Text;
                double Cena = Convert.ToDouble(TextBoxCena.Text);
                bool Akcija = CheckBoxAkcija.Checked;
                IEnumerable<ListItem> kolekcija = CheckBoxListSastojci.Items.Cast<ListItem>()
                .Where(li => li.Selected);
                string Slika = "";
                if ((FileSlika.PostedFile != null) && (FileSlika.PostedFile.ContentLength > 0))
                {
                    Random rnd = new Random();
                    string uid = rnd.Next(10000000).ToString();
                    string fn = System.IO.Path.GetFileName(FileSlika.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~/images/") + "" + uid + fn;

                    Slika = "~/images/" + uid + fn;
                    string fileExtention = FileSlika.PostedFile.ContentType;
                    int fileLenght = FileSlika.PostedFile.ContentLength;
                    FileSlika.SaveAs(SaveLocation);

                }
                JelaUpdate updateJela = new JelaUpdate { jelo = new JelaItem { IdJela = idJela, Slika = Slika, Akcija = Akcija, Cena = Cena, NazivJela = NazivJela } };
                OperationResult result = this.menager.execute(updateJela);
                SqlConnection konekcija = new SqlConnection(WebConfigurationManager.ConnectionStrings["logovanjeString"].ConnectionString);
                SqlCommand komanda1 = new SqlCommand("SELECT TOP 1 Id_jela FROM Jela ORDER BY Id_jela DESC");
                komanda1.Connection = konekcija;
                SqlCommand komanda2 = new SqlCommand("DELETE FROM Jela_Sastojci WHERE Id_jela=@idJela ");
                komanda2.Connection = konekcija;
                komanda2.Parameters.AddWithValue("idJela", idJela);
                komanda2.Connection.Open();
                komanda2.ExecuteNonQuery();
                komanda2.Connection.Close();
                foreach (ListItem item in kolekcija)
                {
                    try
                    {
                        SqlCommand komanda3 = new SqlCommand("INSERT INTO  Jela_Sastojci(Id_jela,Id_sastojka) VALUES(@idJela,@idSastojka)");
                        komanda3.Connection = konekcija;
                        komanda3.Parameters.AddWithValue("idJela", idJela);
                        komanda3.Parameters.AddWithValue("idSastojka", Convert.ToInt32(item.Value));
                        komanda3.Connection.Open();
                        komanda3.ExecuteNonQuery();
                        komanda3.Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        LabelResult.Text = "Failed" + ex.Message;
                    }
                }
                TextBoxIme.Text = String.Empty;
                TextBoxCena.Text = string.Empty;
                CheckBoxAkcija.Checked = false;
                foreach (ListItem item in kolekcija)
                {
                    item.Selected = false;
                }
                fillDishes();
            }

            if (UpdateInsertDish.Text == "INSERT DISH")
            {
                string NazivJela = TextBoxIme.Text;
                double Cena = Convert.ToDouble(TextBoxCena.Text);
                bool Akcija = CheckBoxAkcija.Checked;
                IEnumerable<ListItem> kolekcija = CheckBoxListSastojci.Items.Cast<ListItem>()
                .Where(li => li.Selected);
                string Slika = "";
                if ((FileSlika.PostedFile != null) && (FileSlika.PostedFile.ContentLength > 0))
                {
                    Random rnd = new Random();
                    string uid = rnd.Next(10000000).ToString();
                    string fn = System.IO.Path.GetFileName(FileSlika.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~/images/") + "" + uid + fn;

                    Slika = "~/images/" + uid + fn;
                    string fileExtention = FileSlika.PostedFile.ContentType;
                    int fileLenght = FileSlika.PostedFile.ContentLength;
                    FileSlika.SaveAs(SaveLocation);
                }
                JelaInsert upis = new JelaInsert { jelo = new JelaItem { Akcija = Akcija, Cena = Cena, NazivJela = NazivJela, Slika = Slika } };
                OperationResult rez = this.menager.execute(upis);
                int idP = upis.jelo.IdJela;
                SqlConnection konekcija = new SqlConnection(WebConfigurationManager.ConnectionStrings["logovanjeString"].ConnectionString);
                SqlCommand komanda1 = new SqlCommand("SELECT TOP 1 Id_jela FROM Jela ORDER BY Id_jela DESC");
                komanda1.Connection = konekcija;
                komanda1.Connection.Open();
                int lastID = Convert.ToInt32(komanda1.ExecuteScalar());
                komanda1.Connection.Close();
                OperationResult res = new OperationResult();
                foreach (ListItem item in kolekcija)
                {
                    int ids = Convert.ToInt32(item.Value);
                    Jela_SastojciInsert jelasastojciInsert = new Jela_SastojciInsert { jelosastojak = new JelaSastojciItem { IdJela = lastID, IdSastojka = ids } };
                    res = this.menager.execute(jelasastojciInsert);
                }
                if (res.Success && rez.Success)
                {
                    TextBoxIme.Text = String.Empty;
                    TextBoxCena.Text = string.Empty;
                    CheckBoxAkcija.Checked = false;
                    foreach (ListItem item in kolekcija)
                    {
                        item.Selected = false;
                    }
                    fillDishes();
                }

                foreach (ListItem item in kolekcija)
                {
                    try
                    {
                        komanda1.Connection = konekcija;
                        komanda1.Parameters.AddWithValue("idSastojka", item.Value);
                        komanda1.Connection.Open();
                        komanda1.ExecuteNonQuery();
                        komanda1.Connection.Close();
                    }
                    catch (Exception ex)
                    {
                        LabelResult.Text = "Failed" + ex.Message;
                    }
                }
            }
            UpdateInsertDish.Text = "INSERT DISH";
        }
        protected void GridViewJela_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Image staraSlika = (Image)GridViewJela.Rows[e.RowIndex].FindControl("slika");
            string staraPutanja = staraSlika.ImageUrl;
            FileInfo podaciOfajlu = new FileInfo(Server.MapPath(staraPutanja));
            if (podaciOfajlu.Exists)
            {
                File.Delete(Server.MapPath(staraPutanja));
            }
        }

        protected void GridViewJela_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Image staraSlika = (Image)GridViewJela.Rows[e.RowIndex].FindControl("slika");
            string staraPutanja = staraSlika.ImageUrl;
            FileInfo podaciOfajlu = new FileInfo(Server.MapPath(staraPutanja));
            if (podaciOfajlu.Exists)
            {
                File.Delete(Server.MapPath(staraPutanja));
            }
        }

        protected void GridViewSastojci_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void DeleteSastojak_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            SastojciDelete delete = new SastojciDelete { sastojak = new SastojciItem { IdSastojka = Convert.ToInt32(deleteBtn.CommandArgument) } };
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillIngredients();
            }
        }

        protected void UpdateSastojak_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                InsertUpdateSastojak.Text = "UPDATE INGREDIENT";
                LabelSastojakkkk.Text = "Update Ingredient";
                SastojciSelect select = new SastojciSelect() { sastojak = new SastojciItem { IdSastojka=id } };
                SastojciResult rez = (SastojciResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenFieldSas.Value = rez.sastojci[0].IdSastojka.ToString();
                    TextBoxSastojak.Text = rez.sastojci[0].NazivSastojka.ToString();
                }
            }
        }

        protected void InsertUpdateSastojak_Click(object sender, EventArgs e)
        {
            if (InsertUpdateSastojak.Text == "INSERT INGREDIENT")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    SastojciInsert upis = new SastojciInsert { sastojak = new SastojciItem { NazivSastojka=TextBoxSastojak.Text } };                   
                    OperationResult rez = this.menager.execute(upis);
                    if (rez.Success)
                    {
                        LabelResultSastojak.CssClass = "form-control";
                        LabelResultSastojak.Visible = true;
                        LabelResultSastojak.Text = "INGREDIENT INSERTED";
                        TextBoxSastojak.Text = String.Empty;
                        fillIngredients();
                    }
                }
            }
            if (InsertUpdateSastojak.Text == "UPDATE INGREDIENT")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    SastojciUpdate updateS = new SastojciUpdate();
                    updateS.Id = Convert.ToInt32(HiddenFieldSas.Value);
                    updateS.naziv = TextBoxSastojak.Text;
                    OperationResult result = this.menager.execute(updateS);
                    LabelResultSastojak.Visible = true;
                    if (result.Success)
                    {
                        LabelResultSastojak.Text = "Successfully updated";
                        TextBoxSastojak.Text = String.Empty;
                        fillIngredients();
                        InsertUpdateSastojak.Text = "INSERT INGREDIENT";
                    }
                    else
                    {
                        InsertUpdateSastojak.Text = "Update failed";
                        InsertUpdateSastojak.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
                    }
                }
            }
        }

        protected void GridViewJela_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Name";
                e.Row.Cells[3].Text = "Photo";
                e.Row.Cells[4].Text = "Price";
                e.Row.Cells[5].Text = "Discount";
                e.Row.Cells[7].Text = "Ingredients";
            }

        }

        protected void GridViewSastojci_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Ingredient";
            }
        }

    }
}
