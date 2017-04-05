using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class RezervacijaTerminItem:RestaurantItem
    {
        public RezervacijeItem rezervacija { get; set; }
        public TerminItem termin { get; set; }

        public RezervacijaTerminItem(int id,string i,string e,int br,DateTime datum,int idT,TimeSpan vreme)
        {
            this.rezervacija.IdRez = id;
            this.rezervacija.Ime = i;
            this.rezervacija.mail = e;
            this.rezervacija.BrojLJudi = br;
            this.rezervacija.datum = datum;
            this.rezervacija.IdTerm = idT;
            this.termin.vreme = vreme;
        }
    }
}