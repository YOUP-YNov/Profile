using Business;
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
    public class AuthController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        /// Authentifie un utilisateur en recevant un email et un mot de passe
        /// </summary>
        /// <param name="Email">Email de l'utilisateur</param>
        /// <param name="Pass">Mot de passe non crypter de l'utilisateur</param>
        /// <param name="Device">Optionel, permet de definir le device appelant</param>
        /// <returns></returns>
        public Utilisateur Post(string Email, string Pass, string Device = null)
        {
            return Buisiness.GetUtilisateurByEmailPassword(Email, Pass, Device).ToExpo();
        }
    }
}
