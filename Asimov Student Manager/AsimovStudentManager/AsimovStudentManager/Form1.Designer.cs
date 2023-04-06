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
            this.tc_Prof = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_DelEleve = new System.Windows.Forms.Button();
            this.btn_modifEleve = new System.Windows.Forms.Button();
            this.btn_addEleve = new System.Windows.Forms.Button();
            this.dgv_ProfEleves = new System.Windows.Forms.DataGridView();
            this.lb_pageProfTitle = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_addEleveRetour = new System.Windows.Forms.Button();
            this.btn_addEleveToDb = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_addEleveMdp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_addEleveIdentifiant = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_addElevePrenom = new System.Windows.Forms.TextBox();
            this.dgv_addEleveClasses = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_modifEleveMdp = new System.Windows.Forms.TextBox();
            this.tb_modifElevePrenom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_modifEleveIdentifiant = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tb_modifEleveShowClass = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tb_modifEleveShowMdp = new System.Windows.Forms.TextBox();
            this.tb_modifEleveShowPrenom = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tb_modifEleveShowIdentifiant = new System.Windows.Forms.TextBox();
            this.btn_retourModifEleve = new System.Windows.Forms.Button();
            this.btn_ModifEleveToDb = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_modifEleveClass = new System.Windows.Forms.DataGridView();
            this.tc_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NotesEleve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_moyennesEleve)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tc_Prof.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProfEleves)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addEleveClasses)).BeginInit();
            this.tabPage6.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modifEleveClass)).BeginInit();
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
            this.tabPage3.Controls.Add(this.tc_Prof);
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
            this.btn_DisconnectProf.Click += new System.EventHandler(this.btn_DisconnectProf_Click);
            // 
            // tc_Prof
            // 
            this.tc_Prof.Controls.Add(this.tabPage4);
            this.tc_Prof.Controls.Add(this.tabPage5);
            this.tc_Prof.Controls.Add(this.tabPage6);
            this.tc_Prof.Location = new System.Drawing.Point(3, 39);
            this.tc_Prof.Name = "tc_Prof";
            this.tc_Prof.SelectedIndex = 0;
            this.tc_Prof.Size = new System.Drawing.Size(1165, 693);
            this.tc_Prof.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage4.Controls.Add(this.button4);
            this.tabPage4.Controls.Add(this.btn_DelEleve);
            this.tabPage4.Controls.Add(this.btn_modifEleve);
            this.tabPage4.Controls.Add(this.btn_addEleve);
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
            // btn_modifEleve
            // 
            this.btn_modifEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(38)))), ((int)(((byte)(115)))));
            this.btn_modifEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.btn_modifEleve.ForeColor = System.Drawing.Color.White;
            this.btn_modifEleve.Location = new System.Drawing.Point(298, 609);
            this.btn_modifEleve.Name = "btn_modifEleve";
            this.btn_modifEleve.Size = new System.Drawing.Size(272, 52);
            this.btn_modifEleve.TabIndex = 5;
            this.btn_modifEleve.Text = "Modifier élève";
            this.btn_modifEleve.UseVisualStyleBackColor = false;
            this.btn_modifEleve.Click += new System.EventHandler(this.btn_modifEleve_Click);
            // 
            // btn_addEleve
            // 
            this.btn_addEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(23)))));
            this.btn_addEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addEleve.ForeColor = System.Drawing.Color.White;
            this.btn_addEleve.Location = new System.Drawing.Point(13, 609);
            this.btn_addEleve.Name = "btn_addEleve";
            this.btn_addEleve.Size = new System.Drawing.Size(272, 52);
            this.btn_addEleve.TabIndex = 4;
            this.btn_addEleve.Text = "Ajouter élève";
            this.btn_addEleve.UseVisualStyleBackColor = false;
            this.btn_addEleve.Click += new System.EventHandler(this.btn_addEleve_Click);
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
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage5.Controls.Add(this.btn_addEleveRetour);
            this.tabPage5.Controls.Add(this.btn_addEleveToDb);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.tb_addEleveMdp);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.tb_addEleveIdentifiant);
            this.tabPage5.Controls.Add(this.label4);
            this.tabPage5.Controls.Add(this.tb_addElevePrenom);
            this.tabPage5.Controls.Add(this.dgv_addEleveClasses);
            this.tabPage5.Controls.Add(this.label3);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1157, 667);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Ajouter un élève";
            // 
            // btn_addEleveRetour
            // 
            this.btn_addEleveRetour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_addEleveRetour.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addEleveRetour.ForeColor = System.Drawing.Color.White;
            this.btn_addEleveRetour.Location = new System.Drawing.Point(578, 609);
            this.btn_addEleveRetour.Name = "btn_addEleveRetour";
            this.btn_addEleveRetour.Size = new System.Drawing.Size(560, 52);
            this.btn_addEleveRetour.TabIndex = 12;
            this.btn_addEleveRetour.Text = "Retour";
            this.btn_addEleveRetour.UseVisualStyleBackColor = false;
            this.btn_addEleveRetour.Click += new System.EventHandler(this.btn_addEleveRetour_Click);
            // 
            // btn_addEleveToDb
            // 
            this.btn_addEleveToDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(23)))));
            this.btn_addEleveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addEleveToDb.ForeColor = System.Drawing.Color.White;
            this.btn_addEleveToDb.Location = new System.Drawing.Point(17, 609);
            this.btn_addEleveToDb.Name = "btn_addEleveToDb";
            this.btn_addEleveToDb.Size = new System.Drawing.Size(555, 52);
            this.btn_addEleveToDb.TabIndex = 11;
            this.btn_addEleveToDb.Text = "Ajouter élève";
            this.btn_addEleveToDb.UseVisualStyleBackColor = false;
            this.btn_addEleveToDb.Click += new System.EventHandler(this.btn_addEleveToDb_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(578, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(175, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Classe de l\'élève";
            // 
            // tb_addEleveMdp
            // 
            this.tb_addEleveMdp.Location = new System.Drawing.Point(307, 391);
            this.tb_addEleveMdp.Name = "tb_addEleveMdp";
            this.tb_addEleveMdp.Size = new System.Drawing.Size(200, 20);
            this.tb_addEleveMdp.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(152, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mot de passe";
            // 
            // tb_addEleveIdentifiant
            // 
            this.tb_addEleveIdentifiant.Location = new System.Drawing.Point(307, 303);
            this.tb_addEleveIdentifiant.Name = "tb_addEleveIdentifiant";
            this.tb_addEleveIdentifiant.Size = new System.Drawing.Size(200, 20);
            this.tb_addEleveIdentifiant.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(50, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(244, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Identifiant (prénom.nom)";
            // 
            // tb_addElevePrenom
            // 
            this.tb_addElevePrenom.Location = new System.Drawing.Point(307, 215);
            this.tb_addElevePrenom.Name = "tb_addElevePrenom";
            this.tb_addElevePrenom.Size = new System.Drawing.Size(200, 20);
            this.tb_addElevePrenom.TabIndex = 5;
            // 
            // dgv_addEleveClasses
            // 
            this.dgv_addEleveClasses.AllowUserToAddRows = false;
            this.dgv_addEleveClasses.AllowUserToDeleteRows = false;
            this.dgv_addEleveClasses.AllowUserToOrderColumns = true;
            this.dgv_addEleveClasses.AllowUserToResizeColumns = false;
            this.dgv_addEleveClasses.AllowUserToResizeRows = false;
            this.dgv_addEleveClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_addEleveClasses.Location = new System.Drawing.Point(578, 59);
            this.dgv_addEleveClasses.MultiSelect = false;
            this.dgv_addEleveClasses.Name = "dgv_addEleveClasses";
            this.dgv_addEleveClasses.ReadOnly = true;
            this.dgv_addEleveClasses.RowHeadersVisible = false;
            this.dgv_addEleveClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_addEleveClasses.Size = new System.Drawing.Size(560, 544);
            this.dgv_addEleveClasses.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(64, 212);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Prénom nom de l\'élève";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.panel3);
            this.tabPage6.Controls.Add(this.panel2);
            this.tabPage6.Controls.Add(this.btn_retourModifEleve);
            this.tabPage6.Controls.Add(this.btn_ModifEleveToDb);
            this.tabPage6.Controls.Add(this.label7);
            this.tabPage6.Controls.Add(this.dgv_modifEleveClass);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(1157, 667);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "Modifier un élève";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(18, 328);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(293, 25);
            this.label15.TabIndex = 32;
            this.label15.Text = "Nouvelles données de l\'élève";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(18, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(306, 25);
            this.label14.TabIndex = 31;
            this.label14.Text = "Elève en cours de modification";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.tb_modifEleveMdp);
            this.panel3.Controls.Add(this.tb_modifElevePrenom);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tb_modifEleveIdentifiant);
            this.panel3.Location = new System.Drawing.Point(18, 356);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(555, 234);
            this.panel3.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(47, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(230, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Prénom nom de l\'élève";
            // 
            // tb_modifEleveMdp
            // 
            this.tb_modifEleveMdp.Location = new System.Drawing.Point(290, 197);
            this.tb_modifEleveMdp.Name = "tb_modifEleveMdp";
            this.tb_modifEleveMdp.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveMdp.TabIndex = 28;
            // 
            // tb_modifElevePrenom
            // 
            this.tb_modifElevePrenom.Location = new System.Drawing.Point(290, 21);
            this.tb_modifElevePrenom.Name = "tb_modifElevePrenom";
            this.tb_modifElevePrenom.Size = new System.Drawing.Size(200, 20);
            this.tb_modifElevePrenom.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(135, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(142, 25);
            this.label9.TabIndex = 27;
            this.label9.Text = "Mot de passe";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(33, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "Identifiant (prénom.nom)";
            // 
            // tb_modifEleveIdentifiant
            // 
            this.tb_modifEleveIdentifiant.Location = new System.Drawing.Point(290, 109);
            this.tb_modifEleveIdentifiant.Name = "tb_modifEleveIdentifiant";
            this.tb_modifEleveIdentifiant.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveIdentifiant.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.panel2.Controls.Add(this.tb_modifEleveShowClass);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.tb_modifEleveShowMdp);
            this.panel2.Controls.Add(this.tb_modifEleveShowPrenom);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.tb_modifEleveShowIdentifiant);
            this.panel2.Location = new System.Drawing.Point(18, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 231);
            this.panel2.TabIndex = 29;
            // 
            // tb_modifEleveShowClass
            // 
            this.tb_modifEleveShowClass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tb_modifEleveShowClass.ForeColor = System.Drawing.Color.White;
            this.tb_modifEleveShowClass.Location = new System.Drawing.Point(290, 189);
            this.tb_modifEleveShowClass.Name = "tb_modifEleveShowClass";
            this.tb_modifEleveShowClass.ReadOnly = true;
            this.tb_modifEleveShowClass.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveShowClass.TabIndex = 30;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(102, 186);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(175, 25);
            this.label16.TabIndex = 29;
            this.label16.Text = "Classe de l\'élève";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(47, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(230, 25);
            this.label13.TabIndex = 23;
            this.label13.Text = "Prénom nom de l\'élève";
            // 
            // tb_modifEleveShowMdp
            // 
            this.tb_modifEleveShowMdp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tb_modifEleveShowMdp.ForeColor = System.Drawing.Color.White;
            this.tb_modifEleveShowMdp.Location = new System.Drawing.Point(290, 133);
            this.tb_modifEleveShowMdp.Name = "tb_modifEleveShowMdp";
            this.tb_modifEleveShowMdp.ReadOnly = true;
            this.tb_modifEleveShowMdp.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveShowMdp.TabIndex = 28;
            // 
            // tb_modifEleveShowPrenom
            // 
            this.tb_modifEleveShowPrenom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tb_modifEleveShowPrenom.ForeColor = System.Drawing.Color.White;
            this.tb_modifEleveShowPrenom.Location = new System.Drawing.Point(290, 21);
            this.tb_modifEleveShowPrenom.Name = "tb_modifEleveShowPrenom";
            this.tb_modifEleveShowPrenom.ReadOnly = true;
            this.tb_modifEleveShowPrenom.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveShowPrenom.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(135, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 25);
            this.label11.TabIndex = 27;
            this.label11.Text = "Mot de passe";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(33, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(244, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "Identifiant (prénom.nom)";
            // 
            // tb_modifEleveShowIdentifiant
            // 
            this.tb_modifEleveShowIdentifiant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tb_modifEleveShowIdentifiant.ForeColor = System.Drawing.Color.White;
            this.tb_modifEleveShowIdentifiant.Location = new System.Drawing.Point(290, 77);
            this.tb_modifEleveShowIdentifiant.Name = "tb_modifEleveShowIdentifiant";
            this.tb_modifEleveShowIdentifiant.ReadOnly = true;
            this.tb_modifEleveShowIdentifiant.Size = new System.Drawing.Size(200, 20);
            this.tb_modifEleveShowIdentifiant.TabIndex = 26;
            // 
            // btn_retourModifEleve
            // 
            this.btn_retourModifEleve.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.btn_retourModifEleve.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_retourModifEleve.ForeColor = System.Drawing.Color.White;
            this.btn_retourModifEleve.Location = new System.Drawing.Point(579, 596);
            this.btn_retourModifEleve.Name = "btn_retourModifEleve";
            this.btn_retourModifEleve.Size = new System.Drawing.Size(560, 52);
            this.btn_retourModifEleve.TabIndex = 22;
            this.btn_retourModifEleve.Text = "Retour";
            this.btn_retourModifEleve.UseVisualStyleBackColor = false;
            this.btn_retourModifEleve.Click += new System.EventHandler(this.btn_retourModifEleve_Click);
            // 
            // btn_ModifEleveToDb
            // 
            this.btn_ModifEleveToDb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(115)))), ((int)(((byte)(23)))));
            this.btn_ModifEleveToDb.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ModifEleveToDb.ForeColor = System.Drawing.Color.White;
            this.btn_ModifEleveToDb.Location = new System.Drawing.Point(18, 596);
            this.btn_ModifEleveToDb.Name = "btn_ModifEleveToDb";
            this.btn_ModifEleveToDb.Size = new System.Drawing.Size(555, 52);
            this.btn_ModifEleveToDb.TabIndex = 21;
            this.btn_ModifEleveToDb.Text = "Modifier l\'élève";
            this.btn_ModifEleveToDb.UseVisualStyleBackColor = false;
            this.btn_ModifEleveToDb.Click += new System.EventHandler(this.btn_ModifEleveToDb_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(579, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(261, 25);
            this.label7.TabIndex = 20;
            this.label7.Text = "Nouvelle classe de l\'élève";
            // 
            // dgv_modifEleveClass
            // 
            this.dgv_modifEleveClass.AllowUserToAddRows = false;
            this.dgv_modifEleveClass.AllowUserToDeleteRows = false;
            this.dgv_modifEleveClass.AllowUserToOrderColumns = true;
            this.dgv_modifEleveClass.AllowUserToResizeColumns = false;
            this.dgv_modifEleveClass.AllowUserToResizeRows = false;
            this.dgv_modifEleveClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_modifEleveClass.Location = new System.Drawing.Point(579, 46);
            this.dgv_modifEleveClass.MultiSelect = false;
            this.dgv_modifEleveClass.Name = "dgv_modifEleveClass";
            this.dgv_modifEleveClass.ReadOnly = true;
            this.dgv_modifEleveClass.RowHeadersVisible = false;
            this.dgv_modifEleveClass.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_modifEleveClass.Size = new System.Drawing.Size(560, 544);
            this.dgv_modifEleveClass.TabIndex = 14;
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
            this.tc_Prof.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ProfEleves)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_addEleveClasses)).EndInit();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_modifEleveClass)).EndInit();
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
        private System.Windows.Forms.TabControl tc_Prof;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lb_pageProfTitle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_DelEleve;
        private System.Windows.Forms.Button btn_modifEleve;
        private System.Windows.Forms.Button btn_addEleve;
        private System.Windows.Forms.DataGridView dgv_ProfEleves;
        private System.Windows.Forms.Button btn_DisconnectProf;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox tb_addElevePrenom;
        private System.Windows.Forms.DataGridView dgv_addEleveClasses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_addEleveMdp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_addEleveIdentifiant;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_addEleveRetour;
        private System.Windows.Forms.Button btn_addEleveToDb;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_modifEleveMdp;
        private System.Windows.Forms.TextBox tb_modifElevePrenom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_modifEleveIdentifiant;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tb_modifEleveShowClass;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tb_modifEleveShowMdp;
        private System.Windows.Forms.TextBox tb_modifEleveShowPrenom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tb_modifEleveShowIdentifiant;
        private System.Windows.Forms.Button btn_retourModifEleve;
        private System.Windows.Forms.Button btn_ModifEleveToDb;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_modifEleveClass;
    }
}

