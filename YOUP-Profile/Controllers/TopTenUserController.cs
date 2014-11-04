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
    public class TopTenUserController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }


        /// <summary>
        /// Recupere les 10 derniers inscrits pour les afficher sur le front
        /// </summary>
        /// <returns>Une liste d'utilisateurSmall</returns>
        public IEnumerable<UtilisateurSmall> Get()
        {
            return null;
        }
    }
}
