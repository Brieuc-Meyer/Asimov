using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;

namespace AsimovStudentManager
{
    public partial class Form1 : Form
    {
        public string ID;
        public List<Note> NotesEleve = new List<Note>();

        public Form1()
        {
            InitializeComponent();
            tc_Main.Appearance = TabAppearance.FlatButtons;
            tc_Main.ItemSize = new Size(0, 1);
            tc_Main.SizeMode = TabSizeMode.Fixed;

            tc_Prof.Appearance = TabAppearance.FlatButtons;
            tc_Prof.ItemSize = new Size(0, 1);
            tc_Prof.SizeMode = TabSizeMode.Fixed;

            tb_identifiant.Text = "marc.leroy";
            tb_mdp.Text = "root";

            #region chart style
            // Rajout du "ChartArea"
            chart_moyennesEleve.ChartAreas.Clear();
            chart_moyennesEleve.ChartAreas.Add(new ChartArea("MyChartArea"));

            // Ajout de la s�rie du chart
            chart_moyennesEleve.Series.Clear();
            Series series = new Series("Moyenne");
            chart_moyennesEleve.Series.Add(series);

            // Propri�t�s du chart
            chart_moyennesEleve.Titles.Add("Moyenne par sujet");
            chart_moyennesEleve.ChartAreas["MyChartArea"].AxisX.Title = "Mati�re";
            chart_moyennesEleve.ChartAreas["MyChartArea"].AxisY.Title = "Pourcentage";

            // Rajout d'une l�gende
            chart_moyennesEleve.Legends.Clear();
            chart_moyennesEleve.Legends.Add("Moyenne");
            #endregion

            #region Ajout et style des colonnes
            dgv_NotesEleve.Columns.Add("note_id", "note_id");
            dgv_NotesEleve.Columns.Add("note_eleve_id", "note_eleve_id");
            dgv_NotesEleve.Columns.Add("R�sultat", "R�sultat");
            dgv_NotesEleve.Columns.Add("Professeur", "Professeur");
            dgv_NotesEleve.Columns.Add("Mati�re", "Mati�re");
            dgv_NotesEleve.Columns.Add("Date", "Date");
            dgv_NotesEleve.Columns.Add("Intitul�", "Intitul�");
            dgv_NotesEleve.Columns.Add("D�scription", "D�scription");

            dgv_NotesEleve.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_NotesEleve.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_NotesEleve.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_NotesEleve.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_NotesEleve.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv_NotesEleve.Columns[0].Visible = false;
            dgv_NotesEleve.Columns[1].Visible = false;
            dgv_NotesEleve.Columns[5].Visible = false;
            dgv_NotesEleve.Columns[6].Visible = false;
            dgv_NotesEleve.Columns[7].Visible = false;
            #endregion

        }

