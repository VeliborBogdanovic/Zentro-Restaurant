using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class PozicijeInsert:Operation
    {
       
        public string Naziv{ get; set; }
       

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.PozicijaInsert(this.Naziv);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}