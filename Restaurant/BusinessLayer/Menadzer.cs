using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class MenadzerItem
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Iskustvo { get; set; }
    }
    public class MenadzerInsert : Operation
    {

        public MenadzerItem menadzer = new MenadzerItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.MenadzerInsert(this.menadzer.Ime, this.menadzer.Prezime, this.menadzer.Iskustvo);
            return new OperationResult { Success = true };
        }
    }
    public class MenadzerDelete : Operation
    {
        public MenadzerItem menadzer = new MenadzerItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.MenadzerDelete(this.menadzer.Id);
            return new OperationResult { Success = true };        }
    }
    public class MenadzerUpdate : Operation
    {
        public MenadzerItem menadzer = new MenadzerItem();
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.MenadzerUpdate(this.menadzer.Id, this.menadzer.Ime, this.menadzer.Prezime, this.menadzer.Iskustvo);
            return new OperationResult { Success = true };
        }
    }
    public class MenadzerSelect : Operation
    {
        public MenadzerItem menadzer = new MenadzerItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<MenadzerItem> menadzeri = null;

            if (this.menadzer.Id == 0)
            {
                menadzeri = from menadzer in restoran.Menadzeris
                            select new MenadzerItem { Id = menadzer.Id, Ime = menadzer.Ime, Prezime = menadzer.Prezime, Iskustvo = menadzer.Iskustvo };
            }
            else
            {
                menadzeri = from menadzer in restoran.Menadzeris
                            where menadzer.Id == this.menadzer.Id
                            select new MenadzerItem { Id = menadzer.Id, Ime = menadzer.Ime, Prezime = menadzer.Prezime, Iskustvo = menadzer.Iskustvo };
            }
            return new MenadzerResult { Success = true, menadzeri = menadzeri.ToList() };
           
        }
    }
    public class MenadzerResult : OperationResult
    {
        public List<MenadzerItem> menadzeri { get; set; }
    }

}