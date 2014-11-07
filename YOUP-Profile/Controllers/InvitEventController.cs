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

        public bool GetInvitEvent(int event_id, int user_id, int invit_id)
        {
            try { 
            Buisiness.GetInvitEvent(event_id, user_id, invit_id);
                return true;
            }
            catch{
                return false;

            }
    }
}
