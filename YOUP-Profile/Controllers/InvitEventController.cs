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
    public class InvitEventController : ApiController
    {
        private static readonly Lazy<Buisiness> lazyBuisiness =
                new Lazy<Buisiness>(() => new Buisiness());
        private static Buisiness Buisiness { get { return lazyBuisiness.Value; } }

        /// <summary>
        /// Envoie une invitation à un événement d'un utilisateur à un autre
        /// </summary>
        /// <param name="event_id"> Id de l'évènement</param>
        /// <param name="invit_id"> Id de l'utilisateur invité</param>
        /// <param name="user_id"> Id du créateur de l'event</param>
        /// <returns>true si l'invit OK False si l'invit KO</returns>
        public bool GetInvitEvent(int event_id, int user_id, int invit_id)
        {
            try
            {
                Buisiness.GetInvitEvent(event_id, user_id, invit_id);
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
