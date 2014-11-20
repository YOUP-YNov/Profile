using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using YOUP_Profile.Models;
using YOUP_Profile.Models.Adapters;

namespace YOUP_Profile.Controllers
{
    [EnableCors("*", "*", "*")]
    public class UserPublicController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
        new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }


        /// <summary>
        /// Return les informations pour d'un utilisateur en fonction de son id
        /// </summary>
        /// <param name="id">utilisateur_id </param>
        /// <returns>utilisateur</returns>
        public UtilisateurPublic Get(int id)
        {
            var u = Buisiness.GetUtilisateurById(id);
            return (u != null) ?new UtilisateurPublic(u.ToExpo()) : null;
        }

    }
}