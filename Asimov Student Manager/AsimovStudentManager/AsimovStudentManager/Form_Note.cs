using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsimovStudentManager
{
    public partial class Form_Note : Form
    {
        public Form_Note(Note note)
        {
            InitializeComponent();
            this.Text = note.note_intitule;
            lb_noteMat.Text = note.note_mat_name;
            lb_noteDate.Text = note.note_date_evaluation.ToString();
            lb_noteProf.Text = note.note_prof_nom;
            lb_notePourcentage.Text = note.note_pourcent.ToString() + "%";
            tb_noteIntitule.Text = note.note_intitule;
            tb_noteDescription.Text = note.note_description;
        }
    }
}
