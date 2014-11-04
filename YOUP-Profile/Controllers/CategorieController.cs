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
        public  Categorie GetCategorie(int id)
        {
            return null;
        }
        /// <summary>
        /// Ajoute une categorie à un utilisateur
        /// </summary>
        /// <param name="categorie">L'objet Categorie à ajouter</param>
        /// <param name="token">le token de connexion de l'utilisateur</param>
        /// <returns>la Categorie qui a été ajouté</returns>
        public Categorie Post(Categorie categorie, Guid token)
        {
            return null;
        }
        /// <summary>
        /// Supprime de la liste des categorie suivi par l'utilisateur la categorie passer en parametre
        /// </summary>
        /// <param name="categorie">la categorie à supprimer</param>
        /// <param name="token">le token de connexion de l'utilisateur</param>
        /// <returns>true si tout cest bien passer, false si il y a eu une erreur</returns>
        public bool Delete(Categorie categorie, Guid token)
        {
            return true;
        }
    }
}
