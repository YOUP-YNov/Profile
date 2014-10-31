using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Categorie
    {
        public int Categorie_id;
        public string Libelle;

        public Categorie()
        {
                
        }

        public Categorie(DataRow row)
        {
            Categorie_id    = Convert.ToInt32(row["Utilisateur_id"]);
            Libelle = row["Libelle"] as string;
        }
    }
}
