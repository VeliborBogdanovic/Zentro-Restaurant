using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaUpdate : Operation
    {
        public int Id_jela { get; set; }
        public string naziv{ get; set; }
        public string slika { get; set; }
        public double cena { get; set; }
        public bool akcija { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.JelaUpdate(Id_jela, naziv, slika, cena, akcija);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}