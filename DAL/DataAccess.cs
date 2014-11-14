using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.YoupDSTableAdapters;

namespace DAL
{
    /// <summary>
    /// Classe accedant aux données qui sont stockées en BDD SQL Server
    /// </summary>
    public class DataAccess
    {
        private static readonly Lazy<UtilisateurTA> lazyUtilisateurTA =
                new Lazy<UtilisateurTA>(() => new UtilisateurTA());
        private static UtilisateurTA UtilisateurTA { get { return lazyUtilisateurTA.Value; } }

        private static readonly Lazy<CategorieTA> lazyCategorieTA =
                new Lazy<CategorieTA>(() => new CategorieTA());
        private static CategorieTA CategorieTA { get { return lazyCategorieTA.Value; } }

        private static readonly Lazy<UtilisateurSmallTA> lazyUtilisateurSmallTA =
                new Lazy<UtilisateurSmallTA>(() => new UtilisateurSmallTA());
        private static UtilisateurSmallTA UtilisateurSmallTA { get { return lazyUtilisateurSmallTA.Value; } }

        private static readonly Lazy<TokenTA> lazyTokenTA =
                new Lazy<TokenTA>(() => new TokenTA());
        private static TokenTA TokenTA { get { return lazyTokenTA.Value; } }

        //private static readonly Lazy<AppreciationTA> lazeyAppreciation =
        //        new Lazy<AppreciationTA>(() => new AppreciationTA());
        //private static UT_Appreciation_TA AppreciationTA { get { return lazeyAppreciation.Value; } }
        /// <summary>
        /// Classe accedant aux données qui sont stockées en BDD SQL Server
        /// </summary>
        public DataAccess()
        {
        }

        ///// <summary>
        ///// Returns all row into the UT_Utilisateur Table
        ///// </summary>
        ///// <returns>List<UtilisateurDAL></returns>
        //public List<UtilisateurDAL> GetUtilisateurs()
        //{
        //    var rep = ta.GetUtilisateurs();
        //    if (rep == null && rep.Rows.Count > 0)
        //        return null;
        //    List<UtilisateurDAL> utilisateurs = new List<UtilisateurDAL>();
        //    foreach (DataRow row in rep.Rows)
        //    {
        //        MyDALMapper.getMappingUsers();
        //        utilisateurs.Add(Mapper.Map<DataRow, UtilisateurDAL>(row));
        //    }
        //    return utilisateurs;
        //}

        /// <summary>
        /// Insert a new row into UT_Utilisateur Table
        /// </summary>
        /// <param name="Pseudo">Pseudo Utilisateur</param>
        /// <param name="MotDePasse">Mot de passe Utilisateur (SHA256)</param>
        /// <param name="DateInscription">Date Inscription Utilisateur</param>
        /// <param name="Nom">Nom Utilisateur</param>
        /// <param name="Prenom">Prenom Utilisateur</param>
        /// <param name="Sexe">(bool) Sexe Utilisateur (true = homme, false = Femme)</param>
        /// <param name="AdresseMail">Adresse email Utilisateur</param>
        /// <param name="DateNaissance"> Date de Naissance Utilisateur</param>
        /// <param name="Ville"> Ville Utilisateur</param>
        /// <param name="CodePostal"> Code Postal Utilisateur</param>
        /// <param name="PhotoChemin"> Url vers Photo Utilisateur</param>
        /// <param name="Situation"> situation Utilisateur (string)</param>
        /// <param name="Actif">Actif ou non (bool) false si descativer</param>
        /// <param name="Partenaire">(bool) si il s'agit d'un compte commercial ou non</param>
        /// <param name="Presentation">Resumé, presentation de la personne </param>
        /// <param name="Metier">chaine representant le metier de l'utilisateur</param>
        /// <returns>"ok" if works without error "ko" if error occur</returns>
       
