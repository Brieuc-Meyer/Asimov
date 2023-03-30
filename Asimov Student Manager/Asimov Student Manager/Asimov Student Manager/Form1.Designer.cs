namespace Asimov_Student_Manager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tc_Main = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rb_ConnectProf = new System.Windows.Forms.RadioButton();
            this.rb_ConnectEleve = new System.Windows.Forms.RadioButton();
            this.btn_Connexion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.tb_identifiant = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tc_Main.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
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
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.btn_Connexion);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tb_mdp);
            this.tabPage1.Controls.Add(this.tb_identifiant);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1171, 722);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rb_ConnectProf);
            this.panel1.Controls.Add(this.rb_ConnectEleve);
            this.panel1.Location = new System.Drawing.Point(470, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 28);
            this.panel1.TabIndex = 7;
            // 
            // rb_ConnectProf
            // 
            this.rb_ConnectProf.AutoSize = true;
            this.rb_ConnectProf.Location = new System.Drawing.Point(120, 3);
            this.rb_ConnectProf.Name = "rb_ConnectProf";
            this.rb_ConnectProf.Size = new System.Drawing.Size(80, 19);
            this.rb_ConnectProf.TabIndex = 6;
            this.rb_ConnectProf.TabStop = true;
            this.rb_ConnectProf.Text = "Profésseur";
            this.rb_ConnectProf.UseVisualStyleBackColor = true;
            // 
            // rb_ConnectEleve
            // 
            this.rb_ConnectEleve.AutoSize = true;
            this.rb_ConnectEleve.Location = new System.Drawing.Point(0, 3);
            this.rb_ConnectEleve.Name = "rb_ConnectEleve";
            this.rb_ConnectEleve.Size = new System.Drawing.Size(52, 19);
            this.rb_ConnectEleve.TabIndex = 5;
            this.rb_ConnectEleve.TabStop = true;
            this.rb_ConnectEleve.Text = "Elève";
            this.rb_ConnectEleve.UseVisualStyleBackColor = true;
            // 
            // btn_Connexion
            // 
            this.btn_Connexion.BackColor = System.Drawing.Color.White;
            this.btn_Connexion.ForeColor = System.Drawing.Color.Black;
            this.btn_Connexion.Location = new System.Drawing.Point(503, 446);
            this.btn_Connexion.Name = "btn_Connexion";
            this.btn_Connexion.Size = new System.Drawing.Size(130, 23);
            this.btn_Connexion.TabIndex = 4;
            this.btn_Connexion.Text = "Connexion";
            this.btn_Connexion.UseVisualStyleBackColor = false;
            this.btn_Connexion.Click += new System.EventHandler(this.Connect);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(181, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de passe :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(197, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Identifiant :";
            // 
            // tb_mdp
            // 
            this.tb_mdp.Location = new System.Drawing.Point(270, 355);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.Size = new System.Drawing.Size(604, 23);
            this.tb_mdp.TabIndex = 1;
            // 
            // tb_identifiant
            // 
            this.tb_identifiant.Location = new System.Drawing.Point(270, 251);
            this.tb_identifiant.Name = "tb_identifiant";
            this.tb_identifiant.Size = new System.Drawing.Size(604, 23);
            this.tb_identifiant.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1171, 722);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Vue notes éleve";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
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
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tc_Main;
        private TabPage tabPage1;
        private Button btn_Connexion;
        private Label label2;
        private Label label1;
        private TextBox tb_mdp;
        private TextBox tb_identifiant;
        private TabPage tabPage2;
        private RadioButton rb_ConnectProf;
        private RadioButton rb_ConnectEleve;
        private Panel panel1;
    }
}