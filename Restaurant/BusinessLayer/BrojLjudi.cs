using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class BrojLjudiItem
    {
        public int IdBroj { get; set; }
        public int? Broj { get; set; }
    }
    public class BrojLjudiDelete : Operation
    {
        public BrojLjudiItem brojLjudi = new BrojLjudiItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.BrojLjudiDelete(this.brojLjudi.IdBroj);
            return new OperationResult { Success = true };
           
        }
    }
    public class BrojLjudiInsert : Operation
    {
        public BrojLjudiItem brojLjudi = new BrojLjudiItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.BrojLjudiInsert(this.brojLjudi.Broj);
            return new OperationResult { Success = true };

        }
    }
    public class BrojLjudiResult : OperationResult
    {
        public List<BrojLjudiItem> brojLjudi { get; set; }
    }
    public class BrojLjudiSelect : Operation
    {
        public BrojLjudiItem brojLjudi = new BrojLjudiItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<BrojLjudiItem> brojLJudi = null;

            if (this.brojLjudi.IdBroj == 0)
            {
                brojLJudi = from ljudi in restoran.brojLjudis
                            select new BrojLjudiItem { IdBroj = ljudi.IdBrojLjudi, Broj = ljudi.brojLjudi1 };
            }
            else
            {
                brojLJudi = from ljudi in restoran.brojLjudis
                            where ljudi.IdBrojLjudi == this.brojLjudi.IdBroj
                            select new BrojLjudiItem { IdBroj = ljudi.IdBrojLjudi, Broj = ljudi.brojLjudi1 };
            }
            return new BrojLjudiResult { brojLjudi = brojLJudi.ToList(), Success = true };
           

        }
    }
    public class BrojLjudiUpdate : Operation
    {
        public BrojLjudiItem brojLjudi = new BrojLjudiItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.BrojLjudiUpdate(this.brojLjudi.IdBroj, this.brojLjudi.Broj);
            return new OperationResult { Success = true };

        }
    }
}