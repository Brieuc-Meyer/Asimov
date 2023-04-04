using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsimovStudentManager
{
    public class Note
    {
        public int note_id;
        public int note_eleve_id;
        public int note_pourcent;
        public int note_prof_id;
        public int note_mat_id;
        public DateTime note_date_evaluation;
        public String note_intitule;
        public String note_description;
        public string note_mat_name;
        public string note_prof_nom;

        public Note(int note_id, int note_eleve_id, int note_pourcent, int note_prof_id, int note_mat_id, DateTime note_date_evaluation, String note_intitule, String note_description, string note_mat_name, string note_prof_nom)
        {
            this.note_id = note_id;
            this.note_eleve_id = note_eleve_id;
            this.note_pourcent = note_pourcent;
            this.note_prof_id = note_prof_id;
            this.note_mat_id = note_mat_id;
            this.note_date_evaluation = note_date_evaluation;
            this.note_intitule = note_intitule;
            this.note_description = note_description;
            this.note_mat_name = note_mat_name;
            this.note_prof_nom = note_prof_nom;
        }
    }
}
