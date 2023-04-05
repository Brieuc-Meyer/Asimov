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
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json.Nodes;
using System.Windows.Forms.DataVisualization.Charting;

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
            tb_identifiant.Text = "marc.leroy";
            tb_mdp.Text = "root";

            #region chart style
            // Rajout du "ChartArea"
            chart_moyennesEleve.ChartAreas.Clear();
            chart_moyennesEleve.ChartAreas.Add(new ChartArea("MyChartArea"));

            // Ajout de la série du chart
            chart_moyennesEleve.Series.Clear();
            Series series = new Series("Moyenne");
            chart_moyennesEleve.Series.Add(series);

            // Propriétés du chart
            chart_moyennesEleve.Titles.Add("Moyenne par sujet");
            chart_moyennesEleve.ChartAreas["MyChartArea"].AxisX.Title = "Matière";
            chart_moyennesEleve.ChartAreas["MyChartArea"].AxisY.Title = "Pourcentage";

            // Rajout d'une légende
            chart_moyennesEleve.Legends.Clear();
            chart_moyennesEleve.Legends.Add("Moyenne");
            #endregion

            #region Ajout et style des colonnes
            dgv_NotesEleve.Columns.Add("note_id", "note_id");
            dgv_NotesEleve.Columns.Add("note_eleve_id", "note_eleve_id");
            dgv_NotesEleve.Columns.Add("Résultat", "Résultat");
            dgv_NotesEleve.Columns.Add("Professeur", "Professeur");
            dgv_NotesEleve.Columns.Add("Matière", "Matière");
            dgv_NotesEleve.Columns.Add("Date", "Date");
            dgv_NotesEleve.Columns.Add("Intitulé", "Intitulé");
            dgv_NotesEleve.Columns.Add("Déscription", "Déscription");

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
                handler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                using (var client = new HttpClient(handler))
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
            }
        }

        async void Connect(Object sender, EventArgs e)
        {
            //verification que il y à bien des valeurs d'entrées
            if (tb_identifiant.Text != "" && tb_mdp.Text != "")
            {
                #region si il a séléctionné la connexion de type éleve
                if (rb_ConnectEleve.Checked && rb_ConnectProf.Checked == false)
                {
                    string bodyResponse = await GetUrlBody("https://localhost:3000/connexionEleve/" + tb_identifiant.Text + "/" + tb_mdp.Text);
                    string response = bodyResponse.Replace("\"", "");
                    string keyWord = "Bonjour";

                    if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                    {
                        lb_pageEleveTitle.Text = response.Split(new[] { ';' })[0];
                        this.ID = response.Split(new[] { ';' })[1];
                        string notes = await GetUrlBody("https://localhost:3000/eleve/" + this.ID + "/notes");
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

                    //si il a séléctionné la connexion de type professeur
                }
                #endregion

                #region si il a séléctioné la connexion de type prof
                else if (rb_ConnectProf.Checked && rb_ConnectEleve.Checked == false)
                {
                    string bodyResponse = await GetUrlBody("https://localhost:3000/connexionProfesseur/" + tb_identifiant.Text + "/" + tb_mdp.Text);
                    string response = bodyResponse.Replace("\"", "");
                    string keyWord = "Bonjour";
                    if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                    {
                        ID = response.Split(new[] { ';' })[1];
                        lb_pageProfTitle.Text = response.Split(new[] { ';' })[0];

                        string profEleves = await GetUrlBody("https://localhost:3000/professeur/" + ID.ToString() + "/voireleves");
                        JArray jsonArray = JArray.Parse(profEleves);

                        #region style datagridview eleves du prof
                        dgv_ProfEleves.Columns.Add("eleve_id", "eleve_id");
                        dgv_ProfEleves.Columns[0].Visible = false;
                        dgv_ProfEleves.Columns.Add("Nom de l'élève", "Nom de l'élève");
                        dgv_ProfEleves.Columns.Add("Classe de l'élève", "Classe de l'élève");
                        foreach (DataGridViewColumn col in dgv_ProfEleves.Columns)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        }
                        #endregion

                        foreach (JObject jsonObject in jsonArray)
                        {
                            int rowIndex = dgv_ProfEleves.Rows.Add();
                            dgv_ProfEleves.Rows[rowIndex].Cells[0].Value = jsonObject["eleve_id"];
                            dgv_ProfEleves.Rows[rowIndex].Cells[1].Value = jsonObject["eleve_nom"];
                            dgv_ProfEleves.Rows[rowIndex].Cells[2].Value = jsonObject["class_nom"];
                        }


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
                    MessageBox.Show("Veuillez séléctionner un mode de connexion");
                }
                #endregion
            }
            else //Si auncun mdp ou aucun identifiant rempli
            {
                MessageBox.Show("Veuillez rentrer un identifiant et un mot de passe");
            }
        }

        async void setGraphMoyennes()
        {
            string Moyennes = await GetUrlBody("https://localhost:3000/eleve/"+ this.ID +"/moyennes");
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

        private void btn_DisconnectEleve_Click(object sender, EventArgs e)
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
        }

        async void btn_DelEleve_Click(object sender, EventArgs e)
        {
            if (dgv_ProfEleves.SelectedRows.Count != 0)
            {
                MessageBox.Show(dgv_ProfEleves.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
