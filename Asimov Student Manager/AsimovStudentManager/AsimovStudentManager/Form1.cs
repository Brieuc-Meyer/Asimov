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

namespace AsimovStudentManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tc_Main.Appearance = TabAppearance.FlatButtons;
            tc_Main.ItemSize = new Size(0, 1);
            tc_Main.SizeMode = TabSizeMode.Fixed;
            tb_identifiant.Text = "jean.dupont";
            tb_mdp.Text = "root";
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
            string ID = "";
            //verification que il y à bien des valeurs d'entrées
            if (tb_identifiant.Text != "" && label2.Text != "")
            {
                //si il a séléctionné la connexion de type éleve
                if (rb_ConnectEleve.Checked && rb_ConnectProf.Checked == false)
                {
                    List<Note> NotesEleve = new List<Note>();
                    string bodyResponse = await GetUrlBody("https://localhost:3000/connexionEleve/" + tb_identifiant.Text + "/" + tb_mdp.Text);
                    string response = bodyResponse.Replace("\"", "");
                    string keyWord = "Bonjour";

                    if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                    {
                        lb_pageEleveTitle.Text = response.Split(new[] { ';' })[0];
                        tc_Main.SelectTab(1);
                        ID = response.Split(new[] { ';' })[1];
                        string notes = await GetUrlBody("https://localhost:3000/eleve/" + ID + "/notes");
                        JArray jsonArray = JArray.Parse(notes);

                        foreach (JObject jsonObject in jsonArray)
                        {
                            Note newnote = new Note(Int32.Parse(jsonObject["note_id"].ToString()), Int32.Parse(jsonObject["note_eleve_id"].ToString()), Int32.Parse(jsonObject["note_pourcent"].ToString()), Int32.Parse(jsonObject["note_prof_id"].ToString()), Int32.Parse(jsonObject["note_mat_id"].ToString()), Convert.ToDateTime(jsonObject["note_date_evaluation"].ToString()), jsonObject["note_intitule"].ToString(), jsonObject["note_description"].ToString(), jsonObject["mat_nom"].ToString(), jsonObject["perso_nom"].ToString());
                            NotesEleve.Add(newnote);
                        }

                        #region Ajout et style des colonnes
                        dgv_NotesEleve.Columns.Add("note_id", "note_id");
                        dgv_NotesEleve.Columns.Add("note_eleve_id", "note_eleve_id");
                        dgv_NotesEleve.Columns.Add("Résultat", "Résultat");
                        dgv_NotesEleve.Columns.Add("Profésseur", "Profésseur");
                        dgv_NotesEleve.Columns.Add("Matière", "Matière");
                        dgv_NotesEleve.Columns.Add("Date", "Date");
                        dgv_NotesEleve.Columns.Add("Intitulé", "Intitulé");
                        dgv_NotesEleve.Columns.Add("Déscription", "Déscription");

                        foreach(DataGridViewColumn col in dgv_NotesEleve.Columns)
                        {
                            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                            col.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                        }

                        dgv_NotesEleve.Columns[0].Visible = false;
                        dgv_NotesEleve.Columns[1].Visible = false;
                        #endregion

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
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }

                    //si il a séléctionné la connexion de type professeur
                }
                else if (rb_ConnectProf.Checked && rb_ConnectEleve.Checked == false)
                {
                    string bodyResponse = await GetUrlBody("https://localhost:3000/connexionProfesseur/" + tb_identifiant.Text + "/" + label2.Text);
                    string response = bodyResponse.Replace("\"", "");
                    string keyWord = "Bonjour";
                    if (response.Split(new[] { ' ' })[0].Trim() == keyWord)
                    {
                        tc_Main.SelectTab(1);
                        MessageBox.Show(response.Split(new[] { ';' })[0]);
                        ID = response.Split(new[] { ';' })[1];
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }

                    //si il a séléctionné auncun type de connexion
                }
                else
                {
                    MessageBox.Show("Veuillez séléctionner un mode de connexion");
                }

                //si il n'a pas rempli les informations de connexion
            }
            else
            {
                MessageBox.Show("Veuillez rentrer un identifiant et un mot de passe");
            }
        }
    }
}
