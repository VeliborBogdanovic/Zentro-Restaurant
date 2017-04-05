using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public  class SastojciItem: RestoranItem
    {
        public int IdSastojka { get; set; }
        public string NazivSastojka { get; set; }
    }
    public class SastojciDelete : Operation
    {
        public SastojciItem sastojak = new SastojciItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.SastojciDelete(this.sastojak.IdSastojka);
            return new OperationResult { Success = true };
        }
    }
    public class SastojciInsert : Operation
    {
        public SastojciItem sastojak = new SastojciItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.SastojciInsert(this.sastojak.NazivSastojka);
            return new OperationResult { Success = true };
        }
    }
    public class SastojciResult : OperationResult
    {
        public List<SastojciItem> sastojci { get; set; }
    }
    public class SastojciSelect : Operation
    {
        public SastojciItem sastojak = new SastojciItem();        
        
        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<SastojciItem> sastojci = null;

            if (this.sastojak.IdSastojka == 0)
            {
                sastojci = from sastojak in restoran.Sastojcis
                           select new SastojciItem { IdSastojka = sastojak.Id_sastojka, NazivSastojka = sastojak.naziv };
            }
            else
            {
                sastojci = from sastojak in restoran.Sastojcis
                           where sastojak.Id_sastojka == this.sastojak.IdSastojka
                           select new SastojciItem { IdSastojka = sastojak.Id_sastojka, NazivSastojka = sastojak.naziv };
            }
            return new SastojciResult { Success = true, sastojci = sastojci.ToList() };           
        }
    }
    public class SastojciUpdate : Operation
    {
        public int Id { get; set; }
        public string naziv { get; set; }

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.SastojciUpdate(this.Id, this.naziv);
            return new OperationResult { Success = true };
        }
    }
}