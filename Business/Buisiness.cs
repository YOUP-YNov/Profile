using Business.Models;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Buisiness
    {
        private static readonly Lazy<DataAccess> lazyDataAccess =
                new Lazy<DataAccess>(() => new DataAccess());
        private static DataAccess DataAccess { get { return lazyDataAccess.Value; } }


        /// <summary>
        /// Recupere un utilisateur en fonction de son id
        /// </summary>
        /// <param name="id">utilisateur_id</param>
        /// <returns>Utilisateur</returns>
        public UtilisateurBusiness GetUtilisateurById(int id)
        {
            return DataAccess.GetUtilisateurById(id).ToBuisiness();
        }

        /// <summary>
        /// Authentifie un utilisateur avec son email et son mot de passe
        /// </summary>
        /// <param name="email">Adresse email</param>
        /// <param name="password">mot de passe en clair</param>
        /// <param name="device">Optionel, le type de device</param>
        /// <returns></returns>
        public UtilisateurBusiness GetUtilisateurByEmailPassword(string email, string password, string device = null)
        {
            return DataAccess.GetUserByEMailPasswd(email, Encrypt.hashSHA256(password)).ToBuisiness();
        }

        /// <summary>
        /// Creation d'un nouveau utilisateur
        /// </summary>
        /// <param name="utilisateur">Un utilisateur</param>
        /// <returns>L'utilisateur creer, avec son id mit à jour</returns>
        public UtilisateurBusiness InsertUtilisateur(UtilisateurBusiness utilisateur)
        {
            return DataAccess.AddUtilisateur(new UtilisateurDAL((dynamic)utilisateur)).ToBuisiness();
        }

        /// <summary>
        /// Désactivation d'un utilisateur
        /// </summary>
        /// <param name="utilisateur_id">l'identifiant de l'utilisateur</param>
        /// <returns>Un booléen</returns>
        public bool DesactivationUtilisateur(int utilisateur_id)
        {
            return DataAccess.DesactivationUtilisateur(utilisateur_id);
        }

        /// <summary>
        /// Mise à jour des informations d'un utilisateur
        /// </summary>
        /// <param name="Utilisateur">Un utilisateur</param>
        /// <returns>Un utilisateur mis à jour</returns>
        public UtilisateurBusiness UpdateUtilisateur(UtilisateurBusiness Utilisateur)
        {
            return DataAccess.UpdateUtilisateur(new UtilisateurDAL((dynamic)Utilisateur)).ToBuisiness();
        }

        public List<UtilisateurSmall> GetTenProfilUtilisateur()
        {
            return DataAccess.GetTenProfilUtilisateur();   
        }

        /// <summary>
        /// Fonction qui récupére la liste des utilisteurs participant le plus
        /// </summary>
        /// <returns>Une Liste de 5 UtilisateurSmall (données réduites)</returns>
        public List<UtilisateurSmall> GetFiveMostParticipantUser()
        {
            return DataAccess.GetTopEvent();
        }
    }
}
