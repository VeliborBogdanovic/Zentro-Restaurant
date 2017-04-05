using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class KuvariPozicijaUpdate:Operation
    {
        public string ime { get; set; }
        public int id { get; set; }
        public string slika { get; set; }
        public string slikaMala { get; set; }
        public int idPozicije { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.KuvariPozicijeUpdate(this.id, this.ime,this.slika,this.slikaMala,this.idPozicije);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}