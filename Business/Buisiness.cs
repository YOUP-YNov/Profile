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
            var u = DataAccess.GetUtilisateurById(id);
            return ( u != null) ? u.ToBuisiness() : null;
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
            var u = DataAccess.GetUserByEMailPasswd(email, Encrypt.hashSHA256(password));
            return (u != null) ? u.ToBuisiness() : null;
        }

        /// <summary>
        /// Retourne les informations basique d'un utilisateur
        /// </summary>
        /// <param name="id">l'id utilisateur</param>
        /// <returns>L'utilisateur</returns>
        public UtilisateurSmall GetSmallUserById(int id)
        {
            return DataAccess.GetSmallUserById(id);
        }

        /// <summary>
        /// Creation d'un nouveau utilisateur
        /// </summary>
        /// <param name="utilisateur">Un utilisateur</param>
        /// <returns>L'utilisateur creer, avec son id mit à jour</returns>
        public UtilisateurBusiness InsertUtilisateur(UtilisateurBusiness utilisateur)
        {
            var u = DataAccess.AddUtilisateur(new UtilisateurDAL((dynamic)utilisateur));
            return (u != null) ? u.ToBuisiness() : null;
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
        /// Ajout d'un ami
        /// </summary>
        /// <param name="id_utilisateur">l'identifiant de l'utilisateur</param>
        /// <param name="id_ami">l'identifiant de l'utilisateur ami</param>
        /// <returns>Un booléen</returns>
        public bool AddFriend(int id_utilisateur, int id_ami)
        {
            try
            {
                DataAccess.AddFriendByIdUtilisateur(id_utilisateur, id_ami);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Suppression d'un ami
        /// </summary>
        /// <param name="id_utilisateur">l'identifiant de l'utilisateur</param>
        /// <param name="id_ami">l'identifiant de l'utilisateur ami</param>
        /// <returns>Un booléen</returns>
        public bool RemoveFriend(int id_utilisateur, int id_ami)
        {
            try
            {
                DataAccess.RemoveFriendByIdUtilisateur(id_utilisateur, id_ami);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Invitation d'un utilisateur à un evenement par un utrilisateur
        /// </summary>
        /// <param name="event_id"> id de l'evenement</param>
        /// <param name="invit_id"> id de l'utilisateur invité</param>
        /// <param name="user_id"> id de l'utilisateur invitant</param>
        /// <returns>Un booléen</returns>
        public bool GetInvitEvent(int event_id, int user_id,int invit_id)
        {
            try
            {
                DataAccess.GetInvitEvent(event_id, user_id, invit_id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Mise à jour des informations d'un utilisateur
        /// </summary>
        /// <param name="Utilisateur">Un utilisateur</param>
        /// <returns>Un utilisateur mis à jour</returns>
        public UtilisateurBusiness UpdateUtilisateur(UtilisateurBusiness Utilisateur)
        {
            UtilisateurBusiness existUser = GetUtilisateurByToken(Utilisateur.Token);
            UtilisateurBusiness userUpdate = null;

            if(existUser != null)
            {
                var uInBase = DataAccess.GetUtilisateurById(Utilisateur.Utilisateur_Id);

                bool updatePass = Utilisateur.MotDePasse == uInBase.MotDePasse;
                var u = DataAccess.UpdateUtilisateur(new UtilisateurDAL((dynamic)Utilisateur), updatePass);
                userUpdate = (u != null) ? u.ToBuisiness() : null;
            }

            return userUpdate;
        }

        /// <summary>
        /// Retourne la liste des 10 derniers inscrit
        /// </summary>
        /// <returns>une liste d'utilisateur</returns>
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
            return DataAccess.GetTopFiveEvent();
        }
        /// <summary>
        /// Fonction qui récupère un utilisateur en fonction de son token
        /// </summary>
        /// <param name="token">le token de l'utilisateur</param>
        /// <returns>Un utilisateur</returns>
        public UtilisateurBusiness GetUtilisateurByToken(Guid token)
        {
            return DataAccess.GetUtilisateurByToken(token).ToBuisiness();
        }

        /// <summary>
        /// Fonction qui ajoute une categorie à l'utilisateur
        /// </summary>
        /// <param name="user_id">l'identifiante de l'utilisateur</param>
        /// <param name="cat_id">La categorie à ajouter à l'utilisteur</param>
        public void AddCategorieByUser(int user_id,int cat_id)
        {
            DataAccess.AddCategoryByUser(user_id, cat_id);
        }

        /// <summary>
        /// Retourne une categorie en fonction de son ID
        /// </summary>
        /// <param name="id">id de la categorie</param>
        /// <returns>Une categorie</returns>
        public Categorie GetCategoryById(int id)
        {
            return DataAccess.GetCategoryById(id);
        }

        /// <summary>
        /// Supprime une categorie de l'utilisateur
        /// </summary>
        /// <param name="cat">Categorie</param>
        /// <param name="token">Token de l'utilisateur</param>
        /// <returns>un booleen</returns>
        public bool DeleteCategoryByUser(int cat_id, Guid token)
        {
            return DataAccess.DeleteCategoryUser(cat_id, token);
        }

        /// <summary>
        /// Fonction qui récupére la liste des notes d'un utilisateur
        /// </summary>
        /// <param name="user_id">ID de l'utilisateur</param>
        /// <returns>Liste de NoteUser</returns>
        public List<NoteUser> GetNoteUser(int user_id) 
        {
            return DataAccess.GetNoteUser(user_id);
        }
    }
}
