using Business.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Profile.Models
{
    public class Utilisateur
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
        public string Token { get; set; }
        public List<UtilisateurSmall> Amis { get; set; }
        public List<Categorie> Categories { get; set; }

        public Utilisateur()
        {

        }

        public Utilisateur(UtilisateurBusiness utilisateur)
        {
            Utilisateur_Id = utilisateur.Utilisateur_Id;
            Pseudo = utilisateur.Pseudo;
            MotDePasse = utilisateur.MotDePasse;
            DateInscription = utilisateur.DateInscription;
            Nom = utilisateur.Nom;
            Prenom = utilisateur.Prenom;
            Sexe = utilisateur.Sexe;
            AdresseMail = utilisateur.AdresseMail;
            DateNaissance = utilisateur.DateNaissance;
            Ville = utilisateur.Ville;
            CodePostal = utilisateur.CodePostal;
            PhotoChemin = utilisateur.PhotoChemin;
            Situation = utilisateur.Situation;
            Actif = utilisateur.Actif;
            Partenaire = utilisateur.Partenaire;
            Presentation = utilisateur.Presentation;
            Metier = utilisateur.Metier;
            Token = utilisateur.Token;
            Amis = utilisateur.Amis;
            Categories = utilisateur.Categories;
        }
    }
}