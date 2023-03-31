namespace AsimovStudentManager
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_identifiant = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ConnectEleve = new System.Windows.Forms.RadioButton();
            this.rb_ConnectProf = new System.Windows.Forms.RadioButton();
            this.btn_Connexion = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chart_moyennesEleve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tc_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_moyennesEleve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tabPage1);
            this.tc_Main.Controls.Add(this.tabPage2);
            this.tc_Main.Location = new System.Drawing.Point(12, 12);
            this.tc_Main.Name = "tc_Main";
            this.tc_Main.SelectedIndex = 0;
            this.tc_Main.Size = new System.Drawing.Size(1179, 750);
            this.tc_Main.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage1.Controls.Add(this.btn_Connexion);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.tb_mdp);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tb_identifiant);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1171, 724);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.chart_moyennesEleve);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1171, 724);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vue notes éleve";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(197, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "identifiant :";
            // 
            // tb_identifiant
            // 
            this.tb_identifiant.Location = new System.Drawing.Point(270, 251);
            this.tb_identifiant.Name = "tb_identifiant";
            this.tb_identifiant.Size = new System.Drawing.Size(604, 20);
            this.tb_identifiant.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(181, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mot de passe :";
            // 
            // tb_mdp
            // 
            this.tb_mdp.Location = new System.Drawing.Point(270, 356);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.Size = new System.Drawing.Size(604, 20);
            this.tb_mdp.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ConnectProf);
            this.panel1.Controls.Add(this.rb_ConnectEleve);
            this.panel1.Location = new System.Drawing.Point(470, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 28);
            this.panel1.TabIndex = 4;
            // 
            // rb_ConnectEleve
            // 
            this.rb_ConnectEleve.AutoSize = true;
            this.rb_ConnectEleve.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rb_ConnectEleve.ForeColor = System.Drawing.Color.White;
            this.rb_ConnectEleve.Location = new System.Drawing.Point(0, 4);
            this.rb_ConnectEleve.Name = "rb_ConnectEleve";
            this.rb_ConnectEleve.Size = new System.Drawing.Size(52, 19);
            this.rb_ConnectEleve.TabIndex = 0;
            this.rb_ConnectEleve.TabStop = true;
            this.rb_ConnectEleve.Text = "Elève";
            this.rb_ConnectEleve.UseVisualStyleBackColor = true;
            // 
            // rb_ConnectProf
            // 
            this.rb_ConnectProf.AutoSize = true;
            this.rb_ConnectProf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rb_ConnectProf.ForeColor = System.Drawing.Color.White;
            this.rb_ConnectProf.Location = new System.Drawing.Point(120, 3);
            this.rb_ConnectProf.Name = "rb_ConnectProf";
            this.rb_ConnectProf.Size = new System.Drawing.Size(80, 19);
            this.rb_ConnectProf.TabIndex = 1;
            this.rb_ConnectProf.TabStop = true;
            this.rb_ConnectProf.Text = "Profésseur";
            this.rb_ConnectProf.UseVisualStyleBackColor = true;
            // 
            // btn_Connexion
            // 
            this.btn_Connexion.Location = new System.Drawing.Point(503, 446);
            this.btn_Connexion.Name = "btn_Connexion";
            this.btn_Connexion.Size = new System.Drawing.Size(130, 23);
            this.btn_Connexion.TabIndex = 5;
            this.btn_Connexion.Text = "Connexion";
            this.btn_Connexion.UseVisualStyleBackColor = true;
            this.btn_Connexion.Click += new System.EventHandler(this.Connect);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 42);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bienvenue NomEleve";
            // 
            // chart_moyennesEleve
            // 
            this.chart_moyennesEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            chartArea1.Name = "ChartArea1";
            this.chart_moyennesEleve.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_moyennesEleve.Legends.Add(legend1);
            this.chart_moyennesEleve.Location = new System.Drawing.Point(13, 60);
            this.chart_moyennesEleve.Name = "chart_moyennesEleve";
            this.chart_moyennesEleve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_moyennesEleve.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.White};
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.LegendText = "Moyenne";
            series1.Name = "Series1";
            this.chart_moyennesEleve.Series.Add(series1);
            this.chart_moyennesEleve.Size = new System.Drawing.Size(572, 636);
            this.chart_moyennesEleve.TabIndex = 1;
            this.chart_moyennesEleve.Text = "chart1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(631, 60);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(522, 636);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1203, 774);
            this.Controls.Add(this.tc_Main);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tc_Main.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_moyennesEleve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_Main;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Connexion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rb_ConnectProf;
        private System.Windows.Forms.RadioButton rb_ConnectEleve;
        private System.Windows.Forms.TextBox tb_mdp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_identifiant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_moyennesEleve;
        private System.Windows.Forms.Label label3;
    }
}

