using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.YoupDataSetTableAdapters;
using DAL.Models;

namespace DAL
{
    /// <summary>
    /// Classe accedant aux données qui sont stockées en BDD SQL Server
    /// </summary>
    public class DataAccess
    {
        private static readonly Lazy<UT_GetUtilisateursTableAdapter> lazyTa =
                new Lazy<UT_GetUtilisateursTableAdapter>(() => new UT_GetUtilisateursTableAdapter());
        private static UT_GetUtilisateursTableAdapter ta { get { return lazyTa.Value; } }


        /// <summary>
        /// Classe accedant aux données qui sont stockées en BDD SQL Server
        /// </summary>
        public DataAccess()
        {
        }

        /// <summary>
        /// Returns all row into the UT_Utilisateur Table
        /// </summary>
        /// <returns>List<UtilisateurDAL></returns>
        public List<UtilisateurDAL> GetUtilisateurs()
        {
            var rep = ta.GetUtilisateurs();
            if (rep == null && rep.Rows.Count > 0)
                return null;
            List<UtilisateurDAL> utilisateurs = new List<UtilisateurDAL>();
            foreach (DataRow row in rep.Rows)
            {
                utilisateurs.Add(new UtilisateurDAL(row));
            }
            return utilisateurs;
        }

        /// <summary>
        /// Insert a new row into UT_Utilisateur Table
        /// </summary>
        /// <param name="Pseudo">Pseudo Utilisateur</param>
        /// <param name="MotDePasse">Mot de passe Utilisateur (SHA256)</param>
        /// <param name="DateInscription">Date Inscription Utilisateur</param>
        /// <param name="Nom">Nom Utilisateur</param>
        /// <param name="Prenom">Prenom Utilisateur</param>
        /// <param name="Sexe">(bool) Sexe Utilisateur (true = homme, false = Femme)</param>
        /// <param name="AdresseMail">Adresse email Utilisateur</param>
        /// <param name="DateNaissance"> Date de Naissance Utilisateur</param>
        /// <param name="Ville"> Ville Utilisateur</param>
        /// <param name="CodePostal"> Code Postal Utilisateur</param>
        /// <param name="PhotoChemin"> Url vers Photo Utilisateur</param>
        /// <param name="Situation"> situation Utilisateur (string)</param>
        /// <param name="Actif">Actif ou non (bool) false si descativer</param>
        /// <param name="Partenaire">(bool) si il s'agit d'un compte commercial ou non</param>
        /// <param name="Presentation">Resumé, presentation de la personne </param>
        /// <param name="Metier">chaine representant le metier de l'utilisateur</param>
        /// <returns>"ok" if works without error "ko" if error occur</returns>
       
