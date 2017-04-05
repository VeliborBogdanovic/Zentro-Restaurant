using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class JelaSastojciItem: RestaurantItem
    {
        public int IdJela { get; set; }
        public string Naziv { get; set; }
        public string Slika { get; set; }
        public double Cena { get; set; }
        public bool? akcija { get; set; }
        public int IdSastojka { get; set; }
        public string NazivSastojka { get; set; }

      
        
    }
}