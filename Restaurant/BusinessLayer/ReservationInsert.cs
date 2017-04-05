using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class ReservationInsert:Operation
    {
        public string Ime { get; set; }
        public string Email { get; set; }
        public int Termin { get; set; }
        public int BrLjudi { get; set; }
        public DateTime Datum { get; set; }
        public string  Poruka { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.ReservationInsert(Ime, Email, Datum, Poruka, BrLjudi, Termin);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;
           
        }
    }
}