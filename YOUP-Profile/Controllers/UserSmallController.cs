﻿using Business;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace YOUP_Profile.Controllers
{
    public class UserSmallController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }


        /// <summary>
        /// Recupere un aperçu de l'utilisateur ( id, pseudo, photo )
        /// </summary>
        /// <returns>utilisateurSmall</returns>
        public UtilisateurSmall Get(int id)
        {
            return Buisiness.GetSmallUserById(id);
        }
    }
}
