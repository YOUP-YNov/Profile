using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Profile.Models
{
    public class UtilisateurPublic
    {
        public int Utilisateur_Id { get; set; }
        public string Pseudo { get; set; }
        public Nullable<DateTime> DateInscription { get; set; }
        public string Prenom { get; set; }
        public Nullable<bool> Sexe { get; set; }
        public string Ville { get; set; }
        public string PhotoChemin { get; set; }
        public string Presentation { get; set; }
        public List<UtilisateurSmall> Amis { get; set; }

        public UtilisateurPublic(){}

        public UtilisateurPublic(Utilisateur utilisateur)
        {
            Utilisateur_Id = utilisateur.Utilisateur_Id;
            Pseudo = utilisateur.Pseudo;
            DateInscription = utilisateur.DateInscription;
            Prenom = utilisateur.Prenom;
            Sexe = utilisateur.Sexe;
            Ville = utilisateur.Ville;
            PhotoChemin = utilisateur.PhotoChemin;
            Presentation = utilisateur.Presentation;
            Amis = utilisateur.Amis;
        }
    }
}