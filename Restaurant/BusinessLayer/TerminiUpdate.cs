using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class TerminiUpdate:Operation
    {
        public int Id { get; set; }
        public TimeSpan time { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.TerminiUpdate(this.Id, this.time);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}