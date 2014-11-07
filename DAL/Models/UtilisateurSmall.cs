using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UtilisateurSmall
    {

        public int Utilisateur_Id { get; set; }
        public string Pseudo { get; set; }
        public string PhotoChemin { get; set; }

        public UtilisateurSmall()
        {
                
        }

        public UtilisateurSmall(DataRow row)
        {
            Utilisateur_Id = Convert.ToInt32(row["Utilisateur_Id"]);
            Pseudo = row["Pseudo"] as string;
            PhotoChemin = row["PhotoChemin"] as string;
        }

        public bool GetInvitEvent(int event_id, int user_id, int invit_id)
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
