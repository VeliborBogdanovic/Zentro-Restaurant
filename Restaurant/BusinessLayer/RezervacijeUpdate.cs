using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class RezervacijeUpdate:Operation
    {

        public int IdRez { get; set; }
        public string Ime { get; set; }
        public string Mail { get; set; }
        public DateTime Datum { get; set; }
        public string Poruka { get; set; }
        public int idBrojLJudi { get; set; }
        public int IdTerm { get; set; }
       

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.ReservationUpdate(this.IdRez, this.Ime, this.Mail, this.Datum, this.Poruka, this.idBrojLJudi, this.IdTerm);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}