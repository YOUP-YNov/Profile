using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UtilisateurDAL
    {
        public int Utilisateur_Id { get; set; }
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }
        public Nullable<DateTime> DateInscription { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Nullable<bool> Sexe { get; set; }
        public string AdresseMail { get; set; }
        public Nullable<DateTime> DateNaissance { get; set; }
        public string Ville { get; set; }
        public string CodePostal { get; set; }
        public string PhotoChemin { get; set; }
        public string Situation { get; set; }
        public Nullable<bool> Actif { get; set; }
        public Nullable<bool> Partenaire { get; set; }
        public string Presentation { get; set; }
        public string Metier { get; set; }

        public UtilisateurDAL()
        {

        }

        public UtilisateurDAL(DataRow row)
        {
            try
            {
                Utilisateur_Id = Convert.ToInt32(row["Utilisateur_Id"]);
                Pseudo = row["Utilisateur_Id"] as string;
                MotDePasse = row["Utilisateur_Id"] as string;
                DateInscription = row["Utilisateur_Id"] as Nullable<DateTime>;
                Nom = row["Utilisateur_Id"] as string;
                Prenom = row["Utilisateur_Id"] as string;
                Sexe = row["Utilisateur_Id"] as Nullable<bool>;
                AdresseMail = row["Utilisateur_Id"] as string;
                DateNaissance = row["Utilisateur_Id"] as Nullable<DateTime>;
                Ville = row["Utilisateur_Id"] as string;
                CodePostal = row["Utilisateur_Id"] as string;
                PhotoChemin = row["Utilisateur_Id"] as string;
                Situation = row["Utilisateur_Id"] as string;
                Actif = row["Utilisateur_Id"] as Nullable<bool>;
                Partenaire = row["Utilisateur_Id"] as Nullable<bool>;
                Presentation = row["Utilisateur_Id"] as string;
                Metier = row["Utilisateur_Id"] as string;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }
    }
}
