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
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Connexion = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ConnectProf = new System.Windows.Forms.RadioButton();
            this.rb_ConnectEleve = new System.Windows.Forms.RadioButton();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_identifiant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_DisconnectEleve = new System.Windows.Forms.Button();
            this.dgv_NotesEleve = new System.Windows.Forms.DataGridView();
            this.chart_moyennesEleve = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lb_pageEleveTitle = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btn_DisconnectProf = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_DelEleve = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgv_ProfEleves = new System.Windows.Forms.DataGridView();
            this.lb_pageProfTitle = new System.Windows.Forms.Label();
            this.tc_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NotesEleve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_moyennesEleve)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProfEleves)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_Main
            // 
            this.tc_Main.Controls.Add(this.tabPage1);
            this.tc_Main.Controls.Add(this.tabPage2);
            this.tc_Main.Controls.Add(this.tabPage3);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ConnectProf);
            this.panel1.Controls.Add(this.rb_ConnectEleve);
            this.panel1.Location = new System.Drawing.Point(470, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 28);
            this.panel1.TabIndex = 4;
            // 
            // rb_ConnectProf
            // 
            this.rb_ConnectProf.AutoSize = true;
            this.rb_ConnectProf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rb_ConnectProf.ForeColor = System.Drawing.Color.White;
            this.rb_ConnectProf.Location = new System.Drawing.Point(120, 3);
            this.rb_ConnectProf.Name = "rb_ConnectProf";
            this.rb_ConnectProf.Size = new System.Drawing.Size(77, 19);
            this.rb_ConnectProf.TabIndex = 1;
            this.rb_ConnectProf.TabStop = true;
            this.rb_ConnectProf.Text = "Personnel";
            this.rb_ConnectProf.UseVisualStyleBackColor = true;
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
            // tb_mdp
            // 
            this.tb_mdp.Location = new System.Drawing.Point(270, 356);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.PasswordChar = '*';
            this.tb_mdp.Size = new System.Drawing.Size(604, 20);
            this.tb_mdp.TabIndex = 3;
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
            // tb_identifiant
            // 
            this.tb_identifiant.Location = new System.Drawing.Point(270, 251);
            this.tb_identifiant.Name = "tb_identifiant";
            this.tb_identifiant.Size = new System.Drawing.Size(604, 20);
            this.tb_identifiant.TabIndex = 1;
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
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Controls.Add(this.btn_DisconnectEleve);
            this.tabPage2.Controls.Add(this.dgv_NotesEleve);
            this.tabPage2.Controls.Add(this.chart_moyennesEleve);
            this.tabPage2.Controls.Add(this.lb_pageEleveTitle);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1171, 724);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vue notes éleve";
            // 
            // btn_DisconnectEleve
            // 
            this.btn_DisconnectEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_DisconnectEleve.ForeColor = System.Drawing.Color.White;
            this.btn_DisconnectEleve.Location = new System.Drawing.Point(982, 14);
            this.btn_DisconnectEleve.Name = "btn_DisconnectEleve";
            this.btn_DisconnectEleve.Size = new System.Drawing.Size(171, 29);
            this.btn_DisconnectEleve.TabIndex = 4;
            this.btn_DisconnectEleve.Text = "Se déconnecter";
            this.btn_DisconnectEleve.UseVisualStyleBackColor = false;
            this.btn_DisconnectEleve.Click += new System.EventHandler(this.btn_DisconnectEleve_Click);
            // 
            // dgv_NotesEleve
            // 
            this.dgv_NotesEleve.AllowUserToAddRows = false;
            this.dgv_NotesEleve.AllowUserToDeleteRows = false;
            this.dgv_NotesEleve.AllowUserToResizeColumns = false;
            this.dgv_NotesEleve.AllowUserToResizeRows = false;
            this.dgv_NotesEleve.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.dgv_NotesEleve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NotesEleve.Location = new System.Drawing.Point(631, 60);
            this.dgv_NotesEleve.MultiSelect = false;
            this.dgv_NotesEleve.Name = "dgv_NotesEleve";
            this.dgv_NotesEleve.ReadOnly = true;
            this.dgv_NotesEleve.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgv_NotesEleve.RowHeadersVisible = false;
            this.dgv_NotesEleve.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_NotesEleve.Size = new System.Drawing.Size(522, 636);
            this.dgv_NotesEleve.TabIndex = 3;
            this.dgv_NotesEleve.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_NotesEleve_CellDoubleClick);
            // 
            // chart_moyennesEleve
            // 
            this.chart_moyennesEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.chart_moyennesEleve.Location = new System.Drawing.Point(13, 60);
            this.chart_moyennesEleve.Name = "chart_moyennesEleve";
            this.chart_moyennesEleve.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_moyennesEleve.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.White};
            this.chart_moyennesEleve.Size = new System.Drawing.Size(572, 636);
            this.chart_moyennesEleve.TabIndex = 1;
            this.chart_moyennesEleve.Text = "chart1";
            // 
            // lb_pageEleveTitle
            // 
            this.lb_pageEleveTitle.AutoSize = true;
            this.lb_pageEleveTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pageEleveTitle.ForeColor = System.Drawing.Color.White;
            this.lb_pageEleveTitle.Location = new System.Drawing.Point(6, 3);
            this.lb_pageEleveTitle.Name = "lb_pageEleveTitle";
            this.lb_pageEleveTitle.Size = new System.Drawing.Size(329, 42);
            this.lb_pageEleveTitle.TabIndex = 0;
            this.lb_pageEleveTitle.Text = "Bonjour NomEleve";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage3.Controls.Add(this.btn_DisconnectProf);
            this.tabPage3.Controls.Add(this.tabControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1171, 724);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "MainProf";
            // 
            // btn_DisconnectProf
            // 
            this.btn_DisconnectProf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btn_DisconnectProf.ForeColor = System.Drawing.Color.White;
            this.btn_DisconnectProf.Location = new System.Drawing.Point(993, 8);
            this.btn_DisconnectProf.Name = "btn_DisconnectProf";
            this.btn_DisconnectProf.Size = new System.Drawing.Size(171, 29);
            this.btn_DisconnectProf.TabIndex = 5;
            this.btn_DisconnectProf.Text = "Se déconnecter";
            this.btn_DisconnectProf.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1165, 693);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.btn_DelEleve);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.button1);
            this.tabPage4.Controls.Add(this.dgv_ProfEleves);
            this.tabPage4.Controls.Add(this.lb_pageProfTitle);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1157, 667);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Vue élèves du prof";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(70)))), ((int)(((byte)(0)))));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(869, 609);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(272, 52);
            this.button4.TabIndex = 7;
            this.button4.Text = "Voir notes de l\'élève";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // btn_DelEleve
            // 
            this.btn_DelEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(115)))), ((int)(((byte)(0)))), ((int)(((byte)(11)))));
            this.btn_DelEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btn_DelEleve.ForeColor = System.Drawing.Color.White;
            this.btn_DelEleve.Location = new System.Drawing.Point(584, 609);
            this.btn_DelEleve.Name = "btn_DelEleve";
            this.btn_DelEleve.Size = new System.Drawing.Size(272, 52);
            this.btn_DelEleve.TabIndex = 6;
            this.btn_DelEleve.Text = "Supprimer élève";
            this.btn_DelEleve.UseVisualStyleBackColor = false;
            this.btn_DelEleve.Click += new System.EventHandler(this.btn_DelEleve_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(115)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(298, 609);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(272, 52);
            this.button2.TabIndex = 5;
            this.button2.Text = "Modifier élève";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(23)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(13, 609);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(272, 52);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ajouter élève";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // dgv_ProfEleves
            // 
            this.dgv_ProfEleves.AllowUserToAddRows = false;
            this.dgv_ProfEleves.AllowUserToDeleteRows = false;
            this.dgv_ProfEleves.AllowUserToOrderColumns = true;
            this.dgv_ProfEleves.AllowUserToResizeColumns = false;
            this.dgv_ProfEleves.AllowUserToResizeRows = false;
            this.dgv_ProfEleves.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ProfEleves.Location = new System.Drawing.Point(13, 48);
            this.dgv_ProfEleves.MultiSelect = false;
            this.dgv_ProfEleves.Name = "dgv_ProfEleves";
            this.dgv_ProfEleves.ReadOnly = true;
            this.dgv_ProfEleves.RowHeadersVisible = false;
            this.dgv_ProfEleves.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_ProfEleves.Size = new System.Drawing.Size(1128, 555);
            this.dgv_ProfEleves.TabIndex = 3;
            // 
            // lb_pageProfTitle
            // 
            this.lb_pageProfTitle.AutoSize = true;
            this.lb_pageProfTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_pageProfTitle.ForeColor = System.Drawing.Color.White;
            this.lb_pageProfTitle.Location = new System.Drawing.Point(6, 3);
            this.lb_pageProfTitle.Name = "lb_pageProfTitle";
            this.lb_pageProfTitle.Size = new System.Drawing.Size(303, 42);
            this.lb_pageProfTitle.TabIndex = 2;
            this.lb_pageProfTitle.Text = "Bonjour NomProf";
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NotesEleve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_moyennesEleve)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProfEleves)).EndInit();
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
        private System.Windows.Forms.DataGridView dgv_NotesEleve;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_moyennesEleve;
        private System.Windows.Forms.Label lb_pageEleveTitle;
        private System.Windows.Forms.Button btn_DisconnectEleve;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lb_pageProfTitle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_DelEleve;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgv_ProfEleves;
        private System.Windows.Forms.Button btn_DisconnectProf;
    }
}

