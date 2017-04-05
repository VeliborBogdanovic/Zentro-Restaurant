using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaInsert:Operation
    {
        public int IdJela { get; set; }
        public string NazivJela { get; set; }
        public string Slika { get; set; }
        public double Cena { get; set; }
        public bool? Akcija { get; set; }
        //System.Data.Objects.ObjectParameter idJelaParametar = new System.Data.Objects.ObjectParameter("idJela", System.Type.GetType("System.Int32"));
        public override OperationResult execute(RestaurantEntities entiteti)
        {
             entiteti.JelaInsert( this.NazivJela, this.Slika, this.Cena, this.Akcija);
            OperationResult rez = new OperationResult();
            rez.Success = true;
            return rez;

        }
    }
}