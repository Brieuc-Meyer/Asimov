using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    string bodyResponse = await GetUrlBody("https://localhost:3000/connexionEleve/" + tb_identifiant.Text + "/" + tb_mdp.Text);
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