        public string AddUtilisateur(UtilisateurDAL Utilisateur)
        {
            int rep = 0;
            try
            {
                rep = ta.Insert(Utilisateur.Pseudo,
                                Utilisateur.MotDePasse,
                                Utilisateur.DateInscription,
                                Utilisateur.Nom,
                                Utilisateur.Prenom,
                                Utilisateur.Sexe,
                                Utilisateur.AdresseMail,
                                Utilisateur.DateNaissance,
                                Utilisateur.Ville,
                                Utilisateur.CodePostal,
                                Utilisateur.PhotoChemin,
                                Utilisateur.Situation,
                                Utilisateur.Actif,
                                Utilisateur.Partenaire,
                                Utilisateur.Presentation,
                                Utilisateur.Metier);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
            }
            return (rep == 1) ? "ok" : "ko";
        }
        /// <summary>
        /// Update a row of UT_Utilisateur Table
        /// </summary>
        /// <param name="Utilisateur_Id">Utilisateur id (PK)</param>
        /// <param name="Pseudo">Pseudo Utilisateur</param>
        /// <param name="MotDePasse">Mot de passe Utilisateur (SHA256)</param>
        /// <param name="DateInscription">Date Inscription Utilisateur</param>
        /// <param name="Nom">Nom Utilisateur</param>
        /// <param name="Prenom">Prenom Utilisateur</param>
        /// <param name="Sexe">(bool) Sexe Utilisateur (true = homme, false = Femme)</param>
        /// <param name="AdresseMail">Adresse email Utilisateur</param>
        /// <param name="DateNaissance"> Date de Naissance Utilisateur</param>
        /// <param name="Ville"> Ville Utilisateur</param>
        /// <param name="CodePostal"> Code Postal Utilisateur</param>
        /// <param name="PhotoChemin"> Url vers Photo Utilisateur</param>
        /// <param name="Situation"> situation Utilisateur (string)</param>
        /// <param name="Actif">Actif ou non (bool) false si descativer</param>
        /// <param name="Partenaire">(bool) si il s'agit d'un compte commercial ou non</param>
        /// <param name="Presentation">Resumé, presentation de la personne </param>
        /// <param name="Metier">chaine representant le metier de l'utilisateur</param>
        /// <returns>"ok" if works without error "ko" if error occur</returns>
        public string UpdateUtilisateur(UtilisateurDAL Utilisateur)
        {
            int rep = 0;
            try
            {
                rep = ta.Update(Utilisateur.Utilisateur_Id,
                                Utilisateur.Pseudo,
                                Utilisateur.MotDePasse,
                                Utilisateur.DateInscription,
                                Utilisateur.Nom,
                                Utilisateur.Prenom,
                                Utilisateur.Sexe,
                                Utilisateur.AdresseMail,
                                Utilisateur.DateNaissance,
                                Utilisateur.Ville,
                                Utilisateur.CodePostal,
                                Utilisateur.PhotoChemin,
                                Utilisateur.Situation,
                                Utilisateur.Actif,
                                Utilisateur.Partenaire,
                                Utilisateur.Presentation,
                                Utilisateur.Metier);
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
            }
            return (rep == 1) ? "ok" : "ko";
        }

        /// <summary>
        /// Récupération des 5 premier utilisateurs qui participent le plus
        /// </summary>
        /// <returns>Liste de d5 UtilisateurSmallDAL</returns>
        public List<UtilisateurSmallDAL> GetTopEvent()
        {
            List<UtilisateurSmallDAL> reponse = new List<UtilisateurSmallDAL>();

            var rep = ta.GetTopEvent();

            foreach (DataRow row in rep.Rows)
            {
                reponse.Add(new UtilisateurSmallDAL(row));
            }

            return reponse;
        }

        /// <summary>
        /// Récupère les données utilisateurs à partir d'un ID
        /// </summary>
        /// <param name="utilisateur_id">Id d'un utilisateur</param>
        /// <returns>Objet utilisateur</returns>
        public UtilisateurDAL GetUtilisateurById(int utilisateur_id)
        {
            var rep = ta.GetUtilisateurById(utilisateur_id);
            if (rep.Rows.Count > 0)
                return new UtilisateurDAL(rep.Rows[0]);
            return null;
        }

        /// <summary>
        /// Désactivation d'un utilisateur à partir d'un Id
        /// </summary>
        /// <param name="utilisateur_id">Id d'un utilisateur</param>
        /// <returns>Retourne un booléen qui vérifie le bon déroulement de la procédure</returns>
        public bool DesactivationUtilisateur(int utilisateur_id)
        {
            try
            {
                ta.DesactivationUtilisateur(utilisateur_id);
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }
        /// <summary>
        /// Méthode d'auth d'un utilisateur
        /// </summary>
        /// <param name="email">Adresse EMail</param>
        /// <param name="passwd">Mot de passe</param>
        /// <returns>Un nouveau UtilisateurDAL</returns>
        public UtilisateurDAL GetUserByEMailPasswd(string email, string passwd)
        {
            var rep = ta.GetUtilisateurByEmailPasswd(email, passwd);
          
            if (rep.Rows.Count > 0 )
            {
                return new UtilisateurDAL(rep.Rows[0]);
            }
            return null;
        }

       
    }
}
