using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Restaurant.BusinessLayer;
using Restaurant.DataLayer;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;


namespace Restaurant.Administrator
{
    public partial class Admin : System.Web.UI.Page
    {
        public Size OriginalImageSize { get; set; }
        public Size NewImageSize { get; set; }
        OperationMenager menager = OperationMenager.Singleton;
        protected void Page_Load(object sender, EventArgs e)
        {
            fillKuvari();
            fillMenagers();
            fillPositions();
            if (!IsPostBack)
            {
                PozicijeSelect selectPozicije = new PozicijeSelect();
                PozicijeResult result = this.menager.execute(selectPozicije) as PozicijeResult;
                if (result.Success)
                {
                    DropDownListPozicije.DataSource = result.pozicije.ToList();
                    for (int i = 0; i < result.pozicije.Count; i++)
                    {
                        DropDownListPozicije.DataTextField = "NazivPozicije";
                        DropDownListPozicije.DataValueField = "idPozicije";
                    }
                    DropDownListPozicije.DataBind();
                }
            }
        }

        private void fillKuvari()
        {
            KuvariPozicijeSelect select = new KuvariPozicijeSelect();
            KuvariPozicijeResult result = this.menager.execute(select) as KuvariPozicijeResult;
            if (result.Success)
            {
                GridView1.DataSource = result.kuvariPoz.ToList();
                GridView1.DataBind();               
            }
        }
        private void fillMenagers()
        {
            MenadzerSelect select = new MenadzerSelect();
            MenadzerResult result = this.menager.execute(select) as MenadzerResult;
            if (result.Success)
            {
                GridViewMenager.DataSource = result.menadzeri.ToList();
                GridViewMenager.DataBind();
            }
        }
        private void fillPositions()
        {
            PozicijeSelect select = new PozicijeSelect();
            PozicijeResult result = this.menager.execute(select) as PozicijeResult;
            if (result.Success)
            {
                GridViewPozicije.DataSource = result.pozicije.ToList();
                GridViewPozicije.DataBind();
            }
        }
        protected void GridViewPozicije_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;            
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;            
            e.Row.Cells[4].Visible = false;
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                UpdateFinally.Text = "UPDATE COOK";
                Label1.Text = "UPDATE COOK";
                KuvariPozicijeSelect select = new KuvariPozicijeSelect() { kuvarPozicija = new KuvariPozicijaItem { IdKuvar=id } };
                KuvariPozicijeResult rez = (KuvariPozicijeResult)menager.execute(select);
                if (rez.Success)
                {
                    HiddenField1.Value = rez.kuvariPoz[0].IdKuvar.ToString();
                    string oldImage = rez.kuvariPoz[0].Slika;
                    FileInfo info = new FileInfo(Server.MapPath(oldImage));
                    if (info.Exists)
                    {
                        File.Delete(Server.MapPath(oldImage));
                    }
                    TextBox1.Text = rez.kuvariPoz[0].Ime;
                }
            }
        }



        protected void UpdateFinally_Click(object sender, EventArgs e)
        {
            if (UpdateFinally.Text == "UPDATE COOK")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    KuvariPozicijaUpdate updateKuvari = new KuvariPozicijaUpdate { kuvarPozicija = new KuvariPozicijaItem { IdKuvar = Convert.ToInt32(HiddenField1.Value), Ime = TextBox1.Text, idPozicije = Convert.ToInt32(DropDownListPozicije.SelectedValue),Slika="" } };                
                    if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                    {
                        Random rnd = new Random();
                        string uid = rnd.Next(10000000).ToString();
                        string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                        string SaveLocation = Server.MapPath("~/images/") + "" + uid + fn;
                        string SaveLocationMala = Server.MapPath("~/images/") + "" + uid + fn + "Mala";
                        updateKuvari.kuvarPozicija.Slika = "~/images/" + uid + fn;
                        string fileExtention = File1.PostedFile.ContentType;
                        int fileLenght = File1.PostedFile.ContentLength;
                        if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
                        {
                            File1.SaveAs(SaveLocation);
                            System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(File1.PostedFile.InputStream);
                            System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 81);
                            // Saving image in jpeg format
                            objImage.Save(SaveLocationMala);
                            updateKuvari.kuvarPozicija.SlikaMala = "~/images/" + uid + fn + "Mala";
                        }
                    }
                    OperationResult result = this.menager.execute(updateKuvari);
                    LabelResult.Visible = true;
                    if (result.Success)
                    {
                        LabelResult.Text = "Successfully updated";
                        UpdateFinally.Text = "INSERT COOK";
                        TextBox1.Text = "";
                        fillKuvari();
                        return;
                    }
                    else
                    {
                        LabelResult.Text = "Update failed";
                        LabelResult.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
                        return;
                    }



                }
            }
            if (UpdateFinally.Text == "INSERT COOK")
            {
                KuvariPozicijaInsert insertKuvari = new KuvariPozicijaInsert { kuvarPozicija = new KuvariPozicijaItem { Ime = TextBox1.Text ,idPozicije=Convert.ToInt32(DropDownListPozicije.SelectedValue),Slika="" } };               
                if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
                {
                    Random rnd = new Random();
                    string uid = rnd.Next(10000000).ToString();
                    string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~/images/") + "" + uid + fn;
                    string SaveLocationMala = Server.MapPath("~/images/") + "" + uid + fn + "Mala";
                    insertKuvari.kuvarPozicija.Slika = "~/images/" + uid + fn;
                    string fileExtention = File1.PostedFile.ContentType;
                    int fileLenght = File1.PostedFile.ContentLength;
                    if (fileExtention == "image/png" || fileExtention == "image/jpeg" || fileExtention == "image/x-png")
                    {
                        File1.SaveAs(SaveLocation);
                        System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(File1.PostedFile.InputStream);
                        System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 81);                        
                        objImage.Save(SaveLocationMala);
                        insertKuvari.kuvarPozicija.SlikaMala = "~/images/" + uid + fn + "Mala";
                    }
                }
                OperationResult resultInsert = this.menager.execute(insertKuvari);
                if (resultInsert.Success)
                {
                    LabelResult.Visible = true;
                    LabelResult.Text = "Successfully inserted";
                    TextBox1.Text = "";
                    fillKuvari();
                }
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            KuvarPozicijaDelete delete = new KuvarPozicijaDelete { kuvarPozicija = new KuvariPozicijaItem { IdKuvar = Convert.ToInt32(deleteBtn.CommandArgument) } };        
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillKuvari();
            }

        }
        public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
        {
            var ratio = (double)maxHeight / image.Height;
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            using (var g = Graphics.FromImage(newImage))
            {
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }

        protected void GridViewMenager_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
        }

        protected void DeleteMenager_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            MenadzerDelete delete = new MenadzerDelete { menadzer = new MenadzerItem { Id = Convert.ToInt32(deleteBtn.CommandArgument) } };        
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillMenagers();
            }
        }

        protected void UpdateMenager_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                UpdateFinally.Text = "UPDATE";
                Label6.Text = "UPDATE MENAGER";
                MenadzerSelect selectMenagers = new MenadzerSelect() { menadzer = new MenadzerItem { Id=id } };
                MenadzerResult rez = (MenadzerResult)menager.execute(selectMenagers);
                if (rez.Success)
                {
                    HiddenField2.Value = rez.menadzeri[0].Id.ToString();
                    TextBoxIme.Text = rez.menadzeri[0].Ime;
                    TextBoxPrezime.Text = rez.menadzeri[0].Prezime;
                    TextBoxIskustvo.Text = rez.menadzeri[0].Iskustvo.ToString();
                    ButtonInsertUpdateMenager.Text = "UPDATE MENAGER";
                }
            }
        }


        protected void ButtonInsertUpdateMenager_Click(object sender, EventArgs e)
        {
            if (ButtonInsertUpdateMenager.Text == "INSERT MENAGER")
            {
                MenadzerInsert menagerInsert = new MenadzerInsert { menadzer = new MenadzerItem { Ime = TextBoxIme.Text, Prezime = TextBoxPrezime.Text, Iskustvo = Convert.ToInt32(TextBoxIskustvo.Text) } };               
                OperationResult resultInsert = this.menager.execute(menagerInsert);
                if (resultInsert.Success)
                {
                    LabelMenagerResult.Visible = true;
                    LabelMenagerResult.Text = "Successfully inserted";
                    TextBoxIme.Text = String.Empty;
                    TextBoxPrezime.Text = String.Empty;
                    TextBoxIskustvo.Text = String.Empty;
                    
                    fillMenagers();
                }
            }
            if (ButtonInsertUpdateMenager.Text == "UPDATE MENAGER")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    MenadzerUpdate menagerUpdate = new MenadzerUpdate { menadzer = new MenadzerItem { Ime = TextBoxIme.Text, Prezime = TextBoxPrezime.Text,Iskustvo = Convert.ToInt32(TextBoxIskustvo.Text), Id = Convert.ToInt32(HiddenField2.Value) } };     

                    OperationResult result = this.menager.execute(menagerUpdate);
                    LabelMenagerResult.Visible = true;
                    if (result.Success)
                    {
                        LabelMenagerResult.Text = "Successfully updated";                        
                        TextBoxIme.Text = String.Empty;
                        TextBoxPrezime.Text = String.Empty;
                        TextBoxIskustvo.Text = String.Empty;
                        fillMenagers();
                        ButtonInsertUpdateMenager.Text = "INSERT MENAGER";
                    }
                    else
                    {
                        ButtonInsertUpdateMenager.Text = "Update failed";
                        ButtonInsertUpdateMenager.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");

                    }
                }}
                
            }

        protected void DeletePositions_Click(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            PozicijeDelete delete = new PozicijeDelete();
            delete.pozicija = new PozicijeItem { idPozicije = Convert.ToInt32(deleteBtn.CommandArgument) };        
            OperationResult result = this.menager.execute(delete);
            if (result.Success)
            {
                fillPositions();
            }
        }

        protected void UpdatePositions_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn != null)
            {
                int id = Convert.ToInt32(btn.CommandArgument);
                ButtonInsertUpdatePosition.Text = "UPDATE POSITION";
                LabelPositions.Text = "UPDATE POSITION";
               PozicijeSelect selectPositions=new PozicijeSelect{ pozicija=new PozicijeItem{ idPozicije=id}};
                //PozicijeSelect selectPositions = new PozicijeSelect() { Id = id };
                PozicijeResult rez = (PozicijeResult)menager.execute(selectPositions);
                if (rez.Success)
                {
                    HiddenFieldPosition.Value = rez.pozicije[0].idPozicije.ToString();
                    TextBoxPositionName.Text = rez.pozicije[0].NazivPozicije;
                    ButtonInsertUpdatePosition.Text = "UPDATE POSITION";                    
                }
            }
        }

        protected void ButtonInsertUpdatePosition_Click(object sender, EventArgs e)
        {
            if (ButtonInsertUpdatePosition.Text == "INSERT POSITION")
            {
                PozicijeInsert insertPozicije = new PozicijeInsert { pozicija = new PozicijeItem { NazivPozicije=TextBoxPositionName.Text } };              
                OperationResult resultInsert = this.menager.execute(insertPozicije);
                if (resultInsert.Success)
                {
                    LabelPositionResult.Visible = true;
                    LabelPositionResult.Text = "Successfully inserted";
                    TextBoxPositionName.Text = String.Empty;
                    fillPositions();
                }
            }
            if (ButtonInsertUpdatePosition.Text == "UPDATE POSITION")
            {
                Button insert = (Button)sender;
                if (insert != null)
                {
                    PozicijeUpdate pozicijeUpdate = new PozicijeUpdate { pozicija = new PozicijeItem { idPozicije = Convert.ToInt32(HiddenFieldPosition.Value), NazivPozicije=TextBoxPositionName.Text } };                  
                    OperationResult result = this.menager.execute(pozicijeUpdate);
                    LabelPositionResult.Visible = true;
                    if (result.Success)
                    {
                        LabelPositionResult.Text = "Successfully updated";
                        TextBoxPositionName.Text = String.Empty;                       
                        fillPositions();
                        ButtonInsertUpdatePosition.Text = "INSERT POSITION";
                        LabelPositions.Text = "INSERT POSITION";
                    }
                    else
                    {
                        ButtonInsertUpdateMenager.Text = "Update failed";
                        ButtonInsertUpdatePosition.ForeColor = System.Drawing.ColorTranslator.FromHtml("#d9534f");
                    }                    
                }
            }                
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Name";
                e.Row.Cells[3].Text = "Photo";
                e.Row.Cells[5].Text = "Position";                
            }            
        }

        protected void GridViewMenager_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Name";
                e.Row.Cells[3].Text = "Surname";
                e.Row.Cells[4].Text = "Experience";
            }
        }

        protected void GridViewPozicije_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Options";
                e.Row.Cells[2].Text = "Position";                
            }            
        }
    }
    
}