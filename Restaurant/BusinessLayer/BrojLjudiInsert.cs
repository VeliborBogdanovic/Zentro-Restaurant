using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class BrojLjudiInsert:Operation
    {
        
        public int broj { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.BrojLjudiInsert(this.broj);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}