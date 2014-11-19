using Business;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace YOUP_Profile.Controllers
{
    [EnableCors("*", "*", "*")]
    public class FriendController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }
        
        /// <summary>
        /// retourne la liste d'ami d'un utilisateur par rapport à son id
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>une liste de UtilisateurSmall</returns>
        public IEnumerable<UtilisateurSmall> Get(int id)
        {
            try
            {
                return Buisiness.GetUtilisateurById(id).Amis;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// Fais une requete d'amis pour un utilisateur
        /// </summary>
        /// <param name="ami_id"> id de l'ami à ajouter </param>
        /// <param name="utilisateur_id"> id de l'utilisateur qui veut ajouter un ami</param>
        /// <returns>true si la demande à bien etait faite</returns>
        public bool Post(int utilisateur_id, int ami_id)
        {
            try
            {
                Buisiness.AddFriend(utilisateur_id, ami_id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int utilisateur_id, int ami_id)
        {
            try
            {
                Buisiness.RemoveFriend(utilisateur_id, ami_id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
