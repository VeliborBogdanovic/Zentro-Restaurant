using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaSastojciDelete:Operation
    {
        public int id { get; set; }
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.JelaDelete(this.id);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;
        }
    }
}