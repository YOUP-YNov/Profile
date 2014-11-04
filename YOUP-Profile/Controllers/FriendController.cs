using Business;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YOUP_Profile.Controllers
{
    public class FriendController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }
        
        /// <summary>
        /// Recupere un UtilisateurSmall par son id
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>un UtilisateurSmall</returns>
        public UtilisateurSmall Get(int id)
        {
            return null;
        }

        /// <summary>
        /// Fais une requete d'amis pour un utilisateur
        /// </summary>
        /// <param name="utilisateur">Utilisateur que l'on veut demander en ami</param>
        /// <param name="token">Le token de connexion</param>
        /// <returns>true si la demande à bien etait faite</returns>
        public bool Post(UtilisateurSmall utilisateur, Guid token)
        {
            return false;
        }

        /// <summary>
        /// Accepte une requete d'amis
        /// </summary>
        /// <param name="utilisateur">L'utilisateur que l'on veut accepter</param>
        /// <param name="token">Votre token de connexion</param>
        /// <returns>UtilisateurSmall</returns>
        public UtilisateurSmall Put(UtilisateurSmall utilisateur, Guid token)
        {
            return null;
        }
    }
}
