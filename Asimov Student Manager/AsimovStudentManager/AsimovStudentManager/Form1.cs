using System;
using System.Drawing;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;

namespace AsimovStudentManager
{
    public partial class Form1 : Form
    {
        public string ID;
        public bool ProviseurOn = false;

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

            tc_Proviseur.Appearance = TabAppearance.FlatButtons;
            tc_Proviseur.ItemSize = new Size(0, 1);
            tc_Proviseur.SizeMode = TabSizeMode.Fixed;

            tb_identifiant.Text = "jeanne.dupuis";
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





            // Rajout du "ChartArea"
            chart_ProfNoteEleve.ChartAreas.Clear();
            chart_ProfNoteEleve.ChartAreas.Add(new ChartArea("MyChartArea"));

            // Ajout de la s�rie du chart
            chart_ProfNoteEleve.Series.Clear();
            Series series2 = new Series("Moyenne");
            chart_ProfNoteEleve.Series.Add(series2);

            // Propri�t�s du chart
            chart_ProfNoteEleve.Titles.Add("Moyenne par sujet");
            chart_ProfNoteEleve.ChartAreas["MyChartArea"].AxisX.Title = "Mati�re";
            chart_ProfNoteEleve.ChartAreas["MyChartArea"].AxisY.Title = "Pourcentage";

