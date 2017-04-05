using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class SastojciInsert:Operation
    {
        public string naziv { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.SastojciInsert(this.naziv);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}