        //recupere le body d'une url
            public static async Task<string> GetUrlBody(string url)
            {
                using (var handler = new HttpClientHandler())
                {
                    try
                    {
                        handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                        using (var client = new HttpClient(handler))
                        {
                            var cookieContainer = new CookieContainer();
                            Random rand = new Random();
                            int randomNumber = rand.Next(0, 10001);
                            cookieContainer.Add(new Uri(url), new Cookie("session", randomNumber.ToString()));
                            handler.CookieContainer = cookieContainer;

                            HttpResponseMessage response = await client.GetAsync(url);
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            return responseBody;
                        }
                    } catch (Exception err)
                    {
                        MessageBox.Show("L'acc�s au serveur est indisponible : " + err.Message);
                        return null;
                    }
                }
            }
            async void Connect(Object sender, EventArgs e)
            {
                //verification que il y � bien des valeurs d'entr�es
                if (tb_identifiant.Text != "" && tb_mdp.Text != "")
                {
                    #region si il a s�l�ctionn� la connexion de type �leve
                    if (rb_ConnectEleve.Checked && rb_ConnectProf.Checked == false)
                    {
                        string bodyResponse = await GetUrlBody("https://localhost:3000/connexionEleve/" + tb_identifiant.Text + "/" + tb_mdp.Text);
                        if (bodyResponse == null) { return; }
                        string response = bodyResponse.Replace("\"", "");
                        string keyWord = "Bonjour";

                        if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                        {
                            lb_pageEleveTitle.Text = response.Split(new[] { ';' })[0];
                            this.ID = response.Split(new[] { ';' })[1];
                            string notes = await GetUrlBody("https://localhost:3000/eleve/" + this.ID + "/notes");
                            if (notes == null) { return; }
                            JArray jsonArray = JArray.Parse(notes);

                            foreach (JObject jsonObject in jsonArray)
                            {
                                Note newnote = new Note(Int32.Parse(jsonObject["note_id"].ToString()), Int32.Parse(jsonObject["note_eleve_id"].ToString()), Int32.Parse(jsonObject["note_pourcent"].ToString()), Int32.Parse(jsonObject["note_prof_id"].ToString()), Int32.Parse(jsonObject["note_mat_id"].ToString()), Convert.ToDateTime(jsonObject["note_date_evaluation"].ToString()), jsonObject["note_intitule"].ToString(), jsonObject["note_description"].ToString(), jsonObject["mat_nom"].ToString(), jsonObject["perso_nom"].ToString());
                                NotesEleve.Add(newnote);
                            }

                            #region Population du dgv des notes
                            foreach (Note note in NotesEleve)
                            {
                                int rowIndex = dgv_NotesEleve.Rows.Add();
                                dgv_NotesEleve.Rows[rowIndex].Cells[0].Value = note.note_id;
                                dgv_NotesEleve.Rows[rowIndex].Cells[1].Value = note.note_eleve_id;
                                dgv_NotesEleve.Rows[rowIndex].Cells[2].Value = note.note_pourcent;
                                dgv_NotesEleve.Rows[rowIndex].Cells[3].Value = note.note_prof_nom;
                                dgv_NotesEleve.Rows[rowIndex].Cells[4].Value = note.note_mat_name;
                                dgv_NotesEleve.Rows[rowIndex].Cells[5].Value = note.note_date_evaluation;
                                dgv_NotesEleve.Rows[rowIndex].Cells[6].Value = note.note_intitule;
                                dgv_NotesEleve.Rows[rowIndex].Cells[7].Value = note.note_description;
                            }
                            #endregion

                            setGraphMoyennes();

                            tc_Main.SelectTab(1);
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }

                        //si il a s�l�ctionn� la connexion de type professeur
                    }
                    #endregion

                    #region si il a s�l�ction� la connexion de type prof
                    else if (rb_ConnectProf.Checked && rb_ConnectEleve.Checked == false)
                    {
                        string bodyResponse = await GetUrlBody("https://localhost:3000/connexionProfesseur/" + tb_identifiant.Text + "/" + tb_mdp.Text);
                        if (bodyResponse == null) { return; }
                        string response = bodyResponse.Replace("\"", "");
                        string keyWord = "Bonjour";
                        if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                        {
                            ID = response.Split(new[] { ';' })[1];
                            lb_pageProfTitle.Text = response.Split(new[] { ';' })[0];

                            fill_dgv_ProfEleves();

                            tc_Main.SelectTab(2);
                        }
                        else
                        {
                            MessageBox.Show(response);
                        }
                    }
                    #endregion

                    #region si aucun mode de connexion choisi
                    else
                    {
                        MessageBox.Show("Veuillez s�l�ctionner un mode de connexion");
                    }
                    #endregion
                }
                else //Si auncun mdp ou aucun identifiant rempli
                {
                    MessageBox.Show("Veuillez rentrer un identifiant et un mot de passe");
                }
            }


