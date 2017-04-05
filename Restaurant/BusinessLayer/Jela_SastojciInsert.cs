using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class Jela_SastojciInsert:Operation
    {
        public int iDjela { get; set; }
        public int idSastojka { get; set; }
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.Jela_SastojciInsert(this.iDjela, this.idSastojka);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}