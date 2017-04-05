using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class PozicijeSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<PozicijeItem> pozicije = null;

            if (this.Id == 0)
            {
                pozicije = from poz in restoran.Pozicijes
                           select new PozicijeItem { idPozicije=poz.Id_pozicija,NazivPozicije=poz.naziv };
            }
            else
            {
                pozicije = from poz in restoran.Pozicijes
                           where poz.Id_pozicija == this.Id
                           select new PozicijeItem { idPozicije = poz.Id_pozicija, NazivPozicije = poz.naziv};
            }
            PozicijeResult rez = new PozicijeResult();
            rez.pozicije = pozicije.ToList();
            rez.Success = true;
            return rez;

        }
    }
    public class PozicijeResult : OperationResult
    {
        public List<PozicijeItem> pozicije { get; set; }
    }
}