        //Partie �l�ve
            async void setGraphMoyennes()
            {
                string Moyennes = await GetUrlBody("https://localhost:3000/eleve/"+ this.ID +"/moyennes");
                if (Moyennes == null) { return; }
                JArray jsonArray = JArray.Parse(Moyennes);

                foreach (JObject jsonObject in jsonArray)
                {
                    chart_moyennesEleve.Series["Moyenne"].Points.AddXY(jsonObject["mat_nom"].ToString(), jsonObject["Moyenne"].ToString());
                }
            }
            private void dgv_NotesEleve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                foreach (Note note in NotesEleve)
                {
                    if (note.note_id == (int)dgv_NotesEleve.Rows[e.RowIndex].Cells[0].Value)
                    {
                        Form form_note = new Form_Note(note);
                        form_note.Show();
                    }
                }
            }
            private async void btn_DisconnectEleve_Click(object sender, EventArgs e)
        {
            tb_identifiant.Text = "";
            tb_mdp.Text = "";
            tc_Main.SelectedIndex = 0;

            dgv_NotesEleve.Rows.Clear();
            foreach (Series series in chart_moyennesEleve.Series)
            {
                series.Points.Clear();
            }
            rb_ConnectEleve.Checked = false;
            rb_ConnectProf.Checked = false;
            NotesEleve.Clear();

            List<Form_Note> formsToClose = new List<Form_Note>();
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form_Note)
                {
                    formsToClose.Add((Form_Note)form);
                }
            }

            foreach (Form_Note form in formsToClose)
            {
                form.Close();
            }
            formsToClose.Clear();

            string res = await GetUrlBody("https://localhost:3000/deconnection");
        }



        //Partie prof
            //remplissage de dgv
                async void fill_dgv_ProfEleves()
                {
                    dgv_ProfEleves.Rows.Clear();
                    dgv_ProfEleves.Columns.Clear();
                    string profEleves = await GetUrlBody("https://localhost:3000/professeur/" + ID.ToString() + "/voireleves");
                    if (profEleves == null) { return; }
                    JArray jsonArray = JArray.Parse(profEleves);

                    #region style datagridview eleves du prof
                    dgv_ProfEleves.Columns.Add("eleve_id", "eleve_id");
                    dgv_ProfEleves.Columns[0].Visible = false;
                    dgv_ProfEleves.Columns.Add("eleve_identifiant", "eleve_identifiant");
                    dgv_ProfEleves.Columns[1].Visible = false;
                    dgv_ProfEleves.Columns.Add("eleve_mdp", "eleve_mdp");
                    dgv_ProfEleves.Columns[2].Visible = false;
                    dgv_ProfEleves.Columns.Add("Nom de l'�l�ve", "Nom de l'�l�ve");
                    dgv_ProfEleves.Columns.Add("Classe de l'�l�ve", "Classe de l'�l�ve");
                    dgv_ProfEleves.Columns.Add("class_grade", "class_grade");
                    dgv_ProfEleves.Columns[5].Visible = false;

                    foreach (DataGridViewColumn col in dgv_ProfEleves.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    #endregion

                    foreach (JObject jsonObject in jsonArray)
                    {
                        int rowIndex = dgv_ProfEleves.Rows.Add();
                        dgv_ProfEleves.Rows[rowIndex].Cells[0].Value = jsonObject["eleve_id"];
                        dgv_ProfEleves.Rows[rowIndex].Cells[1].Value = jsonObject["eleve_identifiant"];
                        dgv_ProfEleves.Rows[rowIndex].Cells[2].Value = jsonObject["eleve_mdp"];
                        dgv_ProfEleves.Rows[rowIndex].Cells[3].Value = jsonObject["eleve_nom"];
                        dgv_ProfEleves.Rows[rowIndex].Cells[4].Value = jsonObject["class_nom"];
                        dgv_ProfEleves.Rows[rowIndex].Cells[5].Value = jsonObject["class_grade"];
                    }
                }
                async void fill_dgv_addEleveClasses()
                {
                    dgv_addEleveClasses.Rows.Clear();
                    dgv_addEleveClasses.Columns.Clear();

                    #region style du datagridview
                    dgv_addEleveClasses.Columns.Add("class_grade", "class_grade");
                    dgv_addEleveClasses.Columns.Add("Grade de la classe", "Grade de la classe");
                    dgv_addEleveClasses.Columns.Add("Nombre d'�l�ve", "Nombre d'�l�ve");

                    dgv_addEleveClasses.Columns[0].Visible = false;

                    foreach(DataGridViewColumn col in dgv_addEleveClasses.Columns)
                    {
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                    #endregion

                    string classes = await GetUrlBody("https://localhost:3000/professeur/afficherClassesProf/" + ID.ToString());
                    if (classes == null) { return; }
                    JArray jsonArray = JArray.Parse(classes);

                    foreach(JObject jsonObject in jsonArray)
                    {
                        int rowIndex = dgv_addEleveClasses.Rows.Add();
                        dgv_addEleveClasses.Rows[rowIndex].Cells[0].Value = jsonObject["class_grade"].ToString();
                        dgv_addEleveClasses.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
                        dgv_addEleveClasses.Rows[rowIndex].Cells[2].Value = jsonObject["Nbr_eleve"].ToString();
                    }
                }
                async void fill_dgv_modifEleveClasses()
            {
                dgv_modifEleveClass.Rows.Clear();
                dgv_modifEleveClass.Columns.Clear();

                #region style du datagridview
                dgv_modifEleveClass.Columns.Add("class_grade", "class_grade");
                dgv_modifEleveClass.Columns.Add("Grade de la classe", "Grade de la classe");
                dgv_modifEleveClass.Columns.Add("Nombre d'�l�ve", "Nombre d'�l�ve");

                dgv_modifEleveClass.Columns[0].Visible = false;

                foreach (DataGridViewColumn col in dgv_modifEleveClass.Columns)
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                #endregion

                string classes = await GetUrlBody("https://localhost:3000/professeur/afficherClassesProf/" + ID.ToString());
                if (classes == null) { return; }
                JArray jsonArray = JArray.Parse(classes);

                foreach (JObject jsonObject in jsonArray)
                {
                    int rowIndex = dgv_modifEleveClass.Rows.Add();
                    dgv_modifEleveClass.Rows[rowIndex].Cells[0].Value = jsonObject["class_grade"].ToString();
                    dgv_modifEleveClass.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
                    dgv_modifEleveClass.Rows[rowIndex].Cells[2].Value = jsonObject["Nbr_eleve"].ToString();
                }
            }


            //navigation
                private void btn_addEleve_Click(object sender, EventArgs e)
                {
                    fill_dgv_addEleveClasses();
                    tc_Prof.SelectedIndex = 1;
                }
                private void btn_addEleveRetour_Click(object sender, EventArgs e)
                {
                    tc_Prof.SelectedIndex = 0;
                    tb_addElevePrenom.Text = "";
                    tb_addEleveIdentifiant.Text = "";
                    tb_addEleveMdp.Text = "";
                }
                private async void btn_DisconnectProf_Click(object sender, EventArgs e)
                {
                    tb_identifiant.Text = "";
                    tb_mdp.Text = "";
                    rb_ConnectEleve.Checked = false;
                    rb_ConnectProf.Checked = false;
                    tc_Main.SelectedIndex = 0;
                    tc_Prof.SelectedIndex = 0;

                    dgv_ProfEleves.Rows.Clear();
                    dgv_ProfEleves.Columns.Clear();
                    string res = await GetUrlBody("https://localhost:3000/deconnection");
                }
                private void btn_modifEleve_Click(object sender, EventArgs e)
                {
                    if (dgv_ProfEleves.SelectedRows.Count != 0)
                    {
                
                        tb_modifEleveShowPrenom.Text = dgv_ProfEleves.SelectedRows[0].Cells[3].Value.ToString();
                        tb_modifEleveShowIdentifiant.Text = dgv_ProfEleves.SelectedRows[0].Cells[1].Value.ToString();
                        tb_modifEleveShowMdp.Text = dgv_ProfEleves.SelectedRows[0].Cells[2].Value.ToString();
                        tb_modifEleveShowClass.Text = dgv_ProfEleves.SelectedRows[0].Cells[4].Value.ToString();

                        tb_modifElevePrenom.Text = dgv_ProfEleves.SelectedRows[0].Cells[3].Value.ToString();
                        tb_modifEleveIdentifiant.Text = dgv_ProfEleves.SelectedRows[0].Cells[1].Value.ToString();
                        tb_modifEleveMdp.Text = dgv_ProfEleves.SelectedRows[0].Cells[2].Value.ToString();

                        fill_dgv_modifEleveClasses();

                        tc_Prof.SelectedIndex = 2;
                    }
                }
                private void btn_retourModifEleve_Click(object sender, EventArgs e)
                {
                    tc_Prof.SelectedIndex = 0;
                    tb_modifEleveShowPrenom.Text = "";
                    tb_modifEleveShowIdentifiant.Text = "";
                    tb_modifEleveShowMdp.Text = "";
                    tb_modifEleveShowClass.Text = "";

                    tb_modifElevePrenom.Text = "";
                    tb_modifEleveIdentifiant.Text = "";
                    tb_modifEleveMdp.Text = "";
                }


            //CRUD
                async void btn_DelEleve_Click(object sender, EventArgs e)
                {
                    if (dgv_ProfEleves.SelectedRows.Count != 0)
                    {
                        string eleveID = dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString();
                        DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer l'�l�ve : " + dgv_ProfEleves.SelectedRows[0].Cells[1].Value.ToString() + "\n Toutes les notes de l'�l�ve seront supprim�es", "Supprimer �l�ve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string delResult = await GetUrlBody("https://localhost:3000/professeur/supprimerEleve/" + eleveID);
                            if (delResult == null) { return; }
                            string res = delResult.Replace("\"", "");
                            MessageBox.Show(res);
                            fill_dgv_ProfEleves();
                        }
                        else
                        {
                        }
                    }
                }
                private async void btn_addEleveToDb_Click(object sender, EventArgs e)
                {
                    if(dgv_addEleveClasses.SelectedRows.Count != 0)
                    {
                        if(tb_addElevePrenom.Text != "")
                        {
                            if (tb_addEleveIdentifiant.Text != "")
                            {
                                if (tb_addEleveMdp.Text != "")
                                {
                                    DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter l'�l�ve : " + tb_addElevePrenom.Text, "Ajouter �l�ve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (result == DialogResult.Yes)
                                    {
                                        string addRes = await GetUrlBody("https://localhost:3000/professeur/ajouterEleve/" + tb_addElevePrenom.Text.Trim() + "/" + tb_addEleveIdentifiant.Text.Trim() + "/" + tb_addEleveMdp.Text.Trim() + "/" + dgv_addEleveClasses.SelectedRows[0].Cells[0].Value.ToString());
                                        if (addRes == null) { return; }
                                        string res = addRes.Replace("\"", "");
                                        MessageBox.Show(res);
                                        fill_dgv_ProfEleves();
                                        tc_Prof.SelectedIndex = 0;
                                        tb_addElevePrenom.Text = "";
                                        tb_addEleveIdentifiant.Text = "";
                                        tb_addEleveMdp.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Veuillez entrer un mot de passe pour l'�l�ve");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez entrer un identifiant pour l'�l�ve");
                            }
                        } else
                        {
                            MessageBox.Show("Veuillez entrer un nom pr�nom pour l'�l�ve");
                        }
                    } else
                    {
                        MessageBox.Show("Veuillez choisir une classe pour l'�l�ve");
                    }
                }
                private async void btn_ModifEleveToDb_Click(object sender, EventArgs e)
                {
                    if(dgv_modifEleveClass.SelectedRows.Count != 0)
                    {
                        if(tb_modifElevePrenom.Text != "")
                        {
                            if (tb_modifEleveIdentifiant.Text != "")
                            {
                                if (tb_modifEleveMdp.Text != "")
                                {
                                    DialogResult result = MessageBox.Show("Voulez vous vraiment modifier l'�l�ve : " + tb_modifEleveShowPrenom.Text, "Modifier �l�ve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                    if (result == DialogResult.Yes)
                                    {
                                        string modifRes = await GetUrlBody("https://localhost:3000/professeur/modifEleve/" + tb_modifElevePrenom.Text + "/" + tb_modifEleveIdentifiant.Text + "/" + tb_modifEleveMdp.Text + "/" + dgv_modifEleveClass.SelectedRows[0].Cells[0].Value.ToString() + "/" + dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString());
                                        if (modifRes == null) { return; }
                                        string res = modifRes.Replace("\"", "");
                                        MessageBox.Show(res);
                                        fill_dgv_ProfEleves();
                                        tc_Prof.SelectedIndex = 0;
                                        tb_modifEleveShowPrenom.Text = "";
                                        tb_modifEleveShowIdentifiant.Text = "";
                                        tb_modifEleveShowMdp.Text = "";
                                        tb_modifEleveShowClass.Text = "";

                                        tb_modifElevePrenom.Text = "";
                                        tb_modifEleveIdentifiant.Text = "";
                                        tb_modifEleveMdp.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Veuillez entr� un nouveau mote de passe pour l'�l�ve");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez entr� un nouveau identifiant pour l'�l�ve");
                            }
                        } else
                        {
                            MessageBox.Show("Veuillez entr� un nouveau nom pr�nom pour l'�l�ve");
                        }
                    } else
                    {
                        MessageBox.Show("Veuillez choisir une nouvelle classe pour l'�l�ve");
                    }
                }
    }
}
