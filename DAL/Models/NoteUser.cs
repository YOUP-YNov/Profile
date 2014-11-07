using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class NoteUser
    {
        public int user_note_id { get; set;}
        public int user_comment_id { get; set; }
        public string commentaires { get; set;}
        public int note { get; set;}

        public NoteUser(DataRow row)
        {
            this.user_note_id = Convert.ToInt32(row[@"UtilisateurNote_id"]);
            this.user_comment_id = Convert.ToInt32(row[@"UtilisateurCommente_id"]);
            this.commentaires = row[@"Commentaire"] as string;
            this.note = Convert.ToInt32(row[@"Note"]);
        }

    }
}
