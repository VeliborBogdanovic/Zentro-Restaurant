using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class BrojLjudiUpdate:Operation
    {
        public int Id { get; set; }
        public int broj { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.BrojLjudiUpdate(this.Id, this.broj);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}