using AutoMapper;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public static class Adpaters
    {
        public static List<UtilisateurBusiness> toBuisiness(this List<UtilisateurDAL> DALUsers)
        {
            Mapper.CreateMap<UtilisateurDAL, UtilisateurBusiness>(); // défini le mapping
            // fait la conversion
            var BuisinessUsers = new List<UtilisateurBusiness>();
            foreach (var u in DALUsers)
            {
                BuisinessUsers.Add(Mapper.Map<UtilisateurDAL, UtilisateurBusiness>(u));
            }
            return BuisinessUsers;
        }
    }
}
