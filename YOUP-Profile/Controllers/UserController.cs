﻿using Business;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using YOUP_Profile.Models;
using YOUP_Profile.Models.Adapters;

namespace YOUP_Profile.Controllers
{
    public class UserController : ApiController
    {

        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }


        /// <summary>
        /// Return les informations pour d'un utilisateur en fonction de son id
        /// </summary>
        /// <param name="id">utilisateur_id </param>
        /// <returns>utilisateur</returns>
        public Utilisateur Get(int id)
        {
            return new Utilisateur(Buisiness.GetUtilisateurById(id));
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        /// <param name="utilisateur"> attend un objet de type Utilisateur pour etre mit à jour</param>
        /// <returns>l'utilisateur mit à jour</returns>
        public Utilisateur Put(Utilisateur utilisateur)
        {
            return Buisiness.InsertUtilisateur(new UtilisateurBusiness((dynamic)utilisateur)).ToExpo();
        }

        /// <summary>
        /// Creation d'un utilisateur
        /// </summary>
        /// <param name="utilisateur">Un utilisateur</param>
        /// <returns>L'utilisateur creer</returns>
        public Utilisateur Post(Utilisateur utilisateur)
        {
            return Buisiness.InsertUtilisateur(new UtilisateurBusiness((dynamic)utilisateur)).ToExpo();
        }

    }
}