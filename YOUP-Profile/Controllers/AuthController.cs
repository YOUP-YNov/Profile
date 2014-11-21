using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using YOUP_Profile.Models;
using YOUP_Profile.Models.Adapters;
namespace YOUP_Profile.Controllers
{
    [EnableCors("*","*","*")]
    public class AuthController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        /// Retourne l'utilisateur en fonction de son Token
        /// </summary>
        /// <param name="id"> Token de connexion</param>
        /// <returns>Utilisateur </returns>
        public async Task<Utilisateur> Get(Guid id)
        {
     
            var u = Buisiness.GetUtilisateurByToken(id);
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://youp-recherche.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage reponse = await client.GetAsync("add/get_profile?id=" + u.Utilisateur_Id + "&firstname=" + u.Nom + "&lastname=" + u.Prenom + "&pseudo=" + u.Pseudo + "&activity=" + u.Actif + "&age=" + u.DateNaissance + "&sex=" + u.Sexe + "&town=" + u.Ville + "");

                    if (!reponse.IsSuccessStatusCode)
                        throw new HttpResponseException(reponse);
                }
            }
            catch (Exception)
            {
                
    
            }
            //API ElasticSearch
           

            return (u != null) ? u.ToExpo() : null;


        }

        /// <summary>
        /// Authentifie un utilisateur en recevant un email et un mot de passe
        /// </summary>
        /// <param name="Email">Email de l'utilisateur</param>
        /// <param name="Pass">Mot de passe non crypter de l'utilisateur</param>
        /// <param name="Device">Optionel, permet de definir le device appelant</param>
        /// <returns></returns>
        public Utilisateur Post(string Email, string Pass, string Device = null)
        {
            var u = Buisiness.GetUtilisateurByEmailPassword(Email, Pass, Device);
            return (u != null)? u.ToExpo() : null;
        }
        
        /// <summary>
        /// Deconnexion volontaire de l'utilisateur
        /// Suppression de son token
        /// </summary>
        /// <param name="token">Token de connexion de l'utilisateur</param>
        /// <returns>true si il n'y a pas eu de probleme, false si une erreur</returns>
        public bool Delete(Guid token)
        {
            return true;
        }
    }
}