            // Rajout d'une l�gende
            chart_ProfNoteEleve.Legends.Clear();
            chart_ProfNoteEleve.Legends.Add("Moyenne");
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

                        
                        if (int.Parse(response.Split(new[] { ';' })[2]) == 1 )
                        {
                            btn_ProvieurAdmin.Visible = true;
                            ProviseurOn = true;
                        }
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
            string profEleves = null;
            dgv_ProfEleves.Rows.Clear();
            dgv_ProfEleves.Columns.Clear();
            if (ProviseurOn == true)
            {
                profEleves = await GetUrlBody("https://localhost:3000/proviseur/afficherTousLesEleves/");
            }
            else
            {
                profEleves = await GetUrlBody("https://localhost:3000/professeur/" + ID.ToString() + "/voireleves");
            }
            
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
            dgv_ProfEleves.Columns.Add("class_id", "class_id");
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
                dgv_ProfEleves.Rows[rowIndex].Cells[5].Value = jsonObject["class_id"];
            }
        }
        async void fill_dgv_addEleveClasses()
        {
            dgv_addEleveClasses.Rows.Clear();
            dgv_addEleveClasses.Columns.Clear();

            #region style du datagridview
            dgv_addEleveClasses.Columns.Add("class_id", "class_id");
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
                dgv_addEleveClasses.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_addEleveClasses.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
                dgv_addEleveClasses.Rows[rowIndex].Cells[2].Value = jsonObject["Nbr_eleve"].ToString();
            }
        }
        async void fill_dgv_modifEleveClasses()
        {
            dgv_modifEleveClass.Rows.Clear();
            dgv_modifEleveClass.Columns.Clear();

            #region style du datagridview
            dgv_modifEleveClass.Columns.Add("class_id", "class_id");
            dgv_modifEleveClass.Columns.Add("Grade de la classe", "Grade de la classe");

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
                dgv_modifEleveClass.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_modifEleveClass.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
            }
        }
        async void fill_dgv_ProfVoirNotesEleves()
        {
            dgv_ProfVoirNoteEleve.Rows.Clear();
            dgv_ProfVoirNoteEleve.Columns.Clear();
            NotesEleve.Clear();
            int ID = int.Parse(dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString().Trim());
            string response = await GetUrlBody("https://localhost:3000/eleve/" + ID.ToString() + "/notes");
            JArray notes = JArray.Parse(response);

            #region style du dgv
            dgv_ProfVoirNoteEleve.Columns.Add("note_id", "note_id");
            dgv_ProfVoirNoteEleve.Columns.Add("note_eleve_id", "note_eleve_id");
            dgv_ProfVoirNoteEleve.Columns.Add("R�sultat", "R�sultat");
            dgv_ProfVoirNoteEleve.Columns.Add("Professeur", "Professeur");
            dgv_ProfVoirNoteEleve.Columns.Add("Mati�re", "Mati�re");
            dgv_ProfVoirNoteEleve.Columns.Add("Date", "Date");
            dgv_ProfVoirNoteEleve.Columns.Add("Intitul�", "Intitul�");
            dgv_ProfVoirNoteEleve.Columns.Add("D�scription", "D�scription");

            dgv_ProfVoirNoteEleve.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_ProfVoirNoteEleve.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_ProfVoirNoteEleve.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgv_ProfVoirNoteEleve.Columns[3].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgv_ProfVoirNoteEleve.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv_ProfVoirNoteEleve.Columns[0].Visible = false;
            dgv_ProfVoirNoteEleve.Columns[1].Visible = false;
            dgv_ProfVoirNoteEleve.Columns[5].Visible = false;
            dgv_ProfVoirNoteEleve.Columns[6].Visible = false;
            dgv_ProfVoirNoteEleve.Columns[7].Visible = false;
            #endregion

            foreach (JObject jsonObject in notes)
            {
                Note newnote = new Note(Int32.Parse(jsonObject["note_id"].ToString()), Int32.Parse(jsonObject["note_eleve_id"].ToString()), Int32.Parse(jsonObject["note_pourcent"].ToString()), Int32.Parse(jsonObject["note_prof_id"].ToString()), Int32.Parse(jsonObject["note_mat_id"].ToString()), Convert.ToDateTime(jsonObject["note_date_evaluation"].ToString()), jsonObject["note_intitule"].ToString(), jsonObject["note_description"].ToString(), jsonObject["mat_nom"].ToString(), jsonObject["perso_nom"].ToString());
                NotesEleve.Add(newnote);
            }

            #region Population du dgv des notes
            foreach (Note note in NotesEleve)
            {
                int rowIndex = dgv_ProfVoirNoteEleve.Rows.Add();
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[0].Value = note.note_id;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[1].Value = note.note_eleve_id;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[2].Value = note.note_pourcent;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[3].Value = note.note_prof_nom;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[4].Value = note.note_mat_name;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[5].Value = note.note_date_evaluation;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[6].Value = note.note_intitule;
                dgv_ProfVoirNoteEleve.Rows[rowIndex].Cells[7].Value = note.note_description;
            }
            #endregion
        }
        async void fill_dgv_MatieresNotes()
        {
            string matieres = null;

            dgv_MatieresNotes.Rows.Clear();
            dgv_MatieresNotes.Columns.Clear();

            #region style du datagridview
            dgv_MatieresNotes.Columns.Add("mat_id", "mat_id");
            dgv_MatieresNotes.Columns.Add("Nom de la mati�re", "Nom de la mati�re");

            dgv_MatieresNotes.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_MatieresNotes.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion
            if (ProviseurOn == true)
            {
                matieres = await GetUrlBody("https://localhost:3000/proviseur/afficherToutesLesMatieres/");
            }
            else
            {
                matieres = await GetUrlBody("https://localhost:3000/professeur/afficherMatieresProf/" + ID.ToString());
            }


            if (matieres == null) { return; }
            JArray jsonArray = JArray.Parse(matieres);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_MatieresNotes.Rows.Add();
                dgv_MatieresNotes.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_MatieresNotes.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
        }
        async void fill_dgv_ModifMatieresNotes()
        {
            dgv_ModifMatieresNotes.Rows.Clear();
            dgv_ModifMatieresNotes.Columns.Clear();

            #region style du datagridview
            dgv_ModifMatieresNotes.Columns.Add("mat_id", "mat_id");
            dgv_ModifMatieresNotes.Columns.Add("Nom de la mati�re", "Nom de la mati�re");

            dgv_ModifMatieresNotes.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ModifMatieresNotes.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/professeur/afficherMatieresProf/" + ID.ToString());
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ModifMatieresNotes.Rows.Add();
                dgv_ModifMatieresNotes.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_ModifMatieresNotes.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
        }
        async void setGraphProfEleveMoyennes()
        {
            foreach (Series series in chart_ProfNoteEleve.Series)
            {
                series.Points.Clear();
            }
            int ID = int.Parse(dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString().Trim());
            string Moyennes = await GetUrlBody("https://localhost:3000/eleve/" + ID + "/moyennes");
            if (Moyennes == null) { return; }
            JArray jsonArray = JArray.Parse(Moyennes);

            foreach (JObject jsonObject in jsonArray)
            {
                chart_ProfNoteEleve.Series["Moyenne"].Points.AddXY(jsonObject["mat_nom"].ToString(), jsonObject["Moyenne"].ToString());
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
            ProviseurOn = false;

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
        private void btn_VoirNotesEleve_Click(object sender, EventArgs e)
        {
            if (dgv_ProfEleves.SelectedRows.Count > 0)
            {
                string nomEleve = dgv_ProfEleves.SelectedRows[0].Cells[3].Value.ToString().Trim();
                lb_ProfNotesEleves.Text = "Notes de : " + nomEleve;
                fill_dgv_ProfVoirNotesEleves();

                setGraphProfEleveMoyennes();

                tc_Prof.SelectedIndex = 3;
            }
        }
        private void btn_VoirNotesRetour_Click(object sender, EventArgs e)
        {
            tc_Prof.SelectedIndex = 0;
            dgv_ProfVoirNoteEleve.Rows.Clear();
            dgv_ProfVoirNoteEleve.Columns.Clear();
            foreach (Series series in chart_ProfNoteEleve.Series)
            {
                series.Points.Clear();
            }
        }
        private void btn_ProfAjouterNoteEleve_Click(object sender, EventArgs e)
        {
            fill_dgv_MatieresNotes();
            tc_Prof.SelectedIndex = 4;

        }
        private void btn_RetourAjouterNote_Click(object sender, EventArgs e)
        {
            tc_Prof.SelectedIndex = 3;
        }
        private void dgv_ProfVoirNoteEleve_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (Note note in NotesEleve)
            {
                if (note.note_id == (int)dgv_ProfVoirNoteEleve.Rows[e.RowIndex].Cells[0].Value)
                {
                    Form form_note = new Form_Note(note);
                    form_note.Show();
                }
            }
        }
        private void btn_ProfModifNoteEleve_Click(object sender, EventArgs e)
        {
            if (dgv_ProfVoirNoteEleve.SelectedRows.Count != 0)
            {

                tb_modifNoteShowResultat.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[2].Value.ToString();
                tb_modifNoteShowMatiere.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[4].Value.ToString();
                tb_modifNoteShowDate.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[5].Value.ToString();
                tb_modifNoteShowIntitule.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[6].Value.ToString();
                tb_modifNoteShowDescription.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[7].Value.ToString();


                tb_modifNoteResultat.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[2].Value.ToString();
                string inputDate = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[5].Value.ToString();
                string dateSansHeure = inputDate.Split(new[] { ' ' })[0];
                string[] dateSansHeureSplitee = dateSansHeure.Split(new[] { '/' });
                dtp_modifNoteDate.Value = new DateTime(int.Parse(dateSansHeureSplitee[2]), int.Parse(dateSansHeureSplitee[1]), int.Parse(dateSansHeureSplitee[0]), 10, 30, 0); // Set the date and time you want to set

                tb_modifNoteIntitule.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[6].Value.ToString();
                tb_modifNoteDescription.Text = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[7].Value.ToString();


                fill_dgv_ModifMatieresNotes();

                tc_Prof.SelectedIndex = 5;
            }
        }
        private void btn_RetourModifierNote_Click(object sender, EventArgs e)
        {
            tc_Prof.SelectedIndex = 3;
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
        private async void btn_ProfSuppNoteEleve_Click(object sender, EventArgs e)
        {
            if (dgv_ProfVoirNoteEleve.SelectedRows.Count != 0)
            {
                string noteID = dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer cette note ? : \n" + dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[6].Value.ToString(), "Supprimer note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/professeur/supprimerNote/" + noteID);
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProfVoirNotesEleves();
                }
                else
                {
                }
            }
        }
        private async void btn_ProfAjouterNote_Click(object sender, EventArgs e)
        {
            {
                if (dgv_MatieresNotes.SelectedRows.Count != 0)
                {
                    if (tb_addNoteResultat.Text != "" && int.Parse(tb_addNoteResultat.Text.Trim()) >= 0 && int.Parse(tb_addNoteResultat.Text.Trim()) <= 100)
                    {
                        if (tb_AddNoteIntitule.Text != "")
                        {
                            if (tb_AddNoteDescription.Text != "")
                            {
                                DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter la note " + tb_AddNoteIntitule.Text, "Ajouter Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                                if (result == DialogResult.Yes)
                                {
                                    int eleveID = int.Parse(dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString().Trim());
                                    string inputDate = dtp_AddNoteDate.Value.ToString();
                                    string dateSansHeure = inputDate.Split(new[] { ' ' })[0];
                                    string[] dateSansHeureSplitee = dateSansHeure.Split(new[] { '/' });
                                    string dateFormatee = dateSansHeureSplitee[2] + "-" + dateSansHeureSplitee[1] + "-" + dateSansHeureSplitee[0];
                                    string addRes = await GetUrlBody("https://localhost:3000/professeur/ajouterNote/" + eleveID + "/" + int.Parse(tb_addNoteResultat.Text.Trim()) + "/" + ID.ToString() + "/" + dgv_MatieresNotes.SelectedRows[0].Cells[0].Value.ToString() + "/" + dateFormatee + "/" + tb_AddNoteIntitule.Text + "/" + tb_AddNoteDescription.Text);
                                    if (addRes == null) { return; }
                                    string res = addRes.Replace("\"", "");
                                    MessageBox.Show(res);
                                    tc_Prof.SelectedIndex = 3;
                                    tb_addNoteResultat.Text = "";
                                    tb_AddNoteIntitule.Text = "";
                                    tb_AddNoteDescription.Text = "";
                                    dgv_MatieresNotes.Rows.Clear();
                                    dgv_MatieresNotes.Columns.Clear();
                                    fill_dgv_ProfVoirNotesEleves();
                                    setGraphProfEleveMoyennes();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez entrer une description");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer un intitul�");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez entrer une note en % valide");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez choisir une mati�re ");
                }
            }

        }
        private async void btn_ModifNoteToDb_Click(object sender, EventArgs e)
        {       
            if (dgv_ModifMatieresNotes.SelectedRows.Count != 0)
            {
                if (tb_modifNoteResultat.Text != "" && int.Parse(tb_modifNoteResultat.Text.Trim()) >= 0 && int.Parse(tb_modifNoteResultat.Text.Trim()) <= 100)
                {
                    if (tb_modifNoteIntitule.Text != "")
                    {
                        if (tb_modifNoteDescription.Text != "")
                        {
                            DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter la note " + tb_modifNoteIntitule.Text, "Ajouter Note", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                int eleveID = int.Parse(dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString().Trim());
                                int noteID = int.Parse(dgv_ProfVoirNoteEleve.SelectedRows[0].Cells[0].Value.ToString().Trim());

                                string inputDate = dtp_modifNoteDate.Value.ToString();
                                string dateSansHeure = inputDate.Split(new[] { ' ' })[0];
                                string[] dateSansHeureSplitee = dateSansHeure.Split(new[] { '/' });
                                string dateFormatee = dateSansHeureSplitee[2] + "-" + dateSansHeureSplitee[1] + "-" + dateSansHeureSplitee[0];
                                MessageBox.Show("https://localhost:3000/professeur/modifNote/" + eleveID + "/" + int.Parse(tb_modifNoteResultat.Text.Trim()) + "/" + ID.ToString() + "/" + dgv_ModifMatieresNotes.SelectedRows[0].Cells[0].Value.ToString() + "/" + dateFormatee + "/" + tb_modifNoteIntitule.Text + "/" + tb_modifNoteDescription.Text + "/" + noteID);
                                string addRes = await GetUrlBody("https://localhost:3000/professeur/modifNote/" + eleveID + "/" + int.Parse(tb_modifNoteResultat.Text.Trim()) + "/" + ID.ToString() + "/" + dgv_ModifMatieresNotes.SelectedRows[0].Cells[0].Value.ToString() + "/" + dateFormatee + "/" + tb_modifNoteIntitule.Text + "/" + tb_modifNoteDescription.Text + "/"+ noteID);
                                if (addRes == null) { return; }
                                string res = addRes.Replace("\"", "");
                                MessageBox.Show(res);
                                tc_Prof.SelectedIndex = 3;
                                tb_modifNoteResultat.Text = "";
                                tb_modifNoteIntitule.Text = "";
                                tb_modifNoteDescription.Text = "";
                                dgv_ModifMatieresNotes.Rows.Clear();
                                dgv_ModifMatieresNotes.Columns.Clear();
                                fill_dgv_ProfVoirNotesEleves();
                                setGraphProfEleveMoyennes();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Veuillez entrer une description");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez entrer un intitul�");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer une note en % valide");
                }
            }
            else
            {
                MessageBox.Show("Veuillez choisir une mati�re ");
            }
        }



        //Cont�les de saisie
        private void tb_addNoteResultat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        private void tb_modifNoteResultat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }




        //Partie proviseur

        //remplissage de dgv
        async void fill_dgv_ProviseurMatieres()
        {
            dgv_ProviseurMatieres.Rows.Clear();
            dgv_ProviseurMatieres.Columns.Clear();

            #region style du datagridview
            dgv_ProviseurMatieres.Columns.Add("mat_id", "mat_id");
            dgv_ProviseurMatieres.Columns.Add("Nom de la mati�re", "Nom de la mati�re");

            dgv_ProviseurMatieres.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ProviseurMatieres.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/proviseur/afficherToutesLesMatieres/");
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ProviseurMatieres.Rows.Add();
                dgv_ProviseurMatieres.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_ProviseurMatieres.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
            dgv_ProviseurMatieres.ClearSelection();

        }
        async void fill_dgv_ProviseurProfesseurs()
        {
            dgv_ProviseurProfesseurs.Rows.Clear();
            dgv_ProviseurProfesseurs.Columns.Clear();

            #region style du datagridview
            dgv_ProviseurProfesseurs.Columns.Add("perso_id", "perso_id");
            dgv_ProviseurProfesseurs.Columns.Add("Nom du professeur", "Nom du professeur");
            dgv_ProviseurProfesseurs.Columns.Add("Identifiant du professeur", "Identifiant du professeur");
            dgv_ProviseurProfesseurs.Columns.Add("perso_mdp", "perso_mdp");


            dgv_ProviseurProfesseurs.Columns[0].Visible = false;
            dgv_ProviseurProfesseurs.Columns[3].Visible = false;


            foreach (DataGridViewColumn col in dgv_ProviseurProfesseurs.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/proviseur/afficherProfesseurs/");
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ProviseurProfesseurs.Rows.Add();
                dgv_ProviseurProfesseurs.Rows[rowIndex].Cells[0].Value = jsonObject["perso_id"].ToString();
                dgv_ProviseurProfesseurs.Rows[rowIndex].Cells[1].Value = jsonObject["perso_nom"].ToString();
                dgv_ProviseurProfesseurs.Rows[rowIndex].Cells[2].Value = jsonObject["perso_identifiant"].ToString();
                dgv_ProviseurProfesseurs.Rows[rowIndex].Cells[3].Value = jsonObject["perso_mdp"].ToString();

            }
            dgv_ProviseurProfesseurs.ClearSelection();

        }
        async void fill_dgv_ProviseurClasses()
        {
            dgv_ProviseurClasses.Rows.Clear();
            dgv_ProviseurClasses.Columns.Clear();

            #region style du datagridview
            dgv_ProviseurClasses.Columns.Add("class_id", "class_id");
            dgv_ProviseurClasses.Columns.Add("Nom de la classe", "Nom de la classe");
            dgv_ProviseurClasses.Columns[0].Visible = false;


            foreach (DataGridViewColumn col in dgv_ProviseurClasses.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/proviseur/afficherClasses/");
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ProviseurClasses.Rows.Add();
                dgv_ProviseurClasses.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_ProviseurClasses.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
            }
            dgv_ProviseurClasses.ClearSelection();

        }
        async void fill_dgv_ProviseurShowClassesProf()
        {
            dgv_ProviseurShowClassesProf.Rows.Clear();
            dgv_ProviseurShowClassesProf.Columns.Clear();

            #region style du datagridview
            dgv_ProviseurShowClassesProf.Columns.Add("class_id", "class_id");
            dgv_ProviseurShowClassesProf.Columns.Add("Nom de la classe", "Nom de la classe");

            dgv_ProviseurShowClassesProf.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ProviseurShowClassesProf.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string swowClassesProf = await GetUrlBody("https://localhost:3000/professeur/afficherLesClassesDuProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (swowClassesProf == null) { return; }
            JArray jsonArray = JArray.Parse(swowClassesProf);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ProviseurShowClassesProf.Rows.Add();
                dgv_ProviseurShowClassesProf.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_ProviseurShowClassesProf.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
            }
        }
        async void fill_dgv_ProviseurShowMatieresProf()
        {
            dgv_ProviseurShowMatieresProf.Rows.Clear();
            dgv_ProviseurShowMatieresProf.Columns.Clear();

            #region style du datagridview
            dgv_ProviseurShowMatieresProf.Columns.Add("mat_id", "mat_id");
            dgv_ProviseurShowMatieresProf.Columns.Add("Nom de la mati�re", "Nom de la mati�re");

            dgv_ProviseurShowMatieresProf.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ProviseurShowMatieresProf.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string matieres = await GetUrlBody("https://localhost:3000/professeur/afficherMatieresProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (matieres == null) { return; }
            JArray jsonArray = JArray.Parse(matieres);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ProviseurShowMatieresProf.Rows.Add();
                dgv_ProviseurShowMatieresProf.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_ProviseurShowMatieresProf.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
        }
        async void fill_dgv_MatieresACharge()
        {
            dgv_MatieresACharge.Rows.Clear();
            dgv_MatieresACharge.Columns.Clear();

            #region style du datagridview
            dgv_MatieresACharge.Columns.Add("mat_id", "mat_id");
            dgv_MatieresACharge.Columns.Add("Nom de la mati�re", "Nom de la mati�re");

            dgv_MatieresACharge.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_MatieresACharge.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/professeur/afficherMatieresProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_MatieresACharge.Rows.Add();
                dgv_MatieresACharge.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_MatieresACharge.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
            dgv_MatieresACharge.ClearSelection();

        }
        async void fill_dgv_MatieresDisponibles()
        {
            dgv_MatieresDisponibles.Rows.Clear();
            dgv_MatieresDisponibles.Columns.Clear();

            #region style du datagridview
            dgv_MatieresDisponibles.Columns.Add("mat_id", "mat_id");
            dgv_MatieresDisponibles.Columns.Add("Nom de la matière", "Nom de la matière");

            dgv_MatieresDisponibles.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_MatieresDisponibles.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/professeur/afficherMatieresLibresProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_MatieresDisponibles.Rows.Add();
                dgv_MatieresDisponibles.Rows[rowIndex].Cells[0].Value = jsonObject["mat_id"].ToString();
                dgv_MatieresDisponibles.Rows[rowIndex].Cells[1].Value = jsonObject["mat_nom"].ToString();
            }
            dgv_MatieresDisponibles.ClearSelection();

        }
        async void fill_dgv_ClassesACharge()
        {
            dgv_ClassesACharge.Rows.Clear();
            dgv_ClassesACharge.Columns.Clear();

            #region style du datagridview
            dgv_ClassesACharge.Columns.Add("class_id", "class_id");
            dgv_ClassesACharge.Columns.Add("Nom de la classe", "Nom de la classe");

            dgv_ClassesACharge.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ClassesACharge.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string swowClassesAChargeProf = await GetUrlBody("https://localhost:3000/professeur/afficherLesClassesDuProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (swowClassesAChargeProf == null) { return; }
            JArray jsonArray = JArray.Parse(swowClassesAChargeProf);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ClassesACharge.Rows.Add();
                dgv_ClassesACharge.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_ClassesACharge.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
            }
            dgv_ClassesACharge.ClearSelection();


        }
        async void fill_dgv_ClassesDisponibles()
        {
            dgv_ClassesDisponibles.Rows.Clear();
            dgv_ClassesDisponibles.Columns.Clear();

            #region style du datagridview
            dgv_ClassesDisponibles.Columns.Add("class_id", "class_id");
            dgv_ClassesDisponibles.Columns.Add("Nom de classe", "Nom de classe");

            dgv_ClassesDisponibles.Columns[0].Visible = false;

            foreach (DataGridViewColumn col in dgv_ClassesDisponibles.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            #endregion

            string classes = await GetUrlBody("https://localhost:3000/professeur/afficherClassesLibresProf/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
            if (classes == null) { return; }
            JArray jsonArray = JArray.Parse(classes);

            foreach (JObject jsonObject in jsonArray)
            {
                int rowIndex = dgv_ClassesDisponibles.Rows.Add();
                dgv_ClassesDisponibles.Rows[rowIndex].Cells[0].Value = jsonObject["class_id"].ToString();
                dgv_ClassesDisponibles.Rows[rowIndex].Cells[1].Value = jsonObject["class_nom"].ToString();
            }
            dgv_ClassesDisponibles.ClearSelection();

        }



        //navigation

        private void btn_ProvieurAdmin_Click(object sender, EventArgs e)
        {
            fill_dgv_ProviseurMatieres();
            fill_dgv_ProviseurProfesseurs();
            fill_dgv_ProviseurClasses();


            tc_Main.SelectTab(3);
            tc_Proviseur.SelectedIndex = 0;
        }

        private void btns_retourProviseur(object sender, EventArgs e)
        {
            tc_Proviseur.SelectedIndex = 0;
            tb_modifEleveShowPrenom.Text = "";
            tb_modifEleveShowIdentifiant.Text = "";
            tb_modifEleveShowMdp.Text = "";
            tb_modifEleveShowClass.Text = "";

            tb_modifElevePrenom.Text = "";
            tb_modifEleveIdentifiant.Text = "";
            tb_modifEleveMdp.Text = "";
        }
        private void btns_retourMatClass_Click(object sender, EventArgs e)
        {
            fill_dgv_ProviseurShowMatieresProf();
            fill_dgv_ProviseurShowClassesProf();

            tc_Proviseur.SelectedIndex = 4;

        }
        private void btn_ProviseurAjouterMatiere_Click(object sender, EventArgs e)
        {
            tc_Proviseur.SelectedIndex = 1;

        }

        private void btn_ProviseurAjouterProf_Click(object sender, EventArgs e)
        {
            tc_Proviseur.SelectedIndex = 3;

        }

        private void btn_ProviseurToutsEleves_Click(object sender, EventArgs e)
        {
            tc_Main.SelectTab(2);
            tc_Proviseur.SelectedIndex = 0;
        }

        private void btn_ProviseurModifier_Click(object sender, EventArgs e)
        {
            if (dgv_ProviseurProfesseurs.SelectedRows.Count != 0)
            {
                fill_dgv_ProviseurShowClassesProf();
                fill_dgv_ProviseurShowMatieresProf();
                tb_modifProfShowPrenom.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[1].Value.ToString();
                tb_modifProfShowIdentifiant.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[2].Value.ToString();
                tb_modifProfShowMdp.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[3].Value.ToString();

                tb_modifProfPrenom.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[1].Value.ToString();
                tb_modifProfIdentifiant.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[2].Value.ToString();
                tb_modifProfMdp.Text = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[3].Value.ToString();

                tc_Proviseur.SelectedIndex = 4;

            }
            if (dgv_ProviseurMatieres.SelectedRows.Count != 0)
            {
                tb_ModifMatiereNom.Text = dgv_ProviseurMatieres.SelectedRows[0].Cells[1].Value.ToString();
                tc_Proviseur.SelectedIndex = 2;
            }
            if (dgv_ProviseurClasses.SelectedRows.Count != 0)
            {
                tb_ModifclasseNom.Text = dgv_ProviseurClasses.SelectedRows[0].Cells[1].Value.ToString();

                tc_Proviseur.SelectedIndex = 5;
            }

        }
        private void btn_ProviseurAjouterClasse_Click(object sender, EventArgs e)
        {
            tc_Proviseur.SelectedIndex = 6;

        }

        private void btn_ProviseurModifierClassesProf_Click(object sender, EventArgs e)
        {
            fill_dgv_ClassesDisponibles();
            fill_dgv_ClassesACharge();
            tc_Proviseur.SelectedIndex = 7;
        }

        private void btn_ProviseurModifierMatieresProf_Click(object sender, EventArgs e)
        {
            fill_dgv_MatieresDisponibles();
            fill_dgv_MatieresACharge();

            tc_Proviseur.SelectedIndex = 8;

        }





        //CRUD
        //Insert
        private async void btn_ProviseurAjouterMatiereToDb_Click(object sender, EventArgs e)
        {

            if (tb_AjouterMatiereNom.Text != "")
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter la mati�re: " + tb_AjouterMatiereNom.Text, "Ajouter mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string addRes = await GetUrlBody("https://localhost:3000/proviseur/ajouterMatiere/" + tb_AjouterMatiereNom.Text.Trim());
                    if (addRes == null) { return; }
                    string res = addRes.Replace("\"", "");
                    MessageBox.Show(res);

                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();

                    tb_AjouterMatiereNom.Text = "";

                    tc_Proviseur.SelectedIndex = 0;

                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom pour la mati�re");
            }

        }
        private async void btn_ProviseurAjouterProfToDb_Click(object sender, EventArgs e)
        {
       
            if (tb_ProviseurAddProfPrenomNom.Text != "")
            {
                if (tb_ProviseurAddProfIdentifiant.Text != "")
                {
                    if (tb_ProviseurAddProfMdp.Text != "")
                    {
                        DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter l'�l�ve : " + tb_addElevePrenom.Text, "Ajouter �l�ve", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string addRes = await GetUrlBody("https://localhost:3000/proviseur/ajouterPersonnel/" + tb_ProviseurAddProfPrenomNom.Text.Trim() + "/" + tb_ProviseurAddProfIdentifiant.Text.Trim() + "/" + tb_ProviseurAddProfMdp.Text.Trim() + "/0" );
                            if (addRes == null) { return; }
                            string res = addRes.Replace("\"", "");
                            MessageBox.Show(res);
                            fill_dgv_ProviseurMatieres();
                            fill_dgv_ProviseurProfesseurs();

                            tc_Proviseur.SelectedIndex = 0;
                            tb_ProviseurAddProfPrenomNom.Text = "";
                            tb_ProviseurAddProfIdentifiant.Text = "";
                            tb_ProviseurAddProfMdp.Text = "";
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez entrer un mot de passe pour le professeur");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un identifiant pour le professeur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom pr�nom pour le Professeur");
            }
            

        }
        private async void btn_ProviseurAjouterToDbClasse_Click(object sender, EventArgs e)
        {
            if (tb_ProviseurAjouterClasseNom.Text != "")
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment ajouter la mati�re: " + tb_ProviseurAjouterClasseNom.Text, "Ajouter mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string addRes = await GetUrlBody("https://localhost:3000/proviseur/ajouterClasse/" + tb_ProviseurAjouterClasseNom.Text.Trim());
                    if (addRes == null) { return; }
                    string res = addRes.Replace("\"", "");
                    MessageBox.Show(res);

                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                    fill_dgv_ProviseurClasses();


                    tb_ProviseurAjouterClasseNom.Text = "";

                    tc_Proviseur.SelectedIndex = 0;

                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nom pour la classe");
            }

        }
        //Update
        private async void btn_ProviseurModifierProf_Click(object sender, EventArgs e)
        {
            if (tb_modifProfPrenom.Text != "")
            {
                if (tb_modifProfIdentifiant.Text != "")
                {
                    if (tb_modifProfMdp.Text != "")
                    {
                        DialogResult result = MessageBox.Show("Voulez vous vraiment modifier le professeur : " + tb_modifProfPrenom.Text, "Modifier professeur", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string modifRes = await GetUrlBody("https://localhost:3000/proviseur/modifPersonnel/" + tb_modifProfPrenom.Text.Trim() + "/" + tb_modifProfIdentifiant.Text.Trim() + "/" + tb_modifProfMdp.Text.Trim() + "/0/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString());
                            if (modifRes == null) { return; }
                            string res = modifRes.Replace("\"", "");
                            MessageBox.Show(res);
                            fill_dgv_ProviseurMatieres();
                            fill_dgv_ProviseurProfesseurs();
                            tc_Proviseur.SelectedIndex = 0;
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
                        MessageBox.Show("Veuillez entrer un nouveau mot de passe pour le professeur");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer un nouveau identifiant pour le professeur");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nouveau nom pr�nom pour le professeur");
            }

        }
        private async void btn_ProviseurModifierMatiere_Click(object sender, EventArgs e)
        {
            if (tb_ModifMatiereNom.Text != "")
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment modifier la mati�re : " + tb_ModifMatiereNom.Text, "Modifier mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string modifRes = await GetUrlBody("https://localhost:3000/proviseur/modifMatiere/" + tb_ModifMatiereNom.Text.Trim() + "/" +  dgv_ProviseurMatieres.SelectedRows[0].Cells[0].Value.ToString());
                    if (modifRes == null) { return; }
                    string res = modifRes.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                    tc_Proviseur.SelectedIndex = 0;

                    tb_ModifMatiereNom.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nouveau nom pour votre mati�re");
            }

        }
        private async void btn_ProvieurModifierClasse_Click(object sender, EventArgs e)
        {
            if (tb_ModifclasseNom.Text != "")
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment modifier la mati�re : " + tb_ModifclasseNom.Text, "Modifier mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string modifRes = await GetUrlBody("https://localhost:3000/proviseur/modifClasse/" + tb_ModifclasseNom.Text.Trim() + "/" + dgv_ProviseurClasses.SelectedRows[0].Cells[0].Value.ToString());
                    if (modifRes == null) { return; }
                    string res = modifRes.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                    fill_dgv_ProviseurClasses();

                    tc_Proviseur.SelectedIndex = 0;

                    tb_ModifclasseNom.Text = "";

                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer un nouveau nom pour votre mati�re");
            }

        }
        private async void btn_ProviseurAssignerClasse_Click(object sender, EventArgs e)
        {
            if (dgv_ClassesDisponibles.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment assigner la classe : " + dgv_ClassesDisponibles.SelectedRows[0].Cells[1].Value.ToString(), "Ajouter mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string addRes = await GetUrlBody("https://localhost:3000/proviseur/assignerClasse/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString() + "/" + dgv_ClassesDisponibles.SelectedRows[0].Cells[0].Value.ToString());
                    if (addRes == null) { return; }
                    string res = addRes.Replace("\"", "");
                    MessageBox.Show(res);

                    fill_dgv_ClassesDisponibles();
                    fill_dgv_ClassesACharge();
                    fill_dgv_ProviseurShowClassesProf();

                    tc_Proviseur.SelectedIndex = 7;

                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une matière à assigner");
            }

        }
        private async void btn_ProviseurAssignerMatiere_Click(object sender, EventArgs e)
        {
            if (dgv_MatieresDisponibles.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment assigner la matière : " + dgv_MatieresDisponibles.SelectedRows[0].Cells[1].Value.ToString(), "Ajouter mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string addRes = await GetUrlBody("https://localhost:3000/proviseur/assignerMatiere/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString() + "/" + dgv_MatieresDisponibles.SelectedRows[0].Cells[0].Value.ToString());
                    if (addRes == null) { return; }
                    string res = addRes.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_MatieresDisponibles();
                    fill_dgv_MatieresACharge();
                    fill_dgv_ProviseurShowMatieresProf();

                    tc_Proviseur.SelectedIndex = 8;

                }
            }
            else
            {
                MessageBox.Show("Veuillez selectionner une classe à assigner");
            }

        }
        //delete
        private async void btn_ProviseurSuprimmer_Click(object sender, EventArgs e)
        {
            if (dgv_ProviseurProfesseurs.SelectedRows.Count != 0)
            {
                string profID = dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer ce professeur  ? : \n" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[1].Value.ToString(), "Supprimer prof", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/proviseur/supprimerPersonnel/" + profID);
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                }
                else
                {
                }

            }
            if (dgv_ProviseurMatieres.SelectedRows.Count != 0)
            {
                string matID = dgv_ProviseurMatieres.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer cette mati�re  ? : \n" + dgv_ProviseurMatieres.SelectedRows[0].Cells[1].Value.ToString(), "Supprimer mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/proviseur/supprimerMatiere/" + matID);
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                }
                else
                {
                }
            }
            if (dgv_ProviseurClasses.SelectedRows.Count != 0)
            {
                string classID = dgv_ProviseurClasses.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer cette classe  ? : \n" + dgv_ProviseurClasses.SelectedRows[0].Cells[1].Value.ToString(), "Supprimer mati�re", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/proviseur/supprimerClasse/" + classID);
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ProviseurMatieres();
                    fill_dgv_ProviseurProfesseurs();
                    fill_dgv_ProviseurClasses();

                }
                else
                {
                }
            }
        }

        private async void btn_SuppAssignationMatieres_Click(object sender, EventArgs e)
        {
            if (dgv_MatieresACharge.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment lui supprimer cette matière ? : \n" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[1].Value.ToString(), "Supprimer matière", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/proviseur/suprimmerAsignationMatiere/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString() + "/" + dgv_MatieresACharge.SelectedRows[0].Cells[0].Value.ToString());
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_MatieresACharge();
                    fill_dgv_MatieresDisponibles();
                    tc_Proviseur.SelectedIndex = 8;

                }

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une matière à désasigner");
            }

        }
        private async void btn_SuppAssignationClasse_Click(object sender, EventArgs e)
        {
            if (dgv_ClassesACharge.SelectedRows.Count != 0)
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment lui supprimer cette classe ? : \n" + dgv_ClassesACharge.SelectedRows[0].Cells[1].Value.ToString(), "Supprimer classe", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    string delResult = await GetUrlBody("https://localhost:3000/proviseur/suprimmerAsignationClasse/" + dgv_ProviseurProfesseurs.SelectedRows[0].Cells[0].Value.ToString() + "/" + dgv_ClassesACharge.SelectedRows[0].Cells[0].Value.ToString());
                    if (delResult == null) { return; }
                    string res = delResult.Replace("\"", "");
                    MessageBox.Show(res);
                    fill_dgv_ClassesACharge();
                    fill_dgv_ClassesDisponibles();
                    tc_Proviseur.SelectedIndex = 7;

                }

            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une classe à désasigner");
            }
        }




        //Cont�les de saisie

        private void dgv_ProviseurMatieres_Click(object sender, EventArgs e)
        {
            dgv_ProviseurProfesseurs.ClearSelection();
            dgv_ProviseurClasses.ClearSelection();
        }

        private void dgv_ProviseurProfesseurs_Click(object sender, EventArgs e)
        {
            dgv_ProviseurMatieres.ClearSelection();
            dgv_ProviseurClasses.ClearSelection();
        }
        private void dgv_ProviseurClasses_Click(object sender, EventArgs e)
        {
            dgv_ProviseurProfesseurs.ClearSelection();
            dgv_ProviseurMatieres.ClearSelection();
        }
        private void dgv_ClassesACharge_Click(object sender, EventArgs e)

        {
            dgv_ClassesDisponibles.ClearSelection();
        }
        private void dgv_MatieresACharge_Click(object sender, EventArgs e)

        {
            dgv_MatieresDisponibles.ClearSelection();
        }


    }
}
