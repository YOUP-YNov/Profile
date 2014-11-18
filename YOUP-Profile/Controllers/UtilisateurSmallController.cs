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
    public class UtilisateurSmallController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
        new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        /// Retourne les informations basique d'un utilisateur
        /// </summary>
        /// <param name="id">l'id utilisateur</param>
        /// <returns>L'utilisateur</returns>
        public UtilisateurSmall GetSmallUserById(int id)
        {
            return Buisiness.GetSmallUserById(id);
        }

    }
}
