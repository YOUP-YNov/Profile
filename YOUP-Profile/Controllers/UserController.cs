using Business;
using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using YOUP_Profile.Models;
using YOUP_Profile.Models.Adapters;

namespace YOUP_Profile.Controllers
{
    [EnableCors("*", "*", "*")]
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
            var u = Buisiness.GetUtilisateurById(id);

            return (u != null) ? new Utilisateur(u) : null;
        }

        /// <summary>
        /// Met à jour un utilisateur
        /// </summary>
        /// <param name="utilisateur"> attend un objet de type Utilisateur pour etre mit à jour</param>
        /// <returns>l'utilisateur mit à jour</returns>
        public async Task<Utilisateur> Put(Utilisateur utilisateur)
        {
            var u = Buisiness.InsertUtilisateur(new UtilisateurBusiness((dynamic)utilisateur));

            //API ElasticSearch
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://youp-recherche.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage reponse = await client.GetAsync("update/get_profile?id=" + u.Utilisateur_Id + "&firstname=" + u.Nom + "&lastname=" + u.Prenom + "&pseudo=" + u.Pseudo + "&activity=" + u.Actif + "&age=" + u.DateNaissance + "&sex=" + u.Sexe + "&town=" + u.Ville + "");

                    if (!reponse.IsSuccessStatusCode)
                        throw new HttpResponseException(reponse);
                }
            }
            catch (Exception) { }


            return (u != null) ? u.ToExpo() : null;
        }

        /// <summary>
        /// Creation d'un utilisateur
        /// </summary>
        /// <param name="utilisateur">Un utilisateur</param>
        /// <returns>L'utilisateur creer</returns>
        public async Task<Utilisateur> Post(Utilisateur utilisateur)
        {
            var u = Buisiness.InsertUtilisateur(new UtilisateurBusiness((dynamic)utilisateur));

            //API ElasticSearch
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
            catch (Exception) { }


            return (u != null) ? u.ToExpo() : null;
        }

        /// <summary>
        /// Désactivation d'un utilisateur
        /// </summary>
        /// <param name="id_user">L'id d'un utilisateur</param>
        /// <returns>Vrai ou faux</returns>
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            //API ElasticSearch
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://youp-recherche.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage reponse = await client.GetAsync("remove/get_profile?id="+ id);

                    if (!reponse.IsSuccessStatusCode)
                        throw new HttpResponseException(reponse);
                }
            }
            catch (Exception) { }

            return Buisiness.DesactivationUtilisateur(id);
        }

    }
}
