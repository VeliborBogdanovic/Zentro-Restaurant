using Restaurant.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.BusinessLayer
{
    public class SastojciSelect:Operation
    {
        private int id = 0;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public override OperationResult execute(RestaurantEntities restoran)
        {
            IEnumerable<SastojciItem> sastojci = null;

            if (this.Id == 0)
            {
                sastojci = from sastojak in restoran.Sastojcis
                           select new SastojciItem {  IdSastojka=sastojak.Id_sastojka, NazivSastojka=sastojak.naziv };
            }
            else
            {
                sastojci = from sastojak in restoran.Sastojcis
                           where sastojak.Id_sastojka==this.Id
                           select new SastojciItem { IdSastojka = sastojak.Id_sastojka, NazivSastojka = sastojak.naziv };
            }
            SastojciResult rez = new SastojciResult();
            rez.sastojci = sastojci.ToList();
            rez.Success = true;
            return rez;

        }
    }
}