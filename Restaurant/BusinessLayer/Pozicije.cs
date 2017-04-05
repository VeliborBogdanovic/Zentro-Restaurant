using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class PozicijeItem: RestoranItem
    {
        public int idPozicije { get; set; }
        public string NazivPozicije { get; set; }
    }

    public class PozicijeUpdate : Operation
    {
        public PozicijeItem pozicija = new PozicijeItem();

        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.PozicijeUpdate(this.pozicija.idPozicije, this.pozicija.NazivPozicije);
            return new OperationResult { Success = true };
        }
    }
    public class PozicijeResult : OperationResult
    {
        public List<PozicijeItem> pozicije { get; set; }
    }
    public class PozicijeSelect : Operation
    {
        public PozicijeItem pozicija = new PozicijeItem();

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<PozicijeItem> pozicije = null;

            if (this.pozicija.idPozicije == 0)          
            {
                pozicije = from poz in restoran.Pozicijes
                           select new PozicijeItem { idPozicije = poz.Id_pozicija, NazivPozicije = poz.naziv };
            }
            else
            {
                pozicije = from poz in restoran.Pozicijes
                           where poz.Id_pozicija == this.pozicija.idPozicije
                           select new PozicijeItem { idPozicije = poz.Id_pozicija, NazivPozicije = poz.naziv };
            }
           
           return new PozicijeResult { pozicije = pozicije.ToList(), Success = true };
        }
    }
    public class PozicijeInsert : Operation
    {
        public PozicijeItem pozicija = new PozicijeItem();
        public override OperationResult execute(RestaurantEntities entiteti)
        {
            entiteti.PozicijaInsert(this.pozicija.NazivPozicije);
            return new OperationResult { Success = true };
        }
    }
    public class PozicijeDelete : Operation
    {
        public PozicijeItem pozicija = new PozicijeItem();
        public override OperationResult execute(DataLayer.RestaurantEntities restaurant)
        {
            restaurant.PozicijeDelete(this.pozicija.idPozicije);
            return new OperationResult { Success = true };
        }
    }
}