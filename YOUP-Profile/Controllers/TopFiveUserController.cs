﻿using Business;
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
    public class TopFiveUserController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }


        /// <summary>
        /// Recupere les 5 utilisateurs qui participe le plus à des evenements
        /// </summary>
        /// <returns>Une liste de 5 UtilisateurSmall</returns>
        public IEnumerable<UtilisateurSmall> Get()
        {
            return Buisiness.GetFiveMostParticipantUser();
        }
    }
}
