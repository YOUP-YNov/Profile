using Business;
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
    public class CategorieController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        /// Recupere une categorie en fonction de son id
        /// </summary>
        /// <param name="id">id de la categorie</param>
        /// <returns>Categorie</returns>
        public  Categorie Get(int id)
        {
            return Buisiness.GetCategoryById(id);
        }
        /// <summary>
        /// Ajoute une categorie à un utilisateur
        /// </summary>
        /// <param name="categorie">L'objet Categorie à ajouter</param>
        /// <param name="token">le token de connexion de l'utilisateur</param>
        /// <returns>les catégories de l'utilisateur</returns>
        public List<Categorie> Post(Categorie categorie, Guid token)
        {
            var rep = Buisiness.GetUtilisateurByToken(token);
            Buisiness.AddCategorieByUser(rep.Utilisateur_Id, categorie.Categorie_id);

            return rep.Categories;
        }
        /// <summary>
        /// Supprime de la liste des categorie suivi par l'utilisateur la categorie passer en parametre
        /// </summary>
        /// <param name="categorie">la categorie à supprimer</param>
        /// <param name="token">le token de connexion de l'utilisateur</param>
        /// <returns>true si tout cest bien passer, false si il y a eu une erreur</returns>
        public bool Delete(int categorie_id, Guid token)
        {
           return Buisiness.DeleteCategoryByUser(categorie_id, token);
        }
    }
}
