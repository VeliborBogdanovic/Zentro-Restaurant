using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class BrojLjudiSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<BrojLjudiItem> brojLJudi = null;

            if (this.Id == 0)
            {
                brojLJudi = from ljudi in restoran.brojLjudis
                            select new BrojLjudiItem { IdBroj=ljudi.IdBrojLjudi,Broj=ljudi.brojLjudi1 };
            }
            else
            {
                brojLJudi = from ljudi in restoran.brojLjudis
                            where ljudi.IdBrojLjudi==this.Id
                            select new BrojLjudiItem { IdBroj = ljudi.IdBrojLjudi, Broj = ljudi.brojLjudi1 };
            }
            BrojLjudiResult rez = new BrojLjudiResult();
            rez.brojLjudi = brojLJudi.ToList();
            rez.Success = true;
            return rez;

        }
    }
}