        public UtilisateurDAL AddUtilisateur(UtilisateurDAL Utilisateur)
        {
            try
            {
                string passHashed = Encrypt.hashSHA256(Utilisateur.MotDePasse);
                UtilisateurTA.Insert(Utilisateur.Pseudo,
                                passHashed,
                                Utilisateur.DateInscription,
                                Utilisateur.Nom,
                                Utilisateur.Prenom,
                                Utilisateur.Sexe,
                                Utilisateur.AdresseMail,
                                Utilisateur.DateNaissance,
                                Utilisateur.Ville,
                                Utilisateur.CodePostal,
                                Utilisateur.PhotoChemin,
                                Utilisateur.Situation,
                                Utilisateur.Actif,
                                Utilisateur.Partenaire,
                                Utilisateur.Presentation,
                                Utilisateur.Metier);
                var u = UtilisateurTA.GetUtilisateurByEmailPassword(Utilisateur.AdresseMail, Utilisateur.MotDePasse);
                if (u.Rows.Count > 0)
                    return new UtilisateurDAL(u.Rows[0]);
                else
                    return null;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
            }
            return null;
        }

        /// <summary>
        /// Modifie un utilisateur
        /// </summary>
        /// <param name="Utilisateur">un Utilisateur</param>
        /// <param name="isPassUpdate"></param>
        /// <returns></returns>
        public UtilisateurDAL UpdateUtilisateur(UtilisateurDAL Utilisateur, bool isPassUpdate)
        {
            try
            {
                if (isPassUpdate) { 
                                UtilisateurTA.Update(Utilisateur.Utilisateur_Id,
                                Utilisateur.Pseudo,
                                Utilisateur.MotDePasse,
                                Utilisateur.DateInscription,
                                Utilisateur.Nom,
                                Utilisateur.Prenom,
                                Utilisateur.Sexe,
                                Utilisateur.AdresseMail,
                                Utilisateur.DateNaissance,
                                Utilisateur.Ville,
                                Utilisateur.CodePostal,
                                Utilisateur.PhotoChemin,
                                Utilisateur.Situation,
                                Utilisateur.Actif,
                                Utilisateur.Partenaire,
                                Utilisateur.Presentation,
                                Utilisateur.Metier);
                var u = UtilisateurTA.GetUtilisateurById(Utilisateur.Utilisateur_Id);
                if (u.Rows.Count > 0)
                    return new UtilisateurDAL(u.Rows[0]);
                else
                    return null;
                }
                else
                {
                    string passHashed = Encrypt.hashSHA256(Utilisateur.MotDePasse);
                    UtilisateurTA.Update(Utilisateur.Utilisateur_Id,
                                Utilisateur.Pseudo,
                                passHashed,
                                Utilisateur.DateInscription,
                                Utilisateur.Nom,
                                Utilisateur.Prenom,
                                Utilisateur.Sexe,
                                Utilisateur.AdresseMail,
                                Utilisateur.DateNaissance,
                                Utilisateur.Ville,
                                Utilisateur.CodePostal,
                                Utilisateur.PhotoChemin,
                                Utilisateur.Situation,
                                Utilisateur.Actif,
                                Utilisateur.Partenaire,
                                Utilisateur.Presentation,
                                Utilisateur.Metier);
                    var u = UtilisateurTA.GetUtilisateurById(Utilisateur.Utilisateur_Id);
                    if (u.Rows.Count > 0)
                        return new UtilisateurDAL(u.Rows[0]);
                    else
                        return null;
                }
                
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
            }
            return null;
        }

        /// <summary>
        /// Récupération des 5 premier utilisateurs qui participent le plus
        /// </summary>
        /// <returns>Liste de d5 UtilisateurSmallDAL</returns>
        public List<UtilisateurSmall> GetTopEvent()
        {
            List<UtilisateurSmall> reponse = new List<UtilisateurSmall>();

            var rep = UtilisateurSmallTA.GetTopFiveEvent();

            foreach (DataRow row in rep.Rows)
            {
                reponse.Add(new UtilisateurSmall(row));
            }

            return reponse;
        }

