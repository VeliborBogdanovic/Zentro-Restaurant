using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class MenadzerSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<MenadzerItem> menadzeri = null;

            if (this.Id == 0)
            {
                menadzeri = from menadzer in restoran.Menadzeris
                            select new MenadzerItem {  Id=menadzer.Id, Ime=menadzer.Ime, Prezime=menadzer.Prezime,Iskustvo=menadzer.Iskustvo };
            }
            else
            {
                menadzeri = from menadzer in restoran.Menadzeris
                            where menadzer.Id==this.id
                            select new MenadzerItem { Id = menadzer.Id, Ime = menadzer.Ime, Prezime = menadzer.Prezime, Iskustvo = menadzer.Iskustvo };
            }
            MenadzerResult rez = new MenadzerResult();
            rez.menadzeri = menadzeri.ToList();
            rez.Success = true;
            return rez;

        }
    }
}