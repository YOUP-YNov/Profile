using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YOUP_Profile.Models.Adapters
{
    public static class Adapters
    {
        public static Utilisateur ToExpo(this UtilisateurBusiness u)
        {
            return new Utilisateur(u);
        }

        public static UtilisateurBusiness ToBusiness(this Utilisateur u)
        {
            return new UtilisateurBusiness()
            {
                Utilisateur_Id = u.Utilisateur_Id,
                Pseudo = u.Pseudo,
                MotDePasse = u.MotDePasse,
                DateInscription = u.DateInscription,
                Nom = u.Nom,
                Prenom = u.Prenom,
                Sexe = u.Sexe,
                AdresseMail = u.AdresseMail,
                DateNaissance = u.DateNaissance,
                Ville = u.Ville,
                CodePostal = u.CodePostal,
                PhotoChemin = u.PhotoChemin,
                Situation = u.Situation,
                Actif = u.Actif,
                Partenaire = u.Partenaire,
                Presentation = u.Presentation,
                Metier = u.Metier,
                Amis = u.Amis,
                Categories = u.Categories
            };
        }
    }
}