        /// <summary>
        /// Ajout d'un ami par son id
        /// </summary>
        /// <returns>True si OK, False si KO</returns>
        public bool AddFriendByIdUtilisateur(int id_utilisateur, int id_ami)
        {
            try
            {
                UtilisateurTA.AddFriend(id_utilisateur, id_ami);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Retire un ami par son id
        /// </summary>
        /// <returns>True si OK, False si KO</returns>
        public bool RemoveFriendByIdUtilisateur(int id_utilisateur, int id_ami)
        {
            try
            {
                UtilisateurTA.RemoveFriend(id_utilisateur, id_ami);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Récupère les données utilisateurs à partir d'un ID
        /// </summary>
        /// <param name="utilisateur_id">Id d'un utilisateur</param>
        /// <returns>Objet utilisateur</returns>
        public UtilisateurDAL GetUtilisateurById(int utilisateur_id)
        {
            var rep = UtilisateurTA.GetUtilisateurById(utilisateur_id);
            UtilisateurDAL utilisateur = null;
            if (rep.Rows.Count > 0)
            {
                utilisateur = new UtilisateurDAL(rep.Rows[0]);

                var repamis = UtilisateurSmallTA.GetAmisByUtilisateur(utilisateur.Utilisateur_Id);
                foreach (DataRow row in repamis)
                {
                    utilisateur.Amis = utilisateur.Amis ?? new List<UtilisateurSmall>();
                    utilisateur.Amis.Add(new UtilisateurSmall(row));
                }

                var repinteret = CategorieTA.GetCategorieByUtilisateur(utilisateur.Utilisateur_Id);
                foreach (DataRow cat in repinteret)
                {
                    utilisateur.Categories = utilisateur.Categories ?? new List<Categorie>();
                    utilisateur.Categories.Add(new Categorie(cat));
                }
            }
            return utilisateur;
        }

        /// <summary>
        /// Ajoute une categorie à l'utilisateur
        /// </summary>
        /// <param name="id_user">L'id de l'utilisateur</param>
        /// <param name="id_cat">L'id de la categorie</param>
        public void AddCategoryByUser(int id_user, int id_cat)
        {
            UtilisateurTA.AddCategorieByUser(id_user, id_cat);
        }

        /// <summary>
        /// Retourne un utilisateur
        /// </summary>
        /// <param name="token">le token de l'utilisateur</param>
        /// <returns>un Utilisateur</returns>
        public UtilisateurDAL GetUtilisateurByToken(Guid token)
        {
            var rep = UtilisateurTA.GetUtilisateurByToken(token);
            UtilisateurDAL user = null;
            if(rep.Rows.Count > 0)
            {
                user = new UtilisateurDAL(rep.Rows[0]);
                var repAmis = UtilisateurSmallTA.GetAmisByUtilisateur(user.Utilisateur_Id);
                foreach (var row in repAmis)
                {
                    user.Amis = user.Amis ?? new List<UtilisateurSmall>();
                    user.Amis.Add(new UtilisateurSmall(row));
                }

                var repinteret = CategorieTA.GetCategorieByUtilisateur(user.Utilisateur_Id);
                foreach (var row in repinteret)
                {
                    user.Categories = user.Categories ?? new List<Categorie>();
                    user.Categories.Add(new Categorie(row));
                }
            }

            return user;
        }

        /// <summary>
        /// Désactivation d'un utilisateur à partir d'un Id
        /// </summary>
        /// <param name="utilisateur_id">Id d'un utilisateur</param>
        /// <returns>Retourne un booléen qui vérifie le bon déroulement de la procédure</returns>
        public bool DesactivationUtilisateur(int utilisateur_id)
        {
            try
            {
                UtilisateurTA.DesactivationUtilisateur(utilisateur_id);
                return true;
            }
            catch (Exception E)
            {
                Debug.WriteLine(E.Message);
                return false;
            }
        }
        /// <summary>
        /// Méthode d'auth d'un utilisateur
        /// </summary>
        /// <param name="email">Adresse EMail</param>
        /// <param name="passwd">Mot de passe hasher</param>
        /// <returns>Un nouveau UtilisateurDAL</returns>
        public UtilisateurDAL GetUserByEMailPasswd(string email, string passwd)
        {
            var rep = UtilisateurTA.GetUtilisateurByEmailPassword(email, passwd);
          
            if (rep.Rows.Count > 0 )
            {
                var utilisateur = new UtilisateurDAL(rep.Rows[0]);
                var repamis = UtilisateurSmallTA.GetAmisByUtilisateur(utilisateur.Utilisateur_Id);
                foreach (DataRow row in repamis)
                {
                    utilisateur.Amis = utilisateur.Amis ?? new List<UtilisateurSmall>();
                    utilisateur.Amis.Add(new UtilisateurSmall(row));
                }

                var repinteret = CategorieTA.GetCategorieByUtilisateur(utilisateur.Utilisateur_Id);
                foreach (DataRow cat in repinteret)
                {
                    utilisateur.Categories = utilisateur.Categories ?? new List<Categorie>();
                    utilisateur.Categories.Add(new Categorie(cat));
                }
                utilisateur.Token = Guid.NewGuid();
                TokenTA.Insert(utilisateur.Utilisateur_Id, utilisateur.Token, DateTime.Now.AddDays(10));
                return utilisateur;
            }
            return null;
        }

        /// <summary>
        /// Invitation événement d'un utilisateur par un autre utilisateur
        /// </summary>
        /// <param name="event_id"> id de l'event</param>
        /// <param name="invit_id"> id de l'utilisateur invité</param>
        /// <param name="user_id"> id du créateur de l'event</param>
        /// <returns>true si invit OK false si invit KO</returns>
        public bool GetInvitEvent(int event_id, int user_id, int invit_id)
        {
            try{
                UtilisateurSmallTA.GetInvitEvent(event_id, user_id, invit_id);
                return true;
            }
            catch{
                return false;
            }
        }

        /// <summary>
        /// Retourne la liste des 10 dérnier utilisateurs inscrit
        /// </summary>
        /// <returns>Une liste de 10 UtilisateursDal</returns>
        public List<UtilisateurSmall> GetTenProfilUtilisateur()
        {
            List<UtilisateurSmall> lastTenUser = new List<UtilisateurSmall>();

            var rep = UtilisateurSmallTA.GetTopTenUtilisateurs();

            foreach (DataRow utilisateur in rep)
            {
                lastTenUser.Add(new UtilisateurSmall(utilisateur));
            }

            return lastTenUser;

        }
        /// <summary>
        /// Retourne la categorie
        /// </summary>
        /// <param name="id">id categorie</param>
        /// <returns>Une categorie</returns>
        public Categorie GetCategoryById(int id)
        {
            Categorie cat = null;
            var repCat = CategorieTA.GetCategoryById(id);

            if(repCat.Rows.Count > 0)
            {
                cat = new Categorie(repCat.Rows[0]);
            }

            return cat;
        }       

        /// <summary>
        /// Selectionne toute les note d'un utilisateur
        /// </summary>
        /// <param name="user_id">id de l'utilisateur</param>
        /// <returns>Liste de NoteUser</returns>
        public List<NoteUser> GetNoteUser(int user_id)
        {
            //List<NoteUser> listedenote = new List<NoteUser>();

            //var rep = 

            //foreach (DataRow row in rep)
            //{
            //    listedenote.Add(new NoteUser(row));
            //}

            //return listedenote;
            return null;
        }

        /// <summary>
        /// Supprime une categorie d'un utilisateur
        /// </summary>
        /// <param name="cat">la categorie à supprimer</param>
        /// <param name="token">le token de l'utilisateur</param>
        /// <returns>un booleen</returns>
        public bool DeleteCategoryUser(Categorie cat, Guid token)
        {
            bool delete = false;
            UtilisateurDAL user = null;
            var userByToken = UtilisateurTA.GetUtilisateurByToken(token);

            if(userByToken.Rows.Count > 0)
            {
                user = new UtilisateurDAL(userByToken);
            }

            var rep = CategorieTA.DeleteCategoryByUser(user.Utilisateur_Id,cat.Categorie_id);

            if(rep.Rows.Count > 0)
            {
                delete = Convert.ToBoolean(rep.Rows[0]);
            }
            return delete;
        }
       
    }
}
