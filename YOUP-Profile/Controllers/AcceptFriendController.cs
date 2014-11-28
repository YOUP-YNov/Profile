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
    public class AcceptFriendController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        ///  Creer une demande d'ami 
        /// </summary>
        /// <param name="utilisateur_id">utilisateur qui fait la demande</param>
        /// <param name="friend_id">l'ami que l'on veut demander en ami</param>
        /// <returns>true si succée, false si echec</returns>
        [HttpPost]
        public bool Post(int utilisateur_id,int friend_id)
        {
            return Buisiness.AcceptFriendRequest(utilisateur_id, friend_id);
        }

        /// <summary>
        /// Recupere les requetes d'amitier en attente
        /// </summary>
        /// <param name="id">id de l'utilisateur</param>
        /// <returns>liste de small user</returns>
        public IEnumerable<UtilisateurSmall> Get(int id)
        {
            return Buisiness.GetFriendRequest(id);
        }
    }
}
