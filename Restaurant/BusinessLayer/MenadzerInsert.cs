using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class MenadzerInsert:Operation
    {

        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Iskustvo { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.MenadzerInsert(this.Ime, this.Prezime, this.Iskustvo);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}