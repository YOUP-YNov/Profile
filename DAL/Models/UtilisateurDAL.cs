using DAL.Models;
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
        public List<UtilisateurSmallDAL> Amis { get; set; }
        public List<Categorie> Categories { get; set; }

        public UtilisateurDAL()
        {

        }

        public UtilisateurDAL(DataRow row)
        {
            Amis = new List<UtilisateurSmallDAL>();
            Categories = new List<Categorie>();



            try
            {
                Utilisateur_Id = Convert.ToInt32(row["Utilisateur_Id"]);
                Pseudo = row["Pseudo"] as string;
                MotDePasse = row["MotDePasse"] as string;
                DateInscription = row["DateInscription"] as Nullable<DateTime>;
                Nom = row["Nom"] as string;
                Prenom = row["Prenom"] as string;
                Sexe = row["Sexe"] as Nullable<bool>;
                AdresseMail = row["AdresseMail"] as string;
                DateNaissance = row["DateNaissance"] as Nullable<DateTime>;
                Ville = row["Ville"] as string;
                CodePostal = row["CodePostal"] as string;
                PhotoChemin = row["PhotoChemin"] as string;
                Situation = row["Situation"] as string;
                Actif = row["Actif"] as Nullable<bool>;
                Partenaire = row["Partenaire"] as Nullable<bool>;
                Presentation = row["Presentation"] as string;
                Metier = row["Metier"] as string;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                throw;
            }
        }
    }
}
