using Business.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Buisiness
    {
        private static readonly Lazy<DataAccess> lazyDataAccess =
                new Lazy<DataAccess>(() => new DataAccess());
        private static DataAccess DataAccess { get { return lazyDataAccess.Value; } }

        public List<UtilisateurBusiness> GetUtilisateurs()
        {
            return DataAccess.GetUtilisateurs().toBuisiness();
        }

    }
}
