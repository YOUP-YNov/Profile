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
        public static IEnumerable<UtilisateurBusiness> ToBuisiness(this List<UtilisateurDAL> DALUsers)
        {
            foreach (var u in DALUsers)
            {
                yield return new UtilisateurBusiness(u);
            }
        }

        public static UtilisateurBusiness ToBuisiness(this UtilisateurDAL DALUsers)
        {
            return new UtilisateurBusiness(DALUsers);
        }
    }
}
