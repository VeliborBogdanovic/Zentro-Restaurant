using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariPozicijaInsert:Operation
    {
        public string Ime { get; set; }
        public string slika { get; set; }
        public string slikaMala { get; set; }
        public int IdPozicija { get; set; }
     

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijaInsert(this.Ime, this.slika, this.slikaMala, this.IdPozicija);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}